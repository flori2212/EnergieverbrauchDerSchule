Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports ConsumerBeispiel.Service

Namespace ViewModel
    Public Class DeviceListViewModel
        Inherits ViewModel.ViewModelBase

        Public Sub New()

            Dim DevicesVM = New List(Of DeviceViewModel)
            Dim DeviceGroupsVM = New List(Of DeviceGroupViewModel)
            DataService.Instance.DeviceGroups.ForEach(Sub(x) DeviceGroupsVM.Add(New DeviceGroupViewModel(x)))
            DataService.Instance.Devices.ForEach(Sub(x) DevicesVM.Add(New DeviceViewModel(x, DeviceGroupsVM)))

            AllDevices = New ObservableCollection(Of DeviceViewModel)
            DevicesVM.ForEach(Sub(x) AllDevices.Add(x))
            SelectedDevice = AllDevices.FirstOrDefault

            AllDevicesView = CollectionViewSource.GetDefaultView(AllDevices)
            AllDevicesView.Filter = AddressOf AllDevicesView_Filter

            AllDevicesView.SortDescriptions.Add(New ComponentModel.SortDescription("DeviceGroup.Name", ComponentModel.ListSortDirection.Ascending))
            AllDevicesView.GroupDescriptions.Add(New PropertyGroupDescription("DeviceGroup.Name"))
        End Sub

        Private _allDevices As ObservableCollection(Of DeviceViewModel)
        Public Property AllDevices As ObservableCollection(Of DeviceViewModel)
            Get
                Return _allDevices
            End Get
            Set(ByVal Value As ObservableCollection(Of DeviceViewModel))
                _allDevices = Value
                RaisePropertyChanged()
            End Set
        End Property


        Private _allDevicesView As ICollectionView
        Public Property AllDevicesView As ICollectionView
            Get
                Return _allDevicesView
            End Get
            Set(value As ICollectionView)
                _allDevicesView = value
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
                AllDevicesView.Refresh()
                RaisePropertyChanged()
            End Set
        End Property

        Private Function AllDevicesView_Filter(obj As Object) As Boolean
            If String.IsNullOrEmpty(FilterText) Then Return True
            Dim currentDevice As DeviceViewModel = CType(obj, DeviceViewModel)
            Dim nameF As Boolean = currentDevice.Name.ToLower.Contains(FilterText.ToLower)
            Dim descriptionF As Boolean = currentDevice.Description.ToLower.Contains(FilterText.ToLower)
            Dim powerF As Boolean = currentDevice.Power.ToString.ToLower.Contains(FilterText.ToLower)
            Dim deviceGroupF As Boolean = currentDevice.DeviceGroup.Name.ToLower.Contains(FilterText.ToLower)

            If nameF Or descriptionF Or powerF Or deviceGroupF Then
                Return True
            Else
                Return False
            End If
        End Function

        Private _selectedDevice As DeviceViewModel
        Public Property SelectedDevice As DeviceViewModel
            Get
                Return _selectedDevice
            End Get
            Set(value As DeviceViewModel)
                _selectedDevice = value
                RaisePropertyChanged()
            End Set
        End Property


    End Class

End Namespace



