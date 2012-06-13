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
    ''' A LatLngBounds instance represents a rectangle in geographical coordinates, 
    ''' including one that crosses the 180 degrees longitudinal meridian.
    ''' </summary>
    ''' <remarks></remarks>
    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    <System.Runtime.InteropServices.ComVisibleAttribute(True)> _
    <System.ComponentModel.TypeConverter(GetType(LatLngBoundsTypeConverter))> _
    Public Class LatLngBounds

#Region "Declaraciones"

        Private v_sw As New LatLng
        Private v_ne As New LatLng

#End Region

#Region "Eventos"

        Friend Event Changed(ByVal sender As LatLngBounds)

#End Region

#Region "Propiedades"

        ''' <summary>
        ''' Gets or sets the south-west corner.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SouthWest() As LatLng
            Get
                Return v_sw
            End Get
            Set(ByVal value As LatLng)

                If v_sw.Equals(value) = False Then

                    v_sw = value
                    RaiseEvent Changed(Me)

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the north-eastern corner.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property NorthEast() As LatLng
            Get
                Return v_ne
            End Get
            Set(ByVal value As LatLng)

                If v_ne.Equals(value) = False Then

                    v_ne = value
                    RaiseEvent Changed(Me)

                End If

            End Set
        End Property

#End Region

#Region "Procedimientos"

        ''' <summary>
        ''' Constructs a rectangle from the points at its south-west and north-east corners.
        ''' </summary>
        ''' <param name="sw"></param>
        ''' <param name="ne"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal sw As LatLng, ByVal ne As LatLng)

            v_ne = ne
            v_sw = sw

        End Sub

        ''' <summary>
        ''' Constructs a rectangle from the points at its south-west and north-east corners.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()

        End Sub

        ''' <summary>
        ''' Returns true if the given lat/lng is in this bounds.
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Contains(ByVal value As LatLng) As Boolean

            Dim TempLatLngBounds As Object = CatsToJsLngBounds(Me)
            Dim args(0) As Object

            args(0) = CastToJsLatLng(value)

            Return InvokeMethod(TempLatLngBounds, "contains", args)

        End Function

        ''' <summary>
        ''' Returns true if this bounds equals the given bounds.
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shadows Function Equals(ByVal value As LatLngBounds) As Boolean

            Dim TempLatLngBounds As Object = CatsToJsLngBounds(Me)
            Dim args(0) As Object

            args(0) = CatsToJsLngBounds(value)

            Return InvokeMethod(TempLatLngBounds, "equals", args)

        End Function

        ''' <summary>
        ''' Extends this bounds to contain the given point.
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Extend(ByVal value As LatLng) As LatLngBounds

            Dim TempLatLngBounds As Object = CatsToJsLngBounds(Me)
            Dim args(0) As Object

            args(0) = CastToJsLatLng(value)

            InvokeMethod(TempLatLngBounds, "extend", args)

            RaiseEvent Changed(Me)

            Return Me

        End Function

        ''' <summary>
        ''' Computes the center of this LatLngBounds
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCenter() As LatLng

            Dim TempLatLngBounds As Object = CatsToJsLngBounds(Me)

            Return CastToLatLng(InvokeMethod(TempLatLngBounds, "getCenter"))

        End Function

        ''' <summary>
        ''' Returns the north-east corner of this bounds.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetNorthEast() As LatLng

            Dim TempLatLngBounds As Object = CatsToJsLngBounds(Me)

            Return CastToLatLng(InvokeMethod(TempLatLngBounds, "getNorthEast"))

        End Function

        ''' <summary>
        ''' Returns the south-west corner of this bounds.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSouthWest() As LatLng

            Dim TempLatLngBounds As Object = CatsToJsLngBounds(Me)

            Return CastToLatLng(InvokeMethod(TempLatLngBounds, "getSouthWest"))

        End Function

        ''' <summary>
        ''' Returns true if this bounds shares any points with this bounds.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Intersects(ByVal value As LatLngBounds) As Boolean

            Dim TempLatLngBounds As Object = CatsToJsLngBounds(Me)
            Dim args(0) As Object

            args(0) = CatsToJsLngBounds(value)

            Return InvokeMethod(TempLatLngBounds, "intersects", args)

        End Function

        ''' <summary>
        ''' Returns if the bounds are empty.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsEmpty() As Boolean

            Dim TempLatLngBounds As Object = CatsToJsLngBounds(Me)

            Return InvokeMethod(TempLatLngBounds, "isEmpty")

        End Function

        ''' <summary>
        ''' Converts the given map bounds to a lat/lng span.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ToSpan() As LatLng

            Dim TempLatLngBounds As Object = CatsToJsLngBounds(Me)

            Return CastToLatLng(InvokeMethod(TempLatLngBounds, "toSpan"))

        End Function

        ''' <summary>
        ''' Converts to string.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shadows Function ToString() As String

            Dim TempLatLngBounds As Object = CatsToJsLngBounds(Me)

            Return InvokeMethod(TempLatLngBounds, "toString")

        End Function

        ''' <summary>
        ''' Returns a string of the form "lat_lo,lng_lo,lat_hi,lng_hi" for this bounds, where "lo" corresponds to the southwest corner of the bounding box, while "hi" corresponds to the northeast corner of that box.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shadows Function ToUrlValue() As String

            Dim TempLatLngBounds As Object = CatsToJsLngBounds(Me)

            Return InvokeMethod(TempLatLngBounds, "toUrlValue")

        End Function

        ''' <summary>
        ''' Extends this bounds to contain the given point.
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Union(ByVal value As LatLng) As LatLngBounds

            Dim TempLatLngBounds As Object = CatsToJsLngBounds(Me)
            Dim args(0) As Object

            args(0) = CastToJsLatLng(value)

            InvokeMethod(TempLatLngBounds, "union", args)

            RaiseEvent Changed(Me)

            Return Me

        End Function

#End Region

    End Class

    Friend NotInheritable Class LatLngBoundsTypeConverter
        Inherits System.ComponentModel.TypeConverter

        Public Overrides Function GetProperties(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal value As Object, ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection
            Return System.ComponentModel.TypeDescriptor.GetProperties(GetType(Pegazux.GoogleMaps.LatLngBounds))
        End Function

        Public Overrides Function GetPropertiesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
            Return True
        End Function

    End Class

End Namespace


