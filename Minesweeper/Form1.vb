Imports System.ComponentModel
Public Class Form1
    'Code Creators: Dakota Berg and Elijah Morford 
    'Start Date 2/10/2017


    'x = ((x - 8) \ tilesize)       snipetts for getting exact tile spot based upon location.
    'y = ((y - 54) \ tilesize)

    '----------------------------------------------------------------------

#Region "Player Properties"
    Dim playername As String
    Dim hairindex As Integer
    Dim Haircolor As Integer
    Dim Shirtcolor As Integer
    Dim PantsColor As Integer
    Dim skintone As Integer

    Dim baseimageR As Bitmap
    Dim baseimageL As Bitmap
    Dim baseimageU As Bitmap
    Dim baseimageD As Bitmap
    Dim pantsR As Bitmap
    Dim pantsL As Bitmap
    Dim pantsU As Bitmap
    Dim pantsD As Bitmap
    Dim ShirtR As Bitmap
    Dim ShirtL As Bitmap
    Dim ShirtU As Bitmap
    Dim ShirtD As Bitmap
    Dim HairR As Bitmap
    Dim HairL As Bitmap
    Dim HairU As Bitmap
    Dim HairD As Bitmap

    Dim currentWeapon As Integer










#End Region








    Dim m_Game(3, 100, 100, 16, 16) As Tile
    Dim m_buttonArray(,) As Button
    Dim m_RowSize As Integer
    Dim m_Collumn As Integer
    Dim tilesize As Integer = 24
    Dim levelindex As Integer
    Dim roomindexY As Integer
    Dim roomindexX As Integer
    Dim HPPACK1(0) As clsPickup
    Dim Chestb(0) As clsPickup
    Dim Player1 As clsPlayer
    Dim lvl2EnemyArray(2) As clsEnemy
    Dim lvl1EnemyArray(1) As clsEnemy
    Dim room2Enemts As clsEnemy
    Dim rnd As New Random
    Dim playerDamage As Integer = 0
    Dim mouseisdown As Boolean = False
    Dim CurrentHouse As Integer
#Region "Constant Variables"

    Public Const WallTileIndex As Integer = 0
    Public Const FloorTileIndex As Integer = 1
    Public Const DoorDownIndex As Integer = 2
    Public Const DoorUPIndex As Integer = 3
    Public Const DoorRightIndex As Integer = 4
    Public Const DoorLeftIndex As Integer = 5
    Public Const PickUp As Integer = 6
    Public Const Housetile As Integer = 0
    Public Const DoorHouseIndex As Integer = 7



#End Region






    '- - - - - - - - - - - - -Game Engine Peices- - - - - - - - - - - - -






    Public Function CombineImages(ByVal img1 As Image, ByVal img2 As Image) As Image
        Dim bmp As New Bitmap(Math.Max(img1.Width, img2.Width), 24)
        Dim g As Graphics = Graphics.FromImage(bmp)

        g.DrawImage(img1, 0, 0, 24, 24)
        g.DrawImage(img2, 0, 0, 24, 24)

        g.Dispose()

        Return bmp
    End Function

    Public Function CombinePlayerLayers(ByVal Tile As Image, ByVal base As Image, ByVal pants As Image, ByRef Shirt As Image, ByVal Hair As Bitmap) As Image
        Dim bmp As New Bitmap(Math.Max(24, 24), 24)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.DrawImage(Tile, 0, 0, 24, 24)
        g.DrawImage(base, 0, 0, 24, 24)
        g.DrawImage(pants, 0, 0, 24, 24)
        g.DrawImage(Shirt, 0, 0, 24, 24)
        Hair.MakeTransparent()

        g.DrawImage(Hair, 0, 0, 24, 24)

        g.Dispose()
        Return bmp
    End Function
    Public Function tempPlayerLayers(ByVal Tile As Image, ByVal base As Image, ByVal pants As Image, ByRef Shirt As Image, ByVal Hair As Bitmap) As Image
        Dim bmp As New Bitmap(Math.Max(100, 100), 100)
        Dim g As Graphics = Graphics.FromImage(bmp)
        Hair.MakeTransparent()
        g.DrawImage(Tile, 0, 0, 100, 100)
        g.DrawImage(baseimageD, 0, 0, 100, 100)
        g.DrawImage(pantsD, 0, 0, 100, 100)
        g.DrawImage(ShirtD, 0, 0, 100, 100)

        g.DrawImage(HairD, 0, 0, 100, 100)

        g.Dispose()
        Return bmp
    End Function
    Sub TileLayer(x As Integer, y As Integer, maper As Bitmap)

        maper.MakeTransparent(Color.White)
        Dim bmp As New Bitmap(Math.Max(24, 24), 24)
        Dim g As Graphics = Graphics.FromImage(bmp)
        Dim tile As Image = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, x, y).ReturnBackGround())
        g.DrawImage(tile, 0, 0, 24, 24)
        g.DrawImage(maper, 0, 0, 24, 24)
        g.Dispose()
        m_buttonArray(x, y).BackgroundImage = bmp
        m_Game(levelindex, roomindexX, roomindexY, x, y).SetIndex(WallTileIndex)
    End Sub

    Sub SetTile1(x As Integer, y As Integer, index As Integer)
        m_buttonArray(x, y).BackgroundImage = ImageList1.Images(index)
        m_Game(levelindex, roomindexX, roomindexY, x, y).SetBackGround(index)
    End Sub

    Sub DrawRoomWallVert(x As Integer, y As Integer, bound As Integer, imageindex As Integer)
        For i2 = x To y

            m_buttonArray(bound, i2).BackgroundImage = ImageList1.Images(imageindex)
            m_Game(0, roomindexX, roomindexY, bound, i2).SetIndex(WallTileIndex)
            m_Game(0, roomindexX, roomindexY, bound, i2).SetBackGround(imageindex)
        Next
    End Sub

    Sub DrawRoomWallHori(x As Integer, y As Integer, bound As Integer, imageindex As Integer)
        For i = x To y

            m_buttonArray(i, bound).BackgroundImage = ImageList1.Images(imageindex)
            m_Game(0, roomindexX, roomindexY, i, bound).SetIndex(WallTileIndex)
            m_Game(0, roomindexX, roomindexY, i, bound).SetBackGround(imageindex)
        Next
    End Sub

    Sub DrawRoomWallVertImage(x As Integer, y As Integer, bound As Integer, imageindex As Integer)
        For i2 = x To y
            TileLayer(bound, i2, ImageList1.Images(imageindex))
        Next
    End Sub

    Sub DrawRoomWallHoriImage(x As Integer, y As Integer, bound As Integer, imageindex As Integer)
        For i = x To y
            TileLayer(i, bound, ImageList1.Images(imageindex))
        Next
    End Sub

    Sub HouseLayer(x As Integer, y As Integer)
        m_buttonArray(x, y).BackgroundImage = House.Images(3)
        m_Game(0, roomindexX, roomindexY, x, y).SetIndex(Housetile)
        m_buttonArray(x + 1, y).BackgroundImage = House.Images(4)
        m_Game(0, roomindexX, roomindexY, x + 1, y).SetIndex(Housetile)

        m_buttonArray(x + 2, y).BackgroundImage = House.Images(5)
        m_Game(0, roomindexX, roomindexY, x + 2, y).SetIndex(Housetile)
        m_buttonArray(x, y + 1).BackgroundImage = House.Images(0)
        m_Game(0, roomindexX, roomindexY, x, y + 1).SetIndex(Housetile)
        m_buttonArray(x + 1, y + 1).BackgroundImage = House.Images(1)
        m_Game(0, roomindexX, roomindexY, x + 1, y + 1).SetIndex(DoorHouseIndex)
        m_buttonArray(x + 2, y + 1).BackgroundImage = House.Images(2)
        m_Game(0, roomindexX, roomindexY, x + 2, y + 1).SetIndex(Housetile)
    End Sub
    Sub hp(x As Integer, y As Integer, a As Integer)
        Dim Healthpotion As Bitmap
        Healthpotion = BloodStones.My.Resources.Resource1.Health_Potion
        Healthpotion.MakeTransparent(Color.White)
        m_buttonArray(x, y).BackgroundImage = CombineImages(ImageList1.Images(a), Healthpotion)
    End Sub
    Sub Chest(x As Integer, y As Integer, a As Integer)
        Dim Chesta As Bitmap
        Chesta = BloodStones.My.Resources.Resource1.Chest
        Chesta.MakeTransparent(Color.White)
        m_buttonArray(x, y).BackgroundImage = CombineImages(ImageList1.Images(a), Chesta)
    End Sub
#Region "Pop-UP Text"
    Dim pop() As String
    Sub DisplayText(a As String)
        TextBox1.Visible = True
        Dim listofwords() As String
        listofwords = a.Split(" ")
        pop = listofwords
        count = listofwords.Count
        Text_Timer.Interval = (count * 250)
        Text_Timer.Enabled = True
    End Sub
    Dim count As Integer
    Dim place As Integer
    Private Sub Text_Timer_Tick(sender As Object, e As EventArgs) Handles Text_Timer.Tick
        TextBox1.Clear()


        If count <> 0 Then

            For place = 0 To count - 1
                TextBox1.Text = TextBox1.Text + pop(place) + " "

            Next
            count = 0
        Else
            Text_Timer.Enabled = False
            place = 0
            TextBox1.Visible = False
        End If
        Me.Focus()
    End Sub

    Private Sub WeaponList_DoubleClick(sender As Object, e As EventArgs) Handles WeaponList.DoubleClick
        If WeaponList.SelectedItem.ToString = "Rusty Sword" Then
            playerDamage = 1
            DisplayText("Rusty Sword has been equiped")
        End If
    End Sub

#End Region

#Region "BackPackStorage"
    'Toggle Having The Backpack Lay Over The Player HUD
    Dim packstate As Integer = 1
    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click
        If packstate = 0 Then
            BackPackLabel.Visible = True
            BackpackList.Visible = True
            BackPackPicture.Visible = True
            BackPackTextBox.Visible = True
            WeaponList.Visible = True
            packstate = 1
        ElseIf packstate = 1 Then
            BackPackLabel.Visible = False
            BackpackList.Visible = False
            BackPackPicture.Visible = False
            BackPackTextBox.Visible = False
            WeaponList.Visible = False
            packstate = 0
            Me.Focus()
            BackPackPicture.Image = Nothing
        End If
    End Sub


    Dim healthPotion As Integer
    Dim Key As Integer
    Dim Stone As Integer
    Dim RustySword As Boolean
    Sub ResetPack()
        BackpackList.Items.Clear()
        If healthPotion <> 0 Then
            BackpackList.Items.Add("Health Potions: " & healthPotion)
        End If
        If Key <> 0 Then
            BackpackList.Items.Add("Key: " & Key)
        End If
        If Stone <> 0 Then
            BackpackList.Items.Add("Philiosopher Stone: " & Stone)
        End If
        If RustySword = True Then
            WeaponList.Items.Add("Rusty Sword")
        End If
    End Sub

    Private Sub BackpackList_DoubleClick(sender As Object, e As EventArgs) Handles BackpackList.DoubleClick
        If BackpackList.SelectedIndex = 0 And healthPotion > 0 Then
            Player1.hp(Player1.GetHP + HPPACK1(0).HP)
            healthPotion -= 1
            ResetPack()
            DisplayText("3 Health Restored!")
        End If
    End Sub
    'Handles if Player selects a weapon in the backpack
    Private Sub WeaponList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles WeaponList.SelectedIndexChanged
        If WeaponList.SelectedItem.ToString = "Rusty Sword" Then
            Dim bmp As Bitmap
            bmp = BloodStones.My.Resources.Resource1.sword_rest_Right_
            bmp.MakeTransparent(Color.White)
            BackPackPicture.Image = bmp
            BackPackLabel.Text = "Rusty Sword"
            BackPackTextBox.Text = "Tattered Old Weapon (1 Combat Damage)"
        End If
    End Sub
    'Handles if Player selects an item from the backpack
    Private Sub BackpackList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BackpackList.SelectedIndexChanged
        If BackpackList.SelectedIndex = 0 Then
            Dim bmp As Bitmap
            bmp = BloodStones.My.Resources.Resource1.Health_Potion
            bmp.MakeTransparent(Color.White)
            BackPackPicture.Image = bmp
            BackPackLabel.Text = "Health Potion"
            BackPackTextBox.Text = "Full of a non-Viscous Red Fluid that is sweet to the taste. Restores 3 health."
        End If
    End Sub
