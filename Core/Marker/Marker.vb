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
    Public Class Marker

#Region "Declare"

        Friend v_clickable As Boolean = True
        Friend v_cursor As Cursors = Cursors.auto
        Friend v_draggable As Boolean = True
        Friend v_flat As Boolean = False
        Friend WithEvents v_icon As New MarkerImage
        Friend v_inconstring As String

        ''' <summary>
        ''' TODO: Agregar el soporte para StreetViewPanorama
        ''' </summary>
        ''' <remarks></remarks>
        ''' 
        Friend v_position As New LatLng
        Friend WithEvents v_shadow As New MarkerImage With {.Url = ""}
        Friend v_shape As New MarkerShape
        Friend v_title As String
        Friend v_visible As Boolean = True
        Friend v_zIndex As Int64

        Private v_key As String
        Private v_index As Integer = 0

#End Region

#Region "Events"

        Friend Property Index As Integer
            Get
                Return v_index
            End Get
            Set(ByVal value As Integer)
                v_index = value
            End Set
        End Property

        ''' <summary>
        ''' This event is fired when the marker icon was clicked.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event Click(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when the marker's clickable property changes.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event Clickable_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when the marker's cursor property changes.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event Cursor_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when the marker icon was double clicked.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event DblClick(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MouseEventArgs)

        ''' <summary>
        ''' This event is repeatedly fired while the user drags the marker.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event Drag(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MouseEventArgs)

        ''' <summary>
        ''' This event is fired when the user stops dragging the marker.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event Dragend(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MouseEventArgs)

        ''' <summary>
        ''' This event is fired when the marker's draggable property changes.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event Draggable_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when the user starts dragging the marker.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event Dragstart(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MouseEventArgs)

        ''' <summary>
        ''' This event is fired when the marker's flat property changes.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event Flat_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when the marker icon property changes.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event Icon_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when the DOM mousedown event is fired on the marker icon.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event Mousedown(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MouseEventArgs)

        ''' <summary>
        ''' This event is fired when the mouse leaves the area of the marker icon.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event Mouseout(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MouseEventArgs)

        ''' <summary>
        ''' This event is fired when the mouse enters the area of the marker icon.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event Mouseover(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MouseEventArgs)

        ''' <summary>
        ''' This event is fired for the DOM mouseup on the marker.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event Mouseup(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MouseEventArgs)

        ''' <summary>
        ''' This event is fired when the marker position property changes.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event Position_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when the marker is right clicked on.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event RightClick(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MouseEventArgs)

        ''' <summary>
        ''' This event is fired when the marker's shadow property changes.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event Shadow_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when the marker's shape property changes.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event Shape_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when the marker title property changes.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event Title_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when the marker's visible property changes.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event Visible_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when the marker's zIndex property changes.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks></remarks>
        Public Event ZIndex_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

#End Region

#Region "Propiedades"

        ''' <summary>
        ''' If true, the marker receives mouse and touch events. Default value is true.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Clickable() As Boolean
            Get
                Return v_clickable
            End Get
            Set(ByVal value As Boolean)

                If value <> v_clickable Then

                    v_clickable = value

                    RaiseEvent Clickable_Changed(Me, New System.EventArgs)

                End If

            End Set
        End Property

        ''' <summary>
        ''' Mouse cursor to show on hover
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Cursor() As Cursors
            Get
                Return v_cursor
            End Get
            Set(ByVal value As Cursors)

                If value <> v_cursor Then
                    v_cursor = value
                    RaiseEvent Cursor_Changed(Me, New System.EventArgs)
                End If

            End Set
        End Property

        ''' <summary>
        ''' If true, the marker can be dragged. Default value is false.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Draggable() As Boolean
            Get
                Return v_draggable
            End Get
            Set(ByVal value As Boolean)
                If value <> v_draggable Then
                    v_draggable = value
                    RaiseEvent Draggable_Changed(Me, New System.EventArgs)
                End If
            End Set
        End Property

        ''' <summary>
        ''' If true, the marker shadow will not be displayed.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Flat() As Boolean
            Get
                Return v_flat
            End Get
            Set(ByVal value As Boolean)
                If value <> v_flat Then
                    v_flat = value
                    RaiseEvent Flat_Changed(Me, New System.EventArgs)
                End If
            End Set
        End Property

        ''' <summary>
        ''' MarkerImage for the foreground
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Property Icon() As MarkerImage
            Get
                Return v_icon
            End Get
            Set(ByVal value As MarkerImage)
                If value IsNot v_icon Then
                    v_icon = value
                    RaiseEvent Icon_Changed(Me, New System.EventArgs)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Marker position. Required.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Position() As LatLng
            Get
                Return v_position
            End Get
            Set(ByVal value As LatLng)
                If value IsNot v_position Then
                    v_position = value
                    RaiseEvent Position_Changed(Me, New System.EventArgs)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Shadow image
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Shadow() As MarkerImage
            Get
                Return v_shadow
            End Get
            Set(ByVal value As MarkerImage)
                If value IsNot v_shadow Then
                    v_shadow = value
                    RaiseEvent Shape_Changed(Me, New System.EventArgs)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Image map region definition used for drag/click.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Shape() As MarkerShape
            Get
                Return v_shape
            End Get
            Set(ByVal value As MarkerShape)
                If value IsNot v_shape Then
                    v_shape = value
                    RaiseEvent Shape_Changed(Me, New System.EventArgs)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Rollover text
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Title() As String
            Get
                Return v_title
            End Get
            Set(ByVal value As String)
                If value <> v_title Then
                    v_title = value
                    RaiseEvent Title_Changed(Me, New System.EventArgs)
                End If
            End Set
        End Property

        ''' <summary>
        ''' If true, the marker is visible
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Visible() As Boolean
            Get
                Return v_visible
            End Get
            Set(ByVal value As Boolean)
                If value <> v_visible Then
                    v_visible = value
                    RaiseEvent Visible_Changed(Me, New System.EventArgs)
                End If
            End Set
        End Property

        ''' <summary>
        ''' All Markers are displayed on the map in order of their zIndex, with higher values displaying in front of Markers with lower values. By default, Markers are displayed according to their latitude, with Markers of lower latitudes appearing in front of Markers at higher latitudes.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Zindex() As Int64
            Get
                Return v_zIndex
            End Get
            Set(ByVal value As Int64)
                If value <> v_zIndex Then
                    v_zIndex = value
                    RaiseEvent ZIndex_Changed(Me, New System.EventArgs)
                End If
            End Set
        End Property

#End Region

#Region "Procedimientos"

#Region "New"

        Public Sub New()
        End Sub

#End Region

#Region "Publicos"

        Public Sub SetClickable(ByVal value As Boolean)
            CallCOMFunction("setMarkerClickable", value)
        End Sub

        Public Sub SetCursor(ByVal value As Cursors)

            Dim tempvalue As String = value.ToString.Replace("_", "-")

            CallCOMFunction("setMarkerCursor", tempvalue)

        End Sub

        Public Sub SetDraggable(ByVal value As Boolean)
            CallCOMFunction("setMarkerDraggable", value)
        End Sub

        Public Sub SetFlat(ByVal value As Boolean)
            CallCOMFunction("setMarkerFlat", value)
        End Sub

        Public Sub SetIcon(ByVal value As MarkerImage)
            CallCOMFunction("SetMarkerIcon", value)
        End Sub

        Public Sub SetPosition(ByVal value As LatLng)
            CallCOMFunction("setMarkerPosition", value)
        End Sub

        Public Sub SetShadow(ByVal value As MarkerImage)
            CallCOMFunction("setMarkerShadow", value)
        End Sub

        Public Sub SetShape(ByVal value As MarkerShape)
            CallCOMFunction("setMarkerShape", value)
        End Sub

        Public Sub SetTitle(ByVal value As String)
            CallCOMFunction("setMarkerTitle", value)
        End Sub

        Public Sub SetVisible(ByVal value As Boolean)
            CallCOMFunction("setMarkerVisible", value)
        End Sub

        Public Sub SetZIndex(ByVal value As Integer)
            CallCOMFunction("setMarkerZIndex", value)
        End Sub

        Private Function CallCOMFunction(ByVal functionName As String, Optional ByVal value As Object = Nothing) As Object
            'Try

            '    Dim Params(1) As Object

            '    Params(0) = v_index
            '    Params(1) = value

            '    Return v_options.Map.Parent.Browser.Document.InvokeScript(functionName, Params)

            'Catch ex As Exception

            '    Return Nothing

            'End Try

        End Function

#End Region

#End Region

    End Class

End Namespace