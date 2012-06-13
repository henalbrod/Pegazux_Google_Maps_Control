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

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintPreview
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.toolToolBar = New System.Windows.Forms.ToolStrip()
        Me.btnPrint = New System.Windows.Forms.ToolStripButton()
        Me.btnPageConfig = New System.Windows.Forms.ToolStripButton()
        Me.btnExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPorcentage = New System.Windows.Forms.ToolStripButton()
        Me.btnZoom = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFitToPage = New System.Windows.Forms.ToolStripButton()
        Me.btnFitToZoom = New System.Windows.Forms.ToolStripButton()
        Me.preView = New System.Windows.Forms.PrintPreviewControl()
        Me.PrintDialog = New System.Windows.Forms.PrintDialog()
        Me.trackZoom = New System.Windows.Forms.TrackBar()
        Me.PageSetupDialog = New System.Windows.Forms.PageSetupDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.trackPorcentage = New System.Windows.Forms.TrackBar()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblZoom = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblPorcentage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolToolBar.SuspendLayout()
        CType(Me.trackZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trackPorcentage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolToolBar
        '
        Me.toolToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolToolBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnPrint, Me.btnPageConfig, Me.btnExport, Me.ToolStripSeparator2, Me.btnPorcentage, Me.btnZoom, Me.ToolStripSeparator1, Me.btnFitToPage, Me.btnFitToZoom})
        Me.toolToolBar.Location = New System.Drawing.Point(0, 0)
        Me.toolToolBar.Name = "toolToolBar"
        Me.toolToolBar.Size = New System.Drawing.Size(691, 25)
        Me.toolToolBar.TabIndex = 0
        Me.toolToolBar.Text = "ToolStrip1"
        '
        'btnPrint
        '
        Me.btnPrint.Image = My.Resources.Resources.printer
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(73, 22)
        Me.btnPrint.Text = "Imprimir"
        '
        'btnPageConfig
        '
        Me.btnPageConfig.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnPageConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPageConfig.Image = My.Resources.Resources.gear
        Me.btnPageConfig.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPageConfig.Name = "btnPageConfig"
        Me.btnPageConfig.Size = New System.Drawing.Size(23, 22)
        Me.btnPageConfig.Text = "Configurar página"
        '
        'btnExport
        '
        Me.btnExport.Image = My.Resources.Resources.image_export
        Me.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(70, 22)
        Me.btnExport.Text = "Exportar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnPorcentage
        '
        Me.btnPorcentage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPorcentage.Image = My.Resources.Resources.layer_resize
        Me.btnPorcentage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPorcentage.Name = "btnPorcentage"
        Me.btnPorcentage.Size = New System.Drawing.Size(23, 22)
        Me.btnPorcentage.Text = "Escala"
        '
        'btnZoom
        '
        Me.btnZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoom.Image = My.Resources.Resources.magnifier_zoom_fit
        Me.btnZoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnZoom.Name = "btnZoom"
        Me.btnZoom.Size = New System.Drawing.Size(23, 22)
        Me.btnZoom.Text = "Zoom"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnFitToPage
        '
        Me.btnFitToPage.Checked = True
        Me.btnFitToPage.CheckOnClick = True
        Me.btnFitToPage.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnFitToPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFitToPage.Image = My.Resources.Resources.document_resize
        Me.btnFitToPage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFitToPage.Name = "btnFitToPage"
        Me.btnFitToPage.Size = New System.Drawing.Size(23, 22)
        Me.btnFitToPage.Text = "Ajustar a página"
        '
        'btnFitToZoom
        '
        Me.btnFitToZoom.CheckOnClick = True
        Me.btnFitToZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFitToZoom.Image = My.Resources.Resources.document_resize_actual
        Me.btnFitToZoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFitToZoom.Name = "btnFitToZoom"
        Me.btnFitToZoom.Size = New System.Drawing.Size(23, 22)
        Me.btnFitToZoom.Text = "Ajustar a zoom"
        '
        'preView
        '
        Me.preView.AutoZoom = False
        Me.preView.BackColor = System.Drawing.Color.Gray
        Me.preView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.preView.Location = New System.Drawing.Point(0, 25)
        Me.preView.Name = "preView"
        Me.preView.Size = New System.Drawing.Size(691, 457)
        Me.preView.TabIndex = 2
        Me.preView.Zoom = 0.7R
        '
        'PrintDialog
        '
        Me.PrintDialog.UseEXDialog = True
        '
        'trackZoom
        '
        Me.trackZoom.AutoSize = False
        Me.trackZoom.BackColor = System.Drawing.SystemColors.Control
        Me.trackZoom.Location = New System.Drawing.Point(172, 28)
        Me.trackZoom.Maximum = 500
        Me.trackZoom.Minimum = 1
        Me.trackZoom.Name = "trackZoom"
        Me.trackZoom.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trackZoom.Size = New System.Drawing.Size(23, 194)
        Me.trackZoom.TabIndex = 0
        Me.trackZoom.TickStyle = System.Windows.Forms.TickStyle.None
        Me.trackZoom.Value = 70
        Me.trackZoom.Visible = False
        '
        'PageSetupDialog
        '
        Me.PageSetupDialog.EnableMetric = True
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.FileName = "Google Map.png"
        Me.SaveFileDialog.Filter = "PNG (*.png)|*.png"
        Me.SaveFileDialog.Title = "Exportar a imágen"
        '
        'trackPorcentage
        '
        Me.trackPorcentage.AutoSize = False
        Me.trackPorcentage.BackColor = System.Drawing.SystemColors.Control
        Me.trackPorcentage.LargeChange = 20
        Me.trackPorcentage.Location = New System.Drawing.Point(150, 28)
        Me.trackPorcentage.Maximum = 500
        Me.trackPorcentage.Minimum = 1
        Me.trackPorcentage.Name = "trackPorcentage"
        Me.trackPorcentage.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trackPorcentage.Size = New System.Drawing.Size(23, 194)
        Me.trackPorcentage.TabIndex = 3
        Me.trackPorcentage.TickStyle = System.Windows.Forms.TickStyle.None
        Me.trackPorcentage.Value = 100
        Me.trackPorcentage.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblZoom, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.lblPorcentage})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 482)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(691, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(42, 17)
        Me.ToolStripStatusLabel1.Text = "Zoom:"
        '
        'lblZoom
        '
        Me.lblZoom.BackColor = System.Drawing.Color.Transparent
        Me.lblZoom.Name = "lblZoom"
        Me.lblZoom.Size = New System.Drawing.Size(23, 17)
        Me.lblZoom.Text = "0%"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(31, 17)
        Me.ToolStripStatusLabel3.Text = "        "
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(42, 17)
        Me.ToolStripStatusLabel4.Text = "Escala:"
        '
        'lblPorcentage
        '
        Me.lblPorcentage.BackColor = System.Drawing.Color.Transparent
        Me.lblPorcentage.Name = "lblPorcentage"
        Me.lblPorcentage.Size = New System.Drawing.Size(23, 17)
        Me.lblPorcentage.Text = "0%"
        '
        'frmPrintPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(691, 504)
        Me.Controls.Add(Me.trackPorcentage)
        Me.Controls.Add(Me.trackZoom)
        Me.Controls.Add(Me.preView)
        Me.Controls.Add(Me.toolToolBar)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "frmPrintPreview"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Preview - Google Maps Control"
        Me.toolToolBar.ResumeLayout(False)
        Me.toolToolBar.PerformLayout()
        CType(Me.trackZoom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trackPorcentage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toolToolBar As System.Windows.Forms.ToolStrip
    Friend WithEvents btnPageConfig As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents preView As System.Windows.Forms.PrintPreviewControl
    Friend WithEvents PrintDialog As System.Windows.Forms.PrintDialog
    Friend WithEvents trackZoom As System.Windows.Forms.TrackBar
    Friend WithEvents btnFitToPage As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnFitToZoom As System.Windows.Forms.ToolStripButton
    Friend WithEvents PageSetupDialog As System.Windows.Forms.PageSetupDialog
    Friend WithEvents btnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnZoom As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPorcentage As System.Windows.Forms.ToolStripButton
    Friend WithEvents trackPorcentage As System.Windows.Forms.TrackBar
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblZoom As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblPorcentage As System.Windows.Forms.ToolStripStatusLabel
End Class
