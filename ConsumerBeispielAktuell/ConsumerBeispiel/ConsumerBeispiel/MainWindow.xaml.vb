Imports System.Collections.ObjectModel

Class MainWindow

    Public Property ConsumerLVM As ViewModel.ConsumerListViewModel

    Public Sub New()
        InitializeComponent()

        Service.DataService.Instance.XmlFolderPath = "C:\Users\flori\Desktop\testenergie"
        Service.DataService.Instance.Inistalize()
    End Sub


    Public Sub deleteConsumer(sender As Object, e As RoutedEventArgs)
        ConsumerLVM.AllConsumers.Remove(ConsumerLVM.SelectedConsumer)
        ConsumerLVM.SelectedConsumer = ConsumerLVM.AllConsumers.FirstOrDefault()
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
