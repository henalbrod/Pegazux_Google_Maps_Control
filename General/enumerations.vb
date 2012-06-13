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


#Region "Enumerations"

    ''' <summary>
    ''' Identifiers for common MapTypes.
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    <System.Runtime.InteropServices.ComVisibleAttribute(True)> _
    Public Enum MapTypeId As Integer

        ''' <summary>
        ''' Muestra la vista por defecto de Mapa de carreteras.
        ''' </summary>
        ''' <remarks></remarks>
        ROADMAP = 0

        ''' <summary>
        ''' Muestra imágenes de satélite de Google Earth
        ''' </summary>
        ''' <remarks></remarks>
        SATELLITE = 1

        ''' <summary>
        ''' Muestra una mezcla de la vista normal y la vista de satélite.
        ''' </summary>
        ''' <remarks></remarks>
        HYBRID = 2

        ''' <summary>
        ''' Muestra un mapa físico basado en la información del terreno.
        ''' </summary>
        ''' <remarks></remarks>
        TERRAIN = 3

    End Enum

    ''' <summary>
    ''' Identifiers for common types of navigation controls.
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    <System.Runtime.InteropServices.ComVisibleAttribute(True)> _
    Public Enum NavigationControlStyle As Integer

        ''' <summary>
        ''' The small zoom control similar to the one used by the native Maps application on Android.
        ''' </summary>
        ''' <remarks></remarks>
        ANDROID = 0

        ''' <summary>
        ''' The small, zoom only control.
        ''' </summary>
        ''' <remarks></remarks>
        SMALL = 2

        ''' <summary>
        ''' The larger control, with the zoom slider and pan directional pad.
        ''' </summary>
        ''' <remarks></remarks>
        ZOOM_PAN = 3

    End Enum

    ''' <summary>
    ''' Identifiers for common MapTypesControls.
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    <System.Runtime.InteropServices.ComVisibleAttribute(True)> _
    Public Enum MapTypeControlStyle As Integer

        HORIZONTAL_BAR = 1
        DROPDOWN_MENU = 2

    End Enum

    ''' <summary>
    ''' Identifiers used to specify the placement of controls on the map. 
    ''' Controls are positioned relative to other controls in the same layout position. 
    ''' Controls that are added first are positioned closer to the edge of the map. 
    ''' </summary>
    ''' <remarks></remarks>
    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    <System.Runtime.InteropServices.ComVisibleAttribute(True)> _
    Public Enum ControlPosition As Integer

        ''' <summary>
        ''' Elements are positioned in the center of the bottom row
        ''' </summary>
        ''' <remarks></remarks>
        BOTTOM_CENTER = 1
        ''' <summary>
        ''' Elements are positioned in the bottom left and flow towards the middle.
        ''' Elements are positioned to the right of the Google logo.
        ''' </summary>
        ''' <remarks></remarks>
        BOTTOM_LEFT = 2
        ''' <summary>
        ''' Elements are positioned in the bottom right and flow towards the middle.
        '''Elements are positioned to the left of the copyrights.
        ''' </summary>
        ''' <remarks></remarks>
        BOTTOM_RIGHT = 3
        ''' <summary>
        ''' Elements are positioned on the left, above bottom-left elements, and flow upwards.
        ''' </summary>
        ''' <remarks></remarks>
        LEFT_BOTTOM = 4
        ''' <summary>
        ''' Elements are positioned in the center of the left side.
        ''' </summary>
        ''' <remarks></remarks>
        LEFT_CENTER = 5
        ''' <summary>
        ''' Elements are positioned on the left, below top-left elements, and flow downwards.
        ''' </summary>
        ''' <remarks></remarks>
        LEFT_TOP = 6
        ''' <summary>
        ''' Elements are positioned on the right, above bottom-right elements, and flow upwards.
        ''' </summary>
        ''' <remarks></remarks>
        RIGHT_BOTTOM = 7
        ''' <summary>
        ''' Elements are positioned in the center of the left side.
        ''' </summary>
        ''' <remarks></remarks>
        RIGHT_CENTER = 8
        ''' <summary>
        ''' Elements are positioned on the right, below top-right elements, and flow downwards.
        ''' </summary>
        ''' <remarks></remarks>
        RIGHT_TOP = 9
        ''' <summary>
        ''' Elements are positioned in the center of the top row.
        ''' </summary>
        ''' <remarks></remarks>
        TOP_CENTER = 10
        ''' <summary>
        ''' Elements are positioned in the top left and flow towards the middle.
        ''' </summary>
        ''' <remarks></remarks>
        TOP_LEFT = 11
        ''' <summary>
        ''' Elements are positioned in the top right and flow towards the middle.
        ''' </summary>
        ''' <remarks></remarks>
        TOP_RIGHT = 12

    End Enum

    ''' <summary>
    ''' Describes the shape's type and can be circle, poly or rect.
    ''' </summary>
    ''' <remarks></remarks>
    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    <System.Runtime.InteropServices.ComVisibleAttribute(True)> _
    Public Enum MarkerShapeTypes As Integer

        circle = 0
        poly = 1
        rect = 3

    End Enum

    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    <System.Runtime.InteropServices.ComVisibleAttribute(True)> _
    Public Enum Cursors

        auto
        crosshair
        help
        move
        pointer
        text
        wait
        hand
        progress
        not_allowed
        no_drop
        vertical_text
        all_scroll

    End Enum

#End Region

End Namespace
