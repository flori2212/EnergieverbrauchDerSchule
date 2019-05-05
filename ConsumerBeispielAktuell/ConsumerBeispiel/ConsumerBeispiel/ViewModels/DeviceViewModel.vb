Imports ConsumerBeispiel


Namespace ViewModel
    Public Class DeviceViewModel
        Inherits ViewModel.ViewModelBase

        Public ReadOnly Property Device_Model As Model.Device

        Public Sub New(deviceModel As Model.Device, aviableData As List(Of ViewModel.DeviceGroupViewModel))
            _aviableDeviceGroups = aviableData
            Device_Model = deviceModel

            DeviceGroup = aviableData.Where(Function(x) x.ID = Device_Model.DeviceGroupID).FirstOrDefault()

            Name = deviceModel.Name
            Description = deviceModel.Description
            Power = deviceModel.Power
        End Sub


        Public ReadOnly Property ID As Guid
            Get
                Return Device_Model.ID
            End Get
        End Property


        Public Property UseCount As Integer
            Get
                Return Service.DataService.Instance.GetDeviceUseCount(Device_Model)
            End Get
            Set(value As Integer)

            End Set
        End Property


        Private _Name As String
        Public Property Name As String
            Get
                Return _Name
            End Get
            Set(value As String)
                _Name = value
                Device_Model.Name = value
                RaisePropertyChanged()
            End Set
        End Property


        Private _Description As String
        Public Property Description As String
            Get
                Return _Description
            End Get
            Set(value As String)
                _Description = value
                Device_Model.Description = value
                RaisePropertyChanged()
            End Set
        End Property


        Private _Power As Double
        Public Property Power As Double
            Get
                Return _Power
            End Get
            Set(value As Double)
                _Power = value
                Device_Model.Power = value
                RaisePropertyChanged()
            End Set
        End Property


        Public ReadOnly Property NameAndPower As String
            Get
                Return Name + " - (" + Power.ToString() + " W) - " + DeviceGroup.Name
            End Get
        End Property



        Private _aviableDeviceGroups As List(Of ViewModel.DeviceGroupViewModel)
        Public Property aviableDeviceGroups As List(Of ViewModel.DeviceGroupViewModel)
            Get
                Return _aviableDeviceGroups
            End Get
            Set(value As List(Of ViewModel.DeviceGroupViewModel))
                _aviableDeviceGroups = value
                RaisePropertyChanged()
            End Set
        End Property


        Private _deviceGroup As ViewModel.DeviceGroupViewModel
        Public Property DeviceGroup As ViewModel.DeviceGroupViewModel
            Get
                Return _deviceGroup
            End Get
            Set(value As ViewModel.DeviceGroupViewModel)
                _deviceGroup = value
                Device_Model.DeviceGroupID = value.ID
                RaisePropertyChanged()
            End Set
        End Property

    End Class
End Namespace



