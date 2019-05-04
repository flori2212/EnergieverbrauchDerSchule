Public Class win_calculate

    Public Property CalculateVM As ViewModel.CalculateViewModel

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        CalculateVM = New ViewModel.CalculateViewModel()
        DataContext = CalculateVM

    End Sub

    Public Sub calculate(sender As Object, e As RoutedEventArgs)
        Service.CalculateService.Instance.PricePerkWh = CalculateVM.PricePerkWh
        Service.CalculateService.Instance.Calculate()
        MsgBox(Service.CalculateService.Instance.PricePerYeahr)
    End Sub

End Class
