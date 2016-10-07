Module Module1

    Dim myCustomer As Customer

    Sub Main()
        myCustomer = New Customer With
            {.Name = "Microsoft",
            .Contact = "Dmitry Lyalin"}

        ShowVB14Features()
    End Sub

    Sub ShowVB14Features()

#Region "Null-propogating operators"

        'If myCustomer IsNot Nothing AndAlso
        '    myCustomer.Address IsNot Nothing Then

        '    Dim _city = myCustomer.Address.City
        'End If

        Dim _city = myCustomer?.Address?.City

#End Region

#Region "Comments"

        Dim speakers = {"Robert", ' One speaker
                        "Dmitry"} ' Another speaker

        Dim roberts = From s In speakers  ' This is comment line 1
                      Select s            ' This is comment line 2
                      Where s = "Robert"  ' This is comment line 3
#End Region

#Region "Multiline string literals"

        Dim longString = "This is a demo of some of the new
                          features in VB 14. We think you will
                          be very happy with them and that they will
                          improve your productivity."
#End Region

#Region "String interpolation"
        'Dim _customer = String.Format(
        '    "Customer {0} in {1}", myCustomer.Name, myCustomer.Address.City)

        Dim _customer = $"Customer {myCustomer.Name} in {myCustomer.Address.City}"

#End Region

#Region "NameOf operator"
        Dim aString As String = Nothing

        'If aString Is Nothing Then Throw New ArgumentNullException("aString")

        If aString Is Nothing Then Throw New ArgumentNullException(NameOf(aString))
#End Region

#Region "Year-first date literals"

        Dim today = #2014-01-26#

#End Region


    End Sub

End Module
