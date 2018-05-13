Public Class Main

    Public UserID As String


    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            'If the application title is missing, use the application name, without the extension
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '  Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        Me.Version.Text = "Viber Compatible Version : " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
        'Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Copyright info
        Copyright.Text = My.Application.Info.Copyright
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub txtP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtP.KeyPress
        If e.KeyChar = Chr(13) Then
            lOGIN()
        End If
    End Sub

    Private Sub lOGIN()
        Dim CI As New GetComputerID
        Dim SQL As New SQLCON
        Dim cmd As New SqlClient.SqlCommand("Exec MemberLogin N'" & txtU.Text & "'", SQL.SqlCon)
        SQL.SqlCon.Open()
        Dim sdr As SqlClient.SqlDataReader = cmd.ExecuteReader

        If sdr.Read Then
            If Me.txtU.Text = sdr(1).ToString And Me.txtP.Text = sdr(2).ToString Then
                If sdr(3) < Now Then
                    MessageBox.Show("Your account is expired.", "Login problem", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                If sdr(4).ToString = "" Then
                    UserID = sdr(0).ToString
                    SetComputerID()
                ElseIf sdr(4).ToString = CI.CPUId.ToString.ToString Then
                    UserID = sdr(0).ToString
                Else
                    Me.txtU.Focus()
                    Me.txtP.Text = ""
                    Me.txtU.Text = ""
                    MessageBox.Show("Invalid computerID" & vbCrLf & "Please try to use application in first installation computer" & vbCrLf & "Or contact with us at Info@viber20.com to remove your old computerID", " CpmouterID problem", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

            Else
                MessageBox.Show("Invalid username or password.", "Login problem", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.txtP.Text = ""
                Me.txtU.Text = ""
                Me.txtU.Focus()
            End If

        Else
            Me.txtP.Text = ""
            Me.txtU.Text = ""
            Me.txtU.Focus()
        End If

        SQL.SqlCon.Close()

        If UserID <> "" Then
            Dim frm As New Viber
            Me.Visible = False
            Viber.Location = New Point(900, 50)
            Viber.UserID = UserID
            Viber.Show()
        End If

    End Sub

    Private Sub SetComputerID()

        Dim CI As New GetComputerID
        'MessageBox.Show(CI.CPUId.ToString)
        If IsNothing(CI.CPUId.ToString) = False Then
            Dim SQLL As New SQLCON
            Try
                Dim cmdD As New SqlClient.SqlCommand("Update Members Set ComputerID='" & CI.CPUId.ToString & "' Where ID='" & UserID.ToString & "' And Computerid  is null ", SQLL.SqlCon)
                SQLL.SqlCon.Open()
                cmdD.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString)
            Finally
                SQLL.SqlCon.Close()
            End Try
            MessageBox.Show("Your computerID is registered" & vbCrLf & "Now you can use ViberBulk.", "ComputerID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            MessageBox.Show("Your computer doesn't register" & vbCrLf & "It seems you use application in virtual OS like Vmware" & vbCrLf & "Please try to use in a real OS.", "ComputerID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If

    End Sub
    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        lOGIN()
    End Sub
End Class