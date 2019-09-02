﻿Imports System.Text.RegularExpressions

''' <summary>
''' 文字列検証クラス
''' </summary>
''' <remarks>文字列の検証を行うクラスです</remarks>
Public Class ValidationService
    Implements IDisposable

    'エラーリスト
    Private errorMessageList As ArrayList = Nothing

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks>Validatorのコンストラクタです</remarks>
    Sub New()
        errorMessageList = New ArrayList
    End Sub


    ''' <summary>
    ''' ErrorListの読み取り専用プロパティ。エラーメッセージが格納されているリストを返却します。
    ''' </summary>
    ''' <value>エラーリスト</value>
    ''' <returns>エラーリスト</returns>
    ''' <remarks>設定されているエラーリストを返却します。</remarks>
    Public ReadOnly Property ErrorList() As ArrayList
        Get
            Return errorMessageList
        End Get
    End Property

    ''' <summary>
    ''' 使用可能文字の検証を行うメソッドです。
    ''' 使用可能文字以外の文字がある場合はエラーメッセージをエラーリストに格納します。
    ''' </summary>
    ''' <param name="inString">チェック対象文字列</param>
    ''' <param name="errorMassage">エラーメッセージ</param>
    ''' <returns>チェック結果<br/>
    ''' 使用可能文字のみであった場合：TRUE<br/>
    ''' 使用可能文字以外の文字が存在した場合：FALSE
    ''' </returns>
    ''' <remarks>使用可能文字のパターンを取得し、チェック対象文字列をチェックし結果を返却します。
    ''' 使用可能文字以外の文字が存在した場合はエラーメッセージをエラーリストに格納します。
    ''' 以下の文字を使用可能文字とします。
    ''' 　・ANK（JIS X 0201）（Web禁止文字・半角カタカナを除く）
    ''' 　・JIS基本文字（JIS X 0208）
    ''' 　　　・記号、英数字、かな（01区～08区）
    ''' 　　　・13区の一部（Ⅰ Ⅱ Ⅲ Ⅳ Ⅴ Ⅵ Ⅶ Ⅷ Ⅸ Ⅹ ㈱ №）
    ''' 　・第1水準漢字（16区～47区）
    ''' 　・第2水準漢字（48区～84区）
    ''' 　<br/>
    ''' <code> Dim validator As New Validator()
    ''' Dim result As Boolean = validator.Validate(TextBox1.Text,"エラーメッセージ")
    ''' </code>
    ''' </remarks>
    Public Function ValidateChar(ByVal inString As String, ByVal errorMassage As String) As Boolean

        ValidateChar = True

        '入力文字列のチェック
        '空（Empty）の場合はそのまま返却する
        If (inString <> "") Then


            '文字列と使用可能文字のパターンを渡してチェック
            If Not (ChekReg(inString, GetPatternCode)) Then
                Me.errorMessageList.Add(errorMassage)
                ValidateChar = False
            End If
        End If

        Return ValidateChar

    End Function

    ''' <summary>
    ''' 使用可能文字の検証を行うメソッドです。<br/>CharValidatorで使用しています。<br/>
    ''' 使用可能文字以外の文字がある場合はエラーメッセージをエラーリストに格納します。
    ''' </summary>
    ''' <param name="inString">チェック対象文字列</param>
    ''' <param name="errorMassage">エラーメッセージ</param>
    ''' <param name="isKanaHalf">半角カタカナ許可</param>
    ''' <param name="possibleSymbol">許可半角記号</param>
    ''' <param name="allowHostChars">ホスト禁則文字チェックフラグ</param>
    ''' <returns>チェック結果<br/>
    ''' 使用可能文字のみであった場合：TRUE<br/>
    ''' 使用可能文字以外の文字が存在した場合：FALSE
    ''' </returns>
    ''' <remarks>使用可能文字のパターンを取得し、チェック対象文字列をチェックし結果を返却します。
    ''' 使用可能文字以外の文字が存在した場合はエラーメッセージをエラーリストに格納します。
    ''' 以下の文字を使用可能文字とします。
    ''' 　・ANK（JIS X 0201）（Web禁止文字・半角カタカナを除く）
    ''' 　・JIS基本文字（JIS X 0208）
    ''' 　　　・記号、英数字、かな（01区～08区）
    ''' 　　　・13区の一部（Ⅰ Ⅱ Ⅲ Ⅳ Ⅴ Ⅵ Ⅶ Ⅷ Ⅸ Ⅹ ㈱ №）
    ''' 　・第1水準漢字（16区～47区）
    ''' 　・第2水準漢字（48区～84区）
    ''' 　<br/>
    ''' <code> Dim validator As New Validator()<br/>
    ''' Dim result As Boolean = validator.Validate(TextBox1.Text,"エラーメッセージ",True,"!"#$%")
    ''' </code>
    ''' 　<br/>
    ''' ※このメソッドでは全角・半角の数字、英字、全角カタカナはチェック対象外になります。　<br/>
    ''' 　通常のチェックはValidateChar(String, String)を使用してください。
    ''' </remarks>
    Public Function ValidateChar(ByVal inString As String, ByVal errorMassage As String, ByVal isKanaHalf As Boolean, ByVal possibleSymbol As String, ByVal allowHostChars As Boolean) As Boolean
        Dim checkStr As String = inString
        Dim allKana As String = "[ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜｦﾝｧｨｩｪｫｬｭｮｯ､｡ｰ｢｣ﾞﾟ･]"
        Dim exclusionChars As String = "0123456789０１２３４５６７８９" & _
                                        "abcdefghijklmnopqrstuvwxyz" & _
                                        "ABCDEFGHIJKLMNOPQRSTUVWXYZ" & _
                                        "ＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ" & _
                                        "ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓｔｕｖｗｘｙｚ" & _
                                        "アイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワヲヰヱヴンヵヶァィゥェォャュョッヮ、。ー「」ガギグゲゴザジズゼゾダヂヅデドバビブベボパピプペポ"

        Dim hostChars As String = "℡①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳─│┌┐┘└├┬┤┴┼━┃┏┓┛┗┣┳┫┻╋┠┯┨┷┿┝┰┥┸╂〝〟㈲㈹㊤㊥㊦㊧㊨㍉㌔㌢㍍㌘㌧㌃㌶㍑㍗㌍㌦㌣㌫㍊㌻㍻㍾㍽㍼㎜㎝㎞㎎㎏㏄㎡㏍"

        For Each chr As String In possibleSymbol
            checkStr = checkStr.Replace(chr, "")
        Next
        For Each chrE As String In exclusionChars
            checkStr = checkStr.Replace(chrE, "")
        Next

        If isKanaHalf Then
            For Each chrK As String In allKana
                checkStr = checkStr.Replace(chrK, "")
            Next
        End If

        If allowHostChars = True Then
            For Each chrH As String In hostChars
                checkStr = checkStr.Replace(chrH, "")
            Next
        End If

        ValidateChar = ValidateChar(checkStr, errorMassage)
        Return ValidateChar

    End Function

    ''' <summary>
    ''' 使用可能文字の検証を行うメソッドです。<br/>CharValidatorで使用しています。<br/>
    ''' 使用可能文字以外の文字がある場合はエラーメッセージをエラーリストに格納します。
    ''' </summary>
    ''' <param name="inString">チェック対象文字列</param>
    ''' <param name="errorMassage">エラーメッセージ</param>
    ''' <param name="isKanaHalf">半角カタカナ許可</param>
    ''' <param name="possibleSymbol">許可半角記号</param>
    ''' <returns>チェック結果<br/>
    ''' 使用可能文字のみであった場合：TRUE<br/>
    ''' 使用可能文字以外の文字が存在した場合：FALSE
    ''' </returns>
    ''' <remarks>使用可能文字のパターンを取得し、チェック対象文字列をチェックし結果を返却します。
    ''' 使用可能文字以外の文字が存在した場合はエラーメッセージをエラーリストに格納します。
    ''' 以下の文字を使用可能文字とします。
    ''' 　・ANK（JIS X 0201）（Web禁止文字・半角カタカナを除く）
    ''' 　・JIS基本文字（JIS X 0208）
    ''' 　　　・記号、英数字、かな（01区～08区）
    ''' 　　　・13区の一部（Ⅰ Ⅱ Ⅲ Ⅳ Ⅴ Ⅵ Ⅶ Ⅷ Ⅸ Ⅹ ㈱ №）
    ''' 　・第1水準漢字（16区～47区）
    ''' 　・第2水準漢字（48区～84区）
    ''' 　<br/>
    ''' <code> Dim validator As New Validator()<br/>
    ''' Dim result As Boolean = validator.Validate(TextBox1.Text,"エラーメッセージ",True,"!"#$%")
    ''' </code>
    ''' 　<br/>
    ''' ※このメソッドでは全角・半角の数字、英字、全角カタカナはチェック対象外になります。　<br/>
    ''' 　通常のチェックはValidateChar(String, String)を使用してください。
    ''' </remarks>
    Public Function ValidateChar(ByVal inString As String, ByVal errorMassage As String, ByVal isKanaHalf As Boolean, ByVal possibleSymbol As String) As Boolean
        ValidateChar = ValidateChar(inString, errorMassage, isKanaHalf, possibleSymbol, False)
        Return ValidateChar
    End Function


    ''' <summary>
    ''' 使用可能文字のパターンを取得するメソッドです。
    ''' </summary>
    ''' <returns>使用可能文字の正規表現化したパターン</returns>
    ''' <remarks>正規表現化したUnicodeのパターンを返却します。</remarks>
    Private Function GetPatternCode() As String

        '使用可能文字のUnicode正規表現パターン
        GetPatternCode = "^[\u0020-\u0021|\u0023-\u0025|\u0028-\u002B|\u002D-\u003B|\u003D|\u003F-\u007E|\u00A7-\u00A8|\u00B0-\u00B1|\u00B4|\u00D7|" & _
                "\u00F7|\u0391-\u03A1|\u03A3-\u03A9|\u03B1-\u03C1|\u03C3-\u03C9|\u0401|\u0410-\u044F|\u0451|\u2010|\u2015|" & _
                "\u2018-\u2019|\u201C-\u201D|\u2025-\u2026|\u2032-\u2033|\u203B|\u2103|\u2116|\u2160-\u2169|\u2190-\u2193|\u221E|" & _
                "\u2225|\u2234|\u2260|\u2266-\u2267|\u25A0-\u25A1|\u25B2-\u25B3|\u25BC-\u25BD|\u25C6-\u25C7|\u25CB|\u25CE-\u25CF|" & _
                "\u2605-\u2606|\u2640|\u2642|\u3000-\u3003|\u3005-\u3015|\u3041-\u3093|\u309B-\u309E|\u30A1-\u30F6|\u30FB-\u30FE|\u3231|" & _
                "\u4E00-\u4E01|\u4E03|\u4E07-\u4E0B|\u4E0D-\u4E0E|\u4E10-\u4E11|\u4E14-\u4E19|\u4E1E|\u4E21|\u4E26|\u4E2A|" & _
                "\u4E2D|\u4E31-\u4E32|\u4E36|\u4E38-\u4E39|\u4E3B-\u4E3C|\u4E3F|\u4E42-\u4E43|\u4E45|\u4E4B|\u4E4D-\u4E4F|" & _
                "\u4E55-\u4E59|\u4E5D-\u4E5F|\u4E62|\u4E71|\u4E73|\u4E7E|\u4E80|\u4E82|\u4E85-\u4E86|\u4E88-\u4E8C|" & _
                "\u4E8E|\u4E91-\u4E92|\u4E94-\u4E95|\u4E98-\u4E99|\u4E9B-\u4E9C|\u4E9E-\u4EA2|\u4EA4-\u4EA6|\u4EA8|\u4EAB-\u4EAE|\u4EB0|" & _
                "\u4EB3|\u4EB6|\u4EBA|\u4EC0-\u4EC2|\u4EC4|\u4EC6-\u4EC7|\u4ECA-\u4ECB|\u4ECD-\u4ECF|\u4ED4-\u4ED9|\u4EDD-\u4EDF|" & _
                "\u4EE3-\u4EE5|\u4EED-\u4EEE|\u4EF0|\u4EF2|\u4EF6-\u4EF7|\u4EFB|\u4F01|\u4F09-\u4F0A|\u4F0D-\u4F11|\u4F1A|" & _
                "\u4F1C-\u4F1D|\u4F2F-\u4F30|\u4F34|\u4F36|\u4F38|\u4F3A|\u4F3C-\u4F3D|\u4F43|\u4F46-\u4F47|\u4F4D-\u4F51|" & _
                "\u4F53|\u4F55|\u4F57|\u4F59-\u4F5E|\u4F69|\u4F6F-\u4F70|\u4F73|\u4F75-\u4F76|\u4F7B-\u4F7C|\u4F7F|" & _
                "\u4F83|\u4F86|\u4F88|\u4F8B|\u4F8D|\u4F8F|\u4F91|\u4F96|\u4F98|\u4F9B|" & _
                "\u4F9D|\u4FA0-\u4FA1|\u4FAB|\u4FAD-\u4FAF|\u4FB5-\u4FB6|\u4FBF|\u4FC2-\u4FC4|\u4FCA|\u4FCE|\u4FD0-\u4FD1|" & _
                "\u4FD4|\u4FD7-\u4FD8|\u4FDA-\u4FDB|\u4FDD|\u4FDF|\u4FE1|\u4FE3-\u4FE5|\u4FEE-\u4FEF|\u4FF3|\u4FF5-\u4FF6|" & _
                "\u4FF8|\u4FFA|\u4FFE|\u5005-\u5006|\u5009|\u500B|\u500D|\u500F|\u5011-\u5012|\u5014|" & _
                "\u5016|\u5019-\u501A|\u501F|\u5021|\u5023-\u5026|\u5028-\u502D|\u5036|\u5039|\u5043|\u5047-\u5049|" & _
                "\u504F-\u5050|\u5055-\u5056|\u505A|\u505C|\u5065|\u506C|\u5072|\u5074-\u5076|\u5078|\u507D|" & _
                "\u5080|\u5085|\u508D|\u5091|\u5098-\u509A|\u50AC-\u50AD|\u50B2-\u50B5|\u50B7|\u50BE|\u50C2|" & _
                "\u50C5|\u50C9-\u50CA|\u50CD|\u50CF|\u50D1|\u50D5-\u50D6|\u50DA|\u50DE|\u50E3|\u50E5|" & _
                "\u50E7|\u50ED-\u50EE|\u50F5|\u50F9|\u50FB|\u5100-\u5102|\u5104|\u5109|\u5112|\u5114-\u5116|" & _
                "\u5118|\u511A|\u511F|\u5121|\u512A|\u5132|\u5137|\u513A-\u513C|\u513F-\u5141|\u5143-\u5149|" & _
                "\u514B-\u514E|\u5150|\u5152|\u5154|\u515A|\u515C|\u5162|\u5165|\u5168-\u516E|\u5171|" & _
                "\u5175-\u5178|\u517C|\u5180|\u5182|\u5185-\u5186|\u5189-\u518A|\u518C-\u518D|\u518F-\u5193|\u5195-\u5197|\u5199|" & _
                "\u51A0|\u51A2|\u51A4-\u51A6|\u51A8-\u51AC|\u51B0-\u51B7|\u51BD|\u51C4-\u51C6|\u51C9|\u51CB-\u51CD|\u51D6|" & _
                "\u51DB|\u51DD|\u51E0-\u51E1|\u51E6-\u51E7|\u51E9-\u51EA|\u51ED|\u51F0-\u51F1|\u51F5-\u51F6|\u51F8-\u51FA|\u51FD-\u51FE|" & _
                "\u5200|\u5203-\u5204|\u5206-\u5208|\u520A-\u520B|\u520E|\u5211|\u5214|\u5217|\u521D|\u5224-\u5225|" & _
                "\u5227|\u5229-\u522A|\u522E|\u5230|\u5233|\u5236-\u523B|\u5243-\u5244|\u5247|\u524A-\u524D|\u524F|" & _
                "\u5254|\u5256|\u525B|\u525E|\u5263-\u5265|\u5269-\u526A|\u526F-\u5275|\u527D|\u527F|\u5283|" & _
                "\u5287-\u5289|\u528D|\u5291-\u5292|\u5294|\u529B|\u529F-\u52A0|\u52A3|\u52A9-\u52AD|\u52B1|\u52B4-\u52B5|" & _
                "\u52B9|\u52BC|\u52BE|\u52C1|\u52C3|\u52C5|\u52C7|\u52C9|\u52CD|\u52D2|" & _
                "\u52D5|\u52D7-\u52D9|\u52DD-\u52E0|\u52E2-\u52E4|\u52E6-\u52E7|\u52F2-\u52F3|\u52F5|\u52F8-\u52FA|\u52FE-\u52FF|\u5301-\u5302|" & _
                "\u5305-\u5306|\u5308|\u530D|\u530F-\u5310|\u5315-\u5317|\u5319-\u531A|\u531D|\u5320-\u5321|\u5323|\u532A|" & _
                "\u532F|\u5331|\u5333|\u5338-\u533B|\u533F-\u5341|\u5343|\u5345-\u534A|\u534D|\u5351-\u5354|\u5357-\u5358|" & _
                "\u535A|\u535C|\u535E|\u5360|\u5366|\u5369|\u536E-\u5371|\u5373-\u5375|\u5377-\u5378|\u537B|" & _
                "\u537F|\u5382|\u5384|\u5396|\u5398|\u539A|\u539F-\u53A0|\u53A5-\u53A6|\u53A8-\u53A9|\u53AD-\u53AE|" & _
                "\u53B0|\u53B3|\u53B6|\u53BB|\u53C2-\u53C3|\u53C8-\u53CE|\u53D4|\u53D6-\u53D7|\u53D9|\u53DB|" & _
                "\u53DF|\u53E1-\u53E5|\u53E8-\u53F3|\u53F6-\u53F8|\u53FA|\u5401|\u5403-\u5404|\u5408-\u5411|\u541B|\u541D|" & _
                "\u541F-\u5420|\u5426|\u5429|\u542B-\u542E|\u5436|\u5438-\u5439|\u543B-\u543E|\u5440|\u5442|\u5446|" & _
                "\u5448-\u544A|\u544E|\u5451|\u545F|\u5468|\u546A|\u5470-\u5471|\u5473|\u5475-\u5477|\u547B-\u547D|" & _
                "\u5480|\u5484|\u5486|\u548B-\u548C|\u548E-\u5490|\u5492|\u54A2|\u54A4-\u54A5|\u54A8|\u54AB-\u54AC|" & _
                "\u54AF|\u54B2-\u54B3|\u54B8|\u54BC-\u54BE|\u54C0-\u54C2|\u54C4|\u54C7-\u54C9|\u54D8|\u54E1-\u54E2|\u54E5-\u54E6|" & _
                "\u54E8-\u54E9|\u54ED-\u54EE|\u54F2|\u54FA|\u54FD|\u5504|\u5506-\u5507|\u550F-\u5510|\u5514|\u5516|" & _
                "\u552E-\u552F|\u5531|\u5533|\u5538-\u5539|\u553E|\u5540|\u5544-\u5546|\u554C|\u554F|\u5553|" & _
                "\u5556-\u5557|\u555C-\u555D|\u5563|\u557B-\u557C|\u557E|\u5580|\u5583-\u5584|\u5587|\u5589-\u558B|\u5598-\u559A|" & _
                "\u559C-\u559F|\u55A7-\u55AC|\u55AE|\u55B0|\u55B6|\u55C4-\u55C5|\u55C7|\u55D4|\u55DA|\u55DC|" & _
                "\u55DF|\u55E3-\u55E4|\u55F7|\u55F9|\u55FD-\u55FE|\u5606|\u5609|\u5614|\u5616-\u5618|\u561B|" & _
                "\u5629|\u562F|\u5631-\u5632|\u5634|\u5636|\u5638|\u5642|\u564C|\u564E|\u5650|" & _
                "\u565B|\u5664|\u5668|\u566A-\u566C|\u5674|\u5678|\u567A|\u5680|\u5686-\u5687|\u568A|" & _
                "\u568F|\u5694|\u56A0|\u56A2|\u56A5|\u56AE|\u56B4|\u56B6|\u56BC|\u56C0-\u56C3|" & _
                "\u56C8|\u56CE|\u56D1|\u56D3|\u56D7-\u56D8|\u56DA-\u56DB|\u56DE|\u56E0|\u56E3|\u56EE|" & _
                "\u56F0|\u56F2-\u56F3|\u56F9-\u56FA|\u56FD|\u56FF-\u5700|\u5703-\u5704|\u5708-\u5709|\u570B|\u570D|\u570F|" & _
                "\u5712-\u5713|\u5716|\u5718|\u571C|\u571F|\u5726-\u5728|\u572D|\u5730|\u5737-\u5738|\u573B|" & _
                "\u5740|\u5742|\u5747|\u574A|\u574E-\u5751|\u5761|\u5764|\u5766|\u5769-\u576A|\u577F|" & _
                "\u5782|\u5788-\u5789|\u578B|\u5793|\u57A0|\u57A2-\u57A4|\u57AA|\u57B0|\u57B3|\u57C0|" & _
                "\u57C3|\u57C6|\u57CB|\u57CE|\u57D2-\u57D4|\u57D6|\u57DC|\u57DF-\u57E0|\u57E3|\u57F4|" & _
                "\u57F7|\u57F9-\u57FA|\u57FC|\u5800|\u5802|\u5805-\u5806|\u580A-\u580B|\u5815|\u5819|\u581D|" & _
                "\u5821|\u5824|\u582A|\u582F-\u5831|\u5834-\u5835|\u583A|\u583D|\u5840-\u5841|\u584A-\u584B|\u5851-\u5852|" & _
                "\u5854|\u5857-\u585A|\u585E|\u5862|\u5869|\u586B|\u5870|\u5872|\u5875|\u5879|" & _
                "\u587E|\u5883|\u5885|\u5893|\u5897|\u589C|\u589F|\u58A8|\u58AB|\u58AE|" & _
                "\u58B3|\u58B8-\u58BB|\u58BE|\u58C1|\u58C5|\u58C7|\u58CA|\u58CC|\u58D1|\u58D3|" & _
                "\u58D5|\u58D7-\u58D9|\u58DC|\u58DE-\u58DF|\u58E4-\u58E5|\u58EB-\u58EC|\u58EE-\u58F2|\u58F7|\u58F9-\u58FD|\u5902|" & _
                "\u5909-\u590A|\u590F-\u5910|\u5915-\u5916|\u5918-\u591C|\u5922|\u5925|\u5927|\u5929-\u592E|\u5931-\u5932|\u5937-\u5938|" & _
                "\u593E|\u5944|\u5947-\u5949|\u594E-\u5951|\u5954-\u5955|\u5957-\u5958|\u595A|\u5960|\u5962|\u5965|" & _
                "\u5967-\u596A|\u596C|\u596E|\u5973-\u5974|\u5978|\u597D|\u5981-\u5984|\u598A|\u598D|\u5993|" & _
                "\u5996|\u5999|\u599B|\u599D|\u59A3|\u59A5|\u59A8|\u59AC|\u59B2|\u59B9|" & _
                "\u59BB|\u59BE|\u59C6|\u59C9|\u59CB|\u59D0-\u59D1|\u59D3-\u59D4|\u59D9-\u59DA|\u59DC|\u59E5-\u59E6|" & _
                "\u59E8|\u59EA-\u59EB|\u59F6|\u59FB|\u59FF|\u5A01|\u5A03|\u5A09|\u5A11|\u5A18|" & _
                "\u5A1A|\u5A1C|\u5A1F-\u5A20|\u5A25|\u5A29|\u5A2F|\u5A35-\u5A36|\u5A3C|\u5A40-\u5A41|\u5A46|" & _
                "\u5A49|\u5A5A|\u5A62|\u5A66|\u5A6A|\u5A6C|\u5A7F|\u5A92|\u5A9A-\u5A9B|\u5ABC-\u5ABE|" & _
                "\u5AC1-\u5AC2|\u5AC9|\u5ACB-\u5ACC|\u5AD0|\u5AD6-\u5AD7|\u5AE1|\u5AE3|\u5AE6|\u5AE9|\u5AFA-\u5AFB|" & _
                "\u5B09|\u5B0B-\u5B0C|\u5B16|\u5B22|\u5B2A|\u5B2C|\u5B30|\u5B32|\u5B36|\u5B3E|" & _
                "\u5B40|\u5B43|\u5B45|\u5B50-\u5B51|\u5B54-\u5B55|\u5B57-\u5B58|\u5B5A-\u5B5D|\u5B5F|\u5B63-\u5B66|\u5B69|" & _
                "\u5B6B|\u5B70-\u5B71|\u5B73|\u5B75|\u5B78|\u5B7A|\u5B80|\u5B83|\u5B85|\u5B87-\u5B89|" & _
                "\u5B8B-\u5B8D|\u5B8F|\u5B95|\u5B97-\u5B9D|\u5B9F|\u5BA2-\u5BA6|\u5BAE|\u5BB0|\u5BB3-\u5BB6|\u5BB8-\u5BB9|" & _
                "\u5BBF|\u5BC2-\u5BC7|\u5BC9|\u5BCC|\u5BD0|\u5BD2-\u5BD4|\u5BDB|\u5BDD-\u5BDF|\u5BE1-\u5BE2|\u5BE4-\u5BE9|" & _
                "\u5BEB|\u5BEE|\u5BF0|\u5BF3|\u5BF5-\u5BF6|\u5BF8|\u5BFA|\u5BFE-\u5BFF|\u5C01-\u5C02|\u5C04-\u5C0B|" & _
                "\u5C0D-\u5C0F|\u5C11|\u5C13|\u5C16|\u5C1A|\u5C20|\u5C22|\u5C24|\u5C28|\u5C2D|" & _
                "\u5C31|\u5C38-\u5C41|\u5C45-\u5C46|\u5C48|\u5C4A-\u5C4B|\u5C4D-\u5C51|\u5C53|\u5C55|\u5C5E|\u5C60-\u5C61|" & _
                "\u5C64-\u5C65|\u5C6C|\u5C6E-\u5C6F|\u5C71|\u5C76|\u5C79|\u5C8C|\u5C90-\u5C91|\u5C94|\u5CA1|" & _
                "\u5CA8-\u5CA9|\u5CAB-\u5CAC|\u5CB1|\u5CB3|\u5CB6-\u5CB8|\u5CBB-\u5CBC|\u5CBE|\u5CC5|\u5CC7|\u5CD9|" & _
                "\u5CE0-\u5CE1|\u5CE8-\u5CEA|\u5CED|\u5CEF-\u5CF0|\u5CF6|\u5CFA-\u5CFB|\u5CFD|\u5D07|\u5D0B|\u5D0E|" & _
                "\u5D11|\u5D14-\u5D1B|\u5D1F|\u5D22|\u5D29|\u5D4B-\u5D4C|\u5D4E|\u5D50|\u5D52|\u5D5C|" & _
                "\u5D69|\u5D6C|\u5D6F|\u5D73|\u5D76|\u5D82|\u5D84|\u5D87|\u5D8B-\u5D8C|\u5D90|" & _
                "\u5D9D|\u5DA2|\u5DAC|\u5DAE|\u5DB7|\u5DBA|\u5DBC-\u5DBD|\u5DC9|\u5DCC-\u5DCD|\u5DD2-\u5DD3|" & _
                "\u5DD6|\u5DDB|\u5DDD-\u5DDE|\u5DE1|\u5DE3|\u5DE5-\u5DE8|\u5DEB|\u5DEE|\u5DF1-\u5DF5|\u5DF7|" & _
                "\u5DFB|\u5DFD-\u5DFE|\u5E02-\u5E03|\u5E06|\u5E0B-\u5E0C|\u5E11|\u5E16|\u5E19-\u5E1B|\u5E1D|\u5E25|" & _
                "\u5E2B|\u5E2D|\u5E2F-\u5E30|\u5E33|\u5E36-\u5E38|\u5E3D|\u5E40|\u5E43-\u5E45|\u5E47|\u5E4C|" & _
                "\u5E4E|\u5E54-\u5E55|\u5E57|\u5E5F|\u5E61-\u5E64|\u5E72-\u5E76|\u5E78-\u5E7F|\u5E81|\u5E83-\u5E84|\u5E87|" & _
                "\u5E8A|\u5E8F|\u5E95-\u5E97|\u5E9A|\u5E9C|\u5EA0|\u5EA6-\u5EA7|\u5EAB|\u5EAD|\u5EB5-\u5EB8|" & _
                "\u5EC1-\u5EC3|\u5EC8-\u5ECA|\u5ECF-\u5ED0|\u5ED3|\u5ED6|\u5EDA-\u5EDB|\u5EDD|\u5EDF-\u5EE3|\u5EE8-\u5EE9|\u5EEC|" & _
                "\u5EF0-\u5EF1|\u5EF3-\u5EF4|\u5EF6-\u5EF8|\u5EFA-\u5EFC|\u5EFE-\u5EFF|\u5F01|\u5F03-\u5F04|\u5F09-\u5F0D|\u5F0F-\u5F11|\u5F13-\u5F18|" & _
                "\u5F1B|\u5F1F|\u5F25-\u5F27|\u5F29|\u5F2D|\u5F2F|\u5F31|\u5F35|\u5F37-\u5F38|\u5F3C|" & _
                "\u5F3E|\u5F41|\u5F48|\u5F4A|\u5F4C|\u5F4E|\u5F51|\u5F53|\u5F56-\u5F57|\u5F59|" & _
                "\u5F5C-\u5F5D|\u5F61-\u5F62|\u5F66|\u5F69-\u5F6D|\u5F70-\u5F71|\u5F73|\u5F77|\u5F79|\u5F7C|\u5F7F-\u5F85|" & _
                "\u5F87-\u5F88|\u5F8A-\u5F8C|\u5F90-\u5F93|\u5F97-\u5F99|\u5F9E|\u5FA0-\u5FA1|\u5FA8-\u5FAA|\u5FAD-\u5FAE|\u5FB3-\u5FB4|\u5FB9|" & _
                "\u5FBC-\u5FBD|\u5FC3|\u5FC5|\u5FCC-\u5FCD|\u5FD6-\u5FD9|\u5FDC-\u5FDD|\u5FE0|\u5FE4|\u5FEB|\u5FF0-\u5FF1|" & _
                "\u5FF5|\u5FF8|\u5FFB|\u5FFD|\u5FFF|\u600E-\u6010|\u6012|\u6015-\u6016|\u6019|\u601B-\u601D|" & _
                "\u6020-\u6021|\u6025-\u602B|\u602F|\u6031|\u603A|\u6041-\u6043|\u6046|\u604A-\u604B|\u604D|\u6050|" & _
                "\u6052|\u6055|\u6059-\u605A|\u605F-\u6060|\u6062-\u6065|\u6068-\u606D|\u606F-\u6070|\u6075|\u6077|\u6081|" & _
                "\u6083-\u6084|\u6089|\u608B-\u608D|\u6092|\u6094|\u6096-\u6097|\u609A-\u609B|\u609F-\u60A0|\u60A3|\u60A6-\u60A7|" & _
                "\u60A9-\u60AA|\u60B2-\u60B6|\u60B8|\u60BC-\u60BD|\u60C5-\u60C7|\u60D1|\u60D3|\u60D8|\u60DA|\u60DC|" & _
                "\u60DF-\u60E1|\u60E3|\u60E7-\u60E8|\u60F0-\u60F1|\u60F3-\u60F4|\u60F6-\u60F7|\u60F9-\u60FB|\u6100-\u6101|\u6103|\u6106|" & _
                "\u6108-\u6109|\u610D-\u610F|\u6115|\u611A-\u611B|\u611F|\u6121|\u6127-\u6128|\u612C|\u6134|\u613C-\u613F|" & _
                "\u6142|\u6144|\u6147-\u6148|\u614A-\u614E|\u6153|\u6155|\u6158-\u615A|\u615D|\u615F|\u6162-\u6163|" & _
                "\u6165|\u6167-\u6168|\u616B|\u616E-\u6171|\u6173-\u6177|\u617E|\u6182|\u6187|\u618A|\u618E|" & _
                "\u6190-\u6191|\u6194|\u6196|\u6199-\u619A|\u61A4|\u61A7|\u61A9|\u61AB-\u61AC|\u61AE|\u61B2|" & _
                "\u61B6|\u61BA|\u61BE|\u61C3|\u61C6-\u61CD|\u61D0|\u61E3|\u61E6|\u61F2|\u61F4|" & _
                "\u61F6-\u61F8|\u61FA|\u61FC-\u6200|\u6208-\u620A|\u620C-\u620E|\u6210-\u6212|\u6214|\u6216|\u621A-\u621B|\u621D-\u621F|" & _
                "\u6221|\u6226|\u622A|\u622E-\u6230|\u6232-\u6234|\u6238|\u623B|\u623F-\u6241|\u6247-\u6249|\u624B|" & _
                "\u624D-\u624E|\u6253|\u6255|\u6258|\u625B|\u625E|\u6260|\u6263|\u6268|\u626E|" & _
                "\u6271|\u6276|\u6279|\u627C|\u627E-\u6280|\u6282-\u6284|\u6289-\u628A|\u6291-\u6298|\u629B-\u629C|\u629E|" & _
                "\u62AB-\u62AC|\u62B1|\u62B5|\u62B9|\u62BB-\u62BD|\u62C2|\u62C5-\u62CA|\u62CC-\u62CD|\u62CF-\u62D4|\u62D7-\u62D9|" & _
                "\u62DB-\u62DD|\u62E0-\u62E1|\u62EC-\u62EF|\u62F1|\u62F3|\u62F5-\u62F7|\u62FE-\u62FF|\u6301-\u6302|\u6307-\u6309|\u630C|" & _
                "\u6311|\u6319|\u631F|\u6327-\u6328|\u632B|\u632F|\u633A|\u633D-\u633F|\u6349|\u634C-\u634D|" & _
                "\u634F-\u6350|\u6355|\u6357|\u635C|\u6367-\u6369|\u636B|\u636E|\u6372|\u6376-\u6377|\u637A-\u637B|" & _
                "\u6380|\u6383|\u6388-\u6389|\u638C|\u638E-\u638F|\u6392|\u6396|\u6398|\u639B|\u639F-\u63A3|" & _
                "\u63A5|\u63A7-\u63AC|\u63B2|\u63B4-\u63B5|\u63BB|\u63BE|\u63C0|\u63C3-\u63C4|\u63C6|\u63C9|" & _
                "\u63CF-\u63D0|\u63D2|\u63D6|\u63DA-\u63DB|\u63E1|\u63E3|\u63E9|\u63EE|\u63F4|\u63F6|" & _
                "\u63FA|\u6406|\u640D|\u640F|\u6413|\u6416-\u6417|\u641C|\u6426|\u6428|\u642C-\u642D|" & _
                "\u6434|\u6436|\u643A|\u643E|\u6442|\u644E|\u6458|\u6467|\u6469|\u646F|" & _
                "\u6476|\u6478|\u647A|\u6483|\u6488|\u6492-\u6493|\u6495|\u649A|\u649E|\u64A4-\u64A5|" & _
                "\u64A9|\u64AB|\u64AD-\u64AE|\u64B0|\u64B2|\u64B9|\u64BB-\u64BC|\u64C1-\u64C2|\u64C5|\u64C7|" & _
                "\u64CD|\u64D2|\u64D4|\u64D8|\u64DA|\u64E0-\u64E3|\u64E6-\u64E7|\u64EC|\u64EF|\u64F1-\u64F2|" & _
                "\u64F4|\u64F6|\u64FA|\u64FD-\u64FE|\u6500|\u6505|\u6518|\u651C-\u651D|\u6523-\u6524|\u652A-\u652C|" & _
                "\u652F|\u6534-\u6539|\u653B|\u653E-\u653F|\u6545|\u6548|\u654D|\u654F|\u6551|\u6555-\u6559|" & _
                "\u655D-\u655E|\u6562-\u6563|\u6566|\u656C|\u6570|\u6572|\u6574-\u6575|\u6577-\u6578|\u6582-\u6583|\u6587-\u6589|" & _
                "\u658C|\u658E|\u6590-\u6591|\u6597|\u6599|\u659B-\u659C|\u659F|\u65A1|\u65A4-\u65A5|\u65A7|" & _
                "\u65AB-\u65AD|\u65AF-\u65B0|\u65B7|\u65B9|\u65BC-\u65BD|\u65C1|\u65C3-\u65C6|\u65CB-\u65CC|\u65CF|\u65D2|" & _
                "\u65D7|\u65D9|\u65DB|\u65E0-\u65E2|\u65E5-\u65E9|\u65EC-\u65ED|\u65F1|\u65FA-\u65FB|\u6602-\u6603|\u6606-\u6607|" & _
                "\u660A|\u660C|\u660E-\u660F|\u6613-\u6614|\u661C|\u661F-\u6620|\u6625|\u6627-\u6628|\u662D|\u662F|" & _
                "\u6634-\u6636|\u663C|\u663F|\u6641-\u6644|\u6649|\u664B|\u664F|\u6652|\u665D-\u665F|\u6662|" & _
                "\u6664|\u6666-\u6669|\u666E-\u6670|\u6674|\u6676|\u667A|\u6681|\u6683-\u6684|\u6687-\u6689|\u668E|" & _
                "\u6691|\u6696-\u6698|\u669D|\u66A2|\u66A6|\u66AB|\u66AE|\u66B4|\u66B8-\u66B9|\u66BC|" & _
                "\u66BE|\u66C1|\u66C4|\u66C7|\u66C9|\u66D6|\u66D9-\u66DA|\u66DC-\u66DD|\u66E0|\u66E6|" & _
                "\u66E9|\u66F0|\u66F2-\u66F5|\u66F7-\u66F9|\u66FC-\u6700|\u6703|\u6708-\u6709|\u670B|\u670D|\u670F|" & _
                "\u6714-\u6717|\u671B|\u671D-\u671F|\u6726-\u6728|\u672A-\u672E|\u6731|\u6734|\u6736-\u6738|\u673A|\u673D|" & _
                "\u673F|\u6741|\u6746|\u6749|\u674E-\u6751|\u6753|\u6756|\u6759|\u675C|\u675E-\u6765|" & _
                "\u676A|\u676D|\u676F-\u6773|\u6775|\u6777|\u677C|\u677E-\u677F|\u6785|\u6787|\u6789|" & _
                "\u678B-\u678C|\u6790|\u6795|\u6797|\u679A|\u679C-\u679D|\u67A0-\u67A2|\u67A6|\u67A9|\u67AF|" & _
                "\u67B3-\u67B4|\u67B6-\u67B9|\u67C1|\u67C4|\u67C6|\u67CA|\u67CE-\u67D1|\u67D3-\u67D4|\u67D8|\u67DA|" & _
                "\u67DD-\u67DE|\u67E2|\u67E4|\u67E7|\u67E9|\u67EC|\u67EE-\u67EF|\u67F1|\u67F3-\u67F5|\u67FB|" & _
                "\u67FE-\u67FF|\u6802-\u6804|\u6813|\u6816-\u6817|\u681E|\u6821-\u6822|\u6829-\u682B|\u6832|\u6834|\u6838-\u6839|" & _
                "\u683C-\u683D|\u6840-\u6843|\u6846|\u6848|\u684D-\u684E|\u6850-\u6851|\u6853-\u6854|\u6859|\u685C-\u685D|\u685F|" & _
                "\u6863|\u6867|\u6874|\u6876-\u6877|\u687E-\u687F|\u6881|\u6883|\u6885|\u688D|\u688F|" & _
                "\u6893-\u6894|\u6897|\u689B|\u689D|\u689F-\u68A0|\u68A2|\u68A6-\u68A8|\u68AD|\u68AF-\u68B1|\u68B3|" & _
                "\u68B5-\u68B6|\u68B9-\u68BA|\u68BC|\u68C4|\u68C6|\u68C9-\u68CB|\u68CD|\u68D2|\u68D4-\u68D5|\u68D7-\u68D8|" & _
                "\u68DA|\u68DF-\u68E1|\u68E3|\u68E7|\u68EE-\u68EF|\u68F2|\u68F9-\u68FA|\u6900-\u6901|\u6904-\u6905|\u6908|" & _
                "\u690B-\u690F|\u6912|\u6919-\u691C|\u6921-\u6923|\u6925-\u6926|\u6928|\u692A|\u6930|\u6934|\u6936|" & _
                "\u6939|\u693D|\u693F|\u694A|\u6953-\u6955|\u6959-\u695A|\u695C-\u695E|\u6960-\u6962|\u696A-\u696B|\u696D-\u696F|" & _
                "\u6973-\u6975|\u6977-\u6979|\u697C-\u697E|\u6981-\u6982|\u698A|\u698E|\u6991|\u6994-\u6995|\u699B-\u699C|\u69A0|" & _
                "\u69A7|\u69AE|\u69B1-\u69B2|\u69B4|\u69BB|\u69BE-\u69BF|\u69C1|\u69C3|\u69C7|\u69CA-\u69CE|" & _
                "\u69D0|\u69D3|\u69D8-\u69D9|\u69DD-\u69DE|\u69E7-\u69E8|\u69EB|\u69ED|\u69F2|\u69F9|\u69FB|" & _
                "\u69FD|\u69FF|\u6A02|\u6A05|\u6A0A-\u6A0C|\u6A12-\u6A14|\u6A17|\u6A19|\u6A1B|\u6A1E-\u6A1F|" & _
                "\u6A21-\u6A23|\u6A29-\u6A2B|\u6A2E|\u6A35-\u6A36|\u6A38-\u6A3A|\u6A3D|\u6A44|\u6A47-\u6A48|\u6A4B|\u6A58-\u6A59|" & _
                "\u6A5F|\u6A61-\u6A62|\u6A66|\u6A72|\u6A78|\u6A7F-\u6A80|\u6A84|\u6A8D-\u6A8E|\u6A90|\u6A97|" & _
                "\u6A9C|\u6AA0|\u6AA2-\u6AA3|\u6AAA|\u6AAC|\u6AAE|\u6AB3|\u6AB8|\u6ABB|\u6AC1-\u6AC3|" & _
                "\u6AD1|\u6AD3|\u6ADA-\u6ADB|\u6ADE-\u6ADF|\u6AE8|\u6AEA|\u6AFA-\u6AFB|\u6B04-\u6B05|\u6B0A|\u6B12|" & _
                "\u6B16|\u6B1D|\u6B1F-\u6B21|\u6B23|\u6B27|\u6B32|\u6B37-\u6B3A|\u6B3D-\u6B3E|\u6B43|\u6B47|" & _
                "\u6B49|\u6B4C|\u6B4E|\u6B50|\u6B53-\u6B54|\u6B59|\u6B5B|\u6B5F|\u6B61-\u6B64|\u6B66|" & _
                "\u6B69-\u6B6A|\u6B6F|\u6B73-\u6B74|\u6B78-\u6B79|\u6B7B|\u6B7F-\u6B80|\u6B83-\u6B84|\u6B86|\u6B89-\u6B8B|\u6B8D|" & _
                "\u6B95-\u6B96|\u6B98|\u6B9E|\u6BA4|\u6BAA-\u6BAB|\u6BAF|\u6BB1-\u6BB5|\u6BB7|\u6BBA-\u6BBC|\u6BBF-\u6BC0|" & _
                "\u6BC5-\u6BC6|\u6BCB|\u6BCD-\u6BCE|\u6BD2-\u6BD4|\u6BD8|\u6BDB|\u6BDF|\u6BEB-\u6BEC|\u6BEF|\u6BF3|" & _
                "\u6C08|\u6C0F|\u6C11|\u6C13-\u6C14|\u6C17|\u6C1B|\u6C23-\u6C24|\u6C34|\u6C37-\u6C38|\u6C3E|" & _
                "\u6C40-\u6C42|\u6C4E|\u6C50|\u6C55|\u6C57|\u6C5A|\u6C5D-\u6C60|\u6C62|\u6C68|\u6C6A|" & _
                "\u6C70|\u6C72-\u6C73|\u6C7A|\u6C7D-\u6C7E|\u6C81-\u6C83|\u6C88|\u6C8C-\u6C8D|\u6C90|\u6C92-\u6C93|\u6C96|" & _
                "\u6C99-\u6C9B|\u6CA1-\u6CA2|\u6CAB|\u6CAE|\u6CB1|\u6CB3|\u6CB8-\u6CBF|\u6CC1|\u6CC4-\u6CC5|\u6CC9-\u6CCA|" & _
                "\u6CCC|\u6CD3|\u6CD5|\u6CD7|\u6CD9|\u6CDB|\u6CDD|\u6CE1-\u6CE3|\u6CE5|\u6CE8|" & _
                "\u6CEA|\u6CEF-\u6CF1|\u6CF3|\u6D0B-\u6D0C|\u6D12|\u6D17|\u6D19|\u6D1B|\u6D1E-\u6D1F|\u6D25|" & _
                "\u6D29-\u6D2B|\u6D32-\u6D33|\u6D35-\u6D36|\u6D38|\u6D3B|\u6D3D-\u6D3E|\u6D41|\u6D44-\u6D45|\u6D59-\u6D5A|\u6D5C|" & _
                "\u6D63-\u6D64|\u6D66|\u6D69-\u6D6A|\u6D6C|\u6D6E|\u6D74|\u6D77-\u6D79|\u6D85|\u6D88|\u6D8C|" & _
                "\u6D8E|\u6D93|\u6D95|\u6D99|\u6D9B-\u6D9C|\u6DAF|\u6DB2|\u6DB5|\u6DB8|\u6DBC|" & _
                "\u6DC0|\u6DC5-\u6DC7|\u6DCB-\u6DCC|\u6DD1-\u6DD2|\u6DD5|\u6DD8-\u6DD9|\u6DDE|\u6DE1|\u6DE4|\u6DE6|" & _
                "\u6DE8|\u6DEA-\u6DEC|\u6DEE|\u6DF1|\u6DF3|\u6DF5|\u6DF7|\u6DF9-\u6DFB|\u6E05|\u6E07-\u6E0B|" & _
                "\u6E13|\u6E15|\u6E19-\u6E1B|\u6E1D|\u6E1F-\u6E21|\u6E23-\u6E26|\u6E29|\u6E2B-\u6E2F|\u6E38|\u6E3A|" & _
                "\u6E3E|\u6E43|\u6E4A|\u6E4D-\u6E4E|\u6E56|\u6E58|\u6E5B|\u6E5F|\u6E67|\u6E6B|" & _
                "\u6E6E-\u6E6F|\u6E72|\u6E76|\u6E7E-\u6E80|\u6E82|\u6E8C|\u6E8F-\u6E90|\u6E96|\u6E98|\u6E9C-\u6E9D|" & _
                "\u6E9F|\u6EA2|\u6EA5|\u6EAA|\u6EAF|\u6EB2|\u6EB6-\u6EB7|\u6EBA|\u6EBD|\u6EC2|" & _
                "\u6EC4-\u6EC5|\u6EC9|\u6ECB-\u6ECC|\u6ED1|\u6ED3-\u6ED5|\u6EDD-\u6EDE|\u6EEC|\u6EEF|\u6EF2|\u6EF4|" & _
                "\u6EF7-\u6EF8|\u6EFE-\u6EFF|\u6F01-\u6F02|\u6F06|\u6F09|\u6F0F|\u6F11|\u6F13-\u6F15|\u6F20|\u6F22-\u6F23|" & _
                "\u6F2B-\u6F2C|\u6F31-\u6F32|\u6F38|\u6F3E-\u6F3F|\u6F41|\u6F45|\u6F54|\u6F58|\u6F5B-\u6F5C|\u6F5F|" & _
                "\u6F64|\u6F66|\u6F6D-\u6F70|\u6F74|\u6F78|\u6F7A|\u6F7C|\u6F80-\u6F82|\u6F84|\u6F86|" & _
                "\u6F8E|\u6F91|\u6F97|\u6FA1|\u6FA3-\u6FA4|\u6FAA|\u6FB1|\u6FB3|\u6FB9|\u6FC0-\u6FC3|" & _
                "\u6FC6|\u6FD4-\u6FD5|\u6FD8|\u6FDB|\u6FDF-\u6FE1|\u6FE4|\u6FEB-\u6FEC|\u6FEE-\u6FEF|\u6FF1|\u6FF3|" & _
                "\u6FF6|\u6FFA|\u6FFE|\u7001|\u7009|\u700B|\u700F|\u7011|\u7015|\u7018|" & _
                "\u701A-\u701B|\u701D-\u701F|\u7026-\u7027|\u702C|\u7030|\u7032|\u703E|\u704C|\u7051|\u7058|" & _
                "\u7063|\u706B|\u706F-\u7070|\u7078|\u707C-\u707D|\u7089-\u708A|\u708E|\u7092|\u7099|\u70AC-\u70AF|" & _
                "\u70B3|\u70B8-\u70BA|\u70C8|\u70CB|\u70CF|\u70D9|\u70DD|\u70DF|\u70F1|\u70F9|" & _
                "\u70FD|\u7109|\u7114|\u7119-\u711A|\u711C|\u7121|\u7126|\u7136|\u713C|\u7149|" & _
                "\u714C|\u714E|\u7155-\u7156|\u7159|\u7162|\u7164-\u7167|\u7169|\u716C|\u716E|\u717D|" & _
                "\u7184|\u7188|\u718A|\u718F|\u7194-\u7195|\u719F|\u71A8|\u71AC|\u71B1|\u71B9|" & _
                "\u71BE|\u71C3|\u71C8-\u71C9|\u71CE|\u71D0|\u71D2|\u71D4-\u71D5|\u71D7|\u71DF-\u71E0|\u71E5-\u71E7|" & _
                "\u71EC-\u71EE|\u71F5|\u71F9|\u71FB-\u71FC|\u71FF|\u7206|\u720D|\u7210|\u721B|\u7228|" & _
                "\u722A|\u722C-\u722D|\u7230|\u7232|\u7235-\u7236|\u723A-\u7240|\u7246-\u7248|\u724B-\u724C|\u7252|\u7258-\u7259|" & _
                "\u725B|\u725D|\u725F|\u7261-\u7262|\u7267|\u7269|\u7272|\u7274|\u7279|\u727D-\u727E|" & _
                "\u7280-\u7282|\u7287|\u7292|\u7296|\u72A0|\u72A2|\u72A7|\u72AC|\u72AF|\u72B2|" & _
                "\u72B6|\u72B9|\u72C2-\u72C4|\u72C6|\u72CE|\u72D0|\u72D2|\u72D7|\u72D9|\u72DB|" & _
                "\u72E0-\u72E2|\u72E9|\u72EC-\u72ED|\u72F7-\u72F9|\u72FC-\u72FD|\u730A|\u7316-\u7317|\u731B-\u731D|\u731F|\u7325|" & _
                "\u7329-\u732B|\u732E-\u732F|\u7334|\u7336-\u7337|\u733E-\u733F|\u7344-\u7345|\u734E-\u734F|\u7357|\u7363|\u7368|" & _
                "\u736A|\u7370|\u7372|\u7375|\u7378|\u737A-\u737B|\u7384|\u7387|\u7389|\u738B|" & _
                "\u7396|\u73A9|\u73B2-\u73B3|\u73BB|\u73C0|\u73C2|\u73C8|\u73CA|\u73CD-\u73CE|\u73DE|" & _
                "\u73E0|\u73E5|\u73EA|\u73ED-\u73EE|\u73F1|\u73F8|\u73FE|\u7403|\u7405-\u7406|\u7409|" & _
                "\u7422|\u7425|\u7432-\u7436|\u743A|\u743F|\u7441|\u7455|\u7459-\u745C|\u745E-\u7460|\u7463-\u7464|" & _
                "\u7469-\u746A|\u746F-\u7470|\u7473|\u7476|\u747E|\u7483|\u748B|\u749E|\u74A2|\u74A7|" & _
                "\u74B0|\u74BD|\u74CA|\u74CF|\u74D4|\u74DC|\u74E0|\u74E2-\u74E3|\u74E6-\u74E7|\u74E9|" & _
                "\u74EE|\u74F0-\u74F2|\u74F6-\u74F8|\u7503-\u7505|\u750C-\u750E|\u7511|\u7513|\u7515|\u7518|\u751A|" & _
                "\u751C|\u751E-\u751F|\u7523|\u7525-\u7526|\u7528|\u752B-\u752C|\u7530-\u7533|\u7537-\u7538|\u753A-\u753C|\u7544|" & _
                "\u7546|\u7549-\u754D|\u754F|\u7551|\u7554|\u7559-\u755D|\u7560|\u7562|\u7564-\u7567|\u7569-\u756B|" & _
                "\u756D|\u7570|\u7573-\u7574|\u7576-\u7578|\u757F|\u7582|\u7586-\u7587|\u7589-\u758B|\u758E-\u758F|\u7591|" & _
                "\u7594|\u759A|\u759D|\u75A3|\u75A5|\u75AB|\u75B1-\u75B3|\u75B5|\u75B8-\u75B9|\u75BC-\u75BE|" & _
                "\u75C2-\u75C3|\u75C5|\u75C7|\u75CA|\u75CD|\u75D2|\u75D4-\u75D5|\u75D8-\u75D9|\u75DB|\u75DE|" & _
                "\u75E2-\u75E3|\u75E9|\u75F0|\u75F2-\u75F4|\u75FA|\u75FC|\u75FE-\u75FF|\u7601|\u7609|\u760B|" & _
                "\u760D|\u761F-\u7622|\u7624|\u7627|\u7630|\u7634|\u763B|\u7642|\u7646-\u7648|\u764C|" & _
                "\u7652|\u7656|\u7658|\u765C|\u7661-\u7662|\u7667-\u766A|\u766C|\u7670|\u7672|\u7676|" & _
                "\u7678|\u767A-\u767E|\u7680|\u7683-\u7684|\u7686-\u7688|\u768B|\u768E|\u7690|\u7693|\u7696|" & _
                "\u7699-\u769A|\u76AE|\u76B0|\u76B4|\u76B7-\u76BA|\u76BF|\u76C2-\u76C3|\u76C6|\u76C8|\u76CA|" & _
                "\u76CD|\u76D2|\u76D6-\u76D7|\u76DB-\u76DC|\u76DE-\u76DF|\u76E1|\u76E3-\u76E5|\u76E7|\u76EA|\u76EE|" & _
                "\u76F2|\u76F4|\u76F8|\u76FB|\u76FE|\u7701|\u7704|\u7707-\u7709|\u770B-\u770C|\u771B|" & _
                "\u771E-\u7720|\u7724-\u7726|\u7729|\u7737-\u7738|\u773A|\u773C|\u7740|\u7747|\u775A-\u775B|\u7761|" & _
                "\u7763|\u7765-\u7766|\u7768|\u776B|\u7779|\u777E-\u777F|\u778B|\u778E|\u7791|\u779E|" & _
                "\u77A0|\u77A5|\u77AC-\u77AD|\u77B0|\u77B3|\u77B6|\u77B9|\u77BB-\u77BD|\u77BF|\u77C7|" & _
                "\u77CD|\u77D7|\u77DA-\u77DC|\u77E2-\u77E3|\u77E5|\u77E7|\u77E9|\u77ED-\u77EF|\u77F3|\u77FC|" & _
                "\u7802|\u780C|\u7812|\u7814-\u7815|\u7820|\u7825-\u7827|\u7832|\u7834|\u783A|\u783F|" & _
                "\u7845|\u785D|\u786B-\u786C|\u786F|\u7872|\u7874|\u787C|\u7881|\u7886-\u7887|\u788C-\u788E|" & _
                "\u7891|\u7893|\u7895|\u7897|\u789A|\u78A3|\u78A7|\u78A9-\u78AA|\u78AF|\u78B5|" & _
                "\u78BA|\u78BC|\u78BE|\u78C1|\u78C5-\u78C6|\u78CA-\u78CB|\u78D0-\u78D1|\u78D4|\u78DA|\u78E7-\u78E8|" & _
                "\u78EC|\u78EF|\u78F4|\u78FD|\u7901|\u7907|\u790E|\u7911-\u7912|\u7919|\u7926|" & _
                "\u792A-\u792C|\u793A|\u793C|\u793E|\u7940-\u7941|\u7947-\u7949|\u7950|\u7953|\u7955-\u7957|\u795A|" & _
                "\u795D-\u7960|\u7962|\u7965|\u7968|\u796D|\u7977|\u797A|\u797F-\u7981|\u7984-\u7985|\u798A|" & _
                "\u798D-\u798F|\u799D|\u79A6-\u79A7|\u79AA|\u79AE|\u79B0|\u79B3|\u79B9-\u79BA|\u79BD-\u79C1|\u79C9|" & _
                "\u79CB|\u79D1-\u79D2|\u79D5|\u79D8|\u79DF|\u79E1|\u79E3-\u79E4|\u79E6-\u79E7|\u79E9|\u79EC|" & _
                "\u79F0|\u79FB|\u7A00|\u7A08|\u7A0B|\u7A0D-\u7A0E|\u7A14|\u7A17-\u7A1A|\u7A1C|\u7A1F-\u7A20|" & _
                "\u7A2E|\u7A31-\u7A32|\u7A37|\u7A3B-\u7A40|\u7A42-\u7A43|\u7A46|\u7A49|\u7A4D-\u7A50|\u7A57|\u7A61-\u7A63|" & _
                "\u7A69|\u7A6B|\u7A70|\u7A74|\u7A76|\u7A79-\u7A7A|\u7A7D|\u7A7F|\u7A81|\u7A83-\u7A84|" & _
                "\u7A88|\u7A92-\u7A93|\u7A95-\u7A98|\u7A9F|\u7AA9-\u7AAA|\u7AAE-\u7AB0|\u7AB6|\u7ABA|\u7ABF|\u7AC3-\u7AC5|" & _
                "\u7AC7-\u7AC8|\u7ACA-\u7ACB|\u7ACD|\u7ACF|\u7AD2-\u7AD3|\u7AD5|\u7AD9-\u7ADA|\u7ADC-\u7ADD|\u7ADF-\u7AE3|\u7AE5-\u7AE6|" & _
                "\u7AEA|\u7AED|\u7AEF-\u7AF0|\u7AF6|\u7AF8-\u7AFA|\u7AFF|\u7B02|\u7B04|\u7B06|\u7B08|" & _
                "\u7B0A-\u7B0B|\u7B0F|\u7B11|\u7B18-\u7B19|\u7B1B|\u7B1E|\u7B20|\u7B25-\u7B26|\u7B28|\u7B2C|" & _
                "\u7B33|\u7B35-\u7B36|\u7B39|\u7B45-\u7B46|\u7B48-\u7B49|\u7B4B-\u7B4D|\u7B4F-\u7B52|\u7B54|\u7B56|\u7B5D|" & _
                "\u7B65|\u7B67|\u7B6C|\u7B6E|\u7B70-\u7B71|\u7B74-\u7B75|\u7B7A|\u7B86-\u7B87|\u7B8B|\u7B8D|" & _
                "\u7B8F|\u7B92|\u7B94-\u7B95|\u7B97-\u7B9A|\u7B9C-\u7B9D|\u7B9F|\u7BA1|\u7BAA|\u7BAD|\u7BB1|" & _
                "\u7BB4|\u7BB8|\u7BC0-\u7BC1|\u7BC4|\u7BC6-\u7BC7|\u7BC9|\u7BCB-\u7BCC|\u7BCF|\u7BDD|\u7BE0|" & _
                "\u7BE4-\u7BE6|\u7BE9|\u7BED|\u7BF3|\u7BF6-\u7BF7|\u7C00|\u7C07|\u7C0D|\u7C11-\u7C14|\u7C17|" & _
                "\u7C1F|\u7C21|\u7C23|\u7C27|\u7C2A-\u7C2B|\u7C37-\u7C38|\u7C3D-\u7C40|\u7C43|\u7C4C-\u7C4D|\u7C4F-\u7C50|" & _
                "\u7C54|\u7C56|\u7C58|\u7C5F-\u7C60|\u7C64-\u7C65|\u7C6C|\u7C73|\u7C75|\u7C7E|\u7C81-\u7C83|" & _
                "\u7C89|\u7C8B|\u7C8D|\u7C90|\u7C92|\u7C95|\u7C97-\u7C98|\u7C9B|\u7C9F|\u7CA1-\u7CA2|" & _
                "\u7CA4-\u7CA5|\u7CA7-\u7CA8|\u7CAB|\u7CAD-\u7CAE|\u7CB1-\u7CB3|\u7CB9|\u7CBD-\u7CBE|\u7CC0|\u7CC2|\u7CC5|" & _
                "\u7CCA|\u7CCE|\u7CD2|\u7CD6|\u7CD8|\u7CDC|\u7CDE-\u7CE0|\u7CE2|\u7CE7|\u7CEF|" & _
                "\u7CF2|\u7CF4|\u7CF6|\u7CF8|\u7CFA-\u7CFB|\u7CFE|\u7D00|\u7D02|\u7D04-\u7D06|\u7D0A-\u7D0B|" & _
                "\u7D0D|\u7D10|\u7D14-\u7D15|\u7D17-\u7D1C|\u7D20-\u7D22|\u7D2B-\u7D2C|\u7D2E-\u7D30|\u7D32-\u7D33|\u7D35|\u7D39-\u7D3A|" & _
                "\u7D3F|\u7D42-\u7D46|\u7D4B-\u7D4C|\u7D4E-\u7D50|\u7D56|\u7D5B|\u7D5E|\u7D61-\u7D63|\u7D66|\u7D68|" & _
                "\u7D6E|\u7D71-\u7D73|\u7D75-\u7D76|\u7D79|\u7D7D|\u7D89|\u7D8F|\u7D93|\u7D99-\u7D9C|\u7D9F|" & _
                "\u7DA2-\u7DA3|\u7DAB-\u7DB2|\u7DB4-\u7DB5|\u7DB8|\u7DBA-\u7DBB|\u7DBD-\u7DBF|\u7DC7|\u7DCA-\u7DCB|\u7DCF|\u7DD1-\u7DD2|" & _
                "\u7DD5|\u7DD8|\u7DDA|\u7DDC-\u7DDE|\u7DE0-\u7DE1|\u7DE4|\u7DE8-\u7DE9|\u7DEC|\u7DEF|\u7DF2|" & _
                "\u7DF4|\u7DFB|\u7E01|\u7E04-\u7E05|\u7E09-\u7E0B|\u7E12|\u7E1B|\u7E1E-\u7E1F|\u7E21-\u7E23|\u7E26|" & _
                "\u7E2B|\u7E2E|\u7E31-\u7E32|\u7E35|\u7E37|\u7E39-\u7E3B|\u7E3D-\u7E3E|\u7E41|\u7E43|\u7E46|" & _
                "\u7E4A-\u7E4B|\u7E4D|\u7E54-\u7E56|\u7E59-\u7E5A|\u7E5D-\u7E5E|\u7E66-\u7E67|\u7E69-\u7E6A|\u7E6D|\u7E70|\u7E79|" & _
                "\u7E7B-\u7E7D|\u7E7F|\u7E82-\u7E83|\u7E88-\u7E89|\u7E8C|\u7E8E-\u7E90|\u7E92-\u7E94|\u7E96|\u7E9B-\u7E9C|\u7F36|" & _
                "\u7F38|\u7F3A|\u7F45|\u7F4C-\u7F4E|\u7F50-\u7F51|\u7F54-\u7F55|\u7F58|\u7F5F-\u7F60|\u7F67-\u7F6B|\u7F6E|" & _
                "\u7F70|\u7F72|\u7F75|\u7F77-\u7F79|\u7F82-\u7F83|\u7F85-\u7F88|\u7F8A|\u7F8C|\u7F8E|\u7F94|" & _
                "\u7F9A|\u7F9D-\u7F9E|\u7FA3-\u7FA4|\u7FA8-\u7FA9|\u7FAE-\u7FAF|\u7FB2|\u7FB6|\u7FB8-\u7FB9|\u7FBD|\u7FC1|" & _
                "\u7FC5-\u7FC6|\u7FCA|\u7FCC|\u7FD2|\u7FD4-\u7FD5|\u7FE0-\u7FE1|\u7FE6|\u7FE9|\u7FEB|\u7FF0|" & _
                "\u7FF3|\u7FF9|\u7FFB-\u7FFC|\u8000-\u8001|\u8003-\u8006|\u800B-\u800C|\u8010|\u8012|\u8015|\u8017-\u8019|" & _
                "\u801C|\u8021|\u8028|\u8033|\u8036|\u803B|\u803D|\u803F|\u8046|\u804A|" & _
                "\u8052|\u8056|\u8058|\u805A|\u805E-\u805F|\u8061-\u8062|\u8068|\u806F-\u8070|\u8072-\u8074|\u8076-\u8077|" & _
                "\u8079|\u807D-\u807F|\u8084-\u8087|\u8089|\u808B-\u808C|\u8093|\u8096|\u8098|\u809A-\u809B|\u809D|" & _
                "\u80A1-\u80A2|\u80A5|\u80A9-\u80AA|\u80AC-\u80AD|\u80AF|\u80B1-\u80B2|\u80B4|\u80BA|\u80C3-\u80C4|\u80C6|" & _
                "\u80CC|\u80CE|\u80D6|\u80D9-\u80DB|\u80DD-\u80DE|\u80E1|\u80E4-\u80E5|\u80EF|\u80F1|\u80F4|" & _
                "\u80F8|\u80FC-\u80FD|\u8102|\u8105-\u810A|\u811A-\u811B|\u8123|\u8129|\u812F|\u8131|\u8133|" & _
                "\u8139|\u813E|\u8146|\u814B|\u814E|\u8150-\u8151|\u8153-\u8155|\u815F|\u8165-\u8166|\u816B|" & _
                "\u816E|\u8170-\u8171|\u8174|\u8178-\u817A|\u817F-\u8180|\u8182-\u8183|\u8188|\u818A|\u818F|\u8193|" & _
                "\u8195|\u819A|\u819C-\u819D|\u81A0|\u81A3-\u81A4|\u81A8-\u81A9|\u81B0|\u81B3|\u81B5|\u81B8|" & _
                "\u81BA|\u81BD-\u81C0|\u81C2|\u81C6|\u81C8-\u81C9|\u81CD|\u81D1|\u81D3|\u81D8-\u81DA|\u81DF-\u81E0|" & _
                "\u81E3|\u81E5|\u81E7-\u81E8|\u81EA|\u81ED|\u81F3-\u81F4|\u81FA-\u81FC|\u81FE|\u8201-\u8202|\u8205|" & _
                "\u8207-\u820A|\u820C-\u820E|\u8210|\u8212|\u8216-\u8218|\u821B-\u821C|\u821E-\u821F|\u8229-\u822C|\u822E|\u8233|" & _
                "\u8235-\u8239|\u8240|\u8247|\u8258-\u825A|\u825D|\u825F|\u8262|\u8264|\u8266|\u8268|" & _
                "\u826A-\u826B|\u826E-\u826F|\u8271-\u8272|\u8276-\u8278|\u827E|\u828B|\u828D|\u8292|\u8299|\u829D|" & _
                "\u829F|\u82A5-\u82A6|\u82AB-\u82AD|\u82AF|\u82B1|\u82B3|\u82B8-\u82B9|\u82BB|\u82BD|\u82C5|" & _
                "\u82D1-\u82D4|\u82D7|\u82D9|\u82DB-\u82DC|\u82DE-\u82DF|\u82E1|\u82E3|\u82E5-\u82E7|\u82EB|\u82F1|" & _
                "\u82F3-\u82F4|\u82F9-\u82FB|\u8302-\u8306|\u8309|\u830E|\u8316-\u8318|\u831C|\u8323|\u8328|\u832B|" & _
                "\u832F|\u8331-\u8332|\u8334-\u8336|\u8338-\u8339|\u8340|\u8345|\u8349-\u834A|\u834F-\u8350|\u8352|\u8358|" & _
                "\u8373|\u8375|\u8377|\u837B-\u837C|\u8385|\u8387|\u8389-\u838A|\u838E|\u8393|\u8396|" & _
                "\u839A|\u839E-\u83A0|\u83A2|\u83A8|\u83AA-\u83AB|\u83B1|\u83B5|\u83BD|\u83C1|\u83C5|" & _
                "\u83CA|\u83CC|\u83CE|\u83D3|\u83D6|\u83D8|\u83DC|\u83DF-\u83E0|\u83E9|\u83EB|" & _
                "\u83EF-\u83F2|\u83F4|\u83F7|\u83FB|\u83FD|\u8403-\u8404|\u8407|\u840B-\u840E|\u8413|\u8420|" & _
                "\u8422|\u8429-\u842A|\u842C|\u8431|\u8435|\u8438|\u843C-\u843D|\u8446|\u8449|\u844E|" & _
                "\u8457|\u845B|\u8461-\u8463|\u8466|\u8469|\u846B-\u846F|\u8471|\u8475|\u8477|\u8479-\u847A|" & _
                "\u8482|\u8484|\u848B|\u8490|\u8494|\u8499|\u849C|\u849F|\u84A1|\u84AD|" & _
                "\u84B2|\u84B8-\u84B9|\u84BB-\u84BC|\u84BF|\u84C1|\u84C4|\u84C6|\u84C9-\u84CB|\u84CD|\u84D0-\u84D1|" & _
                "\u84D6|\u84D9-\u84DA|\u84EC|\u84EE|\u84F4|\u84FC|\u84FF-\u8500|\u8506|\u8511|\u8513-\u8515|" & _
                "\u8517-\u8518|\u851A|\u851F|\u8521|\u8526|\u852C-\u852D|\u8535|\u853D|\u8540-\u8541|\u8543|" & _
                "\u8548-\u854B|\u854E|\u8555|\u8557-\u8558|\u855A|\u8563|\u8568-\u856A|\u856D|\u8577|\u857E|" & _
                "\u8580|\u8584|\u8587-\u8588|\u858A|\u8590-\u8591|\u8594|\u8597|\u8599|\u859B-\u859C|\u85A4|" & _
                "\u85A6|\u85A8-\u85AC|\u85AE-\u85AF|\u85B9-\u85BA|\u85C1|\u85C9|\u85CD|\u85CF-\u85D0|\u85D5|\u85DC-\u85DD|" & _
                "\u85E4-\u85E5|\u85E9-\u85EA|\u85F7|\u85F9-\u85FB|\u85FE|\u8602|\u8606-\u8607|\u860A-\u860B|\u8613|\u8616-\u8617|" & _
                "\u861A|\u8622|\u862D|\u862F-\u8630|\u863F|\u864D-\u864E|\u8650|\u8654-\u8655|\u865A|\u865C|" & _
                "\u865E-\u865F|\u8667|\u866B|\u8671|\u8679|\u867B|\u868A-\u868C|\u8693|\u8695|\u86A3-\u86A4|" & _
                "\u86A9-\u86AB|\u86AF-\u86B0|\u86B6|\u86C4|\u86C6-\u86C7|\u86C9|\u86CB|\u86CD-\u86CE|\u86D4|\u86D9|" & _
                "\u86DB|\u86DE-\u86DF|\u86E4|\u86E9|\u86EC-\u86EF|\u86F8-\u86F9|\u86FB|\u86FE|\u8700|\u8702-\u8703|" & _
                "\u8706|\u8708-\u870A|\u870D|\u8711-\u8712|\u8718|\u871A|\u871C|\u8725|\u8729|\u8734|" & _
                "\u8737|\u873B|\u873F|\u8749|\u874B-\u874C|\u874E|\u8753|\u8755|\u8757|\u8759|" & _
                "\u875F-\u8760|\u8763|\u8766|\u8768|\u876A|\u876E|\u8774|\u8776|\u8778|\u877F|" & _
                "\u8782|\u878D|\u879F|\u87A2|\u87AB|\u87AF|\u87B3|\u87BA-\u87BB|\u87BD|\u87C0|" & _
                "\u87C4|\u87C6-\u87C7|\u87CB|\u87D0|\u87D2|\u87E0|\u87EF|\u87F2|\u87F6-\u87F7|\u87F9|" & _
                "\u87FB|\u87FE|\u8805|\u880D-\u880F|\u8811|\u8815-\u8816|\u8821-\u8823|\u8827|\u8831|\u8836|" & _
                "\u8839|\u883B|\u8840|\u8842|\u8844|\u8846|\u884C-\u884D|\u8852-\u8853|\u8857|\u8859|" & _
                "\u885B|\u885D-\u885E|\u8861-\u8863|\u8868|\u886B|\u8870|\u8872|\u8875|\u8877|\u887D-\u887F|" & _
                "\u8881-\u8882|\u8888|\u888B|\u888D|\u8892|\u8896-\u8897|\u8899|\u889E|\u88A2|\u88A4|" & _
                "\u88AB|\u88AE|\u88B0-\u88B1|\u88B4-\u88B5|\u88B7|\u88BF|\u88C1-\u88C5|\u88CF|\u88D4-\u88D5|\u88D8-\u88D9|" & _
                "\u88DC-\u88DD|\u88DF|\u88E1|\u88E8|\u88F2-\u88F4|\u88F8-\u88F9|\u88FC-\u88FE|\u8902|\u8904|\u8907|" & _
                "\u890A|\u890C|\u8910|\u8912-\u8913|\u891D-\u891E|\u8925|\u892A-\u892B|\u8936|\u8938|\u893B|" & _
                "\u8941|\u8943-\u8944|\u894C-\u894D|\u8956|\u895E-\u8960|\u8964|\u8966|\u896A|\u896D|\u896F|" & _
                "\u8972|\u8974|\u8977|\u897E-\u897F|\u8981|\u8983|\u8986-\u8988|\u898A-\u898B|\u898F|\u8993|" & _
                "\u8996-\u8998|\u899A|\u89A1|\u89A6-\u89A7|\u89A9-\u89AA|\u89AC|\u89AF|\u89B2-\u89B3|\u89BA|\u89BD|" & _
                "\u89BF-\u89C0|\u89D2|\u89DA|\u89DC-\u89DD|\u89E3|\u89E6-\u89E7|\u89F4|\u89F8|\u8A00|\u8A02-\u8A03|" & _
                "\u8A08|\u8A0A|\u8A0C|\u8A0E|\u8A10|\u8A13|\u8A16-\u8A18|\u8A1B|\u8A1D|\u8A1F|" & _
                "\u8A23|\u8A25|\u8A2A|\u8A2D|\u8A31|\u8A33-\u8A34|\u8A36|\u8A3A-\u8A3C|\u8A41|\u8A46|" & _
                "\u8A48|\u8A50-\u8A52|\u8A54-\u8A55|\u8A5B|\u8A5E|\u8A60|\u8A62-\u8A63|\u8A66|\u8A69|\u8A6B-\u8A6E|" & _
                "\u8A70-\u8A73|\u8A7C|\u8A82|\u8A84-\u8A85|\u8A87|\u8A89|\u8A8C-\u8A8D|\u8A91|\u8A93|\u8A95|" & _
                "\u8A98|\u8A9A|\u8A9E|\u8AA0-\u8AA1|\u8AA3-\u8AA6|\u8AA8|\u8AAC-\u8AAD|\u8AB0|\u8AB2|\u8AB9|" & _
                "\u8ABC|\u8ABF|\u8AC2|\u8AC4|\u8AC7|\u8ACB-\u8ACD|\u8ACF|\u8AD2|\u8AD6|\u8ADA-\u8ADC|" & _
                "\u8ADE|\u8AE0-\u8AE2|\u8AE4|\u8AE6-\u8AE7|\u8AEB|\u8AED-\u8AEE|\u8AF1|\u8AF3|\u8AF7-\u8AF8|\u8AFA|" & _
                "\u8AFE|\u8B00-\u8B02|\u8B04|\u8B07|\u8B0C|\u8B0E|\u8B10|\u8B14|\u8B16-\u8B17|\u8B19-\u8B1B|" & _
                "\u8B1D|\u8B20-\u8B21|\u8B26|\u8B28|\u8B2B-\u8B2C|\u8B33|\u8B39|\u8B3E|\u8B41|\u8B49|" & _
                "\u8B4C|\u8B4E-\u8B4F|\u8B56|\u8B58|\u8B5A-\u8B5C|\u8B5F|\u8B66|\u8B6B-\u8B6C|\u8B6F-\u8B72|\u8B74|" & _
                "\u8B77|\u8B7D|\u8B80|\u8B83|\u8B8A|\u8B8C|\u8B8E|\u8B90|\u8B92-\u8B93|\u8B96|" & _
                "\u8B99-\u8B9A|\u8C37|\u8C3A|\u8C3F|\u8C41|\u8C46|\u8C48|\u8C4A|\u8C4C|\u8C4E|" & _
                "\u8C50|\u8C55|\u8C5A|\u8C61-\u8C62|\u8C6A-\u8C6C|\u8C78-\u8C7A|\u8C7C|\u8C82|\u8C85|\u8C89-\u8C8A|" & _
                "\u8C8C-\u8C8E|\u8C94|\u8C98|\u8C9D-\u8C9E|\u8CA0-\u8CA2|\u8CA7-\u8CB0|\u8CB2-\u8CB4|\u8CB6-\u8CB8|\u8CBB-\u8CBD|\u8CBF-\u8CC4|" & _
                "\u8CC7-\u8CC8|\u8CCA|\u8CCD-\u8CCE|\u8CD1|\u8CD3|\u8CDA-\u8CDC|\u8CDE|\u8CE0|\u8CE2-\u8CE4|\u8CE6|" & _
                "\u8CEA|\u8CED|\u8CFA-\u8CFD|\u8D04-\u8D05|\u8D07-\u8D08|\u8D0A-\u8D0B|\u8D0D|\u8D0F-\u8D10|\u8D13-\u8D14|\u8D16|" & _
                "\u8D64|\u8D66-\u8D67|\u8D6B|\u8D6D|\u8D70-\u8D71|\u8D73-\u8D74|\u8D77|\u8D81|\u8D85|\u8D8A|" & _
                "\u8D99|\u8DA3|\u8DA8|\u8DB3|\u8DBA|\u8DBE|\u8DC2|\u8DCB-\u8DCC|\u8DCF|\u8DD6|" & _
                "\u8DDA-\u8DDB|\u8DDD|\u8DDF|\u8DE1|\u8DE3|\u8DE8|\u8DEA-\u8DEB|\u8DEF|\u8DF3|\u8DF5|" & _
                "\u8DFC|\u8DFF|\u8E08-\u8E0A|\u8E0F-\u8E10|\u8E1D-\u8E1F|\u8E2A|\u8E30|\u8E34-\u8E35|\u8E42|\u8E44|" & _
                "\u8E47-\u8E4A|\u8E4C|\u8E50|\u8E55|\u8E59|\u8E5F-\u8E60|\u8E63-\u8E64|\u8E72|\u8E74|\u8E76|" & _
                "\u8E7C|\u8E81|\u8E84-\u8E85|\u8E87|\u8E8A-\u8E8B|\u8E8D|\u8E91|\u8E93-\u8E94|\u8E99|\u8EA1|" & _
                "\u8EAA-\u8EAC|\u8EAF-\u8EB1|\u8EBE|\u8EC5-\u8EC6|\u8EC8|\u8ECA-\u8ECD|\u8ED2|\u8EDB|\u8EDF|\u8EE2-\u8EE3|" & _
                "\u8EEB|\u8EF8|\u8EFB-\u8EFE|\u8F03|\u8F05|\u8F09-\u8F0A|\u8F0C|\u8F12-\u8F15|\u8F19|\u8F1B-\u8F1D|" & _
                "\u8F1F|\u8F26|\u8F29-\u8F2A|\u8F2F|\u8F33|\u8F38-\u8F39|\u8F3B|\u8F3E-\u8F3F|\u8F42|\u8F44-\u8F46|" & _
                "\u8F49|\u8F4C-\u8F4E|\u8F57|\u8F5C|\u8F5F|\u8F61-\u8F64|\u8F9B-\u8F9C|\u8F9E-\u8F9F|\u8FA3|\u8FA7-\u8FA8|" & _
                "\u8FAD-\u8FB2|\u8FB7|\u8FBA-\u8FBC|\u8FBF|\u8FC2|\u8FC4-\u8FC5|\u8FCE|\u8FD1|\u8FD4|\u8FDA|" & _
                "\u8FE2|\u8FE5-\u8FE6|\u8FE9-\u8FEB|\u8FED|\u8FEF-\u8FF0|\u8FF4|\u8FF7-\u8FFA|\u8FFD|\u9000-\u9001|\u9003|" & _
                "\u9005-\u9006|\u900B|\u900D-\u9011|\u9013-\u9017|\u9019-\u901A|\u901D-\u9023|\u9027|\u902E|\u9031-\u9032|\u9035-\u9036|" & _
                "\u9038-\u9039|\u903C|\u903E|\u9041-\u9042|\u9045|\u9047|\u9049-\u904B|\u904D-\u9056|\u9058-\u9059|\u905C|" & _
                "\u905E|\u9060-\u9061|\u9063|\u9065|\u9068-\u9069|\u906D-\u906F|\u9072|\u9075-\u9078|\u907A|\u907C-\u907D|" & _
                "\u907F-\u9084|\u9087|\u9089-\u908A|\u908F|\u9091|\u90A3|\u90A6|\u90A8|\u90AA|\u90AF|" & _
                "\u90B1|\u90B5|\u90B8|\u90C1|\u90CA|\u90CE|\u90DB|\u90E1-\u90E2|\u90E4|\u90E8|" & _
                "\u90ED|\u90F5|\u90F7|\u90FD|\u9102|\u9112|\u9119|\u912D|\u9130|\u9132|" & _
                "\u9149-\u914E|\u9152|\u9154|\u9156|\u9158|\u9162-\u9163|\u9165|\u9169-\u916A|\u916C|\u9172-\u9173|" & _
                "\u9175|\u9177-\u9178|\u9182|\u9187|\u9189|\u918B|\u918D|\u9190|\u9192|\u9197|" & _
                "\u919C|\u91A2|\u91A4|\u91AA-\u91AB|\u91AF|\u91B4-\u91B5|\u91B8|\u91BA|\u91C0-\u91C1|\u91C6-\u91C9|" & _
                "\u91CB-\u91D1|\u91D6|\u91D8|\u91DB-\u91DD|\u91DF|\u91E1|\u91E3|\u91E6-\u91E7|\u91F5-\u91F6|\u91FC|" & _
                "\u91FF|\u920D-\u920E|\u9211|\u9214-\u9215|\u921E|\u9229|\u922C|\u9234|\u9237|\u923F|" & _
                "\u9244-\u9245|\u9248-\u9249|\u924B|\u9250|\u9257|\u925A-\u925B|\u925E|\u9262|\u9264|\u9266|" & _
                "\u9271|\u927E|\u9280|\u9283|\u9285|\u9291|\u9293|\u9295-\u9296|\u9298|\u929A-\u929C|" & _
                "\u92AD|\u92B7|\u92B9|\u92CF|\u92D2|\u92E4|\u92E9-\u92EA|\u92ED|\u92F2-\u92F3|\u92F8|" & _
                "\u92FA|\u92FC|\u9306|\u930F-\u9310|\u9318-\u931A|\u9320|\u9322-\u9323|\u9326|\u9328|\u932B-\u932C|" & _
                "\u932E-\u932F|\u9332|\u9335|\u933A-\u933B|\u9344|\u934B|\u934D|\u9354|\u9356|\u935B-\u935C|" & _
                "\u9360|\u936C|\u936E|\u9375|\u937C|\u937E|\u938C|\u9394|\u9396-\u9397|\u939A|" & _
                "\u93A7|\u93AC-\u93AE|\u93B0|\u93B9|\u93C3|\u93C8|\u93D0-\u93D1|\u93D6-\u93D8|\u93DD|\u93E1|" & _
                "\u93E4-\u93E5|\u93E8|\u9403|\u9407|\u9410|\u9413-\u9414|\u9418-\u941A|\u9421|\u942B|\u9435-\u9436|" & _
                "\u9438|\u943A|\u9441|\u9444|\u9451-\u9453|\u945A-\u945B|\u945E|\u9460|\u9462|\u946A|" & _
                "\u9470|\u9475|\u9477|\u947C-\u947F|\u9481|\u9577|\u9580|\u9582-\u9583|\u9587|\u9589-\u958B|" & _
                "\u958F|\u9591|\u9593-\u9594|\u9596|\u9598-\u9599|\u95A0|\u95A2-\u95A5|\u95A7-\u95A8|\u95AD|\u95B2|" & _
                "\u95B9|\u95BB-\u95BC|\u95BE|\u95C3|\u95C7|\u95CA|\u95CC-\u95CD|\u95D4-\u95D6|\u95D8|\u95DC|" & _
                "\u95E1-\u95E2|\u95E5|\u961C|\u9621|\u9628|\u962A|\u962E-\u962F|\u9632|\u963B|\u963F-\u9640|" & _
                "\u9642|\u9644|\u964B-\u964D|\u964F-\u9650|\u965B-\u965F|\u9662-\u9666|\u966A|\u966C|\u9670|\u9672-\u9673|" & _
                "\u9675-\u9678|\u967A|\u967D|\u9685-\u9686|\u9688|\u968A-\u968B|\u968D-\u968F|\u9694-\u9695|\u9697-\u9699|\u969B-\u969C|" & _
                "\u96A0|\u96A3|\u96A7-\u96A8|\u96AA|\u96B0-\u96B2|\u96B4|\u96B6-\u96B9|\u96BB-\u96BC|\u96C0-\u96C1|\u96C4-\u96C7|" & _
                "\u96C9|\u96CB-\u96CE|\u96D1|\u96D5-\u96D6|\u96D9|\u96DB-\u96DC|\u96E2-\u96E3|\u96E8|\u96EA-\u96EB|\u96F0|" & _
                "\u96F2|\u96F6-\u96F7|\u96F9|\u96FB|\u9700|\u9704|\u9706-\u9708|\u970A|\u970D-\u970F|\u9711|" & _
                "\u9713|\u9716|\u9719|\u971C|\u971E|\u9724|\u9727|\u972A|\u9730|\u9732|" & _
                "\u9738-\u9739|\u973D-\u973E|\u9742|\u9744|\u9746|\u9748-\u9749|\u9752|\u9756|\u9759|\u975C|" & _
                "\u975E|\u9760-\u9762|\u9764|\u9766|\u9768-\u9769|\u976B|\u976D|\u9771|\u9774|\u9779-\u977A|" & _
                "\u977C|\u9781|\u9784-\u9786|\u978B|\u978D|\u978F-\u9790|\u9798|\u979C|\u97A0|\u97A3|" & _
                "\u97A6|\u97A8|\u97AB|\u97AD|\u97B3-\u97B4|\u97C3|\u97C6|\u97C8|\u97CB|\u97D3|" & _
                "\u97DC|\u97ED-\u97EE|\u97F2-\u97F3|\u97F5-\u97F6|\u97FB|\u97FF|\u9801-\u9803|\u9805-\u9806|\u9808|\u980C|" & _
                "\u980F-\u9813|\u9817-\u9818|\u981A|\u9821|\u9824|\u982C-\u982D|\u9834|\u9837-\u9838|\u983B-\u983D|\u9846|" & _
                "\u984B-\u984F|\u9854-\u9855|\u9858|\u985B|\u985E|\u9867|\u986B|\u986F-\u9871|\u9873-\u9874|\u98A8|" & _
                "\u98AA|\u98AF|\u98B1|\u98B6|\u98C3-\u98C4|\u98C6|\u98DB-\u98DC|\u98DF|\u98E2|\u98E9|" & _
                "\u98EB|\u98ED-\u98EF|\u98F2|\u98F4|\u98FC-\u98FE|\u9903|\u9905|\u9909-\u990A|\u990C|\u9910|" & _
                "\u9912-\u9914|\u9918|\u991D-\u991E|\u9920-\u9921|\u9924|\u9928|\u992C|\u992E|\u993D-\u993E|\u9942|" & _
                "\u9945|\u9949|\u994B-\u994C|\u9950-\u9952|\u9955|\u9957|\u9996-\u9999|\u99A5|\u99A8|\u99AC-\u99AE|" & _
                "\u99B3-\u99B4|\u99BC|\u99C1|\u99C4-\u99C6|\u99C8|\u99D0-\u99D2|\u99D5|\u99D8|\u99DB|\u99DD|" & _
                "\u99DF|\u99E2|\u99ED-\u99EE|\u99F1-\u99F2|\u99F8|\u99FB|\u99FF|\u9A01|\u9A05|\u9A0E-\u9A0F|" & _
                "\u9A12-\u9A13|\u9A19|\u9A28|\u9A2B|\u9A30|\u9A37|\u9A3E|\u9A40|\u9A42-\u9A43|\u9A45|" & _
                "\u9A4D|\u9A55|\u9A57|\u9A5A-\u9A5B|\u9A5F|\u9A62|\u9A64-\u9A65|\u9A69-\u9A6B|\u9AA8|\u9AAD|" & _
                "\u9AB0|\u9AB8|\u9ABC|\u9AC0|\u9AC4|\u9ACF|\u9AD1|\u9AD3-\u9AD4|\u9AD8|\u9ADE-\u9ADF|" & _
                "\u9AE2-\u9AE3|\u9AE6|\u9AEA-\u9AEB|\u9AED-\u9AEF|\u9AF1|\u9AF4|\u9AF7|\u9AFB|\u9B06|\u9B18|" & _
                "\u9B1A|\u9B1F|\u9B22-\u9B23|\u9B25|\u9B27-\u9B2A|\u9B2E-\u9B2F|\u9B31-\u9B32|\u9B3B-\u9B3C|\u9B41-\u9B45|\u9B4D-\u9B4F|" & _
                "\u9B51|\u9B54|\u9B58|\u9B5A|\u9B6F|\u9B74|\u9B83|\u9B8E|\u9B91-\u9B93|\u9B96-\u9B97|" & _
                "\u9B9F-\u9BA0|\u9BA8|\u9BAA-\u9BAB|\u9BAD-\u9BAE|\u9BB4|\u9BB9|\u9BC0|\u9BC6|\u9BC9-\u9BCA|\u9BCF|" & _
                "\u9BD1-\u9BD2|\u9BD4|\u9BD6|\u9BDB|\u9BE1-\u9BE4|\u9BE8|\u9BF0-\u9BF2|\u9BF5|\u9C04|\u9C06|" & _
                "\u9C08-\u9C0A|\u9C0C-\u9C0D|\u9C10|\u9C12-\u9C15|\u9C1B|\u9C21|\u9C24-\u9C25|\u9C2D-\u9C30|\u9C32|\u9C39-\u9C3B|" & _
                "\u9C3E|\u9C46-\u9C48|\u9C52|\u9C57|\u9C5A|\u9C60|\u9C67|\u9C76|\u9C78|\u9CE5|" & _
                "\u9CE7|\u9CE9|\u9CEB-\u9CEC|\u9CF0|\u9CF3-\u9CF4|\u9CF6|\u9D03|\u9D06-\u9D09|\u9D0E|\u9D12|" & _
                "\u9D15|\u9D1B|\u9D1F|\u9D23|\u9D26|\u9D28|\u9D2A-\u9D2C|\u9D3B|\u9D3E-\u9D3F|\u9D41|" & _
                "\u9D44|\u9D46|\u9D48|\u9D50-\u9D51|\u9D59|\u9D5C-\u9D5E|\u9D60-\u9D61|\u9D64|\u9D6C|\u9D6F|" & _
                "\u9D72|\u9D7A|\u9D87|\u9D89|\u9D8F|\u9D9A|\u9DA4|\u9DA9|\u9DAB|\u9DAF|" & _
                "\u9DB2|\u9DB4|\u9DB8|\u9DBA-\u9DBB|\u9DC1-\u9DC2|\u9DC4|\u9DC6|\u9DCF|\u9DD3|\u9DD9|" & _
                "\u9DE6|\u9DED|\u9DEF|\u9DF2|\u9DF8-\u9DFA|\u9DFD|\u9E1A-\u9E1B|\u9E1E|\u9E75|\u9E78-\u9E79|" & _
                "\u9E7D|\u9E7F|\u9E81|\u9E88|\u9E8B-\u9E8C|\u9E91-\u9E93|\u9E95|\u9E97|\u9E9D|\u9E9F|" & _
                "\u9EA5-\u9EA6|\u9EA9-\u9EAA|\u9EAD|\u9EB8-\u9EBC|\u9EBE-\u9EBF|\u9EC4|\u9ECC-\u9ED0|\u9ED2|\u9ED4|\u9ED8-\u9ED9|" & _
                "\u9EDB-\u9EDE|\u9EE0|\u9EE5|\u9EE8|\u9EEF|\u9EF4|\u9EF6-\u9EF7|\u9EF9|\u9EFB-\u9EFD|\u9F07-\u9F08|" & _
                "\u9F0E|\u9F13|\u9F15|\u9F20-\u9F21|\u9F2C|\u9F3B|\u9F3E|\u9F4A-\u9F4B|\u9F4E-\u9F4F|\u9F52|" & _
                "\u9F54|\u9F5F-\u9F63|\u9F66-\u9F67|\u9F6A|\u9F6C|\u9F72|\u9F76-\u9F77|\u9F8D|\u9F95|\u9F9C-\u9F9D|" & _
                "\u9FA0|\uFF01|\uFF03-\uFF06|\uFF08-\uFF5E|\uFFE0-\uFFE1|\uFFE3|\uFFE5" & _
                "|\uE000|\uE001|\uE002|\uE003|\uE004|\uE005|\uE006|\uE023|\uE025|\uE026|\uE027|\uE028|\uE029|\uE02A|\uE02B|\uE02C|\uE02D|\uE02E|\uE02F|\uE03F" & _
                "]+$"



        Return GetPatternCode

    End Function


    ''' <summary>
    ''' 正規表現チェックを行うメソッドです。
    ''' </summary>
    ''' <param name="targetStr">チェック対象文字列</param>
    ''' <param name="pattern">正規表現パターン</param>
    ''' <returns>チェック結果<br/>
    ''' パターンに一致した場合：TRUE
    ''' パターンと一致しなかった場合：FALSE</returns>
    ''' <remarks>
    ''' <code>ChekReg("正規表現パターン", "チェック対象文字列")</code>
    ''' </remarks>
    Private Function ChekReg(ByVal targetStr As String, ByVal pattern As String) As Boolean

        ChekReg = False

        '正規表現パターンを指定してRegexクラスのインスタンスを作成
        If (Regex.IsMatch(targetStr, pattern)) Then
            ChekReg = True
        End If

        Return ChekReg

    End Function

    '以下、「Implements IDisposable」により自動生成されたコードです。

    Private disposedValue As Boolean = False        ' 重複する呼び出しを検出するには

    ' IDisposable
    ''' <summary>
    ''' 自動生成されたデストラクタです
    ''' </summary>
    ''' <param name="disposing">リソース開放許可</param>
    ''' <remarks>自動生成されたデストラクタです</remarks>
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                'エラーリストを破棄する
                errorMessageList = Nothing
            End If
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
    ''' <summary>
    ''' 自動生成されたデストラクタです。
    ''' </summary>
    ''' <remarks>破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。</remarks>
    Public Sub Dispose() Implements IDisposable.Dispose
        ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(ByVal disposing As Boolean) に記述します。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region


End Class