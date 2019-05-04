Public Class win_timeAreaManager

    Public Property TimeAreasLVM As ViewModel.TimeAreaListViewModel

    Public Sub New()

        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        TimeAreasLVM = New ViewModel.TimeAreaListViewModel()
        DataContext = TimeAreasLVM

    End Sub


    Public Sub deleteTimeArea(sender As Object, e As RoutedEventArgs)
        If TimeAreasLVM.SelectedTimeArea.UseCount <> 0 Then
            MsgBox("Dieser Zeitberreich kann nicht gelöscht werden." + vbCrLf + "Verbraucher haben noch einen Verweis auf ihn gesetzt.")
            Exit Sub
        End If

        TimeAreasLVM.AllTimeAreas.Remove(TimeAreasLVM.SelectedTimeArea)
        TimeAreasLVM.SelectedTimeArea = TimeAreasLVM.AllTimeAreas.FirstOrDefault()
        dataGrid.Focus()
    End Sub


    Public Sub submit(sender As Object, e As RoutedEventArgs)

        Dim TimeAreaModels As New List(Of Model.TimeArea)
        TimeAreasLVM.AllTimeAreas.ToList.ForEach(Sub(x) TimeAreaModels.Add(x.TimeArea_Model))

        Service.DataService.Instance.TimeAreas = TimeAreaModels

        DialogResult = True
        Close()
    End Sub

End Class
