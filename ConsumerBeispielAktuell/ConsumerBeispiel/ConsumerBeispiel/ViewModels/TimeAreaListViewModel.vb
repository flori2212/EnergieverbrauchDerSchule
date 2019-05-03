Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports ConsumerBeispiel.Service

Namespace ViewModel
    Public Class TimeAreaListViewModel
        Inherits ViewModelBase

        Public Sub New()

            Dim TimeAreasVM = New List(Of TimeAreaViewModel)
            DataService.Instance.TimeAreas.ForEach(Sub(x) TimeAreasVM.Add(New TimeAreaViewModel(x)))

            AllTimeAreas = New ObservableCollection(Of TimeAreaViewModel)
            TimeAreasVM.ForEach(Sub(x) AllTimeAreas.Add(x))
            SelectedTimeArea = AllTimeAreas.FirstOrDefault

            AllTimeAreasView = CollectionViewSource.GetDefaultView(AllTimeAreas)
            AllTimeAreasView.Filter = AddressOf AllTimeAreasView_Filter

            AllTimeAreasView.SortDescriptions.Add(New SortDescription("Name", ListSortDirection.Ascending))
            ' AllTimeAreasView.GroupDescriptions.Add(New PropertyGroupDescription("Floor")) ---Keine Gruppierung
        End Sub

        Private _allTimeAreas As ObservableCollection(Of TimeAreaViewModel)
        Public Property AllTimeAreas As ObservableCollection(Of TimeAreaViewModel)
            Get
                Return _allTimeAreas
            End Get
            Set(ByVal Value As ObservableCollection(Of TimeAreaViewModel))
                _allTimeAreas = Value
                RaisePropertyChanged()
            End Set
        End Property


        Private _allTimeAreasView As ICollectionView
        Public Property AllTimeAreasView As ICollectionView
            Get
                Return _allTimeAreasView
            End Get
            Set(value As ICollectionView)
                _allTimeAreasView = value
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
                AllTimeAreasView.Refresh()
                RaisePropertyChanged()
            End Set
        End Property

        Private Function AllTimeAreasView_Filter(obj As Object) As Boolean
            If String.IsNullOrEmpty(FilterText) Then Return True
            Dim currentTimeArea As TimeAreaViewModel = CType(obj, TimeAreaViewModel)
            Dim activeTimePerWeekF As Boolean = currentTimeArea.ActiveDaysPerWeek.ToString().ToLower.Contains(FilterText.ToLower)
            Dim percentOfTheYeahrF As Boolean = currentTimeArea.PercentOfTheYeahr.ToString().ToLower.Contains(FilterText.ToLower)
            Dim timePerDayInMinutes As Boolean = currentTimeArea.TimePerDayInMinutes.ToString().ToLower.Contains(FilterText.ToLower)


            If activeTimePerWeekF Or percentOfTheYeahrF Or timePerDayInMinutes Then
                Return True
            Else
                Return False
            End If
        End Function

        Private _selectedTimeArea As TimeAreaViewModel
        Public Property SelectedTimeArea As TimeAreaViewModel
            Get
                Return _selectedTimeArea
            End Get
            Set(value As TimeAreaViewModel)
                _selectedTimeArea = value
                RaisePropertyChanged()
            End Set
        End Property

    End Class
End Namespace



