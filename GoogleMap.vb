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

Imports System.Drawing
Imports System.Security.Permissions
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace Pegazux.GoogleMaps

    Public Class GoogleMap

#Region "Declare"

        Private WithEvents v_com As New System.Runtime.InteropServices.ComBridge()

        Private WithEvents t_marker As Marker

        Private v_mapLoaded As Boolean
        Private v_markers As New Pegazux.GoogleMaps.MarkerCollection
        Private v_showControls As Boolean
        Private v_backgroundColor As Color
        Private WithEvents v_center As New Pegazux.GoogleMaps.LatLng
        Private v_disableDefaultUI As Boolean
        Private v_disableDoubleClickZoom As Boolean
        Private v_draggable As Boolean = True
        Private v_draggableCursor As Cursors = Cursors.auto
        Private v_draggingCursor As Cursors = Cursors.auto
        Private v_keyboardShortcuts As Boolean = True
        Private v_mapTypeControl As Boolean = True
        Private WithEvents v_mapTypeControlOptions As New MapTypeControlOptions
        Private v_mapTypeId As Pegazux.GoogleMaps.MapTypeId
        Private v_navigationControl As Boolean = True
        Private WithEvents v_navigationControlOptions As New NavigationControlOptions
        Private v_noClear As Boolean
        Private v_scaleControl As Boolean = True
        Private WithEvents v_scaleControlOptions As New ScaleControlOptions
        Private v_scrollwheel As Boolean = True
        Private v_streetViewControl As Boolean = True
        Private v_zoom As Integer

        Private v_useMarkerClusterer As Boolean = False

        Private v_bounds As New LatLngBounds

        'TODO: Implementar Map Panes
        'TODO: Implementar MapCanvasProjection 

#End Region

