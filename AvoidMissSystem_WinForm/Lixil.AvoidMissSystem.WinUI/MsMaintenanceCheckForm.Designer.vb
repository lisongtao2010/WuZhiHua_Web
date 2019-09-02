<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MsMaintenanceCheckForm
    Inherits AvoidMissSystem.WinUI.BaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnDelete = New System.Windows.Forms.Button
        Me.dtList = New System.Windows.Forms.DataGridView
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.goods_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.goods_cd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.goods_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.种类 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.kind_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tools_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tools_order = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.classify_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.classify_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.classify_order = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.type_cd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.type_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.department_cd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.department_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.kind = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.check_position = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.check_item = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.benchmark_type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.benchmark_value1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.benchmark_value2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.benchmark_value3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.check_way = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.check_times = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.picture_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.delete_flg = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tools_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grpSearch = New System.Windows.Forms.GroupBox
        Me.chkLDepartment = New Lixil.AvoidMissSystem.WinUI.Common.ColorCodedCheckedListBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.chkLType = New Lixil.AvoidMissSystem.WinUI.Common.ColorCodedCheckedListBox
        Me.chkLKind = New Lixil.AvoidMissSystem.WinUI.Common.ColorCodedCheckedListBox
        Me.txtSelBenchmarkType = New System.Windows.Forms.TextBox
        Me.txtSelChkWay = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtSelBMValue3 = New System.Windows.Forms.TextBox
        Me.txtSelBMValue2 = New System.Windows.Forms.TextBox
        Me.txtSelBMValue1 = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.txtSelChkProject = New System.Windows.Forms.TextBox
        Me.txtSelKind = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtSelChkPosition = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtSelGoodsName = New System.Windows.Forms.TextBox
        Me.txtSelImgId = New System.Windows.Forms.TextBox
        Me.txtSelClassify = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSelToolNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSelGoodsCd = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.lblTemplate = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblRowCount = New System.Windows.Forms.Label
        Me.lblTemplateDown = New System.Windows.Forms.LinkLabel
        Me.btnChoosePath = New System.Windows.Forms.Button
        Me.txtFilePath = New System.Windows.Forms.TextBox
        Me.btnExcute = New System.Windows.Forms.Button
        Me.rdbExport = New System.Windows.Forms.RadioButton
        Me.rdbImport = New System.Windows.Forms.RadioButton
        Me.btnBack = New System.Windows.Forms.Button
        Me.txtImgId = New System.Windows.Forms.TextBox
        Me.txtBenchmarkType = New System.Windows.Forms.TextBox
        Me.txtGoodsName = New System.Windows.Forms.TextBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.Label35 = New System.Windows.Forms.Label
        Me.txtToolDispNo = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.txtClassifyDispNo = New System.Windows.Forms.TextBox
        Me.drpEditDepartment = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.pbImg = New System.Windows.Forms.PictureBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtChkWay = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtEditGoodsCd = New System.Windows.Forms.TextBox
        Me.txtBenchmarkValue3 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtBenchmarkValue2 = New System.Windows.Forms.TextBox
        Me.drpEditKindCd = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.grpGoodsEdit = New System.Windows.Forms.GroupBox
        Me.txtChktimes = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtBenchmarkValue1 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtEditToolNo = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.drpEditType = New System.Windows.Forms.ComboBox
        Me.txtEditClassify = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtChkProject = New System.Windows.Forms.TextBox
        Me.txtKind = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtChkPosition = New System.Windows.Forms.TextBox
        Me.btnCsv = New System.Windows.Forms.Button
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSearch.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.pbImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGoodsEdit.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(766, -1)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(76, 28)
        Me.btnDelete.TabIndex = 44
        Me.btnDelete.Text = "删除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'dtList
        '
        Me.dtList.AllowUserToAddRows = False
        Me.dtList.AllowUserToDeleteRows = False
        Me.dtList.AllowUserToOrderColumns = True
        Me.dtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.goods_id, Me.goods_cd, Me.goods_name, Me.种类, Me.kind_name, Me.tools_no, Me.tools_order, Me.classify_id, Me.classify_name, Me.classify_order, Me.type_cd, Me.type_name, Me.department_cd, Me.department_name, Me.kind, Me.check_position, Me.check_item, Me.benchmark_type, Me.benchmark_value1, Me.benchmark_value2, Me.benchmark_value3, Me.check_way, Me.check_times, Me.picture_id, Me.delete_flg, Me.tools_id})
        Me.dtList.Location = New System.Drawing.Point(17, 398)
        Me.dtList.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dtList.Name = "dtList"
        Me.dtList.ReadOnly = True
        Me.dtList.RowTemplate.Height = 21
        Me.dtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtList.Size = New System.Drawing.Size(1174, 322)
        Me.dtList.TabIndex = 35
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        Me.id.Width = 40
        '
        'goods_id
        '
        Me.goods_id.DataPropertyName = "goods_id"
        Me.goods_id.HeaderText = "goods_id"
        Me.goods_id.Name = "goods_id"
        Me.goods_id.ReadOnly = True
        Me.goods_id.Visible = False
        Me.goods_id.Width = 75
        '
        'goods_cd
        '
        Me.goods_cd.DataPropertyName = "goods_cd"
        Me.goods_cd.HeaderText = "商品CD"
        Me.goods_cd.Name = "goods_cd"
        Me.goods_cd.ReadOnly = True
        Me.goods_cd.Width = 71
        '
        'goods_name
        '
        Me.goods_name.DataPropertyName = "goods_name"
        Me.goods_name.HeaderText = "商品名称"
        Me.goods_name.Name = "goods_name"
        Me.goods_name.ReadOnly = True
        Me.goods_name.Width = 80
        '
        '种类
        '
        Me.种类.DataPropertyName = "kind_cd"
        Me.种类.HeaderText = "种类id"
        Me.种类.Name = "种类"
        Me.种类.ReadOnly = True
        Me.种类.Visible = False
        Me.种类.Width = 64
        '
        'kind_name
        '
        Me.kind_name.DataPropertyName = "kind_name"
        Me.kind_name.HeaderText = "种类名称"
        Me.kind_name.Name = "kind_name"
        Me.kind_name.ReadOnly = True
        Me.kind_name.Width = 80
        '
        'tools_no
        '
        Me.tools_no.DataPropertyName = "tools_no"
        Me.tools_no.HeaderText = "治具编号"
        Me.tools_no.Name = "tools_no"
        Me.tools_no.ReadOnly = True
        Me.tools_no.Width = 80
        '
        'tools_order
        '
        Me.tools_order.DataPropertyName = "tools_order"
        Me.tools_order.HeaderText = "治具表示顺"
        Me.tools_order.Name = "tools_order"
        Me.tools_order.ReadOnly = True
        Me.tools_order.Width = 92
        '
        'classify_id
        '
        Me.classify_id.DataPropertyName = "classify_id"
        Me.classify_id.HeaderText = "分类id"
        Me.classify_id.Name = "classify_id"
        Me.classify_id.ReadOnly = True
        Me.classify_id.Visible = False
        Me.classify_id.Width = 64
        '
        'classify_name
        '
        Me.classify_name.DataPropertyName = "classify_name"
        Me.classify_name.HeaderText = "分类名称"
        Me.classify_name.Name = "classify_name"
        Me.classify_name.ReadOnly = True
        Me.classify_name.Width = 80
        '
        'classify_order
        '
        Me.classify_order.DataPropertyName = "classify_order"
        Me.classify_order.HeaderText = "分类表示顺"
        Me.classify_order.Name = "classify_order"
        Me.classify_order.ReadOnly = True
        Me.classify_order.Width = 92
        '
        'type_cd
        '
        Me.type_cd.DataPropertyName = "type_cd"
        Me.type_cd.HeaderText = "类型id"
        Me.type_cd.Name = "type_cd"
        Me.type_cd.ReadOnly = True
        Me.type_cd.Visible = False
        Me.type_cd.Width = 64
        '
        'type_name
        '
        Me.type_name.DataPropertyName = "type_name"
        Me.type_name.HeaderText = "类型名称"
        Me.type_name.Name = "type_name"
        Me.type_name.ReadOnly = True
        Me.type_name.Width = 80
        '
        'department_cd
        '
        Me.department_cd.DataPropertyName = "department_cd"
        Me.department_cd.HeaderText = "部门CD"
        Me.department_cd.Name = "department_cd"
        Me.department_cd.ReadOnly = True
        Me.department_cd.Visible = False
        Me.department_cd.Width = 71
        '
        'department_name
        '
        Me.department_name.DataPropertyName = "department_name"
        Me.department_name.HeaderText = "部门名称"
        Me.department_name.Name = "department_name"
        Me.department_name.ReadOnly = True
        Me.department_name.Width = 80
        '
        'kind
        '
        Me.kind.DataPropertyName = "kind"
        Me.kind.HeaderText = "类别 "
        Me.kind.Name = "kind"
        Me.kind.ReadOnly = True
        Me.kind.Width = 59
        '
        'check_position
        '
        Me.check_position.DataPropertyName = "check_position"
        Me.check_position.HeaderText = "检查位置"
        Me.check_position.Name = "check_position"
        Me.check_position.ReadOnly = True
        Me.check_position.Width = 80
        '
        'check_item
        '
        Me.check_item.DataPropertyName = "check_item"
        Me.check_item.HeaderText = "检查项目"
        Me.check_item.Name = "check_item"
        Me.check_item.ReadOnly = True
        Me.check_item.Width = 80
        '
        'benchmark_type
        '
        Me.benchmark_type.DataPropertyName = "benchmark_type"
        Me.benchmark_type.HeaderText = "基准类型"
        Me.benchmark_type.Name = "benchmark_type"
        Me.benchmark_type.ReadOnly = True
        Me.benchmark_type.Width = 80
        '
        'benchmark_value1
        '
        Me.benchmark_value1.DataPropertyName = "benchmark_value1"
        Me.benchmark_value1.HeaderText = "基准值1"
        Me.benchmark_value1.Name = "benchmark_value1"
        Me.benchmark_value1.ReadOnly = True
        Me.benchmark_value1.Width = 74
        '
        'benchmark_value2
        '
        Me.benchmark_value2.DataPropertyName = "benchmark_value2"
        Me.benchmark_value2.HeaderText = "基准值2"
        Me.benchmark_value2.Name = "benchmark_value2"
        Me.benchmark_value2.ReadOnly = True
        Me.benchmark_value2.Width = 74
        '
        'benchmark_value3
        '
        Me.benchmark_value3.DataPropertyName = "benchmark_value3"
        Me.benchmark_value3.HeaderText = "基准值3"
        Me.benchmark_value3.Name = "benchmark_value3"
        Me.benchmark_value3.ReadOnly = True
        Me.benchmark_value3.Width = 74
        '
        'check_way
        '
        Me.check_way.DataPropertyName = "check_way"
        Me.check_way.HeaderText = "检查方式"
        Me.check_way.Name = "check_way"
        Me.check_way.ReadOnly = True
        Me.check_way.Width = 80
        '
        'check_times
        '
        Me.check_times.DataPropertyName = "check_times"
        Me.check_times.HeaderText = "检查次数"
        Me.check_times.Name = "check_times"
        Me.check_times.ReadOnly = True
        '
        'picture_id
        '
        Me.picture_id.DataPropertyName = "picture_id"
        Me.picture_id.HeaderText = "图片ID"
        Me.picture_id.Name = "picture_id"
        Me.picture_id.ReadOnly = True
        Me.picture_id.Width = 67
        '
        'delete_flg
        '
        Me.delete_flg.DataPropertyName = "delete_flg"
        Me.delete_flg.HeaderText = "delete_flg"
        Me.delete_flg.Name = "delete_flg"
        Me.delete_flg.ReadOnly = True
        Me.delete_flg.Visible = False
        Me.delete_flg.Width = 78
        '
        'tools_id
        '
        Me.tools_id.DataPropertyName = "tools_id"
        Me.tools_id.HeaderText = "tools_id"
        Me.tools_id.Name = "tools_id"
        Me.tools_id.ReadOnly = True
        Me.tools_id.Visible = False
        Me.tools_id.Width = 68
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.chkLDepartment)
        Me.grpSearch.Controls.Add(Me.Label34)
        Me.grpSearch.Controls.Add(Me.chkLType)
        Me.grpSearch.Controls.Add(Me.chkLKind)
        Me.grpSearch.Controls.Add(Me.txtSelBenchmarkType)
        Me.grpSearch.Controls.Add(Me.txtSelChkWay)
        Me.grpSearch.Controls.Add(Me.Label25)
        Me.grpSearch.Controls.Add(Me.txtSelBMValue3)
        Me.grpSearch.Controls.Add(Me.txtSelBMValue2)
        Me.grpSearch.Controls.Add(Me.txtSelBMValue1)
        Me.grpSearch.Controls.Add(Me.Label26)
        Me.grpSearch.Controls.Add(Me.Label28)
        Me.grpSearch.Controls.Add(Me.Label29)
        Me.grpSearch.Controls.Add(Me.Label30)
        Me.grpSearch.Controls.Add(Me.Label31)
        Me.grpSearch.Controls.Add(Me.txtSelChkProject)
        Me.grpSearch.Controls.Add(Me.txtSelKind)
        Me.grpSearch.Controls.Add(Me.Label32)
        Me.grpSearch.Controls.Add(Me.Label33)
        Me.grpSearch.Controls.Add(Me.txtSelChkPosition)
        Me.grpSearch.Controls.Add(Me.Label24)
        Me.grpSearch.Controls.Add(Me.txtSelGoodsName)
        Me.grpSearch.Controls.Add(Me.txtSelImgId)
        Me.grpSearch.Controls.Add(Me.txtSelClassify)
        Me.grpSearch.Controls.Add(Me.Label20)
        Me.grpSearch.Controls.Add(Me.Label1)
        Me.grpSearch.Controls.Add(Me.txtSelToolNo)
        Me.grpSearch.Controls.Add(Me.Label2)
        Me.grpSearch.Controls.Add(Me.Label3)
        Me.grpSearch.Controls.Add(Me.txtSelGoodsCd)
        Me.grpSearch.Controls.Add(Me.Label4)
        Me.grpSearch.Controls.Add(Me.Label5)
        Me.grpSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.grpSearch.Location = New System.Drawing.Point(121, 24)
        Me.grpSearch.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.grpSearch.Size = New System.Drawing.Size(976, 186)
        Me.grpSearch.TabIndex = 18
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "检查项目查询"
        '
        'chkLDepartment
        '
        Me.chkLDepartment.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.chkLDepartment.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chkLDepartment.ColumnWidth = 75
        Me.chkLDepartment.FormattingEnabled = True
        Me.chkLDepartment.Location = New System.Drawing.Point(720, 96)
        Me.chkLDepartment.Name = "chkLDepartment"
        Me.chkLDepartment.Size = New System.Drawing.Size(98, 75)
        Me.chkLDepartment.TabIndex = 16
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft YaHei", 9.75!)
        Me.Label34.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label34.Location = New System.Drawing.Point(677, 92)
        Me.Label34.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(48, 19)
        Me.Label34.TabIndex = 45
        Me.Label34.Text = "部门："
        '
        'chkLType
        '
        Me.chkLType.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.chkLType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chkLType.ColumnWidth = 75
        Me.chkLType.FormattingEnabled = True
        Me.chkLType.Location = New System.Drawing.Point(877, 9)
        Me.chkLType.Name = "chkLType"
        Me.chkLType.Size = New System.Drawing.Size(90, 165)
        Me.chkLType.TabIndex = 15
        '
        'chkLKind
        '
        Me.chkLKind.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.chkLKind.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chkLKind.ColumnWidth = 110
        Me.chkLKind.FormattingEnabled = True
        Me.chkLKind.Location = New System.Drawing.Point(720, 11)
        Me.chkLKind.Name = "chkLKind"
        Me.chkLKind.Size = New System.Drawing.Size(98, 75)
        Me.chkLKind.TabIndex = 14
        '
        'txtSelBenchmarkType
        '
        Me.txtSelBenchmarkType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtSelBenchmarkType.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSelBenchmarkType.Location = New System.Drawing.Point(75, 119)
        Me.txtSelBenchmarkType.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtSelBenchmarkType.MaxLength = 2
        Me.txtSelBenchmarkType.Name = "txtSelBenchmarkType"
        Me.txtSelBenchmarkType.Size = New System.Drawing.Size(32, 20)
        Me.txtSelBenchmarkType.TabIndex = 8
        '
        'txtSelChkWay
        '
        Me.txtSelChkWay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtSelChkWay.Location = New System.Drawing.Point(75, 145)
        Me.txtSelChkWay.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtSelChkWay.MaxLength = 25
        Me.txtSelChkWay.Name = "txtSelChkWay"
        Me.txtSelChkWay.Size = New System.Drawing.Size(221, 20)
        Me.txtSelChkWay.TabIndex = 12
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label25.Location = New System.Drawing.Point(8, 148)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 13)
        Me.Label25.TabIndex = 58
        Me.Label25.Text = "检查方式："
        '
        'txtSelBMValue3
        '
        Me.txtSelBMValue3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtSelBMValue3.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSelBMValue3.Location = New System.Drawing.Point(552, 119)
        Me.txtSelBMValue3.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtSelBMValue3.MaxLength = 20
        Me.txtSelBMValue3.Name = "txtSelBMValue3"
        Me.txtSelBMValue3.Size = New System.Drawing.Size(118, 20)
        Me.txtSelBMValue3.TabIndex = 11
        '
        'txtSelBMValue2
        '
        Me.txtSelBMValue2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtSelBMValue2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSelBMValue2.Location = New System.Drawing.Point(367, 119)
        Me.txtSelBMValue2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtSelBMValue2.MaxLength = 20
        Me.txtSelBMValue2.Name = "txtSelBMValue2"
        Me.txtSelBMValue2.Size = New System.Drawing.Size(118, 20)
        Me.txtSelBMValue2.TabIndex = 10
        '
        'txtSelBMValue1
        '
        Me.txtSelBMValue1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtSelBMValue1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSelBMValue1.Location = New System.Drawing.Point(178, 120)
        Me.txtSelBMValue1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtSelBMValue1.MaxLength = 20
        Me.txtSelBMValue1.Name = "txtSelBMValue1"
        Me.txtSelBMValue1.Size = New System.Drawing.Size(118, 20)
        Me.txtSelBMValue1.TabIndex = 9
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label26.Location = New System.Drawing.Point(304, 124)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(55, 13)
        Me.Label26.TabIndex = 54
        Me.Label26.Text = "基准值2："
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label28.Location = New System.Drawing.Point(489, 122)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(55, 13)
        Me.Label28.TabIndex = 53
        Me.Label28.Text = "基准值3："
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label29.Location = New System.Drawing.Point(115, 122)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(55, 13)
        Me.Label29.TabIndex = 52
        Me.Label29.Text = "基准值1："
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label30.Location = New System.Drawing.Point(8, 122)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(61, 13)
        Me.Label30.TabIndex = 51
        Me.Label30.Text = "基准类型："
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label31.Location = New System.Drawing.Point(8, 70)
        Me.Label31.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(37, 13)
        Me.Label31.TabIndex = 45
        Me.Label31.Text = "类别："
        '
        'txtSelChkProject
        '
        Me.txtSelChkProject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtSelChkProject.Location = New System.Drawing.Point(75, 93)
        Me.txtSelChkProject.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtSelChkProject.MaxLength = 250
        Me.txtSelChkProject.Name = "txtSelChkProject"
        Me.txtSelChkProject.Size = New System.Drawing.Size(595, 20)
        Me.txtSelChkProject.TabIndex = 7
        '
        'txtSelKind
        '
        Me.txtSelKind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtSelKind.Location = New System.Drawing.Point(75, 67)
        Me.txtSelKind.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtSelKind.MaxLength = 50
        Me.txtSelKind.Name = "txtSelKind"
        Me.txtSelKind.Size = New System.Drawing.Size(201, 20)
        Me.txtSelKind.TabIndex = 5
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label32.Location = New System.Drawing.Point(8, 95)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(61, 13)
        Me.Label32.TabIndex = 49
        Me.Label32.Text = "检查项目："
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label33.Location = New System.Drawing.Point(304, 70)
        Me.Label33.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(61, 13)
        Me.Label33.TabIndex = 47
        Me.Label33.Text = "检查位置："
        '
        'txtSelChkPosition
        '
        Me.txtSelChkPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtSelChkPosition.Location = New System.Drawing.Point(367, 67)
        Me.txtSelChkPosition.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtSelChkPosition.MaxLength = 50
        Me.txtSelChkPosition.Name = "txtSelChkPosition"
        Me.txtSelChkPosition.Size = New System.Drawing.Size(303, 20)
        Me.txtSelChkPosition.TabIndex = 6
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label24.Location = New System.Drawing.Point(203, 20)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(61, 13)
        Me.Label24.TabIndex = 43
        Me.Label24.Text = "商品名称："
        '
        'txtSelGoodsName
        '
        Me.txtSelGoodsName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtSelGoodsName.Location = New System.Drawing.Point(284, 17)
        Me.txtSelGoodsName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtSelGoodsName.MaxLength = 50
        Me.txtSelGoodsName.Name = "txtSelGoodsName"
        Me.txtSelGoodsName.Size = New System.Drawing.Size(386, 20)
        Me.txtSelGoodsName.TabIndex = 2
        '
        'txtSelImgId
        '
        Me.txtSelImgId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtSelImgId.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSelImgId.Location = New System.Drawing.Point(367, 145)
        Me.txtSelImgId.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtSelImgId.MaxLength = 7
        Me.txtSelImgId.Name = "txtSelImgId"
        Me.txtSelImgId.Size = New System.Drawing.Size(118, 20)
        Me.txtSelImgId.TabIndex = 13
        '
        'txtSelClassify
        '
        Me.txtSelClassify.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtSelClassify.Location = New System.Drawing.Point(284, 42)
        Me.txtSelClassify.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtSelClassify.MaxLength = 50
        Me.txtSelClassify.Name = "txtSelClassify"
        Me.txtSelClassify.Size = New System.Drawing.Size(386, 20)
        Me.txtSelClassify.TabIndex = 4
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label20.Location = New System.Drawing.Point(306, 148)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 13)
        Me.Label20.TabIndex = 41
        Me.Label20.Text = "图片ID："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(8, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "商品CD："
        '
        'txtSelToolNo
        '
        Me.txtSelToolNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtSelToolNo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtSelToolNo.Location = New System.Drawing.Point(75, 42)
        Me.txtSelToolNo.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtSelToolNo.MaxLength = 30
        Me.txtSelToolNo.Name = "txtSelToolNo"
        Me.txtSelToolNo.Size = New System.Drawing.Size(118, 20)
        Me.txtSelToolNo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei", 9.75!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(677, 13)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "种类："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(8, 46)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "治具编号："
        '
        'txtSelGoodsCd
        '
        Me.txtSelGoodsCd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtSelGoodsCd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSelGoodsCd.Location = New System.Drawing.Point(75, 17)
        Me.txtSelGoodsCd.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtSelGoodsCd.MaxLength = 30
        Me.txtSelGoodsCd.Name = "txtSelGoodsCd"
        Me.txtSelGoodsCd.Size = New System.Drawing.Size(118, 20)
        Me.txtSelGoodsCd.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(203, 46)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "分类名："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft YaHei", 9.75!)
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(824, 11)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 19)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "类型："
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(850, -1)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(76, 28)
        Me.btnClear.TabIndex = 45
        Me.btnClear.Text = "清空"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(682, -1)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 28)
        Me.btnSave.TabIndex = 43
        Me.btnSave.Text = "保存"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(598, -1)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(76, 28)
        Me.btnSearch.TabIndex = 42
        Me.btnSearch.Text = "查询"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblTemplate
        '
        Me.lblTemplate.AutoSize = True
        Me.lblTemplate.Location = New System.Drawing.Point(579, 16)
        Me.lblTemplate.Name = "lblTemplate"
        Me.lblTemplate.Size = New System.Drawing.Size(58, 13)
        Me.lblTemplate.TabIndex = 10
        Me.lblTemplate.Text = "模板下载 "
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnCsv)
        Me.GroupBox3.Controls.Add(Me.lblRowCount)
        Me.GroupBox3.Controls.Add(Me.lblTemplate)
        Me.GroupBox3.Controls.Add(Me.lblTemplateDown)
        Me.GroupBox3.Controls.Add(Me.btnChoosePath)
        Me.GroupBox3.Controls.Add(Me.txtFilePath)
        Me.GroupBox3.Controls.Add(Me.btnExcute)
        Me.GroupBox3.Controls.Add(Me.rdbExport)
        Me.GroupBox3.Controls.Add(Me.rdbImport)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 726)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(976, 75)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        '
        'lblRowCount
        '
        Me.lblRowCount.AutoSize = True
        Me.lblRowCount.Location = New System.Drawing.Point(889, 14)
        Me.lblRowCount.Name = "lblRowCount"
        Me.lblRowCount.Size = New System.Drawing.Size(0, 13)
        Me.lblRowCount.TabIndex = 42
        '
        'lblTemplateDown
        '
        Me.lblTemplateDown.AutoSize = True
        Me.lblTemplateDown.Location = New System.Drawing.Point(648, 16)
        Me.lblTemplateDown.Name = "lblTemplateDown"
        Me.lblTemplateDown.Size = New System.Drawing.Size(118, 13)
        Me.lblTemplateDown.TabIndex = 38
        Me.lblTemplateDown.TabStop = True
        Me.lblTemplateDown.Text = "检查项目MS模版.XLS"
        '
        'btnChoosePath
        '
        Me.btnChoosePath.Location = New System.Drawing.Point(19, 41)
        Me.btnChoosePath.Name = "btnChoosePath"
        Me.btnChoosePath.Size = New System.Drawing.Size(75, 23)
        Me.btnChoosePath.TabIndex = 39
        Me.btnChoosePath.Text = "选择路径"
        Me.btnChoosePath.UseVisualStyleBackColor = True
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(104, 43)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(768, 20)
        Me.txtFilePath.TabIndex = 40
        '
        'btnExcute
        '
        Me.btnExcute.Location = New System.Drawing.Point(792, 9)
        Me.btnExcute.Name = "btnExcute"
        Me.btnExcute.Size = New System.Drawing.Size(75, 23)
        Me.btnExcute.TabIndex = 41
        Me.btnExcute.Text = "执行"
        Me.btnExcute.UseVisualStyleBackColor = True
        '
        'rdbExport
        '
        Me.rdbExport.AutoSize = True
        Me.rdbExport.Location = New System.Drawing.Point(122, 16)
        Me.rdbExport.Name = "rdbExport"
        Me.rdbExport.Size = New System.Drawing.Size(73, 17)
        Me.rdbExport.TabIndex = 37
        Me.rdbExport.Text = "批量导出"
        Me.rdbExport.UseVisualStyleBackColor = True
        '
        'rdbImport
        '
        Me.rdbImport.AutoSize = True
        Me.rdbImport.Checked = True
        Me.rdbImport.Location = New System.Drawing.Point(19, 16)
        Me.rdbImport.Name = "rdbImport"
        Me.rdbImport.Size = New System.Drawing.Size(73, 17)
        Me.rdbImport.TabIndex = 36
        Me.rdbImport.TabStop = True
        Me.rdbImport.Text = "批量导入"
        Me.rdbImport.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(933, -1)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(76, 28)
        Me.btnBack.TabIndex = 46
        Me.btnBack.Text = "返回"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'txtImgId
        '
        Me.txtImgId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtImgId.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtImgId.Location = New System.Drawing.Point(552, 159)
        Me.txtImgId.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtImgId.MaxLength = 7
        Me.txtImgId.Name = "txtImgId"
        Me.txtImgId.Size = New System.Drawing.Size(118, 20)
        Me.txtImgId.TabIndex = 34
        '
        'txtBenchmarkType
        '
        Me.txtBenchmarkType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtBenchmarkType.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtBenchmarkType.Location = New System.Drawing.Point(75, 130)
        Me.txtBenchmarkType.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtBenchmarkType.MaxLength = 2
        Me.txtBenchmarkType.Name = "txtBenchmarkType"
        Me.txtBenchmarkType.Size = New System.Drawing.Size(28, 20)
        Me.txtBenchmarkType.TabIndex = 29
        '
        'txtGoodsName
        '
        Me.txtGoodsName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtGoodsName.Location = New System.Drawing.Point(284, 24)
        Me.txtGoodsName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtGoodsName.MaxLength = 50
        Me.txtGoodsName.Name = "txtGoodsName"
        Me.txtGoodsName.Size = New System.Drawing.Size(228, 20)
        Me.txtGoodsName.TabIndex = 18
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(1021, -1)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(76, 28)
        Me.btnExit.TabIndex = 47
        Me.btnExit.Text = "退出"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label35.Location = New System.Drawing.Point(203, 53)
        Me.Label35.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(73, 13)
        Me.Label35.TabIndex = 45
        Me.Label35.Text = "治具表示顺："
        '
        'txtToolDispNo
        '
        Me.txtToolDispNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtToolDispNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtToolDispNo.Location = New System.Drawing.Point(284, 50)
        Me.txtToolDispNo.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtToolDispNo.MaxLength = 3
        Me.txtToolDispNo.Name = "txtToolDispNo"
        Me.txtToolDispNo.Size = New System.Drawing.Size(35, 20)
        Me.txtToolDispNo.TabIndex = 22
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label27.Location = New System.Drawing.Point(644, 26)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(37, 13)
        Me.Label27.TabIndex = 43
        Me.Label27.Text = "部门："
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label36.Location = New System.Drawing.Point(647, 53)
        Me.Label36.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(73, 13)
        Me.Label36.TabIndex = 47
        Me.Label36.Text = "分类表示顺："
        '
        'txtClassifyDispNo
        '
        Me.txtClassifyDispNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtClassifyDispNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtClassifyDispNo.Location = New System.Drawing.Point(728, 50)
        Me.txtClassifyDispNo.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtClassifyDispNo.MaxLength = 3
        Me.txtClassifyDispNo.Name = "txtClassifyDispNo"
        Me.txtClassifyDispNo.Size = New System.Drawing.Size(34, 20)
        Me.txtClassifyDispNo.TabIndex = 24
        '
        'drpEditDepartment
        '
        Me.drpEditDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpEditDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.drpEditDepartment.FormattingEnabled = True
        Me.drpEditDepartment.Location = New System.Drawing.Point(681, 22)
        Me.drpEditDepartment.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.drpEditDepartment.Name = "drpEditDepartment"
        Me.drpEditDepartment.Size = New System.Drawing.Size(81, 21)
        Me.drpEditDepartment.TabIndex = 20
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label23.Location = New System.Drawing.Point(203, 28)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(61, 13)
        Me.Label23.TabIndex = 41
        Me.Label23.Text = "商品名称："
        '
        'pbImg
        '
        Me.pbImg.Location = New System.Drawing.Point(772, 22)
        Me.pbImg.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.pbImg.Name = "pbImg"
        Me.pbImg.Size = New System.Drawing.Size(195, 157)
        Me.pbImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImg.TabIndex = 37
        Me.pbImg.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label19.Location = New System.Drawing.Point(489, 163)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 13)
        Me.Label19.TabIndex = 36
        Me.Label19.Text = "图片ID："
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label10.Location = New System.Drawing.Point(8, 29)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "商品CD："
        '
        'txtChkWay
        '
        Me.txtChkWay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtChkWay.Location = New System.Drawing.Point(75, 159)
        Me.txtChkWay.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtChkWay.MaxLength = 25
        Me.txtChkWay.Name = "txtChkWay"
        Me.txtChkWay.Size = New System.Drawing.Size(217, 20)
        Me.txtChkWay.TabIndex = 33
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(8, 79)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "类型："
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label18.Location = New System.Drawing.Point(8, 163)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(61, 13)
        Me.Label18.TabIndex = 34
        Me.Label18.Text = "检查方式："
        '
        'txtEditGoodsCd
        '
        Me.txtEditGoodsCd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtEditGoodsCd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtEditGoodsCd.Location = New System.Drawing.Point(75, 24)
        Me.txtEditGoodsCd.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtEditGoodsCd.MaxLength = 30
        Me.txtEditGoodsCd.Name = "txtEditGoodsCd"
        Me.txtEditGoodsCd.Size = New System.Drawing.Size(118, 20)
        Me.txtEditGoodsCd.TabIndex = 17
        '
        'txtBenchmarkValue3
        '
        Me.txtBenchmarkValue3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtBenchmarkValue3.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtBenchmarkValue3.Location = New System.Drawing.Point(552, 129)
        Me.txtBenchmarkValue3.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtBenchmarkValue3.MaxLength = 20
        Me.txtBenchmarkValue3.Name = "txtBenchmarkValue3"
        Me.txtBenchmarkValue3.Size = New System.Drawing.Size(118, 20)
        Me.txtBenchmarkValue3.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(325, 53)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "分类名："
        '
        'txtBenchmarkValue2
        '
        Me.txtBenchmarkValue2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtBenchmarkValue2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtBenchmarkValue2.Location = New System.Drawing.Point(363, 129)
        Me.txtBenchmarkValue2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtBenchmarkValue2.MaxLength = 20
        Me.txtBenchmarkValue2.Name = "txtBenchmarkValue2"
        Me.txtBenchmarkValue2.Size = New System.Drawing.Size(118, 20)
        Me.txtBenchmarkValue2.TabIndex = 31
        '
        'drpEditKindCd
        '
        Me.drpEditKindCd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpEditKindCd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.drpEditKindCd.FormattingEnabled = True
        Me.drpEditKindCd.Location = New System.Drawing.Point(555, 22)
        Me.drpEditKindCd.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.drpEditKindCd.Name = "drpEditKindCd"
        Me.drpEditKindCd.Size = New System.Drawing.Size(81, 21)
        Me.drpEditKindCd.TabIndex = 19
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label17.Location = New System.Drawing.Point(300, 134)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 13)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "基准值2："
        '
        'grpGoodsEdit
        '
        Me.grpGoodsEdit.Controls.Add(Me.drpEditDepartment)
        Me.grpGoodsEdit.Controls.Add(Me.txtChktimes)
        Me.grpGoodsEdit.Controls.Add(Me.Label21)
        Me.grpGoodsEdit.Controls.Add(Me.Label36)
        Me.grpGoodsEdit.Controls.Add(Me.txtClassifyDispNo)
        Me.grpGoodsEdit.Controls.Add(Me.Label35)
        Me.grpGoodsEdit.Controls.Add(Me.txtToolDispNo)
        Me.grpGoodsEdit.Controls.Add(Me.Label27)
        Me.grpGoodsEdit.Controls.Add(Me.Label23)
        Me.grpGoodsEdit.Controls.Add(Me.txtGoodsName)
        Me.grpGoodsEdit.Controls.Add(Me.txtBenchmarkType)
        Me.grpGoodsEdit.Controls.Add(Me.txtImgId)
        Me.grpGoodsEdit.Controls.Add(Me.pbImg)
        Me.grpGoodsEdit.Controls.Add(Me.Label19)
        Me.grpGoodsEdit.Controls.Add(Me.Label10)
        Me.grpGoodsEdit.Controls.Add(Me.txtChkWay)
        Me.grpGoodsEdit.Controls.Add(Me.Label6)
        Me.grpGoodsEdit.Controls.Add(Me.Label18)
        Me.grpGoodsEdit.Controls.Add(Me.txtEditGoodsCd)
        Me.grpGoodsEdit.Controls.Add(Me.txtBenchmarkValue3)
        Me.grpGoodsEdit.Controls.Add(Me.Label7)
        Me.grpGoodsEdit.Controls.Add(Me.txtBenchmarkValue2)
        Me.grpGoodsEdit.Controls.Add(Me.drpEditKindCd)
        Me.grpGoodsEdit.Controls.Add(Me.txtBenchmarkValue1)
        Me.grpGoodsEdit.Controls.Add(Me.Label8)
        Me.grpGoodsEdit.Controls.Add(Me.Label17)
        Me.grpGoodsEdit.Controls.Add(Me.txtEditToolNo)
        Me.grpGoodsEdit.Controls.Add(Me.Label16)
        Me.grpGoodsEdit.Controls.Add(Me.Label9)
        Me.grpGoodsEdit.Controls.Add(Me.Label15)
        Me.grpGoodsEdit.Controls.Add(Me.drpEditType)
        Me.grpGoodsEdit.Controls.Add(Me.txtEditClassify)
        Me.grpGoodsEdit.Controls.Add(Me.Label14)
        Me.grpGoodsEdit.Controls.Add(Me.Label11)
        Me.grpGoodsEdit.Controls.Add(Me.txtChkProject)
        Me.grpGoodsEdit.Controls.Add(Me.txtKind)
        Me.grpGoodsEdit.Controls.Add(Me.Label13)
        Me.grpGoodsEdit.Controls.Add(Me.Label12)
        Me.grpGoodsEdit.Controls.Add(Me.txtChkPosition)
        Me.grpGoodsEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.grpGoodsEdit.Location = New System.Drawing.Point(121, 209)
        Me.grpGoodsEdit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.grpGoodsEdit.Name = "grpGoodsEdit"
        Me.grpGoodsEdit.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.grpGoodsEdit.Size = New System.Drawing.Size(976, 186)
        Me.grpGoodsEdit.TabIndex = 19
        Me.grpGoodsEdit.TabStop = False
        Me.grpGoodsEdit.Text = "检查项目编辑"
        '
        'txtChktimes
        '
        Me.txtChktimes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtChktimes.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtChktimes.Location = New System.Drawing.Point(363, 159)
        Me.txtChktimes.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtChktimes.MaxLength = 2
        Me.txtChktimes.Name = "txtChktimes"
        Me.txtChktimes.Size = New System.Drawing.Size(118, 20)
        Me.txtChktimes.TabIndex = 48
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label21.Location = New System.Drawing.Point(300, 163)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(61, 13)
        Me.Label21.TabIndex = 49
        Me.Label21.Text = "检查次数："
        '
        'txtBenchmarkValue1
        '
        Me.txtBenchmarkValue1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtBenchmarkValue1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtBenchmarkValue1.Location = New System.Drawing.Point(174, 130)
        Me.txtBenchmarkValue1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtBenchmarkValue1.MaxLength = 20
        Me.txtBenchmarkValue1.Name = "txtBenchmarkValue1"
        Me.txtBenchmarkValue1.Size = New System.Drawing.Size(118, 20)
        Me.txtBenchmarkValue1.TabIndex = 30
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(8, 53)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "治具编号："
        '
        'txtEditToolNo
        '
        Me.txtEditToolNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtEditToolNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtEditToolNo.Location = New System.Drawing.Point(75, 50)
        Me.txtEditToolNo.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtEditToolNo.MaxLength = 30
        Me.txtEditToolNo.Name = "txtEditToolNo"
        Me.txtEditToolNo.Size = New System.Drawing.Size(118, 20)
        Me.txtEditToolNo.TabIndex = 21
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label16.Location = New System.Drawing.Point(489, 132)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 13)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "基准值3："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(519, 27)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "种类："
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label15.Location = New System.Drawing.Point(111, 134)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "基准值1："
        '
        'drpEditType
        '
        Me.drpEditType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpEditType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.drpEditType.FormattingEnabled = True
        Me.drpEditType.Location = New System.Drawing.Point(75, 76)
        Me.drpEditType.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.drpEditType.Name = "drpEditType"
        Me.drpEditType.Size = New System.Drawing.Size(62, 21)
        Me.drpEditType.TabIndex = 25
        '
        'txtEditClassify
        '
        Me.txtEditClassify.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtEditClassify.Location = New System.Drawing.Point(382, 50)
        Me.txtEditClassify.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtEditClassify.MaxLength = 50
        Me.txtEditClassify.Name = "txtEditClassify"
        Me.txtEditClassify.Size = New System.Drawing.Size(251, 20)
        Me.txtEditClassify.TabIndex = 23
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label14.Location = New System.Drawing.Point(8, 134)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 13)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "基准类型："
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label11.Location = New System.Drawing.Point(156, 79)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "类别："
        '
        'txtChkProject
        '
        Me.txtChkProject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtChkProject.Location = New System.Drawing.Point(75, 103)
        Me.txtChkProject.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtChkProject.MaxLength = 250
        Me.txtChkProject.Name = "txtChkProject"
        Me.txtChkProject.Size = New System.Drawing.Size(687, 20)
        Me.txtChkProject.TabIndex = 28
        '
        'txtKind
        '
        Me.txtKind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtKind.Location = New System.Drawing.Point(201, 77)
        Me.txtKind.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtKind.MaxLength = 50
        Me.txtKind.Name = "txtKind"
        Me.txtKind.Size = New System.Drawing.Size(210, 20)
        Me.txtKind.TabIndex = 26
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label13.Location = New System.Drawing.Point(8, 105)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "检查项目："
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label12.Location = New System.Drawing.Point(419, 79)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "检查位置："
        '
        'txtChkPosition
        '
        Me.txtChkPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtChkPosition.Location = New System.Drawing.Point(495, 77)
        Me.txtChkPosition.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtChkPosition.MaxLength = 50
        Me.txtChkPosition.Name = "txtChkPosition"
        Me.txtChkPosition.Size = New System.Drawing.Size(267, 20)
        Me.txtChkPosition.TabIndex = 27
        '
        'btnCsv
        '
        Me.btnCsv.Location = New System.Drawing.Point(218, 13)
        Me.btnCsv.Name = "btnCsv"
        Me.btnCsv.Size = New System.Drawing.Size(75, 23)
        Me.btnCsv.TabIndex = 43
        Me.btnCsv.Text = "导出CSV"
        Me.btnCsv.UseVisualStyleBackColor = True
        '
        'MsMaintenanceCheckForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(1204, 826)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.dtList)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.grpGoodsEdit)
        Me.Controls.Add(Me.grpSearch)
        Me.Name = "MsMaintenanceCheckForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "检查项目表维护"
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.pbImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGoodsEdit.ResumeLayout(False)
        Me.grpGoodsEdit.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents dtList As System.Windows.Forms.DataGridView
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtSelBenchmarkType As System.Windows.Forms.TextBox
    Friend WithEvents txtSelChkWay As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtSelBMValue3 As System.Windows.Forms.TextBox
    Friend WithEvents txtSelBMValue2 As System.Windows.Forms.TextBox
    Friend WithEvents txtSelBMValue1 As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtSelChkProject As System.Windows.Forms.TextBox
    Friend WithEvents txtSelKind As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtSelChkPosition As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtSelGoodsName As System.Windows.Forms.TextBox
    Friend WithEvents txtSelImgId As System.Windows.Forms.TextBox
    Friend WithEvents txtSelClassify As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSelToolNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSelGoodsCd As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblTemplate As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTemplateDown As System.Windows.Forms.LinkLabel
    Friend WithEvents btnChoosePath As System.Windows.Forms.Button
    Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
    Friend WithEvents btnExcute As System.Windows.Forms.Button
    Friend WithEvents rdbExport As System.Windows.Forms.RadioButton
    Friend WithEvents rdbImport As System.Windows.Forms.RadioButton
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents txtImgId As System.Windows.Forms.TextBox
    Friend WithEvents txtBenchmarkType As System.Windows.Forms.TextBox
    Friend WithEvents txtGoodsName As System.Windows.Forms.TextBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtToolDispNo As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtClassifyDispNo As System.Windows.Forms.TextBox
    Friend WithEvents drpEditDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents pbImg As System.Windows.Forms.PictureBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtChkWay As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtEditGoodsCd As System.Windows.Forms.TextBox
    Friend WithEvents txtBenchmarkValue3 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBenchmarkValue2 As System.Windows.Forms.TextBox
    Friend WithEvents drpEditKindCd As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents grpGoodsEdit As System.Windows.Forms.GroupBox
    Friend WithEvents txtBenchmarkValue1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtEditToolNo As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents drpEditType As System.Windows.Forms.ComboBox
    Friend WithEvents txtEditClassify As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtChkProject As System.Windows.Forms.TextBox
    Friend WithEvents txtKind As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtChkPosition As System.Windows.Forms.TextBox
    Friend WithEvents chkLDepartment As Lixil.AvoidMissSystem.WinUI.Common.ColorCodedCheckedListBox
    Friend WithEvents chkLType As Lixil.AvoidMissSystem.WinUI.Common.ColorCodedCheckedListBox
    Friend WithEvents chkLKind As Lixil.AvoidMissSystem.WinUI.Common.ColorCodedCheckedListBox
    Friend WithEvents txtChktimes As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents goods_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents goods_cd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents goods_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 种类 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kind_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tools_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tools_order As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents classify_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents classify_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents classify_order As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents type_cd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents type_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents department_cd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents department_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kind As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents check_position As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents check_item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents benchmark_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents benchmark_value1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents benchmark_value2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents benchmark_value3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents check_way As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents check_times As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents picture_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents delete_flg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tools_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblRowCount As System.Windows.Forms.Label
    Friend WithEvents btnCsv As System.Windows.Forms.Button

End Class