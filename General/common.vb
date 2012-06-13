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

'IMPORTACIONES PARA SERIALIZACIÓN
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Soap
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Security.Permissions
Imports System.Windows.Forms

Friend Module CommonFunctions

    Public gv_pages As New List(Of System.Windows.Forms.WebBrowser)

    Friend Sub ShowError(ByVal ex As Exception)

        Dim st As New System.Diagnostics.StackTrace

        Dim t_appErrorMesaage As String = "Se ha presentado un error inesperado," & _
            "el mensaje del error es el siguiente: " & vbNewLine & _
            vbNewLine & ex.Message & vbNewLine & vbNewLine & "En: " & st.GetFrame(1).GetMethod.ReflectedType.FullName & "." & st.GetFrame(1).GetMethod.Name

        MsgBox(t_appErrorMesaage, MsgBoxStyle.Exclamation, st.GetFrame(1).GetMethod.ReflectedType.FullName)

    End Sub

    Friend Function Clone(ByVal obj As Object) As Object
        Dim ms As New MemoryStream
        Dim objResult As Object = Nothing
        Try
            Dim bf As New BinaryFormatter
            bf.Serialize(ms, obj)
            ms.Position = 0
            objResult = bf.Deserialize(ms)
        Finally
            ms.Close()
        End Try
        Return objResult
    End Function

    'Obtener Popiedades de objetos COM
    Friend Function InvokeScript(ByVal page As System.Windows.Forms.WebBrowser, ByVal method As String) As Object

        Return page.Document.InvokeScript(method)

    End Function
    Friend Function InvokeScript(ByVal page As System.Windows.Forms.WebBrowser, ByVal method As String, ByVal args() As Object) As Object

        Return page.Document.InvokeScript(method, args)

    End Function
    Friend Function InvokeMethod(ByVal item As Object, ByVal attributeName As String) As Object
        Return item.GetType.InvokeMember(attributeName, Reflection.BindingFlags.InvokeMethod, Nothing, item, Nothing)
    End Function
    Friend Function InvokeMethod(ByVal item As Object, ByVal attributeName As String, ByVal args As Object()) As Object
        Return item.GetType.InvokeMember(attributeName, Reflection.BindingFlags.InvokeMethod, Nothing, item, args)
    End Function
    Friend Function GetProperty(ByVal item As Object, ByVal attributeName As String) As Object
        Return item.GetType.InvokeMember(attributeName, Reflection.BindingFlags.GetProperty, Nothing, item, Nothing)
    End Function
    Friend Function GetField(ByVal item As Object, ByVal attributeName As String) As Object
        Return item.GetType.GetField(attributeName, Reflection.BindingFlags.GetField)
    End Function


    '---CAST FUNCTIONS---


    '--LatLng--
    ''' <summary>
    ''' Gets an object of type type JScriptTypeInfo that represent an instance of the type google.maps.LatLng from an instance of the class Pegazux.Controls.GoogleMaps.LatLng 
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function CastToJsLatLng(ByVal item As Pegazux.GoogleMaps.LatLng) As Object

        Try

            Dim args(0) As Object
            args(0) = item

            Try
here:
                Return InvokeScript(gv_pages(0), "CastToJsLatLng", args)

            Catch ex As Exception

                gv_pages.RemoveAt(0)

                GoTo here

            End Try

        Catch ex As Exception

            'ShowError(ex)

            Return Nothing

        End Try

    End Function
    ''' <summary>
    ''' Gets an instance of the class LatLng from an object of type JScriptTypeInfo that represent an instance of the type google.maps.LatLng
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function CastToLatLng(ByVal item As Object) As Pegazux.GoogleMaps.LatLng

        Try

            Dim TempItem As New Pegazux.GoogleMaps.LatLng

            If item IsNot DBNull.Value Then

                TempItem.Lat = InvokeMethod(item, "lat")
                TempItem.Lng = InvokeMethod(item, "lng")

            End If

            Return TempItem

        Catch ex As Exception

            ShowError(ex)

            Return Nothing

        End Try

    End Function


    ''' <summary>
    ''' Gets an instance of the class LatLngBounds from an object of type JScriptTypeInfo that represent an instance of the type google.maps.LatLngBounds
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CastToLatLngBounds(ByVal item As Object) As Pegazux.GoogleMaps.LatLngBounds

        Try

            Dim TempItem As New Pegazux.GoogleMaps.LatLngBounds

            TempItem.NorthEast = CastToLatLng(InvokeMethod(item, "getNorthEast"))
            TempItem.SouthWest = CastToLatLng(InvokeMethod(item, "getSouthWest"))

            Return TempItem

        Catch ex As Exception

            ShowError(ex)

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Gets an object of type type JScriptTypeInfo that represent an instance of the type google.maps.LatLngBounds from an instance of the class Pegazux.Controls.GoogleMaps.LatLngBounds 
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function CatsToJsLngBounds(ByVal item As Pegazux.GoogleMaps.LatLngBounds) As Object

        Try

            Dim args(0) As Object

            args(0) = item

            Try
