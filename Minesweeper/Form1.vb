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
    Dim HPPACK1(0) As clsPickup
    Dim Player1 As clsPlayer
    Dim lvl1EnemyArray(1) As clsEnemy
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles level1.Click
        'SET ENEMY LOCATIONS
        lvl1EnemyArray(0) = New clsEnemy(3, 13)
        lvl1EnemyArray(0).SetHealth(3)
        lvl1EnemyArray(1) = New clsEnemy(8, 1)
        HPPACK1(0) = New clsPickup(1, 13)
        HPPACK1(0).SetActive(True)
        lvl1EnemyArray(1).SetHealth(3)
        Room1(0)
        Timer1.Enabled = True
    End Sub
    Sub Room1(start As Integer)
        'SETS THE PLAYER LOCATION BASED ON TILE
        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, 0, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

        If start = 0 Then
            Player1 = New clsPlayer(1, 1)
            Player1.hp(7)
            m_Game(0, roomindex, Player1.GetX(), Player1.GetY()).setPlayer(True)
        End If
        If start = 1 Then
            Player1.SetX(14)
            Player1.SetY(14)
        End If



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
                    buttonArray(i, i2).BackgroundImage = ImageList1.Images(4)
                    buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                    buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                    buttonArray(i, i2).FlatAppearance.BorderSize = 0
                    buttonArray(i, i2).Enabled = False
                    Me.Controls.Add(buttonArray(i, i2))
                Next
            Next
            'GENERATE LEVEL WALLS

            'CREATES TOP WALL
            For i = 0 To 15
                buttonArray(i, 0).BackgroundImage = ImageList1.Images(6)
                m_Game(0, roomindex, i, 0).SetIndex(6)
            Next
            'CREATES LEFT WALL
            For i2 = 0 To 15
                buttonArray(0, i2).BackgroundImage = ImageList1.Images(6)
                m_Game(0, roomindex, 0, i2).SetIndex(6)
            Next
            'CREATES BOTTOM WALL
            For i = 0 To 15
                buttonArray(i, 15).BackgroundImage = ImageList1.Images(6)
                m_Game(0, roomindex, i, 15).SetIndex(6)
            Next
            'CREATES RIGHT WALL
            For i2 = 0 To 15
                buttonArray(15, i2).BackgroundImage = ImageList1.Images(6)
                m_Game(0, roomindex, 15, i2).SetIndex(6)
            Next
            'CREATES A WALL INSIDE THE ROOM
            For i = 0 To 13
                buttonArray(i, 2).BackgroundImage = ImageList1.Images(6)
                m_Game(0, roomindex, i, 2).SetIndex(6)
            Next
            'CREATES A WALL INSIDE THE ROOM
            For i = 2 To 15
                buttonArray(i, 4).BackgroundImage = ImageList1.Images(6)
                m_Game(0, roomindex, i, 4).SetIndex(6)
            Next
            'CREATES A WALL INSIDE THE ROOM
            For i = 0 To 13
                buttonArray(i, 6).BackgroundImage = ImageList1.Images(6)
                m_Game(0, roomindex, i, 6).SetIndex(6)
            Next
            'CREATES A WALL INSIDE THE ROOM
            For i = 2 To 15
                buttonArray(i, 8).BackgroundImage = ImageList1.Images(6)
                m_Game(0, roomindex, i, 8).SetIndex(6)
            Next
            'Creates VERTICAL wall in room
            For i2 = 8 To 13
                buttonArray(2, i2).BackgroundImage = ImageList1.Images(6)
                m_Game(0, roomindex, 2, i2).SetIndex(6)
            Next
            'Creates VERTICAL wall in room
            For i2 = 10 To 15
                buttonArray(4, i2).BackgroundImage = ImageList1.Images(6)
                m_Game(0, roomindex, 4, i2).SetIndex(6)
            Next

            'Generate Level Pickups

            If HPPACK1(0).ActiveCheck() = True Then
                m_Game(0, 0, HPPACK1(0).ReturnX, HPPACK1(0).ReturnY).SetIndex(3)
                HPPACK1(0).SetHealth(3)
                buttonArray(HPPACK1(0).ReturnX, HPPACK1(0).ReturnY).BackgroundImage = ImageList1.Images(7)
            End If

            'Places Player
            Player1.ImageNum(1)
                buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(Player1.GetImageNum())

                m_buttonArray = buttonArray

                'Place Enemys            

                For i = 0 To lvl1EnemyArray.Count - 1
                    If lvl1EnemyArray(i).CheckDead = False Then
                        m_Game(0, roomindex, lvl1EnemyArray(1).GetX, lvl1EnemyArray(1).GetY).setEnemy(True)
                        m_Game(0, roomindex, lvl1EnemyArray(0).GetX, lvl1EnemyArray(0).GetY).setEnemy(True)
                        m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(1)
                    End If
                Next






            End If
        m_Game(0, roomindex, 15, 14).SetIndex(10)
        '



    End Sub
    Sub Room2(start As Integer)
        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, 1, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next
        levelindex = 0
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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(4)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next



        'Set Player Starting Location.


        If start = 0 Then
            Player1.SetX(1)
            Player1.SetY(1)
        ElseIf start = 1 Then
            Player1.SetX(14)
            Player1.SetY(14)
        End If
        'CREATES TOP WALL
        For i = 0 To 15
            buttonArray(i, 0).BackgroundImage = ImageList1.Images(6)
            m_Game(0, roomindex, i, 0).SetIndex(6)
        Next
        'CREATES LEFT WALL
        For i2 = 0 To 15
            buttonArray(0, i2).BackgroundImage = ImageList1.Images(6)
            m_Game(0, roomindex, 0, i2).SetIndex(6)
        Next
        'CREATES BOTTOM WALL
        For i = 0 To 15
            buttonArray(i, 15).BackgroundImage = ImageList1.Images(6)
            m_Game(0, roomindex, i, 15).SetIndex(6)
        Next
        'CREATES RIGHT WALL
        For i2 = 0 To 15
            buttonArray(15, i2).BackgroundImage = ImageList1.Images(6)
            m_Game(0, roomindex, 15, i2).SetIndex(6)
        Next
        m_Game(0, roomindex, 0, 1).SetIndex(11)

        Player1.ImageNum(1)
        buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(Player1.GetImageNum())







        m_buttonArray = buttonArray

    End Sub
    Sub CreateRoom(x As Integer, y As Integer)

        For i = 0 To 15
            For i2 = 0 To 15
                m_buttonArray(i, i2).Dispose()
                ' m_Game(0, roomindex, i, i2).SetIndex(0)
                '  m_Game(0, roomindex, i, i2).setEnemy(False)
            Next
        Next

        If x = 0 Then
            Room1(y)
        End If
        If x = 1 Then
            Room2(y)
        End If
    End Sub
    Private Sub level2_Click(sender As Object, e As EventArgs) Handles level2.Click

    End Sub
    Private Sub level3_Click(sender As Object, e As EventArgs) Handles level3.Click

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'Wasd Key Character Controls
        'RIGHT MOVEMENT RIGHT MOVEMENT RIGHTMOVEMENT
        If e.KeyCode = Keys.D And Player1.GetX() <> 15 And m_Game(levelindex, roomindex, Player1.GetX() + 1, Player1.GetY()).GetIndex <> 6 Then

            If Player1.GetImageNum <> 0 Then
                m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(0)
                Player1.ImageNum(0)
            Else
                If m_Game(levelindex, roomindex, Player1.GetX() + 1, Player1.GetY()).CheckForEnemy = False Then
                    m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(4)
                    Player1.SetX(Player1.GetX() + 1)
                    m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(0)
                End If
            End If
            If m_Game(levelindex, roomindex, Player1.GetX + 1, Player1.GetY).GetIndex = 10 Then

                roomindex += 1
                CreateRoom(roomindex, 0)
            End If
            If m_Game(levelindex, roomindex, Player1.GetX + 1, Player1.GetY).GetIndex = 11 Then

                roomindex -= 1
                CreateRoom(roomindex, 1)
            End If
            If m_Game(levelindex, roomindex, Player1.GetX, Player1.GetY).GetIndex = 3 Then
                For i = 0 To HPPACK1.Count - 1
                    If HPPACK1(i).ReturnX = Player1.GetX And HPPACK1(i).ReturnY = Player1.GetY Then
                        Player1.hp(Player1.GetHP + HPPACK1(i).HP)
                        HPPACK1(i).SetActive(False)
                    End If
                Next
            End If
        ElseIf e.KeyCode = Keys.D And Player1.GetX() <> 15 Then
            m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(0)
            Player1.ImageNum(0)
        End If
        ' UPWARD MOVEMENT UPWARD MOVEMENT UPWARD MOVEMENT
        If e.KeyCode = Keys.W And Player1.GetY() <> 0 And m_Game(levelindex, roomindex, Player1.GetX(), Player1.GetY() - 1).GetIndex <> 6 Then

            If Player1.GetImageNum <> 1 Then
                m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(1)
                Player1.ImageNum(1)
            Else
                If m_Game(levelindex, roomindex, Player1.GetX(), Player1.GetY() - 1).CheckForEnemy = False Then
                    m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(4)
                    Player1.SetY(Player1.GetY() - 1)
                    m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(1)
                End If

            End If
            If m_Game(levelindex, roomindex, Player1.GetX, Player1.GetY - 1).GetIndex = 10 Then

                roomindex += 1
                CreateRoom(roomindex, 0)
            End If
            If m_Game(levelindex, roomindex, Player1.GetX, Player1.GetY - 1).GetIndex = 11 Then

                roomindex -= 1
                CreateRoom(roomindex, 1)
            End If
            If m_Game(levelindex, roomindex, Player1.GetX, Player1.GetY).GetIndex = 3 Then
                For i = 0 To HPPACK1.Count - 1
                    If HPPACK1(i).ReturnX = Player1.GetX And HPPACK1(i).ReturnY = Player1.GetY Then
                        Player1.hp(Player1.GetHP + HPPACK1(i).HP)
                        HPPACK1(i).SetActive(False)
                    End If
                Next
            End If
        ElseIf e.KeyCode = Keys.W And Player1.GetY() <> 0 Then
            m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(1)
            Player1.ImageNum(1)
        End If
        'LEFTWARD MOVEMENT LEFTWARD MOVEMENT LEFTWARD MOVEMENT
        If e.KeyCode = Keys.A And Player1.GetX() <> 0 And m_Game(levelindex, roomindex, Player1.GetX() - 1, Player1.GetY()).GetIndex <> 6 Then

            If Player1.GetImageNum <> 2 Then
                m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(2)
                Player1.ImageNum(2)
            Else
                If m_Game(levelindex, roomindex, Player1.GetX() - 1, Player1.GetY()).CheckForEnemy = False Then
                    m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(4)
                    Player1.SetX(Player1.GetX() - 1)
                    m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(2)
                End If
            End If
            If m_Game(levelindex, roomindex, Player1.GetX - 1, Player1.GetY).GetIndex = 10 Then

                roomindex += 1
                CreateRoom(roomindex, 0)
            End If
            If m_Game(levelindex, roomindex, Player1.GetX - 1, Player1.GetY).GetIndex = 11 Then

                roomindex -= 1
                CreateRoom(roomindex, 1)
            End If
            If m_Game(levelindex, roomindex, Player1.GetX, Player1.GetY).GetIndex = 3 Then
                For i = 0 To HPPACK1.Count - 1
                    If HPPACK1(i).ReturnX = Player1.GetX And HPPACK1(i).ReturnY = Player1.GetY Then
                        Player1.hp(Player1.GetHP + HPPACK1(i).HP)
                        HPPACK1(i).SetActive(False)
                    End If
                Next
            End If
        ElseIf e.KeyCode = Keys.A And Player1.GetX() <> 0 Then
            m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(2)
            Player1.ImageNum(2)
        End If
        'DOWNWARD MOVEMENT DOWNWARD MOVEMENT DOWNWARD MOVEMENT
        If e.KeyCode = Keys.S And Player1.GetY() <> 15 And m_Game(levelindex, roomindex, Player1.GetX(), Player1.GetY() + 1).GetIndex <> 6 Then
            If Player1.GetImageNum <> 3 Then
                m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(3)
                Player1.ImageNum(3)
            Else
                If m_Game(levelindex, roomindex, Player1.GetX(), Player1.GetY() + 1).CheckForEnemy = False Then
                    m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(4)
                    Player1.SetY(Player1.GetY() + 1)
                    m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(3)
                End If
            End If
            If m_Game(levelindex, roomindex, Player1.GetX, Player1.GetY + 1).GetIndex = 10 Then

                roomindex += 1
                CreateRoom(roomindex, 0)
            End If
            If m_Game(levelindex, roomindex, Player1.GetX, Player1.GetY).GetIndex = 11 Then

                roomindex -= 1
                CreateRoom(roomindex, 1)
            End If
            If m_Game(levelindex, roomindex, Player1.GetX, Player1.GetY).GetIndex = 3 Then
                For i = 0 To HPPACK1.Count - 1
                    If HPPACK1(i).ReturnX = Player1.GetX And HPPACK1(i).ReturnY = Player1.GetY Then
                        Player1.hp(Player1.GetHP + HPPACK1(i).HP)
                        HPPACK1(i).SetActive(False)
                    End If
                Next
            End If
        ElseIf e.KeyCode = Keys.S And Player1.GetY() <> 15 Then
            m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(3)
            Player1.ImageNum(3)
        End If

        'Arrow Key Player Controls

        'RIGHT MOVEMENT RIGHT MOVEMENT RIGHTMOVEMENT
        If e.KeyCode = Keys.Right And Player1.GetX() <> 15 And m_Game(levelindex, roomindex, Player1.GetX() + 1, Player1.GetY()).GetIndex <> 6 Then

            If Player1.GetImageNum <> 0 Then
                m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(0)
                Player1.ImageNum(0)
            Else
                If m_Game(levelindex, roomindex, Player1.GetX() + 1, Player1.GetY()).CheckForEnemy = False Then
                    m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(4)
                    Player1.SetX(Player1.GetX() + 1)
                    m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(0)
                End If
            End If
            If m_Game(levelindex, roomindex, Player1.GetX + 1, Player1.GetY).GetIndex = 10 Then

                roomindex += 1
                CreateRoom(roomindex, 0)
            End If
            If m_Game(levelindex, roomindex, Player1.GetX + 1, Player1.GetY).GetIndex = 11 Then

                roomindex -= 1
                CreateRoom(roomindex, 1)
            End If
            If m_Game(levelindex, roomindex, Player1.GetX, Player1.GetY).GetIndex = 3 Then
                For i = 0 To HPPACK1.Count - 1
                    If HPPACK1(i).ReturnX = Player1.GetX And HPPACK1(i).ReturnY = Player1.GetY Then
                        Player1.hp(Player1.GetHP + HPPACK1(i).HP)
                        HPPACK1(i).SetActive(False)
                    End If
                Next
            End If
        ElseIf e.KeyCode = Keys.D And Player1.GetX() <> 15 Then
            m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(0)
            Player1.ImageNum(0)
        End If
        ' UPWARD MOVEMENT UPWARD MOVEMENT UPWARD MOVEMENT
        If e.KeyCode = Keys.Up And Player1.GetY() <> 0 And m_Game(levelindex, roomindex, Player1.GetX(), Player1.GetY() - 1).GetIndex <> 6 Then

            If Player1.GetImageNum <> 1 Then
                m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(1)
                Player1.ImageNum(1)
            Else
                If m_Game(levelindex, roomindex, Player1.GetX(), Player1.GetY() - 1).CheckForEnemy = False Then
                    m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(4)
                    Player1.SetY(Player1.GetY() - 1)
                    m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(1)
                End If

            End If
            If m_Game(levelindex, roomindex, Player1.GetX, Player1.GetY - 1).GetIndex = 10 Then

                roomindex += 1
                CreateRoom(roomindex, 0)
            End If
            If m_Game(levelindex, roomindex, Player1.GetX, Player1.GetY - 1).GetIndex = 11 Then

                roomindex -= 1
                CreateRoom(roomindex, 1)
            End If
            If m_Game(levelindex, roomindex, Player1.GetX, Player1.GetY).GetIndex = 3 Then
                For i = 0 To HPPACK1.Count - 1
                    If HPPACK1(i).ReturnX = Player1.GetX And HPPACK1(i).ReturnY = Player1.GetY Then
                        Player1.hp(Player1.GetHP + HPPACK1(i).HP)
                        HPPACK1(i).SetActive(False)
                    End If
                Next
            End If
        ElseIf e.KeyCode = Keys.W And Player1.GetY() <> 0 Then
            m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(1)
            Player1.ImageNum(1)
        End If
        'LEFTWARD MOVEMENT LEFTWARD MOVEMENT LEFTWARD MOVEMENT
        If e.KeyCode = Keys.Left And Player1.GetX() <> 0 And m_Game(levelindex, roomindex, Player1.GetX() - 1, Player1.GetY()).GetIndex <> 6 Then

            If Player1.GetImageNum <> 2 Then
                m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(2)
                Player1.ImageNum(2)
            Else
                If m_Game(levelindex, roomindex, Player1.GetX() - 1, Player1.GetY()).CheckForEnemy = False Then
                    m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(4)
                    Player1.SetX(Player1.GetX() - 1)
                    m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(2)
                End If
            End If
            If m_Game(levelindex, roomindex, Player1.GetX - 1, Player1.GetY).GetIndex = 10 Then

                roomindex += 1
                CreateRoom(roomindex, 0)
            End If
            If m_Game(levelindex, roomindex, Player1.GetX - 1, Player1.GetY).GetIndex = 11 Then

                roomindex -= 1
                CreateRoom(roomindex, 1)
            End If
            If m_Game(levelindex, roomindex, Player1.GetX, Player1.GetY).GetIndex = 3 Then
                For i = 0 To HPPACK1.Count - 1
                    If HPPACK1(i).ReturnX = Player1.GetX And HPPACK1(i).ReturnY = Player1.GetY Then
                        Player1.hp(Player1.GetHP + HPPACK1(i).HP)
                        HPPACK1(i).SetActive(False)
                    End If
                Next
            End If
        ElseIf e.KeyCode = Keys.A And Player1.GetX() <> 0 Then
            m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(2)
            Player1.ImageNum(2)
        End If
        'DOWNWARD MOVEMENT DOWNWARD MOVEMENT DOWNWARD MOVEMENT
        If e.KeyCode = Keys.Down And Player1.GetY() <> 15 And m_Game(levelindex, roomindex, Player1.GetX(), Player1.GetY() + 1).GetIndex <> 6 Then
            If Player1.GetImageNum <> 3 Then
                m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(3)
                Player1.ImageNum(3)
            Else
                If m_Game(levelindex, roomindex, Player1.GetX(), Player1.GetY() + 1).CheckForEnemy = False Then
                    m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(4)
                    Player1.SetY(Player1.GetY() + 1)
                    m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(3)
                End If
            End If
            If m_Game(levelindex, roomindex, Player1.GetX, Player1.GetY + 1).GetIndex = 10 Then

                roomindex += 1
                CreateRoom(roomindex, 0)
            End If
            If m_Game(levelindex, roomindex, Player1.GetX, Player1.GetY).GetIndex = 11 Then

                roomindex -= 1
                CreateRoom(roomindex, 1)
            End If
            If m_Game(levelindex, roomindex, Player1.GetX, Player1.GetY).GetIndex = 3 Then
                For i = 0 To HPPACK1.Count - 1
                    If HPPACK1(i).ReturnX = Player1.GetX And HPPACK1(i).ReturnY = Player1.GetY Then
                        Player1.hp(Player1.GetHP + HPPACK1(i).HP)
                        HPPACK1(i).SetActive(False)
                    End If
                Next
            End If
        ElseIf e.KeyCode = Keys.S And Player1.GetY() <> 15 Then
            m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(3)
            Player1.ImageNum(3)
        End If
        If e.KeyCode = Keys.Space Then


            'Rough Framework for fighting, need to add array of enemys and need to add a for next statement to check against enemys like how enemy1 is checked agaisnt for here.
            If Player1.GetImageNum = 0 Then
                AR.Enabled = True
                If m_Game(0, roomindex, Player1.GetX() + 1, Player1.GetY()).CheckForEnemy = True Then

                    For i = 0 To lvl1EnemyArray.Count - 1
                        If lvl1EnemyArray(i).GetX = Player1.GetX + 1 And lvl1EnemyArray(i).GetY = Player1.GetY Then
                            lvl1EnemyArray(i).SetHealth(lvl1EnemyArray(i).GetHealth() - 1)
                            If lvl1EnemyArray(i).GetHealth <= 0 Then
                                m_Game(0, roomindex, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).setEnemy(False)
                                m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(4)
                            End If
                        End If
                    Next


                End If
            End If

            If Player1.GetImageNum = 1 Then
                AT.Enabled = True
                If m_Game(0, roomindex, Player1.GetX(), Player1.GetY() - 1).CheckForEnemy = True Then
                    For i = 0 To lvl1EnemyArray.Count - 1
                        If lvl1EnemyArray(i).GetX = Player1.GetX And lvl1EnemyArray(i).GetY = Player1.GetY - 1 Then
                            lvl1EnemyArray(i).SetHealth(lvl1EnemyArray(i).GetHealth() - 1)
                            If lvl1EnemyArray(i).GetHealth <= 0 Then
                                m_Game(0, roomindex, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).setEnemy(False)
                                m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(4)
                            End If
                        End If
                    Next
                End If
            End If

            If Player1.GetImageNum = 2 Then
                AL.Enabled = True
                If m_Game(0, roomindex, Player1.GetX() - 1, Player1.GetY()).CheckForEnemy = True Then
                    For i = 0 To lvl1EnemyArray.Count - 1
                        If lvl1EnemyArray(i).GetX = Player1.GetX - 1 And lvl1EnemyArray(i).GetY = Player1.GetY Then
                            lvl1EnemyArray(i).SetHealth(lvl1EnemyArray(i).GetHealth() - 1)
                            If lvl1EnemyArray(i).GetHealth <= 0 Then
                                m_Game(0, roomindex, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).setEnemy(False)
                                m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(4)
                            End If
                        End If
                    Next
                End If
            End If

            If Player1.GetImageNum = 3 Then
                AD.Enabled = True
                If m_Game(0, roomindex, Player1.GetX(), Player1.GetY() + 1).CheckForEnemy = True Then

                    For i = 0 To lvl1EnemyArray.Count - 1
                        If lvl1EnemyArray(i).GetX = Player1.GetX And lvl1EnemyArray(i).GetY = Player1.GetY + 1 Then
                            lvl1EnemyArray(i).SetHealth(lvl1EnemyArray(i).GetHealth() - 1)
                            If lvl1EnemyArray(i).GetHealth <= 0 Then
                                m_Game(0, roomindex, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).setEnemy(False)
                                m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(4)
                            End If
                        End If
                    Next
                End If
            End If












        End If



    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles AR.Tick

        If Player1.GetImageNum <> 8 Then
            m_buttonArray(Player1.GetX, Player1.GetY).BackgroundImage = ImageList1.Images(8)
            Player1.ImageNum(8)
        Else
            Player1.ImageNum(0)
            m_buttonArray(Player1.GetX, Player1.GetY).BackgroundImage = ImageList1.Images(0)
            AR.Enabled = False
        End If
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles AT.Tick
        If Player1.GetImageNum <> 8 Then
            m_buttonArray(Player1.GetX, Player1.GetY).BackgroundImage = ImageList1.Images(8)
            Player1.ImageNum(8)
        Else
            Player1.ImageNum(1)
            m_buttonArray(Player1.GetX, Player1.GetY).BackgroundImage = ImageList1.Images(1)
            AT.Enabled = False
        End If
    End Sub

    Private Sub AL_Tick(sender As Object, e As EventArgs) Handles AL.Tick
        If Player1.GetImageNum <> 8 Then
            m_buttonArray(Player1.GetX, Player1.GetY).BackgroundImage = ImageList1.Images(8)
            Player1.ImageNum(8)
        Else
            Player1.ImageNum(2)
            m_buttonArray(Player1.GetX, Player1.GetY).BackgroundImage = ImageList1.Images(2)
            AL.Enabled = False
        End If
    End Sub

    Private Sub AD_Tick(sender As Object, e As EventArgs) Handles AD.Tick
        If Player1.GetImageNum <> 8 Then
            m_buttonArray(Player1.GetX, Player1.GetY).BackgroundImage = ImageList1.Images(8)
            Player1.ImageNum(8)
        Else
            Player1.ImageNum(3)
            m_buttonArray(Player1.GetX, Player1.GetY).BackgroundImage = ImageList1.Images(3)
            AD.Enabled = False
        End If
    End Sub
    Dim packstate As Integer = 1
    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click

        If packstate = 0 Then
            BackPackLabel.Visible = True
            BackpackList.Visible = True
            BackPackPicture.Visible = True
            BackPackTextBox.Visible = True
            packstate = 1

        ElseIf packstate = 1 Then
            BackPackLabel.Visible = False
            BackpackList.Visible = False
            BackPackPicture.Visible = False
            BackPackTextBox.Visible = False
            packstate = 0
        End If
    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        PictureBox1.Image = ImageList2.Images(Player1.GetHP)
    End Sub

    Private Sub EnemyAI_Tick(sender As Object, e As EventArgs) Handles EnemyAI.Tick
        Dim rnd As New Random
        If levelindex = 0 Then

            If roomindex = 0 Then
                For i = 0 To lvl1EnemyArray.Count - 1
                    Dim a As Integer
                    a = rnd.Next(0, 1)
                    Dim b As Integer
                    b = rnd.Next(0, 1)
                    If a = 0 Then

                        If b = 0 Then
                            lvl1EnemyArray(i).SetX(lvl1EnemyArray(i).GetX + 1)
                        ElseIf b = 1 Then
                            lvl1EnemyArray(i)
                        End If

                    ElseIf a = 1 Then

                        If b = 0 Then
                            lvl1EnemyArray(i)
                        ElseIf b = 1 Then
                            lvl1EnemyArray(i)
                        End If

                    End If





                Next
            End If


        End If









    End Sub
End Class

