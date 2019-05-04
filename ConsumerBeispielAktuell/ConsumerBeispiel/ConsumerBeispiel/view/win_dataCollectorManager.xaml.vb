Public Class win_dataCollectorManager

    Public Property DataCollectorsLVM As ViewModel.DataCollectorListViewModel

    Public Sub New()

        InitializeComponent()

        DataCollectorsLVM = New ViewModel.DataCollectorListViewModel()
        DataContext = DataCollectorsLVM

    End Sub


    Public Sub deleteDataCollector(sender As Object, e As RoutedEventArgs)
        If DataCollectorsLVM.SelectedDataCollector.UseCount <> 0 Then
            MsgBox("Dieser Datensammler kann nicht gelöscht werden." + vbCrLf + "Verbraucher haben noch einen Verweis auf ihn gesetzt.")
            Exit Sub
        End If

        DataCollectorsLVM.AllDataCollectors.Remove(DataCollectorsLVM.SelectedDataCollector)
        DataCollectorsLVM.SelectedDataCollector = DataCollectorsLVM.AllDataCollectors.FirstOrDefault()
        dataGrid.Focus()
    End Sub


    Public Sub submit(sender As Object, e As RoutedEventArgs)

        Dim DataCollectorModels As New List(Of Model.DataCollector)
        DataCollectorsLVM.AllDataCollectors.ToList.ForEach(Sub(x) DataCollectorModels.Add(x.DataCollector_Model))

        Service.DataService.Instance.DataCollectors = DataCollectorModels

        DialogResult = True
        Close()
    End Sub

End Class
