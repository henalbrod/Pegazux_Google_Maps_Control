
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

Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.IO

<Serializable()> _
Friend Class Print
    Implements IDisposable

#Region "Declare"

    Dim t_image As Image

    Private v_handle As System.IntPtr
    Private v_mapArea As System.Drawing.Rectangle
    Private v_parentArea As System.Drawing.Rectangle
    Private v_porcentage As Integer = 100

#End Region

#Region "Procedure"

    Public Sub Print(ByVal handler As System.IntPtr, ByVal mapArea As Rectangle, ByVal parentArea As Rectangle, Optional ByVal porcentage As Integer = 100)

        v_handle = handler
        v_mapArea = mapArea
        v_parentArea = parentArea
        v_porcentage = porcentage

        Dim t_print_Document As PrintDocument = GetPrintDocument(handler, mapArea, parentArea, porcentage)

        AddHandler t_print_Document.PrintPage, AddressOf print_PrintPage

        t_print_Document.Print()

    End Sub

    Public Function GetPrintDocument(ByVal handler As System.IntPtr, ByVal mapArea As Rectangle, ByVal parentArea As Rectangle, Optional ByVal porcentage As Integer = 100) As PrintDocument

        v_handle = handler
        v_mapArea = mapArea
        v_parentArea = parentArea
        v_porcentage = porcentage

        Dim t_print_Preview As New PrintPreviewDialog
        Dim t_print_Document As New PrintDocument
        Dim t_defaultPageSettings As PageSettings

        If My.Settings.Print_DafaultPageSetup = vbNullString Then

            t_defaultPageSettings = (New System.Drawing.Printing.PrinterSettings).DefaultPageSettings

            t_defaultPageSettings.Landscape = True
            t_defaultPageSettings.Margins = New System.Drawing.Printing.Margins(10, 10, 15, 20)
            t_defaultPageSettings.PaperSize = New System.Drawing.Printing.PaperSize("Letter", 850, 1100)
            t_defaultPageSettings.PrinterResolution = New PrinterResolution With {.X = 300, .Y = 300}

            My.Settings.Print_DafaultPageSetup = SerializeToSoap(t_defaultPageSettings)

            My.Settings.Save()

        Else

            t_defaultPageSettings = DeSerializeFromSoap(My.Settings.Print_DafaultPageSetup)

        End If

        t_print_Document.DefaultPageSettings = t_defaultPageSettings
        t_print_Document.OriginAtMargins = True

        AddHandler t_print_Document.PrintPage, AddressOf print_PrintPage

        Return t_print_Document

    End Function

    Public Function GetBitMap(ByVal handler As System.IntPtr, ByVal mapArea As Rectangle, ByVal parentArea As Rectangle, Optional ByVal porcentage As Integer = 100) As Image

        v_handle = handler
        v_mapArea = mapArea
        v_parentArea = parentArea
        v_porcentage = porcentage

        Return GetPrintableArea(ScreenCapture.CaptureWindow(v_handle))

    End Function

    Private Sub print_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)

        Dim t_image As Image = GetPrintableArea(ScreenCapture.CaptureWindow(v_handle))
        Dim t_footerTop As Integer = (e.PageSettings.Bounds.Height - e.PageSettings.Margins.Bottom) - 32

        e.Graphics.DrawImage(t_image, 0, 0)
        e.Graphics.DrawString("Pegazux Google Maps .Net Control", New Font("Arial", 8), Brushes.Black, 0, t_footerTop)

        e.HasMorePages = False

    End Sub

    Private Function GetPrintableArea(ByVal value As Image) As Image

        If v_porcentage <= 1 Then v_porcentage = 100
        If v_porcentage > 500 Then v_porcentage = 100

        Dim t_grafics As Graphics

        Dim t_original As Image = value
        Dim t_recorte As New Bitmap(v_mapArea.Size.Width, v_mapArea.Size.Height)
        Dim t_areaRecorte As New Rectangle(New Point(v_mapArea.Location.X + 7, v_mapArea.Location.Y + 30), v_mapArea.Size)

        t_grafics = Graphics.FromImage(t_recorte)

        t_grafics.DrawImage(t_original, 0, 0, t_areaRecorte, GraphicsUnit.Pixel)

        If v_porcentage <> 100 Then

            Dim t_resizedBitMap As New Bitmap(CInt(t_recorte.Size.Width * (v_porcentage * 0.01)), CInt(t_recorte.Size.Height * (v_porcentage * 0.01)))

            t_grafics = Graphics.FromImage(t_resizedBitMap)
            t_grafics.DrawImage(t_recorte, 0, 0, t_resizedBitMap.Width, t_resizedBitMap.Height)

            t_recorte = t_resizedBitMap

        End If

        t_grafics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy
        t_grafics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        t_grafics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        t_grafics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

        Return t_recorte

    End Function

    ''' <summary>
    ''' Provides functions to capture the entire screen, or a particular window, and save it to a file.
    ''' </summary>
    Private Class ScreenCapture

        ''' <summary>
        ''' Creates an Image object containing a screen shot of the entire desktop
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function CaptureScreen() As Image
            Return CaptureWindow(User32.GetDesktopWindow())
        End Function

        ''' <summary>
        ''' Creates an Image object containing a screen shot of a specific window
        ''' </summary>
        ''' <param name="handle">The handle to the window. (In windows forms, this is obtained by the Handle property)</param>
        ''' <returns></returns>
        Public Shared Function CaptureWindow(ByVal handle As IntPtr) As Image
            ' get te hDC of the target window
            Dim hdcSrc As IntPtr = User32.GetWindowDC(handle)
            ' get the size
            Dim windowRect As New User32.RECT()
            User32.GetWindowRect(handle, windowRect)

            Dim width As Integer = windowRect.right - windowRect.left
            Dim height As Integer = windowRect.bottom - windowRect.top

            ' create a device context we can copy to
            Dim hdcDest As IntPtr = GDI32.CreateCompatibleDC(hdcSrc)
            ' create a bitmap we can copy it to,
            ' using GetDeviceCaps to get the width/height
            Dim hBitmap As IntPtr = GDI32.CreateCompatibleBitmap(hdcSrc, width, height)
            ' select the bitmap object
            Dim hOld As IntPtr = GDI32.SelectObject(hdcDest, hBitmap)
            ' bitblt over
            GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, _
             0, 0, GDI32.SRCCOPY)
            ' restore selection
            GDI32.SelectObject(hdcDest, hOld)
            ' clean up 
            GDI32.DeleteDC(hdcDest)
            User32.ReleaseDC(handle, hdcSrc)
            ' get a .NET image object for it
            Dim img As Image = Image.FromHbitmap(hBitmap)
            ' free up the Bitmap object
            GDI32.DeleteObject(hBitmap)
            Return img
        End Function

        ''' <summary>
        ''' Captures a screen shot of a specific window, and saves it to a file
        ''' </summary>
        ''' <param name="handle"></param>
        ''' <param name="filename"></param>
        ''' <param name="format"></param>
        Public Shared Sub CaptureWindowToFile(ByVal handle As IntPtr, ByVal filename As String, ByVal format As ImageFormat)
            Dim img As Image = CaptureWindow(handle)
            img.Save(filename, format)
        End Sub

        ''' <summary>
        ''' Captures a screen shot of the entire desktop, and saves it to a file
        ''' </summary>
        ''' <param name="filename"></param>
        ''' <param name="format"></param>
        Public Shared Sub CaptureScreenToFile(ByVal filename As String, ByVal format As ImageFormat)
            Dim img As Image = CaptureScreen()
            img.Save(filename, format)
        End Sub

        ''' <summary>
        ''' Helper class containing Gdi32 API functions
        ''' </summary>
        Private Class GDI32

            Public Const SRCCOPY As Integer = &HCC0020
            ' BitBlt dwRop parameter
            <DllImport("gdi32.dll")> _
            Public Shared Function BitBlt(ByVal hObject As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hObjectSource As IntPtr, _
    ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As Integer) As Boolean
            End Function
            <DllImport("gdi32.dll")> _
            Public Shared Function CreateCompatibleBitmap(ByVal hDC As IntPtr, ByVal nWidth As Integer, ByVal nHeight As Integer) As IntPtr
            End Function
            <DllImport("gdi32.dll")> _
            Public Shared Function CreateCompatibleDC(ByVal hDC As IntPtr) As IntPtr
            End Function
            <DllImport("gdi32.dll")> _
            Public Shared Function DeleteDC(ByVal hDC As IntPtr) As Boolean
            End Function
            <DllImport("gdi32.dll")> _
            Public Shared Function DeleteObject(ByVal hObject As IntPtr) As Boolean
            End Function
            <DllImport("gdi32.dll")> _
            Public Shared Function SelectObject(ByVal hDC As IntPtr, ByVal hObject As IntPtr) As IntPtr
            End Function
        End Class

        ''' <summary>
        ''' Helper class containing User32 API functions
        ''' </summary>
        Private Class User32
            <StructLayout(LayoutKind.Sequential)> _
            Public Structure RECT
                Public left As Integer
                Public top As Integer
                Public right As Integer
                Public bottom As Integer
            End Structure
            <DllImport("user32.dll")> _
            Public Shared Function GetDesktopWindow() As IntPtr
            End Function
            <DllImport("user32.dll")> _
            Public Shared Function GetWindowDC(ByVal hWnd As IntPtr) As IntPtr
            End Function
            <DllImport("user32.dll")> _
            Public Shared Function ReleaseDC(ByVal hWnd As IntPtr, ByVal hDC As IntPtr) As IntPtr
            End Function
            <DllImport("user32.dll")> _
            Public Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef rect As RECT) As IntPtr
            End Function
        End Class

    End Class

#End Region

#Region "IDisposable Support"
    Private disposedValue As Boolean ' Para detectar llamadas redundantes

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                v_handle = Nothing
                v_mapArea = Nothing
                v_parentArea = Nothing
            End If
        End If
        Me.disposedValue = True
    End Sub


    ' Visual Basic agregó este código para implementar correctamente el modelo descartable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' No cambie este código. Coloque el código de limpieza en Dispose (ByVal que se dispone como Boolean).
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class