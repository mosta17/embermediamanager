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
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Xml

Namespace MPDB
    Public Class Scraper
        Friend WithEvents bwMPDB As New System.ComponentModel.BackgroundWorker

        Public Event PostersDownloaded(ByVal Posters As List(Of Media.Image))
        Public Event ProgressUpdated(ByVal iPercent As Integer)

        Private Structure Arguments
            Dim Parameter As String
        End Structure

        Private Structure Results
            Dim ResultList As List(Of Media.Image)
            Dim Result As Object
        End Structure

        Public Sub Cancel()
            If Me.bwMPDB.IsBusy Then Me.bwMPDB.CancelAsync()

            Do While Me.bwMPDB.IsBusy
                Application.DoEvents()
            Loop

        End Sub

        Public Sub GetImagesAsync(ByVal imdbID As String)
            Try
                If Not Me.bwMPDB.IsBusy Then
                    Me.bwMPDB.WorkerSupportsCancellation = True
                    Me.bwMPDB.WorkerReportsProgress = True
                    Me.bwMPDB.RunWorkerAsync(New Arguments With {.Parameter = imdbID})
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try
        End Sub

        Public Function GetMPDBPosters(ByVal imdbID As String) As List(Of Media.Image)
            Dim alPosters As New List(Of Media.Image)

            If Me.bwMPDB.CancellationPending Then Return Nothing

            Try
                Dim sHTTP As New HTTP(String.Concat("http://www.movieposterdb.com/movie/", imdbID))
                Dim HTML As String = sHTTP.Response
                sHTTP = Nothing

                If Me.bwMPDB.CancellationPending Then Return Nothing

                If bwMPDB.WorkerReportsProgress Then
                    bwMPDB.ReportProgress(1)
                End If

                If Regex.IsMatch(HTML, String.Concat("http://", Master.eSettings.IMDBURL, "/title/tt", imdbID), RegexOptions.Singleline Or RegexOptions.IgnoreCase Or RegexOptions.Multiline) Then
                    Dim mcPoster As MatchCollection = Regex.Matches(HTML, "http://www.movieposterdb.com/posters/[0-9_](.*?)/[0-9](.*?)/[0-9](.*?)/[a-z0-9_](.*?).jpg")

                    Dim PosterURL As String = String.Empty

                    For Each mPoster As Match In mcPoster
                        If Me.bwMPDB.CancellationPending Then Return Nothing
                        PosterURL = mPoster.Value.Remove(mPoster.Value.LastIndexOf("/") + 1, 1)
                        PosterURL = PosterURL.Insert(mPoster.Value.LastIndexOf("/") + 1, "l")
                        alPosters.Add(New Media.Image With {.Description = "poster", .URL = PosterURL})
                    Next
                End If
                If bwMPDB.WorkerReportsProgress Then
                    bwMPDB.ReportProgress(3)
                End If
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            End Try

            Return alPosters
        End Function

        Private Sub bwMPDB_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwMPDB.DoWork
            Dim Args As Arguments = e.Argument
            Try
                e.Result = GetMPDBPosters(Args.Parameter)
            Catch ex As Exception
                Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
                e.Result = Nothing
            End Try
        End Sub

        Private Sub bwMPDB_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwMPDB.ProgressChanged
            If Not bwMPDB.CancellationPending Then
                RaiseEvent ProgressUpdated(e.ProgressPercentage)
            End If
        End Sub

        Private Sub bwMPDB_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwMPDB.RunWorkerCompleted
            If Not bwMPDB.CancellationPending Then
                RaiseEvent PostersDownloaded(e.Result)
            End If
        End Sub
    End Class
End Namespace
