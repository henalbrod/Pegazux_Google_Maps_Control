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
Imports System.ComponentModel
Imports System.Runtime.InteropServices

Namespace Pegazux.GoogleMaps

    ''' <summary>
    ''' Is a point in geographical coordinates, latitude and longitude.
    ''' Notice the ordering of latitude and longitude. If the noWrap flag is true, then the numbers will be used as passed, otherwise latitude will be clamped to lie between -90 degrees and +90 degrees, and longitude will be wrapped to lie between -180 degrees and +180 degrees.
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    <System.Runtime.InteropServices.ComVisibleAttribute(True)> _
    <System.ComponentModel.TypeConverter(GetType(LatLngTypeConverter))> _
    Public Class LatLng

#Region "Declaraciones"

        Private v_lat As Double
        Private v_lng As Double
        Private v_noWrap As Boolean

#End Region

#Region "Eventos"

        Public Event Change(ByVal sender As LatLng)

#End Region

#Region "Propiedades"

        ''' <summary>
        ''' Gets or sets the coordinates in the x-axis of the map.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Lat() As Double
            Get
                Return v_lat
            End Get
            Set(ByVal value As Double)

                If v_lat <> value Then

                    v_lat = value
                    RaiseEvent Change(Me)

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the coordinates in the y-axis of the map.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Lng() As Double
            Get
                Return v_lng
            End Get
            Set(ByVal value As Double)

                If v_lng <> value Then

                    v_lng = value
                    RaiseEvent Change(Me)

                End If

            End Set
        End Property

        ''' <summary>
        ''' If set to true, then the numbers have been used as input, latitude otherwise adjusted between -90 and 90 degrees, and the length will be adjusted between -180 degrees and 180 degrees.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property NoWrap() As Boolean
            Get
                Return v_noWrap
            End Get
            Set(ByVal value As Boolean)
                v_noWrap = value
            End Set
        End Property

#End Region

#Region "Procedimientos"

        Public Sub New()

            v_lat = 0
            v_lng = 0
            v_noWrap = False

        End Sub

        Public Sub New(ByVal lat As Double, ByVal Lng As Double, Optional ByVal NoWrap As Boolean = False)

            v_lat = lat
            v_lng = Lng
            v_noWrap = NoWrap

        End Sub

        ''' <summary>
        ''' Compares two LatLng.
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shadows Function Equals(ByVal item As LatLng) As Boolean

            Dim TempLatLngBounds As Object = CastToJsLatLng(Me)
            Dim args(0) As Object

            args(0) = CastToJsLatLng(item)

            Return InvokeMethod(TempLatLngBounds, "equals", args)

        End Function

        ''' <summary>
        ''' Returns a string representation of this LatLng.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shadows Function ToString() As String

            Return "(" & Me.Lat.ToString & "," & Me.Lng.ToString & ")"

        End Function

        ''' <summary>
        ''' Returns a string of the form "lat,lng" for this LatLng. We round the lat/lng values to 6 decimal places by default.
        ''' </summary>
        ''' <param name="Presision"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ToUrlValue(Optional ByVal Presision As Integer = 6) As String

            If Presision > 6 Then Presision = 6

            Return Math.Round(v_lat, Presision) & "," & Math.Round(v_lng, Presision)

        End Function

#End Region

    End Class

    Friend NotInheritable Class LatLngTypeConverter
        Inherits System.ComponentModel.TypeConverter

        Public Overrides Function GetProperties(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal value As Object, ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection
            Return System.ComponentModel.TypeDescriptor.GetProperties(GetType(Pegazux.GoogleMaps.LatLng))
        End Function

        Public Overrides Function GetPropertiesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
            Return True
        End Function

    End Class

End Namespace


