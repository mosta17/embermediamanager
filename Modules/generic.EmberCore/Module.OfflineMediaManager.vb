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

Public Class OfflineHolderModule
    Implements EmberAPI.Interfaces.EmberExternalModule
    Dim emmRuntimeObjects As New ModulesManager.EmberRuntimeObjects

    Private enabled As Boolean = False
    Private _Name As String = "Offline Media Manager"
    Sub Setup() Implements EmberAPI.Interfaces.EmberExternalModule.Setup
        'Dim _setup As New frmSetup
        '_setup.ShowDialog()
    End Sub
    Sub Enable() Implements EmberAPI.Interfaces.EmberExternalModule.Enable
        If Not enabled Then
            Dim tmpOfflineHolder As New dlgOfflineHolder
            MyMenu.Image = tmpOfflineHolder.Icon.ToBitmap.Clone
            MyMenu.Text = "Offline Media Manager"
            '= Master.eLang.GetString(15, "&Offline Media Manager")
            Dim tsi As ToolStripMenuItem = emmRuntimeObjects.TopMenu.Items("ToolsToolStripMenuItem")
            tsi.DropDownItems.Add(MyMenu)
            enabled = True
            tmpOfflineHolder.Dispose()
        End If
    End Sub
    Sub Disable() Implements EmberAPI.Interfaces.EmberExternalModule.Disable
        If enabled Then
            Dim tsi As ToolStripMenuItem = emmRuntimeObjects.TopMenu.Items("ToolsToolStripMenuItem")
            tsi.DropDownItems.Remove(MyMenu)
            enabled = False
        End If
    End Sub
    Sub Init(ByRef emm As ModulesManager.EmberRuntimeObjects) Implements EmberAPI.Interfaces.EmberExternalModule.Init
        emmRuntimeObjects = emm
    End Sub

    ReadOnly Property ModuleName() As String Implements EmberAPI.Interfaces.EmberExternalModule.ModuleName
        Get
            Return _Name
        End Get
    End Property
    ReadOnly Property ModuleVersion() As String Implements EmberAPI.Interfaces.EmberExternalModule.ModuleVersion
        Get
            Return FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FilePrivatePart.ToString
        End Get
    End Property

    'Dim MyMenu As New System.Windows.Forms.ToolStripMenuItem
    Dim WithEvents MyMenu As New System.Windows.Forms.ToolStripMenuItem
    Private Sub MyMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyMenu.Click
        Using dOfflineHolder As New dlgOfflineHolder
            If dOfflineHolder.ShowDialog() = Windows.Forms.DialogResult.OK Then
                'Me.LoadMedia(New Structures.Scans With {.Movies = True})
            End If
        End Using
    End Sub
End Class
