
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports ConsumerBeispiel.Service

Namespace ViewModel
    Public Class DataCollectorListViewModel
        Inherits ViewModelBase

        Public Sub New()

            Dim DataCollectorsVM = New List(Of DataCollectorViewModel)
            DataService.Instance.DataCollectors.ForEach(Sub(x) DataCollectorsVM.Add(New DataCollectorViewModel(x)))

            AllDataCollectors = New ObservableCollection(Of DataCollectorViewModel)
            DataCollectorsVM.ForEach(Sub(x) AllDataCollectors.Add(x))
            SelectedDataCollector = AllDataCollectors.FirstOrDefault

            AllDataCollectorsView = CollectionViewSource.GetDefaultView(AllDataCollectors)
            AllDataCollectorsView.Filter = AddressOf AllDataCollectorsView_Filter

            AllDataCollectorsView.SortDescriptions.Add(New SortDescription("Names", ListSortDirection.Ascending))
            AllDataCollectorsView.GroupDescriptions.Add(New PropertyGroupDescription("Grade"))
        End Sub

        Private _allDataCollectors As ObservableCollection(Of DataCollectorViewModel)
        Public Property AllDataCollectors As ObservableCollection(Of DataCollectorViewModel)
            Get
                Return _allDataCollectors
            End Get
            Set(ByVal Value As ObservableCollection(Of DataCollectorViewModel))
                _allDataCollectors = Value
                RaisePropertyChanged()
            End Set
        End Property


        Private _allDataCollectorsView As ICollectionView
        Public Property AllDataCollectorsView As ICollectionView
            Get
                Return _allDataCollectorsView
            End Get
            Set(value As ICollectionView)
                _allDataCollectorsView = value
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
                AllDataCollectorsView.Refresh()
                RaisePropertyChanged()
            End Set
        End Property

        Private Function AllDataCollectorsView_Filter(obj As Object) As Boolean
            If String.IsNullOrEmpty(FilterText) Then Return True
            Dim currentDataCollector As DataCollectorViewModel = CType(obj, DataCollectorViewModel)
            Dim DataCollectorNamesF As Boolean = currentDataCollector.Names.ToLower.Contains(FilterText.ToLower)
            Dim gradeF As Boolean = currentDataCollector.Grade.ToLower.Contains(FilterText.ToLower)

            If DataCollectorNamesF Or gradeF Then
                Return True
            Else
                Return False
            End If
        End Function

        Private _selectedDataCollector As DataCollectorViewModel
        Public Property SelectedDataCollector As DataCollectorViewModel
            Get
                Return _selectedDataCollector
            End Get
            Set(value As DataCollectorViewModel)
                _selectedDataCollector = value
                RaisePropertyChanged()
            End Set
        End Property

    End Class

End Namespace

