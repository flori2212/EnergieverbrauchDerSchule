Namespace Service
    Public Class CalculateService

        Private Sub New()  'Damit kein Objekt angelegt werden kann
        End Sub

        Public Shared ReadOnly Property Instance As CalculateService = New CalculateService

        Public Property PricePerkWh As Double
        Public Property kWhByDeviceGroups As Dictionary(Of String, Double)
        Public Property kWhPerYeahr As Double
        Public Property PricePerYeahr As Double

        Public Sub Calculate()
            kWhByDeviceGroups = New Dictionary(Of String, Double)
            kWhPerYeahr = 0


            For Each c As Model.Consumer In DataService.Instance.Consumers
                Dim verbrauch As Double
                Dim device As Model.Device
                Dim deviceGroup As Model.DeviceGroup
                Dim timeArea As Model.TimeArea

                For Each d As Model.Device In DataService.Instance.Devices
                    If c.DeviceID = d.ID Then
                        device = d
                    End If
                Next

                For Each ta As Model.TimeArea In DataService.Instance.TimeAreas
                    If c.TimeAreaID = ta.ID Then
                        timeArea = ta
                    End If
                Next

                For Each dg As Model.DeviceGroup In DataService.Instance.DeviceGroups
                    If device.DeviceGroupID = dg.ID Then
                        deviceGroup = dg
                    End If
                Next

                verbrauch = c.DeviceCount * device.Power * (timeArea.GetTimePerYeahrInMinutes() / 60) 'Wh
                verbrauch /= 1000 'kWh

                kWhPerYeahr += verbrauch

                If kWhByDeviceGroups.ContainsKey(deviceGroup.Name) Then
                    kWhByDeviceGroups.Item(deviceGroup.Name) += verbrauch
                End If
            Next

            PricePerYeahr = kWhPerYeahr * PricePerkWh
        End Sub

    End Class
End Namespace


