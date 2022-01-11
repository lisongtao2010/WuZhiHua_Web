Imports System.Configuration

Module A000Module

    Sub main()
        Dim Debug As String = ConfigurationManager.AppSettings("Debug").ToString()
        Dim startFormName As String = ConfigurationManager.AppSettings("StartFormName").ToString()

        If startFormName = "CheckMainForm" Then
            'Dim fm As New CheckMainForm
            'fm.Show()
        ElseIf startFormName = "MsMaintenanceLoginForm" Then
            Dim fm As New MsMaintenanceLoginForm
            fm.Show()
        End If

    End Sub


End Module
