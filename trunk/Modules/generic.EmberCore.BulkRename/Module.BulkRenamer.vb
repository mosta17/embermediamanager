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

Imports EmberAPI

Public Class BulkRenamerModule
    Implements Interfaces.EmberExternalModule

#Region "Fields"

    Private WithEvents MyMenu As New System.Windows.Forms.ToolStripMenuItem
    Private MySettings As New _MySettings
    Private WithEvents MyTrayMenu As New System.Windows.Forms.ToolStripMenuItem
    Private _AssemblyName As String = String.Empty
    Private _enabled As Boolean = False
    Private _Name As String = "Renamer"
    Private _setup As frmSettingsHolder

#End Region 'Fields

#Region "Events"

    Public Event GenericEvent(ByVal mType As Enums.ModuleEventType, ByRef _params As List(Of Object)) Implements Interfaces.EmberExternalModule.GenericEvent

    Public Event ModuleEnabledChanged(ByVal Name As String, ByVal State As Boolean, ByVal diffOrder As Integer) Implements Interfaces.EmberExternalModule.ModuleSetupChanged

    Public Event ModuleSettingsChanged() Implements Interfaces.EmberExternalModule.ModuleSettingsChanged

#End Region 'Events

#Region "Properties"

    Public ReadOnly Property ModuleType() As List(Of Enums.ModuleEventType) Implements Interfaces.EmberExternalModule.ModuleType
        Get
            Return New List(Of Enums.ModuleEventType)(New Enums.ModuleEventType() {Enums.ModuleEventType.MovieScraperRDYtoSave, Enums.ModuleEventType.RenameMovie, Enums.ModuleEventType.RenameMovieManual})
        End Get
    End Property

    Property Enabled() As Boolean Implements Interfaces.EmberExternalModule.Enabled
        Get
            Return _enabled
        End Get
        Set(ByVal value As Boolean)
            If _enabled = value Then Return
            _enabled = value
            If _enabled Then
                Enable()
            Else
                Disable()
            End If

        End Set
    End Property

    ReadOnly Property ModuleName() As String Implements Interfaces.EmberExternalModule.ModuleName
        Get
            Return _Name
        End Get
    End Property

    ReadOnly Property ModuleVersion() As String Implements Interfaces.EmberExternalModule.ModuleVersion
        Get
            Return FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FilePrivatePart.ToString
        End Get
    End Property

#End Region 'Properties

