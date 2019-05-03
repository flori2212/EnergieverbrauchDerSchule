Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports ConsumerBeispiel.Service

Namespace ViewModel
    Public Class DeviceGroupListViewModel
        Inherits ViewModelBase

        Public Sub New()

            Dim DeviceGroupsVM = New List(Of DeviceGroupViewModel)
            DataService.Instance.DeviceGroups.ForEach(Sub(x) DeviceGroupsVM.Add(New DeviceGroupViewModel(x)))

            AllDeviceGroups = New ObservableCollection(Of DeviceGroupViewModel)
            DeviceGroupsVM.ForEach(Sub(x) AllDeviceGroups.Add(x))
            SelectedDeviceGroup = AllDeviceGroups.FirstOrDefault

            AllDeviceGroupsView = CollectionViewSource.GetDefaultView(AllDeviceGroups)
            AllDeviceGroupsView.Filter = AddressOf AllDeviceGroupsView_Filter

            AllDeviceGroupsView.SortDescriptions.Add(New SortDescription("Name", ListSortDirection.Ascending))
            ' AllDeviceGroupsView.GroupDescriptions.Add(New PropertyGroupDescription("Floor"))  ---Keine Gruppierung
        End Sub


        Private _allDeviceGroups As ObservableCollection(Of DeviceGroupViewModel)
        Public Property AllDeviceGroups As ObservableCollection(Of DeviceGroupViewModel)
            Get
                Return _allDeviceGroups
            End Get
            Set(ByVal Value As ObservableCollection(Of DeviceGroupViewModel))
                _allDeviceGroups = Value
                RaisePropertyChanged()
            End Set
        End Property


        Private _allDeviceGroupsView As ICollectionView
        Public Property AllDeviceGroupsView As ICollectionView
            Get
                Return _allDeviceGroupsView
            End Get
            Set(value As ICollectionView)
                _allDeviceGroupsView = value
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
                AllDeviceGroupsView.Refresh()
                RaisePropertyChanged()
            End Set
        End Property

        Private Function AllDeviceGroupsView_Filter(obj As Object) As Boolean
            If String.IsNullOrEmpty(FilterText) Then Return True
            Dim currentDeviceGroup As DeviceGroupViewModel = CType(obj, DeviceGroupViewModel)
            Dim NameF As Boolean = currentDeviceGroup.Name.ToLower.Contains(FilterText.ToLower)

            If NameF Then
                Return True
            Else
                Return False
            End If
        End Function

        Private _selectedDeviceGroup As DeviceGroupViewModel
        Public Property SelectedDeviceGroup As DeviceGroupViewModel
            Get
                Return _selectedDeviceGroup
            End Get
            Set(value As DeviceGroupViewModel)
                _selectedDeviceGroup = value
                RaisePropertyChanged()
            End Set
        End Property

    End Class
End Namespace


