﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgEditMovie
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgEditMovie))
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.pnlTop = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.lblStudio = New System.Windows.Forms.Label
        Me.txtStudio = New System.Windows.Forms.TextBox
        Me.lblTrailer = New System.Windows.Forms.Label
        Me.txtTrailer = New System.Windows.Forms.TextBox
        Me.txtReleaseDate = New System.Windows.Forms.TextBox
        Me.lblReleaseDate = New System.Windows.Forms.Label
        Me.lblCredits = New System.Windows.Forms.Label
        Me.txtCredits = New System.Windows.Forms.TextBox
        Me.lblCerts = New System.Windows.Forms.Label
        Me.txtCerts = New System.Windows.Forms.TextBox
        Me.lblRuntime = New System.Windows.Forms.Label
        Me.txtRuntime = New System.Windows.Forms.TextBox
        Me.lblMPAADesc = New System.Windows.Forms.Label
        Me.txtMPAADesc = New System.Windows.Forms.TextBox
        Me.btnEditActor = New System.Windows.Forms.Button
        Me.btnAddActor = New System.Windows.Forms.Button
        Me.btnManual = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.lblActors = New System.Windows.Forms.Label
        Me.lvActors = New System.Windows.Forms.ListView
        Me.colName = New System.Windows.Forms.ColumnHeader
        Me.colRole = New System.Windows.Forms.ColumnHeader
        Me.colThumb = New System.Windows.Forms.ColumnHeader
        Me.lbMPAA = New System.Windows.Forms.ListBox
        Me.lblGenre = New System.Windows.Forms.Label
        Me.lbGenre = New System.Windows.Forms.ListBox
        Me.lblMPAA = New System.Windows.Forms.Label
        Me.lblDirector = New System.Windows.Forms.Label
        Me.txtDirector = New System.Windows.Forms.TextBox
        Me.txtTop250 = New System.Windows.Forms.TextBox
        Me.lblTop250 = New System.Windows.Forms.Label
        Me.lblPlot = New System.Windows.Forms.Label
        Me.txtPlot = New System.Windows.Forms.TextBox
        Me.lblOutline = New System.Windows.Forms.Label
        Me.txtOutline = New System.Windows.Forms.TextBox
        Me.lblTagline = New System.Windows.Forms.Label
        Me.txtTagline = New System.Windows.Forms.TextBox
        Me.pbStar5 = New System.Windows.Forms.PictureBox
        Me.pbStar4 = New System.Windows.Forms.PictureBox
        Me.pbStar3 = New System.Windows.Forms.PictureBox
        Me.pbStar2 = New System.Windows.Forms.PictureBox
        Me.pbStar1 = New System.Windows.Forms.PictureBox
        Me.txtVotes = New System.Windows.Forms.TextBox
        Me.lblVotes = New System.Windows.Forms.Label
        Me.lblRating = New System.Windows.Forms.Label
        Me.mtxtYear = New System.Windows.Forms.MaskedTextBox
        Me.lblYear = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.lblPosterSize = New System.Windows.Forms.Label
        Me.btnSetPosterScrape = New System.Windows.Forms.Button
        Me.btnSetPoster = New System.Windows.Forms.Button
        Me.pbPoster = New System.Windows.Forms.PictureBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.lblFanartSize = New System.Windows.Forms.Label
        Me.btnSetFanartScrape = New System.Windows.Forms.Button
        Me.btnSetFanart = New System.Windows.Forms.Button
        Me.pbFanart = New System.Windows.Forms.PictureBox
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.pbFrame = New System.Windows.Forms.PictureBox
        Me.btnFrameSave = New System.Windows.Forms.Button
        Me.pnlFrameProgress = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.btnGrab = New System.Windows.Forms.Button
        Me.lblTime = New System.Windows.Forms.Label
        Me.tbFrame = New System.Windows.Forms.TrackBar
        Me.btnFrameLoad = New System.Windows.Forms.Button
        Me.ofdImage = New System.Windows.Forms.OpenFileDialog
        Me.pnlTop.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.pbStar5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStar4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStar3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.pbPoster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.pbFanart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.pbFrame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFrameProgress.SuspendLayout()
        CType(Me.tbFrame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(708, 553)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 21
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(781, 553)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 22
        Me.Cancel_Button.Text = "Cancel"
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTop.Controls.Add(Me.Label2)
        Me.pnlTop.Controls.Add(Me.Label1)
        Me.pnlTop.Controls.Add(Me.PictureBox1)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(854, 64)
        Me.pnlTop.TabIndex = 56
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(61, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(186, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Edit the details for the selected movie."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(58, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Edit Movie"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(7, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(4, 70)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(844, 478)
        Me.TabControl1.TabIndex = 27
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblStudio)
        Me.TabPage1.Controls.Add(Me.txtStudio)
        Me.TabPage1.Controls.Add(Me.lblTrailer)
        Me.TabPage1.Controls.Add(Me.txtTrailer)
        Me.TabPage1.Controls.Add(Me.txtReleaseDate)
        Me.TabPage1.Controls.Add(Me.lblReleaseDate)
        Me.TabPage1.Controls.Add(Me.lblCredits)
        Me.TabPage1.Controls.Add(Me.txtCredits)
        Me.TabPage1.Controls.Add(Me.lblCerts)
        Me.TabPage1.Controls.Add(Me.txtCerts)
        Me.TabPage1.Controls.Add(Me.lblRuntime)
        Me.TabPage1.Controls.Add(Me.txtRuntime)
        Me.TabPage1.Controls.Add(Me.lblMPAADesc)
        Me.TabPage1.Controls.Add(Me.txtMPAADesc)
        Me.TabPage1.Controls.Add(Me.btnEditActor)
        Me.TabPage1.Controls.Add(Me.btnAddActor)
        Me.TabPage1.Controls.Add(Me.btnManual)
        Me.TabPage1.Controls.Add(Me.btnRemove)
        Me.TabPage1.Controls.Add(Me.lblActors)
        Me.TabPage1.Controls.Add(Me.lvActors)
        Me.TabPage1.Controls.Add(Me.lbMPAA)
        Me.TabPage1.Controls.Add(Me.lblGenre)
        Me.TabPage1.Controls.Add(Me.lbGenre)
        Me.TabPage1.Controls.Add(Me.lblMPAA)
        Me.TabPage1.Controls.Add(Me.lblDirector)
        Me.TabPage1.Controls.Add(Me.txtDirector)
        Me.TabPage1.Controls.Add(Me.txtTop250)
        Me.TabPage1.Controls.Add(Me.lblTop250)
        Me.TabPage1.Controls.Add(Me.lblPlot)
        Me.TabPage1.Controls.Add(Me.txtPlot)
        Me.TabPage1.Controls.Add(Me.lblOutline)
        Me.TabPage1.Controls.Add(Me.txtOutline)
        Me.TabPage1.Controls.Add(Me.lblTagline)
        Me.TabPage1.Controls.Add(Me.txtTagline)
        Me.TabPage1.Controls.Add(Me.pbStar5)
        Me.TabPage1.Controls.Add(Me.pbStar4)
        Me.TabPage1.Controls.Add(Me.pbStar3)
        Me.TabPage1.Controls.Add(Me.pbStar2)
        Me.TabPage1.Controls.Add(Me.pbStar1)
        Me.TabPage1.Controls.Add(Me.txtVotes)
        Me.TabPage1.Controls.Add(Me.lblVotes)
        Me.TabPage1.Controls.Add(Me.lblRating)
        Me.TabPage1.Controls.Add(Me.mtxtYear)
        Me.TabPage1.Controls.Add(Me.lblYear)
        Me.TabPage1.Controls.Add(Me.lblTitle)
        Me.TabPage1.Controls.Add(Me.txtTitle)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(836, 452)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Details"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblStudio
        '
        Me.lblStudio.AutoSize = True
        Me.lblStudio.Location = New System.Drawing.Point(635, 343)
        Me.lblStudio.Name = "lblStudio"
        Me.lblStudio.Size = New System.Drawing.Size(40, 13)
        Me.lblStudio.TabIndex = 101
        Me.lblStudio.Text = "Studio:"
        '
        'txtStudio
        '
        Me.txtStudio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStudio.Location = New System.Drawing.Point(635, 359)
        Me.txtStudio.Name = "txtStudio"
        Me.txtStudio.Size = New System.Drawing.Size(193, 20)
        Me.txtStudio.TabIndex = 100
        '
        'lblTrailer
        '
        Me.lblTrailer.AutoSize = True
        Me.lblTrailer.Location = New System.Drawing.Point(217, 408)
        Me.lblTrailer.Name = "lblTrailer"
        Me.lblTrailer.Size = New System.Drawing.Size(64, 13)
        Me.lblTrailer.TabIndex = 99
        Me.lblTrailer.Text = "Trailer URL:"
        '
        'txtTrailer
        '
        Me.txtTrailer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTrailer.Location = New System.Drawing.Point(217, 424)
        Me.txtTrailer.Name = "txtTrailer"
        Me.txtTrailer.Size = New System.Drawing.Size(408, 20)
        Me.txtTrailer.TabIndex = 17
        '
        'txtReleaseDate
        '
        Me.txtReleaseDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReleaseDate.Location = New System.Drawing.Point(79, 154)
        Me.txtReleaseDate.Name = "txtReleaseDate"
        Me.txtReleaseDate.Size = New System.Drawing.Size(71, 20)
        Me.txtReleaseDate.TabIndex = 4
        '
        'lblReleaseDate
        '
        Me.lblReleaseDate.AutoSize = True
        Me.lblReleaseDate.Location = New System.Drawing.Point(79, 138)
        Me.lblReleaseDate.Name = "lblReleaseDate"
        Me.lblReleaseDate.Size = New System.Drawing.Size(75, 13)
        Me.lblReleaseDate.TabIndex = 96
        Me.lblReleaseDate.Text = "Release Date:"
        '
        'lblCredits
        '
        Me.lblCredits.AutoSize = True
        Me.lblCredits.Location = New System.Drawing.Point(217, 324)
        Me.lblCredits.Name = "lblCredits"
        Me.lblCredits.Size = New System.Drawing.Size(42, 13)
        Me.lblCredits.TabIndex = 95
        Me.lblCredits.Text = "Credits:"
        '
        'txtCredits
        '
        Me.txtCredits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCredits.Location = New System.Drawing.Point(217, 340)
        Me.txtCredits.Name = "txtCredits"
        Me.txtCredits.Size = New System.Drawing.Size(408, 20)
        Me.txtCredits.TabIndex = 15
        '
        'lblCerts
        '
        Me.lblCerts.AutoSize = True
        Me.lblCerts.Location = New System.Drawing.Point(217, 366)
        Me.lblCerts.Name = "lblCerts"
        Me.lblCerts.Size = New System.Drawing.Size(76, 13)
        Me.lblCerts.TabIndex = 93
        Me.lblCerts.Text = "Certification(s):"
        '
        'txtCerts
        '
        Me.txtCerts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCerts.Location = New System.Drawing.Point(217, 382)
        Me.txtCerts.Name = "txtCerts"
        Me.txtCerts.Size = New System.Drawing.Size(408, 20)
        Me.txtCerts.TabIndex = 16
        '
        'lblRuntime
        '
        Me.lblRuntime.AutoSize = True
        Me.lblRuntime.Location = New System.Drawing.Point(7, 179)
        Me.lblRuntime.Name = "lblRuntime"
        Me.lblRuntime.Size = New System.Drawing.Size(49, 13)
        Me.lblRuntime.TabIndex = 91
        Me.lblRuntime.Text = "Runtime:"
        '
        'txtRuntime
        '
        Me.txtRuntime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuntime.Location = New System.Drawing.Point(7, 195)
        Me.txtRuntime.Name = "txtRuntime"
        Me.txtRuntime.Size = New System.Drawing.Size(192, 20)
        Me.txtRuntime.TabIndex = 6
        '
        'lblMPAADesc
        '
        Me.lblMPAADesc.AutoSize = True
        Me.lblMPAADesc.Location = New System.Drawing.Point(632, 251)
        Me.lblMPAADesc.Name = "lblMPAADesc"
        Me.lblMPAADesc.Size = New System.Drawing.Size(130, 13)
        Me.lblMPAADesc.TabIndex = 89
        Me.lblMPAADesc.Text = "MPAA Rating Description:"
        '
        'txtMPAADesc
        '
        Me.txtMPAADesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMPAADesc.Location = New System.Drawing.Point(635, 268)
        Me.txtMPAADesc.Multiline = True
        Me.txtMPAADesc.Name = "txtMPAADesc"
        Me.txtMPAADesc.Size = New System.Drawing.Size(193, 68)
        Me.txtMPAADesc.TabIndex = 19
        '
        'btnEditActor
        '
        Me.btnEditActor.Location = New System.Drawing.Point(298, 293)
        Me.btnEditActor.Name = "btnEditActor"
        Me.btnEditActor.Size = New System.Drawing.Size(75, 23)
        Me.btnEditActor.TabIndex = 13
        Me.btnEditActor.Text = "Edit"
        Me.btnEditActor.UseVisualStyleBackColor = True
        '
        'btnAddActor
        '
        Me.btnAddActor.Location = New System.Drawing.Point(217, 293)
        Me.btnAddActor.Name = "btnAddActor"
        Me.btnAddActor.Size = New System.Drawing.Size(75, 23)
        Me.btnAddActor.TabIndex = 12
        Me.btnAddActor.Text = "Add New"
        Me.btnAddActor.UseVisualStyleBackColor = True
        '
        'btnManual
        '
        Me.btnManual.Location = New System.Drawing.Point(755, 423)
        Me.btnManual.Name = "btnManual"
        Me.btnManual.Size = New System.Drawing.Size(75, 23)
        Me.btnManual.TabIndex = 20
        Me.btnManual.Text = "Manual Edit"
        Me.btnManual.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(550, 293)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnRemove.TabIndex = 14
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'lblActors
        '
        Me.lblActors.AutoSize = True
        Me.lblActors.Location = New System.Drawing.Point(218, 139)
        Me.lblActors.Name = "lblActors"
        Me.lblActors.Size = New System.Drawing.Size(40, 13)
        Me.lblActors.TabIndex = 83
        Me.lblActors.Text = "Actors:"
        '
        'lvActors
        '
        Me.lvActors.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colName, Me.colRole, Me.colThumb})
        Me.lvActors.FullRowSelect = True
        Me.lvActors.Location = New System.Drawing.Point(217, 155)
        Me.lvActors.Name = "lvActors"
        Me.lvActors.Size = New System.Drawing.Size(408, 132)
        Me.lvActors.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvActors.TabIndex = 11
        Me.lvActors.UseCompatibleStateImageBehavior = False
        Me.lvActors.View = System.Windows.Forms.View.Details
        '
        'colName
        '
        Me.colName.Text = "Name"
        Me.colName.Width = 110
        '
        'colRole
        '
        Me.colRole.Text = "Role"
        Me.colRole.Width = 100
        '
        'colThumb
        '
        Me.colThumb.Text = "Thumb"
        Me.colThumb.Width = 174
        '
        'lbMPAA
        '
        Me.lbMPAA.FormattingEnabled = True
        Me.lbMPAA.Items.AddRange(New Object() {"[none]", "Rated G", "Rated PG", "Rated PG-13", "Rated R", "Rated NC-17"})
        Me.lbMPAA.Location = New System.Drawing.Point(635, 155)
        Me.lbMPAA.Name = "lbMPAA"
        Me.lbMPAA.Size = New System.Drawing.Size(193, 82)
        Me.lbMPAA.TabIndex = 18
        '
        'lblGenre
        '
        Me.lblGenre.AutoSize = True
        Me.lblGenre.Location = New System.Drawing.Point(7, 268)
        Me.lblGenre.Name = "lblGenre"
        Me.lblGenre.Size = New System.Drawing.Size(39, 13)
        Me.lblGenre.TabIndex = 80
        Me.lblGenre.Text = "Genre:"
        '
        'lbGenre
        '
        Me.lbGenre.FormattingEnabled = True
        Me.lbGenre.Items.AddRange(New Object() {"[none]", "Action", "Adult", "Adventure", "Animation", "Anime", "Biography", "Bollywood", "Children", "Christmas", "Comedy", "Concert", "Crime", "Disaster", "Documentary", "Drama", "Family", "Fantasy", "Film Noir", "Halloween", "Hentai", "History", "Horror", "Independent", "Interview", "Martial Arts", "Mini-TV Series", "Monster", "Music", "Musical", "Mystery", "Nature", "Post-Apocalypse", "Religion", "Romance", "Sci-Fi", "Short", "Sport", "Stageplay", "Stand Up", "Superhero", "Supernatural", "Thriller", "War", "Wester", "Wrestling"})
        Me.lbGenre.Location = New System.Drawing.Point(6, 284)
        Me.lbGenre.Name = "lbGenre"
        Me.lbGenre.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbGenre.Size = New System.Drawing.Size(193, 160)
        Me.lbGenre.TabIndex = 8
        '
        'lblMPAA
        '
        Me.lblMPAA.AutoSize = True
        Me.lblMPAA.Location = New System.Drawing.Point(632, 139)
        Me.lblMPAA.Name = "lblMPAA"
        Me.lblMPAA.Size = New System.Drawing.Size(74, 13)
        Me.lblMPAA.TabIndex = 78
        Me.lblMPAA.Text = "MPAA Rating:"
        '
        'lblDirector
        '
        Me.lblDirector.AutoSize = True
        Me.lblDirector.Location = New System.Drawing.Point(7, 220)
        Me.lblDirector.Name = "lblDirector"
        Me.lblDirector.Size = New System.Drawing.Size(47, 13)
        Me.lblDirector.TabIndex = 77
        Me.lblDirector.Text = "Director:"
        '
        'txtDirector
        '
        Me.txtDirector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDirector.Location = New System.Drawing.Point(7, 236)
        Me.txtDirector.Name = "txtDirector"
        Me.txtDirector.Size = New System.Drawing.Size(192, 20)
        Me.txtDirector.TabIndex = 7
        '
        'txtTop250
        '
        Me.txtTop250.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTop250.Location = New System.Drawing.Point(156, 154)
        Me.txtTop250.Name = "txtTop250"
        Me.txtTop250.Size = New System.Drawing.Size(43, 20)
        Me.txtTop250.TabIndex = 5
        '
        'lblTop250
        '
        Me.lblTop250.AutoSize = True
        Me.lblTop250.Location = New System.Drawing.Point(153, 138)
        Me.lblTop250.Name = "lblTop250"
        Me.lblTop250.Size = New System.Drawing.Size(50, 13)
        Me.lblTop250.TabIndex = 74
        Me.lblTop250.Text = "Top 250:"
        '
        'lblPlot
        '
        Me.lblPlot.AutoSize = True
        Me.lblPlot.Location = New System.Drawing.Point(467, 7)
        Me.lblPlot.Name = "lblPlot"
        Me.lblPlot.Size = New System.Drawing.Size(28, 13)
        Me.lblPlot.TabIndex = 73
        Me.lblPlot.Text = "Plot:"
        '
        'txtPlot
        '
        Me.txtPlot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlot.Location = New System.Drawing.Point(443, 26)
        Me.txtPlot.Multiline = True
        Me.txtPlot.Name = "txtPlot"
        Me.txtPlot.Size = New System.Drawing.Size(385, 108)
        Me.txtPlot.TabIndex = 10
        '
        'lblOutline
        '
        Me.lblOutline.AutoSize = True
        Me.lblOutline.Location = New System.Drawing.Point(217, 7)
        Me.lblOutline.Name = "lblOutline"
        Me.lblOutline.Size = New System.Drawing.Size(43, 13)
        Me.lblOutline.TabIndex = 71
        Me.lblOutline.Text = "Outline:"
        '
        'txtOutline
        '
        Me.txtOutline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOutline.Location = New System.Drawing.Point(217, 26)
        Me.txtOutline.Multiline = True
        Me.txtOutline.Name = "txtOutline"
        Me.txtOutline.Size = New System.Drawing.Size(220, 108)
        Me.txtOutline.TabIndex = 9
        '
        'lblTagline
        '
        Me.lblTagline.AutoSize = True
        Me.lblTagline.Location = New System.Drawing.Point(7, 50)
        Me.lblTagline.Name = "lblTagline"
        Me.lblTagline.Size = New System.Drawing.Size(45, 13)
        Me.lblTagline.TabIndex = 69
        Me.lblTagline.Text = "Tagline:"
        '
        'txtTagline
        '
        Me.txtTagline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTagline.Location = New System.Drawing.Point(7, 69)
        Me.txtTagline.Name = "txtTagline"
        Me.txtTagline.Size = New System.Drawing.Size(192, 20)
        Me.txtTagline.TabIndex = 1
        '
        'pbStar5
        '
        Me.pbStar5.Location = New System.Drawing.Point(175, 110)
        Me.pbStar5.Name = "pbStar5"
        Me.pbStar5.Size = New System.Drawing.Size(24, 24)
        Me.pbStar5.TabIndex = 67
        Me.pbStar5.TabStop = False
        '
        'pbStar4
        '
        Me.pbStar4.Location = New System.Drawing.Point(151, 110)
        Me.pbStar4.Name = "pbStar4"
        Me.pbStar4.Size = New System.Drawing.Size(24, 24)
        Me.pbStar4.TabIndex = 66
        Me.pbStar4.TabStop = False
        '
        'pbStar3
        '
        Me.pbStar3.Location = New System.Drawing.Point(127, 110)
        Me.pbStar3.Name = "pbStar3"
        Me.pbStar3.Size = New System.Drawing.Size(24, 24)
        Me.pbStar3.TabIndex = 65
        Me.pbStar3.TabStop = False
        '
        'pbStar2
        '
        Me.pbStar2.Location = New System.Drawing.Point(103, 110)
        Me.pbStar2.Name = "pbStar2"
        Me.pbStar2.Size = New System.Drawing.Size(24, 24)
        Me.pbStar2.TabIndex = 64
        Me.pbStar2.TabStop = False
        '
        'pbStar1
        '
        Me.pbStar1.Location = New System.Drawing.Point(79, 110)
        Me.pbStar1.Name = "pbStar1"
        Me.pbStar1.Size = New System.Drawing.Size(24, 24)
        Me.pbStar1.TabIndex = 63
        Me.pbStar1.TabStop = False
        '
        'txtVotes
        '
        Me.txtVotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVotes.Location = New System.Drawing.Point(7, 154)
        Me.txtVotes.Name = "txtVotes"
        Me.txtVotes.Size = New System.Drawing.Size(66, 20)
        Me.txtVotes.TabIndex = 3
        '
        'lblVotes
        '
        Me.lblVotes.AutoSize = True
        Me.lblVotes.Location = New System.Drawing.Point(7, 138)
        Me.lblVotes.Name = "lblVotes"
        Me.lblVotes.Size = New System.Drawing.Size(37, 13)
        Me.lblVotes.TabIndex = 61
        Me.lblVotes.Text = "Votes:"
        '
        'lblRating
        '
        Me.lblRating.AutoSize = True
        Me.lblRating.Location = New System.Drawing.Point(76, 94)
        Me.lblRating.Name = "lblRating"
        Me.lblRating.Size = New System.Drawing.Size(41, 13)
        Me.lblRating.TabIndex = 60
        Me.lblRating.Text = "Rating:"
        '
        'mtxtYear
        '
        Me.mtxtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mtxtYear.Location = New System.Drawing.Point(7, 110)
        Me.mtxtYear.Mask = "####"
        Me.mtxtYear.Name = "mtxtYear"
        Me.mtxtYear.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.mtxtYear.Size = New System.Drawing.Size(50, 20)
        Me.mtxtYear.TabIndex = 2
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New System.Drawing.Point(7, 94)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(32, 13)
        Me.lblYear.TabIndex = 58
        Me.lblYear.Text = "Year:"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(7, 7)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(30, 13)
        Me.lblTitle.TabIndex = 57
        Me.lblTitle.Text = "Title:"
        '
        'txtTitle
        '
        Me.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTitle.Location = New System.Drawing.Point(7, 26)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(192, 20)
        Me.txtTitle.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lblPosterSize)
        Me.TabPage2.Controls.Add(Me.btnSetPosterScrape)
        Me.TabPage2.Controls.Add(Me.btnSetPoster)
        Me.TabPage2.Controls.Add(Me.pbPoster)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(836, 452)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Poster"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lblPosterSize
        '
        Me.lblPosterSize.Location = New System.Drawing.Point(8, 8)
        Me.lblPosterSize.Name = "lblPosterSize"
        Me.lblPosterSize.Size = New System.Drawing.Size(100, 23)
        Me.lblPosterSize.TabIndex = 25
        Me.lblPosterSize.Text = "Size: (XXXXxXXXX)"
        Me.lblPosterSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPosterSize.Visible = False
        '
        'btnSetPosterScrape
        '
        Me.btnSetPosterScrape.Image = CType(resources.GetObject("btnSetPosterScrape.Image"), System.Drawing.Image)
        Me.btnSetPosterScrape.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetPosterScrape.Location = New System.Drawing.Point(735, 93)
        Me.btnSetPosterScrape.Name = "btnSetPosterScrape"
        Me.btnSetPosterScrape.Size = New System.Drawing.Size(96, 83)
        Me.btnSetPosterScrape.TabIndex = 24
        Me.btnSetPosterScrape.Text = "Change Poster (Scrape)"
        Me.btnSetPosterScrape.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetPosterScrape.UseVisualStyleBackColor = True
        '
        'btnSetPoster
        '
        Me.btnSetPoster.Image = CType(resources.GetObject("btnSetPoster.Image"), System.Drawing.Image)
        Me.btnSetPoster.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetPoster.Location = New System.Drawing.Point(735, 6)
        Me.btnSetPoster.Name = "btnSetPoster"
        Me.btnSetPoster.Size = New System.Drawing.Size(96, 83)
        Me.btnSetPoster.TabIndex = 23
        Me.btnSetPoster.Text = "Change Poster (Local)"
        Me.btnSetPoster.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetPoster.UseVisualStyleBackColor = True
        '
        'pbPoster
        '
        Me.pbPoster.BackColor = System.Drawing.Color.DimGray
        Me.pbPoster.Location = New System.Drawing.Point(6, 6)
        Me.pbPoster.Name = "pbPoster"
        Me.pbPoster.Size = New System.Drawing.Size(724, 440)
        Me.pbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbPoster.TabIndex = 0
        Me.pbPoster.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lblFanartSize)
        Me.TabPage3.Controls.Add(Me.btnSetFanartScrape)
        Me.TabPage3.Controls.Add(Me.btnSetFanart)
        Me.TabPage3.Controls.Add(Me.pbFanart)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(836, 452)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Fanart"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lblFanartSize
        '
        Me.lblFanartSize.Location = New System.Drawing.Point(8, 8)
        Me.lblFanartSize.Name = "lblFanartSize"
        Me.lblFanartSize.Size = New System.Drawing.Size(100, 23)
        Me.lblFanartSize.TabIndex = 27
        Me.lblFanartSize.Text = "Size: (XXXXxXXXX)"
        Me.lblFanartSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblFanartSize.Visible = False
        '
        'btnSetFanartScrape
        '
        Me.btnSetFanartScrape.Image = CType(resources.GetObject("btnSetFanartScrape.Image"), System.Drawing.Image)
        Me.btnSetFanartScrape.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetFanartScrape.Location = New System.Drawing.Point(735, 93)
        Me.btnSetFanartScrape.Name = "btnSetFanartScrape"
        Me.btnSetFanartScrape.Size = New System.Drawing.Size(96, 83)
        Me.btnSetFanartScrape.TabIndex = 26
        Me.btnSetFanartScrape.Text = "Change Fanart (Scrape)"
        Me.btnSetFanartScrape.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetFanartScrape.UseVisualStyleBackColor = True
        '
        'btnSetFanart
        '
        Me.btnSetFanart.Image = CType(resources.GetObject("btnSetFanart.Image"), System.Drawing.Image)
        Me.btnSetFanart.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetFanart.Location = New System.Drawing.Point(735, 6)
        Me.btnSetFanart.Name = "btnSetFanart"
        Me.btnSetFanart.Size = New System.Drawing.Size(96, 83)
        Me.btnSetFanart.TabIndex = 25
        Me.btnSetFanart.Text = "Change Fanart (Local)"
        Me.btnSetFanart.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetFanart.UseVisualStyleBackColor = True
        '
        'pbFanart
        '
        Me.pbFanart.BackColor = System.Drawing.Color.DimGray
        Me.pbFanart.Location = New System.Drawing.Point(6, 6)
        Me.pbFanart.Name = "pbFanart"
        Me.pbFanart.Size = New System.Drawing.Size(724, 440)
        Me.pbFanart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbFanart.TabIndex = 1
        Me.pbFanart.TabStop = False
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.btnFrameSave)
        Me.TabPage4.Controls.Add(Me.pnlFrameProgress)
        Me.TabPage4.Controls.Add(Me.btnGrab)
        Me.TabPage4.Controls.Add(Me.lblTime)
        Me.TabPage4.Controls.Add(Me.tbFrame)
        Me.TabPage4.Controls.Add(Me.btnFrameLoad)
        Me.TabPage4.Controls.Add(Me.pbFrame)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(836, 452)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Frame Extraction"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'pbFrame
        '
        Me.pbFrame.BackColor = System.Drawing.Color.DimGray
        Me.pbFrame.Location = New System.Drawing.Point(6, 6)
        Me.pbFrame.Name = "pbFrame"
        Me.pbFrame.Size = New System.Drawing.Size(724, 414)
        Me.pbFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbFrame.TabIndex = 8
        Me.pbFrame.TabStop = False
        '
        'btnFrameSave
        '
        Me.btnFrameSave.Enabled = False
        Me.btnFrameSave.Image = CType(resources.GetObject("btnFrameSave.Image"), System.Drawing.Image)
        Me.btnFrameSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFrameSave.Location = New System.Drawing.Point(735, 362)
        Me.btnFrameSave.Name = "btnFrameSave"
        Me.btnFrameSave.Size = New System.Drawing.Size(96, 83)
        Me.btnFrameSave.TabIndex = 7
        Me.btnFrameSave.Text = "Save Extrathumb"
        Me.btnFrameSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFrameSave.UseVisualStyleBackColor = True
        '
        'pnlFrameProgress
        '
        Me.pnlFrameProgress.BackColor = System.Drawing.Color.White
        Me.pnlFrameProgress.Controls.Add(Me.Label3)
        Me.pnlFrameProgress.Controls.Add(Me.ProgressBar1)
        Me.pnlFrameProgress.Location = New System.Drawing.Point(241, 175)
        Me.pnlFrameProgress.Name = "pnlFrameProgress"
        Me.pnlFrameProgress.Size = New System.Drawing.Size(252, 51)
        Me.pnlFrameProgress.TabIndex = 6
        Me.pnlFrameProgress.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Extracting Frame..."
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(5, 28)
        Me.ProgressBar1.MarqueeAnimationSpeed = 25
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(242, 16)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 0
        '
        'btnGrab
        '
        Me.btnGrab.Enabled = False
        Me.btnGrab.Location = New System.Drawing.Point(655, 423)
        Me.btnGrab.Name = "btnGrab"
        Me.btnGrab.Size = New System.Drawing.Size(75, 23)
        Me.btnGrab.TabIndex = 5
        Me.btnGrab.Text = "Grab Frame"
        Me.btnGrab.UseVisualStyleBackColor = True
        '
        'lblTime
        '
        Me.lblTime.Location = New System.Drawing.Point(590, 423)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(59, 23)
        Me.lblTime.TabIndex = 4
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbFrame
        '
        Me.tbFrame.BackColor = System.Drawing.Color.White
        Me.tbFrame.Enabled = False
        Me.tbFrame.Location = New System.Drawing.Point(6, 422)
        Me.tbFrame.Name = "tbFrame"
        Me.tbFrame.Size = New System.Drawing.Size(580, 45)
        Me.tbFrame.TabIndex = 2
        Me.tbFrame.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'btnFrameLoad
        '
        Me.btnFrameLoad.Image = CType(resources.GetObject("btnFrameLoad.Image"), System.Drawing.Image)
        Me.btnFrameLoad.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFrameLoad.Location = New System.Drawing.Point(735, 6)
        Me.btnFrameLoad.Name = "btnFrameLoad"
        Me.btnFrameLoad.Size = New System.Drawing.Size(96, 83)
        Me.btnFrameLoad.TabIndex = 1
        Me.btnFrameLoad.Text = "Load Movie"
        Me.btnFrameLoad.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFrameLoad.UseVisualStyleBackColor = True
        '
        'dlgEditMovie
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(854, 582)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.pnlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgEditMovie"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Movie"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.pbStar5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStar4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStar3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.pbPoster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.pbFanart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.pbFrame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFrameProgress.ResumeLayout(False)
        Me.pnlFrameProgress.PerformLayout()
        CType(Me.tbFrame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents lblMPAADesc As System.Windows.Forms.Label
    Friend WithEvents txtMPAADesc As System.Windows.Forms.TextBox
    Friend WithEvents btnEditActor As System.Windows.Forms.Button
    Friend WithEvents btnAddActor As System.Windows.Forms.Button
    Friend WithEvents btnManual As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents lblActors As System.Windows.Forms.Label
    Friend WithEvents lvActors As System.Windows.Forms.ListView
    Friend WithEvents colName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colRole As System.Windows.Forms.ColumnHeader
    Friend WithEvents colThumb As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbMPAA As System.Windows.Forms.ListBox
    Friend WithEvents lblGenre As System.Windows.Forms.Label
    Friend WithEvents lbGenre As System.Windows.Forms.ListBox
    Friend WithEvents lblMPAA As System.Windows.Forms.Label
    Friend WithEvents lblDirector As System.Windows.Forms.Label
    Friend WithEvents txtDirector As System.Windows.Forms.TextBox
    Friend WithEvents txtTop250 As System.Windows.Forms.TextBox
    Friend WithEvents lblTop250 As System.Windows.Forms.Label
    Friend WithEvents lblPlot As System.Windows.Forms.Label
    Friend WithEvents txtPlot As System.Windows.Forms.TextBox
    Friend WithEvents lblOutline As System.Windows.Forms.Label
    Friend WithEvents txtOutline As System.Windows.Forms.TextBox
    Friend WithEvents lblTagline As System.Windows.Forms.Label
    Friend WithEvents txtTagline As System.Windows.Forms.TextBox
    Friend WithEvents pbStar5 As System.Windows.Forms.PictureBox
    Friend WithEvents pbStar4 As System.Windows.Forms.PictureBox
    Friend WithEvents pbStar3 As System.Windows.Forms.PictureBox
    Friend WithEvents pbStar2 As System.Windows.Forms.PictureBox
    Friend WithEvents pbStar1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtVotes As System.Windows.Forms.TextBox
    Friend WithEvents lblVotes As System.Windows.Forms.Label
    Friend WithEvents lblRating As System.Windows.Forms.Label
    Friend WithEvents mtxtYear As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btnSetPoster As System.Windows.Forms.Button
    Friend WithEvents pbPoster As System.Windows.Forms.PictureBox
    Friend WithEvents btnSetFanart As System.Windows.Forms.Button
    Friend WithEvents pbFanart As System.Windows.Forms.PictureBox
    Friend WithEvents ofdImage As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblRuntime As System.Windows.Forms.Label
    Friend WithEvents txtRuntime As System.Windows.Forms.TextBox
    Friend WithEvents txtReleaseDate As System.Windows.Forms.TextBox
    Friend WithEvents lblReleaseDate As System.Windows.Forms.Label
    Friend WithEvents lblCredits As System.Windows.Forms.Label
    Friend WithEvents txtCredits As System.Windows.Forms.TextBox
    Friend WithEvents lblCerts As System.Windows.Forms.Label
    Friend WithEvents txtCerts As System.Windows.Forms.TextBox
    Friend WithEvents lblTrailer As System.Windows.Forms.Label
    Friend WithEvents txtTrailer As System.Windows.Forms.TextBox
    Friend WithEvents btnSetPosterScrape As System.Windows.Forms.Button
    Friend WithEvents btnSetFanartScrape As System.Windows.Forms.Button
    Friend WithEvents lblPosterSize As System.Windows.Forms.Label
    Friend WithEvents lblFanartSize As System.Windows.Forms.Label
    Friend WithEvents lblStudio As System.Windows.Forms.Label
    Friend WithEvents txtStudio As System.Windows.Forms.TextBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents btnFrameLoad As System.Windows.Forms.Button
    Friend WithEvents tbFrame As System.Windows.Forms.TrackBar
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents btnGrab As System.Windows.Forms.Button
    Friend WithEvents pnlFrameProgress As System.Windows.Forms.Panel
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnFrameSave As System.Windows.Forms.Button
    Friend WithEvents pbFrame As System.Windows.Forms.PictureBox

End Class
