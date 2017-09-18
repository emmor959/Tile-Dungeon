<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.AR = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AT = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.AL = New System.Windows.Forms.Timer(Me.components)
        Me.AD = New System.Windows.Forms.Timer(Me.components)
        Me.BackpackList = New System.Windows.Forms.ListBox()
        Me.BackPackPicture = New System.Windows.Forms.PictureBox()
        Me.BackPackTextBox = New System.Windows.Forms.TextBox()
        Me.BackPackLabel = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.EnemyAI = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Text_Timer = New System.Windows.Forms.Timer(Me.components)
        Me.WeaponList = New System.Windows.Forms.ListBox()
        Me.MovespeedMod = New System.Windows.Forms.Timer(Me.components)
        Me.House = New System.Windows.Forms.ImageList(Me.components)
        Me.EnemyAttackRat = New System.Windows.Forms.Timer(Me.components)
        Me.TemporaryWinChecker = New System.Windows.Forms.Timer(Me.components)
        Me.TemporaryTimeCheck = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.BackPackPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AR
        '
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(387, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.FileToolStripMenuItem.Text = "&Backpack"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(22, 20)
        Me.ToolStripMenuItem1.Text = " "
        '
        'AT
        '
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Bad Brick Tile.png")
        Me.ImageList1.Images.SetKeyName(1, "Bad Brick Tile - Copy.png")
        Me.ImageList1.Images.SetKeyName(2, "Wall Brick.png")
        Me.ImageList1.Images.SetKeyName(3, "Cave Outer Enterence.png")
        Me.ImageList1.Images.SetKeyName(4, "Cave innter Wall.png")
        Me.ImageList1.Images.SetKeyName(5, "Cave Outer Left.png")
        Me.ImageList1.Images.SetKeyName(6, "Cave Outer upper.png")
        Me.ImageList1.Images.SetKeyName(7, "GravelFloor.png")
        Me.ImageList1.Images.SetKeyName(8, "GravelWalls.png")
        Me.ImageList1.Images.SetKeyName(9, "GravelWalls.png")
        Me.ImageList1.Images.SetKeyName(10, "DirtFloor.png")
        Me.ImageList1.Images.SetKeyName(11, "wooden pole.png")
        Me.ImageList1.Images.SetKeyName(12, "Grass(2).png")
        Me.ImageList1.Images.SetKeyName(13, "Grass(3).png")
        Me.ImageList1.Images.SetKeyName(14, "Grass(1).png")
        Me.ImageList1.Images.SetKeyName(15, "Black.png")
        Me.ImageList1.Images.SetKeyName(16, "House(1).png")
        Me.ImageList1.Images.SetKeyName(17, "GravelFloorWater(Down).png")
        Me.ImageList1.Images.SetKeyName(18, "GravelFloorWater(Left).png")
        Me.ImageList1.Images.SetKeyName(19, "GravelFloorWater(Right).png")
        Me.ImageList1.Images.SetKeyName(20, "GravelFloorWater(Up).png")
        Me.ImageList1.Images.SetKeyName(21, "DarkWater(Right).png")
        Me.ImageList1.Images.SetKeyName(22, "Dirt.png")
        Me.ImageList1.Images.SetKeyName(23, "DirtAndGrassX.png")
        Me.ImageList1.Images.SetKeyName(24, "DirtAndGrassY.png")
        Me.ImageList1.Images.SetKeyName(25, "Trees.png")
        Me.ImageList1.Images.SetKeyName(26, "Murky Water.png")
        '
        'AL
        '
        '
        'AD
        '
        '
        'BackpackList
        '
        Me.BackpackList.BackColor = System.Drawing.Color.LightGray
        Me.BackpackList.FormattingEnabled = True
        Me.BackpackList.Location = New System.Drawing.Point(0, 24)
        Me.BackpackList.Name = "BackpackList"
        Me.BackpackList.Size = New System.Drawing.Size(178, 212)
        Me.BackpackList.TabIndex = 4
        Me.BackpackList.Visible = False
        '
        'BackPackPicture
        '
        Me.BackPackPicture.BackColor = System.Drawing.Color.LightGray
        Me.BackPackPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BackPackPicture.Location = New System.Drawing.Point(184, 195)
        Me.BackPackPicture.Name = "BackPackPicture"
        Me.BackPackPicture.Size = New System.Drawing.Size(35, 33)
        Me.BackPackPicture.TabIndex = 5
        Me.BackPackPicture.TabStop = False
        Me.BackPackPicture.Visible = False
        '
        'BackPackTextBox
        '
        Me.BackPackTextBox.BackColor = System.Drawing.Color.LightGray
        Me.BackPackTextBox.Location = New System.Drawing.Point(184, 252)
        Me.BackPackTextBox.Multiline = True
        Me.BackPackTextBox.Name = "BackPackTextBox"
        Me.BackPackTextBox.ReadOnly = True
        Me.BackPackTextBox.Size = New System.Drawing.Size(198, 156)
        Me.BackPackTextBox.TabIndex = 6
        Me.BackPackTextBox.Visible = False
        '
        'BackPackLabel
        '
        Me.BackPackLabel.AutoSize = True
        Me.BackPackLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.BackPackLabel.Location = New System.Drawing.Point(184, 236)
        Me.BackPackLabel.Name = "BackPackLabel"
        Me.BackPackLabel.Size = New System.Drawing.Size(0, 13)
        Me.BackPackLabel.TabIndex = 7
        Me.BackPackLabel.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(0, 408)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(34, 33)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "Heart(0%).png")
        Me.ImageList2.Images.SetKeyName(1, "Heart(10%).png")
        Me.ImageList2.Images.SetKeyName(2, "Heart(20%).png")
        Me.ImageList2.Images.SetKeyName(3, "Heart(30%).png")
        Me.ImageList2.Images.SetKeyName(4, "Heart(40%).png")
        Me.ImageList2.Images.SetKeyName(5, "Heart(50%).png")
        Me.ImageList2.Images.SetKeyName(6, "Heart(60%).png")
        Me.ImageList2.Images.SetKeyName(7, "Heart(70%).png")
        Me.ImageList2.Images.SetKeyName(8, "Heart(80%).png")
        Me.ImageList2.Images.SetKeyName(9, "Heart(90%).png")
        Me.ImageList2.Images.SetKeyName(10, "Heart(Full).png")
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'EnemyAI
        '
        Me.EnemyAI.Interval = 1000
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Black
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(40, 409)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(342, 32)
        Me.TextBox1.TabIndex = 9
        Me.TextBox1.Visible = False
        '
        'Text_Timer
        '
        Me.Text_Timer.Interval = 500
        '
        'WeaponList
        '
        Me.WeaponList.BackColor = System.Drawing.Color.LightGray
        Me.WeaponList.FormattingEnabled = True
        Me.WeaponList.Location = New System.Drawing.Point(0, 235)
        Me.WeaponList.Name = "WeaponList"
        Me.WeaponList.Size = New System.Drawing.Size(178, 173)
        Me.WeaponList.TabIndex = 10
        Me.WeaponList.Visible = False
        '
        'MovespeedMod
        '
        Me.MovespeedMod.Interval = 200
        '
        'House
        '
        Me.House.ImageStream = CType(resources.GetObject("House.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.House.TransparentColor = System.Drawing.Color.Transparent
        Me.House.Images.SetKeyName(0, "FirstHouse(Left).png")
        Me.House.Images.SetKeyName(1, "FirstHouse(Door).png")
        Me.House.Images.SetKeyName(2, "FirstHouse(Right).png")
        Me.House.Images.SetKeyName(3, "FirstHouse(Right Roof).png")
        Me.House.Images.SetKeyName(4, "FirstHouse(MiddleRoof).png")
        Me.House.Images.SetKeyName(5, "FirstHouse(Left Roof).png")
        Me.House.Images.SetKeyName(6, "FirstHouse(Left Roof).png")
        Me.House.Images.SetKeyName(7, "FirstHouse(MiddleRoof).png")
        Me.House.Images.SetKeyName(8, "FirstHouse(Right Roof).png")
        Me.House.Images.SetKeyName(9, "Roof(1).png")
        '
        'EnemyAttackRat
        '
        '
        'TemporaryTimeCheck
        '
        Me.TemporaryTimeCheck.Enabled = True
        Me.TemporaryTimeCheck.Interval = 1000
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(90, 118)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(210, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Slot 1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(90, 192)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(210, 23)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Slot 2"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(90, 266)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(210, 23)
        Me.Button4.TabIndex = 13
        Me.Button4.Text = "Slot 3"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(133, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "What Is Your Name?"
        Me.Label1.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(90, 121)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(210, 20)
        Me.TextBox2.TabIndex = 15
        Me.TextBox2.Visible = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(90, 192)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(210, 23)
        Me.Button5.TabIndex = 16
        Me.Button5.Text = "Confirm"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(90, 334)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(210, 23)
        Me.Button6.TabIndex = 17
        Me.Button6.Text = "Confirm"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(58, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "+"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(77, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "-"
        Me.Label3.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label4.Location = New System.Drawing.Point(77, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "-"
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.Location = New System.Drawing.Point(58, 163)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "+"
        Me.Label5.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(77, 237)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(10, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "-"
        Me.Label6.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label7.Location = New System.Drawing.Point(58, 237)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(13, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "+"
        Me.Label7.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label8.Location = New System.Drawing.Point(77, 311)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "-"
        Me.Label8.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label9.Location = New System.Drawing.Point(58, 311)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(13, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "+"
        Me.Label9.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label10.Location = New System.Drawing.Point(306, 89)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(10, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "-"
        Me.Label10.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label11.Location = New System.Drawing.Point(287, 89)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(13, 13)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "+"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label12.Location = New System.Drawing.Point(58, 76)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Hair Color"
        Me.Label12.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label13.Location = New System.Drawing.Point(58, 150)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 13)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Shirt Color"
        Me.Label13.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label14.Location = New System.Drawing.Point(58, 226)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 13)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Pants Color"
        Me.Label14.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label15.Location = New System.Drawing.Point(58, 298)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 13)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Skin Tone"
        Me.Label15.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label16.Location = New System.Drawing.Point(261, 76)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Hair Style"
        Me.Label16.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(136, 118)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 100)
        Me.PictureBox2.TabIndex = 33
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(387, 446)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.WeaponList)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BackPackLabel)
        Me.Controls.Add(Me.BackPackTextBox)
        Me.Controls.Add(Me.BackPackPicture)
        Me.Controls.Add(Me.BackpackList)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.BackPackPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents AR As Timer
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AT As Timer
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents AL As Timer
    Friend WithEvents AD As Timer
    Friend WithEvents BackpackList As ListBox
    Friend WithEvents BackPackPicture As PictureBox
    Friend WithEvents BackPackTextBox As TextBox
    Friend WithEvents BackPackLabel As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents Timer1 As Timer
    Friend WithEvents EnemyAI As Timer
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Text_Timer As Timer
    Friend WithEvents WeaponList As ListBox
    Friend WithEvents MovespeedMod As Timer
    Friend WithEvents House As ImageList
    Friend WithEvents EnemyAttackRat As Timer
    Friend WithEvents TemporaryWinChecker As Timer
    Friend WithEvents TemporaryTimeCheck As Timer
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents PictureBox2 As PictureBox
End Class
