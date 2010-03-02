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

Public Class MovieExporterModule
    Implements EmberAPI.Interfaces.EmberExternalModule
    Dim emmRuntimeObjects As New ModulesManager.EmberRuntimeObjects
    Private _enabled As Boolean = False
    Private _Name As String = "Movie List Exporter"
    Function InjectSetup(ByRef p As System.Windows.Forms.Panel) As Integer Implements EmberAPI.Interfaces.EmberExternalModule.InjectSetup
        'Dim _setup As New frmSetup
        '_setup.ShowDialog()
        Return 0
    End Function
    Sub SaveSetupScraper() Implements EmberAPI.Interfaces.EmberExternalModule.SaveSetup

    End Sub

    Property Enabled() As Boolean Implements EmberAPI.Interfaces.EmberExternalModule.Enabled
        Get
            Return _enabled
        End Get
        Set(ByVal value As Boolean)
            _enabled = value
            If _enabled Then
                Enable()
            Else
                disable()
            End If
        End Set
    End Property

    Sub Enable()
        Dim tmpExportMovies As New dlgExportMovies
        MyMenu.Image = New Bitmap(tmpExportMovies.Icon.ToBitmap)
        MyMenu.Text = "Export Movie List"
        Dim tsi As ToolStripMenuItem = DirectCast(emmRuntimeObjects.TopMenu.Items("ToolsToolStripMenuItem"), ToolStripMenuItem)
        tsi.DropDownItems.Add(MyMenu)
        tmpExportMovies.Dispose()

    End Sub
    Sub Disable()
        Dim tsi As ToolStripMenuItem = DirectCast(emmRuntimeObjects.TopMenu.Items("ToolsToolStripMenuItem"), ToolStripMenuItem)
        tsi.DropDownItems.Remove(MyMenu)
    End Sub
    Sub Init(ByRef emm As ModulesManager.EmberRuntimeObjects) Implements EmberAPI.Interfaces.EmberExternalModule.Init
        emmRuntimeObjects = emm
        'Master.eLang.LoadLanguage(Master.eSettings.Language)
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
        Using dExportMovies As New dlgExportMovies
            dExportMovies.ShowDialog()
        End Using
    End Sub
End Class
