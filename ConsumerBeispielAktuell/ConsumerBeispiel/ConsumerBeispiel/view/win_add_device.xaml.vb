Public Class win_add_device
    Public Property DeviceVM As ViewModel.DeviceViewModel

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        Dim d As Model.Device = New Model.Device()

        Dim deviceGroupVms As New List(Of ViewModel.DeviceGroupViewModel)

        d.DeviceGroupID = Service.DataService.Instance.DeviceGroups.FirstOrDefault?.ID
        Service.DataService.Instance.DeviceGroups.ForEach(Sub(x) deviceGroupVms.Add(New ViewModel.DeviceGroupViewModel(x)))

        DeviceVM = New ViewModel.DeviceViewModel(d, deviceGroupVms)
        DataContext = DeviceVM
    End Sub

    Private Sub Create(sender As Object, e As RoutedEventArgs)
        Service.DataService.Instance.Devices.Add(DeviceVM.Device_Model)
        DialogResult = True
        Close()
    End Sub

    Public Sub Cancel()
        DialogResult = False
        Close()
    End Sub

End Class
