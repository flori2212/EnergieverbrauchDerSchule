Public Class win_add_consumer

    Public Property ConsumerLVM As ViewModel.ConsumerListViewModel

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ConsumerLVM = New ViewModel.ConsumerListViewModel() 'Erzeuge neues Objekt mit Beispieldateien
        DataContext = ConsumerLVM                            'Setze den DataContext

    End Sub

End Class
