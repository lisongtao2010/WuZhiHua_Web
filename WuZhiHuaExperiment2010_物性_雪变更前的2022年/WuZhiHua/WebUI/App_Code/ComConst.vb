Imports Microsoft.VisualBasic

Public Class ComConst

    Public Const Err As String = "NG_DATA"

    Public Shared Function IsErr(ByVal data As String) As Boolean
        Return data = Err
    End Function


End Class
