<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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


    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.buttonXStop = New System.Windows.Forms.Button()
        Me.buttonMiddleStop = New System.Windows.Forms.Button()
        Me.buttonRightStop = New System.Windows.Forms.Button()
        Me.buttonLeftStop = New System.Windows.Forms.Button()
        Me.buttonX = New System.Windows.Forms.Button()
        Me.buttonMiddle = New System.Windows.Forms.Button()
        Me.buttonRight = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.buttonLeft = New System.Windows.Forms.Button()
        Me.timerLeft = New System.Windows.Forms.Timer(Me.components)
        Me.timerRight = New System.Windows.Forms.Timer(Me.components)
        Me.timerMiddle = New System.Windows.Forms.Timer(Me.components)
        Me.timerX = New System.Windows.Forms.Timer(Me.components)
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.textBoxCheckX2 = New System.Windows.Forms.TextBox()
        Me.textBoxCheckEnter = New System.Windows.Forms.TextBox()
        Me.textBoxCheckX1 = New System.Windows.Forms.TextBox()
        Me.textBoxCheckMiddle = New System.Windows.Forms.TextBox()
        Me.textBoxCheckRight = New System.Windows.Forms.TextBox()
        Me.textBoxCheckLeft = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.timerCheckKeys = New System.Windows.Forms.Timer(Me.components)
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.buttonXStop)
        Me.groupBox1.Controls.Add(Me.buttonMiddleStop)
        Me.groupBox1.Controls.Add(Me.buttonRightStop)
        Me.groupBox1.Controls.Add(Me.buttonLeftStop)
        Me.groupBox1.Controls.Add(Me.buttonX)
        Me.groupBox1.Controls.Add(Me.buttonMiddle)
        Me.groupBox1.Controls.Add(Me.buttonRight)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.buttonLeft)
        Me.groupBox1.Location = New System.Drawing.Point(12, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(531, 130)
        Me.groupBox1.TabIndex = 0
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Click mouse button programmatically"
        '
        'buttonXStop
        '
        Me.buttonXStop.Location = New System.Drawing.Point(387, 88)
        Me.buttonXStop.Name = "buttonXStop"
        Me.buttonXStop.Size = New System.Drawing.Size(121, 33)
        Me.buttonXStop.TabIndex = 9
        Me.buttonXStop.Text = "Stop this test"
        Me.buttonXStop.UseVisualStyleBackColor = True
        '
        'buttonMiddleStop
        '
        Me.buttonMiddleStop.Location = New System.Drawing.Point(260, 88)
        Me.buttonMiddleStop.Name = "buttonMiddleStop"
        Me.buttonMiddleStop.Size = New System.Drawing.Size(121, 33)
        Me.buttonMiddleStop.TabIndex = 8
        Me.buttonMiddleStop.Text = "Stop this test"
        Me.buttonMiddleStop.UseVisualStyleBackColor = True
        '
        'buttonRightStop
        '
        Me.buttonRightStop.Location = New System.Drawing.Point(133, 88)
        Me.buttonRightStop.Name = "buttonRightStop"
        Me.buttonRightStop.Size = New System.Drawing.Size(121, 33)
        Me.buttonRightStop.TabIndex = 7
        Me.buttonRightStop.Text = "Stop this test"
        Me.buttonRightStop.UseVisualStyleBackColor = True
        '
        'buttonLeftStop
        '
        Me.buttonLeftStop.Location = New System.Drawing.Point(6, 88)
        Me.buttonLeftStop.Name = "buttonLeftStop"
        Me.buttonLeftStop.Size = New System.Drawing.Size(121, 33)
        Me.buttonLeftStop.TabIndex = 6
        Me.buttonLeftStop.Text = "Stop this test"
        Me.buttonLeftStop.UseVisualStyleBackColor = True
        '
        'buttonX
        '
        Me.buttonX.Location = New System.Drawing.Point(387, 49)
        Me.buttonX.Name = "buttonX"
        Me.buttonX.Size = New System.Drawing.Size(121, 33)
        Me.buttonX.TabIndex = 5
        Me.buttonX.Text = "Test for X button"
        Me.buttonX.UseVisualStyleBackColor = True
        '
        'buttonMiddle
        '
        Me.buttonMiddle.Location = New System.Drawing.Point(260, 49)
        Me.buttonMiddle.Name = "buttonMiddle"
        Me.buttonMiddle.Size = New System.Drawing.Size(121, 33)
        Me.buttonMiddle.TabIndex = 4
        Me.buttonMiddle.Text = "Test for middle button"
        Me.buttonMiddle.UseVisualStyleBackColor = True
        '
        'buttonRight
        '
        Me.buttonRight.Location = New System.Drawing.Point(133, 49)
        Me.buttonRight.Name = "buttonRight"
        Me.buttonRight.Size = New System.Drawing.Size(121, 33)
        Me.buttonRight.TabIndex = 3
        Me.buttonRight.Text = "Test for right button"
        Me.buttonRight.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(6, 21)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(277, 13)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Mouse button will click in current coordinates every 1 sec"
        '
        'buttonLeft
        '
        Me.buttonLeft.Location = New System.Drawing.Point(6, 49)
        Me.buttonLeft.Name = "buttonLeft"
        Me.buttonLeft.Size = New System.Drawing.Size(121, 33)
        Me.buttonLeft.TabIndex = 1
        Me.buttonLeft.Text = "Test for left button"
        Me.buttonLeft.UseVisualStyleBackColor = True
        '
        'timerLeft
        '
        Me.timerLeft.Interval = 1000
        '
        'timerRight
        '
        Me.timerRight.Interval = 1000
        '
        'timerMiddle
        '
        Me.timerMiddle.Interval = 1000
        '
        'timerX
        '
        Me.timerX.Interval = 1000
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.textBoxCheckX2)
        Me.groupBox2.Controls.Add(Me.textBoxCheckEnter)
        Me.groupBox2.Controls.Add(Me.textBoxCheckX1)
        Me.groupBox2.Controls.Add(Me.textBoxCheckMiddle)
        Me.groupBox2.Controls.Add(Me.textBoxCheckRight)
        Me.groupBox2.Controls.Add(Me.textBoxCheckLeft)
        Me.groupBox2.Controls.Add(Me.label2)
        Me.groupBox2.Location = New System.Drawing.Point(12, 148)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(531, 92)
        Me.groupBox2.TabIndex = 1
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Check if mouse buttons and keys pressed"
        '
        'textBoxCheckX2
        '
        Me.textBoxCheckX2.Location = New System.Drawing.Point(361, 32)
        Me.textBoxCheckX2.Name = "textBoxCheckX2"
        Me.textBoxCheckX2.Size = New System.Drawing.Size(164, 20)
        Me.textBoxCheckX2.TabIndex = 6
        '
        'textBoxCheckEnter
        '
        Me.textBoxCheckEnter.Location = New System.Drawing.Point(361, 58)
        Me.textBoxCheckEnter.Name = "textBoxCheckEnter"
        Me.textBoxCheckEnter.Size = New System.Drawing.Size(164, 20)
        Me.textBoxCheckEnter.TabIndex = 5
        '
        'textBoxCheckX1
        '
        Me.textBoxCheckX1.Location = New System.Drawing.Point(185, 58)
        Me.textBoxCheckX1.Name = "textBoxCheckX1"
        Me.textBoxCheckX1.Size = New System.Drawing.Size(170, 20)
        Me.textBoxCheckX1.TabIndex = 4
        '
        'textBoxCheckMiddle
        '
        Me.textBoxCheckMiddle.Location = New System.Drawing.Point(185, 32)
        Me.textBoxCheckMiddle.Name = "textBoxCheckMiddle"
        Me.textBoxCheckMiddle.Size = New System.Drawing.Size(170, 20)
        Me.textBoxCheckMiddle.TabIndex = 3
        '
        'textBoxCheckRight
        '
        Me.textBoxCheckRight.Location = New System.Drawing.Point(9, 58)
        Me.textBoxCheckRight.Name = "textBoxCheckRight"
        Me.textBoxCheckRight.Size = New System.Drawing.Size(170, 20)
        Me.textBoxCheckRight.TabIndex = 2
        '
        'textBoxCheckLeft
        '
        Me.textBoxCheckLeft.Location = New System.Drawing.Point(9, 32)
        Me.textBoxCheckLeft.Name = "textBoxCheckLeft"
        Me.textBoxCheckLeft.Size = New System.Drawing.Size(170, 20)
        Me.textBoxCheckLeft.TabIndex = 1
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(6, 16)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(434, 13)
        Me.label2.TabIndex = 0
        Me.label2.Text = "Try press left, right, middle, X mouse button, or ENTER key in any window or just" & _
            " in screen."
        '
        'timerCheckKeys
        '
        Me.timerCheckKeys.Enabled = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 255)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents buttonLeft As System.Windows.Forms.Button
    Private WithEvents buttonX As System.Windows.Forms.Button
    Private WithEvents buttonMiddle As System.Windows.Forms.Button
    Private WithEvents buttonRight As System.Windows.Forms.Button
    Private WithEvents timerLeft As System.Windows.Forms.Timer
    Private WithEvents timerRight As System.Windows.Forms.Timer
    Private WithEvents timerMiddle As System.Windows.Forms.Timer
    Private WithEvents timerX As System.Windows.Forms.Timer
    Private WithEvents buttonXStop As System.Windows.Forms.Button
    Private WithEvents buttonMiddleStop As System.Windows.Forms.Button
    Private WithEvents buttonRightStop As System.Windows.Forms.Button
    Private WithEvents buttonLeftStop As System.Windows.Forms.Button
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents textBoxCheckEnter As System.Windows.Forms.TextBox
    Private WithEvents textBoxCheckX1 As System.Windows.Forms.TextBox
    Private WithEvents textBoxCheckMiddle As System.Windows.Forms.TextBox
    Private WithEvents textBoxCheckRight As System.Windows.Forms.TextBox
    Private WithEvents textBoxCheckLeft As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents timerCheckKeys As System.Windows.Forms.Timer
    Private WithEvents textBoxCheckX2 As System.Windows.Forms.TextBox

    '=======================================================
    'Service provided by Telerik (www.telerik.com)
    'Conversion powered by NRefactory.
    'Twitter: @telerik
    'Facebook: facebook.com/telerik
    '=======================================================

End Class
