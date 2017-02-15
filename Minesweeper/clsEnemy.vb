Public Class clsEnemy
    Dim EnemyX As Integer
    Dim EnemyY As Integer
    Dim ImageIndex As Integer

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
End Class
