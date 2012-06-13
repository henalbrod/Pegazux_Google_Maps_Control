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

Namespace Pegazux.GoogleMaps

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    <Serializable()> _
    Partial Class GoogleMap
        Inherits System.Windows.Forms.UserControl

        'UserControl reemplaza a Dispose para limpiar la lista de componentes.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Requerido por el Diseñador de Windows Forms
        Private components As System.ComponentModel.IContainer

        'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
        'Se puede modificar usando el Diseñador de Windows Forms.  
        'No lo modifique con el editor de código.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.page = New System.Windows.Forms.WebBrowser()
            Me.SuspendLayout()
            '
            'page
            '
            Me.page.AllowWebBrowserDrop = False
            Me.page.Dock = System.Windows.Forms.DockStyle.Fill
            Me.page.IsWebBrowserContextMenuEnabled = False
            Me.page.Location = New System.Drawing.Point(0, 0)
            Me.page.MinimumSize = New System.Drawing.Size(20, 20)
            Me.page.Name = "page"
            Me.page.ScriptErrorsSuppressed = True
            Me.page.ScrollBarsEnabled = False
            Me.page.Size = New System.Drawing.Size(477, 413)
            Me.page.TabIndex = 0
            Me.page.TabStop = False
            Me.page.WebBrowserShortcutsEnabled = False
            '
            'GoogleMap
            '
            Me.Controls.Add(Me.page)
            Me.Name = "GoogleMap"
            Me.Size = New System.Drawing.Size(477, 413)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents page As System.Windows.Forms.WebBrowser

    End Class

End Namespace