#Region "Event"

        ''' <summary>
        ''' This event is fired when the map's load have being finalized.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Shadows Event MapLoaded(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when a marker is added to the map.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event MarkerAdded(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MarkerEventArgs)

        ''' <summary>
        ''' This event is fired when the viewport bounds have changed.
        ''' </summary>
        ''' <remarks></remarks>
        ''' 
        Public Event Bounds_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when the map center property changes.
        ''' </summary>
        ''' <remarks></remarks>
        Public Event Center_changed(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MapEventArgs)

        ''' <summary>
        ''' This event is fired when the user clicks on the map (but not when they click on a marker or infowindow).
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Shadows Event Click(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MouseEventArgs)

        ''' <summary>
        ''' This event is fired when the user double-clicks on the map. Note that the click event will also fire, right before this one.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event Dblclick(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MouseEventArgs)

        ''' <summary>
        ''' This event is repeatedly fired while the user drags the map
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event Drag(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when the user stops dragging the map.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event DragEnd(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when the user starts dragging the map.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event DragStart(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when the map becomes idle after panning or zooming.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event Idle(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when the mapTypeId property changes.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event MapTypeId_Changed(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MapEventArgs)

        ''' <summary>
        ''' This event is fired whenever the user's mouse moves over the map container.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Shadows Event Mousemove(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MouseEventArgs)

        ''' <summary>
        ''' This event is fired when the user's mouse exits the map container.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event Mouseout(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MouseEventArgs)

        ''' <summary>
        ''' This event is fired when the user's mouse enters the map container.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event Mouseover(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MouseEventArgs)

        ''' <summary>
        ''' This event is fired when the projection changes
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Shadows Event Projection_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when the div changes size
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Shadows Event Resize(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when the DOM contextmenu event is fired on the map container.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event RightClick(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MouseEventArgs)

        ''' <summary>
        ''' This event is fired when the visible tiles have finished loading.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event TilesLoaded(ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' This event is fired when the map zoom property changes.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event Zoom_Changed(ByVal sender As Object, ByVal e As System.EventArgs)


#End Region

#Region "Property"

        ''' <summary>
        ''' Get or set the map's markers.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Markers As Pegazux.GoogleMaps.MarkerCollection
            Get
                Return v_markers
            End Get
            Set(ByVal value As Pegazux.GoogleMaps.MarkerCollection)
                v_markers = value
            End Set
        End Property

        Public Property UseMarkerClusterer As Boolean
            Get
                Return v_useMarkerClusterer
            End Get
            Set(ByVal value As Boolean)

                If value <> v_useMarkerClusterer Then

                    v_useMarkerClusterer = value

                    v_com.SetUsingClusterer(value)

                End If

            End Set
        End Property

        Public Shadows Property BackGroundColor As Color
            Get
                Return v_backgroundColor
            End Get
            Set(ByVal value As Color)
                v_backgroundColor = value
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public Property Center() As Pegazux.GoogleMaps.LatLng
            Get
                Return v_center
            End Get
            Set(ByVal value As Pegazux.GoogleMaps.LatLng)
                SetCenter(value)
            End Set
        End Property

        Public Property DisableDefaultUI As Boolean
            Get
                Return v_disableDefaultUI
            End Get
            Set(ByVal value As Boolean)
                SetDisableDefaultUI(value)
            End Set
        End Property

        Public Property DisableDoubleClickZoom As Boolean
            Get
                Return v_disableDoubleClickZoom
            End Get
            Set(ByVal value As Boolean)
                SetDisableDoubleClickZoom(value)
            End Set
        End Property

        Public Property ShowControls As Boolean
            Get
                Return v_showControls
            End Get
            Set(ByVal value As Boolean)
                SetShowControls(value)
            End Set
        End Property

        Public Property MapTypeId As Pegazux.GoogleMaps.MapTypeId
            Get
                Return v_mapTypeId
            End Get
            Set(ByVal value As Pegazux.GoogleMaps.MapTypeId)
                SetMapTypeId(value)
            End Set
        End Property

        Public Property MapTypeControl As Boolean
            Get
                Return v_mapTypeControl
            End Get
            Set(ByVal value As Boolean)
                SetMapTypeControl(value)
            End Set
        End Property

        Public Property MapTypeControlOptions As MapTypeControlOptions
            Get
                Return v_mapTypeControlOptions
            End Get
            Set(ByVal value As MapTypeControlOptions)
                SetMapTypeControlOptions(value)
            End Set
        End Property

        Public Property Draggable As Boolean
            Get
                Return v_draggable
            End Get
            Set(ByVal value As Boolean)
                SetDraggable(value)
            End Set
        End Property

        Public Property DraggableCursor As Cursors
            Get
                Return v_draggableCursor
            End Get
            Set(ByVal value As Cursors)
                SetDraggableCursor(value)
            End Set
        End Property

        Public Property DraggingCursor As Cursors
            Get
                Return v_draggingCursor
            End Get
            Set(ByVal value As Cursors)
                SetDraggingCursor(value)
            End Set
        End Property

        Public Property KeyboardShortcuts As Boolean
            Get
                Return v_keyboardShortcuts
            End Get
            Set(ByVal value As Boolean)
                SetKeyboardShortcuts(value)
            End Set
        End Property

        Public Property NavigationControl As Boolean
            Get
                Return v_navigationControl
            End Get
            Set(ByVal value As Boolean)
                SetNavigationControl(value)
            End Set
        End Property

        Public Property NavigationControlOptions As NavigationControlOptions
            Get
                Return v_navigationControlOptions
            End Get
            Set(ByVal value As NavigationControlOptions)
                SetNavigationControlOptions(value)
            End Set
        End Property

        Public Property NoClear As Boolean
            Get
                Return v_noClear
            End Get
            Set(ByVal value As Boolean)
                SetNoClear(value)
            End Set
        End Property

        Public Shadows Property ScaleControl As Boolean
            Get
                Return v_scaleControl
            End Get
            Set(ByVal value As Boolean)
                SetScaleControl(value)
            End Set
        End Property

        Public Property ScaleControlOptions As ScaleControlOptions
            Get
                Return v_scaleControlOptions
            End Get
            Set(ByVal value As ScaleControlOptions)
                SetScaleControlOptions(value)
            End Set
        End Property

        Public Shadows Property Scrollwheel As Boolean
            Get
                Return v_scrollwheel
            End Get
            Set(ByVal value As Boolean)
                SetScrollwheel(value)
            End Set
        End Property

        Public Shadows Property StreetViewControl As Boolean
            Get
                Return v_streetViewControl
            End Get
            Set(ByVal value As Boolean)
                SetStreetViewControl(value)
            End Set
        End Property

        Public Shadows ReadOnly Property Bounds As LatLngBounds
            Get
                Return v_bounds
            End Get
        End Property


        ''' <summary>
        ''' Get or set the map's zoom level.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Zoom As Integer
            Get

                Return v_zoom

            End Get
            Set(ByVal value As Integer)
                SetZoom(value)
            End Set
        End Property

#End Region

#Region "Procedure"

#Region "Private"

        Private Sub GoogleMap_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            gv_pages.Add(Me.page)

            Me.page.ObjectForScripting = v_com

            Dim t_pageText As String = My.Resources.page

            t_pageText = t_pageText.Replace("//<|JQUERY|>", My.Resources.jQuery)

            t_pageText = t_pageText.Replace("//<|CLUSTERER|>", My.Resources.markerclusterer)

            t_pageText = t_pageText.Replace("//<|MAP|>", My.Resources.map)
            t_pageText = t_pageText.Replace("<|BACK_COLOR|>", String.Format("#{0:X2}{1:X2}{2:X2}", v_backgroundColor.R, v_backgroundColor.G, v_backgroundColor.B))

            t_pageText = t_pageText.Replace("//<|MARKERS|>", My.Resources.markers.Replace("//<|USECLUSTERER|>", v_useMarkerClusterer))

            t_pageText = t_pageText.Replace("//<|FUNCTIONS|>", My.Resources.functions)

            Me.page.DocumentText = t_pageText

        End Sub

        Private Sub Initialize()

            v_com.Page = Me.page

            SetShowControls(v_showControls)
            SetMapTypeId(v_mapTypeId)
            SetMapTypeControl(v_mapTypeControl)
            SetMapTypeControlOptions(v_mapTypeControlOptions)
            SetDisableDoubleClickZoom(v_disableDoubleClickZoom)
            SetDisableDefaultUI(v_disableDefaultUI)
            SetDraggable(v_draggable)
            SetDraggableCursor(v_draggableCursor)
            SetDraggingCursor(v_draggingCursor)
            SetCenter(v_center)
            SetKeyboardShortcuts(v_keyboardShortcuts)
            SetNavigationControlOptions(v_navigationControlOptions)
            SetNoClear(v_noClear)
            SetScaleControl(v_scaleControl)
            SetScaleControlOptions(v_scaleControlOptions)
            SetScrollwheel(v_scrollwheel)
            SetStreetViewControl(v_streetViewControl)
            SetZoom(v_zoom)

        End Sub

        Private Sub SetShowControls(ByVal value As Boolean)
            Try

                v_showControls = value

                If v_mapLoaded = True Then
                    v_com.SetShowControls(v_showControls)
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub SetMapTypeId(ByVal value As Pegazux.GoogleMaps.MapTypeId)
            Try

                v_mapTypeId = value

                If v_mapLoaded = True Then
                    v_com.SetMapTypeId(v_mapTypeId)
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub SetMapTypeControl(ByVal value As Boolean)
            Try

                v_mapTypeControl = value

                If v_mapLoaded = True Then
                    v_com.SetMapTypeControl(v_mapTypeControl)
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub SetMapTypeControlOptions(ByVal value As MapTypeControlOptions)
            Try

                v_mapTypeControlOptions = value

                If v_mapLoaded = True Then
                    v_com.SetMapTypeControlOptions(v_mapTypeControlOptions, v_mapTypeControlOptions.MapTypeIds.Count)
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub SetDisableDoubleClickZoom(ByVal value As Boolean)
            Try

                v_disableDoubleClickZoom = value

                If v_mapLoaded = True Then
                    v_com.SetDisableDefaultUI(v_disableDoubleClickZoom)
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub SetDisableDefaultUI(ByVal value As Boolean)
            Try

                v_disableDefaultUI = value

                If v_mapLoaded = True Then
                    v_com.SetDisableDefaultUI(v_disableDefaultUI)
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub SetDraggable(ByVal value As Boolean)
            Try

                v_draggable = value

                If v_mapLoaded = True Then
                    v_com.SetDraggable(v_draggable)
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub SetDraggableCursor(ByVal value As Cursors)
            Try

                v_draggableCursor = value

                If v_mapLoaded = True Then
                    v_com.SetDraggableCursor(v_draggableCursor.ToString)
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub SetDraggingCursor(ByVal value As Cursors)
            Try

                v_draggingCursor = value

                If v_mapLoaded = True Then
                    v_com.SetDraggingCursor(v_draggingCursor.ToString)
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub SetKeyboardShortcuts(ByVal value As Boolean)
            Try

                v_keyboardShortcuts = value

                If v_mapLoaded = True Then
                    v_com.SetKeyboardShortcuts(v_keyboardShortcuts)
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub SetNavigationControl(ByVal value As Boolean)
            Try

                v_navigationControl = value

                If v_mapLoaded = True Then
                    v_com.SetNavigationControl(v_navigationControl)
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub SetNavigationControlOptions(ByVal value As NavigationControlOptions)
            Try

                v_navigationControlOptions = value

                If v_mapLoaded = True Then
                    v_com.SetNavigationControlOptions(v_navigationControlOptions)
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub SetNoClear(ByVal value As Boolean)
            Try

                v_noClear = value

                If v_mapLoaded = True Then
                    v_com.SetNoClear(v_noClear)
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub SetScaleControl(ByVal value As Boolean)
            Try

                v_scaleControl = value

                If v_mapLoaded = True Then
                    v_com.SetScaleControl(v_scaleControl)
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub SetScaleControlOptions(ByVal value As ScaleControlOptions)
            Try

                v_scaleControlOptions = value

                If v_mapLoaded = True Then
                    v_com.SetScaleControlOptions(v_scaleControlOptions)
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub SetScrollwheel(ByVal value As Boolean)
            Try

                v_scrollwheel = value

                If v_mapLoaded = True Then
                    v_com.SetScrollwheel(v_scrollwheel)
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub SetStreetViewControl(ByVal value As Boolean)
            Try

                v_streetViewControl = value

                If v_mapLoaded = True Then
                    v_com.SetStreetViewControl(v_streetViewControl)
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub SetCenter(ByVal value As Pegazux.GoogleMaps.LatLng)

            Try

                v_center = value

                If v_mapLoaded = True Then
                    v_com.SetCenter(v_center)
                End If

            Catch ex As Exception
            End Try

        End Sub

        Private Sub SetZoom(ByVal value As Integer)
            Try

                v_zoom = value

                If v_mapLoaded = True Then
                    v_com.SetZoom(v_zoom)
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub SetMapBounds(ByVal value As LatLngBounds)
            Try

                v_bounds = value

                If v_mapLoaded = True Then
                    v_com.SetBounds(v_bounds)
                End If

            Catch ex As Exception
            End Try
        End Sub

#End Region

#Region "Properties Event Handlres"

        Private Sub v_center_Change(ByVal sender As LatLng) Handles v_center.Change

            SetCenter(sender)

        End Sub

        Private Sub v_mapTypeControlOptions_PropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles v_mapTypeControlOptions.PropertyChanged
            SetMapTypeControlOptions(v_mapTypeControlOptions)
        End Sub

        Private Sub v_navigationControlOptions_PropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles v_navigationControlOptions.PropertyChanged
            SetNavigationControlOptions(v_navigationControlOptions)
        End Sub

        Private Sub v_scaleControlOptions_PropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles v_scaleControlOptions.PropertyChanged
            SetScaleControlOptions(v_scaleControlOptions)
        End Sub

#End Region

#Region "Com Event Handler"

        Private Sub com_Ready(ByVal sender As Object, ByVal e As System.EventArgs) Handles v_com.Ready
            v_mapLoaded = True
            Initialize()
            RaiseEvent MapLoaded(Me, New System.EventArgs)
        End Sub

        Private Sub com_Bounds_Changed(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MapEventArgs) Handles v_com.Bounds_Changed

            If v_mapLoaded = True Then
                v_bounds = e.Value
                RaiseEvent Bounds_Changed(Me, e)
            End If

        End Sub

        Private Sub com_Center_changed(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MapEventArgs) Handles v_com.Center_changed
            v_center = e.Value
            If v_mapLoaded = True Then
                RaiseEvent Center_changed(Me, e)
            End If
        End Sub

        Private Sub com_Click(ByVal sender As Object, ByVal e As MouseEventArgs) Handles v_com.Click
            If v_mapLoaded = True Then
                RaiseEvent Click(Me, e)
            End If
        End Sub

        Private Sub com_Dblclick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles v_com.Dblclick
            If v_mapLoaded = True Then
                RaiseEvent Dblclick(Me, e)
            End If
        End Sub

        Private Sub com_Drag(ByVal sender As Object, ByVal e As System.EventArgs) Handles v_com.Drag
            If v_mapLoaded = True Then
                RaiseEvent Drag(Me, e)
            End If
        End Sub

        Private Sub com_DragEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles v_com.DragEnd
            If v_mapLoaded = True Then
                RaiseEvent DragEnd(Me, e)
            End If
        End Sub

        Private Sub com_DragStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles v_com.DragStart
            If v_mapLoaded = True Then
                RaiseEvent DragStart(Me, e)
            End If
        End Sub

        Private Sub com_Idle(ByVal sender As Object, ByVal e As System.EventArgs) Handles v_com.Idle
            If v_mapLoaded = True Then
                RaiseEvent Idle(Me, e)
            End If
        End Sub

        Private Sub com_MapTypeId_Changed(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MapEventArgs) Handles v_com.MapTypeId_Changed
            v_mapTypeId = e.Value
            If v_mapLoaded = True Then
                RaiseEvent MapTypeId_Changed(Me, e)
            End If
        End Sub

        Private Sub com_MarkerAdded(ByVal sender As Object, ByVal e As MarkerEventArgs) Handles v_com.MarkerAdded
            RaiseEvent MarkerAdded(Me, e)
        End Sub

        Private Sub com_Mousemove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles v_com.Mousemove
            If v_mapLoaded = True Then
                RaiseEvent Mousemove(Me, e)
            End If
        End Sub

        Private Sub com_Mouseout(ByVal sender As Object, ByVal e As MouseEventArgs) Handles v_com.Mouseout
            If v_mapLoaded = True Then
                RaiseEvent Mouseout(Me, e)
            End If
        End Sub

        Private Sub com_Mouseover(ByVal sender As Object, ByVal e As MouseEventArgs) Handles v_com.Mouseover
            If v_mapLoaded = True Then
                RaiseEvent Mouseover(Me, e)
            End If
        End Sub

        Private Sub com_Projection_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles v_com.Projection_Changed
            If v_mapLoaded = True Then
                RaiseEvent Projection_Changed(Me, e)
            End If
        End Sub

        Private Sub com_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles v_com.Resize
            If v_mapLoaded = True Then
                RaiseEvent Resize(Me, e)
            End If
        End Sub

        Private Sub com_RightClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles v_com.RightClick
            If v_mapLoaded = True Then
                RaiseEvent RightClick(Me, e)
            End If
        End Sub

        Private Sub com_TilesLoaded(ByVal sender As Object, ByVal e As System.EventArgs) Handles v_com.TilesLoaded
            If v_mapLoaded = True Then
                RaiseEvent TilesLoaded(Me, e)
            End If
        End Sub

        Private Sub com_Zoom_Changed(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MapEventArgs) Handles v_com.Zoom_Changed
            v_zoom = e.Value

            If v_mapLoaded = True Then
                RaiseEvent Zoom_Changed(Me, New System.EventArgs)
            End If

        End Sub

#End Region

#Region "Print"

        ''' <summary>
        ''' Shows print preview dialoge box
        ''' </summary>
        ''' <param name="scale">Set the map's view scale.</param>
        ''' <remarks></remarks>
        Public Sub ShowPrintPreview(Optional ByVal scale As Integer = 100)

            Dim t_printPreview As New frmPrintPreview

            t_printPreview.ParentHandle = Me.ParentForm.Handle
            t_printPreview.ParentArea = Me.ParentForm.ClientRectangle
            t_printPreview.MapArea = New System.Drawing.Rectangle(Me.Location, Me.Size)

            t_printPreview.preView.Document = t_printPreview.GetDocument()

            t_printPreview.ShowDialog(Me.ParentForm)

            t_printPreview.Dispose()

        End Sub

        ''' <summary>
        ''' Prints current map's view direct to the printer.
        ''' </summary>
        ''' <param name="scale">Set the map's view scale.</param>
        ''' <remarks></remarks>
        Public Sub Print(Optional ByVal scale As Integer = 100)

            Dim t_print As New Print

            t_print.Print(Me.ParentForm.Handle, New System.Drawing.Rectangle(Me.Location, Me.Size), Me.ParentForm.ClientRectangle, scale)

            t_print.Dispose()

        End Sub

        ''' <summary>
        ''' Gets a PrintDocument object with the value to be printed.
        ''' </summary>
        ''' <param name="scale">Set the map's view scale.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPrintDocument(Optional ByVal scale As Integer = 100) As Printing.PrintDocument

            Dim t_print As New Print
            Dim t_printDocument As Printing.PrintDocument = t_print.GetPrintDocument(Me.ParentForm.Handle, New System.Drawing.Rectangle(Me.Location, Me.Size), Me.ParentForm.ClientRectangle, scale)

            t_print.Dispose()

            Return t_printDocument

        End Function

        ''' <summary>
        ''' Gets a Bitmap object from the current map's view.
        ''' </summary>
        ''' <param name="scale">Set the map's view scale.</param>
        ''' <returns>Bitmap</returns>
        ''' <remarks></remarks>
        Public Function GetBitMap(Optional ByVal scale As Integer = 100) As Bitmap

            Dim t_print As New Print
            Dim t_bitmap As Bitmap = t_print.GetBitMap(Me.ParentForm.Handle, New System.Drawing.Rectangle(Me.Location, Me.Size), Me.ParentForm.ClientRectangle, scale)

            t_print.Dispose()

            Return t_bitmap

        End Function

#End Region

#Region "Public"

#Region "Moves"

        ''' <summary>
        ''' Move the map to the north
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub MoveUp()

            v_com.PanBy(0, -100)

        End Sub

        ''' <summary>
        ''' Move the map to the south
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub MoveDown()

            v_com.PanBy(0, 100)

        End Sub

        ''' <summary>
        ''' Move the map to the west
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub MoveLeft()

            v_com.PanBy(-100, 0)

        End Sub

        ''' <summary>
        ''' Move the map to the east
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub MoveRight()

            v_com.PanBy(100, 0)

        End Sub

        Public Sub panBy(ByVal x As Double, ByVal y As Double)
            v_com.PanBy(x, y)
        End Sub

        Public Sub PanTo(ByVal value As LatLng)
            v_com.PanTo(value)
        End Sub

        Public Sub PanToBounds(ByVal value As LatLngBounds)
            v_com.PanToBounds(value)
        End Sub

#End Region

#Region "Place"

        Public Sub FitBounds(ByVal bounds As LatLngBounds)

            v_com.SetBounds(bounds)

        End Sub

#End Region

#Region "Markers"

        Public Function GetMap() As String

            Return v_com.Page.Document.GetElementById("map_canvas").InnerHtml

        End Function

        Public Sub AddMarker(ByVal item As Marker)

            v_com.AddMarker(item)

            v_markers.Add(item)

        End Sub

        Public Sub DeleteMarkers()
            v_com.DeleteMarkers()
        End Sub

        Public Sub RefreshMarkers()
            v_com.RefreshMarkers()
        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace


