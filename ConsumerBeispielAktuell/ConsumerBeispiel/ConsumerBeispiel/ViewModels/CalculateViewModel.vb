Namespace ViewModel
    Public Class CalculateViewModel
        Inherits ViewModelBase

        Public Sub New()

        End Sub

        Private _pricePerkWh As Double
        Public Property PricePerkWh As Double
            Get
                Return _pricePerkWh
            End Get
            Set(value As Double)
                _pricePerkWh = value
                RaisePropertyChanged()
            End Set
        End Property



    End Class
End Namespace



