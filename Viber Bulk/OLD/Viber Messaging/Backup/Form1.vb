Imports System.Threading

Public Class Form1

    ' --- Click mouse button programmatically

    Private Sub buttonLeft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonLeft.Click
        timerLeft.Enabled = True
    End Sub

    Private Sub buttonLeftStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonLeftStop.Click
        timerLeft.Enabled = False
    End Sub

    Private Sub timerLeft_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timerLeft.Tick
        Win32.mouse_event(Win32.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
        Thread.Sleep(100)
        Win32.mouse_event(Win32.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
    End Sub

    '

    Private Sub buttonRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonRight.Click
        timerRight.Enabled = True
    End Sub

    Private Sub buttonRightStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonRightStop.Click
        timerRight.Enabled = False
    End Sub

    Private Sub timerRight_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timerRight.Tick
        Win32.mouse_event(Win32.MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0)
        Thread.Sleep(100)
        Win32.mouse_event(Win32.MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0)
    End Sub

    '

    Private Sub buttonMiddle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonMiddle.Click
        timerMiddle.Enabled = True
    End Sub

    Private Sub buttonMiddleStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonMiddleStop.Click
        timerMiddle.Enabled = False
    End Sub

    Private Sub timerMiddle_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timerMiddle.Tick
        Win32.mouse_event(Win32.MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0)
        Thread.Sleep(100)
        Win32.mouse_event(Win32.MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0)
    End Sub

    '

    Private Sub buttonX_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonX.Click
        timerX.Enabled = True
    End Sub

    Private Sub buttonXStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonXStop.Click
        timerX.Enabled = False
    End Sub

    Private Sub timerX_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timerX.Tick
        Win32.mouse_event(Win32.MOUSEEVENTF_XDOWN, 0, 0, 0, 0)
        Thread.Sleep(100)
        Win32.mouse_event(Win32.MOUSEEVENTF_XUP, 0, 0, 0, 0)
    End Sub

    ' --- Check if mouse buttons and keys pressed

    Private Sub timerCheckKeys_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timerCheckKeys.Tick
        If Win32.GetAsyncKeyState(Keys.LButton) <> 0 Then
            textBoxCheckLeft.Text = "Left mouse button pressed"
        Else
            textBoxCheckLeft.Text = "Left mouse button not pressed"
        End If

        If Win32.GetAsyncKeyState(Keys.RButton) <> 0 Then
            textBoxCheckRight.Text = "Right mouse button pressed"
        Else
            textBoxCheckRight.Text = "Right mouse button not pressed"
        End If

        If Win32.GetAsyncKeyState(Keys.MButton) <> 0 Then
            textBoxCheckMiddle.Text = "Middle mouse button pressed"
        Else
            textBoxCheckMiddle.Text = "Middle mouse button not pressed"
        End If

        If Win32.GetAsyncKeyState(Keys.XButton1) <> 0 Then
            textBoxCheckX1.Text = "X1 mouse button pressed"
        Else
            textBoxCheckX1.Text = "X1 mouse button not pressed"
        End If

        If Win32.GetAsyncKeyState(Keys.XButton2) <> 0 Then
            textBoxCheckX2.Text = "X2 mouse button pressed"
        Else
            textBoxCheckX2.Text = "X2 mouse button not pressed"
        End If

        If Win32.GetAsyncKeyState(Keys.[Return]) <> 0 Then
            textBoxCheckEnter.Text = "ENTER key pressed"
        Else
            textBoxCheckEnter.Text = "ENTER key not pressed"
        End If
    End Sub

    '=======================================================
    'Service provided by Telerik (www.telerik.com)
    'Conversion powered by NRefactory.
    'Twitter: @telerik
    'Facebook: facebook.com/telerik
    '=======================================================
End Class
