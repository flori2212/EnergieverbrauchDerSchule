Namespace ViewModel
    Public Class DeviceGroupViewModel
        Inherits ViewModelBase


        Private ReadOnly _deviceGroupModel As Model.DeviceGroup

        Public Sub New(deviceGroupModel As Model.DeviceGroup)
            _deviceGroupModel = deviceGroupModel

            Name = deviceGroupModel.Name
        End Sub

        Public ReadOnly Property ID As Integer
            Get
                Return _deviceGroupModel.ID
            End Get
        End Property


        Private _Name As String
        Public Property Name As String
            Get
                Return _Name
            End Get
            Set(value As String)
                _Name = value
                RaisePropertyChanged()
            End Set
        End Property
    End Class
End Namespace



