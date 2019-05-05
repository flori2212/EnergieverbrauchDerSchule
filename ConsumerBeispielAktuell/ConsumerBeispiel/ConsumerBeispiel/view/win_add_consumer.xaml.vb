Public Class win_add_consumer

    Public Property ConsumerVM As ViewModel.ConsumerViewModel

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()
        Dim c As Model.Consumer = New Model.Consumer()


        Dim deviceVms As New List(Of ViewModel.DeviceViewModel)
        Dim deviceGroupVms As New List(Of ViewModel.DeviceGroupViewModel)
        Dim roomVms As New List(Of ViewModel.RoomViewModel)
        Dim dataCollectorVms As New List(Of ViewModel.DataCollectorViewModel)
        Dim timeAreaVms As New List(Of ViewModel.TimeAreaViewModel)

        With Service.DataService.Instance
            c.DataCollectorID = .DataCollectors.FirstOrDefault?.ID
            c.DeviceID = .Devices.FirstOrDefault?.ID
            c.RoomID = .Rooms.FirstOrDefault?.ID
            c.TimeAreaID = .TimeAreas.FirstOrDefault?.ID

            .DeviceGroups.ForEach(Sub(x) deviceGroupVms.Add(New ViewModel.DeviceGroupViewModel(x)))
            .Devices.ForEach(Sub(x) deviceVms.Add(New ViewModel.DeviceViewModel(x, deviceGroupVms)))
            .Rooms.ForEach(Sub(x) roomVms.Add(New ViewModel.RoomViewModel(x)))
            .DataCollectors.ForEach(Sub(x) dataCollectorVms.Add(New ViewModel.DataCollectorViewModel(x)))
            .TimeAreas.ForEach(Sub(x) timeAreaVms.Add(New ViewModel.TimeAreaViewModel(x)))

        End With

        ConsumerVM = New ViewModel.ConsumerViewModel(c, (deviceVms, roomVms, dataCollectorVms, timeAreaVms))
        DataContext = ConsumerVM                            'Setze den DataContext

    End Sub


    Private Sub BtnCreateConsumer_Click(sender As Object, e As RoutedEventArgs)
        Service.DataService.Instance.Consumers.Add(ConsumerVM.Consumer_Model)
        Service.DataService.Instance.SaveConsumers()
        Me.DialogResult = True
    End Sub
End Class
