﻿'################################################################################
'#                             EMBER MEDIA MANAGER                              #
'################################################################################
'################################################################################
'# This file is part of Ember Media Manager.                                    #
'#                                                                              #
'# Ember Media Manager is free software: you can redistribute it and/or modify  #
'# it under the terms of the GNU General Public License as published by         #
'# the Free Software Foundation, either version 3 of the License, or            #
'# (at your option) any later version.                                          #
'#                                                                              #
'# Ember Media Manager is distributed in the hope that it will be useful,       #
'# but WITHOUT ANY WARRANTY; without even the implied warranty of               #
'# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                #
'# GNU General Public License for more details.                                 #
'#                                                                              #
'# You should have received a copy of the GNU General Public License            #
'# along with Ember Media Manager.  If not, see <http://www.gnu.org/licenses/>. #
'################################################################################

Imports System.IO
Imports System.Text.RegularExpressions

Public Class Scanner

    Public MoviePaths As New List(Of String)
    Public TVPaths As New List(Of String)
    Public htTVShows As New Hashtable
    Public ShowPath As String = String.Empty
    Public SourceLastScan As New DateTime

    Friend WithEvents bwPrelim As New System.ComponentModel.BackgroundWorker

    Public Event ScannerUpdated(ByVal iType As Integer, ByVal sText As String)
    Public Event ScanningCompleted()

    Private Structure Arguments
        Dim Scan As Master.Scans
        Dim SourceName As String
    End Structure

    Public Class Seasons
        Private _season As Integer
        Private _episodes As List(Of Integer)

        Public Property Season() As Integer
            Get
                Return _season
            End Get
            Set(ByVal value As Integer)
                _season = value
            End Set
        End Property

        Public Property Episodes() As List(Of Integer)
            Get
                Return _episodes
            End Get
            Set(ByVal value As List(Of Integer))
                _episodes = value
            End Set
        End Property

        Public Sub New()
            Me.Clear()
        End Sub

        Public Sub Clear()
            Me._season = -1
            Me._episodes = New List(Of Integer)
        End Sub
    End Class

    Public Class MovieContainer
        Private _filename As String
        Private _source As String
        Private _single As Boolean
        Private _usefolder As Boolean
        Private _poster As String
        Private _fanart As String
        Private _nfo As String
        Private _extra As String
        Private _trailer As String
        Private _subs As String

        Public Property Filename() As String
            Get
                Return _filename
            End Get
            Set(ByVal value As String)
                _filename = value
            End Set
        End Property

        Public Property Source() As String
            Get
                Return _source
            End Get
            Set(ByVal value As String)
                _source = value
            End Set
        End Property

        Public Property isSingle() As Boolean
            Get
                Return _single
            End Get
            Set(ByVal value As Boolean)
                _single = value
            End Set
        End Property

        Public Property UseFolder() As Boolean
            Get
                Return _usefolder
            End Get
            Set(ByVal value As Boolean)
                _usefolder = value
            End Set
        End Property

        Public Property Poster() As String
            Get
                Return _poster
            End Get
            Set(ByVal value As String)
                _poster = value
            End Set
        End Property

        Public Property Fanart() As String
            Get
                Return _fanart
            End Get
            Set(ByVal value As String)
                _fanart = value
            End Set
        End Property

        Public Property Nfo() As String
            Get
                Return _nfo
            End Get
            Set(ByVal value As String)
                _nfo = value
            End Set
        End Property

        Public Property Extra() As String
            Get
                Return _extra
            End Get
            Set(ByVal value As String)
                _extra = value
            End Set
        End Property

        Public Property Trailer() As String
            Get
                Return _trailer
            End Get
            Set(ByVal value As String)
                _trailer = value
            End Set
        End Property

        Public Property Subs() As String
            Get
                Return _subs
            End Get
            Set(ByVal value As String)
                _subs = value
            End Set
        End Property

        Public Sub New()
            Clear()
        End Sub

        Public Sub Clear()
            _filename = String.Empty
            _source = String.Empty
            _single = False
            _usefolder = False
            _poster = String.Empty
            _fanart = String.Empty
            _nfo = String.Empty
            _extra = String.Empty
            _trailer = String.Empty
            _subs = String.Empty
        End Sub
    End Class

    Public Class TVShowContainer
        Private _showpath As String
        Private _source As String
        Private _poster As String
        Private _fanart As String
        Private _nfo As String
        Private _episodes As New List(Of EpisodeContainer)

        Public Property ShowPath() As String
            Get
                Return _showpath
            End Get
            Set(ByVal value As String)
                _showpath = value
            End Set
        End Property

        Public Property Source() As String
            Get
                Return _source
            End Get
            Set(ByVal value As String)
                _source = value
            End Set
        End Property

        Public Property Poster() As String
            Get
                Return _poster
            End Get
            Set(ByVal value As String)
                _poster = value
            End Set
        End Property

        Public Property Fanart() As String
            Get
                Return _fanart
            End Get
            Set(ByVal value As String)
                _fanart = value
            End Set
        End Property

        Public Property Nfo() As String
            Get
                Return _nfo
            End Get
            Set(ByVal value As String)
                _nfo = value
            End Set
        End Property

        Public Property Episodes() As List(Of EpisodeContainer)
            Get
                Return _episodes
            End Get
            Set(ByVal value As List(Of EpisodeContainer))
                _episodes = value
            End Set
        End Property

        Public Sub New()
            Clear()
        End Sub

        Public Sub Clear()
            _showpath = String.Empty
            _source = String.Empty
            _poster = String.Empty
            _fanart = String.Empty
            _nfo = String.Empty
            _episodes.Clear()
        End Sub
    End Class

    Public Class EpisodeContainer
        Private _filename As String
        Private _source As String
        Private _poster As String
        Private _fanart As String
        Private _nfo As String

        Public Property Filename() As String
            Get
                Return _filename
            End Get
            Set(ByVal value As String)
                _filename = value
            End Set
        End Property

        Public Property Source() As String
            Get
                Return _source
            End Get
            Set(ByVal value As String)
                _source = value
            End Set
        End Property

        Public Property Poster() As String
            Get
                Return _poster
            End Get
            Set(ByVal value As String)
                _poster = value
            End Set
        End Property

        Public Property Fanart() As String
            Get
                Return _fanart
            End Get
            Set(ByVal value As String)
                _fanart = value
            End Set
        End Property

        Public Property Nfo() As String
            Get
                Return _nfo
            End Get
            Set(ByVal value As String)
                _nfo = value
            End Set
        End Property

        Public Sub New()
            Clear()
        End Sub

        Public Sub Clear()
            _filename = String.Empty
            _source = String.Empty
            _poster = String.Empty
            _fanart = String.Empty
            _nfo = String.Empty
        End Sub
    End Class

    Public Sub Start(ByVal Scan As Master.Scans, ByVal SourceName As String)
        Me.bwPrelim = New System.ComponentModel.BackgroundWorker
        Me.bwPrelim.WorkerReportsProgress = True
        Me.bwPrelim.WorkerSupportsCancellation = True
        Me.bwPrelim.RunWorkerAsync(New Arguments With {.Scan = Scan, .SourceName = SourceName})
    End Sub

    Public Function IsBusy() As Boolean
        Return bwPrelim.IsBusy
    End Function

    Public Sub Cancel()
        If Me.bwPrelim.IsBusy Then Me.bwPrelim.CancelAsync()
    End Sub

    Public Sub CancelAndWait()
        If bwPrelim.IsBusy Then bwPrelim.CancelAsync()
        While bwPrelim.IsBusy
            Application.DoEvents()
        End While
    End Sub

    ''' <summary>
    ''' Get all directories/movies in the parent directory
    ''' </summary>
    ''' <param name="sSource">Name of source.</param>
    ''' <param name="sPath">Path of source.</param>
    ''' <param name="bRecur">Scan directory recursively?</param>
    ''' <param name="bUseFolder">Use the folder name for initial title? (else uses file name)</param>
    ''' <param name="bSingle">Only detect one movie from each folder?</param>
    Public Sub ScanSourceDir(ByVal sSource As String, ByVal sPath As String, ByVal bRecur As Boolean, ByVal bUseFolder As Boolean, ByVal bSingle As Boolean)
        If Directory.Exists(sPath) Then
            Dim sMoviePath As String = String.Empty
            Dim dInfo As New DirectoryInfo(sPath)

            Try

                'check if there are any movies in the parent folder
                ScanForFiles(sPath, sSource, bUseFolder, bSingle)

                For Each inDir As DirectoryInfo In dInfo.GetDirectories.Where(Function(s) (Master.eSettings.IgnoreLastScan OrElse s.LastWriteTime > SourceLastScan) AndAlso isValidDir(s.FullName)).OrderBy(Function(d) d.Name)
                    If Me.bwPrelim.CancellationPending Then Return
                    ScanForFiles(inDir.FullName, sSource, bUseFolder, bSingle)
                    If bRecur Then
                        ScanSourceDir(sSource, inDir.FullName, bRecur, bUseFolder, bSingle)
                    End If
                Next


            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try

            dInfo = Nothing
        End If

    End Sub

    ''' <summary>
    ''' Find all related files in a directory.
    ''' </summary>
    ''' <param name="sPath">Full path of the directory.</param>
    ''' <param name="sSource">Name of source.</param>
    ''' <param name="bUseFolder">Use the folder name for initial title? (else uses file name)</param>
    ''' <param name="bSingle">Only detect one movie from each folder?</param>
    Public Sub ScanForFiles(ByVal sPath As String, ByVal sSource As String, ByVal bUseFolder As Boolean, ByVal bSingle As Boolean)

        Dim di As DirectoryInfo
        Dim lFi As New List(Of FileInfo)
        Dim fList As New List(Of FileInfo)
        Dim SkipStack As Boolean = False
        Dim vtsSingle As Boolean = False
        Dim bdmvSingle As Boolean = False
        Dim tFile As String = String.Empty
        Dim autoCheck As Boolean = False

        Try

            If Directory.Exists(Path.Combine(sPath, "VIDEO_TS")) Then
                di = New DirectoryInfo(Path.Combine(sPath, "VIDEO_TS"))
                bSingle = True
            ElseIf Directory.Exists(Path.Combine(sPath, String.Concat("BDMV", Path.DirectorySeparatorChar, "STREAM"))) Then
                di = New DirectoryInfo(Path.Combine(sPath, String.Concat("BDMV", Path.DirectorySeparatorChar, "STREAM")))
                bSingle = True
            Else
                di = New DirectoryInfo(sPath)
                autoCheck = True
            End If

            Try
                lFi.AddRange(di.GetFiles)
            Catch
            End Try

            If lFi.Count > 0 Then

                If Master.eSettings.AutoDetectBDMV AndAlso autoCheck Then
                    If lFi.Contains(New FileInfo(Path.Combine(sPath, "index.bdmv"))) Then
                        bdmvSingle = True
                        tFile = FileManip.Common.GetLongestFromRip(sPath, True)
                        If Me.bwPrelim.CancellationPending Then Return
                    End If
                End If

                If Not bdmvSingle AndAlso Master.eSettings.AutoDetectVTS AndAlso autoCheck Then
                    Dim hasIfo As Integer = 0
                    Dim hasVob As Integer = 0
                    Dim hasBup As Integer = 0
                    For Each lfile As FileInfo In lFi
                        If Path.GetExtension(lfile.FullName).ToLower = ".ifo" Then hasIfo = 1
                        If Path.GetExtension(lfile.FullName).ToLower = ".vob" Then hasVob = 1
                        If Path.GetExtension(lfile.FullName).ToLower = ".bup" Then hasBup = 1
                        If Path.GetFileName(lfile.FullName).ToLower = "video_ts.vob" Then
                            'video_ts.vob takes precedence
                            tFile = lfile.FullName
                        ElseIf String.IsNullOrEmpty(tFile) AndAlso (Path.GetFileName(lfile.FullName).ToLower = "video_ts.ifo" _
                        OrElse Path.GetFileName(lfile.FullName).ToLower = "video_ts.bup") Then
                            tFile = lfile.FullName
                        End If
                        vtsSingle = (hasIfo + hasVob + hasBup) > 1
                        If vtsSingle AndAlso Path.GetFileName(tFile).ToLower = "video_ts.vob" Then Exit For
                        If Me.bwPrelim.CancellationPending Then Return
                    Next
                End If

                If (vtsSingle OrElse bdmvSingle) AndAlso Not String.IsNullOrEmpty(tFile) Then
                    If Not MoviePaths.Contains(StringManip.CleanStackingMarkers(tFile.ToLower)) AndAlso _
                    Not Path.GetFileName(tFile).ToLower.Contains("-trailer") AndAlso Not Path.GetFileName(tFile).ToLower.Contains("[trailer") AndAlso _
                    Not Path.GetFileName(tFile).ToLower.Contains("sample") Then
                        If Master.eSettings.NoStackExts.Contains(Path.GetExtension(tFile).ToLower) Then
                            MoviePaths.Add(tFile.ToLower)
                        Else
                            MoviePaths.Add(StringManip.CleanStackingMarkers(tFile).ToLower)
                        End If
                        LoadMovie(New MovieContainer With {.Filename = tFile, .Source = sSource, .isSingle = True, .UseFolder = bUseFolder})
                    End If

                Else
                    fList.AddRange(lFi.Where(Function(f) Master.eSettings.ValidExts.Contains(f.Extension.ToLower) AndAlso _
                            Not f.Name.ToLower.Contains("-trailer") AndAlso Not f.Name.ToLower.Contains("[trailer") AndAlso _
                            Not f.Name.ToLower.Contains("sample") AndAlso ((Master.eSettings.SkipStackSizeCheck AndAlso _
                            StringManip.IsStacked(f.Name)) OrElse f.Length >= Master.eSettings.SkipLessThan * 1048576)))

                    For Each lFile As FileInfo In fList
                        If Not MoviePaths.Contains(StringManip.CleanStackingMarkers(lFile.FullName.ToLower)) Then
                            If Master.eSettings.NoStackExts.Contains(lFile.Extension.ToLower) Then
                                MoviePaths.Add(lFile.FullName.ToLower)
                                SkipStack = True
                            Else
                                MoviePaths.Add(StringManip.CleanStackingMarkers(lFile.FullName).ToLower)
                            End If

                            LoadMovie(New MovieContainer With {.Filename = lFile.FullName, .Source = sSource, .isSingle = If(fList.Count = 1, True, bSingle), .UseFolder = If(bSingle OrElse fList.Count = 1, bUseFolder, False)})
                            If bSingle AndAlso Not SkipStack Then Exit For
                        End If
                        If Me.bwPrelim.CancellationPending Then Return
                    Next
                End If

            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try

        di = Nothing
        lFi = Nothing
        fList = Nothing
    End Sub

    ''' <summary>
    ''' Check if we should scan the directory.
    ''' </summary>
    ''' <param name="sPath">Full path of the directory to check</param>
    ''' <returns>True if directory is valid, false if not.</returns>
    Public Function isValidDir(ByVal sPath As String) As Boolean

        Try

            sPath = sPath.Remove(0, sPath.IndexOf("\"))
            If Path.GetDirectoryName(sPath).ToLower = "extrathumbs" OrElse _
            Path.GetDirectoryName(sPath).ToLower = "extras" OrElse _
            Path.GetDirectoryName(sPath).ToLower = "video_ts" OrElse _
            Path.GetDirectoryName(sPath).ToLower = "bdmv" OrElse _
            Path.GetDirectoryName(sPath).ToLower = "audio_ts" OrElse _
            Path.GetDirectoryName(sPath).ToLower = "recycler" OrElse _
            Path.GetDirectoryName(sPath).ToLower = "subs" OrElse _
            Path.GetDirectoryName(sPath).ToLower = "subtitles" OrElse _
            sPath.ToLower.Contains("-trailer") OrElse _
            sPath.ToLower.Contains("[trailer") OrElse _
            sPath.ToLower.Contains("temporary files") OrElse _
            sPath.ToLower.Contains("(noscan)") OrElse _
            sPath.ToLower.Contains("$recycle.bin") OrElse _
            sPath.ToLower.Contains("lost+found") OrElse _
            sPath.ToLower.Contains("system volume information") OrElse _
            sPath.ToLower.Contains("sample") OrElse _
            sPath.Contains(":") Then
                Return False
            End If

        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return False
        End Try
        Return True 'This is the Else
    End Function

    ''' <summary>
    ''' Check if there are movies in the subdirectorys of a path.
    ''' </summary>
    ''' <param name="MovieDir">DirectoryInfo object of directory to scan.</param>
    ''' <returns>True if the path's subdirectories contain movie files, else false.</returns>
    Public Function SubDirsHaveMovies(ByVal MovieDir As DirectoryInfo) As Boolean
        Try
            If Directory.Exists(MovieDir.FullName) Then

                For Each inDir As DirectoryInfo In MovieDir.GetDirectories
                    If isValidDir(inDir.FullName) Then
                        If ScanSubs(inDir) Then Return True
                        SubDirsHaveMovies(inDir)
                    End If
                Next

            End If
            Return False
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Check if a path contains movies.
    ''' </summary>
    ''' <param name="inDir">DirectoryInfo object of directory to scan</param>
    ''' <returns>True if directory contains movie files.</returns>
    Public Function ScanSubs(ByVal inDir As DirectoryInfo) As Boolean
        Try

            If inDir.GetFiles.Where(Function(s) Master.eSettings.ValidExts.Contains(s.Extension.ToLower) AndAlso _
                                                      Not s.Name.ToLower.Contains("-trailer") AndAlso Not s.Name.ToLower.Contains("[trailer") AndAlso _
                                                      Not s.Name.ToLower.Contains("sample")).OrderBy(Function(s) s.Name).Count > 0 Then Return True

        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Check if a directory contains supporting files (nfo, poster, fanart, etc)
    ''' </summary>
    ''' <param name="sPath">MovieContainer object.</param>
    Public Sub GetMovieFolderContents(ByRef Movie As MovieContainer)

        Dim tmpName As String = String.Empty
        Dim tmpNameNoStack As String = String.Empty
        Dim currname As String = String.Empty
        Dim parPath As String = String.Empty
        Dim isYAMJ As Boolean = False
        Dim fList As New List(Of String)

        Try
            If Master.eSettings.VideoTSParent AndAlso FileManip.Common.isVideoTS(Movie.Filename) Then
                isYAMJ = True

                Try
                    fList.AddRange(Directory.GetFiles(Directory.GetParent(Directory.GetParent(Movie.Filename).FullName).FullName))
                Catch
                End Try

                parPath = Directory.GetParent(Directory.GetParent(Movie.Filename).FullName).FullName.ToLower
                tmpName = Path.Combine(parPath, StringManip.CleanStackingMarkers(Directory.GetParent(Directory.GetParent(Movie.Filename).FullName).Name)).ToLower
                tmpNameNoStack = Path.Combine(parPath, Directory.GetParent(Directory.GetParent(Movie.Filename).FullName).Name).ToLower

                If Movie.isSingle AndAlso File.Exists(String.Concat(Directory.GetParent(Directory.GetParent(Movie.Filename).FullName).FullName, Path.DirectorySeparatorChar, "extrathumbs", Path.DirectorySeparatorChar, "thumb1.jpg")) Then
                    Movie.Extra = String.Concat(Directory.GetParent(Directory.GetParent(Movie.Filename).FullName).FullName, Path.DirectorySeparatorChar, "extrathumbs", Path.DirectorySeparatorChar, "thumb1.jpg")
                End If
            ElseIf Master.eSettings.VideoTSParent AndAlso FileManip.Common.isBDRip(Movie.Filename) Then
                isYAMJ = True

                Try
                    fList.AddRange(Directory.GetFiles(Directory.GetParent(Directory.GetParent(Directory.GetParent(Movie.Filename).FullName).FullName).FullName))
                Catch
                End Try

                parPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Movie.Filename).FullName).FullName).FullName.ToLower
                tmpName = Path.Combine(parPath, StringManip.CleanStackingMarkers(Directory.GetParent(Directory.GetParent(Directory.GetParent(Movie.Filename).FullName).FullName).Name)).ToLower
                tmpNameNoStack = Path.Combine(parPath, Directory.GetParent(Directory.GetParent(Directory.GetParent(Movie.Filename).FullName).FullName).Name).ToLower

                If Movie.isSingle AndAlso File.Exists(String.Concat(Directory.GetParent(Directory.GetParent(Movie.Filename).FullName).FullName, Path.DirectorySeparatorChar, "extrathumbs", Path.DirectorySeparatorChar, "thumb1.jpg")) Then
                    Movie.Extra = String.Concat(Directory.GetParent(Directory.GetParent(Movie.Filename).FullName).FullName, Path.DirectorySeparatorChar, "extrathumbs", Path.DirectorySeparatorChar, "thumb1.jpg")
                End If
            Else
                If Movie.isSingle Then
                    fList.AddRange(Directory.GetFiles(Directory.GetParent(Movie.Filename).FullName))
                Else
                    Try
                        Dim sName As String = StringManip.CleanStackingMarkers(Path.GetFileNameWithoutExtension(Movie.Filename), True)
                        fList.AddRange(Directory.GetFiles(Directory.GetParent(Movie.Filename).FullName, If(sName.EndsWith("*"), sName, String.Concat(sName, "*"))))
                    Catch
                    End Try
                End If

                parPath = Directory.GetParent(Movie.Filename).FullName.ToLower
                tmpName = Path.Combine(parPath, StringManip.CleanStackingMarkers(Path.GetFileNameWithoutExtension(Movie.Filename))).ToLower
                tmpNameNoStack = Path.Combine(parPath, Path.GetFileNameWithoutExtension(Movie.Filename)).ToLower


                If Movie.isSingle AndAlso File.Exists(String.Concat(Directory.GetParent(Movie.Filename).FullName, Path.DirectorySeparatorChar, "extrathumbs", Path.DirectorySeparatorChar, "thumb1.jpg")) Then
                    Movie.Extra = String.Concat(Directory.GetParent(Movie.Filename).FullName, Path.DirectorySeparatorChar, "extrathumbs", Path.DirectorySeparatorChar, "thumb1.jpg")
                End If
            End If

            For Each fFile As String In fList
                'fanart
                If String.IsNullOrEmpty(Movie.Fanart) Then
                    If (Movie.isSingle AndAlso Master.eSettings.FanartJPG AndAlso fFile.ToLower = Path.Combine(parPath, "fanart.jpg")) _
                        OrElse ((Not Movie.isSingle OrElse Not Master.eSettings.MovieNameMultiOnly) AndAlso _
                                ((Master.eSettings.MovieNameFanartJPG AndAlso fFile.ToLower = String.Concat(tmpNameNoStack, "-fanart.jpg")) _
                                OrElse (Master.eSettings.MovieNameFanartJPG AndAlso fFile.ToLower = String.Concat(tmpName, "-fanart.jpg")) _
                                OrElse (Master.eSettings.MovieNameFanartJPG AndAlso (fFile.ToLower = Path.Combine(parPath, "video_ts-fanart.jpg") OrElse fFile.ToLower = Path.Combine(parPath, "index-fanart.jpg")))) _
                                OrElse (Master.eSettings.MovieNameDotFanartJPG AndAlso (fFile.ToLower = Path.Combine(parPath, "video_ts.fanart.jpg") OrElse fFile.ToLower = Path.Combine(parPath, "index.fanart.jpg")))) _
                        OrElse ((Not Movie.isSingle OrElse isYAMJ OrElse Not Master.eSettings.MovieNameMultiOnly) AndAlso _
                                (((Master.eSettings.MovieNameDotFanartJPG OrElse isYAMJ) AndAlso fFile.ToLower = String.Concat(tmpName, ".fanart.jpg")) _
                                OrElse ((Master.eSettings.MovieNameDotFanartJPG OrElse isYAMJ) AndAlso fFile.ToLower = String.Concat(tmpNameNoStack, ".fanart.jpg")))) Then

                        Movie.Fanart = fFile
                        Continue For
                    End If
                End If

                'poster
                If String.IsNullOrEmpty(Movie.Poster) Then
                    If (Movie.isSingle AndAlso (Master.eSettings.MovieTBN AndAlso fFile.ToLower = Path.Combine(parPath, "movie.tbn")) _
                                OrElse (Master.eSettings.PosterTBN AndAlso fFile.ToLower = Path.Combine(parPath, "poster.tbn")) _
                                OrElse (Master.eSettings.MovieJPG AndAlso fFile.ToLower = Path.Combine(parPath, "movie.jpg")) _
                                OrElse (Master.eSettings.PosterJPG AndAlso fFile.ToLower = Path.Combine(parPath, "poster.jpg")) _
                                OrElse (Master.eSettings.FolderJPG AndAlso fFile.ToLower = Path.Combine(parPath, "folder.jpg"))) _
                        OrElse ((Not Movie.isSingle OrElse Not Master.eSettings.MovieNameMultiOnly) AndAlso _
                                ((Master.eSettings.MovieNameTBN AndAlso fFile.ToLower = Path.Combine(parPath, "video_ts.tbn")) _
                                OrElse (Master.eSettings.MovieNameJPG AndAlso fFile.ToLower = Path.Combine(parPath, "video_ts.jpg")))) _
                        OrElse ((Not Movie.isSingle OrElse Not Master.eSettings.MovieNameMultiOnly) AndAlso _
                                ((Master.eSettings.MovieNameTBN AndAlso fFile.ToLower = Path.Combine(parPath, "index.tbn")) _
                                OrElse (Master.eSettings.MovieNameJPG AndAlso fFile.ToLower = Path.Combine(parPath, "index.jpg")))) _
                        OrElse ((Not Movie.isSingle OrElse isYAMJ OrElse Not Master.eSettings.MovieNameMultiOnly) AndAlso _
                                (((Master.eSettings.MovieNameTBN OrElse isYAMJ) AndAlso fFile.ToLower = String.Concat(tmpNameNoStack, ".tbn")) _
                                OrElse ((Master.eSettings.MovieNameTBN OrElse isYAMJ) AndAlso fFile.ToLower = String.Concat(tmpName, ".tbn")) _
                                OrElse ((Master.eSettings.MovieNameJPG OrElse isYAMJ) AndAlso fFile.ToLower = String.Concat(tmpNameNoStack, ".jpg")) _
                                OrElse ((Master.eSettings.MovieNameJPG OrElse isYAMJ) AndAlso fFile.ToLower = String.Concat(tmpName, ".jpg")))) Then
                        Movie.Poster = fFile
                        Continue For
                    End If
                End If

                'nfo
                If String.IsNullOrEmpty(Movie.Nfo) Then
                    If (Movie.isSingle AndAlso Master.eSettings.MovieNFO AndAlso fFile.ToLower = Path.Combine(parPath, "movie.nfo")) _
                    OrElse ((Not Movie.isSingle OrElse isYAMJ OrElse Not Master.eSettings.MovieNameMultiOnly) AndAlso _
                    (((Master.eSettings.MovieNameNFO OrElse isYAMJ) AndAlso fFile.ToLower = String.Concat(tmpNameNoStack, ".nfo")) _
                    OrElse ((Master.eSettings.MovieNameNFO OrElse isYAMJ) AndAlso fFile.ToLower = String.Concat(tmpName, ".nfo")))) Then
                        Movie.Nfo = fFile
                        Continue For
                    End If
                End If

                If String.IsNullOrEmpty(Movie.Subs) Then
                    If Regex.IsMatch(fFile.ToLower, String.Concat("^", Regex.Escape(tmpNameNoStack), "(\.(.*?))?\.(sst|srt|sub|ssa|aqt|smi|sami|jss|mpl|rt|idx|ass)$"), RegexOptions.IgnoreCase) OrElse _
                                Regex.IsMatch(fFile.ToLower, String.Concat("^", Regex.Escape(tmpName), "(\.(.*?))?\.(sst|srt|sub|ssa|aqt|smi|sami|jss|mpl|rt|idx|ass)$"), RegexOptions.IgnoreCase) Then
                        Movie.Subs = fFile
                        Continue For
                    End If
                End If

                If String.IsNullOrEmpty(Movie.Trailer) Then
                    For Each t As String In Master.eSettings.ValidExts
                        Select Case True
                            Case fFile.ToLower = String.Concat(tmpNameNoStack, "-trailer", t.ToLower)
                                Movie.Trailer = fFile
                                Exit For
                            Case fFile.ToLower = String.Concat(tmpName, "-trailer", t.ToLower)
                                Movie.Trailer = fFile
                                Exit For
                            Case fFile.ToLower = String.Concat(tmpNameNoStack, "[trailer]", t.ToLower)
                                Movie.Trailer = fFile
                                Exit For
                            Case fFile.ToLower = String.Concat(tmpName, "[trailer]", t.ToLower)
                                Movie.Trailer = fFile
                                Exit For
                            Case Movie.isSingle AndAlso fFile.ToLower = Path.Combine(parPath, String.Concat("movie-trailer", t.ToLower))
                                Movie.Trailer = fFile
                                Exit For
                            Case Movie.isSingle AndAlso fFile.ToLower = Path.Combine(parPath, String.Concat("movie[trailer]", t.ToLower))
                                Movie.Trailer = fFile
                                Exit For
                        End Select
                    Next
                End If

                If Not String.IsNullOrEmpty(Movie.Poster) AndAlso Not String.IsNullOrEmpty(Movie.Fanart) _
                AndAlso Not String.IsNullOrEmpty(Movie.Nfo) AndAlso Not String.IsNullOrEmpty(Movie.Trailer) _
                AndAlso Not String.IsNullOrEmpty(Movie.Subs) AndAlso Not String.IsNullOrEmpty(Movie.Extra) Then
                    Exit For
                End If
            Next

        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try

        fList = Nothing

    End Sub

    ''' <summary>
    ''' Check if a directory contains supporting files (nfo, poster)
    ''' </summary>
    ''' <param name="sPath">Full path to directory.</param>
    Public Sub GetEpFolderContents(ByRef Episode As EpisodeContainer)

        Dim tmpName As String = String.Empty
        Dim fName As String = String.Empty
        Dim fList As New List(Of String)

        Try
            Try
                fList.AddRange(Directory.GetFiles(Directory.GetParent(Episode.Filename).FullName, String.Concat(Path.GetFileNameWithoutExtension(Episode.Filename), "*.*")))
            Catch
            End Try

            tmpName = Path.Combine(Directory.GetParent(Episode.Filename).FullName, Path.GetFileNameWithoutExtension(Episode.Filename))

            If Master.eSettings.EpisodeTBN Then
                fName = String.Concat(tmpName, ".tbn")
                Episode.Poster = fList.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
            End If

            If String.IsNullOrEmpty(Episode.Poster) AndAlso Master.eSettings.EpisodeJPG Then
                fName = String.Concat(tmpName, ".jpg")
                Episode.Poster = fList.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
            End If

            If Master.eSettings.EpisodeDashFanart Then
                fName = String.Concat(tmpName, "-fanart.jpg")
                Episode.Fanart = fList.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
            End If

            If String.IsNullOrEmpty(Episode.Fanart) AndAlso Master.eSettings.EpisodeDotFanart Then
                fName = String.Concat(tmpName, "-fanart.jpg")
                Episode.Fanart = fList.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
            End If

            fName = String.Concat(tmpName, ".nfo")
            Episode.Nfo = fList.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)

        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try

        fList = Nothing

    End Sub

    ''' <summary>
    ''' Check if a directory contains supporting files (nfo, poster)
    ''' </summary>
    ''' <param name="tShow">TVShowContainer object.</param>
    Public Sub GetShowFolderContents(ByRef tShow As TVShowContainer)

        Dim parPath As String = tShow.ShowPath
        Dim fList As New List(Of String)
        Dim fName As String = String.Empty

        Try
            Try
                fList.AddRange(Directory.GetFiles(tShow.ShowPath))
            Catch
            End Try

            If Master.eSettings.ShowSeasonAll Then
                fName = Path.Combine(parPath, "season-all.tbn")
                tShow.Poster = fList.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
            End If

            If String.IsNullOrEmpty(tShow.Poster) AndAlso Master.eSettings.ShowFolderJPG Then
                fName = Path.Combine(parPath, "folder.jpg")
                tShow.Poster = fList.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
            End If

            If String.IsNullOrEmpty(tShow.Poster) AndAlso Master.eSettings.ShowPosterTBN Then
                fName = Path.Combine(parPath, "poster.tbn")
                tShow.Poster = fList.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
            End If

            If String.IsNullOrEmpty(tShow.Poster) AndAlso Master.eSettings.ShowPosterJPG Then
                fName = Path.Combine(parPath, "poster.jpg")
                tShow.Poster = fList.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
            End If

            If Master.eSettings.ShowFanartJPG Then
                fName = Path.Combine(parPath, "fanart.jpg")
                tShow.Fanart = fList.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
            End If

            If String.IsNullOrEmpty(tShow.Fanart) AndAlso Master.eSettings.ShowDashFanart Then
                fName = Path.Combine(parPath, String.Concat(Path.GetFileNameWithoutExtension(parPath), "-fanart.jpg"))
                tShow.Fanart = fList.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
            End If

            If String.IsNullOrEmpty(tShow.Fanart) AndAlso Master.eSettings.ShowDotFanart Then
                fName = Path.Combine(parPath, String.Concat(Path.GetFileNameWithoutExtension(parPath), ".fanart.jpg"))
                tShow.Fanart = fList.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
            End If

            fName = Path.Combine(parPath, "tvshow.nfo")
            tShow.Nfo = fList.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)

        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try

        fList = Nothing
    End Sub

    ''' <summary>
    ''' Get the full path to a trailer, if it exists.
    ''' </summary>
    ''' <param name="sPath">Full path to a movie file for which you are trying to find the accompanying trailer.</param>
    ''' <returns>Full path of trailer file.</returns>
    Public Function GetTrailerPath(ByVal sPath As String) As String

        Dim tFile As String = String.Empty

        Dim parPath As String = Directory.GetParent(sPath).FullName
        Dim tmpName As String = Path.Combine(parPath, StringManip.CleanStackingMarkers(Path.GetFileNameWithoutExtension(sPath)))
        Dim tmpNameNoStack As String = Path.Combine(parPath, Path.GetFileNameWithoutExtension(sPath))
        For Each t As String In Master.eSettings.ValidExts
            If File.Exists(String.Concat(tmpName, "-trailer", t)) Then
                tFile = String.Concat(tmpName, "-trailer", t)
                Exit For
            ElseIf File.Exists(String.Concat(tmpName, "[trailer]", t)) Then
                tFile = String.Concat(tmpName, "[trailer]", t)
                Exit For
            ElseIf File.Exists(String.Concat(tmpNameNoStack, "-trailer", t)) Then
                tFile = String.Concat(tmpNameNoStack, "-trailer", t)
                Exit For
            ElseIf File.Exists(String.Concat(tmpNameNoStack, "[trailer]", t)) Then
                tFile = String.Concat(tmpNameNoStack, "[trailer]", t)
                Exit For
            End If
        Next

        Return tFile

    End Function

    ''' <summary>
    ''' Get all directories in the parent directory
    ''' </summary>
    ''' <param name="sSource">Name of source.</param>
    ''' <param name="sPath">Path of source.</param>
    Public Sub ScanTVSourceDir(ByVal sSource As String, ByVal sPath As String, Optional ByVal isInner As Boolean = False)

        If Directory.Exists(sPath) Then

            Dim currShowContainer As TVShowContainer
            Dim dInfo As New DirectoryInfo(sPath)
            Dim inInfo As DirectoryInfo

            Try


                For Each inDir As DirectoryInfo In dInfo.GetDirectories.Where(Function(d) isValidDir(d.FullName)).OrderBy(Function(d) d.Name)
                    currShowContainer = New TVShowContainer
                    currShowContainer.ShowPath = inDir.FullName
                    currShowContainer.Source = sSource
                    Me.ScanForTVFiles(currShowContainer, inDir.FullName)

                    inInfo = New DirectoryInfo(inDir.FullName)

                    For Each sDirs As DirectoryInfo In inInfo.GetDirectories.Where(Function(d) Regex.IsMatch(d.Name, "((s(eason)?)?([\W_])?([0-9]+))|specials?", RegexOptions.IgnoreCase) AndAlso (Master.eSettings.TVIgnoreLastScan OrElse d.LastWriteTime > SourceLastScan) AndAlso isValidDir(d.FullName)).OrderBy(Function(d) d.Name)
                        Me.ScanForTVFiles(currShowContainer, sDirs.FullName)
                    Next

                    LoadShow(currShowContainer)
                Next

            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try
            dInfo = Nothing
            inInfo = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Find all related files in a directory.
    ''' </summary>
    ''' <param name="sPath">Full path of the directory.</param>
    ''' <param name="sSource">Name of source.</param>
    Public Sub ScanForTVFiles(ByRef tShow As TVShowContainer, ByVal sPath As String)

        Dim di As New DirectoryInfo(sPath)
        Try

            For Each lFile As FileInfo In di.GetFiles.Where(Function(f) Not TVPaths.Contains(f.FullName.ToLower) AndAlso Master.eSettings.ValidExts.Contains(f.Extension.ToLower) AndAlso _
                    Not f.Name.ToLower.Contains("-trailer") AndAlso Not f.Name.ToLower.Contains("[trailer") AndAlso Not f.Name.ToLower.Contains("sample") AndAlso _
                    f.Length >= Master.eSettings.SkipLessThan * 1048576).OrderBy(Function(s) s.Name)
                tShow.Episodes.Add(New EpisodeContainer With {.Filename = lFile.FullName, .Source = tShow.Source})
            Next

        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
        di = Nothing
    End Sub

    Private Sub bwPrelim_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwPrelim.DoWork

        Try
            Dim Args As Arguments = DirectCast(e.Argument, Arguments)
            Dim mPath As String = String.Empty

            Master.DB.SaveMovieList()

            If Args.Scan.Movies Then
                MoviePaths.Clear()
                Using SQLcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                    SQLcommand.CommandText = "SELECT Movies.MoviePath FROM Movies;"
                    Using SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                        While SQLreader.Read
                            mPath = SQLreader("MoviePath").ToString.ToLower
                            If Master.eSettings.NoStackExts.Contains(Path.GetExtension(mPath)) Then
                                MoviePaths.Add(mPath)
                            Else
                                MoviePaths.Add(StringManip.CleanStackingMarkers(mPath))
                            End If
                            If Me.bwPrelim.CancellationPending Then
                                e.Cancel = True
                                Return
                            End If
                        End While
                    End Using
                End Using

                Using SQLTrans As SQLite.SQLiteTransaction = Master.DB.BeginTransaction
                    Using SQLcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                        If Not String.IsNullOrEmpty(Args.SourceName) Then
                            SQLcommand.CommandText = String.Format("SELECT * FROM sources WHERE Name = ""{0}"";", Args.SourceName)
                        Else
                            SQLcommand.CommandText = "SELECT * FROM sources;"
                        End If

                        Using SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                            Using SQLUpdatecommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                                SQLUpdatecommand.CommandText = "UPDATE sources SET LastScan = (?) WHERE ID = (?);"
                                Dim parLastScan As SQLite.SQLiteParameter = SQLUpdatecommand.Parameters.Add("parLastScan", DbType.String, 0, "LastScan")
                                Dim parID As SQLite.SQLiteParameter = SQLUpdatecommand.Parameters.Add("parID", DbType.Int32, 0, "ID")
                                While SQLreader.Read
                                    SourceLastScan = Convert.ToDateTime(SQLreader("LastScan").ToString)
                                    If Convert.ToBoolean(SQLreader("Recursive")) OrElse (Master.eSettings.IgnoreLastScan OrElse Directory.GetLastWriteTime(SQLreader("Path").ToString) > SourceLastScan) Then
                                        'save the scan time back to the db
                                        parLastScan.Value = Now
                                        parID.Value = SQLreader("ID")
                                        SQLUpdatecommand.ExecuteNonQuery()
                                        ScanSourceDir(SQLreader("Name").ToString, SQLreader("Path").ToString, Convert.ToBoolean(SQLreader("Recursive")), Convert.ToBoolean(SQLreader("Foldername")), Convert.ToBoolean(SQLreader("Single")))
                                    End If
                                    If Me.bwPrelim.CancellationPending Then
                                        e.Cancel = True
                                        Return
                                    End If
                                End While
                            End Using
                        End Using
                    End Using
                    SQLTrans.Commit()
                End Using
            End If

            If Args.Scan.TV Then
                htTVShows.Clear()
                Using SQLcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                    SQLcommand.CommandText = "SELECT ID, TVShowPath FROM TVShows;"
                    Using SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                        While SQLreader.Read
                            htTVShows.Add(SQLreader("TVShowPath").ToString.ToLower, SQLreader("ID"))
                            If Me.bwPrelim.CancellationPending Then
                                e.Cancel = True
                                Return
                            End If
                        End While
                    End Using
                End Using

                TVPaths.Clear()
                Using SQLcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                    SQLcommand.CommandText = "SELECT TVEpPath FROM TVEpPaths;"
                    Using SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                        While SQLreader.Read
                            TVPaths.Add(SQLreader("TVEpPath").ToString.ToLower)
                            If Me.bwPrelim.CancellationPending Then
                                e.Cancel = True
                                Return
                            End If
                        End While
                    End Using
                End Using

                Using SQLTrans As SQLite.SQLiteTransaction = Master.DB.BeginTransaction
                    Using SQLcommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                        If Not String.IsNullOrEmpty(Args.SourceName) Then
                            SQLcommand.CommandText = String.Format("SELECT * FROM TVSources WHERE Name = ""{0}"";", Args.SourceName)
                        Else
                            SQLcommand.CommandText = "SELECT * FROM TVSources;"
                        End If

                        Using SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                            Using SQLUpdatecommand As SQLite.SQLiteCommand = Master.DB.CreateCommand
                                SQLUpdatecommand.CommandText = "UPDATE TVSources SET LastScan = (?) WHERE ID = (?);"
                                Dim parLastScan As SQLite.SQLiteParameter = SQLUpdatecommand.Parameters.Add("parLastScan", DbType.String, 0, "LastScan")
                                Dim parID As SQLite.SQLiteParameter = SQLUpdatecommand.Parameters.Add("parID", DbType.Int32, 0, "ID")
                                While SQLreader.Read
                                    SourceLastScan = Convert.ToDateTime(SQLreader("LastScan").ToString)
                                    'save the scan time back to the db
                                    parLastScan.Value = Now
                                    parID.Value = SQLreader("ID")
                                    SQLUpdatecommand.ExecuteNonQuery()
                                    ScanTVSourceDir(SQLreader("Name").ToString, SQLreader("Path").ToString)
                                    If Me.bwPrelim.CancellationPending Then
                                        e.Cancel = True
                                        Return
                                    End If
                                End While
                            End Using
                        End Using
                    End Using
                    SQLTrans.Commit()
                End Using
            End If

            'remove any db entries that no longer exist
            Master.DB.Clean(Master.eSettings.CleanDB, Master.eSettings.TVCleanDB)
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            e.Cancel = True
        End Try

    End Sub

    Private Sub bwPrelim_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwPrelim.ProgressChanged
        RaiseEvent ScannerUpdated(e.ProgressPercentage, e.UserState.ToString)
    End Sub

    Private Sub bwPrelim_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwPrelim.RunWorkerCompleted

        If Not e.Cancelled Then
            RaiseEvent ScanningCompleted()
        End If

    End Sub

    Private Sub GetSeasonImages(ByRef TVDB As Master.DBTV, ByVal sSeason As Integer)

        Dim SeasonPath As String = String.Empty
        Dim bInside As Boolean = False
        Dim lFiles As New List(Of String)
        Dim fName As String = String.Empty

        Try
            If Regex.IsMatch(Directory.GetParent(TVDB.Filename).Name, "((s(eason)?)?([\W_])?([0-9]+))|specials?", RegexOptions.IgnoreCase) Then
                SeasonPath = Directory.GetParent(Directory.GetParent(TVDB.Filename).FullName).FullName
                bInside = True
            Else
                SeasonPath = Directory.GetParent(TVDB.Filename).FullName
            End If

            Try
                lFiles.AddRange(Directory.GetFiles(SeasonPath, "season*.tbn"))
            Catch
            End Try

            If lFiles.Count > 0 Then
                If Master.eSettings.SeasonX OrElse Master.eSettings.SeasonXX Then
                    If sSeason = 0 Then
                        fName = Path.Combine(SeasonPath, "season-specials.tbn")
                    Else
                        If Master.eSettings.SeasonXX Then
                            fName = Path.Combine(SeasonPath, String.Format("season{0}.tbn", sSeason.ToString.PadLeft(2, Convert.ToChar("0"))))
                        Else
                            fName = Path.Combine(SeasonPath, String.Format("season{0}.tbn", sSeason.ToString))
                        End If
                    End If
                    TVDB.SeasonPosterPath = lFiles.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
                End If
            End If

            If bInside AndAlso ((Master.eSettings.SeasonPosterTBN OrElse Master.eSettings.SeasonPosterJPG OrElse _
                                Master.eSettings.SeasonNameTBN OrElse Master.eSettings.SeasonNameJPG OrElse _
                                Master.eSettings.SeasonFolderJPG AndAlso String.IsNullOrEmpty(TVDB.SeasonPosterPath)) OrElse _
                                (Master.eSettings.SeasonFanartJPG OrElse Master.eSettings.SeasonDashFanart OrElse _
                                 Master.eSettings.SeasonDotFanart AndAlso String.IsNullOrEmpty(TVDB.SeasonFanartPath))) Then
                SeasonPath = Directory.GetParent(TVDB.Filename).FullName

                lFiles.Clear()
                Try
                    lFiles.AddRange(Directory.GetFiles(Directory.GetParent(TVDB.Filename).FullName))
                Catch
                End Try

                If String.IsNullOrEmpty(TVDB.SeasonPosterPath) Then
                    If String.IsNullOrEmpty(TVDB.SeasonPosterPath) AndAlso Master.eSettings.SeasonPosterTBN Then
                        fName = Path.Combine(SeasonPath, "poster.tbn")
                        TVDB.SeasonPosterPath = lFiles.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
                    End If

                    If String.IsNullOrEmpty(TVDB.SeasonPosterPath) AndAlso Master.eSettings.SeasonPosterJPG Then
                        fName = Path.Combine(SeasonPath, "poster.jpg")
                        TVDB.SeasonPosterPath = lFiles.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
                    End If

                    If String.IsNullOrEmpty(TVDB.SeasonPosterPath) AndAlso Master.eSettings.SeasonNameTBN Then
                        fName = Path.Combine(SeasonPath, String.Concat(Directory.GetParent(TVDB.Filename).Name, ".tbn"))
                        TVDB.SeasonPosterPath = lFiles.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
                    End If

                    If String.IsNullOrEmpty(TVDB.SeasonPosterPath) AndAlso Master.eSettings.SeasonNameJPG Then
                        fName = Path.Combine(SeasonPath, String.Concat(Directory.GetParent(TVDB.Filename).Name, ".jpg"))
                        TVDB.SeasonPosterPath = lFiles.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
                    End If

                    If String.IsNullOrEmpty(TVDB.SeasonPosterPath) AndAlso Master.eSettings.SeasonFolderJPG Then
                        fName = Path.Combine(SeasonPath, "folder.jpg")
                        TVDB.SeasonPosterPath = lFiles.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
                    End If
                End If

                If String.IsNullOrEmpty(TVDB.SeasonFanartPath) Then
                    If String.IsNullOrEmpty(TVDB.SeasonFanartPath) AndAlso Master.eSettings.SeasonFanartJPG Then
                        fName = Path.Combine(SeasonPath, "fanart.jpg")
                        TVDB.SeasonFanartPath = lFiles.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
                    End If

                    If String.IsNullOrEmpty(TVDB.SeasonFanartPath) AndAlso Master.eSettings.SeasonDashFanart Then
                        fName = Path.Combine(SeasonPath, String.Concat(Directory.GetParent(TVDB.Filename).Name, "-fanart.jpg"))
                        TVDB.SeasonFanartPath = lFiles.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
                    End If

                    If String.IsNullOrEmpty(TVDB.SeasonFanartPath) AndAlso Master.eSettings.SeasonDotFanart Then
                        fName = Path.Combine(SeasonPath, String.Concat(Directory.GetParent(TVDB.Filename).Name, ".fanart.jpg"))
                        TVDB.SeasonFanartPath = lFiles.FirstOrDefault(Function(s) s.ToLower = fName.ToLower)
                    End If
                End If
            End If

        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try

        lFiles = Nothing
    End Sub

    Public Shared Function GetSeasons(ByVal sPath As String) As List(Of Seasons)

        Dim retSeason As New List(Of Seasons)
        Dim epMatch As String = String.Empty
        Dim cSeason As Seasons

        For Each rShow As emmSettings.TVShowRegEx In Master.eSettings.TVShowRegexes

            Try

                For Each sMatch As Match In Regex.Matches(If(rShow.SeasonFromDirectory, Path.GetDirectoryName(sPath), Path.GetFileNameWithoutExtension(sPath)), rShow.SeasonRegex, RegexOptions.IgnoreCase)
                    Try
                        cSeason = New Seasons
                        If IsNumeric(sMatch.Groups("season").Value) Then
                            cSeason.Season = Convert.ToInt32(sMatch.Groups("season").Value)
                        ElseIf Regex.IsMatch(sMatch.Groups("season").Value, "specials?", RegexOptions.IgnoreCase) Then
                            cSeason.Season = 0
                        Else
                            cSeason.Season = -1
                        End If

                        Select Case rShow.EpisodeRetrieve
                            Case emmSettings.EpRetrieve.FromDirectory
                                epMatch = Path.GetDirectoryName(sPath)
                            Case emmSettings.EpRetrieve.FromFilename
                                epMatch = Path.GetFileNameWithoutExtension(sPath)
                            Case emmSettings.EpRetrieve.FromSeasonResult
                                epMatch = sMatch.Value
                        End Select

                        For Each eMatch As Match In Regex.Matches(epMatch, rShow.EpisodeRegex, RegexOptions.IgnoreCase)
                            cSeason.Episodes.Add(Convert.ToInt32(eMatch.Groups("episode").Value))
                        Next

                        retSeason.Add(cSeason)
                    Catch ex As Exception
                        Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                    End Try
                Next

                If retSeason.Count > 0 Then Return retSeason
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                Continue For
            End Try
        Next

        'nothing found
        cSeason = New Seasons
        cSeason.Season = -1
        cSeason.Episodes.Add(-1)
        retSeason.Add(cSeason)

        Return retSeason
    End Function

    Public Sub LoadMovie(ByVal mContainer As MovieContainer)
        Dim tmpMovieDB As New Master.DBMovie
        Try
            'first, lets get the contents
            GetMovieFolderContents(mContainer)

            If Not String.IsNullOrEmpty(mContainer.Nfo) Then
                tmpMovieDB.Movie = NFO.LoadMovieFromNFO(mContainer.Nfo, mContainer.isSingle)
            Else
                tmpMovieDB.Movie = NFO.LoadMovieFromNFO(mContainer.Filename, mContainer.isSingle)
            End If

            If String.IsNullOrEmpty(tmpMovieDB.Movie.Title) Then
                'no title so assume it's an invalid nfo, clear nfo path if exists
                mContainer.Nfo = String.Empty

                If FileManip.Common.isVideoTS(mContainer.Filename) Then
                    tmpMovieDB.ListTitle = StringManip.FilterName(Directory.GetParent(Directory.GetParent(mContainer.Filename).FullName).Name)
                    tmpMovieDB.Movie.Title = StringManip.FilterName(Directory.GetParent(Directory.GetParent(mContainer.Filename).FullName).Name, False)
                ElseIf FileManip.Common.isBDRip(mContainer.Filename) Then
                    tmpMovieDB.ListTitle = StringManip.FilterName(Directory.GetParent(Directory.GetParent(Directory.GetParent(mContainer.Filename).FullName).FullName).Name)
                    tmpMovieDB.Movie.Title = StringManip.FilterName(Directory.GetParent(Directory.GetParent(Directory.GetParent(mContainer.Filename).FullName).FullName).Name, False)
                Else
                    If mContainer.UseFolder AndAlso mContainer.isSingle Then
                        tmpMovieDB.ListTitle = StringManip.FilterName(Directory.GetParent(mContainer.Filename).Name)
                        tmpMovieDB.Movie.Title = StringManip.FilterName(Directory.GetParent(mContainer.Filename).Name, False)
                    Else
                        tmpMovieDB.ListTitle = StringManip.FilterName(Path.GetFileNameWithoutExtension(mContainer.Filename))
                        tmpMovieDB.Movie.Title = StringManip.FilterName(Path.GetFileNameWithoutExtension(mContainer.Filename), False)
                    End If
                End If

                If String.IsNullOrEmpty(tmpMovieDB.Movie.SortTitle) Then tmpMovieDB.Movie.SortTitle = tmpMovieDB.ListTitle

            Else
                Dim tTitle As String = StringManip.FilterTokens(tmpMovieDB.Movie.Title)
                If String.IsNullOrEmpty(tmpMovieDB.Movie.SortTitle) Then tmpMovieDB.Movie.SortTitle = tTitle
                If Master.eSettings.DisplayYear AndAlso Not String.IsNullOrEmpty(tmpMovieDB.Movie.Year) Then
                    tmpMovieDB.ListTitle = String.Format("{0} ({1})", tTitle, tmpMovieDB.Movie.Year)
                Else
                    tmpMovieDB.ListTitle = StringManip.FilterTokens(tmpMovieDB.Movie.Title)
                End If
            End If

            If Not String.IsNullOrEmpty(tmpMovieDB.ListTitle) Then
                tmpMovieDB.NfoPath = mContainer.Nfo
                tmpMovieDB.PosterPath = mContainer.Poster
                tmpMovieDB.FanartPath = mContainer.Fanart
                tmpMovieDB.TrailerPath = mContainer.Trailer
                tmpMovieDB.SubPath = mContainer.Subs
                tmpMovieDB.ExtraPath = mContainer.Extra
                tmpMovieDB.Filename = mContainer.Filename
                tmpMovieDB.isSingle = mContainer.isSingle
                tmpMovieDB.UseFolder = mContainer.UseFolder
                tmpMovieDB.Source = mContainer.Source
                tmpMovieDB.FileSource = XML.GetFileSource(mContainer.Filename)
                tmpMovieDB.IsNew = True
                tmpMovieDB.IsLock = False
                tmpMovieDB.IsMark = Master.eSettings.MarkNew
                'Do the Save
                tmpMovieDB = Master.DB.SaveMovieToDB(tmpMovieDB, True, True)

                Me.bwPrelim.ReportProgress(0, tmpMovieDB.Movie.Title)
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try

    End Sub

    Private Sub LoadShow(ByVal TVContainer As TVShowContainer)
        Dim tmpTVDB As New Master.DBTV
        'TODO: Handle video_ts
        Try
            If TVContainer.Episodes.Count > 0 Then
                If Not htTVShows.ContainsKey(TVContainer.ShowPath.ToLower) Then
                    GetShowFolderContents(TVContainer)

                    If Not String.IsNullOrEmpty(TVContainer.Nfo) Then
                        tmpTVDB.TVShow = NFO.LoadTVShowFromNFO(TVContainer.Nfo)
                    Else
                        tmpTVDB.TVShow = NFO.LoadTVShowFromNFO(TVContainer.ShowPath)
                    End If

                    If String.IsNullOrEmpty(tmpTVDB.TVShow.Title) Then
                        'no title so assume it's an invalid nfo, clear nfo path if exists
                        TVContainer.Nfo = String.Empty
                        'set title based on show folder name
                        'looks funny to use getfilenamewithoutextension, but it works when passing a path with no file specified
                        'used as a workaround to "New DirectoryInfo(sFile.TVContainer.ShowPath).Name" as I suspect this is the
                        'root of the problem as reported in Issue #58
                        tmpTVDB.TVShow.Title = StringManip.FilterTVShowName(Path.GetFileNameWithoutExtension(TVContainer.ShowPath))
                    End If

                    tmpTVDB.ShowPath = TVContainer.ShowPath
                    tmpTVDB.ShowNfoPath = TVContainer.Nfo
                    tmpTVDB.ShowPosterPath = TVContainer.Poster
                    tmpTVDB.ShowFanartPath = TVContainer.Fanart
                    tmpTVDB.IsNewShow = True
                    tmpTVDB.IsLockShow = False
                    tmpTVDB.IsMarkShow = Master.eSettings.MarkNew
                    tmpTVDB.Source = TVContainer.Source

                    Master.DB.SaveTVShowToDB(tmpTVDB, True, True)

                Else
                    tmpTVDB.ShowID = Convert.ToInt64(htTVShows.Item(TVContainer.ShowPath.ToLower))
                End If
                If tmpTVDB.ShowID > -1 Then
                    For Each Episode In TVContainer.Episodes
                        If Not String.IsNullOrEmpty(Episode.Filename) Then
                            GetEpFolderContents(Episode)

                            tmpTVDB.EpNfoPath = Episode.Nfo
                            tmpTVDB.EpPosterPath = Episode.Poster
                            tmpTVDB.Source = Episode.Source
                            tmpTVDB.IsNewEp = True
                            tmpTVDB.IsLockEp = False
                            tmpTVDB.IsMarkEp = Master.eSettings.MarkNew

                            For Each sSeasons As Seasons In GetSeasons(Episode.Filename)
                                For Each i As Integer In sSeasons.Episodes

                                    tmpTVDB.Filename = Episode.Filename

                                    tmpTVDB.TVEp = New Media.EpisodeDetails

                                    If Not String.IsNullOrEmpty(Episode.Nfo) Then
                                        tmpTVDB.TVEp = NFO.LoadTVEpFromNFO(Episode.Nfo, sSeasons.Season, i)
                                    Else
                                        tmpTVDB.TVEp = NFO.LoadTVEpFromNFO(Episode.Filename, sSeasons.Season, i)
                                    End If

                                    If String.IsNullOrEmpty(tmpTVDB.TVEp.Title) Then
                                        'no title so assume it's an invalid nfo, clear nfo path if exists
                                        Episode.Nfo = String.Empty
                                        'set title based on episode file
                                        tmpTVDB.TVEp.Title = StringManip.FilterTVEpName(Path.GetFileNameWithoutExtension(Episode.Filename), tmpTVDB.TVShow.Title)
                                    End If

                                    If tmpTVDB.TVEp.Season < 0 Then tmpTVDB.TVEp.Season = sSeasons.Season
                                    If tmpTVDB.TVEp.Episode < 0 Then tmpTVDB.TVEp.Episode = i

                                    If String.IsNullOrEmpty(tmpTVDB.TVEp.Title) Then
                                        'nothing usable in the title after filters have run
                                        tmpTVDB.TVEp.Title = String.Format("{0} S{1}E{2}", tmpTVDB.TVShow.Title, tmpTVDB.TVEp.Season, tmpTVDB.TVEp.Episode)
                                    End If

                                    If String.IsNullOrEmpty(tmpTVDB.SeasonPosterPath) OrElse String.IsNullOrEmpty(tmpTVDB.SeasonFanartPath) Then Me.GetSeasonImages(tmpTVDB, tmpTVDB.TVEp.Season)

                                    'Do the Save
                                    Master.DB.SaveTVEpToDB(tmpTVDB, True, True)

                                    Me.bwPrelim.ReportProgress(1, String.Format("{0}: {1}", tmpTVDB.TVShow.Title, tmpTVDB.TVEp.Title))
                                Next
                            Next
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub
End Class