here:
                Return InvokeScript(gv_pages(0), "CatsToJsLngBounds", args)

            Catch ex As Exception

                gv_pages.RemoveAt(0)

                GoTo here

            End Try

        Catch ex As Exception

            ShowError(ex)

            Return Nothing

        End Try

    End Function

    '--MapTypeID--
    ''' <summary>
    ''' Gets an instance of the class MapTypeId  from an object of type JScriptTypeInfo that represent an instance of the type google.maps.MapTypeId 
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function CastToMapTypeId(ByVal item As Object) As Pegazux.GoogleMaps.MapTypeId

        Try

            For i As Integer = 0 To 3

                Dim Temp As Pegazux.GoogleMaps.MapTypeId = i

                If item.ToString.ToUpper = Temp.ToString Then

                    Return Temp

                End If

            Next

            Return Pegazux.GoogleMaps.MapTypeId.ROADMAP

        Catch ex As Exception

            ShowError(ex)

            Return Nothing

        End Try

    End Function


#Region "Serialización"

    Friend Function SerializeToSoap(ByVal value As Object) As String

        Dim t_fileStream As New MemoryStream
        Dim t_serializer As New SoapFormatter

        t_serializer.Serialize(t_fileStream, value)

        t_fileStream.Flush()
        t_fileStream.Position = 0

        Dim t_streamReader = New StreamReader(t_fileStream)
        Dim t_string = t_streamReader.ReadToEnd()

        t_fileStream.Dispose()
        t_streamReader.Dispose()
        t_serializer = Nothing

        GC.Collect()

        Return t_string

    End Function

    Friend Function DeSerializeFromSoap(ByVal value As String) As Object

        Dim t_fileStream As New MemoryStream
        Dim t_streamWriter As New StreamWriter(t_fileStream)
        Dim t_stringReader As New StringReader(value)

        t_streamWriter.AutoFlush = True
        t_streamWriter.Write(t_stringReader.ReadToEnd)

        t_fileStream.Seek(0, SeekOrigin.Begin)

        Dim deserializer As New SoapFormatter
        Dim t_object As Object = CType(deserializer.Deserialize(t_fileStream), Object)

        t_fileStream.Dispose()
        t_streamWriter.Dispose()
        t_stringReader.Dispose()
        deserializer = Nothing

        GC.Collect()

        Return t_object

    End Function

#End Region


End Module

Namespace System.Runtime.InteropServices

    ''' <summary>
    ''' Implementa funciones que permiten la comunicación de puente entre objetos no administrados DOM y objetos adminitrados COM.
    ''' </summary>
    ''' <remarks></remarks>
    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
     <System.Runtime.InteropServices.ComVisibleAttribute(True)> _
     <Serializable()> _
    Public NotInheritable Class ComBridge

#Region "Declare"

        Private v_page As System.Windows.Forms.WebBrowser

#End Region

#Region "Event"

        ''' <summary>
        ''' This event is fired when the map's load have being finalized.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event Ready(ByVal sender As Object, ByVal e As System.EventArgs)

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
        Public Event Bounds_Changed(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MapEventArgs)

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
        Public Event Drag(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MapEventArgs)

        ''' <summary>
        ''' This event is fired when the user stops dragging the map.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event DragEnd(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MapEventArgs)

        ''' <summary>
        ''' This event is fired when the user starts dragging the map.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event DragStart(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MapEventArgs)

        ''' <summary>
        ''' This event is fired when the map becomes idle after panning or zooming.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event Idle(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MapEventArgs)

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
        Public Shadows Event Projection_Changed(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MapEventArgs)

        ''' <summary>
        ''' This event is fired when the div changes size
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Shadows Event Resize(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MapEventArgs)

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
        Public Event TilesLoaded(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MapEventArgs)

        ''' <summary>
        ''' This event is fired when the map zoom property changes.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event Zoom_Changed(ByVal sender As Object, ByVal e As Pegazux.GoogleMaps.MapEventArgs)

