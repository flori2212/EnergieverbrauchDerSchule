Namespace Model

    Public Class TimeArea
        Public Property ID As Integer
        Public Property Name As String

        Private _activeDaysPerWeek
        Public Property ActiveDaysPerWeek As Integer
            Get
                Return _activeDaysPerWeek
            End Get
            Set(value As Integer)

                _activeDaysPerWeek = value

            End Set
        End Property

        Public Property PercentOfTheYeahr As Integer
        Public Property TimePerDayInMinutes As Integer
        Public Property ActiveInHolydays As Boolean

    End Class

End Namespace

