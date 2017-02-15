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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateBoardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.level1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.level2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.level3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BombsLeftToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XYPOS_MENU = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.TimerToolStripMenuItem, Me.BombsLeftToolStripMenuItem, Me.XYPOS_MENU})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(406, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerateBoardToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
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
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 1
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
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 428)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerateBoardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TimerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BombsLeftToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents XYPOS_MENU As ToolStripMenuItem
    Friend WithEvents Timer2 As Timer
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents level1 As ToolStripMenuItem
    Friend WithEvents level2 As ToolStripMenuItem
    Friend WithEvents level3 As ToolStripMenuItem
End Class
