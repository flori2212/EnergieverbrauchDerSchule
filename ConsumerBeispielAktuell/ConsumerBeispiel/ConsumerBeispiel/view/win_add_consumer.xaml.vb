Public Class win_add_consumer

    Public Property ConsumerVM As ViewModel.ConsumerViewModel

    Public Sub New(dVM As List(Of ViewModel.DeviceViewModel), rVM As List(Of ViewModel.RoomViewModel), dcVM As List(Of ViewModel.DataCollectorViewModel), taVM As List(Of ViewModel.TimeAreaViewModel))

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()
        Dim c As Model.Consumer = New Model.Consumer()
        ConsumerVM = New ViewModel.ConsumerViewModel(c, (dVM, rVM, dcVM, taVM))
        DataContext = ConsumerVM                            'Setze den DataContext

    End Sub

End Class
