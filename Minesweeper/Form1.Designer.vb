﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
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
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.BackPackPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GenerateBoardToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
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
        Me.ImageList1.Images.SetKeyName(7, "Untitled.png")
        Me.ImageList1.Images.SetKeyName(8, "Attack image placeholder.png")
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
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PictureBox1.Location = New System.Drawing.Point(0, 405)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(34, 33)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PictureBox2.Location = New System.Drawing.Point(28, 405)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(34, 33)
        Me.PictureBox2.TabIndex = 9
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PictureBox3.Location = New System.Drawing.Point(57, 405)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(34, 33)
        Me.PictureBox3.TabIndex = 10
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PictureBox4.Location = New System.Drawing.Point(89, 405)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(34, 33)
        Me.PictureBox4.TabIndex = 11
        Me.PictureBox4.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PictureBox5.Location = New System.Drawing.Point(121, 405)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(34, 33)
        Me.PictureBox5.TabIndex = 12
        Me.PictureBox5.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PictureBox6.Location = New System.Drawing.Point(154, 405)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(34, 33)
        Me.PictureBox6.TabIndex = 13
        Me.PictureBox6.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PictureBox7.Location = New System.Drawing.Point(186, 405)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(34, 33)
        Me.PictureBox7.TabIndex = 14
        Me.PictureBox7.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PictureBox8.Location = New System.Drawing.Point(218, 405)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(34, 33)
        Me.PictureBox8.TabIndex = 15
        Me.PictureBox8.TabStop = False
        '
        'PictureBox9
        '
        Me.PictureBox9.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PictureBox9.Location = New System.Drawing.Point(250, 405)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(34, 33)
        Me.PictureBox9.TabIndex = 16
        Me.PictureBox9.TabStop = False
        '
        'PictureBox10
        '
        Me.PictureBox10.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PictureBox10.Location = New System.Drawing.Point(283, 405)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(34, 33)
        Me.PictureBox10.TabIndex = 17
        Me.PictureBox10.TabStop = False
        '
        'PictureBox11
        '
        Me.PictureBox11.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PictureBox11.Location = New System.Drawing.Point(315, 405)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(34, 33)
        Me.PictureBox11.TabIndex = 18
        Me.PictureBox11.TabStop = False
        '
        'PictureBox12
        '
        Me.PictureBox12.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PictureBox12.Location = New System.Drawing.Point(348, 405)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(34, 33)
        Me.PictureBox12.TabIndex = 19
        Me.PictureBox12.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(387, 441)
        Me.Controls.Add(Me.PictureBox12)
        Me.Controls.Add(Me.PictureBox11)
        Me.Controls.Add(Me.PictureBox10)
        Me.Controls.Add(Me.PictureBox9)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
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
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents PictureBox10 As PictureBox
    Friend WithEvents PictureBox11 As PictureBox
    Friend WithEvents PictureBox12 As PictureBox
End Class