#End Region

#Region "Property"

        Public Property Page As System.Windows.Forms.WebBrowser
            Get
                Return v_page
            End Get
            Set(ByVal value As System.Windows.Forms.WebBrowser)
                v_page = value
            End Set
        End Property

#End Region

#Region "Procedure"

#Region "Triggers"

        '//MAP TRIGGERS

        Public Sub OnReady()

            RaiseEvent Ready(Me, New System.EventArgs)

        End Sub

        Public Sub OnMarkerAdded(ByVal value As Object)
            ' RaiseEvent MarkerAdded(Me, New Pegazux.GoogleMaps.MapEventArgs(value))
        End Sub

        Public Sub OnBounds_Changed(ByVal value As Object)
            RaiseEvent Bounds_Changed(Me, New Pegazux.GoogleMaps.MapEventArgs(CastToLatLngBounds(value)))
        End Sub

        Public Sub OnCenter_changed(ByVal value As Object)
            Dim t_eventArgs As New Pegazux.GoogleMaps.MapEventArgs(CastToLatLng(value))
            RaiseEvent Center_changed(Me, t_eventArgs)
        End Sub

        Public Overloads Sub OnClick(ByVal value As Object)
            RaiseEvent Click(Me, New Pegazux.GoogleMaps.MouseEventArgs(CastToLatLng(value)))
        End Sub

        Public Sub OnDblclick(ByVal value As Object)
            RaiseEvent Dblclick(Me, New Pegazux.GoogleMaps.MouseEventArgs(CastToLatLng(value)))
        End Sub

        Public Sub OnDrag()
            RaiseEvent Drag(Me, New Pegazux.GoogleMaps.MapEventArgs())
        End Sub

        Public Sub OnDragEnd()
            RaiseEvent DragEnd(Me, New Pegazux.GoogleMaps.MapEventArgs())
        End Sub

        Public Sub OnDragStart()
            RaiseEvent DragStart(Me, New Pegazux.GoogleMaps.MapEventArgs())
        End Sub

        Public Sub OnIdle()
            RaiseEvent Idle(Me, New Pegazux.GoogleMaps.MapEventArgs())
        End Sub

        Public Sub OnMapTypeId_Changed(ByVal value As Object)
            RaiseEvent MapTypeId_Changed(Me, New Pegazux.GoogleMaps.MapEventArgs(CastToMapTypeId(value)))
        End Sub

        Public Overloads Sub OnMousemove(ByVal value As Object)
            RaiseEvent Mousemove(Me, New Pegazux.GoogleMaps.MouseEventArgs(CastToLatLng(value)))
        End Sub

        Public Sub OnMouseOut(ByVal value As Object)
            RaiseEvent Mouseout(Me, New Pegazux.GoogleMaps.MouseEventArgs(CastToLatLng(value)))
        End Sub

        Public Sub OnMouseover(ByVal value As Object)
            RaiseEvent Mouseover(Me, New Pegazux.GoogleMaps.MouseEventArgs(CastToLatLng(value)))
        End Sub

        Public Overloads Sub OnProjection_Changed()
            RaiseEvent Projection_Changed(Me, New Pegazux.GoogleMaps.MapEventArgs())
        End Sub

        Public Overloads Sub OnResize()
            RaiseEvent Resize(Me, New Pegazux.GoogleMaps.MapEventArgs())
        End Sub

        Public Sub OnRightClick(ByVal value As Object)
            RaiseEvent RightClick(Me, New Pegazux.GoogleMaps.MouseEventArgs(CastToLatLng(value)))
        End Sub

        Public Sub OnTilesLoaded()
            RaiseEvent TilesLoaded(Me, New Pegazux.GoogleMaps.MapEventArgs())
        End Sub

        Public Sub OnZoom_Changed(ByVal value As Object)
            RaiseEvent Zoom_Changed(Me, New Pegazux.GoogleMaps.MapEventArgs(value))
        End Sub

