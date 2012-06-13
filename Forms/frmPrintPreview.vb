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

<Serializable()> _
Friend Class frmPrintPreview

#Region "Declare"

    Private v_handle As System.IntPtr
    Private v_mapArea As System.Drawing.Rectangle
    Private v_parentArea As System.Drawing.Rectangle
    Private v_print As New Print
    Private v_porcentageMouseDown As Boolean

#End Region

#Region "Property"

    Public Property ParentHandle As System.IntPtr
        Get
            Return v_handle
        End Get
        Set(ByVal value As System.IntPtr)
            v_handle = value
        End Set
    End Property

    Public Property MapArea As System.Drawing.Rectangle
        Get
            Return v_mapArea
        End Get
        Set(ByVal value As System.Drawing.Rectangle)
            v_mapArea = value
        End Set
    End Property

    Public Property ParentArea As System.Drawing.Rectangle
        Get
            Return v_parentArea
        End Get
        Set(ByVal value As System.Drawing.Rectangle)
            v_parentArea = value
        End Set
    End Property

#End Region

#Region "Procedure"

    Private Sub frmPrintPreview_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Me.preView.Document = GetDocument()

        Me.preView.AutoZoom = True

        lblPorcentage.Text = trackPorcentage.Value & "%"
        lblZoom.Text = trackZoom.Value & "%"

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Me.PrintDialog.Document = Me.preView.Document

        If Me.PrintDialog.ShowDialog(Me) = vbOK Then

            Me.preView.Document.Print()

        End If

    End Sub

    Private Sub preView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles preView.Click
        trackZoom.Visible = False
        trackPorcentage.Visible = False
    End Sub

    Private Sub toolToolBar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolToolBar.Click
        trackZoom.Visible = False
    End Sub

    Private Sub toolToolBar_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles toolToolBar.ItemClicked
        trackZoom.Visible = False
    End Sub

    Private Sub trackZoom_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trackZoom.Scroll

        btnFitToZoom.Checked = True
        btnFitToPage.Checked = False
        Me.preView.AutoZoom = False
        Me.preView.Zoom = CDbl(trackZoom.Value * 0.01)
        lblZoom.Text = trackZoom.Value & "%"

    End Sub

    Private Sub btnFitToPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFitToPage.Click

        Me.preView.AutoZoom = True
        btnFitToZoom.Checked = False

    End Sub

    Private Sub btnFitToZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFitToZoom.Click

        btnFitToPage.Checked = False
        Me.preView.AutoZoom = False
        Me.preView.Zoom = CDbl(trackZoom.Value * 0.01)

    End Sub

    Private Sub btnPageConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPageConfig.Click

        Me.PageSetupDialog.Document = Me.preView.Document

        If Me.PageSetupDialog.ShowDialog(Me) = vbOK Then

            My.Settings.Print_DafaultPageSetup = SerializeToSoap(Me.PageSetupDialog.PageSettings)
            My.Settings.Save()

            Me.preView.InvalidatePreview()

        End If

    End Sub

    Public Function GetDocument() As System.Drawing.Printing.PrintDocument



        Return v_print.GetPrintDocument(v_handle, v_mapArea, v_parentArea, 100)

    End Function

    Private Sub Zoom_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoom.Click

        If btnZoom.IsOnOverflow Then

            trackZoom.Left = PointToClient(MousePosition).X - 2
            trackZoom.Visible = True
            trackZoom.Focus()

        Else

            trackZoom.Left = 172
            trackZoom.Visible = True

        End If

        trackZoom.Focus()

    End Sub

    Private Sub trackPorcentage_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trackPorcentage.MouseDown

        v_porcentageMouseDown = True

    End Sub

    Private Sub trackPorcentage_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trackPorcentage.MouseUp

        v_porcentageMouseDown = False

        Me.preView.Document = v_print.GetPrintDocument(ParentHandle, MapArea, ParentArea, trackPorcentage.Value)

        Me.preView.Invalidate()

    End Sub

    Private Sub trackPorcentage_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trackPorcentage.ValueChanged

        If v_porcentageMouseDown = False Then

            Me.preView.Document = v_print.GetPrintDocument(ParentHandle, MapArea, ParentArea, trackPorcentage.Value)

            Me.preView.Invalidate()

        End If

        lblPorcentage.Text = trackPorcentage.Value & "%"

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        Dim t_res As MsgBoxResult = If(trackPorcentage.Value <> 100, MsgBox("Desea exportar la imágen ajustada a la escala actual?, oprima 'Si' para exportar al " & trackPorcentage.Value & "% y oprima 'No' para exportar en su tamaño original", vbYesNoCancel, "Escalar"), MsgBoxResult.No)

        If t_res = MsgBoxResult.Yes Then

            SaveFileDialog.FileName = "Google Map (" & trackPorcentage.Value & "%)"

            If SaveFileDialog.ShowDialog(Me.ParentForm) = vbOK Then

                v_print.GetBitMap(ParentHandle, MapArea, ParentArea, trackPorcentage.Value).Save(SaveFileDialog.FileName)

            End If

        ElseIf t_res = MsgBoxResult.No Then

            SaveFileDialog.FileName = "Google Map (100%)"

            If SaveFileDialog.ShowDialog(Me.ParentForm) = vbOK Then

                v_print.GetBitMap(ParentHandle, MapArea, ParentArea, 100).Save(SaveFileDialog.FileName)

            End If

        End If

    End Sub

    Private Sub btnPorcentage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPorcentage.Click

        If btnPorcentage.IsOnOverflow Then

            trackPorcentage.Left = PointToClient(MousePosition).X - 2
            trackPorcentage.Visible = True
            trackPorcentage.Focus()

        Else

            trackPorcentage.Left = 150
            trackPorcentage.Visible = True

        End If

        trackPorcentage.Focus()

    End Sub

#End Region

End Class