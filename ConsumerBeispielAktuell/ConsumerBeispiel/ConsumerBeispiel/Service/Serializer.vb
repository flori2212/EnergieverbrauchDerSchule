Imports System.IO
Imports System.Xml.Serialization

Namespace Service
    Friend Class Serializer
        Public Shared Sub SaveXML(Of K)(ByVal filename As String, ByVal serializedObject As K)
            Dim xml As XmlSerializer = New XmlSerializer(GetType(K))
            Dim fs As FileStream = New FileStream(filename, FileMode.Create)
            xml.Serialize(fs, serializedObject)
            fs.Close()
        End Sub

        Public Shared Function LoadXML(Of K)(ByVal filename As String) As K
            Dim xml As XmlSerializer = New XmlSerializer(GetType(K))
            Dim ret As K
            Dim fs As FileStream = New FileStream(filename, FileMode.Open)
            ret = CType(xml.Deserialize(fs), K)
            fs.Close()
            Return ret
        End Function
    End Class
End Namespace


