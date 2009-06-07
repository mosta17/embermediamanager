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

Public Class ListViewColumnSorter
    Implements System.Collections.IComparer

    Private ColumnToSort As Integer
    Private OrderOfSort As SortOrder
    Private ByText As Boolean
    Private IsNumeric As Boolean
    Private ObjectCompare As CaseInsensitiveComparer

    Public Sub New()
        ColumnToSort = 0
        OrderOfSort = SortOrder.None
        ObjectCompare = New CaseInsensitiveComparer()
        ByText = False
        IsNumeric = False
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Dim compareResult As Integer
        Dim listviewX As ListViewItem
        Dim listviewY As ListViewItem

        Try
            ' Cast the objects to be compared to ListViewItem objects.
            listviewX = CType(x, ListViewItem)
            listviewY = CType(y, ListViewItem)

            ' Compare the two items.
            If ByText Then
                If IsNumeric Then
                    compareResult = ObjectCompare.Compare(CInt(listviewX.Text.Trim), CInt(listviewY.Text.Trim))
                Else
                    compareResult = ObjectCompare.Compare(listviewX.Text.Trim, listviewY.Text.Trim)
                End If
            Else
                If IsNumeric Then
                    compareResult = ObjectCompare.Compare(CInt(listviewX.SubItems(ColumnToSort).Text.Trim), CInt(listviewY.SubItems(ColumnToSort).Text.Trim))
                Else
                    compareResult = ObjectCompare.Compare(listviewX.SubItems(ColumnToSort).Text.Trim, listviewY.SubItems(ColumnToSort).Text.Trim)
                End If
            End If

            ' Calculate the correct return value based on the object 
            ' comparison.
            If (OrderOfSort = SortOrder.Ascending) Then
                ' Ascending sort is selected, return typical result of 
                ' compare operation.
                Return compareResult
            ElseIf (OrderOfSort = SortOrder.Descending) Then
                ' Descending sort is selected, return negative result of 
                ' compare operation.
                Return (-compareResult)
            Else
                ' Return '0' to indicate that they are equal.
                Return 0
            End If
        Catch ex As Exception
            Master.eLog.WriteToErrorLog(ex.Message, ex.StackTrace, "Error")
            Return 0
        End Try
    End Function

    Public Property SortColumn() As Integer
        Get
            Return ColumnToSort
        End Get
        Set(ByVal value As Integer)
            ColumnToSort = value
        End Set
    End Property

    Public Property Order() As SortOrder
        Get
            Return OrderOfSort
        End Get
        Set(ByVal value As SortOrder)
            OrderOfSort = value
        End Set
    End Property

    Public Property SortByText() As Boolean
        Get
            Return ByText
        End Get
        Set(ByVal value As Boolean)
            ByText = value
        End Set
    End Property

    Public Property NumericSort() As Boolean
        Get
            Return IsNumeric
        End Get
        Set(ByVal value As Boolean)
            IsNumeric = value
        End Set
    End Property
End Class
