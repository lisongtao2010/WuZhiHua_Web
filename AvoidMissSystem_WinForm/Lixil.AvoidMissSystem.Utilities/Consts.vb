Public Class Consts

    Public Const DELETED As String = "1"
    Public Const UNDELETED As String = "0"

    Public Const SINKI As String = "0"
    Public Const KOUSIN As String = "1"

    '检查表检索条件保存用
    Public Const CHECKID_TEXT As String = "CHECKID"
    Public Const GOODSCD_TEXT As String = "GOODSCD"
    Public Const GOODSNAME_TEXT As String = "GOODSNAME"
    Public Const KINDCD_TEXT As String = "KINDCD"
    Public Const KINDNAME_TEXT As String = "KINDNAME"
    Public Const TOOLNO_TEXT As String = "TOOLNO"
    Public Const TOOLDISP_TEXT As String = "TOOLDISP"
    Public Const CLASSIFY_TEXT As String = "CLASSIFY"
    Public Const CLASSIFYDISP_TEXT As String = "CLASSIFYDISP"
    Public Const TYPECD_TEXT As String = "TYPECD"
    Public Const TYPENAME_TEXT As String = "TYPENAME"
    Public Const DEPARTMENT_TEXT As String = "DEPARTMENT"
    Public Const DEPARTMENTCD_TEXT As String = "DEPARTMENTCD"
    Public Const DEPARTMENTNAME_TEXT As String = "DEPARTMENTNAME"
    Public Const GOODSKIND_TEXT As String = "GOODSKIND"
    Public Const CHKPOSITION_TEXT As String = "CHKPOSITION"
    Public Const CHKITEM_TEXT As String = "CHKITEM"
    Public Const BMTYPE_TEXT As String = "BMTYPE"
    Public Const BMVALUE1_TEXT As String = "BMVALUE1"
    Public Const BMVALUE2_TEXT As String = "BMVALUE2"
    Public Const BMVALUE3_TEXT As String = "BMVALUE3"
    Public Const CHKWAY_TEXT As String = "CHKWAY"
    Public Const CHKTIMES_TEXT As String = "CHKTIMES"
    Public Const IMGID_TEXT As String = "IMGID"
    Public Const USER_TEXT As String = "USER"
    '治具表检索条件保存用
    Public Const TOOLSNO As String = "T_TOOLSNO"
    Public Const DEPARTMENT As String = "T_DEPARTMENT"
    Public Const DISTINGUISH As String = "T_DISTINGUISH"
    Public Const BARCODEFLG As String = "T_BARCODEFLG"
    Public Const BARCODE As String = "T_BARCODE"
    Public Const REMARKS As String = "T_REMARKS"
    '图片表检索条件保存用
    Public Const PDEPARTMENT As String = "P_DEPARTMENT"
    Public Const PREMARKS As String = "P_REMARKS"

    Public Class Flag
        ''' <summary>フラグOFF</summary>
        Public Const [OFF] As Integer = 0
        ''' <summary>フラグON</summary>
        Public Const [ON] As Integer = 1
    End Class

    Public Class DBErro
        ''' <summary>插入失败</summary>
        Public Const InserError As String = "DBE001"
        ''' <summary>更新失败</summary>
        Public Const UpdateError As String = "DBE002"
        ''' <summary>採番失败</summary>
        Public Const GetIndexError As String = "DBE003"
        ''' <summary>採番失败(到达最大值)</summary>
        Public Const GetIndexMaxError As String = "DBE004"
    End Class

    Public Class TYPEKBN
        ''' <summary>
        ''' 商品表
        ''' </summary>
        ''' <remarks></remarks>
        Public Const GOODS As String = "GO"
        ''' <summary>
        ''' 治具表
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TOOLS As String = "TO"
        ''' <summary>
        ''' 分类表
        ''' </summary>
        ''' <remarks></remarks>
        Public Const CLASSIFY As String = "CL"
        ''' <summary>
        ''' 类型表
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TYPE As String = "TY"
        ''' <summary>
        ''' 检查表(基础表)
        ''' </summary>
        ''' <remarks></remarks>
        Public Const CHECK As String = "CK"
        ''' <summary>
        ''' 图片表
        ''' </summary>
        ''' <remarks></remarks>
        Public Const PICTURE As String = "PI"

        ''' <summary>
        ''' 检查结果表
        ''' </summary>
        ''' <remarks></remarks>
        Public Const CHECK_RESULT As String = "CR"

        ''' <summary>
        ''' 检查结果详细表
        ''' </summary>
        ''' <remarks></remarks>
        Public Const RESULT_DETAIL As String = "RD"

        ''' <summary>
        ''' 日志表
        ''' </summary>
        ''' <remarks></remarks>
        Public Const LOG As String = "LO"
    End Class

    ''' <summary>
    ''' 权限类型
    ''' </summary>
    ''' <remarks></remarks>
    Public Class AccessType
        ''' <summary>
        ''' admin权限
        ''' </summary>
        ''' <remarks></remarks>
        Public Const ADMIN As String = "0"
        ''' <summary>
        ''' 机能权限
        ''' </summary>
        ''' <remarks></remarks>
        Public Const KINOU As String = "1"
        ''' <summary>
        ''' 部门权限
        ''' </summary>
        ''' <remarks></remarks>
        Public Const BUMON As String = "2"
    End Class

    ''' <summary>
    ''' 权限区分
    ''' </summary>
    ''' <remarks></remarks>
    Public Class AccessCd
        ''' <summary>
        ''' 管理员权限
        ''' </summary>
        ''' <remarks></remarks>
        Public Const MS_ADMIN As String = "000"
        ''' <summary>
        ''' 图片MS维护权限
        ''' </summary>
        ''' <remarks></remarks>
        Public Const MS_PICTRUE As String = "001"
        ''' <summary>
        ''' 治具MS维护权限
        ''' </summary>
        ''' <remarks></remarks>
        Public Const MS_TOOLS As String = "002"
        ''' <summary>
        ''' 基础MS维护权限
        ''' </summary>
        ''' <remarks></remarks>
        Public Const MS_BASIC As String = "003"
        ''' <summary>
        ''' 检查结果修正权限
        ''' </summary>
        ''' <remarks></remarks>
        Public Const MS_RESULTMODIFY As String = "004"
        ''' <summary>
        ''' 部门维护权限：一部
        ''' </summary>
        ''' <remarks></remarks>
        Public Const BM_FIRST As String = "001"
        ''' <summary>
        ''' 部门维护权限：二部
        ''' </summary>
        ''' <remarks></remarks>
        Public Const BM_SECOND As String = "002"
        ''' <summary>
        ''' 部门维护权限：三部
        ''' </summary>
        ''' <remarks></remarks>
        Public Const BM_THIRD As String = "003"
    End Class

    ''' <summary>
    ''' 页面跳转
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PAGE
        ''' <summary>
        ''' 图片MS维护页面
        ''' </summary>
        ''' <remarks></remarks>
        Public Const MS_PICTURE As String = "picture"
        ''' <summary>
        ''' 治具MS维护页面
        ''' </summary>
        ''' <remarks></remarks>
        Public Const MS_TOOLS As String = "msTools"
        ''' <summary>
        ''' 基础MS维护页面
        ''' </summary>
        ''' <remarks></remarks>
        Public Const MS_BASIC As String = "msBasic"
        ''' <summary>
        ''' 权限MS维护页面
        ''' </summary>
        ''' <remarks></remarks>
        Public Const MS_AUTHORITY As String = "msAuthority"
        ''' <summary>
        ''' 检查结果修正页面
        ''' </summary>
        ''' <remarks></remarks>
        Public Const MS_RESULTMODIFY As String = "chkResult"
        ''' <summary>
        ''' Main（检查）主页面
        ''' </summary>
        ''' <remarks></remarks>
        Public Const MAIN As String = "mainForm"
        ''' <summary>
        ''' MS维护登录页面
        ''' </summary>
        ''' <remarks></remarks>
        Public Const MS_LOGIN As String = "msLogin"
        ''' <summary>
        ''' MS维护主页面
        ''' </summary>
        ''' <remarks></remarks>
        Public Const MS_MAIN As String = "msMain"
        ''' <summary>
        ''' 检查主页面
        ''' </summary>
        ''' <remarks></remarks>
        Public Const CHK_MAIN As String = "chkMain"
        ''' <summary>
        ''' 日志查询
        ''' </summary>
        ''' <remarks></remarks>
        Public Const MS_LOG As String = "msLog"

        Public Const MS_BAOBIAO As String = "msBaobiao"
    End Class

    ''' <summary>
    ''' 检查结果
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CheckResult

        ''' <summary>
        ''' 结果初始状态
        ''' </summary>
        ''' <remarks></remarks>
        Public Const INIT As String = "INIT"
        ''' <summary>
        ''' 合格
        ''' </summary>
        ''' <remarks></remarks>
        Public Const OK As String = "OK"
        ''' <summary>
        ''' 合格但需要提示
        ''' </summary>
        ''' <remarks></remarks>
        Public Const OW As String = "OW"
        ''' <summary>
        ''' 不合格
        ''' </summary>
        ''' <remarks></remarks>
        Public Const NG As String = "NG"
        ''' <summary>
        ''' 微欠品
        ''' </summary>
        ''' <remarks></remarks>
        Public Const SD As String = "SD"
        ''' <summary>
        ''' 轻重中欠品
        ''' </summary>
        ''' <remarks></remarks>
        Public Const MD As String = "MD"
        ''' <summary>
        ''' 漏检
        ''' </summary>
        ''' <remarks></remarks>
        Public Const LC As String = "LC"
    End Class

    ''' <summary>
    ''' 基准类型
    ''' </summary>
    ''' <remarks></remarks>
    Public Class BenchmarkType
        ''' <summary>
        ''' 类型0(输入一个描述文本，只在系统的基准值里面表示文字。)
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TYPE00 As String = "00"

        ''' <summary>
        ''' 类型1(输入一个值，和基准值相同(=))
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TYPE01 As String = "01"

        ''' <summary>
        ''' 类型2(输入一个值，小于基准值
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TYPE02 As String = "02"

        ''' <summary>
        ''' 类型3(输入一个值，小于等于基准值)
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TYPE03 As String = "03"

        ''' <summary>
        ''' 类型4(输入一个值，大于基准值)
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TYPE04 As String = "04"

        ''' <summary>
        ''' 类型5(输入一个值，大于等于基准值)
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TYPE05 As String = "05"

        ''' <summary>
        ''' 类型6(输入一个值，小于基准1,大于基准2)
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TYPE06 As String = "06"

        ''' <summary>
        ''' 类型7
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TYPE07 As String = "07"

        ''' <summary>
        ''' 类型8
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TYPE08 As String = "08"

        ''' <summary>
        ''' 类型9
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TYPE09 As String = "09"

        ''' <summary>
        ''' 类型10
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TYPE10 As String = "10"

        ''' <summary>
        ''' 类型11
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TYPE11 As String = "11"

        ''' <summary>
        ''' 类型12
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TYPE12 As String = "12"

        ''' <summary>
        ''' 类型13
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TYPE13 As String = "13"

        ''' <summary>
        ''' 类型14
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TYPE14 As String = "14"

        ''' <summary>
        ''' 类型15
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TYPE15 As String = "15"

        ''' <summary>
        ''' 类型90
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TYPE90 As String = "90"

        Public Const TYPE15_1 As String = "15-1"
        Public Const TYPE16_1 As String = "16-1"
        Public Const TYPE17_1 As String = "17-1"
        Public Const TYPE18_1 As String = "18-1"
        Public Const TYPE19_1 As String = "19-1"
        Public Const TYPE20_1 As String = "20-1"
        Public Const TYPE15_2 As String = "15-2"
        Public Const TYPE16_2 As String = "16-2"
        Public Const TYPE17_2 As String = "17-2"
        Public Const TYPE18_2 As String = "18-2"
        Public Const TYPE19_2 As String = "19-2"
        Public Const TYPE20_2 As String = "20-2"



    End Class

    ''' <summary>
    ''' 检查状态（检查主页面用）
    ''' </summary>
    ''' <remarks></remarks>
    Public Class StateType

        ''' <summary>
        ''' 初始状态下
        ''' </summary>
        ''' <remarks></remarks>
        Public Const STATEINIT As String = "0"

        ''' <summary>
        ''' 接受商品code
        ''' </summary>
        ''' <remarks></remarks>
        Public Const STATE1 As String = "1"

        ''' <summary>
        ''' 接受商品作番
        ''' </summary>
        ''' <remarks></remarks>
        Public Const STATE2 As String = "2"

        ''' <summary>
        ''' 外观寸法检查中
        ''' </summary>
        ''' <remarks></remarks>
        Public Const STATE3 As String = "3"

        ''' <summary>
        ''' 治具检查中
        ''' </summary>
        ''' <remarks></remarks>
        Public Const STATE4 As String = "4"

        ''' <summary>
        ''' 接受检查员code
        ''' </summary>
        ''' <remarks></remarks>
        Public Const STATE5 As String = "5"

        ''' <summary>
        ''' 错误状态
        ''' </summary>
        ''' <remarks></remarks>
        Public Const STATEERROR As String = "ERROR"

        ''' <summary>
        ''' 不接受状态
        ''' </summary>
        ''' <remarks></remarks>
        Public Const NOACCEPT As String = "NOACCEPT"

    End Class

    ''' <summary>
    ''' 操作类型
    ''' </summary>
    ''' <remarks></remarks>
    Public Class OperateKind

        ''' <summary>
        ''' 插入操作
        ''' </summary>
        ''' <remarks></remarks>
        Public Const INSERT As String = "IN"

        ''' <summary>
        ''' 更新操作
        ''' </summary>
        ''' <remarks></remarks>
        Public Const UPDATE As String = "UP"

        ''' <summary>
        ''' 删除操作
        ''' </summary>
        ''' <remarks></remarks>
        Public Const DELETE As String = "DE"

        ''' <summary>
        ''' 批量导入操作
        ''' </summary>
        ''' <remarks></remarks>
        Public Const IMPORT As String = "IM"

    End Class
End Class
