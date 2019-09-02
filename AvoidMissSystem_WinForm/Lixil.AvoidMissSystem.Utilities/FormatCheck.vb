Imports System.Text
Imports System.Text.RegularExpressions

''' <summary>
''' 共通フォーマットチェック
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class FormatCheck

#Region "インスタンス生成禁止"
    Private Sub New()
    End Sub
#End Region

#Region "半角数字のみで構成されているかチェック"
    ''' <summary>
    ''' 半角数字のみで構成されているかチェックします。
    ''' </summary>
    ''' <param name="str">チェック対象の文字列</param>
    ''' <returns>半角数字のみ:True、半角数字以外:False</returns>
    ''' <remarks></remarks>
    Public Shared Function IsHalfNumberOnly(ByVal str As String) As Boolean

        If Not Regex.IsMatch(str, "^[0-9]+$") Then
            Return False
        End If
        Return True
    End Function
#End Region

#Region "半角英数字のみで構成されているかチェック"
    ''' <summary>
    ''' 半角英数字のみで構成されているかチェックします。
    ''' </summary>
    ''' <param name="str">チェック対象の文字列</param>
    ''' <returns>半角英数字のみ:True、半角英数字以外:False</returns>
    ''' <remarks></remarks>
    Public Shared Function IsAlphaNumberOnly(ByVal str As String) As Boolean

        If Not Regex.IsMatch(str, "^[a-zA-Z0-9]+$") Then
            Return False
        End If
        Return True
    End Function
#End Region

#Region "カンマを取り除いた後に半角数字だけで構成されているかチェック"
    ''' <summary>
    ''' カンマを取り除いた後に半角数字だけで構成されているかチェック"。
    ''' </summary>
    ''' <param name="str">チェック対象の文字列</param>
    ''' <returns>半角数字のみ:True、半角数字以外:False</returns>
    ''' <remarks></remarks>
    Public Shared Function IsTrimCommaAfterHalfNumberOnly(ByVal str As String) As Boolean

        Dim work As String = str.Replace(",", String.Empty)
        If Not Regex.IsMatch(work, "(^[0-9]+$)|(^-[0-9]+$)") Then
            Return False
        End If
        Return True
    End Function
#End Region

#Region "小数点入力の文字列かチェック"
    ''' <summary>
    ''' 小数点入力の文字列かチェック。
    ''' </summary>
    ''' <param name="str">チェック対象の文字列</param>
    ''' <returns>半角数字のみ:True、半角数字以外:False</returns>
    ''' <remarks></remarks>
    Public Shared Function IsDecimalNumber(ByVal str As String) As Boolean

        If Not Regex.IsMatch(str, "^([1-9]\d*|0)(\.\d+)?$") Then
            Return False
        End If
        Return True
    End Function
#End Region

#Region "全角英数カナのみで構成されているかチェック"
    ''' <summary>
    ''' 全角英数カナのみで構成されているかチェックします。
    ''' </summary>
    ''' <param name="str">チェック対象の文字列</param>
    ''' <returns>全角英数カナのみ:True、全角英数カナ以外:False</returns>
    ''' <remarks></remarks>
    Public Shared Function IsFullEnglishNumberKanaOnly(ByVal str As String) As Boolean

        For index As Integer = 1 To str.Length
            If Encoding.GetEncoding("UTF-8").GetByteCount(Mid(str, index, 1)) > 1 Then
                If Not Regex.IsMatch(Mid(str, index, 1), "^[　０-９ａ-ｚＡ-Ｚアイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワヲヰヱヴンヵヶァィゥェォャュョッヮ、。ー「」（）ガギグゲゴザジズゼゾダヂヅデドバビブベボパピプペポ]+$") Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function
#End Region

#Region "郵便番号フォーマットチェック"
    ''' <summary>
    ''' 郵便番号が正しいかどうかチェックします。
    ''' </summary>
    ''' <param name="str">チェック対象の文字列</param>
    ''' <returns>郵便番号が正しい場合:True、郵便番号が正しくない場合:False</returns>
    ''' <remarks></remarks>
    Public Shared Function IsZipCodeFormat(ByVal str As String) As Boolean

        If Regex.IsMatch(str, "^\d[3]-\d[4]$") Then
            Return False
        End If
        Return True
    End Function
