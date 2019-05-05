Namespace ViewModel
    Public Class DeviceGroupViewModel
        Inherits ViewModelBase


        Public ReadOnly Property DeviceGroup_Model As Model.DeviceGroup

        Public Sub New(deviceGroupModel As Model.DeviceGroup)
            DeviceGroup_Model = deviceGroupModel

            Name = deviceGroupModel.Name
        End Sub

        Public ReadOnly Property ID As Guid
            Get
                Return DeviceGroup_Model.ID
            End Get
        End Property


        Private _Name As String
        Public Property Name As String
            Get
                Return _Name
            End Get
            Set(value As String)
                _Name = value
                DeviceGroup_Model.Name = value
                RaisePropertyChanged()
            End Set
        End Property
    End Class
End Namespace



