Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports ConsumerBeispiel.Service

Namespace ViewModel
    Public Class ConsumerListViewModel
        Inherits ViewModelBase

        Public Sub New()
            Reload()
        End Sub


        Public Sub Reload()
            Dim DevicesVM = New List(Of DeviceViewModel)
            Dim DeviceGroupsVM = New List(Of DeviceGroupViewModel)
            DataService.Instance.DeviceGroups.ForEach(Sub(x) DeviceGroupsVM.Add(New DeviceGroupViewModel(x)))
            DataService.Instance.Devices.ForEach(Sub(x) DevicesVM.Add(New DeviceViewModel(x, DeviceGroupsVM)))

            Dim RoomsVM = New List(Of RoomViewModel)
            DataService.Instance.Rooms.ForEach(Sub(x) RoomsVM.Add(New RoomViewModel(x)))

            Dim TimeAreasVM = New List(Of TimeAreaViewModel)
            DataService.Instance.TimeAreas.ForEach(Sub(x) TimeAreasVM.Add(New TimeAreaViewModel(x)))

            Dim DataCollectorsVM = New List(Of DataCollectorViewModel)
            DataService.Instance.DataCollectors.ForEach(Sub(x) DataCollectorsVM.Add(New DataCollectorViewModel(x)))

            Dim ConsumersVM = New List(Of ConsumerViewModel)
            DataService.Instance.Consumers.ForEach(Sub(x) ConsumersVM.Add(New ConsumerViewModel(x, (DevicesVM, RoomsVM, DataCollectorsVM, TimeAreasVM, DataService.Instance.DeviceGroups))))

            AllConsumers = New ObservableCollection(Of ConsumerViewModel)
            ConsumersVM.ForEach(Sub(x) AllConsumers.Add(x))
            SelectedConsumer = AllConsumers.FirstOrDefault()

            AllConsumersView = CollectionViewSource.GetDefaultView(AllConsumers)
            AllConsumersView.Filter = AddressOf AllConsumersView_Filter

            AllConsumersView.SortDescriptions.Add(New ComponentModel.SortDescription("Room.RoomNumber", ComponentModel.ListSortDirection.Ascending))
            AllConsumersView.GroupDescriptions.Add(New PropertyGroupDescription("Room.RoomNumber"))
        End Sub


        Private _allConsumers As ObservableCollection(Of ConsumerViewModel)
        Public Property AllConsumers As ObservableCollection(Of ConsumerViewModel)
            Get
                Return _allConsumers
            End Get
            Set(ByVal Value As ObservableCollection(Of ConsumerViewModel))
                _allConsumers = Value
                RaisePropertyChanged()
            End Set
        End Property

        Private _allConsumersView As ICollectionView
        Public Property AllConsumersView As ICollectionView
            Get
                Return _allConsumersView
            End Get
            Set(value As ICollectionView)
                _allConsumersView = value
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
                AllConsumersView.Refresh()
                RaisePropertyChanged()
            End Set
        End Property

        Private Function AllConsumersView_Filter(obj As Object) As Boolean
            If String.IsNullOrEmpty(FilterText) Then Return True
            Dim currentConsumer As ConsumerViewModel = CType(obj, ConsumerViewModel)

            Dim lowerFilterText = FilterText.ToLower()
            With currentConsumer
                Return .Room.RoomNumber.ToString.Contains(lowerFilterText) OrElse
                        .DataCollector.NamesAndGrade.ToLower.Contains(lowerFilterText) OrElse
                        .Device.DeviceGroup.Name.ToLower.Contains(lowerFilterText) OrElse
                        .Device.Name.ToLower.Contains(lowerFilterText)
            End With
        End Function




        Private _selectetConsumer As ConsumerViewModel
        Public Property SelectedConsumer As ConsumerViewModel
            Get
                Return _selectetConsumer
            End Get
            Set(value As ConsumerViewModel)
                _selectetConsumer = value
                RaisePropertyChanged()
            End Set
        End Property



    End Class
End Namespace
