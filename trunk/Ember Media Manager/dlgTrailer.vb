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



Imports System.IO
Imports System.Text.RegularExpressions

Public Class dlgTrailer

    Private cTrailer As New Trailers
    Private sHTTP As New HTTP
    Dim tArray As New List(Of String)
    Dim imdbID As String = String.Empty
    Dim sPath As String = String.Empty
    Dim tURL As String = String.Empty
    Dim prePath As String = String.Empty
    Friend WithEvents bwCompileList As New System.ComponentModel.BackgroundWorker
    Friend WithEvents bwDownloadTrailer As New System.ComponentModel.BackgroundWorker

    Private Structure Arguments
        Dim Parameter As String
        Dim bType As Boolean
    End Structure

    Private Sub btnSetNfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetNfo.Click
        If Regex.IsMatch(Me.txtYouTube.Text, "http:\/\/.*youtube.*\/watch\?v=(.{11})&?.*") Then
            tURL = Me.txtYouTube.Text
        ElseIf Me.lbTrailers.SelectedItems.Count > 0 Then
            tURL = lbTrailers.SelectedItem.ToString
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.BeginDownload(True)
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.bwCompileList.CancelAsync()
        Me.bwDownloadTrailer.CancelAsync()

        While Me.bwCompileList.IsBusy OrElse Me.bwDownloadTrailer.IsBusy
            Application.DoEvents()
        End While

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BeginDownload(ByVal CloseDialog As Boolean)
        Dim didCancel As Boolean = False

        Me.OK_Button.Enabled = False
        Me.btnSetNfo.Enabled = False
        Me.btnPlayTrailer.Enabled = False
        Me.lbTrailers.Enabled = False
        Me.txtYouTube.Enabled = False
        Me.txtManual.Enabled = False
        Me.btnBrowse.Enabled = False
        Me.lblStatus.Text = Master.eLang.GetString(380, "Downloading selected trailer...")
        Me.pbStatus.Style = ProgressBarStyle.Continuous
        Me.pbStatus.Value = 0
        Me.pnlStatus.Visible = True
        Application.DoEvents()

        If Not String.IsNullOrEmpty(Me.prePath) AndAlso File.Exists(Me.prePath) Then
            If CloseDialog Then
                Me.tURL = Path.Combine(Directory.GetParent(Me.sPath).FullName, Path.GetFileName(Me.prePath))
                FileManip.Common.MoveFileWithStream(Me.prePath, Me.tURL)

                File.Delete(Me.prePath)

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                System.Diagnostics.Process.Start(String.Concat("""", Me.prePath, """"))
                didCancel = True
            End If
        ElseIf Me.txtManual.Text.Length > 0 AndAlso Master.eSettings.ValidExts.Contains(Path.GetExtension(Me.txtManual.Text)) AndAlso File.Exists(Me.txtManual.Text) Then
            If CloseDialog Then
                Me.tURL = Path.Combine(Directory.GetParent(Me.sPath).FullName, String.Concat(Path.GetFileNameWithoutExtension(Me.sPath), If(Master.eSettings.DashTrailer, "-trailer", "[trailer]"), Path.GetExtension(Me.txtManual.Text)))
                FileManip.Common.MoveFileWithStream(Me.txtManual.Text, Me.tURL)

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                System.Diagnostics.Process.Start(String.Concat("""", Me.txtManual.Text, """"))
                didCancel = True
            End If
        ElseIf Regex.IsMatch(Me.txtYouTube.Text, "http:\/\/.*youtube.*\/watch\?v=(.{11})&?.*") Then
            Using dFormats As New dlgTrailerFormat
                Dim sFormat As String = dFormats.ShowDialog(Me.txtYouTube.Text)

                If Not String.IsNullOrEmpty(sFormat) Then
                    Me.bwDownloadTrailer = New System.ComponentModel.BackgroundWorker
                    Me.bwDownloadTrailer.WorkerReportsProgress = True
                    Me.bwDownloadTrailer.RunWorkerAsync(New Arguments With {.Parameter = sFormat, .bType = CloseDialog})
                Else
                    didCancel = True
                End If
            End Using
        Else
            If Regex.IsMatch(Me.lbTrailers.SelectedItem.ToString, "http:\/\/.*youtube.*\/watch\?v=(.{11})&?.*") Then
                Using dFormats As New dlgTrailerFormat
                    Dim sFormat As String = dFormats.ShowDialog(Me.lbTrailers.SelectedItem.ToString)

                    If Not String.IsNullOrEmpty(sFormat) Then
                        Me.bwDownloadTrailer = New System.ComponentModel.BackgroundWorker
                        Me.bwDownloadTrailer.WorkerReportsProgress = True
                        Me.bwDownloadTrailer.RunWorkerAsync(New Arguments With {.Parameter = sFormat, .bType = CloseDialog})
                    Else
                        didCancel = True
                    End If
                End Using
            Else
                Me.bwDownloadTrailer = New System.ComponentModel.BackgroundWorker
                Me.bwDownloadTrailer.WorkerReportsProgress = True
                Me.bwDownloadTrailer.RunWorkerAsync(New Arguments With {.parameter = lbTrailers.SelectedItem.ToString, .bType = CloseDialog})
            End If
        End If

        If didCancel Then
            Me.pnlStatus.Visible = False
            Me.lbTrailers.Enabled = True
            Me.txtYouTube.Enabled = True
            Me.txtManual.Enabled = True
            Me.btnBrowse.Enabled = True
            Me.SetEnabled(False)
        End If
    End Sub
    Private Sub bwCompileList_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwCompileList.DoWork

        Try
            tArray = cTrailer.GetTrailers(Me.imdbID, False)

            If Me.bwCompileList.CancellationPending Then
                e.Cancel = True
            End If
        Catch
        End Try

    End Sub

    Private Sub bwCompileList_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwCompileList.RunWorkerCompleted

        If Not e.Cancelled Then
            If Me.tArray.Count > 0 Then
                For Each tTrail As String In Me.tArray
                    Me.lbTrailers.Items.Add(tTrail)
                Next

                Me.btnGetTrailers.Visible = False
            Else
                Me.btnGetTrailers.Enabled = False
            End If

        End If

        Me.pnlStatus.Visible = False
        Me.lbTrailers.Enabled = True
        Me.txtYouTube.Enabled = True
        Me.txtManual.Enabled = True
        Me.btnBrowse.Enabled = True
        Me.SetEnabled(False)

    End Sub

    Private Sub bwDownloadTrailer_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDownloadTrailer.DoWork

        Dim Args As Arguments = DirectCast(e.Argument, Arguments)
        Try

            If Args.bType Then
                Me.tURL = cTrailer.DownloadTrailer(Me.sPath, Args.Parameter)
            Else
                Me.prePath = cTrailer.DownloadTrailer(Path.Combine(Master.TempPath, Path.GetFileName(Me.sPath)), Args.Parameter)
            End If

        Catch
        End Try

        e.Result = Args.bType

        If Me.bwDownloadTrailer.CancellationPending Then
            e.Cancel = True
        End If

    End Sub

    Private Sub bwDownloadTrailer_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwDownloadTrailer.ProgressChanged
        pbStatus.Value = e.ProgressPercentage
    End Sub

    Private Sub bwDownloadTrailer_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwDownloadTrailer.RunWorkerCompleted

        If Not e.Cancelled Then
            If Convert.ToBoolean(e.Result) Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                Me.pnlStatus.Visible = False
                Me.lbTrailers.Enabled = True
                Me.txtYouTube.Enabled = True
                Me.txtManual.Enabled = True
                Me.btnBrowse.Enabled = True
                Me.SetEnabled(False)
                If Not String.IsNullOrEmpty(Me.prePath) Then System.Diagnostics.Process.Start(String.Concat("""", prePath, """"))
            End If
        End If
    End Sub

    Private Sub DownloadProgressUpdated(ByVal iProgress As Integer)
        bwDownloadTrailer.ReportProgress(iProgress)
    End Sub

    Private Sub lbTrailers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbTrailers.SelectedIndexChanged
        Me.SetEnabled(True)
    End Sub

    Public Overloads Function ShowDialog(ByVal _imdbID As String, ByVal _sPath As String) As String

        Me.imdbID = _imdbID
        Me.sPath = _sPath

        If MyBase.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Return Me.tURL
        Else
            Return String.Empty
        End If

    End Function

    Private Sub dlgTrailer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SetUp()
        AddHandler cTrailer.ProgressUpdated, AddressOf DownloadProgressUpdated
        AddHandler sHTTP.ProgressUpdated, AddressOf DownloadProgressUpdated
    End Sub

    Private Sub SetUp()
        Me.Text = Master.eLang.GetString(372, "Select Trailer")
        Me.OK_Button.Text = Master.eLang.GetString(373, "Download")
        Me.Cancel_Button.Text = Master.eLang.GetString(167, "Cancel")
        Me.GroupBox1.Text = Master.eLang.GetString(374, "Select Trailer to Download")
        Me.GroupBox2.Text = Master.eLang.GetString(375, "Manual Trailer Entry")
        Me.Label1.Text = Master.eLang.GetString(376, "YouTube URL:")
        Me.lblStatus.Text = Master.eLang.GetString(377, "Compiling trailer list...")
        Me.btnPlayTrailer.Text = Master.eLang.GetString(378, "Preview Trailer")
        Me.btnSetNfo.Text = Master.eLang.GetString(379, "Set To Nfo")
        Me.Label2.Text = Master.eLang.GetString(644, "Local Trailer:")
    End Sub

    Private Sub dlgTrailer_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Activate()
    End Sub

    Private Sub btnPlayTrailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlayTrailer.Click
        Try
            Me.BeginDownload(False)
        Catch
            MsgBox(Master.eLang.GetString(382, "The trailer could not be played. This could be due to an invalid URI or you do not have the proper player to play the trailer type."), MsgBoxStyle.Critical, Master.eLang.GetString(383, "Error Playing Trailer"))
            Me.pnlStatus.Visible = False
            Me.lbTrailers.Enabled = True
            Me.txtYouTube.Enabled = True
            Me.txtManual.Enabled = True
            Me.btnBrowse.Enabled = True
            Me.SetEnabled(False)
        End Try
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Try
            With ofdTrailer
                .InitialDirectory = Directory.GetParent(Master.currMovie.Filename).FullName
                .Filter = String.Concat("Supported Trailer Formats|*", Master.ListToStringWithSeparator(Master.eSettings.ValidExts.ToArray(), ";*"))
                .FilterIndex = 0
            End With

            If ofdTrailer.ShowDialog() = DialogResult.OK Then
                txtManual.Text = ofdTrailer.FileName
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub txtManual_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtManual.TextChanged
        Me.SetEnabled(True)
    End Sub

    Protected Overrides Sub Finalize()
        cTrailer = Nothing
        sHTTP = Nothing
        MyBase.Finalize()
    End Sub

    Private Sub btnGetTrailers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetTrailers.Click
        Me.OK_Button.Enabled = False
        Me.btnSetNfo.Enabled = False
        Me.btnPlayTrailer.Enabled = False
        Me.lbTrailers.Enabled = False
        Me.txtYouTube.Enabled = False
        Me.txtManual.Enabled = False
        Me.btnBrowse.Enabled = False
        Me.pnlStatus.Visible = True

        Me.bwCompileList = New System.ComponentModel.BackgroundWorker
        Me.bwCompileList.WorkerSupportsCancellation = True
        Me.bwCompileList.RunWorkerAsync()
    End Sub

    Private Sub txtYouTube_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYouTube.TextChanged
        Me.SetEnabled(True)
    End Sub

    Private Sub SetEnabled(ByVal DeletePre As Boolean)

        If DeletePre AndAlso Not String.IsNullOrEmpty(Me.prePath) AndAlso File.Exists(Me.prePath) Then
            File.Delete(Me.prePath)
            Me.prePath = String.Empty
        End If

        If Regex.IsMatch(Me.txtYouTube.Text, "http:\/\/.*youtube.*\/watch\?v=(.{11})&?.*") OrElse Me.lbTrailers.SelectedItems.Count > 0 OrElse Me.txtManual.Text.Length > 0 Then
            Me.OK_Button.Enabled = True
            Me.btnPlayTrailer.Enabled = True
            If Me.txtManual.Text.Length > 0 Then
                Me.btnSetNfo.Enabled = False
            Else
                Me.btnSetNfo.Enabled = True
            End If
        Else
            Me.OK_Button.Enabled = False
            Me.btnPlayTrailer.Enabled = False
            Me.btnSetNfo.Enabled = False
        End If
    End Sub
End Class