#End Region

    '- - - - - - - - - - - - - - - - - Player Input Handling- - - - - - - - - - - - - - - -

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        mouseisdown = False
    End Sub
    Dim moveing As Integer = 0
    Private Sub MovespeedMod_Tick(sender As Object, e As EventArgs) Handles MovespeedMod.Tick
        If moveing = 1 Then
            mouseisdown = False
            MovespeedMod.Enabled = False
            moveing = 0
        End If
        If moveing = 0 Then
            moveing = 1
        End If
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'Wasd Key Character Controls
        'RIGHT MOVEMENT RIGHT MOVEMENT RIGHTMOVEMENT
        If mouseisdown = False Then
            Try
                If e.KeyCode = Keys.D And Player1.GetX() <> 15 And m_Game(levelindex, roomindexX, roomindexY, Player1.GetX() + 1, Player1.GetY()).GetIndex <> WallTileIndex Then
                    If Player1.GetImageNum <> 0 Then
                        PlayerRight(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
                        Player1.ImageNum(0)
                    Else
                        If m_Game(levelindex, roomindexX, roomindexY, Player1.GetX + 1, Player1.GetY).GetIndex = DoorRightIndex Then
                            roomindexX += 1
                            CreateRoom(roomindexX, roomindexY, 2)

                        Else
                            MovePlayer(1, 0)
                        End If
                    End If
                ElseIf e.KeyCode = Keys.D And Player1.GetX() <> 15 Then
                    PlayerRight(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
                    Player1.ImageNum(0)
                End If
                ' UPWARD MOVEMENT UPWARD MOVEMENT UPWARD MOVEMENT
                If e.KeyCode = Keys.W And Player1.GetY() <> 0 And m_Game(levelindex, roomindexX, roomindexY, Player1.GetX(), Player1.GetY() - 1).GetIndex <> WallTileIndex Then
                    If Player1.GetImageNum <> 1 Then
                        PlayerUp(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
                        Player1.ImageNum(1)
                    Else
                        If m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY - 1).GetIndex = DoorUPIndex Then
                            roomindexY -= 1
                            CreateRoom(roomindexX, roomindexY, 1)
                        ElseIf m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY - 1).GetIndex = DoorHouseIndex Then
                            CreateHouse(1)
                        Else

                            MovePlayer(0, -1)
                        End If
                    End If
                ElseIf e.KeyCode = Keys.W And Player1.GetY() <> 0 Then
                    PlayerUp(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
                    Player1.ImageNum(1)
                End If
                'LEFTWARD MOVEMENT LEFTWARD MOVEMENT LEFTWARD MOVEMENT
                If e.KeyCode = Keys.A And Player1.GetX() <> 0 And m_Game(levelindex, roomindexX, roomindexY, Player1.GetX() - 1, Player1.GetY()).GetIndex <> WallTileIndex Then
                    If Player1.GetImageNum <> 2 Then
                        PlayerLeft(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
                        Player1.ImageNum(2)
                    Else
                        If m_Game(levelindex, roomindexX, roomindexY, Player1.GetX - 1, Player1.GetY).GetIndex = DoorLeftIndex Then
                            roomindexX -= 1
                            CreateRoom(roomindexX, roomindexY, 3)
                        Else
                            MovePlayer(-1, 0)
                        End If
                    End If
                ElseIf e.KeyCode = Keys.A And Player1.GetX() <> 0 Then
                    PlayerLeft(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
                    Player1.ImageNum(2)
                End If
                'DOWNWARD MOVEMENT DOWNWARD MOVEMENT DOWNWARD MOVEMENT
                If e.KeyCode = Keys.S And Player1.GetY() <> 15 And m_Game(levelindex, roomindexX, roomindexY, Player1.GetX(), Player1.GetY() + 1).GetIndex <> WallTileIndex Then
                    If Player1.GetImageNum <> 3 Then
                        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
                        Player1.ImageNum(3)
                    Else
                        If m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY + 1).GetIndex = DoorDownIndex Then
                            roomindexY += 1
                            CreateRoom(roomindexX, roomindexY, 0)
                        ElseIf m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY + 1).GetIndex = DoorHouseIndex Then
                            CreateRoom(roomindexX, roomindexY, 5)

                        Else
                            MovePlayer(0, 1)
                        End If
                    End If
                ElseIf e.KeyCode = Keys.S And Player1.GetY() <> 15 Then
                    PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
                    Player1.ImageNum(3)
                End If
                'Arrow Key Player Controls

                'RIGHT MOVEMENT RIGHT MOVEMENT RIGHTMOVEMENT
                If e.KeyCode = Keys.Right And Player1.GetX() <> 15 And m_Game(levelindex, roomindexX, roomindexY, Player1.GetX() + 1, Player1.GetY()).GetIndex <> WallTileIndex Then
                    If Player1.GetImageNum <> 0 Then
                        PlayerRight(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
                        Player1.ImageNum(0)
                    Else
                        If m_Game(levelindex, roomindexX, roomindexY, Player1.GetX + 1, Player1.GetY).GetIndex = DoorDownIndex Then
                            roomindexY += 1
                            CreateRoom(roomindexX, roomindexY, 0)
                        ElseIf m_Game(levelindex, roomindexX, roomindexY, Player1.GetX + 1, Player1.GetY).GetIndex = DoorUPIndex Then
                            roomindexY -= 1
                            CreateRoom(roomindexX, roomindexY, 1)
                        Else
                            MovePlayer(1, 0)
                        End If
                    End If
                ElseIf e.KeyCode = Keys.Right And Player1.GetX() <> 15 Then
                    PlayerRight(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
                    Player1.ImageNum(0)
                End If
                ' UPWARD MOVEMENT UPWARD MOVEMENT UPWARD MOVEMENT
                If e.KeyCode = Keys.Up And Player1.GetY() <> 0 And m_Game(levelindex, roomindexX, roomindexY, Player1.GetX(), Player1.GetY() - 1).GetIndex <> WallTileIndex Then
                    If Player1.GetImageNum <> 1 Then
                        PlayerUp(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
                        Player1.ImageNum(1)
                    Else
                        If m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY - 1).GetIndex = DoorUPIndex Then
                            roomindexY -= 1
                            CreateRoom(roomindexX, roomindexY, 1)
                        Else
                            MovePlayer(0, -1)
                        End If
                    End If
                ElseIf e.KeyCode = Keys.Up And Player1.GetY() <> 0 Then
                    PlayerUp(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
                    Player1.ImageNum(1)
                End If
                'LEFTWARD MOVEMENT LEFTWARD MOVEMENT LEFTWARD MOVEMENT
                If e.KeyCode = Keys.Left And Player1.GetX() <> 0 And m_Game(levelindex, roomindexX, roomindexY, Player1.GetX() - 1, Player1.GetY()).GetIndex <> WallTileIndex Then
                    If Player1.GetImageNum <> 2 Then
                        PlayerLeft(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
                        Player1.ImageNum(2)
                    Else
                        If m_Game(levelindex, roomindexX, roomindexY, Player1.GetX - 1, Player1.GetY).GetIndex = DoorLeftIndex Then
                            roomindexX -= 1
                            CreateRoom(roomindexX, roomindexY, 1)
                        Else
                            MovePlayer(-1, 0)
                        End If
                    End If
                ElseIf e.KeyCode = Keys.Left And Player1.GetX() <> 0 Then
                    PlayerLeft(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
                    Player1.ImageNum(2)
                End If
                'DOWNWARD MOVEMENT DOWNWARD MOVEMENT DOWNWARD MOVEMENT
                If e.KeyCode = Keys.Down And Player1.GetY() <> 15 And m_Game(levelindex, roomindexX, roomindexY, Player1.GetX(), Player1.GetY() + 1).GetIndex <> WallTileIndex Then
                    If Player1.GetImageNum <> 3 Then
                        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
                        Player1.ImageNum(3)
                    Else
                        If m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY + 1).GetIndex = DoorDownIndex Then
                            roomindexY += 1
                            CreateRoom(roomindexX, roomindexY, 0)
                        Else
                            MovePlayer(0, 1)
                        End If
                    End If
                ElseIf e.KeyCode = Keys.Down And Player1.GetY() <> 15 Then
                    PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
                    Player1.ImageNum(3)
                End If
            Catch ex As Exception

            End Try
            If e.KeyCode = Keys.Space Then
                'Rough Framework for fighting, need to add array of enemys and need to add a for next statement to check against enemys like how enemy1 is checked agaisnt for here.
                If Player1.GetImageNum = 0 Then
                    AR.Enabled = True
                    If m_Game(0, roomindexX, roomindexY, Player1.GetX() + 1, Player1.GetY()).CheckForEnemy = True Then
                        PlayerAttack(1, 0)
                    End If
                    PickingUp(1, 0)
                End If
                If Player1.GetImageNum = 1 Then
                    AT.Enabled = True
                    If m_Game(0, roomindexX, roomindexY, Player1.GetX(), Player1.GetY() - 1).CheckForEnemy = True Then
                        PlayerAttack(0, -1)
                    End If
                    PickingUp(0, -1)
                End If
                If Player1.GetImageNum = 2 Then
                    AL.Enabled = True
                    If m_Game(0, roomindexX, roomindexY, Player1.GetX() - 1, Player1.GetY()).CheckForEnemy = True Then
                        PlayerAttack(-1, 0)
                    End If
                    PickingUp(-1, 0)
                End If
                If Player1.GetImageNum = 3 Then
                    AD.Enabled = True
                    If m_Game(0, roomindexX, roomindexY, Player1.GetX(), Player1.GetY() + 1).CheckForEnemy = True Then
                        PlayerAttack(0, 1)
                    End If
                    PickingUp(0, 1)
                End If
            End If
            mouseisdown = True
            MovespeedMod.Enabled = True
        End If
    End Sub

    Sub PlayerAttack(x As Integer, Y As Integer)

        If x = 1 Then
            For i = 0 To lvl1EnemyArray.Count - 1
                If lvl1EnemyArray(i).GetX = Player1.GetX + x And lvl1EnemyArray(i).GetY = Player1.GetY + Y Then
                    lvl1EnemyArray(i).SetHealth(lvl1EnemyArray(i).GetHealth() - playerDamage)
                    If lvl1EnemyArray(i).GetHealth <= 0 Then
                        m_Game(0, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).setEnemy(False)
                        m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).ReturnBackGround())
                    End If
                End If
            Next
            For i = 0 To lvl2EnemyArray.Count - 1
                If lvl2EnemyArray(i).GetX = Player1.GetX + x And lvl2EnemyArray(i).GetY = Player1.GetY + Y Then
                    lvl2EnemyArray(i).SetHealth(lvl2EnemyArray(i).GetHealth() - playerDamage)
                    If lvl2EnemyArray(i).GetHealth <= 0 Then
                        m_Game(0, roomindexX, roomindexY, lvl2EnemyArray(i).GetX, lvl2EnemyArray(i).GetY).setEnemy(False)
                        m_buttonArray(lvl2EnemyArray(i).GetX, lvl2EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, lvl2EnemyArray(i).GetX, lvl2EnemyArray(i).GetY).ReturnBackGround())
                    End If
                End If
            Next
        End If
        If x = -1 Then
            For i = 0 To lvl1EnemyArray.Count - 1
                If lvl1EnemyArray(i).GetX = Player1.GetX + x And lvl1EnemyArray(i).GetY = Player1.GetY + Y Then
                    lvl1EnemyArray(i).SetHealth(lvl1EnemyArray(i).GetHealth() - playerDamage)
                    If lvl1EnemyArray(i).GetHealth <= 0 Then
                        m_Game(0, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).setEnemy(False)
                        m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).ReturnBackGround())
                    End If
                End If
            Next
            For i = 0 To lvl2EnemyArray.Count - 1
                If lvl2EnemyArray(i).GetX = Player1.GetX + x And lvl2EnemyArray(i).GetY = Player1.GetY + Y Then
                    lvl2EnemyArray(i).SetHealth(lvl2EnemyArray(i).GetHealth() - playerDamage)
                    If lvl2EnemyArray(i).GetHealth <= 0 Then
                        m_Game(0, roomindexX, roomindexY, lvl2EnemyArray(i).GetX, lvl2EnemyArray(i).GetY).setEnemy(False)
                        m_buttonArray(lvl2EnemyArray(i).GetX, lvl2EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, lvl2EnemyArray(i).GetX, lvl2EnemyArray(i).GetY).ReturnBackGround())
                    End If
                End If
            Next
        End If
        If Y = -1 Then
            For i = 0 To lvl1EnemyArray.Count - 1
                If lvl1EnemyArray(i).GetX = Player1.GetX + x And lvl1EnemyArray(i).GetY = Player1.GetY + Y Then
                    lvl1EnemyArray(i).SetHealth(lvl1EnemyArray(i).GetHealth() - playerDamage)
                    If lvl1EnemyArray(i).GetHealth <= 0 Then
                        m_Game(0, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).setEnemy(False)
                        m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).ReturnBackGround())
                    End If
                End If
            Next
            For i = 0 To lvl2EnemyArray.Count - 1
                If lvl2EnemyArray(i).GetX = Player1.GetX + x And lvl2EnemyArray(i).GetY = Player1.GetY + Y Then
                    lvl2EnemyArray(i).SetHealth(lvl2EnemyArray(i).GetHealth() - playerDamage)
                    If lvl2EnemyArray(i).GetHealth <= 0 Then
                        m_Game(0, roomindexX, roomindexY, lvl2EnemyArray(i).GetX, lvl2EnemyArray(i).GetY).setEnemy(False)
                        m_buttonArray(lvl2EnemyArray(i).GetX, lvl2EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, lvl2EnemyArray(i).GetX, lvl2EnemyArray(i).GetY).ReturnBackGround())
                    End If
                End If
            Next
        End If
        If Y = 1 Then
            For i = 0 To lvl1EnemyArray.Count - 1
                If lvl1EnemyArray(i).GetX = Player1.GetX + x And lvl1EnemyArray(i).GetY = Player1.GetY + Y Then
                    lvl1EnemyArray(i).SetHealth(lvl1EnemyArray(i).GetHealth() - playerDamage)
                    If lvl1EnemyArray(i).GetHealth <= 0 Then
                        m_Game(0, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).setEnemy(False)
                        m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).ReturnBackGround())
                    End If
                End If
            Next
            For i = 0 To lvl2EnemyArray.Count - 1
                If lvl2EnemyArray(i).GetX = Player1.GetX + x And lvl2EnemyArray(i).GetY = Player1.GetY + Y Then
                    lvl2EnemyArray(i).SetHealth(lvl2EnemyArray(i).GetHealth() - playerDamage)
                    If lvl2EnemyArray(i).GetHealth <= 0 Then
                        m_Game(0, roomindexX, roomindexY, lvl2EnemyArray(i).GetX, lvl2EnemyArray(i).GetY).setEnemy(False)
                        m_buttonArray(lvl2EnemyArray(i).GetX, lvl2EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, lvl2EnemyArray(i).GetX, lvl2EnemyArray(i).GetY).ReturnBackGround())
                    End If
                End If
            Next
        End If

    End Sub
    'Player Attacking To The Right
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles AR.Tick
        If Player1.GetImageNum <> 8 Then
            'do attack animation

            If currentWeapon = 0 Then
                m_buttonArray(Player1.GetX + 1, Player1.GetY).BackgroundImage = m_buttonArray(Player1.GetX + 1, Player1.GetY).BackgroundImage

            ElseIf currentWeapon = 1 Then

            End If



            Player1.ImageNum(8)
        Else
            Player1.ImageNum(0)
            PlayerRight(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
            AR.Enabled = False
        End If
    End Sub
    'Player Attacking To The Top
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles AT.Tick
        If Player1.GetImageNum <> 8 Then
            m_buttonArray(Player1.GetX, Player1.GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
            Player1.ImageNum(8)
        Else
            Player1.ImageNum(1)
            PlayerUp(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
            AT.Enabled = False
        End If
    End Sub
    'Player Attacking To The Left
    Private Sub AL_Tick(sender As Object, e As EventArgs) Handles AL.Tick
        If Player1.GetImageNum <> 8 Then
            m_buttonArray(Player1.GetX, Player1.GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
            Player1.ImageNum(8)
        Else
            Player1.ImageNum(2)
            PlayerLeft(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
            AL.Enabled = False
        End If
    End Sub
    'Player Attacking Down
    Private Sub AD_Tick(sender As Object, e As EventArgs) Handles AD.Tick
        If Player1.GetImageNum <> 8 Then
            m_buttonArray(Player1.GetX, Player1.GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
            Player1.ImageNum(8)
        Else
            Player1.ImageNum(3)
            PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
            AD.Enabled = False
        End If
    End Sub


    'Updates The Players Heart To Show Health Amount
    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        PictureBox1.Image = ImageList2.Images(Player1.GetHP)
    End Sub

#Region "Player Images"

    Sub PlayerLeft(a As Integer)

        m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = CombinePlayerLayers(ImageList1.Images(a), baseimageL, pantsL, ShirtL, HairL)
    End Sub
    Sub PlayerRight(a As Integer)
        m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = CombinePlayerLayers(ImageList1.Images(a), baseimageR, pantsR, ShirtR, HairR)
    End Sub
    Sub PlayerDown(a As Integer)
        m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = CombinePlayerLayers(ImageList1.Images(a), baseimageD, pantsD, ShirtD, HairD)
    End Sub
    Sub PlayerUp(a As Integer)
        m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = CombinePlayerLayers(ImageList1.Images(a), baseimageU, pantsU, ShirtU, HairU)
    End Sub





#End Region






    Sub MovePlayer(x As Integer, y As Integer)
        If m_Game(levelindex, roomindexX, roomindexY, Player1.GetX() + x, Player1.GetY() + y).CheckForEnemy = False Then
            m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).setPlayer(False)
            m_buttonArray(Player1.GetX(), Player1.GetY()).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
            Player1.SetX(Player1.GetX() + x)
            Player1.SetY(Player1.GetY() + y)
            If x = 1 Then
                PlayerRight(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
            End If
            If y = 1 Then
                PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
            End If
            If x = -1 Then
                PlayerLeft(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
            End If
            If y = -1 Then
                PlayerUp(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
            End If
            m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).setPlayer(True)
            ReDraw(-x, -y)
        End If
    End Sub
    Sub ReDraw(x As Integer, y As Integer)
        If m_Game(levelindex, roomindexX, roomindexY, Player1.GetX + x, Player1.GetY + y).GetIndex = PickUp Then
            For i = 0 To HPPACK1.Count - 1
                If Player1.GetX + x = HPPACK1(i).ReturnX And Player1.GetY + y = HPPACK1(i).ReturnY And HPPACK1(i).ActiveCheck Then
                    hp(HPPACK1(i).ReturnX, HPPACK1(i).ReturnY, m_Game(levelindex, roomindexX, roomindexY, HPPACK1(i).ReturnX, HPPACK1(i).ReturnY).ReturnBackGround)
                End If
            Next
            For i = 0 To Chestb.Count - 1
                If Player1.GetX + x = Chestb(i).ReturnX And Player1.GetY + y = Chestb(i).ReturnY Then 'And Chestb(i).ActiveCheck Then
                    Chest(Chestb(i).ReturnX, Chestb(i).ReturnY, m_Game(levelindex, roomindexX, roomindexY, Chestb(i).ReturnX, Chestb(i).ReturnY).ReturnBackGround)
                End If
            Next
        End If
    End Sub
    Sub PickingUp(x As Integer, y As Integer)
        For i = 0 To HPPACK1.Count - 1
            If HPPACK1(i).ReturnX = Player1.GetX + x And HPPACK1(i).ReturnY = Player1.GetY + y And HPPACK1(i).ActiveCheck = True Then
                healthPotion += 1
                HPPACK1(i).SetActive(False)
                ResetPack()
                DisplayText("+ 1 Health Potion")
                m_buttonArray(HPPACK1(i).ReturnX, HPPACK1(i).ReturnY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, HPPACK1(i).ReturnX, HPPACK1(i).ReturnY).ReturnBackGround())
            End If
        Next
        For i = 0 To Chestb.Count - 1
            If Chestb(i).ReturnX = Player1.GetX + x And Chestb(i).ReturnY = Player1.GetY + y And Chestb(i).ActiveCheck = True Then
                If Chestb(i).WeaponCheck = False Then

                    BackpackList.Items.Add(Chestb(i).Item())
                    DisplayText(Chestb(i).Item())

                Else
                    WeaponList.Items.Add(Chestb(i).Item())
                    DisplayText("You Got The " + Chestb(i).Item())
                    Chestb(i).SetActive(False)
                    If Chestb(i).Item = "RustySword" Then
                        RustySword = True
                    End If

                End If
            End If
        Next
    End Sub





    '- - - - - - - - - - - - - - -Eneny AI- - - - - - - - - - - - -





    Dim attackchecker As Integer
    Private Sub EnemyAttackRat_Tick(sender As Object, e As EventArgs) Handles EnemyAttackRat.Tick
        For i = 0 To lvl1EnemyArray.Count - 1
            If attackchecker = 0 Then

                If lvl1EnemyArray(i).GetAttack = True Then
                    If lvl1EnemyArray(i).GetDirection = 0 Then

                        Dim bmp As Bitmap
                        bmp = BloodStones.My.Resources.Resource1.Rat_Front_
                        bmp.MakeTransparent(Color.White)
                        'Left
                        m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).ReturnBackGround)

                        If m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY + 1).CheckForPlayer = True Then
                            Player1.hp(Player1.GetHP - 1)
                        End If
                    End If
                    If lvl1EnemyArray(i).GetDirection = 1 Then
                        Dim bmp As Bitmap
                        bmp = BloodStones.My.Resources.Resource1.Rat_Front_
                        bmp.MakeTransparent(Color.White)
                        'Left
                        m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).ReturnBackGround)
                        If m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY - 1).CheckForPlayer = True Then
                            Player1.hp(Player1.GetHP - 1)
                        End If
                    End If
                    If lvl1EnemyArray(i).GetDirection = 2 Then
                        Dim bmp As Bitmap
                        bmp = BloodStones.My.Resources.Resource1.Rat_Front_
                        bmp.MakeTransparent(Color.White)
                        'Left
                        m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).ReturnBackGround)
                        If m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX - 1, lvl1EnemyArray(i).GetY).CheckForPlayer = True Then
                            Player1.hp(Player1.GetHP - 1)
                        End If
                    End If
                    If lvl1EnemyArray(i).GetDirection = 3 Then
                        Dim bmp As Bitmap
                        bmp = BloodStones.My.Resources.Resource1.Rat_Front_
                        bmp.MakeTransparent(Color.White)
                        'Left
                        m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).ReturnBackGround)
                        If m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX + 1, lvl1EnemyArray(i).GetY).CheckForPlayer = True Then
                            Player1.hp(Player1.GetHP - 1)
                        End If
                    End If
                End If

                attackchecker = 1
            Else
                If lvl1EnemyArray(i).GetDirection = 0 Then
                    Dim bmp As Bitmap
                    bmp = BloodStones.My.Resources.Resource1.Rat_Front_
                    bmp.MakeTransparent(Color.White)
                    m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = CombineImages(m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage, bmp)
                End If
                If lvl1EnemyArray(i).GetDirection = 1 Then
                    Dim bmp As Bitmap
                    bmp = BloodStones.My.Resources.Resource1.Rat_Back_
                    bmp.MakeTransparent(Color.White)
                    m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = CombineImages(m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage, bmp)
                End If
                If lvl1EnemyArray(i).GetDirection = 2 Then
                    Dim bmp As Bitmap
                    bmp = BloodStones.My.Resources.Resource1.Rat_left_
                    bmp.MakeTransparent(Color.White)
                    m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = CombineImages(m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage, bmp)
                End If
                If lvl1EnemyArray(i).GetDirection = 3 Then
                    Dim bmp As Bitmap
                    bmp = BloodStones.My.Resources.Resource1.Rat_Right_
                    bmp.MakeTransparent(Color.White)
                    m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = CombineImages(m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage, bmp)
                End If
                lvl1EnemyArray(i).SetAttack(False)
                attackchecker = 0
            End If
            If lvl1EnemyArray(i).CheckDead = True Then
                m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).ReturnBackGround)
            End If
            EnemyAttackRat.Enabled = False
        Next
    End Sub
    Private Sub EnemyAI_Tick(sender As Object, e As EventArgs) Handles EnemyAI.Tick
        Dim a As Integer
        Dim b As Integer
        If levelindex = 0 Then
            If roomindexY = 2 Then
                For i = 0 To lvl1EnemyArray.Count - 1
                    a = rnd.Next(1, 10)
                    b = rnd.Next(1, 10)
                    If lvl1EnemyArray(i).CheckDead = False Then
                        If a < 5 Then
                            If b < 5 Then
                                Dim bmp As Bitmap
                                bmp = BloodStones.My.Resources.Resource1.Rat_Front_
                                bmp.MakeTransparent(Color.White)
                                'Down
                                m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).ReturnBackGround)
                                m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).setEnemy(False)
                                If m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY + 1).GetIndex <> WallTileIndex And m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY + 1).CheckForPlayer = False Then
                                    lvl1EnemyArray(i).SetY(lvl1EnemyArray(i).GetY + 1)
                                End If
                                m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = CombineImages(m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage, bmp)
                                m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).setEnemy(True)
                                lvl1EnemyArray(i).SetDirection(0)
                            ElseIf b >= 5 Then
                                Dim bmp As Bitmap
                                bmp = BloodStones.My.Resources.Resource1.Rat_Back_
                                bmp.MakeTransparent(Color.White)
                                'UP
                                m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).ReturnBackGround)
                                m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).setEnemy(False)
                                If m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY - 1).GetIndex <> WallTileIndex And m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY - 1).CheckForPlayer = False Then
                                    lvl1EnemyArray(i).SetY(lvl1EnemyArray(i).GetY - 1)
                                End If
                                m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).setEnemy(True)
                                m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = CombineImages(m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage, bmp)
                                lvl1EnemyArray(i).SetDirection(1)
                            End If

                        ElseIf a >= 5 Then

                            If b < 5 Then
                                Dim bmp As Bitmap
                                bmp = BloodStones.My.Resources.Resource1.Rat_left_
                                bmp.MakeTransparent(Color.White)
                                'Left
                                m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).ReturnBackGround)
                                m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).setEnemy(False)
                                If m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX - 1, lvl1EnemyArray(i).GetY).GetIndex <> WallTileIndex And m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX - 1, lvl1EnemyArray(i).GetY).CheckForPlayer = False Then
                                    lvl1EnemyArray(i).SetX(lvl1EnemyArray(i).GetX - 1)
                                End If
                                m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).setEnemy(True)
                                m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = CombineImages(m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage, bmp)
                                lvl1EnemyArray(i).SetDirection(2)
                            ElseIf b >= 5 Then
                                Dim bmp As Bitmap
                                bmp = BloodStones.My.Resources.Resource1.Rat_Right_
                                bmp.MakeTransparent(Color.White)
                                'Right
                                m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = ImageList1.Images(m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).ReturnBackGround)
                                m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).setEnemy(False)
                                If m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX + 1, lvl1EnemyArray(i).GetY).GetIndex <> WallTileIndex And m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX + 1, lvl1EnemyArray(i).GetY).CheckForPlayer = False Then
                                    lvl1EnemyArray(i).SetX(lvl1EnemyArray(i).GetX + 1)
                                End If
                                m_Game(levelindex, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).setEnemy(True)
                                m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = CombineImages(m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage, bmp)
                                lvl1EnemyArray(i).SetDirection(3)
                            End If
                        End If


                        'Check which way they're looking

                    End If
                    Dim at As Integer
                    at = rnd.Next(0, 5)
                    If a = 4 Then
                        lvl1EnemyArray(i).SetAttack(True)
                        EnemyAttackRat.Enabled = True
                    End If
                Next
            End If
        End If
    End Sub
    Sub EnemyAttack(b As clsEnemy)
        'Check if they are a rat

    End Sub







    '- - - - - - - - - - - - - - - - -Game Map Start Point- - - - - - - - - - - - - - - - -

    'Plans For Characer Creation:
    'Pregame menu with save slots which upon loading one you either start the game or create a character and at the end of creating the character you enter the game.
    Sub RoomTest(start As Integer)
        'SETS THE PLAYER LOCATION BASED ON TILE
        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

        If start = 0 Then
            Player1 = New clsPlayer(1, 1)
            Player1.hp(7)
            m_Game(0, roomindexX, roomindexY, Player1.GetX(), Player1.GetY()).setPlayer(True)
        End If
        If start = 1 Then
            Player1.SetX(14)
            Player1.SetY(14)
        End If



        'GENERATES THE ROOM AND DEFAULTS ALL TILES TO BASE TEXTURE
        If roomindexY = 0 And levelindex = 0 Then
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
                    m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(0)
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
                buttonArray(i, 0).BackgroundImage = ImageList1.Images(2)
                m_Game(0, roomindexX, roomindexY, i, 0).SetIndex(WallTileIndex)
                m_Game(0, roomindexX, roomindexY, i, 0).SetBackGround(2)
            Next
            'CREATES LEFT WALL
            For i2 = 0 To 15
                buttonArray(0, i2).BackgroundImage = ImageList1.Images(2)
                m_Game(0, roomindexX, roomindexY, 0, i2).SetIndex(WallTileIndex)
                m_Game(0, roomindexX, roomindexY, 0, i2).SetBackGround(2)
            Next
            'CREATES BOTTOM WALL
            For i = 0 To 15
                buttonArray(i, 15).BackgroundImage = ImageList1.Images(2)
                m_Game(0, roomindexX, roomindexY, i, 15).SetIndex(WallTileIndex)
                m_Game(0, roomindexX, roomindexY, i, 15).SetBackGround(2)
            Next
            'CREATES RIGHT WALL
            For i2 = 0 To 15
                buttonArray(15, i2).BackgroundImage = ImageList1.Images(2)
                m_Game(0, roomindexX, roomindexY, 15, i2).SetIndex(WallTileIndex)
                m_Game(0, roomindexX, roomindexY, 15, i2).SetBackGround(2)
            Next
            'CREATES A WALL INSIDE THE ROOM
            For i = 0 To 13
                buttonArray(i, 2).BackgroundImage = ImageList1.Images(2)
                m_Game(0, roomindexX, roomindexY, i, 2).SetIndex(WallTileIndex)
                m_Game(0, roomindexX, roomindexY, i, 2).SetBackGround(2)
            Next
            'CREATES A WALL INSIDE THE ROOM
            For i = 2 To 15
                buttonArray(i, 4).BackgroundImage = ImageList1.Images(2)
                m_Game(0, roomindexX, roomindexY, i, 4).SetIndex(WallTileIndex)
                m_Game(0, roomindexX, roomindexY, i, 4).SetBackGround(2)
            Next
            'CREATES A WALL INSIDE THE ROOM
            For i = 0 To 13
                buttonArray(i, 6).BackgroundImage = ImageList1.Images(2)
                m_Game(0, roomindexX, roomindexY, i, 6).SetIndex(WallTileIndex)
                m_Game(0, roomindexX, roomindexY, i, 6).SetBackGround(2)
            Next
            'CREATES A WALL INSIDE THE ROOM
            For i = 2 To 15
                buttonArray(i, 8).BackgroundImage = ImageList1.Images(2)
                m_Game(0, roomindexX, roomindexY, i, 8).SetIndex(WallTileIndex)
                m_Game(0, roomindexX, roomindexY, i, 8).SetBackGround(2)
            Next
            'Creates VERTICAL wall in room
            For i2 = 8 To 13
                buttonArray(2, i2).BackgroundImage = ImageList1.Images(2)
                m_Game(0, roomindexX, roomindexY, 2, i2).SetIndex(WallTileIndex)
                m_Game(0, roomindexX, roomindexY, 2, i2).SetBackGround(2)
            Next
            'Creates VERTICAL wall in room
            For i2 = 10 To 15
                buttonArray(4, i2).BackgroundImage = ImageList1.Images(2)
                m_Game(0, roomindexX, roomindexY, 4, i2).SetIndex(WallTileIndex)
                m_Game(0, roomindexX, roomindexY, 4, i2).SetBackGround(2)
            Next

            'Generate Level Pickups

            If HPPACK1(0).ActiveCheck() = True Then
                m_Game(0, 0, 0, HPPACK1(0).ReturnX, HPPACK1(0).ReturnY).SetIndex(3)
                HPPACK1(0).SetHealth(3)
                Dim bmp As Bitmap
                bmp = BloodStones.My.Resources.Resource1.Health_Potion
                bmp.MakeTransparent(Color.White)
                buttonArray(HPPACK1(0).ReturnX, HPPACK1(0).ReturnY).BackgroundImage = CombineImages(ImageList1.Images(4), bmp)

            End If

            'Places Player          



            'Place Enemys            
            m_buttonArray = buttonArray
            PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
            For i = 0 To lvl1EnemyArray.Count - 1
                If lvl1EnemyArray(i).CheckDead = False Then
                    m_Game(0, roomindexX, roomindexY, lvl1EnemyArray(1).GetX, lvl1EnemyArray(1).GetY).setEnemy(True)
                    m_Game(0, roomindexX, roomindexY, lvl1EnemyArray(0).GetX, lvl1EnemyArray(0).GetY).setEnemy(True)
                    Dim bmp As Bitmap
                    bmp = BloodStones.My.Resources.Resource1.Rat_Front_
                    bmp.MakeTransparent(Color.White)
                    m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = CombineImages(m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage, bmp)
                End If
            Next






        End If
        'For i = 0 To lvl1EnemyArray.Count - 1
        ' Dim open As Integer
        'If lvl1EnemyArray(i).CheckDead = True Then
        'open += 1
        'End If
        'If open = 2 Then
        'EnemyAI.Enabled = False
        'm_Game(0, roomindex, 15, 14).SetIndex(10)
        ' End If
        '  Next



        DisplayText("Use the WASD or Arrow Keys To Move!")
    End Sub


    Sub CreateRoom(x As Integer, y As Integer, start As Integer)

        For i = 0 To 15
            For i2 = 0 To 15
                m_buttonArray(i, i2).Dispose()
                ' m_Game(0, roomindex, i, i2).SetIndex(0)
                '  m_Game(0, roomindex, i, i2).setEnemy(False)
            Next
        Next
        'cave
        If x = 0 And y = 0 Then
            Room1(start)
        End If
        If x = 0 And y = 1 Then
            Room2(start)
        End If
        If x = 0 And y = 2 Then
            Room3(start)
        End If
        'first path
        If x = 0 And y = 3 Then
            Room4(start)
        End If
        If x = 0 And y = 4 Then
            Room5(start)
        End If
        'Town one
        If x = 0 And y = 5 Then
            Room6(start)
        End If
        If x = 0 And y = 6 Then
            Room7(start)
        End If
        If x = 1 And y = 5 Then
            Room8(start)
        End If
        If x = 1 And y = 6 Then
            Room9(start)
        End If
        'Second Path
        If x = 2 And y = 6 Then
            Room10(start)
        End If
        If x = 3 And y = 6 Then
            Room11(start)
        End If
        'Town Two
        If x = 4 And y = 6 Then
            Room12(start)
        End If
        If x = 4 And y = 5 Then
            Room13(start)
        End If
        If x = 5 And y = 5 Then
            Room14(start)
        End If
        If x = 5 And y = 6 Then
            Room15(start)
        End If
        'Third Path
        If x = 5 And y = 4 Then
            Room16(start)
        End If
        If x = 6 And y = 4 Then
            Room17(start)
        End If

        'Fourth Path
        If x = 6 And y = 6 Then
            Room18(start)
        End If
        If x = 7 And y = 6 Then
            Room19(start)
        End If
        If x = 7 And y = 7 Then
            Room20(start)
        End If
        If x = 8 And y = 6 Then
            Room21(start)
        End If
        'Town Three

        If x = 9 And y = 6 Then
            Room22(start)
        End If
        If x = 9 And y = 5 Then
            Room23(start)
        End If
        If x = 10 And y = 5 Then
            Room24(start)
        End If
        If x = 11 And y = 5 Then
            Room25(start)
        End If
        If x = 10 And y = 6 Then
            Room26(start)
        End If
        If x = 11 And y = 6 Then
            Room27(start)
        End If
        If x = 9 And y = 7 Then
            Room28(start)
        End If
        If x = 10 And y = 7 Then
            Room29(start)
        End If
        If x = 11 And y = 7 Then
            Room30(start)
        End If
    End Sub
    Sub CreateHouse(start As Integer)
        For i = 0 To 15
            For i2 = 0 To 15
                m_buttonArray(i, i2).Dispose()
            Next
        Next
        If roomindexX = 0 And roomindexY = 5 Then
            If Player1.GetX = 3 And Player1.GetY = 7 Then
                House1(start)
            ElseIf Player1.GetX = 3 And Player1.GetY = 12 Then
                House2(start)
            ElseIf Player1.GetX = 11 And Player1.GetY = 12 Then
                House3(start)
            End If
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'SET ENEMY LOCATIONS
        lvl2EnemyArray(0) = New clsEnemy(2, 5)
        lvl2EnemyArray(0).SetHealth(3)
        lvl2EnemyArray(1) = New clsEnemy(2, 7)
        lvl2EnemyArray(1).SetHealth(5)
        lvl2EnemyArray(2) = New clsEnemy(2, 9)
        lvl2EnemyArray(2).SetHealth(100)
        lvl1EnemyArray(0) = New clsEnemy(8, 7)
        lvl1EnemyArray(0).SetHealth(3)
        lvl1EnemyArray(1) = New clsEnemy(8, 9)
        lvl1EnemyArray(1).SetHealth(3)
        HPPACK1(0) = New clsPickup(14, 7)
        HPPACK1(0).SetActive(True)
        Chestb(0) = New clsPickup(14, 8)
        Chestb(0).SetActive(True)






    End Sub




    Sub Room1(start As Integer)
        For i = 1 To 16
            For i2 = 1 To 16
                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)
            Next
        Next
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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(7)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(7)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next
        'Set Player Starting Location.
        If start = 0 Then
            Player1 = New clsPlayer(6, 1)
            Player1.hp(7)
            m_Game(0, roomindexX, roomindexY, Player1.GetX(), Player1.GetY()).setPlayer(True)
        End If
        If start = 1 Then

            Player1.SetX(8)
            Player1.SetY(14)
        End If
        m_buttonArray = buttonArray


        SetTile1(10, 1, 21)
        SetTile1(10, 2, 21)
        SetTile1(10, 3, 21)
        SetTile1(11, 1, 21)
        SetTile1(11, 2, 21)
        SetTile1(11, 3, 21)
        SetTile1(12, 1, 21)
        SetTile1(12, 2, 21)
        SetTile1(12, 3, 21)



        'CREATES TOP WALL
        DrawRoomWallHori(0, 15, 0, 9)
        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 9)
        'CREATES BLACK AREAS
        For i = 0 To 3
            For i2 = 0 To 15
                m_buttonArray(i, i2).BackgroundImage = ImageList1.Images(15)
            Next
        Next
        For i = 14 To 15
            For i2 = 0 To 3
                m_buttonArray(i, i2).BackgroundImage = ImageList1.Images(15)
            Next
        Next
        For i = 11 To 15
            For i2 = 4 To 15
                m_buttonArray(i, i2).BackgroundImage = ImageList1.Images(15)
            Next
        Next
        'CREATES LEFT WALL
        DrawRoomWallVert(0, 6, 4, 9)

        'CREATES LEFT WALL
        DrawRoomWallVert(6, 10, 3, 9)

        'CREATES LEFT WALL
        DrawRoomWallVert(10, 15, 4, 9)

        'CREATES RIGHT WALL
        DrawRoomWallVert(4, 7, 10, 9)

        'CREATES RIGHT WALL
        DrawRoomWallVert(7, 10, 11, 9)

        'CREATES RIGHT WALL
        DrawRoomWallVert(10, 15, 10, 9)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 3, 13, 9)

        DrawRoomWallHori(10, 13, 4, 9)

        m_buttonArray(8, 15).BackgroundImage = ImageList1.Images(7)
        m_Game(0, roomindexX, roomindexY, 8, 15).SetIndex(DoorDownIndex)
        Player1.ImageNum(3)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
        DisplayText("Use the WASD or Arrow Keys To Move!")
    End Sub
    Sub Room2(start As Integer)
        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(7)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(7)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next



        'Set Player Starting Location.


        If start = 0 Then
            Player1.SetX(8)
            Player1.SetY(1)
        ElseIf start = 1 Then
            Player1.SetX(7)
            Player1.SetY(14)
        End If
        m_buttonArray = buttonArray
        'CREATES TOP WALL
        DrawRoomWallHori(0, 15, 0, 9)

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 9)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 9)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 9)

        DrawRoomWallHori(10, 12, 2, 9)

        DrawRoomWallHori(9, 9, 1, 9)

        DrawRoomWallVert(0, 5, 6, 9)

        DrawRoomWallHori(0, 5, 3, 9)

        DrawRoomWallHori(0, 4, 11, 9)

        DrawRoomWallHori(7, 12, 9, 9)
        DrawRoomWallHori(7, 10, 6, 9)

        For i = 13 To 15
            For i2 = 0 To 4
                Dim bound As Integer = i2 * 3
                m_buttonArray(i, bound).BackgroundImage = ImageList1.Images(9)
                m_Game(0, roomindexX, roomindexY, i, bound).SetIndex(WallTileIndex)
                m_Game(0, roomindexX, roomindexY, i, bound).SetBackGround(9)
            Next
        Next
        DrawRoomWallVert(12, 15, 5, 9)

        'CREATES BLACK AREA
        For i = 0 To 5
            For i2 = 0 To 2
                m_buttonArray(i, i2).BackgroundImage = ImageList1.Images(15)
            Next
        Next
        For i = 0 To 4
            For i2 = 12 To 15
                m_buttonArray(i, i2).BackgroundImage = ImageList1.Images(15)
            Next
        Next
        For i = 10 To 15
            For i2 = 0 To 1
                m_buttonArray(i, i2).BackgroundImage = ImageList1.Images(15)
            Next
        Next
        For i = 13 To 15
            For i2 = 2 To 2
                m_buttonArray(i, i2).BackgroundImage = ImageList1.Images(15)
            Next
        Next
        For i = 10 To 15
            For i2 = 10 To 15
                m_buttonArray(i, i2).BackgroundImage = ImageList1.Images(15)
            Next
        Next
        DrawRoomWallVert(10, 15, 10, 9)
        m_buttonArray(8, 0).BackgroundImage = ImageList1.Images(7)


        For i = 0 To lvl2EnemyArray.Count - 1
            If lvl2EnemyArray(i).CheckDead = False Then
                m_Game(0, roomindexX, roomindexY, lvl2EnemyArray(i).GetX, lvl2EnemyArray(i).GetY).setEnemy(True)
                Dim bmp As Bitmap
                bmp = BloodStones.My.Resources.Resource1.Dummy1
                bmp.MakeTransparent(Color.White)
                m_buttonArray(lvl2EnemyArray(i).GetX, lvl2EnemyArray(i).GetY).BackgroundImage = CombineImages(m_buttonArray(lvl2EnemyArray(i).GetX, lvl2EnemyArray(i).GetY).BackgroundImage, bmp)
            End If
        Next
        If HPPACK1(0).ActiveCheck() = True Then
            m_Game(levelindex, roomindexX, roomindexY, HPPACK1(0).ReturnX, HPPACK1(0).ReturnY).SetIndex(PickUp)
            HPPACK1(0).SetHealth(3)
            hp(HPPACK1(0).ReturnX, HPPACK1(0).ReturnY, m_Game(levelindex, roomindexX, roomindexY, HPPACK1(0).ReturnX, HPPACK1(0).ReturnY).ReturnBackGround())

        End If
        If Chestb(0).ActiveCheck() = True Then
            m_Game(levelindex, roomindexX, roomindexY, Chestb(0).ReturnX, Chestb(0).ReturnY).SetIndex(PickUp)
            Chestb(0).SetItem("Rusty Sword")
            Chestb(0).SetWeapon(True)
            Chest(Chestb(0).ReturnX, Chestb(0).ReturnY, m_Game(levelindex, roomindexX, roomindexY, Chestb(0).ReturnX, Chestb(0).ReturnY).ReturnBackGround())

        End If

        m_Game(0, roomindexX, roomindexY, 8, 0).SetIndex(DoorUPIndex)
        m_Game(0, roomindexX, roomindexY, 7, 15).SetIndex(DoorDownIndex)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
        DisplayText("Press Space To Attack")
        buttonArray(8, 0).BackgroundImage = ImageList1.Images(7)
        buttonArray(7, 15).BackgroundImage = ImageList1.Images(7)
    End Sub
    Sub Room3(start As Integer)
        EnemyAI.Enabled = True

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(7)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(7)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        If start = 0 Then
            Player1.SetX(7)
            Player1.SetY(1)
        ElseIf start = 1 Then
            Player1.SetX(8)
            Player1.SetY(14)
        End If
        'CREATES TOP WALL
        For i = 0 To 15
            Dim bound As Integer = 0
            buttonArray(i, bound).BackgroundImage = ImageList1.Images(9)
            m_Game(0, roomindexX, roomindexY, i, bound).SetIndex(WallTileIndex)
            m_Game(0, roomindexX, roomindexY, i, bound).SetBackGround(9)
        Next
        'CREATES LEFT WALL
        For i2 = 0 To 15
            Dim bound As Integer = 0
            buttonArray(bound, i2).BackgroundImage = ImageList1.Images(9)
            m_Game(0, roomindexX, roomindexY, bound, i2).SetIndex(WallTileIndex)
            m_Game(0, roomindexX, roomindexY, bound, i2).SetBackGround(9)
        Next
        'CREATES BOTTOM WALL
        For i = 0 To 15
            Dim bound As Integer = 15
            buttonArray(i, bound).BackgroundImage = ImageList1.Images(9)
            m_Game(0, roomindexX, roomindexY, i, bound).SetIndex(WallTileIndex)
            m_Game(0, roomindexX, roomindexY, i, bound).SetBackGround(9)
        Next
        'CREATES RIGHT WALL
        For i2 = 0 To 15
            Dim bound As Integer = 15
            buttonArray(bound, i2).BackgroundImage = ImageList1.Images(9)
            m_Game(0, roomindexX, roomindexY, bound, i2).SetIndex(WallTileIndex)
            m_Game(0, roomindexX, roomindexY, bound, i2).SetBackGround(9)
        Next

        m_buttonArray = buttonArray

        For i = 0 To lvl1EnemyArray.Count - 1
            If lvl1EnemyArray(i).CheckDead = False Then
                m_Game(0, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).setEnemy(True)
                m_Game(0, roomindexX, roomindexY, lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).setEnemy(True)
                Dim bmp As Bitmap
                bmp = BloodStones.My.Resources.Resource1.Rat_Front_
                bmp.MakeTransparent(Color.White)
                m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage = CombineImages(m_buttonArray(lvl1EnemyArray(i).GetX, lvl1EnemyArray(i).GetY).BackgroundImage, bmp)
            End If
        Next
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
        m_Game(0, roomindexX, roomindexY, 7, 0).SetIndex(DoorUPIndex)
        m_Game(0, roomindexX, roomindexY, 8, 15).SetIndex(DoorDownIndex)
        buttonArray(8, 15).BackgroundImage = ImageList1.Images(7)
        buttonArray(7, 0).BackgroundImage = ImageList1.Images(7)
    End Sub
    Sub Room4(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(levelindex, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray



        'CREATES LEFT WALL
        DrawRoomWallVertImage(0, 15, 0, 25)

        'CREATES BOTTOM WALL
        DrawRoomWallHoriImage(0, 15, 15, 25)

        'CREATES RIGHT WALL
        DrawRoomWallVertImage(0, 15, 15, 25)

        DrawRoomWallHori(0, 15, 0, 6)

        '   For i = 1 To 6
        '  SetTile1(8, i, 24)
        '  Next
        '   SetTile1(7, 7, 22)
        '   SetTile1(8, 7, 22)
        '   For i = 8 To 15
        '   SetTile1(7, i, 24)
        '   Next
        TileLayer(8, 9, ImageList1.Images(25))
        TileLayer(3, 4, ImageList1.Images(25))
        TileLayer(10, 13, ImageList1.Images(25))
        TileLayer(4, 8, ImageList1.Images(25))
        TileLayer(9, 4, ImageList1.Images(25))
        TileLayer(6, 5, ImageList1.Images(25))


        If start = 0 Then
            Player1.SetX(8)
            Player1.SetY(1)
        ElseIf start = 1 Then
            Player1.SetX(7)
            Player1.SetY(14)
        End If
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
        m_Game(0, roomindexX, roomindexY, 8, 0).SetIndex(DoorUPIndex)
        m_Game(0, roomindexX, roomindexY, 7, 15).SetIndex(DoorDownIndex)
        buttonArray(8, 0).BackgroundImage = ImageList1.Images(3)
        buttonArray(7, 15).BackgroundImage = ImageList1.Images(13)
    End Sub
    Sub Room5(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVertImage(0, 15, 0, 25)

        'CREATES BOTTOM WALL
        DrawRoomWallHoriImage(0, 15, 15, 25)

        'CREATES RIGHT WALL
        DrawRoomWallVertImage(0, 15, 15, 25)

        DrawRoomWallHoriImage(0, 15, 0, 25)

        For i = 8 To 15
            SetTile1(7, i, 24)
        Next
        If start = 0 Then
            Player1.SetX(7)
            Player1.SetY(1)
        ElseIf start = 1 Then
            Player1.SetX(7)
            Player1.SetY(14)
        End If
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
        m_Game(0, roomindexX, roomindexY, 7, 0).SetIndex(DoorUPIndex)
        m_Game(0, roomindexX, roomindexY, 7, 15).SetIndex(DoorDownIndex)
        m_buttonArray(7, 0).BackgroundImage = ImageList1.Images(13)
        '  m_buttonArray(7, 15).BackgroundImage = ImageList1.Images(13)


    End Sub
#Region "Town #1"
    Sub Room6(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next


        m_buttonArray = buttonArray

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 13)
        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 13)
        'CREATES LEFT WALL

        'Change 13 to 12 for final version
        DrawRoomWallVert(0, 15, 0, 12)
        'CREATES TOP WALL
        DrawRoomWallHori(0, 15, 0, 12)
        If start = 0 Then
            Player1.SetX(7)
            Player1.SetY(1)
        ElseIf start = 1 Then
            Player1.SetX(7)
            Player1.SetY(14)
        ElseIf start = 3 Then
            Player1.SetX(14)
            Player1.SetY(8)
        ElseIf start = 5 Then
            If CurrentHouse = 1 Then
                Player1.SetX(3)
                Player1.SetY(7)
            ElseIf CurrentHouse = 2 Then
                Player1.SetX(3)
                Player1.SetY(12)
            ElseIf CurrentHouse = 3 Then
                Player1.SetX(11)
                Player1.SetY(12)
            End If
            CurrentHouse = 0
        End If


        For i = 0 To 15
            SetTile1(7, i, 24)
        Next
        SetTile1(7, 8, 22)
        For i = 8 To 15
            SetTile1(i, 8, 23)
        Next
        m_Game(0, roomindexX, roomindexY, 7, 0).SetIndex(DoorUPIndex)
        m_Game(0, roomindexX, roomindexY, 7, 15).SetIndex(DoorDownIndex)
        m_Game(0, roomindexX, roomindexY, 15, 8).SetIndex(DoorRightIndex)
        ' m_buttonArray(7, 0).BackgroundImage = ImageList1.Images(13)
        '  m_buttonArray(7, 15).BackgroundImage = ImageList1.Images(13)
        ' m_buttonArray(15, 8).BackgroundImage = ImageList1.Images(13)




        HouseLayer(2, 5)

        HouseLayer(2, 10)

        HouseLayer(10, 10)

        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
    Sub House1(start As Integer)
        CurrentHouse = 1
        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray
        DrawRoomWallVert(0, 15, 15, 13)

        DrawRoomWallHori(0, 15, 0, 13)

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        If start = 1 Then
            Player1.SetX(7)
            Player1.SetY(14)
        End If
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())

        m_Game(0, roomindexX, roomindexY, 7, 15).SetIndex(DoorHouseIndex)
    End Sub
    Sub House2(start As Integer)
        CurrentHouse = 2
        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray
        DrawRoomWallVert(0, 15, 15, 13)

        DrawRoomWallHori(0, 15, 0, 13)

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        If start = 1 Then
            Player1.SetX(7)
            Player1.SetY(14)
        End If
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())

        m_Game(0, roomindexX, roomindexY, 7, 15).SetIndex(DoorHouseIndex)
    End Sub
    Sub House3(start As Integer)
        CurrentHouse = 3
        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray
        DrawRoomWallVert(0, 15, 15, 13)

        DrawRoomWallHori(0, 15, 0, 13)

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        If start = 1 Then
            Player1.SetX(7)
            Player1.SetY(14)
        End If
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())

        m_Game(0, roomindexX, roomindexY, 7, 15).SetIndex(DoorHouseIndex)
    End Sub
    Sub Room7(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray


        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 13)

        DrawRoomWallHori(0, 15, 0, 13)

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)


        For i = 0 To 7
            SetTile1(7, i, 24)
        Next
        SetTile1(7, 7, 22)
        For i = 8 To 15
            SetTile1(i, 7, 23)
        Next

        If start = 0 Then
            Player1.SetX(7)
            Player1.SetY(1)
        ElseIf start = 3 Then
            Player1.SetX(14)
            Player1.SetY(7)
        End If
        HouseLayer(2, 4)
        HouseLayer(11, 4)
        HouseLayer(2, 10)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
        m_Game(0, roomindexX, roomindexY, 7, 0).SetIndex(DoorUPIndex)
        m_Game(0, roomindexX, roomindexY, 15, 7).SetIndex(DoorRightIndex)
        '   m_buttonArray(7, 0).BackgroundImage = ImageList1.Images(13)
        '  m_buttonArray(15, 7).BackgroundImage = ImageList1.Images(13)
    End Sub
    Sub Room8(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray
        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 13)
        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 13)
        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)



        If start = 2 Then
            Player1.SetX(1)
            Player1.SetY(8)
        ElseIf start = 1 Then
            Player1.SetX(7)
            Player1.SetY(14)
        End If

        For i = 8 To 15
            SetTile1(7, i, 24)
        Next
        SetTile1(7, 8, 22)
        For i = 0 To 6
            SetTile1(i, 8, 23)
        Next
        HouseLayer(2, 10)
        For i = 9 To 15
            For i2 = 0 To 6
                SetTile1(i, i2, 26)
            Next
        Next

        SetTile1(9, 5, 13)
        SetTile1(9, 6, 13)
        SetTile1(9, 6, 13)
        SetTile1(10, 6, 13)
        SetTile1(11, 6, 13)


        m_Game(0, roomindexX, roomindexY, 0, 8).SetIndex(DoorLeftIndex)
        m_Game(0, roomindexX, roomindexY, 7, 15).SetIndex(DoorDownIndex)

        For i = 0 To 8
            TileLayer(i, 0, ImageList1.Images(25))
        Next
        For i = 7 To 15
            TileLayer(15, i, ImageList1.Images(25))
        Next
        ' m_buttonArray(0, 8).BackgroundImage = ImageList1.Images(13)
        '   m_buttonArray(7, 15).BackgroundImage = ImageList1.Images(13)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
    Sub Room9(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 13)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 13)
        If start = 0 Then
            Player1.SetX(7)
            Player1.SetY(1)
        ElseIf start = 2 Then
            Player1.SetX(1)
            Player1.SetY(7)
        ElseIf start = 3 Then
            Player1.SetX(14)
            Player1.SetY(8)
        End If
        For i = 0 To 15
            TileLayer(15, i, ImageList1.Images(25))
        Next
        For i = 0 To 7
            SetTile1(i, 7, 23)
        Next
        For i = 8 To 15
            SetTile1(i, 8, 23)
        Next
        For i = 0 To 7
            SetTile1(7, i, 24)
        Next
        SetTile1(7, 7, 22)
        SetTile1(7, 8, 22)



        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
        m_Game(0, roomindexX, roomindexY, 7, 0).SetIndex(DoorUPIndex)
        m_Game(0, roomindexX, roomindexY, 0, 7).SetIndex(DoorLeftIndex)
        m_Game(0, roomindexX, roomindexY, 15, 8).SetIndex(DoorRightIndex)
        '  m_buttonArray(7, 0).BackgroundImage = ImageList1.Images(13)
        '  m_buttonArray(0, 7).BackgroundImage = ImageList1.Images(13)
        '  m_buttonArray(15, 8).BackgroundImage = ImageList1.Images(13)
    End Sub
