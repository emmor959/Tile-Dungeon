Public Class clsPickup

    Dim m_ReturnHealth As Integer
    Dim m_ReturnGold As Integer
    Dim m_returnItem As String
    Dim m_Active As Boolean
    Dim m_Weapon As Boolean
    Dim m_x As Integer
    Dim m_y As Integer
    Sub New(x As Integer, y As Integer)
        m_x = x
        m_y = y
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
    Public Sub SetActive(b As Boolean)
        m_Active = b
    End Sub
    Public Function ActiveCheck()
        Return m_Active
    End Function
    Public Function ReturnX()
        Return m_x
    End Function
    Public Function ReturnY()
        Return m_y
    End Function
    Public Sub SetWeapon(b As Boolean)
        m_Weapon = b
    End Sub
    Public Function WeaponCheck()
        Return m_Weapon
    End Function
End Class
