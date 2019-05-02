Namespace Service
    Public Class DataService

        Public Property Consumers As List(Of Model.Consumer)
        Public Property Devices As List(Of Model.Device)
        Public Property DeviceGroups As List(Of Model.DeviceGroup)
        Public Property Rooms As List(Of Model.Room)
        Public Property TimeAreas As List(Of Model.TimeArea)
        Public Property DataCollectors As List(Of Model.DataCollector)


        Public Property XmlFolderPath As String

        Private Sub New()  'Damit kein Objekt angelegt werden kann
        End Sub

        Public Shared ReadOnly Property Instance As DataService = New DataService

        ' Properties speichern

        Public Sub SaveAllData()
            SaveConsumers()
            SaveDevices()
            SaveDeviceGroups()
            SaveRooms()
            SaveTimeAreas()
            SaveDataCollector()

        End Sub

        Friend Sub SaveConsumers(Optional consumerList As List(Of Model.Consumer) = Nothing)
            CheckForXmlFolderPath()
            If consumerList IsNot Nothing Then Consumers = consumerList
            Serializer.SaveXML(XmlFolderPath + "\consumers.xml", Consumers)
        End Sub
        Friend Sub SaveDevices(Optional deviceList As List(Of Model.Device) = Nothing)
            CheckForXmlFolderPath()
            If deviceList IsNot Nothing Then Devices = deviceList
            Serializer.SaveXML(XmlFolderPath + "\devices.xml", Devices)
        End Sub
        Friend Sub SaveDeviceGroups(Optional deviceGroupList As List(Of Model.DeviceGroup) = Nothing)
            CheckForXmlFolderPath()
            If deviceGroupList IsNot Nothing Then DeviceGroups = deviceGroupList
            Serializer.SaveXML(XmlFolderPath + "\deviceGroups.xml", DeviceGroups)
        End Sub
        Friend Sub SaveRooms(Optional roomList As List(Of Model.Room) = Nothing)
            CheckForXmlFolderPath()
            If roomList IsNot Nothing Then Rooms = roomList
            Serializer.SaveXML(XmlFolderPath + "\rooms.xml", Rooms)
        End Sub
        Friend Sub SaveTimeAreas(Optional timeAreaList As List(Of Model.TimeArea) = Nothing)
            CheckForXmlFolderPath()
            If timeAreaList IsNot Nothing Then TimeAreas = timeAreaList
            Serializer.SaveXML(XmlFolderPath + "\timeAreas.xml", TimeAreas)
        End Sub
        Friend Sub SaveDataCollector(Optional dataCollectorList As List(Of Model.DataCollector) = Nothing)
            CheckForXmlFolderPath()
            If dataCollectorList IsNot Nothing Then DataCollectors = dataCollectorList
            Serializer.SaveXML(XmlFolderPath + "\dataCollectors.xml", DataCollectors)
        End Sub

        ' Daten laden

        Friend Sub LoadAllData()
            LoadConsumers()
            LoadDevices()
            LoadDeviceGroups()
            LoadRooms()
            LoadTimeAreas()
            LoadDataCollectors()

        End Sub

        Friend Function LoadConsumers() As List(Of Model.Consumer)
            CheckForXmlFolderPath()
            Consumers = Serializer.LoadXML(Of List(Of Model.Consumer))(XmlFolderPath + "\consumers.xml")
            Return Consumers
        End Function
        Friend Function LoadDevices() As List(Of Model.Device)
            CheckForXmlFolderPath()
            Devices = Serializer.LoadXML(Of List(Of Model.Device))(XmlFolderPath + "\devices.xml")
            Return Devices
        End Function
        Friend Function LoadDeviceGroups() As List(Of Model.DeviceGroup)
            CheckForXmlFolderPath()
            DeviceGroups = Serializer.LoadXML(Of List(Of Model.DeviceGroup))(XmlFolderPath + "\deviceGroups.xml")
            Return DeviceGroups
        End Function
        Friend Function LoadRooms() As List(Of Model.Room)
            CheckForXmlFolderPath()
            Rooms = Serializer.LoadXML(Of List(Of Model.Room))(XmlFolderPath + "\rooms.xml")
            Return Rooms
        End Function
        Friend Function LoadTimeAreas() As List(Of Model.TimeArea)
            CheckForXmlFolderPath()
            TimeAreas = Serializer.LoadXML(Of List(Of Model.TimeArea))(XmlFolderPath + "\timeAreas.xml")
            Return TimeAreas
        End Function
        Friend Function LoadDataCollectors() As List(Of Model.DataCollector)
            CheckForXmlFolderPath()
            DataCollectors = Serializer.LoadXML(Of List(Of Model.DataCollector))(XmlFolderPath + "\dataCollectors.xml")
            Return DataCollectors
        End Function


        Public Sub Inistalize()
            Consumers = New List(Of Model.Consumer)
            Devices = New List(Of Model.Device)
            DeviceGroups = New List(Of Model.DeviceGroup)
            Rooms = New List(Of Model.Room)
            TimeAreas = New List(Of Model.TimeArea)
            DataCollectors = New List(Of Model.DataCollector)
        End Sub



        Public Sub ConsumerExist(c As Model.Consumer)

        End Sub


        ' Private Methoden und Funktionen
        Private Sub CheckForXmlFolderPath()
            If String.IsNullOrEmpty(XmlFolderPath) Then Throw New Exception("Der Pfad zu den XML Dateien muss angegeben werden!")
        End Sub
    End Class

End Namespace

