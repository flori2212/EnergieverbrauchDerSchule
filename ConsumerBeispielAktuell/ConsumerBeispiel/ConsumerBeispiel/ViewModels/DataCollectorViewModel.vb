Namespace ViewModel

    Public Class DataCollectorViewModel
        Inherits ViewModelBase

        Public ReadOnly Property DataCollector_Model As Model.DataCollector


        Public Sub New(dataCollectorModel As Model.DataCollector)
            DataCollector_Model = dataCollectorModel

            Names = dataCollectorModel.Names
            Grade = dataCollectorModel.Grade
        End Sub



        Public ReadOnly Property ID As Guid
            Get
                Return DataCollector_Model.ID
            End Get
        End Property

        Public Property UseCount As Integer
            Get
                Return Service.DataService.Instance.GetDataCollectorUseCount(DataCollector_Model)
            End Get
            Set(value As Integer)
            End Set
        End Property


        Private _names As String
        Public Property Names As String
            Get
                Return _names
            End Get
            Set(value As String)
                _names = value
                DataCollector_Model.Names = value
                RaisePropertyChanged()
            End Set
        End Property

        Private _grade As String
        Public Property Grade As String
            Get
                Return _grade
            End Get
            Set(value As String)
                _grade = value
                DataCollector_Model.Grade = value
                RaisePropertyChanged()
            End Set
        End Property


        Public ReadOnly Property NamesAndGrade As String
            Get
                Return Names + " - " + Grade
            End Get
        End Property

    End Class

End Namespace
