﻿' ################################################################################
' #                             EMBER MEDIA MANAGER                              #
' ################################################################################
' ################################################################################
' # This file is part of Ember Media Manager.                                    #
' #                                                                              #
' # Ember Media Manager is free software: you can redistribute it and/or modify  #
' # it under the terms of the GNU General Public License as published by         #
' # the Free Software Foundation, either version 3 of the License, or            #
' # (at your option) any later version.                                          #
' #                                                                              #
' # Ember Media Manager is distributed in the hope that it will be useful,       #
' # but WITHOUT ANY WARRANTY; without even the implied warranty of               #
' # MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                #
' # GNU General Public License for more details.                                 #
' #                                                                              #
' # You should have received a copy of the GNU General Public License            #
' # along with Ember Media Manager.  If not, see <http://www.gnu.org/licenses/>. #
' ################################################################################

Option Explicit On
Imports System.IO



Public Class FileFolderRenamer
    Class FileRename
        Private _title As String
        Public Year As String
        Public BasePath As String
        Private _path As String
        Private _fileName As String
        Private _newPath As String
        Private _newFileName As String
        Public fType As Integer
        Public Resolution As String
        Public Audio As String
        Public Property Title() As String
            Get
                Return Me._title
            End Get
            Set(ByVal value As String)
                Me._title = value
            End Set
        End Property

        Public Property Path() As String
            Get
                Return Me._path
            End Get
            Set(ByVal value As String)
                Me._path = value
            End Set
        End Property
        Public Property FileName() As String
            Get
                Return Me._fileName
            End Get
            Set(ByVal value As String)
                Me._fileName = value
            End Set
        End Property
        Public Property NewPath() As String
            Get
                Return Me._newPath
            End Get
            Set(ByVal value As String)
                Me._newPath = value
            End Set
        End Property
        Public Property NewFileName() As String
            Get
                Return Me._newFileName
            End Get
            Set(ByVal value As String)
                Me._newFileName = value
            End Set
        End Property

    End Class
    Private _movies As New List(Of FileRename)
    Public MovieFolders As New ArrayList

    Public Sub New()
        _movies.Clear()
        Dim dirArray() As String
        For Each strFolders As String In Master.eSettings.MovieFolders
            dirArray = Split(strFolders, "|")
            MovieFolders.Add(dirArray(0).ToString)
        Next
    End Sub

    Public Sub AddMovie(ByVal _movie As FileRename)
        _movies.Add(_movie)
    End Sub

    Public Function GetMovies() As List(Of FileRename)
        Return _movies
    End Function

    Public Sub ProccessFiles(ByVal folderPattern As String, ByVal filePattern As String)
        Try
            For Each f As FileRename In _movies
                f.NewFileName = ProccessPattern(f, filePattern)
                f.NewPath = ProccessPattern(f, folderPattern)
            Next
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Function ProccessPattern(ByVal f As FileRename, ByVal pattern As String) As String
        Try
            pattern = pattern.Replace("$D", f.Path)
            pattern = pattern.Replace("$F", f.FileName)
            pattern = pattern.Replace("$T", f.Title)
            pattern = pattern.Replace("$Y", f.Year)
            pattern = pattern.Replace("$R", f.Resolution)
            pattern = pattern.Replace("$A", f.Audio)
            pattern = pattern.Replace("$t", f.Title.Replace(" ", "."))
            For Each Invalid As Char In Path.GetInvalidPathChars
                pattern = pattern.Replace(Invalid, String.Empty)
            Next
            pattern = pattern.Replace(":", "-")
            Return pattern
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return vbNullString
        End Try
    End Function

    Public Sub DoRename()
        Try
            For Each f As FileFolderRenamer.FileRename In _movies
                'Rename Directory
                If Not f.NewPath = f.Path Then
                    Dim srcDir As String = Path.Combine(f.BasePath, f.Path)
                    Dim destDir As String = Path.Combine(f.BasePath, f.NewPath)
                    System.IO.Directory.Move(srcDir, destDir)
                End If
                'Rename Files
                If Not f.NewFileName = f.FileName Then
                    Dim tmpList As New ArrayList

                    Dim di As New DirectoryInfo(Path.Combine(f.BasePath, f.NewPath))
                    Dim lFi As New List(Of FileInfo)
                    Try
                        lFi.AddRange(di.GetFiles())
                    Catch
                    End Try
                    If lFi.Count > 0 Then
                        lFi.Sort(AddressOf Master.SortFileNames)
                        Dim srcFile As String
                        Dim dstFile As String
                        For Each lFile As FileInfo In lFi
                            srcFile = lFile.FullName
                            dstFile = Path.Combine(Path.GetDirectoryName(lFile.FullName), Path.GetFileName(lFile.FullName).Replace(f.FileName, f.NewFileName))
                            If Not srcFile = dstFile Then
                                Dim fr = New System.IO.FileInfo(srcFile)
                                fr.MoveTo(dstFile)
                            End If
                        Next
                    End If
                End If
            Next
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub
    Public Shared Function RenameSingle(ByVal _tmpPath As String, ByVal _tmpMovie As Media.Movie, ByVal folderPattern As String, ByVal filePattern As String) As Boolean
        Dim bulkRename As New FileFolderRenamer
        Dim MovieFile As FileFolderRenamer.FileRename = New FileFolderRenamer.FileRename
        'bulkRename._movies.Clear()
        MovieFile.Title = _tmpMovie.Title
        MovieFile.Year = _tmpMovie.Year
        If Not IsNothing(_tmpMovie.FileInfo) AndAlso (Not IsNothing(_tmpMovie.FileInfo.StreamDetails.Video) OrElse _tmpMovie.FileInfo.StreamDetails.Audio.Count > 0) Then
            MovieFile.Resolution = Master.GetResFromDimensions(_tmpMovie.FileInfo)
            MovieFile.Audio = Master.GetBestAudio(_tmpMovie.FileInfo).Codec
        End If

        MovieFile.BasePath = Path.GetDirectoryName(_tmpPath)
        MovieFile.Path = Path.GetDirectoryName(_tmpPath)
        'MovieFile.NewFileName = bulkRename.ProccessPattern(MovieFile, folderPattern)
        'MovieFile.NewPath = bulkRename.ProccessPattern(MovieFile, filePattern)
        For Each i As String In bulkRename.MovieFolders
            If i = MovieFile.Path.Substring(0, i.Length) Then
                MovieFile.Path = MovieFile.Path.Substring(i.Length)
                If MovieFile.Path.Substring(0, 1) = Path.DirectorySeparatorChar Then
                    MovieFile.Path = MovieFile.Path.Substring(1)
                End If
                MovieFile.BasePath = i
                Exit For
            End If
        Next
        MovieFile.FileName = Path.GetFileNameWithoutExtension(Master.CleanStackingMarkers(_tmpPath))

        bulkRename.AddMovie(MovieFile)
        bulkRename.ProccessFiles(folderPattern, filePattern)
        bulkRename.DoRename()
        Return True
    End Function
End Class
