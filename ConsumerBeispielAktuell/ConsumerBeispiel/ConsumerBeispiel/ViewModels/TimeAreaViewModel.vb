Namespace ViewModel

    Public Class TimeAreaViewModel
        Inherits ViewModelBase

        Public ReadOnly Property TimeArea_Model As Model.TimeArea



        Public Sub New(timeAreaModel As Model.TimeArea)
            TimeArea_Model = timeAreaModel

            Name = timeAreaModel.Name
            ActiveDaysPerWeek = timeAreaModel.ActiveDaysPerWeek
            ActiveInHolydays = timeAreaModel.ActiveInHolydays
            PercentOfTheYeahr = timeAreaModel.PercentOfTheYeahr
            TimePerDayInMinutes = timeAreaModel.TimePerDayInMinutes
        End Sub



        Public ReadOnly Property ID As Integer
            Get
                Return TimeArea_Model.ID
            End Get
        End Property

        Public Property UseCount As Integer
            Get
                Return Service.DataService.Instance.GetTimeAreaUseCount(TimeArea_Model)
            End Get
            Set(value As Integer)

            End Set
        End Property


        Private _Name As String
        Public Property Name As String
            Get
                Return _name
            End Get
            Set(value As String)
                _Name = value
                TimeArea_Model.Name = value
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
                TimeArea_Model.ActiveDaysPerWeek = value
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
                TimeArea_Model.PercentOfTheYeahr = value
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
                TimeArea_Model.ActiveInHolydays = value
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
                TimeArea_Model.TimePerDayInMinutes = value
                RaisePropertyChanged()
            End Set
        End Property

    End Class

End Namespace
