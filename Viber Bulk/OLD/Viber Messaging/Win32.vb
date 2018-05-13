Imports System.Runtime.InteropServices

Class Win32
    ' Mouse

    Public Const MOUSEEVENTF_ABSOLUTE As UInteger = &H8000
    Public Const MOUSEEVENTF_LEFTDOWN As UInteger = &H2
    Public Const MOUSEEVENTF_LEFTUP As UInteger = &H4
    Public Const MOUSEEVENTF_MIDDLEDOWN As UInteger = &H20
    Public Const MOUSEEVENTF_MIDDLEUP As UInteger = &H40
    Public Const MOUSEEVENTF_MOVE As UInteger = &H1
    Public Const MOUSEEVENTF_RIGHTDOWN As UInteger = &H8
    Public Const MOUSEEVENTF_RIGHTUP As UInteger = &H10
    Public Const MOUSEEVENTF_XDOWN As UInteger = &H80
    Public Const MOUSEEVENTF_XUP As UInteger = &H100
    Public Const MOUSEEVENTF_WHEEL As UInteger = &H800
    Public Const MOUSEEVENTF_HWHEEL As UInteger = &H1000

    <DllImport("user32.dll")> _
    Public Shared Sub mouse_event(ByVal dwFlags As UInteger, ByVal dx As UInteger, ByVal dy As UInteger, ByVal dwData As UInteger, ByVal dwExtraInfo As Integer)
    End Sub

    ' Check mouse buttons & keys if pressed
    <DllImport("user32.dll")> _
    Public Shared Function GetAsyncKeyState(ByVal vKey As System.Windows.Forms.Keys) As Short
    End Function
End Class

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================