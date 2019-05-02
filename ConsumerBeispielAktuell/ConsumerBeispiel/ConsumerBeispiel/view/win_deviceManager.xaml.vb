Imports System.Collections.ObjectModel

Public Class win_deviceManager

    Public Property DevicesLVM As ViewModel.DeviceListViewModel

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        DevicesLVM = New ViewModel.DeviceListViewModel()
        DataContext = DevicesLVM


    End Sub


    Public Sub deleteDevice(sender As Object, e As RoutedEventArgs)
        DevicesLVM.AllDevices.Remove(DevicesLVM.SelectedDevice)
        DevicesLVM.SelectedDevice = DevicesLVM.AllDevices.FirstOrDefault()
        dataGrid.Focus()
    End Sub


    Public Sub submit(sender As Object, e As RoutedEventArgs)

        Dim deviceModels As New List(Of Model.Device)
        DevicesLVM.AllDevices.ToList.ForEach(Sub(x) deviceModels.Add(x.Device_Model))

        Service.DataService.Instance.Devices = deviceModels

        DialogResult = True
        Close()
    End Sub

End Class