#End Region

        Public Sub New()

        End Sub

        Public Sub New(ByVal page As System.Windows.Forms.WebBrowser)
            v_page = page
        End Sub

        '--setShowControls--
        Public Sub SetShowControls(ByVal value As Boolean)
            Try
                InvokeScript(Page, "setMapTypeControl", New Object() {value})
                InvokeScript(Page, "setNavigationControl", New Object() {value})
                InvokeScript(Page, "setScaleControl", New Object() {value})
                InvokeScript(Page, "setStreetViewControl", New Object() {value})
            Catch ex As Exception
            End Try
        End Sub

        '--setMapTypeId--
        Public Sub SetMapTypeId(ByVal value As Pegazux.GoogleMaps.MapTypeId)
            Try
                InvokeScript(Page, "setMapTypeId", New Object() {value})
            Catch ex As Exception
            End Try
        End Sub
        Public Function GetMapTypeId() As Pegazux.GoogleMaps.MapTypeId
            Try
                Return CastToMapTypeId(InvokeScript(Page, "getMapTypeId"))
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        '--disableDefaultUI--
        Public Sub SetDisableDefaultUI(ByVal value As Boolean)
            Try
                InvokeScript(Page, "setDisableDefaultUI", New Object() {value})
            Catch ex As Exception
            End Try
        End Sub
        Public Function GetDisableDefaultUI() As Boolean
            Try
                Return CBool(InvokeScript(Page, "getDisableDefaultUI"))
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        '--disableDoubleClickZoom--
        Public Sub SetDisableDoubleClickZoom(ByVal value As Boolean)
            Try
                InvokeScript(Page, "setDisableDoubleClickZoom", New Object() {value})
            Catch ex As Exception
            End Try
        End Sub
        Public Function GetDisableDoubleClickZoom() As Boolean
            Try
                Return CBool(InvokeScript(Page, "getDisableDoubleClickZoom"))
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        '--draggable--
        Public Sub SetDraggable(ByVal value As Boolean)
            Try
                InvokeScript(Page, "setDraggable", New Object() {value})
            Catch ex As Exception
            End Try
        End Sub
        Public Function GetDraggable() As Boolean
            Try
                Return CBool(InvokeScript(Page, "getDraggable"))
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        '--draggableCursor--
        Public Sub SetDraggableCursor(ByVal value As String)
            Try
                InvokeScript(Page, "setDraggableCursor", New Object() {value})
            Catch ex As Exception
            End Try
        End Sub
        Public Function GetDraggableCursor() As String
            Try
                Return CStr(InvokeScript(Page, "getDraggableCursor"))
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        '--draggingCursor--
        Public Sub SetDraggingCursor(ByVal value As String)
            Try
                InvokeScript(Page, "setDraggingCursor", New Object() {value})
            Catch ex As Exception
            End Try
        End Sub
        Public Function GetDraggingCursor() As String
            Try
                Return CStr(InvokeScript(Page, "getDraggingCursor"))
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        '--keyboardShortcuts--
        Public Sub SetKeyboardShortcuts(ByVal value As Boolean)
            Try
                InvokeScript(Page, "setKeyboardShortcuts", New Object() {value})
            Catch ex As Exception
            End Try
        End Sub
        Public Function GetKeyboardShortcuts() As String
            Try
                Return CBool(InvokeScript(Page, "getKeyboardShortcuts"))
            Catch ex As Exception
                Return Nothing
            End Try
        End Function


        '--mapTypeControl--
        Public Sub SetMapTypeControl(ByVal value As Boolean)
            Try
                InvokeScript(Page, "setMapTypeControl", New Object() {value})
            Catch ex As Exception
            End Try
        End Sub
        Public Function GetMapTypeControl() As String
            Try
                Return CBool(InvokeScript(Page, "getMapTypeControl"))
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        '--mapTypeControlOptions--
        Public Sub SetMapTypeControlOptions(ByVal value As Pegazux.GoogleMaps.MapTypeControlOptions, ByVal count As Integer)
            Try
                InvokeScript(Page, "setMapTypeControlOptions", New Object() {value, count})
            Catch ex As Exception
            End Try
        End Sub


        '--mapTypenavigationControlControl--
        Public Sub SetNavigationControl(ByVal value As Boolean)
            Try
                InvokeScript(Page, "setNavigationControl", New Object() {value})
            Catch ex As Exception
            End Try
        End Sub
        Public Function GetNavigationControl() As String
            Try
                Return CBool(InvokeScript(Page, "getNavigationControl"))
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        '--navigationControlOptions--
        Public Sub SetNavigationControlOptions(ByVal value As Pegazux.GoogleMaps.NavigationControlOptions)
            Try
                InvokeScript(Page, "setNavigationControlOptions", New Object() {value})
            Catch ex As Exception
            End Try
        End Sub


        '--setCenter--
        Public Sub SetCenter(ByVal value As Pegazux.GoogleMaps.LatLng)
            Try
                InvokeScript(Page, "setCenter", New Object() {value})
            Catch ex As Exception
            End Try
        End Sub
        Public Function GetCenter() As Pegazux.GoogleMaps.LatLng
            Try
                Return CastToLatLng(InvokeScript(Page, "getCenter"))
            Catch ex As Exception
                Return Nothing
            End Try
        End Function


        '--noClear--
        Public Sub SetNoClear(ByVal value As Boolean)
            Try
                InvokeScript(Page, "setNoClear", New Object() {value})
            Catch ex As Exception
            End Try
        End Sub
        Public Function GetNoClear() As Boolean
            Try
                Return CBool(InvokeScript(Page, "getNoClear"))
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        '--scaleControl--
        Public Sub SetScaleControl(ByVal value As Boolean)
            Try
                InvokeScript(Page, "setScaleControl", New Object() {value})
            Catch ex As Exception
            End Try
        End Sub
        Public Function GetScaleControl() As Boolean
            Try
                Return CBool(InvokeScript(Page, "getScaleControl"))
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        '--scaleControlOptions--
        Public Sub SetScaleControlOptions(ByVal value As Pegazux.GoogleMaps.ScaleControlOptions)
            Try
                InvokeScript(Page, "setScaleControlOptions", New Object() {value})
            Catch ex As Exception
            End Try
        End Sub

        '--scrollwheel--
        Public Sub SetScrollwheel(ByVal value As Boolean)
            Try
                InvokeScript(Page, "setScrollwheel", New Object() {value})
            Catch ex As Exception
            End Try
        End Sub
        Public Function GetScrollwheel() As Boolean
            Try
                Return CBool(InvokeScript(Page, "getScrollwheel"))
            Catch ex As Exception
                Return Nothing
            End Try
        End Function


        '--streetViewControl--
        Public Sub SetStreetViewControl(ByVal value As Boolean)
            Try
                InvokeScript(Page, "setStreetViewControl", New Object() {value})
            Catch ex As Exception
            End Try
        End Sub
        Public Function GetStreetViewControl() As Boolean
            Try
                Return CBool(InvokeScript(Page, "getStreetViewControl"))
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        '--zoom--
        Public Sub SetZoom(ByVal value As Integer)
            Try
                InvokeScript(Page, "setZoom", New Object() {value})
            Catch ex As Exception
            End Try
        End Sub
        Public Function GetZoom() As Integer
            Try
                Return CInt(InvokeScript(Page, "getZoom"))
            Catch ex As Exception
                Return 0
            End Try
        End Function

        '--panBy--
        Public Sub PanBy(ByVal x As Integer, ByVal y As Integer)

            InvokeScript(Page, "panBy", New Object() {x, y})

        End Sub

        '--panBy--
        Public Sub PanTo(ByVal value As Pegazux.GoogleMaps.LatLng)

            InvokeScript(Page, "panTo", New Object() {value})

        End Sub

        '--panBy--
        Public Sub PanToBounds(ByVal value As Pegazux.GoogleMaps.LatLngBounds)

            InvokeScript(Page, "panToBounds", New Object() {value})

        End Sub
        '--setBounds--
        Public Sub SetBounds(ByVal value As Pegazux.GoogleMaps.LatLngBounds)

            InvokeScript(Page, "fitBounds", New Object() {value})

        End Sub

        Public Function GetBounds() As Pegazux.GoogleMaps.LatLngBounds
            Try
                Return CastToLatLngBounds(InvokeScript(Page, "getBounds"))
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        '---addMarker---
        Public Sub AddMarker(ByVal value As Pegazux.GoogleMaps.Marker)
            InvokeScript(Page, "addMarker", New Object() {value})
        End Sub

        '---setUsingClusterer---
        Public Sub SetUsingClusterer(ByVal value As Boolean)
            InvokeScript(Page, "setUsingClusterer", New Object() {value})
        End Sub

        '---refreshMarkers---
        Public Sub RefreshMarkers()
            InvokeScript(Page, "refreshMarkers")
        End Sub

        '---deleteMarkers---
        Public Sub DeleteMarkers()
            InvokeScript(Page, "deleteMarkers")
        End Sub


#End Region

    End Class

End Namespace