#End Region

#Region "電話番号フォーマットチェック（ハイフン含む）"
    ''' <summary>
    ''' 電話番号が正しいかどうかをチェックします。
    ''' </summary>
    ''' <param name="str">チェック対象の文字列</param>
    ''' <returns>電話番号が正しい場合:True、電話番号が正しくない場合:False</returns>
    ''' <remarks></remarks>
    Public Shared Function IsTelNumberFormat(ByVal str As String) As Boolean

        If Not Regex.IsMatch(str, "^\d{2,4}-\d{2,4}-\d{3,4}$") Then
            Return False
        End If
        Return True
    End Function
#End Region

#Region "メールアドレスチェック"
    ''' <summary>
    ''' メールアドレスが正しいかどうかチェックします。
    ''' </summary>
    ''' <param name="str">チェック対象の文字列</param>
    ''' <returns>メールアドレスが正しい場合:True、メールアドレスが正しくない場合:False</returns>
    ''' <remarks></remarks>
    Public Shared Function IsEmailFormat(ByVal str As String) As Boolean

        If Not Regex.IsMatch(str, "^([a-zA-Z0-9])+([a-zA-Z0-9\._-])*@([a-zA-Z0-9_-])+([a-zA-Z0-9\._-]+)+$") Then
            Return False
        End If
        Return True
    End Function
#End Region

#Region "年月日フォーマットチェック"
    ''' <summary>
    ''' 年月日が正しいかどうかチェックします。
    ''' </summary>
    ''' <param name="str">チェック対象の文字列</param>
    ''' <returns>年月日が正しい場合:True、年月日が正しくない場合:False</returns>
    ''' <remarks></remarks>
    Public Shared Function IsDateFormat(ByVal str As String) As Boolean

        'yyyy/MM/dd構成チェック
        If str.Length <> 10 Then
            Return False
        End If
        If str.Substring(4, 1) <> "/" Then
            Return False
        End If
        If str.Substring(7, 1) <> "/" Then
            Return False
        End If

        '年、月、日をそれぞれ取得
        Dim year As String = str.Substring(0, 4)
        Dim month As String = str.Substring(5, 2)
        Dim day As String = str.Substring(8, 2)

        '年部分チェック
        If Regex.IsMatch(year, "[^0-9]") Then
            Return False
        Else
            If Integer.Parse(year) < 1 Then
                Return False
            End If
        End If

        '月部分チェック
        If Regex.IsMatch(month, "[^0-9]") Then
            Return False
        End If
        If Integer.Parse(month) < 1 Or Integer.Parse(month) > 12 Then
            Return False
        End If

        '日部分チェック
        If Regex.IsMatch(day, "[^0-9]") Then
            Return False
        End If

        '日付+月チェック
        Dim dayeOfMonth As Integer = Date.DaysInMonth(Integer.Parse(year), Integer.Parse(month))
        If Integer.Parse(day) > dayeOfMonth Then
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' 年月日が正しいかどうかチェックします。
    ''' </summary>
    ''' <param name="str">チェック対象の文字列</param>
    ''' <returns>年月日が正しい場合:True、年月日が正しくない場合:False</returns>
    ''' <remarks></remarks>
    Public Shared Function IsDate(ByVal str As String) As Boolean

        'yyyyMMdd構成チェック
        If str.Length <> 8 Then
            Return False
        End If

        '年、月、日をそれぞれ取得
        Dim year As String = str.Substring(0, 4)
        Dim month As String = str.Substring(4, 2)
        Dim day As String = str.Substring(6, 2)

        '年部分チェック
        If Regex.IsMatch(year, "[^0-9]") Then
            Return False
        Else
            If Integer.Parse(year) < 1 Then
                Return False
            End If
        End If

        '月部分チェック
        If Regex.IsMatch(month, "[^0-9]") Then
            Return False
        End If
        If Integer.Parse(month) < 1 Or Integer.Parse(month) > 12 Then
            Return False
        End If

        '日部分チェック
        If Regex.IsMatch(day, "[^0-9]") Then
            Return False
        End If

        '日付+月チェック
        Dim dayeOfMonth As Integer = Date.DaysInMonth(Integer.Parse(year), Integer.Parse(month))
        If Integer.Parse(day) > dayeOfMonth Then
            Return False
        End If
        Return True
    End Function
