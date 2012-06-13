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
    ''' This object defines the marker shape to use in determination of a marker's clickable region. The shape consists of two properties — type and coord — which define the general type of marker and coordinates specific to that type of marker.
    ''' </summary>
    ''' <remarks></remarks>
    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    <System.Runtime.InteropServices.ComVisibleAttribute(True)> _
    Public Class MarkerShape

#Region "Declaraciones"

        Private v_coord As Integer()
        Private v_type As MarkerShapeTypes

#End Region

#Region "Propiedades"

        ''' <summary>
        ''' The format of this attribute depends on the value of the type and follows the w3 AREA coords specification found at http://www.w3.org/TR/REC-html40/struct/objects.html#adef-coords. 
        '''coord is an array of integers that specify the pixel position of the shape relative to the top-left corner of the target image. The coordinates depend on the value of type as follows: 
        '''- circ or circle: coord is [x1,y1,r] where x1,y2 are the coordinates of the center of the circle, and r is the radius of the circle. 
        '''- poly or polygon: coord is [x1,y1,x2,y2...xn,yn] where each x,y pair contains the coordinates of one vertex of the polygon. 
        '''- rect or rectangle: coord is [x1,y1,x2,y2] where x1,y1 are the coordinates of the upper-left corner of the rectangle and x2,y2 are the coordinates of the lower-right coordinates of the rectangle.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Coord() As Integer()
            Get
                Return v_coord
            End Get
            Set(ByVal value As Integer())
                v_coord = value
            End Set
        End Property

        ''' <summary>
        ''' Describes the shape's type and can be circle, poly or rectangle.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Type() As MarkerShapeTypes
            Get
                Return v_type
            End Get
            Set(ByVal value As MarkerShapeTypes)
                v_type = value
            End Set
        End Property

#End Region

    End Class

End Namespace