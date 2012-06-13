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
    ''' Defines an image to be used as the icon or shadow for a Marker. 
    ''' 'origin' and 'size' are used to select a segment of a sprite image 
    ''' and 'anchor' overrides the position of the anchor point from its default 
    ''' bottom middle position. 
    ''' The anchor of an image is the pixel to which the system refers 
    ''' in tracking the image's position. By default, the anchor is set to the 
    ''' bottom middle of the image (coordinates width/2, height). 
    ''' So when a marker is placed at a given LatLng, 
    ''' the pixel defined as the anchor is positioned 
    ''' at the specified LatLng. 
    ''' To scale the image, whether sprited or not, 
    ''' set the value of scaledSize to the size of the whole image and set size, 
    ''' origin and anchor in scaled values. 
    ''' The MarkerImage cannot be changed once constructed.
    ''' </summary>
    ''' <remarks></remarks>
    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    <System.Runtime.InteropServices.ComVisibleAttribute(True)> _
    Public Class MarkerImage

#Region "Declaraciones"

        Private v_url As String = ""
        Private v_size As Size
        Private v_origin As Point
        Private v_anchor As Point
        Private v_scaledsize As Size

#End Region

#Region "Eventos"

        Friend Event UrlChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Friend Event SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Friend Event OriginChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Friend Event AnchorChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Friend Event ScaledSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs)

#End Region

#Region "Propiedades"

        Public Property Url() As String
            Get
                Return v_url
            End Get
            Set(ByVal value As String)
                If value <> v_url Then
                    v_url = value
                    RaiseEvent UrlChanged(Me, New System.EventArgs)
                End If
            End Set
        End Property

        Public Property Size() As Size
            Get
                Return v_size
            End Get
            Set(ByVal value As Size)

                If Not value Is v_size Then
                    v_size = value
                    RaiseEvent SizeChanged(Me, New System.EventArgs)
                End If

                Try
                    If ScaledSize.Height < Size.Height Then
                        ScaledSize.Height = Size.Height()
                    End If

                    If ScaledSize.Width < Size.Width Then
                        ScaledSize.Width = Size.Width()
                    End If
                Catch ex As Exception
                End Try

            End Set
        End Property

        Public Property Origin() As Point
            Get
                Return v_origin
            End Get
            Set(ByVal value As Point)
                If Not value Is v_origin Then
                    v_origin = value
                    RaiseEvent OriginChanged(Me, New System.EventArgs)
                End If
            End Set
        End Property

        Public Property Anchor() As Point
            Get
                Return v_anchor
            End Get
            Set(ByVal value As Point)
                If Anchor IsNot value Then
                    v_anchor = value
                    RaiseEvent AnchorChanged(Me, New System.EventArgs)
                End If
            End Set
        End Property

        Public Property ScaledSize() As Size
            Get
                Return v_scaledsize
            End Get
            Set(ByVal value As Size)
                If value IsNot v_size Then
                    v_scaledsize = value
                    RaiseEvent SizeChanged(Me, New System.EventArgs)
                End If
            End Set
        End Property

#End Region

    End Class

End Namespace