#End Region

#Region "禁則文字チェック"

#Region "入力可能とする文字の定義"
    ''' <summary>機種依存文字(89～92区)</summary>
    Public Const DIVISION_89_TO_92_CHAR As String = "纊褜鍈銈蓜俉炻昱棈鋹曻彅丨仡仼伀伃伹佖侒侊侚侔俍偀倢俿倞偆偰偂傔僴僘兊兤冝冾凬刕劜劦勀勛匀匇匤卲厓厲" & _
                                               "叝﨎咜咊咩哿喆坙坥垬埈埇﨏塚增墲夋奓奛奝奣妤妺孖寀甯寘寬尞岦岺峵崧嵓﨑嵂嵭嶸嶹巐弡弴彧德忞恝悅悊惞惕" & _
                                               "愠惲愑愷愰憘戓抦揵摠撝擎敎昀昕昻昉昮昞昤晥晗晙暙暠暲暿曺朎朗杦枻桒柀栁桄棏﨔榘槢樰橫橆橳橾櫢櫤毖氿汜" & _
                                               "沆洄涇浯涖涬淏淸淲淼渹湜渧渼溿濵瀅瀇瀨炅炫焏焄煜煆煇凞燁燾犾猤猪獷玽珉珖珣珒琇珵琦琪琩琮瑢璉璟甁畯皂" & _
                                               "皜皞皛皦益睆劯硺礰礼神祥禔福禛竑竧靖竫箞綷綠緖繒罇羡羽茁荢荿菇菶葈蕫﨟薰蘒﨡蠇裵訒訷詹誧誾諟譿賰賴贒" & _
                                               "赶﨣軏﨤逸遧郞都鄕釗釞釭釮釤釥鈆鈐鈊鈺鉀鈼鉎鉙鉑鈹鉧銧鉷鉸鋧鋗鋙鋐﨧鋕鋠鋓錥錡鋻﨨錞鋿錝錂鍰鍗鎤鏆鏞" & _
                                               "鏸鐱鑅鑈閒隆﨩隝隯霳霻靃靍靏靑靕顗顥飯飼餧館馞驎髙髜魵魲鮏鮱鮻鰀鵰鵫鶴鸙黑ⅰⅱⅲⅳⅴⅵⅶⅷⅸⅹ￢￤＇"

    ''' <summary>機種依存文字(115～119区)</summary>
    Public Const DIVISION_115_TO_119_CHAR As String = "ⅰⅱⅲⅳⅴⅵⅶⅷⅸⅹⅠⅡⅢⅣⅤⅥⅦⅧⅨⅩ￢￤＇""㈱№℡∵纊褜鍈銈蓜俉炻昱棈鋹曻彅丨仡仼伀伃伹佖侒侊侚" & _
                                                 "侔俍偀倢俿倞偆偰偂傔僴僘兊兤冝冾凬刕劜劦勀勛匀匇匤卲厓厲叝﨎咜咊咩哿喆坙坥垬埈埇﨏塚增墲夋奓奛奝奣妤" & _
                                                 "妺孖寀甯寘寬尞岦岺峵崧嵓﨑嵂嵭嶸嶹巐弡弴彧德忞恝悅悊惞惕愠惲愑愷愰憘戓抦揵摠撝擎敎昀昕昻昉昮昞昤晥晗" & _
                                                 "晙晴晳暙暠暲暿曺朎朗杦枻桒柀栁桄棏﨓楨﨔榘槢樰橫橆橳橾櫢櫤毖氿汜沆汯泚洄涇浯涖涬淏淸淲淼渹湜渧渼溿澈" & _
                                                 "澵濵瀅瀇瀨炅炫焏焄煜煆煇凞燁燾犱犾猤猪獷玽珉珖珣珒琇珵琦琪琩琮瑢璉璟甁畯皂皜皞皛皦益睆劯砡硎硤硺礰礼" & _
                                                 "神祥禔福禛竑竧靖竫箞精絈絜綷綠緖繒罇羡羽茁荢荿菇菶葈蒴蕓蕙蕫﨟薰蘒﨡蠇裵訒訷詹誧誾諟諸諶譓譿賰賴贒赶" & _
                                                 "﨣軏﨤逸遧郞都鄕鄧釚釗釞釭釮釤釥鈆鈐鈊鈺鉀鈼鉎鉙鉑鈹鉧銧鉷鉸鋧鋗鋙鋐﨧鋕鋠鋓錥錡鋻﨨錞鋿錝錂鍰鍗鎤鏆" & _
                                                 "鏞鏸鐱鑅鑈閒隆﨩隝隯霳霻靃靍靏靑靕顗顥飯飼餧館馞驎髙髜魵魲鮏鮱鮻鰀鵰鵫鶴鸙黑"

    ''' <summary>ホスト禁則文字内で入力可とするもの</summary>
    Public Const POSSIBLE_HOST_CHAR As String = "℡①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳〝〟㈲㈹㊤㊥㊦㊧㊨㍉㌔㌢㍍㌘㌧㌃㌶㍑㍗㌍㌦㌣㌫㍊㌻㍻㍾㍽㍼㎜㎝㎞㎎㎏㏄㎡㏍"

    ''' <summary>Web禁止文字内で入力可とするもの</summary>
    Public Const POSSIBLE_WEB_CHAR As String = "<>"

    Public Const a As String = "[\uff02]"
