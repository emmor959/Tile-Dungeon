Public Class clsPickup

    Dim m_ReturnHealth As Integer
    Dim m_ReturnGold As Integer
    Dim m_returnItem As String
    Dim m_Active As Boolean = True
    Sub New()
    End Sub
    Public Sub SetHealth(a As Integer)
        m_ReturnHealth = a
    End Sub
    Public Sub SetGold(a As Integer)
        m_ReturnGold = a
    End Sub
    Public Sub SetItem(b As String)
        m_returnItem = b
    End Sub
    Public Function HP()
        Return m_ReturnHealth
        m_Active = False
    End Function
    Public Function Gold()
        Return m_ReturnGold
        m_Active = False
    End Function
    Public Function Item()
        Return m_returnItem
        m_Active = False
    End Function
    Public Function ActiveCheck()
        Return m_Active
    End Function
End Class