#End Region
    Sub Room10(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 2 Then
            Player1.SetX(1)
            Player1.SetY(8)
        ElseIf start = 3 Then
            Player1.SetX(14)
            Player1.SetY(6)
        End If
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
        m_Game(0, roomindexX, roomindexY, 0, 8).SetIndex(DoorLeftIndex)
        m_Game(0, roomindexX, roomindexY, 15, 6).SetIndex(DoorRightIndex)
        m_buttonArray(0, 8).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(15, 6).BackgroundImage = ImageList1.Images(13)
    End Sub
    Sub Room11(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 2 Then
            Player1.SetX(1)
            Player1.SetY(6)
        ElseIf start = 3 Then
            Player1.SetX(14)
            Player1.SetY(8)
        End If

        m_Game(0, roomindexX, roomindexY, 0, 6).SetIndex(DoorLeftIndex)
        m_Game(0, roomindexX, roomindexY, 15, 8).SetIndex(DoorRightIndex)
        m_buttonArray(0, 6).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(15, 8).BackgroundImage = ImageList1.Images(13)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
#Region "Town Two"
    Sub Room12(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 3 Then
            Player1.SetX(14)
            Player1.SetY(7)
        ElseIf start = 2 Then
            Player1.SetX(1)
            Player1.SetY(8)
        ElseIf start = 0 Then
            Player1.SetX(6)
            Player1.SetY(1)
        End If

        m_Game(0, roomindexX, roomindexY, 6, 0).SetIndex(DoorUPIndex)
        m_Game(0, roomindexX, roomindexY, 15, 7).SetIndex(DoorRightIndex)
        m_Game(0, roomindexX, roomindexY, 0, 8).SetIndex(DoorLeftIndex)
        m_buttonArray(6, 0).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(15, 7).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(0, 8).BackgroundImage = ImageList1.Images(13)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
    Sub Room13(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 1 Then
            Player1.SetX(6)
            Player1.SetY(14)
        ElseIf start = 3 Then
            Player1.SetX(14)
            Player1.SetY(8)
        End If

        m_Game(0, roomindexX, roomindexY, 6, 15).SetIndex(DoorDownIndex)
        m_Game(0, roomindexX, roomindexY, 15, 8).SetIndex(DoorRightIndex)
        m_buttonArray(6, 15).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(15, 8).BackgroundImage = ImageList1.Images(13)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
    Sub Room14(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 0 Then
            Player1.SetX(6)
            Player1.SetY(1)
        ElseIf start = 2 Then
            Player1.SetX(1)
            Player1.SetY(8)
        ElseIf start = 1 Then
            Player1.SetX(7)
            Player1.SetY(14)
        End If
        m_Game(0, roomindexX, roomindexY, 6, 0).SetIndex(DoorUPIndex)
        m_Game(0, roomindexX, roomindexY, 7, 15).SetIndex(DoorDownIndex)
        m_Game(0, roomindexX, roomindexY, 0, 8).SetIndex(DoorLeftIndex)
        m_buttonArray(6, 0).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(7, 15).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(0, 8).BackgroundImage = ImageList1.Images(13)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
    Sub Room15(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 3 Then
            Player1.SetX(14)
            Player1.SetY(8)
        ElseIf start = 0 Then
            Player1.SetX(7)
            Player1.SetY(1)
        ElseIf start = 2 Then
            Player1.SetX(1)
            Player1.SetY(7)
        End If
        m_Game(0, roomindexX, roomindexY, 0, 7).SetIndex(DoorLeftIndex)
        m_Game(0, roomindexX, roomindexY, 7, 0).SetIndex(DoorUPIndex)
        m_Game(0, roomindexX, roomindexY, 15, 8).SetIndex(DoorRightIndex)
        m_buttonArray(7, 0).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(0, 7).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(15, 8).BackgroundImage = ImageList1.Images(13)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
#End Region
    Sub Room16(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 1 Then
            Player1.SetX(6)
            Player1.SetY(14)
        ElseIf start = 3 Then
            Player1.SetX(14)
            Player1.SetY(8)
        End If

        m_Game(0, roomindexX, roomindexY, 6, 15).SetIndex(DoorDownIndex)
        m_Game(0, roomindexX, roomindexY, 15, 8).SetIndex(DoorRightIndex)
        m_buttonArray(6, 15).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(15, 8).BackgroundImage = ImageList1.Images(13)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
    Sub Room17(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 2 Then
            Player1.SetX(1)
            Player1.SetY(8)
        End If


        m_Game(0, roomindexX, roomindexY, 0, 8).SetIndex(DoorLeftIndex)
        m_buttonArray(0, 8).BackgroundImage = ImageList1.Images(13)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
    Sub Room18(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 3 Then
            Player1.SetX(14)
            Player1.SetY(7)

        ElseIf start = 2 Then
            Player1.SetX(1)
            Player1.SetY(8)
        End If
        m_Game(0, roomindexX, roomindexY, 0, 8).SetIndex(DoorLeftIndex)

        m_Game(0, roomindexX, roomindexY, 15, 7).SetIndex(DoorRightIndex)

        m_buttonArray(0, 8).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(15, 7).BackgroundImage = ImageList1.Images(13)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
    Sub Room19(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 3 Then
            Player1.SetX(14)
            Player1.SetY(8)
        ElseIf start = 1 Then
            Player1.SetX(7)
            Player1.SetY(14)
        ElseIf start = 2 Then
            Player1.SetX(1)
            Player1.SetY(7)
        End If
        m_Game(0, roomindexX, roomindexY, 0, 7).SetIndex(DoorLeftIndex)
        m_Game(0, roomindexX, roomindexY, 7, 15).SetIndex(DoorDownIndex)
        m_Game(0, roomindexX, roomindexY, 15, 8).SetIndex(DoorRightIndex)
        m_buttonArray(7, 15).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(0, 7).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(15, 8).BackgroundImage = ImageList1.Images(13)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
    Sub Room20(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)

        If start = 0 Then
            Player1.SetX(7)
            Player1.SetY(1)
        End If

        m_Game(0, roomindexX, roomindexY, 7, 0).SetIndex(DoorUPIndex)

        m_buttonArray(7, 0).BackgroundImage = ImageList1.Images(13)

        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
    Sub Room21(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 3 Then
            Player1.SetX(14)
            Player1.SetY(6)
        ElseIf start = 2 Then
            Player1.SetX(1)
            Player1.SetY(8)
        End If
        m_Game(0, roomindexX, roomindexY, 0, 8).SetIndex(DoorLeftIndex)

        m_Game(0, roomindexX, roomindexY, 15, 6).SetIndex(DoorRightIndex)

        m_buttonArray(0, 8).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(15, 6).BackgroundImage = ImageList1.Images(13)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
#Region "Town 3"
    Sub Room22(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 3 Then
            Player1.SetX(14)
            Player1.SetY(8)
        ElseIf start = 2 Then
            Player1.SetX(1)
            Player1.SetY(6)
        ElseIf start = 0 Then
            Player1.SetX(7)
            Player1.SetY(1)
        ElseIf start = 1 Then
            Player1.SetX(8)
            Player1.SetY(14)
        End If
        m_Game(0, roomindexX, roomindexY, 0, 6).SetIndex(DoorLeftIndex)
        m_Game(0, roomindexX, roomindexY, 15, 8).SetIndex(DoorRightIndex)
        m_Game(0, roomindexX, roomindexY, 7, 0).SetIndex(DoorUPIndex)
        m_Game(0, roomindexX, roomindexY, 8, 15).SetIndex(DoorDownIndex)
        m_buttonArray(0, 6).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(15, 8).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(7, 0).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(8, 15).BackgroundImage = ImageList1.Images(13)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
    Sub Room23(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 3 Then
            Player1.SetX(14)
            Player1.SetY(9)
        ElseIf start = 1 Then
            Player1.SetX(7)
            Player1.SetY(14)
        End If
        m_Game(0, roomindexX, roomindexY, 7, 15).SetIndex(DoorDownIndex)

        m_Game(0, roomindexX, roomindexY, 15, 9).SetIndex(DoorRightIndex)

        m_buttonArray(7, 15).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(15, 9).BackgroundImage = ImageList1.Images(13)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
    Sub Room24(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 3 Then
            Player1.SetX(14)
            Player1.SetY(7)
        ElseIf start = 2 Then
            Player1.SetX(1)
            Player1.SetY(9)
        ElseIf start = 1 Then
            Player1.SetX(8)
            Player1.SetY(14)
        End If
        m_Game(0, roomindexX, roomindexY, 0, 9).SetIndex(DoorLeftIndex)

        m_Game(0, roomindexX, roomindexY, 15, 7).SetIndex(DoorRightIndex)
        m_Game(0, roomindexX, roomindexY, 8, 15).SetIndex(DoorDownIndex)
        m_buttonArray(0, 9).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(8, 15).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(15, 7).BackgroundImage = ImageList1.Images(13)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
    Sub Room25(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 2 Then
            Player1.SetX(1)
            Player1.SetY(7)
        ElseIf start = 1 Then
            Player1.SetX(9)
            Player1.SetY(14)
        End If
        m_Game(0, roomindexX, roomindexY, 0, 7).SetIndex(DoorLeftIndex)

        m_Game(0, roomindexX, roomindexY, 9, 15).SetIndex(DoorDownIndex)

        m_buttonArray(0, 7).BackgroundImage = ImageList1.Images(13)
        m_buttonArray(9, 15).BackgroundImage = ImageList1.Images(13)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
    Sub Room26(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 0 Then
            Player1.SetX(8)
            Player1.SetY(1)
        ElseIf start = 1 Then
            Player1.SetX(6)
            Player1.SetY(14)
        ElseIf start = 2 Then
            Player1.SetX(1)
            Player1.SetY(8)
        ElseIf start = 3 Then
            Player1.SetX(14)
            Player1.SetY(7)
        End If
        m_Game(0, roomindexX, roomindexY, 0, 8).SetIndex(DoorLeftIndex)
        m_buttonArray(0, 8).BackgroundImage = ImageList1.Images(13)

        m_Game(0, roomindexX, roomindexY, 15, 7).SetIndex(DoorRightIndex)
        m_buttonArray(15, 7).BackgroundImage = ImageList1.Images(13)

        m_Game(0, roomindexX, roomindexY, 6, 15).SetIndex(DoorDownIndex)
        m_buttonArray(6, 15).BackgroundImage = ImageList1.Images(13)

        m_Game(0, roomindexX, roomindexY, 8, 0).SetIndex(DoorUPIndex)
        m_buttonArray(8, 0).BackgroundImage = ImageList1.Images(13)

        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
    Sub Room27(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 2 Then
            Player1.SetX(1)
            Player1.SetY(7)
        ElseIf start = 0 Then
            Player1.SetX(9)
            Player1.SetY(1)
        ElseIf start = 1 Then
            Player1.SetX(7)
            Player1.SetY(14)
        End If
        m_Game(0, roomindexX, roomindexY, 0, 7).SetIndex(DoorLeftIndex)
        m_buttonArray(0, 7).BackgroundImage = ImageList1.Images(13)
        m_Game(0, roomindexX, roomindexY, 9, 0).SetIndex(DoorUPIndex)
        m_buttonArray(9, 0).BackgroundImage = ImageList1.Images(13)
        m_Game(0, roomindexX, roomindexY, 7, 15).SetIndex(DoorDownIndex)
        m_buttonArray(7, 15).BackgroundImage = ImageList1.Images(13)

        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
    Sub Room28(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 0 Then
            Player1.SetX(8)
            Player1.SetY(1)
        ElseIf start = 3 Then
            Player1.SetX(14)
            Player1.SetY(7)
        End If
        m_Game(0, roomindexX, roomindexY, 8, 0).SetIndex(DoorUPIndex)
        m_buttonArray(8, 0).BackgroundImage = ImageList1.Images(13)
        m_Game(0, roomindexX, roomindexY, 15, 7).SetIndex(DoorRightIndex)
        m_buttonArray(15, 7).BackgroundImage = ImageList1.Images(13)


        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
    Sub Room29(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 0 Then
            Player1.SetX(6)
            Player1.SetY(1)
        ElseIf start = 3 Then
            Player1.SetX(14)
            Player1.SetY(8)
        ElseIf start = 2 Then
            Player1.SetX(1)
            Player1.SetY(7)
        End If
        m_Game(0, roomindexX, roomindexY, 0, 7).SetIndex(DoorLeftIndex)
        m_buttonArray(0, 7).BackgroundImage = ImageList1.Images(13)
        m_Game(0, roomindexX, roomindexY, 15, 8).SetIndex(DoorRightIndex)
        m_buttonArray(15, 8).BackgroundImage = ImageList1.Images(13)
        m_Game(0, roomindexX, roomindexY, 6, 0).SetIndex(DoorUPIndex)
        m_buttonArray(6, 0).BackgroundImage = ImageList1.Images(13)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub
    Sub Room30(start As Integer)

        For i = 1 To 16
            For i2 = 1 To 16

                m_Game(0, roomindexX, roomindexY, i - 1, i2 - 1) = New Tile(False, False, 1)

            Next
        Next

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
                buttonArray(i, i2).BackgroundImage = ImageList1.Images(13)
                m_Game(0, roomindexX, roomindexY, i, i2).SetBackGround(13)
                buttonArray(i, i2).FlatStyle = FlatStyle.Flat
                buttonArray(i, i2).BackgroundImageLayout = ImageLayout.Stretch
                buttonArray(i, i2).FlatAppearance.BorderSize = 0
                buttonArray(i, i2).Enabled = False
                Me.Controls.Add(buttonArray(i, i2))
            Next
        Next

        m_buttonArray = buttonArray

        'CREATES LEFT WALL
        DrawRoomWallVert(0, 15, 0, 12)

        'CREATES BOTTOM WALL
        DrawRoomWallHori(0, 15, 15, 12)

        'CREATES RIGHT WALL
        DrawRoomWallVert(0, 15, 15, 12)

        DrawRoomWallHori(0, 15, 0, 12)
        If start = 2 Then
            Player1.SetX(1)
            Player1.SetY(8)
        ElseIf start = 0 Then
            Player1.SetX(7)
            Player1.SetY(1)
        End If
        m_Game(0, roomindexX, roomindexY, 0, 8).SetIndex(DoorLeftIndex)
        m_buttonArray(0, 8).BackgroundImage = ImageList1.Images(13)
        m_Game(0, roomindexX, roomindexY, 7, 0).SetIndex(DoorUPIndex)
        m_buttonArray(7, 0).BackgroundImage = ImageList1.Images(13)
        PlayerDown(m_Game(levelindex, roomindexX, roomindexY, Player1.GetX, Player1.GetY).ReturnBackGround())
    End Sub


#End Region

#Region "Start"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Visible = False
        Button3.Visible = False
        Button4.Visible = False
        Label1.Text = "What Is Your Name?"
        Label1.Visible = True
        Button5.Visible = True
        TextBox2.Visible = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        playername = TextBox2.Text
        Button5.Visible = False
        TextBox2.Visible = False
        Label1.Text = "What Do You Look Like?"
        Button6.Visible = True
        Hair_Up.Visible = True
        Hair_Down.Visible = True
        Label4.Visible = True
        Label5.Visible = True
        Label6.Visible = True
        Label7.Visible = True
        Label8.Visible = True
        Label9.Visible = True
        Label10.Visible = True
        Label11.Visible = True
        Label12.Visible = True
        Label13.Visible = True
        Label14.Visible = True
        Label15.Visible = True
        Label16.Visible = True
        PictureBox2.Visible = True

        baseimageD = BloodStones.My.Resources.Resource1.M_Adult_Front_
        baseimageD.MakeTransparent()
        baseimageU = BloodStones.My.Resources.Resource1.M_Adult_Back_
        baseimageU.MakeTransparent()
        baseimageL = BloodStones.My.Resources.Resource1.M_Adult_left_
        baseimageL.MakeTransparent()
        baseimageR = BloodStones.My.Resources.Resource1.M_Adult_right_
        baseimageR.MakeTransparent()

        pantsD = BloodStones.My.Resources.Resource1.Pants_Front_
        pantsU = BloodStones.My.Resources.Resource1.Pants_Front_
        pantsL = BloodStones.My.Resources.Resource1.Pants_Left_
        pantsR = BloodStones.My.Resources.Resource1.Pants_Right_

        pantsL.MakeTransparent()
        pantsU.MakeTransparent()
        pantsR.MakeTransparent()
        pantsD.MakeTransparent()

        ShirtD = BloodStones.My.Resources.Player_Hair.M_Leather_shirt_Front___Back_
        ShirtU = BloodStones.My.Resources.Player_Hair.M_Leather_shirt_Front___Back_
        ShirtL = BloodStones.My.Resources.Player_Hair.M_LeatherArmor_Left_
        ShirtR = BloodStones.My.Resources.Player_Hair.M_LeatherArmor_right_

        ShirtD.MakeTransparent()
        ShirtU.MakeTransparent()
        ShirtL.MakeTransparent()
        ShirtR.MakeTransparent()
        '  PictureBox2.Image = tempPlayerLayers(ImageList1.Images(1), baseimageD, pantsD, ShirtD, HairD)


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Button6.Visible = False
        Label1.Visible = False
        Hair_Up.Visible = False
        Hair_Down.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        Label9.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        Label13.Visible = False
        Label14.Visible = False
        Label15.Visible = False
        Label16.Visible = False
        PictureBox2.Visible = False
        Room1(0)
        Timer1.Enabled = True
        Me.Focus()
    End Sub

    Private Sub Hair_Up_Click(sender As Object, e As EventArgs) Handles Hair_Up.Click

        If hairindex <> 16 Then
            hairindex += 1
        Else
            hairindex = 0
        End If
        HairChange()
    End Sub

    Private Sub Hair_Down_Click(sender As Object, e As EventArgs) Handles Hair_Down.Click
        '  PictureBox2.Image = tempPlayerLayers(ImageList1.Images(1), baseimageD, pantsD, ShirtD, HairD)
        If hairindex <> 0 Then
            hairindex -= 1
        Else
            hairindex = 16
        End If
        HairChange()
    End Sub
    Sub HairChange()
        HairD = BloodStones.My.Resources.Player_Hair.BLH_Front_
        HairR = BloodStones.My.Resources.Player_Hair.BH_right_
        HairL = BloodStones.My.Resources.Player_Hair.BH_left_
        HairU = BloodStones.My.Resources.Player_Hair.BLH_Back_


        Dim Haircolor As Color

        Dim x As Integer
        Dim y As Integer
        Dim red As Byte
        Dim green As Byte
        Dim blue As Byte
        If hairindex = 0 Then
            Haircolor = Color.Black
        ElseIf hairindex = 1 Then
            Haircolor = Color.SandyBrown
        ElseIf hairindex = 2 Then
            Haircolor = Color.Brown
        ElseIf hairindex = 3 Then
            Haircolor = Color.RosyBrown
        ElseIf hairindex = 4 Then
            Haircolor = Color.Yellow
        ElseIf hairindex = 5 Then
            Haircolor = Color.Gray
        ElseIf hairindex = 6 Then
            Haircolor = Color.Gainsboro
        ElseIf hairindex = 7 Then
            Haircolor = Color.HotPink
        ElseIf hairindex = 8 Then
            Haircolor = Color.DarkBlue
        ElseIf hairindex = 9 Then
            Haircolor = Color.Teal
        ElseIf hairindex = 10 Then
            Haircolor = Color.Red
        ElseIf hairindex = 11 Then
            Haircolor = Color.GreenYellow
        ElseIf hairindex = 12 Then
            Haircolor = Color.LawnGreen
        ElseIf hairindex = 13 Then
            Haircolor = Color.Purple
        ElseIf hairindex = 14 Then
            Haircolor = Color.Chocolate
        ElseIf hairindex = 15 Then
            Haircolor = Color.Coral
        ElseIf hairindex = 16 Then
            Haircolor = Color.Cornsilk
        End If

        For x = 0 To HairD.Width - 1
            For y = 0 To HairD.Height - 1
                red = HairD.GetPixel(x, y).R
                green = HairD.GetPixel(x, y).G
                blue = HairD.GetPixel(x, y).B
                If red < 5 Then
                    HairD.SetPixel(x, y, Haircolor)
                End If
            Next
        Next
        For x = 0 To HairL.Width - 1
            For y = 0 To HairL.Height - 1
                red = HairL.GetPixel(x, y).R
                green = HairL.GetPixel(x, y).G
                blue = HairL.GetPixel(x, y).B
                If red < 5 Then
                    HairL.SetPixel(x, y, Haircolor)
                End If
            Next
        Next
        For x = 0 To HairR.Width - 1
            For y = 0 To HairR.Height - 1
                red = HairR.GetPixel(x, y).R
                green = HairR.GetPixel(x, y).G
                blue = HairR.GetPixel(x, y).B
                If red < 5 Then
                    HairR.SetPixel(x, y, Haircolor)
                End If
            Next
        Next
        For x = 0 To HairU.Width - 1
            For y = 0 To HairU.Height - 1
                red = HairU.GetPixel(x, y).R
                green = HairU.GetPixel(x, y).G
                blue = HairU.GetPixel(x, y).B
                If red < 5 Then
                    HairU.SetPixel(x, y, Haircolor)
                End If
            Next
        Next
        '    PictureBox2.Image.Dispose()
        PictureBox2.Image = tempPlayerLayers(ImageList1.Images(1), baseimageD, pantsD, ShirtD, HairD)
    End Sub
    Dim ShirtIndex As Integer
    Sub ChangeShirt()
        ShirtD = BloodStones.My.Resources.Player_Hair.M_Leather_shirt_Front___Back_
        ShirtU = BloodStones.My.Resources.Player_Hair.M_Leather_shirt_Front___Back_
        ShirtL = BloodStones.My.Resources.Player_Hair.M_LeatherArmor_Left_
        ShirtR = BloodStones.My.Resources.Player_Hair.M_LeatherArmor_right_

        Dim Shirtcolor As Color

        If ShirtIndex = 0 Then
            Shirtcolor = Color.Black
        ElseIf ShirtIndex = 1 Then
            Shirtcolor = Color.Blue
        ElseIf ShirtIndex = 2 Then
            Shirtcolor = Color.Red
        ElseIf ShirtIndex = 3 Then
            Shirtcolor = Color.Pink
        ElseIf ShirtIndex = 4 Then
            Shirtcolor = Color.Green
        ElseIf ShirtIndex = 5 Then
            Shirtcolor = Color.Yellow
        End If






        Dim x As Integer
        Dim y As Integer
        Dim red As Byte
        Dim green As Byte
        Dim blue As Byte
        For x = 0 To ShirtD.Width - 1
            For y = 0 To ShirtD.Height - 1
                red = ShirtD.GetPixel(x, y).R
                green = ShirtD.GetPixel(x, y).G
                blue = ShirtD.GetPixel(x, y).B
                If red < 5 Then
                    ShirtD.SetPixel(x, y, Shirtcolor)
                End If
            Next
        Next
        For x = 0 To ShirtU.Width - 1
            For y = 0 To ShirtU.Height - 1
                red = ShirtU.GetPixel(x, y).R
                green = ShirtU.GetPixel(x, y).G
                blue = ShirtU.GetPixel(x, y).B
                If red < 5 Then
                    ShirtU.SetPixel(x, y, Shirtcolor)
                End If
            Next
        Next
        For x = 0 To ShirtL.Width - 1
            For y = 0 To ShirtL.Height - 1
                red = ShirtL.GetPixel(x, y).R
                green = ShirtL.GetPixel(x, y).G
                blue = ShirtL.GetPixel(x, y).B
                If red < 5 Then
                    ShirtL.SetPixel(x, y, Shirtcolor)
                End If
            Next
        Next
        For x = 0 To ShirtR.Width - 1
            For y = 0 To ShirtR.Height - 1
                red = ShirtR.GetPixel(x, y).R
                green = ShirtR.GetPixel(x, y).G
                blue = ShirtR.GetPixel(x, y).B
                If red < 5 Then
                    ShirtR.SetPixel(x, y, Shirtcolor)
                End If
            Next
        Next





        ShirtD.MakeTransparent()
        ShirtU.MakeTransparent()
        ShirtL.MakeTransparent()
        ShirtR.MakeTransparent()

        PictureBox2.Image = tempPlayerLayers(ImageList1.Images(1), baseimageD, pantsD, ShirtD, HairD)

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        If ShirtIndex <> 5 Then
            ShirtIndex += 1
        Else
            ShirtIndex = 0
        End If
        ChangeShirt()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        If ShirtIndex <> 0 Then
            ShirtIndex -= 1
        Else
            ShirtIndex = 5
        End If
        ChangeShirt()
    End Sub
    Dim pantsindex As Integer
    Sub ChangePants()
        pantsD = BloodStones.My.Resources.Resource1.Pants_Front_
        pantsU = BloodStones.My.Resources.Resource1.Pants_Front_
        pantsL = BloodStones.My.Resources.Resource1.Pants_Left_
        pantsR = BloodStones.My.Resources.Resource1.Pants_Right_

        Dim pantscolor As Color

        If pantsindex = 0 Then
            pantscolor = Color.Blue
        ElseIf pantsindex = 1 Then
            pantscolor = Color.Black
        ElseIf pantsindex = 2 Then
            pantscolor = Color.Brown
        ElseIf pantsindex = 3 Then
            pantscolor = Color.DarkBlue
        ElseIf pantsindex = 4 Then
            pantscolor = Color.Purple
        ElseIf pantsindex = 5 Then
            pantscolor = Color.Beige
        ElseIf pantsindex = 6 Then
            pantscolor = Color.Red
        End If

        Dim x As Integer
        Dim y As Integer
        Dim red As Byte
        Dim green As Byte
        Dim blue As Byte
        For x = 0 To pantsD.Width - 1
            For y = 0 To pantsD.Height - 1
                red = pantsD.GetPixel(x, y).R
                green = pantsD.GetPixel(x, y).G
                blue = pantsD.GetPixel(x, y).B
                If red < 5 Then
                    pantsD.SetPixel(x, y, pantscolor)
                End If
            Next
        Next
        For x = 0 To pantsU.Width - 1
            For y = 0 To pantsU.Height - 1
                red = pantsU.GetPixel(x, y).R
                green = pantsU.GetPixel(x, y).G
                blue = pantsU.GetPixel(x, y).B
                If red < 5 Then
                    pantsU.SetPixel(x, y, pantscolor)
                End If
            Next
        Next
        For x = 0 To pantsL.Width - 1
            For y = 0 To pantsL.Height - 1
                red = pantsL.GetPixel(x, y).R
                green = pantsL.GetPixel(x, y).G
                blue = pantsL.GetPixel(x, y).B
                If red < 5 Then
                    pantsL.SetPixel(x, y, pantscolor)
                End If
            Next
        Next
        For x = 0 To pantsR.Width - 1
            For y = 0 To pantsR.Height - 1
                red = pantsR.GetPixel(x, y).R
                green = pantsR.GetPixel(x, y).G
                blue = pantsR.GetPixel(x, y).B
                If red < 5 Then
                    pantsR.SetPixel(x, y, pantscolor)
                End If
            Next
        Next


        pantsL.MakeTransparent()
        pantsU.MakeTransparent()
        pantsR.MakeTransparent()
        pantsD.MakeTransparent()

        PictureBox2.Image = tempPlayerLayers(ImageList1.Images(1), baseimageD, pantsD, ShirtD, HairD)

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

        If pantsindex <> 6 Then
            pantsindex += 1
        Else
            pantsindex = 0
        End If
        ChangePants()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        If pantsindex <> 0 Then
            pantsindex -= 1
        Else
            pantsindex = 6
        End If
        ChangePants()
    End Sub

#End Region

End Class

