
Imports System.Windows

Module AppLocation

    Public Declare Function MoveWindow Lib "user32" (ByVal hwnd As Int32, ByVal x As Long, ByVal y As Long, ByVal nWidth As Long, ByVal nHeight As Long, ByVal bRepaint As Boolean) As Boolean

    Friend ApplicationProcess As System.Diagnostics.Process
    Friend ApplicationHandle As Long

    Public Function OpenApplication()
        ApplicationProcess = System.Diagnostics.Process.Start("C:\Viber\Viber.4.2.2.6\viber.exe")
        System.Threading.Thread.Sleep(1000)
        ApplicationHandle = ApplicationProcess.MainWindowHandle
        MoveWindow(ApplicationHandle, 0, 20, 20, 0, True)
        Return (True)
    End Function

End Module

