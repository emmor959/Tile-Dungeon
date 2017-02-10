Public Class Tile

    Dim m_PlayerPresent As Boolean
    Dim m_EnemyPresent As Boolean
    Dim m_TileIndex As Integer
    Dim m_RoomIndex As Integer
    Sub New(player As Boolean, enemy As Boolean, Tile As Integer)
        m_PlayerPresent = player
        m_EnemyPresent = enemy
        m_TileIndex = Tile
    End Sub
    Public Function GetIndex()
        Return m_TileIndex
    End Function
    Public Sub SetIndex(a As Integer)
        m_TileIndex = a
    End Sub
    Public Function CheckForPlayer()
        If m_PlayerPresent = True Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function CheckForEnemy()
        If m_EnemyPresent = True Then
            Return True
        Else
            Return False
        End If
    End Function
    Sub setPlayer(a As Boolean)
        m_PlayerPresent = a
    End Sub
    Sub setEnemy(a As Boolean)
        m_EnemyPresent = a
    End Sub
    Sub SEtRoom(a As Integer)
        m_RoomIndex = a
    End Sub
    Public Function GetRoom()
        Return m_RoomIndex
    End Function
End Class
