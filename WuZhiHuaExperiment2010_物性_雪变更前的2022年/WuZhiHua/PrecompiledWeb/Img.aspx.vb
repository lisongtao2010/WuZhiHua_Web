Imports System.Data

Partial Class Img
    Inherits System.Web.UI.Page

    Private checkDA As New CheckDA
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim bt As Byte()
            Dim dtPicInfo As DataTable = checkDA.GetPicInfoById(Request.QueryString("id")).Tables("PicInfo")
            If dtPicInfo.Rows.Count > 0 Then
                bt = DirectCast(dtPicInfo.Rows(0).Item("picture_content"), Byte())
                Response.BinaryWrite(bt)
            Else
            End If
            Response.End()
        Catch ex As Exception
        End Try

    End Sub
End Class
