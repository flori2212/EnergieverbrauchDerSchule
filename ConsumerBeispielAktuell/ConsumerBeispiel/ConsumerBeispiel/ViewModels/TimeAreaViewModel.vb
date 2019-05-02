Namespace ViewModel

    Public Class TimeAreaViewModel
        Inherits ViewModelBase

        Private ReadOnly _timeAreaModel As Model.TimeArea



        Public Sub New(timeAreaModel As Model.TimeArea)
            _timeAreaModel = timeAreaModel

            Name = timeAreaModel.Name
            ActiveDaysPerWeek = timeAreaModel.ActiveDaysPerWeek
            ActiveInHolydays = timeAreaModel.ActiveInHolydays
            PercentOfTheYeahr = timeAreaModel.PercentOfTheYeahr
            TimePerDayInMinutes = timeAreaModel.TimePerDayInMinutes
        End Sub



        Public ReadOnly Property ID As Integer
            Get
                Return _timeAreaModel.ID
            End Get
        End Property




        Private _Name As String
        Public Property Name As String
            Get
                Return _name
            End Get
            Set(value As String)
                _Name = value
                RaisePropertyChanged()
            End Set
        End Property


        Private _activeDaysPerWeek As Integer
        Public Property ActiveDaysPerWeek As Integer
            Get
                Return _activeDaysPerWeek
            End Get
            Set(value As Integer)
                _activeDaysPerWeek = value
                RaisePropertyChanged()
            End Set
        End Property


        Private _percentOfTheYeahr As Integer
        Public Property PercentOfTheYeahr As Integer
            Get
                Return _percentOfTheYeahr
            End Get
            Set(value As Integer)
                _percentOfTheYeahr = value
                RaisePropertyChanged()
            End Set
        End Property


        Private _activeInHolydays As Boolean
        Public Property ActiveInHolydays As Boolean
            Get
                Return _activeInHolydays
            End Get
            Set(value As Boolean)
                _activeInHolydays = value
                RaisePropertyChanged()
            End Set
        End Property

        Private _timePerDayInMinutes As Integer
        Public Property TimePerDayInMinutes As Integer
            Get
                Return _timePerDayInMinutes
            End Get
            Set(value As Integer)
                _timePerDayInMinutes = value
                RaisePropertyChanged()
            End Set
        End Property

    End Class

End Namespace
