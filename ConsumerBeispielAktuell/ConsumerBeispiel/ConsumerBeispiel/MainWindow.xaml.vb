Imports System.Collections.ObjectModel

Class MainWindow

    Public Property ConsumerLVM As ViewModel.ConsumerListViewModel

    Public Sub New()
        InitializeComponent()

        Dim xmlFolderName As String = "Data"
        Dim AppPath = My.Application.Info.DirectoryPath
        Service.DataService.Instance.XmlFolderPath = $"{AppPath}\{xmlFolderName}"
        If Not IO.Directory.Exists(Service.DataService.Instance.XmlFolderPath) Then IO.Directory.CreateDirectory(Service.DataService.Instance.XmlFolderPath)
        Service.DataService.Instance.XmlFolderPath = "C:\Users\flori\Desktop\ExampleFiles"
        Service.DataService.Instance.Inistalize()
    End Sub


    Public Sub deleteConsumer(sender As Object, e As RoutedEventArgs)
        ConsumerLVM.AllConsumers.Remove(ConsumerLVM.SelectedConsumer)
        ConsumerLVM.SelectedConsumer = ConsumerLVM.AllConsumers.FirstOrDefault()
        Dim consumerModels As New List(Of Model.Consumer)
        ConsumerLVM.AllConsumers.ToList.ForEach(Sub(x) consumerModels.Add(x.Consumer_Model))
        Service.DataService.Instance.Consumers = consumerModels
        dataGrid.Focus()
    End Sub

    Public Sub deviceManager(sender As Object, e As RoutedEventArgs)
        Dim win As New win_deviceManager()
        win.ShowDialog()
        ConsumerLVM.Reload()
    End Sub
    Public Sub roomManager(sender As Object, e As RoutedEventArgs)
        Dim win As New win_roomManager()
        win.ShowDialog()
        ConsumerLVM.Reload()
    End Sub

    Public Sub openFile(sender As Object, e As RoutedEventArgs)
        Service.DataService.Instance.LoadAllData()

        ConsumerLVM = Nothing
        ConsumerLVM = New ViewModel.ConsumerListViewModel() 'Erzeuge neues Objekt mit Beispieldateien
        win_window.DataContext = ConsumerLVM                'Setze den DataContext
    End Sub

    Public Sub saveFile(sender As Object, e As RoutedEventArgs)
        Service.DataService.Instance.SaveAllData()
    End Sub

    Public Sub newConsumer(sender As Object, e As RoutedEventArgs)
        Dim win As New win_add_consumer()
        win.ShowDialog()
    End Sub

End Class
