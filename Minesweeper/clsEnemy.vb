﻿Public Class clsEnemy
    Dim EnemyX As Integer
    Dim EnemyY As Integer
    Dim ImageIndex As Integer
    Dim hp As Integer
    Sub New(x As Integer, y As Integer)
        EnemyX = x
        EnemyY = y
    End Sub
    Function GetX()
        Return EnemyX
    End Function
    Function GetY()
        Return EnemyY
    End Function
    Sub SetX(x As Integer)
        EnemyX = x
    End Sub
    Sub SetY(y As Integer)
        EnemyY = y
    End Sub
    Sub ImageNum(x As Integer)
        ImageIndex = x
    End Sub
    Function GetImageNum()
        Return ImageIndex
    End Function
    Function GetHealth()
        Return hp
    End Function
    Sub SetHealth(x As Integer)
        hp = x
    End Sub
    Function CheckDead()
        If hp <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class