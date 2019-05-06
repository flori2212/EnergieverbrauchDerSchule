Namespace ViewModel
    Public Class CalculateResultViewModel
        Inherits ViewModelBase

        Public ReadOnly Property CalculateResult_Model As Model.CalculateResult

        Public Sub New(calculateResultModel As Model.CalculateResult)
            CalculateResult_Model = calculateResultModel
            Consumers = calculateResultModel.Consumers
        End Sub


        Private _Consumers As List(Of ViewModel.ConsumerViewModel)
        Public Property Consumers As List(Of ViewModel.ConsumerViewModel)
            Get
                Return _Consumers
            End Get
            Set(value As List(Of ViewModel.ConsumerViewModel))
                _Consumers = value
                RaisePropertyChanged()
            End Set
        End Property


        Public Function GetDeviceGroupList() As Dictionary(Of String, Double)
            Dim deviceGroupList As New Dictionary(Of String, Double)
            For Each c As ViewModel.ConsumerViewModel In Consumers
                If deviceGroupList.ContainsKey(c.Device.DeviceGroup.Name) = False Then
                    deviceGroupList.Add(c.Device.DeviceGroup.Name, c.KwhPerYeahr)
                Else
                    deviceGroupList.Item(c.Device.DeviceGroup.Name) += c.KwhPerYeahr
                End If
            Next
            Return deviceGroupList
        End Function

    End Class
End Namespace