#Region "Methods"

    Public Function RunGeneric(ByVal mType As Enums.ModuleEventType, ByRef _params As List(Of Object)) As Interfaces.ModuleResult Implements Interfaces.EmberExternalModule.RunGeneric
        Select Case mType
            Case Enums.ModuleEventType.MovieScraperRDYtoSave
                Dim tDBMovie As EmberAPI.Structures.DBMovie = DirectCast(_params(0), EmberAPI.Structures.DBMovie)
                ' TODO: Some of the Bellow setting should move to Module
                If MySettings.AutoRenameMulti AndAlso Master.GlobalScrapeMod.NFO AndAlso (Not String.IsNullOrEmpty(MySettings.FoldersPattern) AndAlso Not String.IsNullOrEmpty(MySettings.FilesPattern)) Then
                    FileFolderRenamer.RenameSingle(tDBMovie, MySettings.FoldersPattern, MySettings.FilesPattern, False, Not String.IsNullOrEmpty(tDBMovie.Movie.IMDBID), False)
                End If
            Case Enums.ModuleEventType.RenameMovie
                If MySettings.AutoRenameSingle AndAlso Not String.IsNullOrEmpty(MySettings.FoldersPattern) AndAlso Not String.IsNullOrEmpty(MySettings.FilesPattern) Then
                    Dim tDBMovie As EmberAPI.Structures.DBMovie = DirectCast(_params(0), EmberAPI.Structures.DBMovie)
                    Dim BatchMode As Boolean = DirectCast(_params(1), Boolean)
                    Dim ToNFO As Boolean = DirectCast(_params(2), Boolean)
                    Dim ShowErrors As Boolean = DirectCast(_params(3), Boolean)
                    FileFolderRenamer.RenameSingle(tDBMovie, MySettings.FoldersPattern, MySettings.FilesPattern, BatchMode, ToNFO, ShowErrors)
                End If
            Case Enums.ModuleEventType.RenameMovieManual
                Using dRenameManual As New dlgRenameManual
                    Select Case dRenameManual.ShowDialog()
                        Case Windows.Forms.DialogResult.OK
                            Return New Interfaces.ModuleResult With {.Cancelled = False, .breakChain = False}
                        Case Else
                            Return New Interfaces.ModuleResult With {.Cancelled = True, .breakChain = False}
                    End Select
                End Using
        End Select
        Return New Interfaces.ModuleResult With {.breakChain = False}
    End Function

    Sub Disable()
        Dim tsi As New ToolStripMenuItem
        tsi = DirectCast(ModulesManager.Instance.RuntimeObjects.TopMenu.Items("ToolsToolStripMenuItem"), ToolStripMenuItem)
        tsi.DropDownItems.Remove(MyMenu)
        tsi = DirectCast(ModulesManager.Instance.RuntimeObjects.TrayMenu.Items("cmnuTrayIconTools"), ToolStripMenuItem)
        tsi.DropDownItems.Remove(MyTrayMenu)
        '_enabled = False
    End Sub

    Sub Enable()
        Dim tsi As New ToolStripMenuItem
        MyMenu.Image = New Bitmap(My.Resources.icon)
        MyMenu.Text = Master.eLang.GetString(13, "Bulk &Renamer")
        '.RenamerToolStripMenuItem.Text = Master.eLang.GetString(13, "Bulk &Renamer")
        tsi = DirectCast(ModulesManager.Instance.RuntimeObjects.TopMenu.Items("ToolsToolStripMenuItem"), ToolStripMenuItem)
        tsi.DropDownItems.Add(MyMenu)
        MyTrayMenu.Image = New Bitmap(My.Resources.icon)
        MyTrayMenu.Text = Master.eLang.GetString(13, "Bulk &Renamer")
        tsi = DirectCast(ModulesManager.Instance.RuntimeObjects.TrayMenu.Items("cmnuTrayIconTools"), ToolStripMenuItem)
        tsi.DropDownItems.Add(MyTrayMenu)
        '_enabled = True
    End Sub

    Private Sub Handle_ModuleSettingsChanged()
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Private Sub Handle_SetupChanged(ByVal state As Boolean, ByVal difforder As Integer)
        RaiseEvent ModuleEnabledChanged(Me._Name, state, difforder)
    End Sub

    Sub Init(ByVal sAssemblyName As String) Implements Interfaces.EmberExternalModule.Init
        _AssemblyName = sAssemblyName
        LoadSettings()
    End Sub

    Function InjectSetup() As Containers.SettingsPanel Implements Interfaces.EmberExternalModule.InjectSetup
        Dim SPanel As New Containers.SettingsPanel
        Me._setup = New frmSettingsHolder
        Me._setup.chkEnabled.Checked = Me._enabled
        Me._setup.txtFolderPattern.Text = MySettings.FoldersPattern
        Me._setup.txtFilePattern.Text = MySettings.FilesPattern
        _setup.chkRenameMulti.Checked = MySettings.AutoRenameMulti
        _setup.chkRenameSingle.Checked = MySettings.AutoRenameSingle
        _setup.chkGenericModule.Checked = MySettings.GenericModule
        _setup.chkBulkRenamer.Checked = MySettings.BulkRenamer
        SPanel.Name = Me._Name
        SPanel.Text = Me._Name
        SPanel.Prefix = "Renamer_"
        SPanel.Type = Master.eLang.GetString(802, "Modules", True)
        SPanel.ImageIndex = If(Me._enabled, 9, 10)
        SPanel.Order = 100
        SPanel.Panel = Me._setup.pnlSettings()
        AddHandler _setup.ModuleEnabledChanged, AddressOf Handle_SetupChanged
        AddHandler _setup.ModuleSettingsChanged, AddressOf Handle_ModuleSettingsChanged
        Return SPanel
    End Function

    Sub LoadSettings()
        MySettings.FoldersPattern = AdvancedSettings.GetSetting("FoldersPattern", "$T {($Y)}")
        MySettings.FilesPattern = AdvancedSettings.GetSetting("FilesPattern", "$T{.$S}")
        MySettings.AutoRenameMulti = AdvancedSettings.GetBooleanSetting("AutoRenameMulti", False)
        MySettings.AutoRenameSingle = AdvancedSettings.GetBooleanSetting("AutoRenameSingle", False)
        MySettings.BulkRenamer = AdvancedSettings.GetBooleanSetting("BulkRenamer", True)
        MySettings.GenericModule = AdvancedSettings.GetBooleanSetting("GenericModule", True)
    End Sub

    Private Sub MyMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyMenu.Click
        Using dBulkRename As New dlgBulkRenamer
            dBulkRename.txtFolder.Text = MySettings.FoldersPattern
            dBulkRename.txtFile.Text = MySettings.FilesPattern
            Try
                If dBulkRename.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ModulesManager.Instance.RuntimeObjects.InvokeLoadMedia(New Structures.Scans With {.Movies = True}, String.Empty)
                End If
            Catch ex As Exception
            End Try
        End Using
    End Sub

    Private Sub MyTrayMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyTrayMenu.Click
        Using dBulkRename As New dlgBulkRenamer
            dBulkRename.txtFolder.Text = MySettings.FoldersPattern
            dBulkRename.txtFile.Text = MySettings.FilesPattern
            Try
                If dBulkRename.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ModulesManager.Instance.RuntimeObjects.InvokeLoadMedia(New Structures.Scans With {.Movies = True}, String.Empty)
                End If
            Catch ex As Exception
            End Try
        End Using
    End Sub

    Sub SaveEmberExternalModule(ByVal DoDispose As Boolean) Implements Interfaces.EmberExternalModule.SaveSetup
        Me.Enabled = _setup.chkEnabled.Checked
        MySettings.FoldersPattern = _setup.txtFolderPattern.Text
        MySettings.FilesPattern = _setup.txtFilePattern.Text
        MySettings.AutoRenameMulti = _setup.chkRenameMulti.Checked
        MySettings.AutoRenameSingle = _setup.chkRenameSingle.Checked
        MySettings.GenericModule = _setup.chkGenericModule.Checked
        MySettings.BulkRenamer = _setup.chkBulkRenamer.Checked
        SaveSettings()
    End Sub

    Sub SaveSettings()
        AdvancedSettings.SetSetting("FoldersPattern", MySettings.FoldersPattern)
        AdvancedSettings.SetSetting("FilesPattern", MySettings.FilesPattern)
        AdvancedSettings.SetBooleanSetting("AutoRenameMulti", MySettings.AutoRenameMulti)
        AdvancedSettings.SetBooleanSetting("AutoRenameSingle", MySettings.AutoRenameSingle)
        AdvancedSettings.SetBooleanSetting("BulkRenamer", MySettings.BulkRenamer)
        AdvancedSettings.SetBooleanSetting("GenericModule", MySettings.GenericModule)
    End Sub

#End Region 'Methods

#Region "Nested Types"

    Structure _MySettings

#Region "Fields"

        Dim AutoRenameMulti As Boolean
        Dim AutoRenameSingle As Boolean
        Dim BulkRenamer As Boolean
        Dim FilesPattern As String
        Dim FoldersPattern As String
        Dim GenericModule As Boolean

#End Region 'Fields

    End Structure

#End Region 'Nested Types

End Class