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

Namespace Pegazux.GoogleMaps

    ''' <summary>
    ''' Options for the rendering of the map type control.
    ''' </summary>
    ''' <remarks></remarks>
    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    <System.Runtime.InteropServices.ComVisibleAttribute(True)> _
    <System.ComponentModel.TypeConverter(GetType(MapTypeControlOptionsTypeConverter))> _
    Public Class MapTypeControlOptions

#Region "Declaraciones"

        Private v_mapTypeIds As MapTypeId()
        Private v_position As ControlPosition
        Private v_style As MapTypeControlStyle

        Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs)

#End Region

#Region "Propiedades"

        ''' <summary>
        ''' IDs of map types to show in the control.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False)> _
        <DebuggerBrowsable(False)> _
        Public Property MapTypeIds() As MapTypeId()
            Get
                Return v_mapTypeIds
            End Get
            Set(ByVal value As MapTypeId())
                v_mapTypeIds = value
                RaiseEvent PropertyChanged(Me, New System.EventArgs)
            End Set
        End Property

        ''' <summary>
        ''' Position id. Used to specify the position of the control on the map. 
        ''' The default position is TOP_RIGHT.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Position() As ControlPosition
            Get
                Return v_position
            End Get
            Set(ByVal value As ControlPosition)
                If v_position <> value Then
                    v_position = value
                    RaiseEvent PropertyChanged(Me, New System.EventArgs)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Style id. Used to select what style of map type control to display.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Style() As MapTypeControlStyle
            Get
                Return v_style
            End Get
            Set(ByVal value As MapTypeControlStyle)
                If v_style <> value Then
                    v_style = value
                    RaiseEvent PropertyChanged(Me, New System.EventArgs)
                End If
            End Set
        End Property

#End Region

#Region "Procedimientos"

        Public Sub New()

            ReDim v_mapTypeIds(3)

            v_mapTypeIds(0) = MapTypeId.HYBRID
            v_mapTypeIds(0) = MapTypeId.ROADMAP
            v_mapTypeIds(0) = MapTypeId.SATELLITE
            v_mapTypeIds(0) = MapTypeId.TERRAIN

            v_position = ControlPosition.TOP_RIGHT

            v_style = MapTypeControlStyle.HORIZONTAL_BAR

        End Sub

#End Region

    End Class

    Friend NotInheritable Class MapTypeControlOptionsTypeConverter
        Inherits System.ComponentModel.TypeConverter

        Public Overrides Function GetProperties(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal value As Object, ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection
            Return System.ComponentModel.TypeDescriptor.GetProperties(GetType(Pegazux.GoogleMaps.MapTypeControlOptions))
        End Function

        Public Overrides Function GetPropertiesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
            Return True
        End Function

    End Class

End Namespace