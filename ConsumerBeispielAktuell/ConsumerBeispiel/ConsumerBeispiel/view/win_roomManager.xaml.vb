Public Class win_roomManager

    Public Property RoomsLVM As ViewModel.RoomListViewModel

    Public Sub New()

        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        RoomsLVM = New ViewModel.RoomListViewModel()
        DataContext = RoomsLVM

    End Sub


    Public Sub deleteRoom(sender As Object, e As RoutedEventArgs)
        RoomsLVM.AllRooms.Remove(RoomsLVM.SelectedRoom)
        RoomsLVM.SelectedRoom = RoomsLVM.AllRooms.FirstOrDefault()
        dataGrid.Focus()
    End Sub


    Public Sub submit(sender As Object, e As RoutedEventArgs)

        Dim RoomModels As New List(Of Model.Room)
        RoomsLVM.AllRooms.ToList.ForEach(Sub(x) RoomModels.Add(x.Room_Model))

        Service.DataService.Instance.Rooms = RoomModels

        DialogResult = True
        Close()
    End Sub

End Class
