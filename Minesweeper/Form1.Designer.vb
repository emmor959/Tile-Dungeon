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
        Me.GenerateBoardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.level1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.level2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.level3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BombsLeftToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XYPOS_MENU = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.MenuStrip1.SuspendLayout()
        CType(Me.BackPackPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AR
        '
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.TimerToolStripMenuItem, Me.BombsLeftToolStripMenuItem, Me.XYPOS_MENU})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(387, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerateBoardToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.FileToolStripMenuItem.Text = "Backpack"
        '
        'GenerateBoardToolStripMenuItem
        '
        Me.GenerateBoardToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.level1, Me.level2, Me.level3})
        Me.GenerateBoardToolStripMenuItem.Name = "GenerateBoardToolStripMenuItem"
        Me.GenerateBoardToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.GenerateBoardToolStripMenuItem.Text = "Levels:"
        '
        'level1
        '
        Me.level1.Name = "level1"
        Me.level1.Size = New System.Drawing.Size(80, 22)
        Me.level1.Text = "1"
        '
        'level2
        '
        Me.level2.Name = "level2"
        Me.level2.Size = New System.Drawing.Size(80, 22)
        Me.level2.Text = "2"
        '
        'level3
        '
        Me.level3.Name = "level3"
        Me.level3.Size = New System.Drawing.Size(80, 22)
        Me.level3.Text = "3"
        '
        'TimerToolStripMenuItem
        '
        Me.TimerToolStripMenuItem.Name = "TimerToolStripMenuItem"
        Me.TimerToolStripMenuItem.Size = New System.Drawing.Size(22, 20)
        Me.TimerToolStripMenuItem.Text = " "
        '
        'BombsLeftToolStripMenuItem
        '
        Me.BombsLeftToolStripMenuItem.Name = "BombsLeftToolStripMenuItem"
        Me.BombsLeftToolStripMenuItem.Size = New System.Drawing.Size(22, 20)
        Me.BombsLeftToolStripMenuItem.Text = " "
        '
        'XYPOS_MENU
        '
        Me.XYPOS_MENU.Name = "XYPOS_MENU"
        Me.XYPOS_MENU.Size = New System.Drawing.Size(22, 20)
        Me.XYPOS_MENU.Text = " "
        '
        'AT
        '
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "M_Adult(right).png")
        Me.ImageList1.Images.SetKeyName(1, "M_Adult(Back).png")
        Me.ImageList1.Images.SetKeyName(2, "M_Adult(left).png")
        Me.ImageList1.Images.SetKeyName(3, "M_Adult(Front).png")
        Me.ImageList1.Images.SetKeyName(4, "Bad Brick Tile.png")
        Me.ImageList1.Images.SetKeyName(5, "Bad Brick Tile - Copy.png")
        Me.ImageList1.Images.SetKeyName(6, "Wall Brick.png")
        Me.ImageList1.Images.SetKeyName(7, "Health_Potion.png")
        Me.ImageList1.Images.SetKeyName(8, "Attack image placeholder.png")
        Me.ImageList1.Images.SetKeyName(9, "wooden pole.png")
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
        Me.BackpackList.Location = New System.Drawing.Point(0, 27)
        Me.BackpackList.Name = "BackpackList"
        Me.BackpackList.Size = New System.Drawing.Size(178, 381)
        Me.BackpackList.TabIndex = 4
        Me.BackpackList.Visible = False
        '
        'BackPackPicture
        '
        Me.BackPackPicture.BackColor = System.Drawing.Color.LightGray
        Me.BackPackPicture.Location = New System.Drawing.Point(184, 27)
        Me.BackPackPicture.Name = "BackPackPicture"
        Me.BackPackPicture.Size = New System.Drawing.Size(198, 199)
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(387, 441)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents AR As Timer
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerateBoardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TimerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BombsLeftToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents XYPOS_MENU As ToolStripMenuItem
    Friend WithEvents AT As Timer
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents level1 As ToolStripMenuItem
    Friend WithEvents level2 As ToolStripMenuItem
    Friend WithEvents level3 As ToolStripMenuItem
    Friend WithEvents AL As Timer
    Friend WithEvents AD As Timer
    Friend WithEvents BackpackList As ListBox
    Friend WithEvents BackPackPicture As PictureBox
    Friend WithEvents BackPackTextBox As TextBox
    Friend WithEvents BackPackLabel As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents Timer1 As Timer
End Class
