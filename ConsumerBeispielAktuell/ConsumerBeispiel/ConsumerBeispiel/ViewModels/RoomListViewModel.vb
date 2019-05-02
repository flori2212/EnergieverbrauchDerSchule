Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports ConsumerBeispiel.Service

Namespace ViewModel

    Public Class RoomListViewModel
        Inherits ViewModelBase

        Public Sub New()

            Dim RoomsVM = New List(Of RoomViewModel)
            DataService.Instance.Rooms.ForEach(Sub(x) RoomsVM.Add(New RoomViewModel(x)))

            AllRooms = New ObservableCollection(Of RoomViewModel)
            RoomsVM.ForEach(Sub(x) AllRooms.Add(x))
            SelectedRoom = AllRooms.FirstOrDefault

            AllRoomsView = CollectionViewSource.GetDefaultView(AllRooms)
            AllRoomsView.Filter = AddressOf AllRoomsView_Filter

            AllRoomsView.SortDescriptions.Add(New ComponentModel.SortDescription("RoomNumber", ComponentModel.ListSortDirection.Ascending))
            AllRoomsView.GroupDescriptions.Add(New PropertyGroupDescription("Floor"))
        End Sub

        Private _allRooms As ObservableCollection(Of RoomViewModel)
        Public Property AllRooms As ObservableCollection(Of RoomViewModel)
            Get
                Return _allRooms
            End Get
            Set(ByVal Value As ObservableCollection(Of RoomViewModel))
                _allRooms = Value
                RaisePropertyChanged()
            End Set
        End Property


        Private _allRoomsView As ICollectionView
        Public Property AllRoomsView As ICollectionView
            Get
                Return _allRoomsView
            End Get
            Set(value As ICollectionView)
                _allRoomsView = value
                RaisePropertyChanged()
            End Set
        End Property

        Private _filterText As String
        Public Property FilterText As String
            Get
                Return _filterText
            End Get
            Set(value As String)
                _filterText = value
                AllRoomsView.Refresh()
                RaisePropertyChanged()
            End Set
        End Property

        Private Function AllRoomsView_Filter(obj As Object) As Boolean
            If String.IsNullOrEmpty(FilterText) Then Return True
            Dim currentRoom As RoomViewModel = CType(obj, RoomViewModel)
            Dim roomNumberF As Boolean = currentRoom.RoomNumber.ToLower.Contains(FilterText.ToLower)
            Dim floorF As Boolean = currentRoom.Floor.ToLower.Contains(FilterText.ToLower)

            If roomNumberF Or floorF Then
                Return True
            Else
                Return False
            End If
        End Function

        Private _selectedRoom As RoomViewModel
        Public Property SelectedRoom As RoomViewModel
            Get
                Return _selectedRoom
            End Get
            Set(value As RoomViewModel)
                _selectedRoom = value
                RaisePropertyChanged()
            End Set
        End Property


    End Class
End Namespace

