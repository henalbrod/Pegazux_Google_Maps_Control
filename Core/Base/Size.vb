' Pegazux.GoogleMaps Library 0.0.0.1
' http://pegazux.blogspot.com
'
' Copyright 2011, Henry Alberto Rodriguez
' Licensed under the GPL Version 3 license.
' http://www.gnu.org/licenses/gpl-3.0.txt


' Includes jQuery.js'
' jQuery JavaScript Library v1.5.2
' http://jquery.com/
'
' Copyright 2011, John Resig
' Dual licensed under the MIT or GPL Version 2 licenses.
' http://jquery.org/license


' Icludes markerclusterer.js
' MarkerClustererPlus for Google Maps V3
' http://code.google.com/p/google-maps-utility-library-v3/
'
' Copyright 2011, Gary Little
' Licensed under the Apache License, Version 2.0.
' http://www.apache.org/licenses/LICENSE-2.0

' Date: Sund Dec 25 14:06:23 2011

' This file is part of Pegazux.GoogleMaps.

' Pegazux.GoogleMaps is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.

' Pegazux.GoogleMaps is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.

' You should have received a copy of the GNU General Public License
' along with Foobar.  If not, see <http://www.gnu.org/licenses/>.

Imports System.Security.Permissions

Namespace Pegazux.GoogleMaps

    ''' <summary>
    ''' Two-dimensonal size, where width is the distance on the x-axis, and height is the distance on the y-axis.
    ''' </summary>
    ''' <remarks></remarks>
    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    <System.Runtime.InteropServices.ComVisibleAttribute(True)> _
    Public Class Size

#Region "Declaraciones"

        Private v_width As Integer
        Private v_height As Integer
        Private v_widthUnit As String
        Private v_heightUnit As String

#End Region

#Region "Propiedades"

        ''' <summary>
        ''' The width along the x-axis, in pixels.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Width() As Integer
            Get
                Return v_width
            End Get
            Set(ByVal value As Integer)
                v_width = value
            End Set
        End Property

        ''' <summary>
        ''' The height along the y-axis, in pixels.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Height() As Integer
            Get
                Return v_height
            End Get
            Set(ByVal value As Integer)
                v_height = value
            End Set
        End Property

        Public ReadOnly Property WidthUnit() As String
            Get
                Return v_widthUnit
            End Get
        End Property

        Public ReadOnly Property HeightUnit() As String
            Get
                Return v_heightUnit
            End Get
        End Property

#End Region

#Region "Procedimientos"

        Public Sub New()
            v_width = 0
            v_height = 0
        End Sub

        Public Sub New(ByVal width As Integer, ByVal Height As Integer)
            v_width = width
            v_height = Height
        End Sub

        Public Sub New(ByVal width As Integer, ByVal height As Integer, ByVal widthUnit As String, ByVal heightUnit As Integer)
            v_width = width
            v_height = height
            v_widthUnit = widthUnit
            v_heightUnit = heightUnit
        End Sub

        ''' <summary>
        ''' Compares two Sizes.
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shadows Function Equals(ByVal item As Size) As Boolean

            Return Me.GetHashCode = item.GetHashCode

        End Function

        ''' <summary>
        ''' Returns a string representation of this Size.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shadows Function ToString() As String

            Return "(" & Me.Height & "," & Me.Width & ")"

        End Function

#End Region

    End Class

End Namespace