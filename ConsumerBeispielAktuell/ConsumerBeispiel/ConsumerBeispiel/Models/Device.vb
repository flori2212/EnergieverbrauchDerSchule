Namespace Model
    Public Class Device

        Public Property ID As Integer

        Public Property Name As String
        Public Property Description As String

        Private _Power As Integer
        Public Property Power As Double
            Get
                Return _Power
            End Get
            Set(value As Double)
                If value >= 0 Then
                    _Power = value
                Else
                    Throw New ArgumentException("Der Wert muss größer oder gleich 0 sein")
                End If

            End Set
        End Property

        Public Property DeviceGroupID As Integer



    End Class


    Public Class DeviceGroup
        Public Property ID As Integer

        Public Property Name As String

    End Class
End Namespace
