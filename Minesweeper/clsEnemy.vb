Public Class clsEnemy
    Dim EnemyX As Integer
    Dim EnemyY As Integer
    Dim Index As Integer
    Dim hp As Integer
    Dim Direction As Integer
    Dim Isattacking As Boolean
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
    Sub IndexNum(x As Integer)
        Index = x
    End Sub
    Function GetIndexNum()
        Return Index
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
    Sub SetDirection(x As Integer)
        Direction = x
    End Sub
    Function GetDirection()
        Return Direction
    End Function
    Sub SetAttack(x As Boolean)
        Isattacking = x
    End Sub
    Function GetAttack()
        Return Isattacking
    End Function
End Class
