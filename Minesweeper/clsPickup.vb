Public Class clsPickup

    Dim m_ReturnHealth As Integer
    Dim m_ReturnGold As Integer
    Dim m_returnItem As String
    Sub New()
    End Sub
    Public Sub SetHealth(a As Integer)
        m_ReturnHealth = a
    End Sub
    Public Sub GetGold(a As Integer)
        m_ReturnGold = a
    End Sub
    Public Sub GetItem(b As String)
        m_returnItem = b
    End Sub
    Public Function HP()
        Return m_ReturnHealth
    End Function
    Public Function Gold()
        Return m_ReturnGold
    End Function
    Public Function Item()
        Return m_returnItem
    End Function
End Class
