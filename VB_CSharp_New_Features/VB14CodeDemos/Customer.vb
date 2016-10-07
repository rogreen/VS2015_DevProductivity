Public Class Customer

    Public Property Name() As String
    Public Property Contact() As String
    Public Property Address() As Address

#Region "ReadOnly auto-implemented properties"
    Public ReadOnly Property Version1 As String
    Public ReadOnly Property Version2 As String = "1.0.0.0"

#End Region

    Sub New()
        Me.Version1 = "1.0.0.0"
    End Sub

End Class

Public Class Address
    Public Property City As String
    Public Property State As String
    Public Property ZipCode As String

End Class
