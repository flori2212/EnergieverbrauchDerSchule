Namespace ViewModel

    Public Class DataCollectorViewModel
        Inherits ViewModelBase

        Private ReadOnly _dataCollectorModel As Model.DataCollector


        Public Sub New(dataCollectorModel As Model.DataCollector)
            _dataCollectorModel = dataCollectorModel

            Names = dataCollectorModel.Names
            Grade = dataCollectorModel.Grade
        End Sub



        Public ReadOnly Property ID As Integer
            Get
                Return _dataCollectorModel.ID
            End Get
        End Property


        Private _names As String
        Public Property Names As String
            Get
                Return _names
            End Get
            Set(value As String)
                _names = value
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
