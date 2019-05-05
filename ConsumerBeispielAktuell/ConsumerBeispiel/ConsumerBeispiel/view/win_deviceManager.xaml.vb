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
        If DevicesLVM.SelectedDevice.UseCount <> 0 Then
            MsgBox("Dieses Gerät kann nicht gelöscht werden." + vbCrLf + "Verbraucher haben noch einen Verweis auf es gesetzt.")
            Exit Sub
        End If
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

    Public Sub newDevice(sender As Object, e As RoutedEventArgs)
        Dim win As New win_add_device()
        If win.ShowDialog() Then
            DevicesLVM.Reload()
        End If
    End Sub

End Class


