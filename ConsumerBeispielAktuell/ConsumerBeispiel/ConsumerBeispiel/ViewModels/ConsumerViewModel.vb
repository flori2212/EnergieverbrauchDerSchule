Namespace ViewModel
    Public Class ConsumerViewModel
        Inherits ViewModelBase

        Public ReadOnly Property Consumer_Model As Model.Consumer


        Friend Sub New(consumerModel As Model.Consumer, aviableData As (Devices As List(Of DeviceViewModel), Rooms As List(Of RoomViewModel), DataCollectors As List(Of DataCollectorViewModel), TimeAreas As List(Of TimeAreaViewModel)))
            Consumer_Model = consumerModel
            _aviableRooms = aviableData.Rooms
            _aviableDevices = aviableData.Devices
            _aviableTimeAreas = aviableData.TimeAreas
            _AviableDataCollectors = aviableData.DataCollectors


            With Consumer_Model
                'Wenn neuer Datensatz (anscheinend weil ja ID eine Empty GUID ist
                If .ID = Guid.Empty Then
                    .ID = Guid.NewGuid()
                    .RoomID = _aviableRooms.FirstOrDefault?.ID
                End If

                Device = AviableDevices.Where(Function(x) x.ID = .DeviceID).SingleOrDefault()
                Room = AviableRooms.Where(Function(x) x.ID = .RoomID).SingleOrDefault()
                DataCollector = AviableDataCollectors.Where(Function(x) x.ID = .DataCollectorID).SingleOrDefault()
                TimeArea = AviableTimeAreas.Where(Function(x) x.ID = .TimeAreaID).SingleOrDefault()

                _deviceCount = .DeviceCount
            End With
        End Sub


        Public ReadOnly Property ID As Guid
            Get
                Return Consumer_Model.ID
            End Get
        End Property

        Private _deviceCount As Integer
        Public Property DeviceCount As Integer
            Get
                Return _deviceCount
            End Get
            Set(value As Integer)
                _deviceCount = value
                Consumer_Model.DeviceCount = value
                RaisePropertyChanged()
            End Set
        End Property

        Public Property KwhPerYeahr As Double
            Get
                Return (Device.Power * DeviceCount * TimeArea.TimePerYeahrHours()) / 1000
            End Get
            Set(value As Double)

            End Set
        End Property



        Private _aviableRooms As List(Of ViewModel.RoomViewModel)
        Public ReadOnly Property AviableRooms As List(Of ViewModel.RoomViewModel)
            Get
                Return _aviableRooms
            End Get
        End Property

        Private _aviableDevices As List(Of ViewModel.DeviceViewModel)
        Public ReadOnly Property AviableDevices As List(Of ViewModel.DeviceViewModel)
            Get
                Return _aviableDevices
            End Get
        End Property

        Private _AviableDataCollectors As List(Of ViewModel.DataCollectorViewModel)
        Public ReadOnly Property AviableDataCollectors As List(Of ViewModel.DataCollectorViewModel)
            Get
                Return _AviableDataCollectors
            End Get
        End Property

        Private _aviableTimeAreas As List(Of ViewModel.TimeAreaViewModel)
        Public ReadOnly Property AviableTimeAreas As List(Of ViewModel.TimeAreaViewModel)
            Get
                Return _aviableTimeAreas
            End Get
        End Property




        Private _room As ViewModel.RoomViewModel
        Public Property Room As ViewModel.RoomViewModel
            Get
                Return _room
            End Get
            Set(ByVal Value As ViewModel.RoomViewModel)
                _room = Value
                Consumer_Model.RoomID = Value?.ID    'In das 'originale' Modelobjekt die ID zurückgreiben da sich der Raum ja geändert hat
                RaisePropertyChanged()
            End Set
        End Property

        Private _DataCollector As ViewModel.DataCollectorViewModel
        Public Property DataCollector As ViewModel.DataCollectorViewModel
            Get
                Return _DataCollector
            End Get
            Set(value As ViewModel.DataCollectorViewModel)
                _DataCollector = value
                Consumer_Model.DataCollectorID = value?.ID
                RaisePropertyChanged()
            End Set
        End Property

        Private _TimeArea As ViewModel.TimeAreaViewModel
        Public Property TimeArea As ViewModel.TimeAreaViewModel
            Get
                Return _TimeArea
            End Get
            Set(value As ViewModel.TimeAreaViewModel)
                _TimeArea = value
                Consumer_Model.TimeAreaID = value?.ID
                RaisePropertyChanged()
            End Set
        End Property

        Private _device As ViewModel.DeviceViewModel
        Public Property Device As ViewModel.DeviceViewModel
            Get
                Return _device
            End Get
            Set(value As ViewModel.DeviceViewModel)
                _device = value
                Consumer_Model.DeviceID = value.ID
                RaisePropertyChanged()
            End Set
        End Property




    End Class
End Namespace
