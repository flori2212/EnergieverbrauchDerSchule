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

        Public Function GetTimePerYeahrInMinutes() As Double
            Dim time As Double

            time = TimePerDayInMinutes
            time *= ActiveDaysPerWeek

            If ActiveInHolydays = True Then
                time *= 52
            Else
                time *= 36
            End If

            time *= (PercentOfTheYeahr / 100)

            Return time
        End Function

    End Class

End Namespace

