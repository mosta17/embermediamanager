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

Public Class frmYAMJ

#Region "Events"
    Public Event ModuleEnabledChanged(ByVal State As Boolean, ByVal difforder As Integer)

    Public Event ModuleSettingsChanged()

#End Region 'Events




    Private Sub chkEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnabled.CheckedChanged
        RaiseEvent ModuleEnabledChanged(chkEnabled.Checked, 0)
    End Sub

    Public Sub New()
        InitializeComponent()
        Me.SetUp()
    End Sub

    Private Sub SetUp()
        'Me.chkEnabled.Text = Master.eLang.GetString(774, "Enabled", True)
        Me.chkYAMJCompatibleSets.Text = Master.eLang.GetString(2, "YAMJ Compatible Sets")
        Me.chkVideoTSParent.Text = Master.eLang.GetString(3, "YAMJ Compatible VIDEO_TS File Placement/Naming")
        Me.chkYAMJCompatibleTVImages.Text = Master.eLang.GetString(4, "YAMJ Compatible TV Images Naming")
        Me.chkYAMJnfoFields.Text = Master.eLang.GetString(5, "YAMJ Specific NFO fields")
        Me.chkShowPoster.Text = Master.eLang.GetString(6, "Show Poster as SET_<Show>_1.jpg")
        Me.chkShowFanart.Text = Master.eLang.GetString(7, "Show Poster as SET_<Show>_1.jpg")
        Me.chkSeasonPoster.Text = Master.eLang.GetString(8, "Season Poster as <Episode>SxxE01.jpg")
        Me.chkSeasonFanart.Text = Master.eLang.GetString(9, "Season Fanart as <Episode>SxxE01.fanart.jpg")
        Me.chkEpisodePoster.Text = Master.eLang.GetString(10, "Episode Poster as <Show>.videoimage.jpg")
    End Sub


    Sub CheckAnyEnabled()
        If chkVideoTSParent.Checked OrElse chkYAMJCompatibleSets.Checked OrElse chkYAMJCompatibleTVImages.Checked _
            OrElse chkYAMJnfoFields.Checked Then
            chkEnabled.Checked = True
        Else
            chkEnabled.Checked = False
        End If
        RaiseEvent ModuleEnabledChanged(chkEnabled.Checked, 0)
    End Sub

    Private Sub chkVideoTSParent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVideoTSParent.CheckedChanged
        CheckAnyEnabled()
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Private Sub chkYAMJCompatibleSets_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkYAMJCompatibleSets.CheckedChanged
        CheckAnyEnabled()
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Private Sub chkYAMJCompatibleTVSets_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkYAMJCompatibleTVImages.CheckedChanged
        CheckAnyEnabled()
        gbImages.Enabled = chkYAMJCompatibleTVImages.Checked
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Private Sub btnCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckAll.Click
        chkVideoTSParent.Checked = True
        chkYAMJCompatibleSets.Checked = True
        chkYAMJCompatibleTVImages.Checked = True
        chkYAMJnfoFields.Checked = True
        chkShowPoster.Checked = True
        chkShowFanart.Checked = True
        chkSeasonPoster.Checked = True
        chkSeasonFanart.Checked = True
        chkEpisodePoster.Checked = True

    End Sub

    Private Sub chkYAMJnfoFields_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkYAMJnfoFields.CheckedChanged
        CheckAnyEnabled()
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Private Sub chkShowPoster_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowPoster.CheckedChanged
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Private Sub chkShowFanart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowFanart.CheckedChanged
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Private Sub chkSeasonPoster_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSeasonPoster.CheckedChanged
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Private Sub chkSeasonFanart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSeasonFanart.CheckedChanged
        RaiseEvent ModuleSettingsChanged()
    End Sub

    Private Sub chkEpisodePoster_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEpisodePoster.CheckedChanged
        RaiseEvent ModuleSettingsChanged()
    End Sub
End Class