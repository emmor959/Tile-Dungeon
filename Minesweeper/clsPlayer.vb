﻿Public Class clsPlayer

    Dim playerX As Integer
    Dim playerY As Integer
    Dim ImageIndex As Integer

    Sub New(x As Integer, y As Integer)
        playerX = x
        playerY = y
    End Sub
    Function GetX()
        Return playerX
    End Function
    Function GetY()
        Return playerY
    End Function
    Sub SetX(x As Integer)
        playerX = x
    End Sub
    Sub SetY(y As Integer)
        playerY = y
    End Sub
    Sub ImageNum(x As Integer)
        ImageIndex = x
    End Sub
    Function GetImageNum()
        Return ImageIndex
    End Function
End Class
