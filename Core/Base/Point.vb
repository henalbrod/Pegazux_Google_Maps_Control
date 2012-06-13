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

    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    <System.Runtime.InteropServices.ComVisibleAttribute(True)> _
    Public Class Point

#Region "Declaraciones"

        Private v_x As Integer
        Private v_y As Integer

#End Region

#Region "Propiedades"

        ''' <summary>
        ''' The X coordinate
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property X() As Integer
            Get
                Return v_x
            End Get
            Set(ByVal value As Integer)
                v_x = value
            End Set
        End Property

        ''' <summary>
        ''' The Y coordinate
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Y() As Integer
            Get
                Return v_y
            End Get
            Set(ByVal value As Integer)
                v_y = value
            End Set
        End Property

#End Region

#Region "Procedimientos"

        Public Sub New()
            v_x = 0
            v_y = 0
        End Sub
        Public Sub New(ByVal X As Integer, ByVal Y As Integer)
            v_x = X
            v_y = Y
        End Sub

        ''' <summary>
        ''' Compares two Points
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shadows Function Equals(ByVal item As Point) As Boolean

            Return (Me.X = item.X And Me.Y = item.Y)

        End Function

        ''' <summary>
        ''' Returns a string representation of this Point.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shadows Function ToString() As String

            Return "(" & Me.X & "," & Me.Y & ")"

        End Function

#End Region

    End Class

End Namespace