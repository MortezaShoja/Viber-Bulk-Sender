Imports System
Imports System.Threading

Public Class Viber
    Private Countdowne As Integer = 0
    Private SQl As SQLCON
    Private cmd As Data.SqlClient.SqlCommand
    Private Sdr As Data.SqlClient.SqlDataReader
    Public StartStop As Boolean = False
    Public UserID As String

    Private Sub Viber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.btnSplash.Width = 263
        Me.btnSplash.Height = 506

        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Version.Text = "Viber Compatible Version : " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
        Copyright.Text = My.Application.Info.Copyright

        '-----------------------------------------------
        If Not System.IO.Directory.Exists("C:\ViberMessaging") Then
            System.IO.Directory.CreateDirectory("C:\ViberMessaging")
        End If

        If Not System.IO.Directory.Exists("C:\ViberMessaging\Images") Then
            System.IO.Directory.CreateDirectory("C:\ViberMessaging\Images")
        End If

        If Not System.IO.Directory.Exists("C:\ViberMessaging\Phonebooks") Then
            System.IO.Directory.CreateDirectory("C:\ViberMessaging\Phonebooks")
        End If

        If Not System.IO.Directory.Exists("C:\ViberMessaging\Messages") Then
            System.IO.Directory.CreateDirectory("C:\ViberMessaging\Messages")
        End If

        If Not System.IO.Directory.Exists("C:\ViberMessaging\System") Then

            System.IO.Directory.CreateDirectory("C:\ViberMessaging\System")

            Dim SW As New System.IO.StreamWriter("C:\ViberMessaging\System\LastSent.sys")
            SW.WriteLine(Now.AddMinutes(-Me.nuSleepTime.Value).ToString)
            SW.Flush()
            SW.Close()

            Dim SW2 As New System.IO.StreamWriter("C:\ViberMessaging\System\Locations.sys")
            SW2.WriteLine("335,150,270,225,325,450,530,590,420,590,580,100,1,1")
            SW2.Flush()
            SW2.Close()

            Dim SW3 As New System.IO.StreamWriter("C:\ViberMessaging\System\Log.sys")
            SW3.WriteLine("00989121000000")
            SW3.Flush()
            SW3.Close()

            Dim SW4 As New System.IO.StreamWriter("C:\ViberMessaging\System\Viber.sys")
            Dim User = System.Security.Principal.WindowsIdentity.GetCurrent.User
            Dim UserName() = User.Translate(GetType(System.Security.Principal.NTAccount)).Value.ToString.ToString.Split("\")
            SW4.WriteLine("C:\Users\" & UserName(1).ToString & "\AppData\Local\Viber\Viber.exe")
            SW4.Flush()
            SW4.Close()

        Else

            If Not System.IO.File.Exists("C:\ViberMessaging\System\LastSent.sys") Then
                Dim SW As New System.IO.StreamWriter("C:\ViberMessaging\System\LastSent.sys")
                SW.WriteLine(Now.AddMinutes(-Me.nuSleepTime.Value).ToString)
                SW.Flush()
                SW.Close()
            End If

            If Not System.IO.File.Exists("C:\ViberMessaging\System\Locations.sys") Then
                Dim SW2 As New System.IO.StreamWriter("C:\ViberMessaging\System\Locations.sys")
                SW2.WriteLine("335,150,270,225,325,450,530,590,420,590,580,100,30,40")
                SW2.Flush()
                SW2.Close()
            End If

            If Not System.IO.File.Exists("C:\ViberMessaging\System\Log.sys") Then
                Dim SW3 As New System.IO.StreamWriter("C:\ViberMessaging\System\Log.sys")
                SW3.WriteLine("00989121000000")
                SW3.Flush()
                SW3.Close()
            End If

            If Not System.IO.File.Exists("C:\ViberMessaging\System\Viber.sys") Then
                Dim SW4 As New System.IO.StreamWriter("C:\ViberMessaging\System\Viber.sys")
                Dim User = System.Security.Principal.WindowsIdentity.GetCurrent.User
                Dim UserName() = User.Translate(GetType(System.Security.Principal.NTAccount)).Value.ToString.ToString.Split("\")
                SW4.WriteLine("C:\Users\" & UserName(1).ToString & "\AppData\Local\Viber\Viber.exe")
                SW4.Flush()
                SW4.Close()
            End If

        End If



        Dim SR As New System.IO.StreamReader("C:\ViberMessaging\System\LastSent.sys")
        Me.lblLastSentTime.Text = SR.ReadLine
        SR.Close()

        ReadLastNumbers()

        FillPhonebooks()
        LocadLocations()
        FillLstImages()
        FillMessages()


        '--------------------  Load Viber ---------------------------
        'Dim SR3 As New System.IO.StreamReader("C:\ViberMessaging\System\Viber.sys")
        'Process.Start(SR3.ReadLine)
        'SR3.Close()


    End Sub

    Private Sub Viber_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    Private Sub Viber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(27) Then
            Me.timerPointing.Enabled = False
        End If
    End Sub

    Private Sub ReadLastNumbers()
        Dim SR2 As New System.IO.StreamReader("C:\ViberMessaging\System\Log.sys")
        Dim NU As String = SR2.ReadLine
        Me.txtAreaCode.Text = Mid(NU, 1, 4).ToString
        Me.txtPishShomare.Text = Mid(NU, 5, 3).ToString
        Me.txtNumber.Text = Mid(NU, 8, 7).ToString
        SR2.Close()
    End Sub

    Private Sub FillLstImages()
        Dim di As New IO.DirectoryInfo("C:\ViberMessaging\Images")
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        If diar1.Length > 0 Then
            If diar1.Length = 1 Then
                Me.btnOpenImagePlace.Text = "Open Pictures ( " & diar1.Length & " Image )"
            Else
                Me.btnOpenImagePlace.Text = "Open Pictures ( " & diar1.Length & " Images )"
            End If
        Else
            Me.btnOpenImagePlace.Text = "Open Pictures ( 0 Image )"
        End If
    End Sub

    Private Sub LocadLocations()
        Dim SR As New System.IO.StreamReader("C:\ViberMessaging\System\Locations.sys")
        Dim Locations() As String = SR.ReadLine.ToString.Split(",")
        SR.Close()

        Me.NuCallIconX.Value = Locations(0)
        Me.NuCallIconY.Value = Locations(1)
        Me.NuPhoneNumberBoxX.Value = Locations(2)
        Me.NuPhoneNumberBoxY.Value = Locations(3)
        Me.NuSendTextMessageIconX.Value = Locations(4)
        Me.NuSendTextMessageIconY.Value = Locations(5)
        Me.NuMessageLocationX.Value = Locations(6)
        Me.NuMessageLocationY.Value = Locations(7)
        Me.NuSendPhotoIconX.Value = Locations(8)
        Me.NuSendPhotoIconY.Value = Locations(9)
        Me.NuFreePlaceX.Value = Locations(10)
        Me.NuFreePlaceY.Value = Locations(11)
        Me.nuSleepTime.Value = Locations(12)
        Me.nuMessageCount.Value = Locations(13)

    End Sub

    Private Sub MoveCursor(ByVal X As Integer, ByVal Y As Integer)
        ' Set the Current cursor, move the cursor's Position, 
        ' and set its clipping rectangle to the form.  

        Me.Cursor = New Cursor(Cursor.Current.Handle)
        Cursor.Position = New Point(X, Y)
        ' Cursor.Clip = New Rectangle(Me.Location, Me.Size)
    End Sub

    Private Sub btnAutosending_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutosending.Click
        Me.btnSplash.Visible = True

        If Me.txtMessage.Text <> String.Empty Then
            'System.Threading.Thread.Sleep(1000)

            If rbManualNumbers.Checked = True Then
                Dim SW2 As New System.IO.StreamWriter("C:\ViberMessaging\System\Log.sys")
                SW2.WriteLine(Me.txtAreaCode.Text & Me.txtPishShomare.Text & Me.txtNumber.Text)
                SW2.Flush()
                SW2.Close()
                SendManualNumbers()
            End If

            If rbOfflinePhoneBook.Checked = True Then
                SendOfflinePhonebook()
            End If

            If rbOnlinePhoneBook.Checked = True Then

            End If
            Me.btnSplash.Visible = False
            MessageBox.Show("Sending messages was finished.", "Sent log", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            MessageBox.Show("Please write a message to send" & vbCrLf & "Then try again", "Message Text Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
        ReadLastNumbers()
    End Sub

    Private Sub SendManualNumbers()
        'Dim TypeOfLanguage = New System.Globalization.CultureInfo("en") ' or "fa-IR" for Farsi(Iran) 
        'InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(TypeOfLanguage)
        '263 506

        Me.btnSplash.Text = "Please whate while sending..."
        Me.btnSplash.Visible = True
        ReadLastNumbers()
        Try

            'Dim StartN As Integer = Integer.Parse(Me.txtNumber.Text)

            For J As Double = 1 To Me.NuManualSendCount.Value
                'If StartStop = True Then Exit Sub
                If J Mod Me.nuMessageCount.Value = 0 Then
                    'Threading.Thread.Sleep((Me.nuSleepTime.Value * 60) * 100)
                    Me.btnSplash.Visible = True
                    Me.timerReStart.Interval = (Me.nuSleepTime.Value * 60000)
                    Me.timerReStart.Enabled = True
                    Countdowne = Me.nuSleepTime.Value * 60000
                    Me.btnSplash.Text = "Please whate while finishing countdown" & vbCrLf & (Countdowne / 1000).ToString & " Seconds till restart sending.."
                    Me.timerCountdown.Enabled = True
                    Exit Sub
                End If
                SendMessage(Me.txtAreaCode.Text & Me.txtPishShomare.Text & (Double.Parse(Me.txtNumber.Text) + J).ToString)
            Next
        Catch ex As Exception
            MessageBox.Show("Mission Error" & vbCrLf & ex.Message.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
        End Try
    End Sub

    Private Sub SendOfflinePhonebook()
        'Dim TypeOfLanguage = New System.Globalization.CultureInfo("en") ' or "fa-IR" for Farsi(Iran) 
        'InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(TypeOfLanguage)

        Me.btnSplash.Text = "Please whate while sending..."

        Dim cop() As String = Me.cboOfflinePhonebook.Text.Split("_")
        Dim SR As New System.IO.StreamReader("C:\ViberMessaging\Phonebooks\" & cop(0) & ".txt")

        Try
            For J As Double = 1 To cop(1)
                'If StartStop = True Then Exit Sub
                'Dim J100 As Double = J Mod 100
                'If J100 = 0 Then
                '    Threading.Thread.Sleep((Me.nuSleepTime.Value * 60) * 100)
                'End If
                If J Mod Me.nuMessageCount.Value = 0 Then
                    'Threading.Thread.Sleep((Me.nuSleepTime.Value * 60) * 100)
                    Me.btnSplash.Visible = True
                    Me.timerReStart.Interval = (Me.nuSleepTime.Value * 60000)
                    Me.timerReStart.Enabled = True
                    Countdowne = Me.nuSleepTime.Value * 60000
                    Me.btnSplash.Text = "Please whate while finishing countdown" & vbCrLf & (Countdowne / 1000).ToString & " Seconds till restart sending.."
                    Me.timerCountdown.Enabled = True
                    Exit Sub
                End If
                SendMessage(SR.ReadLine.ToString)
            Next
        Catch ex As Exception
            MessageBox.Show("Mission Error" & vbCrLf & ex.Message.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
        End Try
    End Sub

    Private Sub SendMessage(ByVal Number As String)

        Dim TypeOfLanguage = New System.Globalization.CultureInfo("en") ' or "fa-IR" for Farsi(Iran) 
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(TypeOfLanguage)

        System.Threading.Thread.Sleep(1000)
        SendKeys.Send("{ESC}")

        MoveCursor(Me.NuCallIconX.Value, Me.NuCallIconY.Value) ' Move to Call Icon
        Win32.mouse_event(Win32.MOUSEEVENTF_LEFTDOWN, 50, 50, 50, 50)
        Threading.Thread.Sleep(100)
        Win32.mouse_event(Win32.MOUSEEVENTF_LEFTUP, 50, 50, 50, 50)
        Threading.Thread.Sleep(100)

        MoveCursor(Me.NuPhoneNumberBoxX.Value, Me.NuPhoneNumberBoxY.Value) ' Move to Phone Number Position
        My.Computer.Clipboard.SetText(Number)
        Threading.Thread.Sleep(100)

        Win32.mouse_event(Win32.MOUSEEVENTF_LEFTDOWN, 50, 50, 50, 50)
        Win32.mouse_event(Win32.MOUSEEVENTF_LEFTUP, 50, 50, 50, 50)
        Threading.Thread.Sleep(100)
        Win32.mouse_event(Win32.MOUSEEVENTF_LEFTDOWN, 50, 50, 50, 50)
        Win32.mouse_event(Win32.MOUSEEVENTF_LEFTUP, 50, 50, 50, 50)

        Threading.Thread.Sleep(100)
        SendKeys.Send("^(v)")
        Threading.Thread.Sleep(100)

        '--------------- Send Message ----------------
        MoveCursor(Me.NuSendTextMessageIconX.Value, Me.NuSendTextMessageIconY.Value) ' Move to Text Message Icon In Call Menu
        Win32.mouse_event(Win32.MOUSEEVENTF_LEFTDOWN, 50, 50, 50, 50)
        Threading.Thread.Sleep(100)
        Win32.mouse_event(Win32.MOUSEEVENTF_LEFTUP, 50, 50, 50, 50)

        MoveCursor(Me.NuMessageLocationX.Value, Me.NuMessageLocationY.Value) ' Move to Message Text Location
        Threading.Thread.Sleep(2000)
        My.Computer.Clipboard.SetText(Me.txtMessage.Text)

        Win32.mouse_event(Win32.MOUSEEVENTF_LEFTDOWN, 50, 50, 50, 50)
        Threading.Thread.Sleep(100)
        Win32.mouse_event(Win32.MOUSEEVENTF_LEFTUP, 50, 50, 50, 50)
        '-------------------- Sending ------------------------------

        Threading.Thread.Sleep(200)
        SendKeys.Send("^(v)")
        Threading.Thread.Sleep(200)
        SendKeys.Send("{ENTER}")
        Threading.Thread.Sleep(500)

        '------------ Selecting Images -------------

        Dim di As New IO.DirectoryInfo("C:\ViberMessaging\Images")
        Dim diar1 As IO.FileInfo() = di.GetFiles()

        If diar1.Length > 0 Then
            MoveCursor(Me.NuSendPhotoIconX.Value, Me.NuSendPhotoIconY.Value) ' Move to Send Photo Icon
            Threading.Thread.Sleep(100)

            For I = 0 To diar1.Length - 1

                SendKeys.Send("{ESC}")
                My.Computer.Clipboard.SetText("C:\ViberMessaging\Images\" & diar1(I).ToString)

                Win32.mouse_event(Win32.MOUSEEVENTF_LEFTDOWN, 50, 50, 50, 50)
                Threading.Thread.Sleep(100)
                Win32.mouse_event(Win32.MOUSEEVENTF_LEFTUP, 50, 50, 50, 50)

                Threading.Thread.Sleep(3000)
                SendKeys.Send("^(v)")
                Threading.Thread.Sleep(100)
                SendKeys.Send("{ENTER}")
                Threading.Thread.Sleep(3000)

            Next
        End If

        If Me.rbManualNumbers.Checked = True Then
            Dim SW2 As New System.IO.StreamWriter("C:\ViberMessaging\System\Log.sys")
            SW2.WriteLine(Number)
            SW2.Flush()
            SW2.Close()
        End If

        MoveCursor(Me.NuFreePlaceX.Value, Me.NuFreePlaceY.Value) ' Move to Top Free Place
        Win32.mouse_event(Win32.MOUSEEVENTF_LEFTDOWN, 50, 50, 50, 50)
        Threading.Thread.Sleep(100)
        Win32.mouse_event(Win32.MOUSEEVENTF_LEFTUP, 50, 50, 50, 50)
        Threading.Thread.Sleep(3000)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerPointing.Tick
        Dim MousePosition As Point
        MousePosition = Cursor.Position
        Me.lblMouseX.Text = MousePosition.X.ToString
        Me.lblMouseY.Text = MousePosition.Y.ToString
    End Sub

    Private Sub btnOpenImagePlace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenImagePlace.Click
        Process.Start("explorer.exe", "C:\ViberMessaging\Images")
        Me.TimerImageCount.Enabled = True
    End Sub

    Private Sub cboPhoneBook_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPhoneBook.SelectedIndexChanged
        FillNumbers()
    End Sub

    Private Sub FillNumbers()
        Try
            Me.lstPhone.Items.Clear()
            Dim SR As New System.IO.StreamReader("C:\ViberMessaging\Phonebooks\" & Me.cboPhoneBook.Text & ".txt")
            Try
                While SR.EndOfStream = False
                    Me.lstPhone.Items.Add(SR.ReadLine)
                End While
            Catch ex As Exception
                Me.lstPhone.Items.Clear()
            End Try
            SR.Close()
        Catch ex As Exception
            Me.lstPhone.Items.Clear()
        End Try

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If Me.cboPhoneBook.Text <> "" Then
                'If Integer.Parse(Me.txtPhoneNumber.Text) = True Then
                Dim SW As System.IO.StreamWriter = System.IO.File.AppendText("C:\ViberMessaging\Phonebooks\" & Me.cboPhoneBook.Text & ".txt")

                SW.WriteLine(Me.txtPhoneNumber.Text)
                SW.Flush()
                SW.Close()
                FillNumbers()
                'Else
                '    MessageBox.Show("Pelase write phone number in numeric format", "Syntax error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                'End If
                Me.txtPhoneNumber.Text = String.Empty
            Else
                MessageBox.Show("Please select a phone book", "Invalid phonebook name", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case Me.TabControl1.SelectedTab.Name.ToString
            Case Is = "tabPhoneBook"
                FillPhonebooks()
            Case Is = "tabMessages"
                FillMessages()
            Case Is = "tabLicence"
                FillLicence()
        End Select
    End Sub

    Private Sub FillLicence()
        SQl = New SQLCON
        Try
            cmd = New Data.SqlClient.SqlCommand("SELECT [Owner],[AccountType],[StartDate],[ExpireDate] FROM Members Where ID='" & UserID & "'", SQl.SqlCon)
            SQl.SqlCon.Open()
            'cmd.ExecuteNonQuery()
            Sdr = cmd.ExecuteReader
            While Sdr.Read
                Me.lblLicenceowner.Text = Sdr(0).ToString
                Me.lblLicencetype.Text = Sdr(1).ToString
                Me.lblLicenceStartDate.Text = Sdr(2).ToString
                Me.lblLicenceExpireDate.Text = Sdr(3).ToString
            End While
        Catch ex As Exception

        Finally
            SQl.SqlCon.Close()
        End Try
    End Sub

    Private Sub FillPhonebooks()
        Me.cboPhoneBook.Items.Clear()
        Me.cboOfflinePhonebook.Items.Clear()
        Me.cboPhoneBook.Text = String.Empty
        Me.cboOfflinePhonebook.Text = String.Empty
        Try
            Dim PhoneBooks() As String = System.IO.Directory.GetFiles("C:\ViberMessaging\Phonebooks")
            For I As Integer = 0 To PhoneBooks.Length - 1
                Dim F() As String = PhoneBooks(I).Split("\")
                Dim FN As String = F(F.Length - 1)
                Me.cboPhoneBook.Items.Add(Mid(FN, 1, FN.Length - 4))
                Try
                    Dim C As Integer = System.IO.File.ReadAllLines("C:\ViberMessaging\Phonebooks\" & FN).Length
                    Me.cboOfflinePhonebook.Items.Add(Mid(FN, 1, FN.Length - 4) & "_" & C)
                Catch ex As Exception
                    Me.cboOfflinePhonebook.Items.Add(Mid(FN, 1, FN.Length - 4) & "_" & 0)
                End Try

            Next
        Catch ex As Exception
            Me.cboPhoneBook.Items.Clear()
            Me.cboOfflinePhonebook.Items.Clear()
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            Dim lines() As String = System.IO.File.ReadAllLines("C:\ViberMessaging\Phonebooks\" & Me.cboPhoneBook.Text & ".txt")
            lines(Me.lstPhone.SelectedIndex) = Me.txtPhoneNumber.Text
            System.IO.File.WriteAllLines("C:\ViberMessaging\Phonebooks\" & Me.cboPhoneBook.Text & ".txt", lines)
            FillNumbers()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        DeletePhone()
    End Sub

    Private Sub DeletePhone()
        Try
            Dim line As String = Nothing
            Dim linesList As New List(Of String)(System.IO.File.ReadAllLines("C:\ViberMessaging\Phonebooks\" & Me.cboPhoneBook.Text & ".txt"))
            Dim SR As New System.IO.StreamReader("C:\ViberMessaging\Phonebooks\" & Me.cboPhoneBook.Text & ".txt")
            line = SR.ReadLine()
            For i As Integer = 0 To linesList.Count - 1
                If line.StartsWith(Me.lstPhone.Text) = True Then
                    SR.Dispose()
                    SR.Close()
                    linesList.RemoveAt(i)
                    System.IO.File.WriteAllLines("C:\ViberMessaging\Phonebooks\" & Me.cboPhoneBook.Text & ".txt", linesList.ToArray())
                    Exit For
                End If
                line = SR.ReadLine()
            Next i
            FillNumbers()
            SR.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstPhone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lstPhone.KeyPress
        If e.KeyChar = Chr(127) Then
            DeletePhone()
        End If
    End Sub

    Private Sub lstPhone_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPhone.SelectedIndexChanged
        Me.txtPhoneNumber.Text = Me.lstPhone.Text
    End Sub

    Private Sub btnDelPhonebook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelPhonebook.Click
        Try
            System.IO.File.Delete("C:\ViberMessaging\Phonebooks\" & Me.cboPhoneBook.Text & ".txt")
            FillPhonebooks()
            Me.txtPhonebookName.Text = String.Empty
            Me.cboPhoneBook.Text = String.Empty
            Me.lstPhone.Items.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEditPhonebook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditPhonebook.Click
        Try
            FileSystem.Rename("C:\ViberMessaging\Phonebooks\" & Me.cboPhoneBook.Text & ".txt", "C:\ViberMessaging\Phonebooks\" & Me.txtPhonebookName.Text & ".txt")
            FillPhonebooks()
            Me.cboPhoneBook.Text = Me.txtPhonebookName.Text
            Me.txtPhonebookName.Text = String.Empty
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAddPhonebook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPhonebook.Click
        Try
            If Me.txtPhonebookName.Text <> "" Then
                If System.IO.File.Exists("C:\ViberMessaging\Phonebooks\" & Me.txtPhonebookName.Text & ".txt") = False Then
                    Dim File As System.IO.FileStream = System.IO.File.Create("C:\ViberMessaging\Phonebooks\" & Me.txtPhonebookName.Text & ".txt")
                    File.Close()
                    FillPhonebooks()
                    Me.cboPhoneBook.Text = Me.txtPhonebookName.Text
                    Me.txtPhonebookName.Text = String.Empty
                Else
                    MessageBox.Show("This phonebook in alredy exist." & vbCrLf & "Please select diffrent phonebook name", "Phonebook exist", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If
            Else
                MessageBox.Show("Please fill phonebook name." & vbCrLf & "Then try again", "Syntax error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnSaveLocations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveLocations.Click
        Dim SW As New System.IO.StreamWriter("C:\ViberMessaging\System\Locations.sys")
        SW.WriteLine(Me.NuCallIconX.Value & "," & Me.NuCallIconY.Value & "," & Me.NuPhoneNumberBoxX.Value & "," & Me.NuPhoneNumberBoxY.Value & "," & Me.NuSendTextMessageIconX.Value & "," & Me.NuSendTextMessageIconY.Value & "," & Me.NuMessageLocationX.Value & "," & Me.NuMessageLocationY.Value & "," & Me.NuSendPhotoIconX.Value & "," & Me.NuSendPhotoIconY.Value & "," & Me.NuFreePlaceX.Value & "," & Me.NuFreePlaceY.Value & "," & Me.nuSleepTime.Value & "," & Me.nuMessageCount.Value)
        SW.Flush()
        SW.Close()
    End Sub

    Private Sub TimerImageCount_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerImageCount.Tick
        FillLstImages()
        Me.TimerImageCount.Enabled = False
    End Sub

    Private Sub NuManualSendCount_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuManualSendCount.ValueChanged
        Me.rbManualNumbers.Checked = True
    End Sub

    Private Sub cboOfflinePhonebook_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOfflinePhonebook.SelectedIndexChanged
        Me.rbOfflinePhoneBook.Checked = True
    End Sub

    Private Sub txtPishShomare_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.rbManualNumbers.Checked = True
    End Sub

    Private Sub txtFromNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.rbManualNumbers.Checked = True
    End Sub

    Private Sub cboOnlinePhonebook_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOnlinePhonebook.SelectedIndexChanged
        Me.rbOnlinePhoneBook.Checked = True
    End Sub

    Private Sub btnViberFileLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViberFileLocation.Click
        Me.OpenFileDialog1.ShowDialog()
        Dim VL As String = Me.OpenFileDialog1.FileName.ToString
        Dim SW As New System.IO.StreamWriter("C:\ViberMessaging\System\Viber.sys")
        SW.WriteLine(VL)
        SW.Flush()
        SW.Close()
    End Sub

    Private Sub rbOfflinePhoneBook_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbOfflinePhoneBook.CheckedChanged
        If Me.rbOfflinePhoneBook.Checked = True Then
            If Me.cboOfflinePhonebook.Items.Count >= 1 Then
                Me.cboOfflinePhonebook.Text = Me.cboOfflinePhonebook.Items.Item(0).ToString
            Else
                MessageBox.Show("Sorry we can't find any phonebook" & vbCrLf & "Please first add offline phonebook" & vbCrLf & "Then try againe", "Offline phonebook error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.rbManualNumbers.Checked = True
            End If
        End If
    End Sub

    Private Sub txtAreaCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAreaCode.TextChanged
        If Me.txtAreaCode.Text.Length > 4 Then
            MessageBox.Show("The area code cano`t be more than 4 digits", "Area code error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ReadLastNumbers()
        End If
    End Sub

    Private Sub txtPishShomare_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPishShomare.TextChanged
        If Me.txtPishShomare.Text.Length > 3 Then
            MessageBox.Show("The code cano`t be more than 3 digits", "Area code error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ReadLastNumbers()
        End If
    End Sub

    Private Sub txtNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumber.TextChanged
        If Me.txtNumber.Text.Length > 7 Then
            MessageBox.Show("The phone number cano`t be more than 7 digits", "Phone number error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ReadLastNumbers()
        End If
    End Sub

    Private Sub txtAreaCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAreaCode.KeyPress, txtPishShomare.KeyPress, txtAreaCode.KeyPress
        Dim tb As TextBox = CType(sender, TextBox)
        Dim chr As Char = e.KeyChar
        If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
            'If adding the character to the end of the current TextBox value results in
            ' a numeric value, go on. Otherwise, set e.Handled to True, and don't let
            ' the character to be added.
            e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
        ElseIf e.KeyChar = "." Then
            'For the decimal character (.) we need a different rule:
            'If adding a decimal to the end of the current value of the TextBox results
            ' in a numeric value, it can be added. If not, this means we already have a
            ' decimal in the TextBox value, so we only allow the new decimal to sit in
            ' when it is overwriting the previous decimal.
            If Not (tb.SelectedText = "." Or IsNumeric(tb.Text & e.KeyChar)) Then
                e.Handled = True
            End If
        ElseIf e.KeyChar = "-" Then
            'A negative sign is prevented if the "-" key is pressed in any location
            ' other than the begining of the number, or if the number already has a
            ' negative sign
            If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                e.Handled = True
            End If
        ElseIf Not Char.IsControl(e.KeyChar) Then
            'IsControl is checked, because without that, keys like BackSpace couldn't
            ' work correctly.
            e.Handled = True
        End If
    End Sub

    Private Sub timerMReStart_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerReStart.Tick
        'MessageBox.Show("Timer starts")
        Me.timerReStart.Enabled = False
        Me.btnSplash.Text = "Please whate while sending..."
        SendManualNumbers()
    End Sub

    Private Sub timerCountdown_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerCountdown.Tick
        If Countdowne < 60000 Then
            Me.btnSplash.Text = "Please whate while finishing countdown" & vbCrLf & (Countdowne / 1000).ToString & " Seconds till restart sending.."
        ElseIf Countdowne > 6000 Then
            Me.btnSplash.Text = "Please whate while finishing countdown" & vbCrLf & (Countdowne / 1000).ToString & " Seconds till restart sending.."
        ElseIf Countdowne <= 0 Then
            Me.timerCountdown.Enabled = False
            Me.btnSplash.Text = "Please whate while sending..."
        End If

        Countdowne -= 6000
        'If Countdowne <= 0 Then
        '    Me.timerCountdown.Enabled = False
        '    Me.btnSplash.Text = "Please whate while sending..."
        'End If

    End Sub

    Private Sub Viber_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        Me.Location = New Point(900, 50)
    End Sub

    Private Sub btnAddMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMessage.Click
        Try
            If Me.txtMessageSubject.Text <> "" Then
                If System.IO.File.Exists("C:\ViberMessaging\Messages\" & Me.txtMessageSubject.Text & ".txt") = False Then
                    'Dim File As System.IO.FileStream = System.IO.File.Create("C:\ViberMessaging\Messages\" & Me.txtMessageSubject.Text & ".txt")
                    'File.Close()
                    Dim Fmessage As New System.IO.StreamWriter("C:\ViberMessaging\Messages\" & Me.txtMessageSubject.Text & ".txt")
                    Fmessage.Write(Me.txtMessageText.Text)
                    Fmessage.Flush()
                    Fmessage.Close()

                    FillMessages()
                    Me.cboMessageSubjects.Text = Me.txtMessageSubject.Text
                    Me.txtMessageSubject.Text = String.Empty
                    Me.txtMessageText.Text = String.Empty
                Else
                    MessageBox.Show("This message in alredy exist." & vbCrLf & "Please select diffrent message name", "Message exist", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If
            Else
                MessageBox.Show("Please fill message name." & vbCrLf & "Then try again", "Syntax error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEditMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditMessage.Click
        Try
            If Not Me.cboMessageSubjects.Text = Me.txtMessageText.Text Then
                FileSystem.Rename("C:\ViberMessaging\Messages\" & Me.cboMessageSubjects.Text & ".txt", "C:\ViberMessaging\Messages\" & Me.txtMessageSubject.Text & ".txt")
            End If

            Dim Fmessage As New System.IO.StreamWriter("C:\ViberMessaging\Messages\" & Me.txtMessageSubject.Text & ".txt")
            Fmessage.Write(Me.txtMessageText.Text)
            Fmessage.Flush()
            Fmessage.Close()

            FillMessages()
            Me.cboMessageSubjects.Text = Me.txtMessageSubject.Text
            Me.txtMessageSubject.Text = String.Empty
            Me.txtMessageText.Text = String.Empty


            FillMessages()
            Me.cboMessageSubjects.Text = Me.txtMessageText.Text
            Me.txtMessageText.Text = String.Empty
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDeleteMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteMessage.Click
        Try
            System.IO.File.Delete("C:\ViberMessaging\Messages\" & Me.cboMessageSubjects.Text & ".txt")
            FillMessages()
            Me.cboMessageSubjects.Text = String.Empty
            Me.txtMessageSubject.Text = String.Empty
            Me.txtMessageText.Text = String.Empty
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillMessages()
        Me.cboMessageSubjects.Items.Clear()
        Me.cboMessageSubjects.Items.Add("")
        Me.cboMessageSubjects.Text = String.Empty

        Me.cboMessageSubjectSend.Items.Clear()
        Me.cboMessageSubjectSend.Items.Add("")
        Me.cboMessageSubjectSend.Text = String.Empty

        Try
            Dim Messages() As String = System.IO.Directory.GetFiles("C:\ViberMessaging\Messages")
            For I As Integer = 0 To Messages.Length - 1
                Dim F() As String = Messages(I).Split("\")
                Dim FN As String = F(F.Length - 1)
                Me.cboMessageSubjects.Items.Add(Mid(FN, 1, FN.Length - 4))
                Me.cboMessageSubjectSend.Items.Add(Mid(FN, 1, FN.Length - 4))
                'Try
                '    Dim C As Integer = System.IO.File.ReadAllLines("C:\ViberMessaging\Messages\" & FN).Length
                '    Me.cboMessageSubjectSend.Items.Add(Mid(FN, 1, FN.Length - 4) & "_" & C)
                'Catch ex As Exception
                '    Me.cboMessageSubjectSend.Items.Add(Mid(FN, 1, FN.Length - 4) & "_" & 0)
                'End Try

            Next
        Catch ex As Exception
            Me.cboMessageSubjects.Items.Clear()
            Me.cboMessageSubjectSend.Items.Clear()
        End Try
    End Sub



    Private Sub cboMessageSubjects_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMessageSubjects.SelectedIndexChanged
        Try
            Me.txtMessageText.Text = String.Empty
            Dim SR As New System.IO.StreamReader("C:\ViberMessaging\Messages\" & Me.cboMessageSubjects.Text & ".txt")
            Try
                Me.txtMessageText.Text = SR.ReadToEnd
            Catch ex As Exception
                Me.txtMessageText.Text = String.Empty
            End Try
            SR.Close()
            Me.txtMessageSubject.Text = Me.cboMessageSubjects.Text
        Catch ex As Exception
            Me.txtMessageText.Text = String.Empty
        End Try
    End Sub

    Private Sub cboMessageSubjectSend_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMessageSubjectSend.SelectedIndexChanged
        Try
            Me.txtMessage.Text = String.Empty
            Dim SR As New System.IO.StreamReader("C:\ViberMessaging\Messages\" & Me.cboMessageSubjectSend.Text & ".txt")
            Try
                Me.txtMessage.Text = SR.ReadToEnd
            Catch ex As Exception
                Me.txtMessage.Text = String.Empty
            End Try
            SR.Close()
        Catch ex As Exception
            Me.txtMessage.Text = String.Empty
        End Try
    End Sub
End Class