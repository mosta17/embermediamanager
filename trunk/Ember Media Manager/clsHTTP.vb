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
Imports System.IO.Compression

Public Class HTTP

    Dim _response As String
    Dim _responseuri As String

    Public Property Response() As String
        Get
            Return Me._response
        End Get
        Set(ByVal value As String)
            Me._response = value
        End Set
    End Property

    Public Property ResponseUri() As String
        Get
            Return Me._responseuri
        End Get
        Set(ByVal value As String)
            Me._responseuri = value
        End Set
    End Property

    Public Sub New(ByVal URL As String)
        Me.Clear()

        Me.DownloadData(URL)
    End Sub

    Public Sub Clear()
        Me._response = String.Empty
        Me._responseuri = String.Empty
    End Sub

    Private Sub DownloadData(ByVal URL As String)
        Try
            Dim wrRequest As HttpWebRequest = HttpWebRequest.Create(URL)
            wrRequest.Timeout = 10000
            wrRequest.Headers.Add("Accept-Encoding", "gzip,deflate")
            Dim wrResponse As HttpWebResponse = wrRequest.GetResponse()
            Dim contentEncoding As String = String.Empty
            For Each resKey As String In wrResponse.Headers.Keys
                If Not IsNothing(resKey) Then
                    If resKey.ToLower = "content-encoding" Then
                        contentEncoding = wrResponse.Headers.Item(resKey)
                        Exit For
                    End If
                End If
            Next
            Using Ms As Stream = wrResponse.GetResponseStream
                If contentEncoding.ToLower = "gzip" Then
                    Me._response = New StreamReader(New GZipStream(Ms, CompressionMode.Decompress)).ReadToEnd
                ElseIf contentEncoding.ToLower = "deflate" Then
                    Me._response = New StreamReader(New DeflateStream(Ms, CompressionMode.Decompress)).ReadToEnd
                Else
                    Me._response = New StreamReader(Ms).ReadToEnd
                End If
            End Using
            Me._responseuri = wrResponse.ResponseUri.ToString
            wrResponse.Close()
            wrResponse = Nothing
            wrRequest = Nothing
        Catch
        End Try

    End Sub
End Class
