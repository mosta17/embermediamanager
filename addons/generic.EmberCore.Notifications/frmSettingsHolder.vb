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

Public Class frmSettingsHolder

    #Region "Events"

    Public Event ModuleEnabledChanged(ByVal State As Boolean)

    Public Event ModuleSettingsChanged()

    #End Region 'Events

    #Region "Methods"

    Private Sub chkAddNewMovie_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOnNewMovie.CheckedChanged
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Private Sub chkEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnabled.CheckedChanged
        RaiseEvent ModuleEnabledChanged(chkEnabled.Checked)
    End Sub

    Private Sub chkOnError_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOnError.CheckedChanged
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Private Sub chkOnMovieScraped_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOnMovieScraped.CheckedChanged
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Private Sub chkOnNewEp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOnNewEp.CheckedChanged
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Public Sub New()
        InitializeComponent()
        Me.SetUp()
    End Sub

    Private Sub SetUp()
        Me.chkEnabled.Text = Master.eLang.GetString(774, "Enabled", True)
        Me.chkOnError.Text = Master.eLang.GetString(1, "On Error")
        Me.chkOnNewMovie.Text = Master.eLang.GetString(2, "On New Movie Added")
        Me.chkOnMovieScraped.Text = Master.eLang.GetString(3, "On Movie Scraped")
        Me.chkOnNewEp.Text = Master.eLang.GetString(4, "On New Episode Added")

    End Sub

    #End Region 'Methods

End Class