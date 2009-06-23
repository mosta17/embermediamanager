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

Public Class dlgSetsManager

    Private lMovies As New List(Of Movies)
    Private alSets As New ArrayList
    Private currSet As New Sets
    Friend WithEvents bwLoadMovies As New System.ComponentModel.BackgroundWorker

    Friend Class Sets
        Private _set As String
        Private _order As Integer
        Private _movies As New List(Of Movies)

        Public Property [Set]() As String
            Get
                Return _set
            End Get
            Set(ByVal value As String)
                _set = value
            End Set
        End Property

        Public Property Movies() As List(Of Movies)
            Get
                Return _movies
            End Get
            Set(ByVal value As List(Of Movies))
                _movies = value
            End Set
        End Property

        Public Sub AddMovie(ByVal sMovie As Movies, ByVal Order As Integer)
            sMovie.Order = Order
            _movies.Add(sMovie)
        End Sub

        Public Sub New()
            Me.Clear()
        End Sub

        Public Sub Clear()
            Me._set = String.Empty
            Me._order = 0
            Me._movies.Clear()
        End Sub

    End Class

    Friend Class Movies
        Private _movie As Media.Movie
        Private _path As String
        Private _isfile As Boolean
        Private _order As Integer

        Public Property Movie() As Media.Movie
            Get
                Return Me._movie
            End Get
            Set(ByVal value As Media.Movie)
                Me._movie = value
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

        Public Property isFile() As Boolean
            Get
                Return Me._isfile
            End Get
            Set(ByVal value As Boolean)
                Me._isfile = value
            End Set
        End Property

        Public Property Order() As Integer
            Get
                Return Me._order
            End Get
            Set(ByVal value As Integer)
                Me._order = value
            End Set
        End Property

        Public Sub New()
            Me.Clear()
        End Sub

        Public Sub Clear()
            Me._movie = New Media.Movie
            Me._path = String.Empty
            Me._isfile = False
            Me._order = 0
        End Sub
    End Class

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Master.eSettings.Sets = alSets
        Master.eSettings.Save()

        If Me.currSet.Movies.Count > 0 Then SaveSet(currSet)

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dlgSetsManager_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.bwLoadMovies.IsBusy Then
            Me.DoCancel()
            Do While Me.bwLoadMovies.IsBusy
                Application.DoEvents()
            Loop
        End If
    End Sub

    Private Sub dlgSetsManager_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        Me.Activate()

        ' Show Cancel Panel
        btnCancel.Visible = True
        lblCompiling.Visible = True
        pbCompile.Visible = True
        pbCompile.Style = ProgressBarStyle.Continuous
        lblCanceling.Visible = False
        pnlCancel.Visible = True
        Application.DoEvents()

        Me.bwLoadMovies.WorkerSupportsCancellation = True
        Me.bwLoadMovies.WorkerReportsProgress = True
        Me.bwLoadMovies.RunWorkerAsync()
    End Sub

    Private Sub bwLoadMovies_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLoadMovies.DoWork

        '//
        ' Start thread to load movie information from nfo
        '\\

        Try

            For Each sSet As String In Master.eSettings.Sets
                If Not String.IsNullOrEmpty(sSet) Then alSets.Add(sSet)
            Next

            Using SQLcommand As SQLite.SQLiteCommand = Master.SQLcn.CreateCommand
                Dim tmpMovie As New Media.Movie
                Dim tmpPath As String = String.Empty
                Dim iProg As Integer = 0
                SQLcommand.CommandText = String.Concat("SELECT COUNT(id) AS mcount FROM movies;")
                Using SQLcount As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                    Me.bwLoadMovies.ReportProgress(-1, SQLcount("mcount"))
                End Using
                SQLcommand.CommandText = String.Concat("SELECT path, type FROM movies ORDER BY title ASC;")
                Using SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
                    If SQLreader.HasRows Then
                        While SQLreader.Read()
                            If bwLoadMovies.CancellationPending Then Return
                            tmpPath = Master.GetNfoPath(SQLreader("path").ToString, SQLreader("type"))
                            If Not String.IsNullOrEmpty(tmpPath) Then
                                tmpMovie = Master.LoadMovieFromNFO(tmpPath)
                                If Not String.IsNullOrEmpty(tmpMovie.Title) Then
                                    lMovies.Add(New Movies With {.Movie = tmpMovie, .Path = tmpPath, .isFile = SQLreader("type")})
                                    If tmpMovie.Sets.Count > 0 Then
                                        For Each mSet As Media.Set In tmpMovie.Sets
                                            If Not alSets.Contains(mSet.SetContainer.Set) AndAlso Not String.IsNullOrEmpty(mSet.SetContainer.Set) Then
                                                alSets.Add(mSet.SetContainer.Set)
                                            End If
                                        Next
                                    End If
                                End If
                            End If
                            Me.bwLoadMovies.ReportProgress(iProg, tmpMovie.Title)
                            iProg += 1
                        End While
                    End If
                End Using
            End Using
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub bwLoadMovies_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwLoadMovies.ProgressChanged

        If e.ProgressPercentage >= 0 Then
            Me.pbCompile.Value = e.ProgressPercentage
            Me.lblFile.Text = e.UserState
        Else
            Me.pbCompile.Maximum = Convert.ToInt32(e.UserState)
        End If

    End Sub

    Private Sub bwLoadMovies_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLoadMovies.RunWorkerCompleted

        '//
        ' Thread finished: fill movie and sets lists
        '\\

        Me.LoadSets()

        For Each tMovie As Movies In lMovies
            Me.lbMovies.Items.Add(tMovie.Movie.Title)
        Next

        Me.pnlCancel.Visible = False

        Me.lbSets.Enabled = True
        Me.lbMoviesInSet.Enabled = True
        Me.lbMovies.Enabled = True
        Me.btnNewSet.Enabled = True
        Me.btnUp.Enabled = True
        Me.btnDown.Enabled = True
        Me.btnRemove.Enabled = True
        Me.btnAdd.Enabled = True
        Me.btnEditSet.Enabled = True
        Me.btnRemoveSet.Enabled = True

    End Sub

    Private Sub DoCancel()
        Me.bwLoadMovies.CancelAsync()
        btnCancel.Visible = False
        lblCompiling.Visible = False
        pbCompile.Style = ProgressBarStyle.Marquee
        pbCompile.MarqueeAnimationSpeed = 25
        lblCanceling.Visible = True
        lblFile.Visible = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lbSets_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSets.DoubleClick
        Me.EditSet()
    End Sub

    Private Sub lbSets_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbSets.SelectedIndexChanged
        Try
            Dim tOrder As Integer = 0

            If Me.currSet.Movies.Count > 0 Then SaveSet(currSet)

            Me.currSet.Clear()
            Me.lbMoviesInSet.Items.Clear()

            If Me.lbSets.SelectedItems.Count > 0 Then

                Me.lblCurrentSet.Text = Me.lbSets.SelectedItem.ToString

                Me.currSet.Set = Me.lbSets.SelectedItem.ToString

                For Each tMovie As Movies In lMovies
                    For Each mSet As Media.Set In tMovie.Movie.Sets
                        If mSet.SetContainer.Set = Me.currSet.Set Then
                            If Not String.IsNullOrEmpty(mSet.SetContainer.Order) Then
                                tOrder = Convert.ToInt32(mSet.SetContainer.Order)
                            End If
                            Me.currSet.AddMovie(tMovie, tOrder)
                        End If
                    Next
                Next

                If Me.currSet.Movies.Count > 0 Then Me.LoadCurrSet()

            Else
                Me.lblCurrentSet.Text = "None Selected"
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub btnNewSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewSet.Click
        Try
            Using dNewSet As New dlgNewSet
                Dim strSet As String = dNewSet.ShowDialog
                If Not String.IsNullOrEmpty(strSet) AndAlso Not Me.alSets.Contains(strSet) Then
                    Me.alSets.Add(strSet)
                    Me.LoadSets()
                End If
            End Using
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub LoadSets()
        Me.lbSets.Items.Clear()
        Me.lbMoviesInSet.Items.Clear()
        Me.lblCurrentSet.Text = "None Selected"

        For Each mSet As String In alSets
            Me.lbSets.Items.Add(mSet)
        Next
    End Sub

    Private Sub SaveSet(ByVal mSet As Sets)
        Try
            For Each tMovie As Movies In mSet.Movies
                tMovie.Movie.AddSet(mSet.Set, tMovie.Order)
                Master.SaveMovieToNFO(tMovie.Movie, tMovie.Path, tMovie.isFile)
            Next
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If Me.lbSets.SelectedItems.Count > 0 Then
                For i As Integer = 0 To lbMovies.SelectedItems.Count - 1
                    If Not Me.lbMoviesInSet.Items.Contains(Me.lbMovies.SelectedItems(i)) Then
                        Me.currSet.AddMovie(lMovies(Me.lbMovies.SelectedIndices(i)), Me.lbMoviesInSet.Items.Count + i)
                    End If
                Next
                Me.LoadCurrSet()
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub LoadCurrSet()
        Try
            Me.lbMoviesInSet.Items.Clear()
            Me.currSet.Movies.Sort(AddressOf SortMovies)
            For Each tMovie As Movies In Me.currSet.Movies
                Me.lbMoviesInSet.Items.Add(tMovie.Movie.Title)
                tMovie.Order = Me.lbMoviesInSet.Items.Count
            Next
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Function SortMovies(ByVal x As Movies, ByVal y As Movies) As Integer
        Try
            If IsNothing(x.Order) OrElse x.Order <= 0 Then
                Return -1
            End If
            If IsNothing(y.Order) OrElse y.Order <= 0 Then
                Return 1
            End If

            Return x.Order.CompareTo(y.Order)
        Catch
            Return 0
        End Try
    End Function

    Private Sub RemoveFromSet(ByVal iIndex As Integer, ByVal isEdit As Boolean)
        Try
            Me.currSet.Movies(iIndex).Movie.RemoveSet(Me.currSet.Set)
            Master.SaveMovieToNFO(Me.currSet.Movies(iIndex).Movie, Me.currSet.Movies(iIndex).Path, Me.currSet.Movies(iIndex).isFile)
            If Not isEdit Then Me.currSet.Movies.RemoveAt(iIndex)
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Me.RemoveFromSet(Me.lbMoviesInSet.SelectedIndex, False)
        Me.LoadCurrSet()
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        Try
            If Me.lbMoviesInSet.Items.Count > 0 AndAlso Not IsNothing(Me.lbMoviesInSet.SelectedItem) AndAlso Me.lbMoviesInSet.SelectedIndex > 0 Then
                Dim iIndex As Integer = Me.lbMoviesInSet.SelectedIndex
                Me.currSet.Movies(iIndex).Order -= 1
                Me.currSet.Movies(iIndex - 1).Order += 1
                Me.LoadCurrSet()
                Me.lbMoviesInSet.SelectedIndex = iIndex - 1
                Me.lbMoviesInSet.Focus()
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        Try
            If Me.lbMoviesInSet.Items.Count > 0 AndAlso Not IsNothing(Me.lbMoviesInSet.SelectedItem) AndAlso Me.lbMoviesInSet.SelectedIndex < (Me.lbMoviesInSet.Items.Count - 1) Then
                Dim iIndex As Integer = Me.lbMoviesInSet.SelectedIndex
                Me.currSet.Movies(iIndex).Order += 1
                Me.currSet.Movies(iIndex + 1).Order -= 1
                Me.LoadCurrSet()
                Me.lbMoviesInSet.SelectedIndex = iIndex + 1
                Me.lbMoviesInSet.Focus()
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub btnEditSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditSet.Click
        Me.EditSet()
    End Sub

    Private Sub EditSet()
        Try
            If Me.lbSets.SelectedItems.Count > 0 Then
                Using dNewSet As New dlgNewSet
                    Dim strSet As String = dNewSet.ShowDialog(Me.lbSets.SelectedItem.ToString)
                    If Not String.IsNullOrEmpty(strSet) AndAlso Not Me.alSets.Contains(strSet) Then
                        For i As Integer = 0 To Me.alSets.Count - 1
                            If Me.alSets(i) = Me.lbSets.SelectedItem.ToString Then
                                'remove the old set from each movie.
                                If lbMoviesInSet.Items.Count > 0 Then
                                    For b As Integer = lbMoviesInSet.Items.Count - 1 To 0 Step -1
                                        Me.RemoveFromSet(b, True)
                                    Next
                                End If
                                'set the currset to have the updated title
                                currSet.Set = strSet
                                'save the set to update each movie with the new set name
                                Me.SaveSet(currSet)
                                'change the name in alSets
                                Me.alSets(i) = strSet
                                Exit For
                            End If
                        Next
                        Me.LoadSets()
                    End If
                End Using
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub btnRemoveSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSet.Click
        Try
            If lbMoviesInSet.Items.Count > 0 Then
                For i As Integer = lbMoviesInSet.Items.Count - 1 To 0 Step -1
                    Me.RemoveFromSet(i, False)
                Next
            End If

            For i As Integer = 0 To Me.alSets.Count - 1
                If Me.alSets(i) = Me.lbSets.SelectedItem.ToString Then
                    Me.alSets.RemoveAt(i)
                    Exit For
                End If
            Next

            Me.LoadSets()
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
        End Try
    End Sub

    Private Sub dlgSetsManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim iBackground As New Bitmap(Me.pnlTop.Width, Me.pnlTop.Height)
        Using g As Graphics = Graphics.FromImage(iBackground)
            g.FillRectangle(New Drawing2D.LinearGradientBrush(Me.pnlTop.ClientRectangle, Color.SteelBlue, Color.LightSteelBlue, Drawing2D.LinearGradientMode.Horizontal), pnlTop.ClientRectangle)
            Me.pnlTop.BackgroundImage = iBackground
        End Using
    End Sub
End Class
