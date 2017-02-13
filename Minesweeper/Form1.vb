Public Class Form1

    'x = ((x - 8) \ tilesize)       snipetts for getting exact tile spot based upon location.
    'y = ((y - 54) \ tilesize)

    '----------------------------------------------------------------------
    Dim m_Game(3, 10, 16, 16) As Tile
    Dim m_buttonArray(,) As Button
    Dim m_RowSize As Integer
    Dim m_Collumn As Integer
    Dim tilesize As Integer = 24
    Dim levelindex As Integer
    Dim roomindex As Integer
    Dim playx, playy As Integer
    Private Sub GenerateBoard(x As Integer, y As Integer, z As Integer)
        'for didgital logic array
        Dim colloms As Integer
        Dim rows As Integer

        rows = x
        colloms = y

        m_RowSize = rows
        m_Collumn = colloms

        'For i = 1 To rows
        '  For i2 = 1 To colloms
        '  If isABomb(bombIndex) = True Then
        '                tmpboard(i - 1, i2 - 1) = New Tile(True, False, False, 0)
        '                isABomb((i * i2) - 1) = False
        ' Else
        '                tmpboard(i - 1, i2 - 1) = New Tile(False, False, False, 0)
        '  End If
        '             bombIndex = bombIndex + 1
        '  Next
        '  Next

        'Code Snippet for preface to Generating the board.

        ' m_board = tmpboard
        CompileBoard(rows - 1, colloms - 1)
    End Sub
    Private Sub CompileBoard(x As Integer, Y As Integer)




    End Sub
    Private Sub BoardChecker(x As Integer, y As Integer)

        ' If m_board(x, y).CheckForBomb = True Then
        ' m_buttonArray(x, y).BackgroundImage = ImageList1.Images(12)
        '  End If
        'Code for applying images to the buttons.
    End Sub
    Private Sub ClearBoard(X As Integer, Y As Integer)
        For i = 0 To X
            For i2 = 0 To Y
                m_buttonArray(i, i2).Dispose()
            Next
        Next
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles level1.Click
        'Room 1 (0,0)
        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, 0, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

        'SETS THE PLAYER LOCATION BASED ON TILE
        playx = 1
        playy = 1
        m_Game(0, 0, playx, playy).setPlayer(True)


        'GENERATES THE ROOM AND DEFAULTS ALL TILES TO BASE TEXTURE
        If roomindex = 0 And levelindex = 0 Then
            Dim buttonArray(16, 16) As Button
            For i = 0 To 15
                For i2 = 0 To 15
                    buttonArray(i, i2) = New System.Windows.Forms.Button()
                    buttonArray(i, i2).Location = New System.Drawing.Point((i * tilesize), (i2 * tilesize) + tilesize)
                    buttonArray(i, i2).Name = (i.ToString + "_" + i2.ToString)
                    buttonArray(i, i2).Size = New System.Drawing.Size(tilesize, tilesize)
                    buttonArray(i, i2).TabIndex = 1
                    buttonArray(i, i2).Text = ""
                    buttonArray(i, i2).UseVisualStyleBackColor = True
                    buttonArray(i, i2).BackColor = Color.Gray
                    buttonArray(i, i2).BackgroundImage = ImageList1.Images(0)
                    buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                    buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                    buttonArray(i, i2).FlatAppearance.BorderSize = 0
                    buttonArray(i, i2).Enabled = False
                    Me.Controls.Add(buttonArray(i, i2))
                Next
            Next
            'CREATES TOP WALL
            For i = 0 To 15
                buttonArray(i, 0).BackgroundImage = ImageList1.Images(2)
                m_Game(0, 0, i, 0).SetIndex(2)
            Next
            'CREATES LEFT WALL
            For i2 = 0 To 15
                buttonArray(0, i2).BackgroundImage = ImageList1.Images(2)
                m_Game(0, 0, 0, i2).SetIndex(2)
            Next
            'CREATES BOTTOM WALL
            For i = 0 To 15
                buttonArray(i, 15).BackgroundImage = ImageList1.Images(2)
                m_Game(0, 0, i, 15).SetIndex(2)
            Next
            'CREATES RIGHT WALL
            For i2 = 0 To 15
                buttonArray(15, i2).BackgroundImage = ImageList1.Images(2)
                m_Game(0, 0, 15, i2).SetIndex(2)
            Next
            'CREATES A WALL INSIDE THE ROOM
            For i = 0 To 13
                buttonArray(i, 2).BackgroundImage = ImageList1.Images(2)
                m_Game(0, 0, i, 2).SetIndex(2)
            Next
            'CREATES A WALL INSIDE THE ROOM
            For i = 2 To 15
                buttonArray(i, 4).BackgroundImage = ImageList1.Images(2)
                m_Game(0, 0, i, 4).SetIndex(2)
            Next
            'CREATES A WALL INSIDE THE ROOM
            For i = 0 To 13
                buttonArray(i, 6).BackgroundImage = ImageList1.Images(2)
                m_Game(0, 0, i, 6).SetIndex(2)
            Next
            'CREATES A WALL INSIDE THE ROOM
            For i = 2 To 15
                buttonArray(i, 8).BackgroundImage = ImageList1.Images(2)
                m_Game(0, 0, i, 8).SetIndex(2)
            Next











            buttonArray(playx, playy).BackgroundImage = ImageList1.Images(1)

            m_buttonArray = buttonArray

        End If
    End Sub
    Private Sub level2_Click(sender As Object, e As EventArgs) Handles level2.Click

    End Sub
    Private Sub level3_Click(sender As Object, e As EventArgs) Handles level3.Click

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.D And playx <> 15 And m_Game(0, 0, playx + 1, playy).GetIndex <> 2 Then
            m_buttonArray(playx, playy).BackgroundImage = ImageList1.Images(0)
            playx += 1
            m_buttonArray(playx, playy).BackgroundImage = ImageList1.Images(1)
        End If
        If e.KeyCode = Keys.W And playy <> 0 And m_Game(0, 0, playx, playy - 1).GetIndex <> 2 Then
            m_buttonArray(playx, playy).BackgroundImage = ImageList1.Images(0)
            playy -= 1
            m_buttonArray(playx, playy).BackgroundImage = ImageList1.Images(1)
        End If
        If e.KeyCode = Keys.A And playx <> 0 And m_Game(0, 0, playx - 1, playy).GetIndex <> 2 Then
            m_buttonArray(playx, playy).BackgroundImage = ImageList1.Images(0)
            playx -= 1
            m_buttonArray(playx, playy).BackgroundImage = ImageList1.Images(1)
        End If
        If e.KeyCode = Keys.S And playy <> 15 And m_Game(0, 0, playx, playy + 1).GetIndex <> 2 Then
            m_buttonArray(playx, playy).BackgroundImage = ImageList1.Images(0)
            playy += 1
            m_buttonArray(playx, playy).BackgroundImage = ImageList1.Images(1)
        End If
    End Sub
End Class
