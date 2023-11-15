Imports System.CodeDom.Compiler

Partial Class EVALTEST

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MsgBox(Calculate("1+2*3+4=12").ToString)




    End Sub


    Public Function GetBoolGsValue(ByVal expression As String, ByVal cell1 As String, ByVal cell2 As String, ByVal cell3 As String, ByVal cell4 As String, ByVal cell5 As String, ByVal cell6 As String) As Boolean
        expression = expression.Replace("cell1", cell1).Replace("cell2", cell2).Replace("cell3", cell3).Replace("cell4", cell4).Replace("cell5", cell5).Replace("cell6", cell6)
        Return Calculate(expression).ToString.ToUpper = "TRUE"
    End Function



    Public Function Calculate(ByVal expression As String) As Object
        Dim className As String = "clsF"
        Dim methodName As String = "funCal"

        Dim classSource As New System.Text.StringBuilder

        classSource.Append("public   class   " + className + vbCrLf)
        classSource.Append("         public  function " + methodName + "() as object" + vbCrLf)
        classSource.Append("                 return   " + expression + vbCrLf)
        classSource.Append("         end function" + vbCrLf)
        classSource.Append("end class")

        Dim codeProvider As New VBCodeProvider
        Dim cParams As New CompilerParameters
        cParams.GenerateExecutable = False
        cParams.GenerateInMemory = False
        Dim cResults As CompilerResults = codeProvider.CompileAssemblyFromSource(cParams, classSource.ToString)
        Dim asm As System.Reflection.Assembly = cResults.CompiledAssembly
        Dim eval As Object = asm.CreateInstance(className)

        Dim method As System.Reflection.MethodInfo = eval.GetType.GetMethod(methodName)
        Dim args() As String = Nothing
        Dim reObj As Object = method.Invoke(eval, args)

        GC.Collect()
        Return reObj
    End Function

End Class