#End Region

    ''' <summary>
    ''' 禁則文字が含まれているかどうかチェックします。
    ''' </summary>
    ''' <param name="str">チェック対象の文字列</param>
    ''' <returns>禁則文字が含まれていない場合:True、禁則文字が含まれている場合:False</returns>
    ''' <remarks></remarks>
    Public Shared Function IsIllegalChars(ByVal str As String) As Boolean

        Dim checkString As New StringBuilder

        'Unicodeの\uff02（ダブルコーテーションの環境依存文字）は、VisualStudioで文字定義が作成出来ないため、先に取り除く。
        For i As Integer = 0 To str.Length - 1
            If Not Regex.IsMatch(str.Chars(i), "[\uff02]") Then
                checkString.Append(str.Chars(i))
            End If
        Next

        Dim valid As New ValidationService()
        Dim possibleSymbols As New StringBuilder
        possibleSymbols.Append(DIVISION_89_TO_92_CHAR)
        possibleSymbols.Append(DIVISION_115_TO_119_CHAR)
        possibleSymbols.Append(POSSIBLE_HOST_CHAR)
        possibleSymbols.Append(POSSIBLE_WEB_CHAR)

        '使用不可の文字がある場合はFalse
        If Not valid.ValidateChar(checkString.ToString().Replace(vbCrLf, "").Replace(vbCr, "").Replace(vbLf, ""), String.Empty, True, possibleSymbols.ToString(), False) Then
            Return False
        End If
        Return True
    End Function
#End Region

#Region "半角英数字のみで構成されているかチェック（符号含む）"
    ''' <summary>
    ''' 半角英数字のみで構成されているかチェックします（符号含む）。
    ''' </summary>
    ''' <param name="str">チェック対象の文字列</param>
    ''' <returns>半角英数字のみ:True、半角英数字以外:False</returns>
    ''' <remarks></remarks>
    Public Shared Function IsAlphaNumber(ByVal str As String) As Boolean

        If Not Regex.IsMatch(str, "^[a-zA-Z0-9\u0000-\u00FF]+$") Then
            Return False
        End If
        Return True
    End Function
#End Region

End Class
