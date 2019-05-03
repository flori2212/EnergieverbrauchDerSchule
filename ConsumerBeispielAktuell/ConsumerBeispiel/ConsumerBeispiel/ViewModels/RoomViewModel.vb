Namespace ViewModel
    Public Class RoomViewModel
        Inherits ViewModelBase

        Public ReadOnly Property Room_Model As Model.Room

        Public Sub New(roomModel As Model.Room)
            Room_Model = roomModel

            RoomNumber = roomModel.RoomNumber
            Floor = roomModel.Floor
        End Sub

        Public ReadOnly Property ID As Integer
            Get
                Return Room_Model.ID
            End Get
        End Property

        Public Property UseCount As Integer
            Get
                Return Service.DataService.Instance.GetRoomUseCount(Room_Model)
            End Get
            Set(value As Integer)

            End Set
        End Property


        Private _roomNumber As String
        Public Property RoomNumber As String
            Get
                Return _roomNumber
            End Get
            Set(value As String)
                _roomNumber = value
                Room_Model.RoomNumber = value
                RaisePropertyChanged()
            End Set
        End Property

        Private _floor As String
        Public Property Floor As String
            Get
                Return _floor
            End Get
            Set(value As String)
                _floor = value
                Room_Model.Floor = value
                RaisePropertyChanged()
            End Set
        End Property


    End Class
End Namespace

