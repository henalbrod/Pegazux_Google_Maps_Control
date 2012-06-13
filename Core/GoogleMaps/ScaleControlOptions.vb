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
    ''' Options for the rendering of the scale control.
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    <System.Runtime.InteropServices.ComVisibleAttribute(True)> _
    <System.ComponentModel.TypeConverter(GetType(ScaleControlOptionsTypeConverter))> _
    Public Class ScaleControlOptions

#Region "Declaraciones"

        Private v_position As ControlPosition
        Private v_style As String

        Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs)

#End Region

#Region "Propiedades"

        ''' <summary>
        ''' Position id. Used to specify the position of the control on the map. 
        ''' The default position is BOTTOM_LEFT.
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
        ''' Style id. Used to select what style of scale control to display.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Style() As String
            Get
                Return v_style
            End Get
        End Property

#End Region

#Region "Procedimientos"

        Public Sub New()
            v_position = ControlPosition.BOTTOM_LEFT
            v_style = "DEFAULT"
        End Sub

#End Region

    End Class

    Friend NotInheritable Class ScaleControlOptionsTypeConverter
        Inherits System.ComponentModel.TypeConverter

        Public Overrides Function GetProperties(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal value As Object, ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection
            Return System.ComponentModel.TypeDescriptor.GetProperties(GetType(Pegazux.GoogleMaps.ScaleControlOptions))
        End Function

        Public Overrides Function GetPropertiesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
            Return True
        End Function

    End Class

End Namespace