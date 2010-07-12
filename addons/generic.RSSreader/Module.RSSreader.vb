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

Imports System
Imports System.Drawing
Imports System.Drawing.Bitmap
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Xml.Serialization

Public Class RSSreaderExternalModule
    Implements Interfaces.EmberExternalModule

#Region "Fields"

    'Private eSettings As New Settings
    Private WithEvents MyMenu As New System.Windows.Forms.ToolStripMenuItem
    Private MyMenuSep As New System.Windows.Forms.ToolStripSeparator
    Private MyPath As String
    Private _enabled As Boolean = False
    Private _Name As String = Master.eLang.GetString(1, "RSS Reader")
    Private _setup As frmSettingsHolder
    Private withErrors As Boolean
    Private fRSS As frmRSSReader
    Private _rssReader As New List(Of RSSReader)
#End Region 'Fields

#Region "Events"

    Public Event GenericEvent(ByVal mType As Enums.ModuleEventType, ByRef _params As List(Of Object)) Implements Interfaces.EmberExternalModule.GenericEvent

    Public Event ModuleEnabledChanged(ByVal Name As String, ByVal State As Boolean, ByVal diffOrder As Integer) Implements Interfaces.EmberExternalModule.ModuleSetupChanged

    Public Event ModuleSettingsChanged() Implements Interfaces.EmberExternalModule.ModuleSettingsChanged

#End Region 'Events

#Region "Properties"

    Public ReadOnly Property ModuleType() As List(Of Enums.ModuleEventType) Implements Interfaces.EmberExternalModule.ModuleType
        Get
            Return New List(Of Enums.ModuleEventType)(New Enums.ModuleEventType() {Enums.ModuleEventType.Generic})
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

    Public Sub Load()
        Dim hrsslist As New Hashtable
        hrsslist = AdvancedSettings.GetComplexSetting(String.Concat("rss"))
        If Not _setup Is Nothing Then
            _setup.ListView1.Items.Clear()
            If Not hrsslist Is Nothing Then
                For Each k In hrsslist.Keys
                    Dim i As ListViewItem = _setup.ListView1.Items.Add(k.ToString)
                    i.SubItems.Add(hrsslist.Item(k).ToString)
                Next
            Else
                hrsslist = New Hashtable
            End If
        End If
    End Sub
    Private Sub ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyMenu.Click
        'If fRSS Is Nothing Then
        fRSS = New frmRSSReader()
        For Each rss As RSSReader In _rssReader
            fRSS.AddRSS(rss)
        Next
        'End If
        fRSS.Show()
    End Sub

    Public Function RunGeneric(ByVal mType As Enums.ModuleEventType, ByRef _params As List(Of Object), ByRef _refparam As Object) As Interfaces.ModuleResult Implements Interfaces.EmberExternalModule.RunGeneric
        Return New Interfaces.ModuleResult With {.breakChain = False}
    End Function

    Public Sub Save()
        Dim hrsslist As New Hashtable
        For Each i As ListViewItem In _setup.ListView1.Items
            hrsslist.Add(i.SubItems(0).Text, i.SubItems(1).Text)
        Next
        AdvancedSettings.SetComplexSetting(String.Concat("rss"), hrsslist)
    End Sub

    Sub Disable()
        'ModulesManager.Instance.RuntimeObjects.TopMenu.Items.Remove(MyMenuSep)
        ModulesManager.Instance.RuntimeObjects.TopMenu.Items.Remove(MyMenu)
        For Each rss As RSSReader In _rssReader
            rss = Nothing
        Next
        _rssReader.Clear()
    End Sub

    Sub Enable()
        MyMenu.Text = Master.eLang.GetString(1, "RSS Reader")
        MyMenu.Alignment = ToolStripItemAlignment.Right
        'ModulesManager.Instance.RuntimeObjects.TopMenu.Items.Add(MyMenuSep)
        ModulesManager.Instance.RuntimeObjects.TopMenu.Items.Add(MyMenu)
        Dim hrsslist As New Hashtable
        hrsslist = AdvancedSettings.GetComplexSetting(String.Concat("rss"))
        If Not hrsslist Is Nothing Then
            For Each k In hrsslist.Keys
                _rssReader.Add(New RSSReader(hrsslist.Item(k).ToString))
            Next
        End If
    End Sub

    Private Sub Handle_ModuleEnabledChanged(ByVal State As Boolean)
        RaiseEvent ModuleEnabledChanged(Me._Name, State, 0)
    End Sub

    Private Sub Handle_ModuleSettingsChanged()
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Sub Init(ByVal sAssemblyName As String) Implements Interfaces.EmberExternalModule.Init
        MyPath = Path.Combine(Functions.AppPath, "Modules")
        Load()
    End Sub

    Function InjectSetup() As Containers.SettingsPanel Implements Interfaces.EmberExternalModule.InjectSetup
        Dim SPanel As New Containers.SettingsPanel
        _setup = New frmSettingsHolder
        _setup.cbEnabled.Checked = Enabled
        Load()
        SPanel.Name = Me._Name
        SPanel.Text = Master.eLang.GetString(0, "RSS Reader")
        SPanel.Prefix = "RSSReader_"
        SPanel.Type = Master.eLang.GetString(802, "Modules", True)
        SPanel.ImageIndex = If(Me._enabled, 9, 10)
        SPanel.Order = 100
        SPanel.Panel = _setup.pnlSettings
        AddHandler Me._setup.ModuleEnabledChanged, AddressOf Handle_ModuleEnabledChanged
        AddHandler Me._setup.ModuleSettingsChanged, AddressOf Handle_ModuleSettingsChanged
        Return SPanel
    End Function

    Sub SaveSetupScraper(ByVal DoDispose As Boolean) Implements Interfaces.EmberExternalModule.SaveSetup
        Me.Enabled = False
        Me.Enabled = Me._setup.cbEnabled.Checked
        Save()
    End Sub


#End Region 'Methods



End Class