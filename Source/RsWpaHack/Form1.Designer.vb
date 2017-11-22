<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.txtSSID = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.pad = New System.Windows.Forms.NumericUpDown
        Me.lstMAC = New System.Windows.Forms.ListBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Seriallab = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'txtSSID
        '
        Me.txtSSID.Location = New System.Drawing.Point(121, 50)
        Me.txtSSID.Name = "txtSSID"
        Me.txtSSID.Size = New System.Drawing.Size(216, 41)
        Me.txtSSID.TabIndex = 0
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(121, 142)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(216, 41)
        Me.TextBox2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(121, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 30)
        Me.Label1.Text = "SSID"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(121, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 29)
        Me.Label2.Text = "Mac Ad."
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Location = New System.Drawing.Point(389, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 36)
        Me.Label3.Text = "Pad:"
        '
        'pad
        '
        Me.pad.Location = New System.Drawing.Point(379, 78)
        Me.pad.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.pad.Name = "pad"
        Me.pad.Size = New System.Drawing.Size(84, 36)
        Me.pad.TabIndex = 2
        '
        'lstMAC
        '
        Me.lstMAC.BackColor = System.Drawing.Color.White
        Me.lstMAC.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lstMAC.Location = New System.Drawing.Point(87, 223)
        Me.lstMAC.Name = "lstMAC"
        Me.lstMAC.Size = New System.Drawing.Size(337, 263)
        Me.lstMAC.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(149, 576)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(198, 62)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Crack!"
        '
        'Seriallab
        '
        Me.Seriallab.BackColor = System.Drawing.Color.White
        Me.Seriallab.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Seriallab.Location = New System.Drawing.Point(178, 385)
        Me.Seriallab.Name = "Seriallab"
        Me.Seriallab.Size = New System.Drawing.Size(246, 40)
        Me.Seriallab.Text = "Serial"
        Me.Seriallab.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(110, 506)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(283, 39)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Trova Mac"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItem1)
        Me.MainMenu1.MenuItems.Add(Me.MenuItem2)
        '
        'MenuItem1
        '
        Me.MenuItem1.MenuItems.Add(Me.MenuItem3)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem4)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem5)
        Me.MenuItem1.Text = "Menu"
        '
        'MenuItem3
        '
        Me.MenuItem3.Text = "Pro Mode"
        '
        'MenuItem4
        '
        Me.MenuItem4.Text = "Normal Mode"
        '
        'MenuItem5
        '
        Me.MenuItem5.Text = "Info"
        '
        'MenuItem2
        '
        Me.MenuItem2.MenuItems.Add(Me.MenuItem7)
        Me.MenuItem2.Text = "Mode"
        '
        'MenuItem7
        '
        Me.MenuItem7.Text = "Fastweb"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(34, 673)
        Me.ProgressBar1.Maximum = 204
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(402, 20)
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label4.Location = New System.Drawing.Point(99, 385)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 40)
        Me.Label4.Text = "Serial:"
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label5.Location = New System.Drawing.Point(99, 446)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 40)
        Me.Label5.Text = "K:"
        Me.Label5.Visible = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label6.Location = New System.Drawing.Point(243, 446)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(165, 40)
        Me.Label6.Text = "Q:"
        Me.Label6.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(480, 696)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(192.0!, 192.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ClientSize = New System.Drawing.Size(480, 696)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Seriallab)
        Me.Controls.Add(Me.lstMAC)
        Me.Controls.Add(Me.pad)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.txtSSID)
        Me.Controls.Add(Me.PictureBox1)
        Me.Location = New System.Drawing.Point(0, 52)
        Me.Menu = Me.MainMenu1
        Me.Name = "Form1"
        Me.Text = "RsWpaHack"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtSSID As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pad As System.Windows.Forms.NumericUpDown
    Friend WithEvents lstMAC As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Seriallab As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Public WithEvents Label1 As System.Windows.Forms.Label

End Class
