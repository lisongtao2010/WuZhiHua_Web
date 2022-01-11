<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MsMaintenanceToolsForm
    Inherits AvoidMissSystem.WinUI.BaseForm

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.lblSearchGoodsCD = New System.Windows.Forms.Label
        Me.lblSearchToolsNo = New System.Windows.Forms.Label
        Me.lblSearchDistinguish = New System.Windows.Forms.Label
        Me.lblSearchBarcode = New System.Windows.Forms.Label
        Me.lblSearchRemarks = New System.Windows.Forms.Label
        Me.txtSearchRemarks = New System.Windows.Forms.TextBox
        Me.txtSearchBarcode = New System.Windows.Forms.TextBox
        Me.txtSearchDistinguish = New System.Windows.Forms.TextBox
        Me.txtSearchToolsNo = New System.Windows.Forms.TextBox
        Me.txtSearchGoodsCD = New System.Windows.Forms.TextBox
        Me.lblSearchDepartment = New System.Windows.Forms.Label
        Me.pnlTools = New System.Windows.Forms.Panel
        Me.dgvGoods = New System.Windows.Forms.DataGridView
        Me.dgvTools = New System.Windows.Forms.DataGridView
        Me.btnExcel = New System.Windows.Forms.Button
        Me.pnlExcel = New System.Windows.Forms.Panel
        Me.lblRowCount = New System.Windows.Forms.Label
        Me.lblTemplate = New System.Windows.Forms.Label
        Me.lblTemplateDown = New System.Windows.Forms.LinkLabel
        Me.txtFilePath = New System.Windows.Forms.TextBox
        Me.rdoExport = New System.Windows.Forms.RadioButton
        Me.rdoImport = New System.Windows.Forms.RadioButton
        Me.btnFilePath = New System.Windows.Forms.Button
        Me.pnlAction = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnReturn = New System.Windows.Forms.Button
        Me.gbSearch = New System.Windows.Forms.GroupBox
        Me.ddlSearchBarcodeFlg = New System.Windows.Forms.ComboBox
        Me.lblID = New System.Windows.Forms.Label
        Me.lblSearchBarcodeFlg = New System.Windows.Forms.Label
        Me.txtSearchID = New System.Windows.Forms.TextBox
        Me.gbEdit = New System.Windows.Forms.GroupBox
        Me.ddlBarcodeFlg = New System.Windows.Forms.ComboBox
        Me.ddlDepartment = New System.Windows.Forms.ComboBox
        Me.lblDepartment = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.lblDistinguish = New System.Windows.Forms.Label
        Me.txtBarcode = New System.Windows.Forms.TextBox
        Me.lblBarcodeFlg = New System.Windows.Forms.Label
        Me.lblBarcode = New System.Windows.Forms.Label
        Me.txtDistinguish = New System.Windows.Forms.TextBox
        Me.lblToolsNo = New System.Windows.Forms.Label
        Me.txtToolsNo = New System.Windows.Forms.TextBox
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.pnlTools.SuspendLayout()
        CType(Me.dgvGoods, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTools, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExcel.SuspendLayout()
        Me.pnlAction.SuspendLayout()
        Me.gbSearch.SuspendLayout()
        Me.gbEdit.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(376, 2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 30)
        Me.btnSearch.TabIndex = 0
        Me.btnSearch.Text = "查询"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(608, 2)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 30)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "清空"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(531, 2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 30)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "删除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(453, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 30)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "保存"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblSearchGoodsCD
        '
        Me.lblSearchGoodsCD.AutoSize = True
        Me.lblSearchGoodsCD.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblSearchGoodsCD.Location = New System.Drawing.Point(352, 84)
        Me.lblSearchGoodsCD.Name = "lblSearchGoodsCD"
        Me.lblSearchGoodsCD.Size = New System.Drawing.Size(61, 17)
        Me.lblSearchGoodsCD.TabIndex = 1
        Me.lblSearchGoodsCD.Text = "商品CD："
        '
        'lblSearchToolsNo
        '
        Me.lblSearchToolsNo.AutoSize = True
        Me.lblSearchToolsNo.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblSearchToolsNo.Location = New System.Drawing.Point(6, 35)
        Me.lblSearchToolsNo.Name = "lblSearchToolsNo"
        Me.lblSearchToolsNo.Size = New System.Drawing.Size(68, 17)
        Me.lblSearchToolsNo.TabIndex = 1
        Me.lblSearchToolsNo.Text = "治具编号："
        '
        'lblSearchDistinguish
        '
        Me.lblSearchDistinguish.AutoSize = True
        Me.lblSearchDistinguish.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblSearchDistinguish.Location = New System.Drawing.Point(352, 37)
        Me.lblSearchDistinguish.Name = "lblSearchDistinguish"
        Me.lblSearchDistinguish.Size = New System.Drawing.Size(68, 17)
        Me.lblSearchDistinguish.TabIndex = 1
        Me.lblSearchDistinguish.Text = "治具区分："
        '
        'lblSearchBarcode
        '
        Me.lblSearchBarcode.AutoSize = True
        Me.lblSearchBarcode.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblSearchBarcode.Location = New System.Drawing.Point(352, 60)
        Me.lblSearchBarcode.Name = "lblSearchBarcode"
        Me.lblSearchBarcode.Size = New System.Drawing.Size(56, 17)
        Me.lblSearchBarcode.TabIndex = 1
        Me.lblSearchBarcode.Text = "条形码："
        '
        'lblSearchRemarks
        '
        Me.lblSearchRemarks.AutoSize = True
        Me.lblSearchRemarks.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblSearchRemarks.Location = New System.Drawing.Point(6, 82)
        Me.lblSearchRemarks.Name = "lblSearchRemarks"
        Me.lblSearchRemarks.Size = New System.Drawing.Size(44, 17)
        Me.lblSearchRemarks.TabIndex = 1
        Me.lblSearchRemarks.Text = "备注："
        '
        'txtSearchRemarks
        '
        Me.txtSearchRemarks.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtSearchRemarks.Location = New System.Drawing.Point(87, 81)
        Me.txtSearchRemarks.MaxLength = 200
        Me.txtSearchRemarks.Name = "txtSearchRemarks"
        Me.txtSearchRemarks.Size = New System.Drawing.Size(160, 19)
        Me.txtSearchRemarks.TabIndex = 10
        '
        'txtSearchBarcode
        '
        Me.txtSearchBarcode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSearchBarcode.Location = New System.Drawing.Point(430, 57)
        Me.txtSearchBarcode.MaxLength = 30
        Me.txtSearchBarcode.Name = "txtSearchBarcode"
        Me.txtSearchBarcode.Size = New System.Drawing.Size(160, 19)
        Me.txtSearchBarcode.TabIndex = 9
        '
        'txtSearchDistinguish
        '
        Me.txtSearchDistinguish.Location = New System.Drawing.Point(430, 34)
        Me.txtSearchDistinguish.MaxLength = 100
        Me.txtSearchDistinguish.Name = "txtSearchDistinguish"
        Me.txtSearchDistinguish.Size = New System.Drawing.Size(160, 19)
        Me.txtSearchDistinguish.TabIndex = 7
        '
        'txtSearchToolsNo
        '
        Me.txtSearchToolsNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSearchToolsNo.Location = New System.Drawing.Point(87, 34)
        Me.txtSearchToolsNo.MaxLength = 30
        Me.txtSearchToolsNo.Name = "txtSearchToolsNo"
        Me.txtSearchToolsNo.Size = New System.Drawing.Size(160, 19)
        Me.txtSearchToolsNo.TabIndex = 6
        '
        'txtSearchGoodsCD
        '
        Me.txtSearchGoodsCD.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSearchGoodsCD.Location = New System.Drawing.Point(430, 81)
        Me.txtSearchGoodsCD.MaxLength = 30
        Me.txtSearchGoodsCD.Name = "txtSearchGoodsCD"
        Me.txtSearchGoodsCD.Size = New System.Drawing.Size(160, 19)
        Me.txtSearchGoodsCD.TabIndex = 11
        '
        'lblSearchDepartment
        '
        Me.lblSearchDepartment.AutoSize = True
        Me.lblSearchDepartment.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblSearchDepartment.Location = New System.Drawing.Point(6, 13)
        Me.lblSearchDepartment.Name = "lblSearchDepartment"
        Me.lblSearchDepartment.Size = New System.Drawing.Size(44, 17)
        Me.lblSearchDepartment.TabIndex = 1
        Me.lblSearchDepartment.Text = "部门："
        '
        'pnlTools
        '
        Me.pnlTools.Controls.Add(Me.dgvGoods)
        Me.pnlTools.Controls.Add(Me.dgvTools)
        Me.pnlTools.Location = New System.Drawing.Point(29, 242)
        Me.pnlTools.Name = "pnlTools"
        Me.pnlTools.Size = New System.Drawing.Size(837, 320)
        Me.pnlTools.TabIndex = 3
        '
        'dgvGoods
        '
        Me.dgvGoods.AllowUserToAddRows = False
        Me.dgvGoods.AllowUserToDeleteRows = False
        Me.dgvGoods.AllowUserToResizeRows = False
        Me.dgvGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGoods.Location = New System.Drawing.Point(675, 4)
        Me.dgvGoods.Name = "dgvGoods"
        Me.dgvGoods.RowHeadersVisible = False
        Me.dgvGoods.RowTemplate.Height = 21
        Me.dgvGoods.Size = New System.Drawing.Size(160, 313)
        Me.dgvGoods.TabIndex = 0
        '
        'dgvTools
        '
        Me.dgvTools.AllowUserToAddRows = False
        Me.dgvTools.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTools.Location = New System.Drawing.Point(2, 4)
        Me.dgvTools.Name = "dgvTools"
        Me.dgvTools.RowTemplate.Height = 21
        Me.dgvTools.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTools.Size = New System.Drawing.Size(665, 313)
        Me.dgvTools.TabIndex = 1
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(654, 2)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(75, 23)
        Me.btnExcel.TabIndex = 4
        Me.btnExcel.Text = "执行"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'pnlExcel
        '
        Me.pnlExcel.Controls.Add(Me.lblRowCount)
        Me.pnlExcel.Controls.Add(Me.lblTemplate)
        Me.pnlExcel.Controls.Add(Me.lblTemplateDown)
        Me.pnlExcel.Controls.Add(Me.txtFilePath)
        Me.pnlExcel.Controls.Add(Me.btnExcel)
        Me.pnlExcel.Controls.Add(Me.rdoExport)
        Me.pnlExcel.Controls.Add(Me.rdoImport)
        Me.pnlExcel.Controls.Add(Me.btnFilePath)
        Me.pnlExcel.Location = New System.Drawing.Point(29, 563)
        Me.pnlExcel.Name = "pnlExcel"
        Me.pnlExcel.Size = New System.Drawing.Size(837, 55)
        Me.pnlExcel.TabIndex = 4
        '
        'lblRowCount
        '
        Me.lblRowCount.AutoSize = True
        Me.lblRowCount.Location = New System.Drawing.Point(760, 7)
        Me.lblRowCount.Name = "lblRowCount"
        Me.lblRowCount.Size = New System.Drawing.Size(0, 12)
        Me.lblRowCount.TabIndex = 2
        '
        'lblTemplate
        '
        Me.lblTemplate.AutoSize = True
        Me.lblTemplate.Location = New System.Drawing.Point(493, 8)
        Me.lblTemplate.Name = "lblTemplate"
        Me.lblTemplate.Size = New System.Drawing.Size(41, 12)
        Me.lblTemplate.TabIndex = 2
        Me.lblTemplate.Text = "模板下载"
        '
        'lblTemplateDown
        '
        Me.lblTemplateDown.AutoSize = True
        Me.lblTemplateDown.Location = New System.Drawing.Point(547, 8)
        Me.lblTemplateDown.Name = "lblTemplateDown"
        Me.lblTemplateDown.Size = New System.Drawing.Size(91, 12)
        Me.lblTemplateDown.TabIndex = 3
        Me.lblTemplateDown.TabStop = True
        Me.lblTemplateDown.Text = "治具MS模版.XLS"
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(116, 30)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(613, 19)
        Me.txtFilePath.TabIndex = 6
        '
        'rdoExport
        '
        Me.rdoExport.AutoSize = True
        Me.rdoExport.Location = New System.Drawing.Point(116, 5)
        Me.rdoExport.Name = "rdoExport"
        Me.rdoExport.Size = New System.Drawing.Size(71, 16)
        Me.rdoExport.TabIndex = 1
        Me.rdoExport.TabStop = True
        Me.rdoExport.Text = "批量导出"
        Me.rdoExport.UseVisualStyleBackColor = True
        '
        'rdoImport
        '
        Me.rdoImport.AutoSize = True
        Me.rdoImport.Location = New System.Drawing.Point(25, 5)
        Me.rdoImport.Name = "rdoImport"
        Me.rdoImport.Size = New System.Drawing.Size(71, 16)
        Me.rdoImport.TabIndex = 0
        Me.rdoImport.TabStop = True
        Me.rdoImport.Text = "批量导入"
        Me.rdoImport.UseVisualStyleBackColor = True
        '
        'btnFilePath
        '
        Me.btnFilePath.Location = New System.Drawing.Point(25, 28)
        Me.btnFilePath.Name = "btnFilePath"
        Me.btnFilePath.Size = New System.Drawing.Size(75, 23)
        Me.btnFilePath.TabIndex = 5
        Me.btnFilePath.Text = "选择路径"
        Me.btnFilePath.UseVisualStyleBackColor = True
        '
        'pnlAction
        '
        Me.pnlAction.Controls.Add(Me.btnClose)
        Me.pnlAction.Controls.Add(Me.btnReturn)
        Me.pnlAction.Controls.Add(Me.btnSave)
        Me.pnlAction.Controls.Add(Me.btnDelete)
        Me.pnlAction.Controls.Add(Me.btnClear)
        Me.pnlAction.Controls.Add(Me.btnSearch)
        Me.pnlAction.Location = New System.Drawing.Point(29, -2)
        Me.pnlAction.Name = "pnlAction"
        Me.pnlAction.Size = New System.Drawing.Size(837, 34)
        Me.pnlAction.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(763, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 30)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "退出"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnReturn
        '
        Me.btnReturn.Location = New System.Drawing.Point(685, 2)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(75, 30)
        Me.btnReturn.TabIndex = 4
        Me.btnReturn.Text = "返回"
        Me.btnReturn.UseVisualStyleBackColor = True
        '
        'gbSearch
        '
        Me.gbSearch.Controls.Add(Me.ddlSearchBarcodeFlg)
        Me.gbSearch.Controls.Add(Me.lblSearchDepartment)
        Me.gbSearch.Controls.Add(Me.txtSearchRemarks)
        Me.gbSearch.Controls.Add(Me.lblID)
        Me.gbSearch.Controls.Add(Me.lblSearchDistinguish)
        Me.gbSearch.Controls.Add(Me.txtSearchBarcode)
        Me.gbSearch.Controls.Add(Me.lblSearchBarcodeFlg)
        Me.gbSearch.Controls.Add(Me.lblSearchBarcode)
        Me.gbSearch.Controls.Add(Me.txtSearchID)
        Me.gbSearch.Controls.Add(Me.txtSearchDistinguish)
        Me.gbSearch.Controls.Add(Me.lblSearchToolsNo)
        Me.gbSearch.Controls.Add(Me.txtSearchToolsNo)
        Me.gbSearch.Controls.Add(Me.lblSearchRemarks)
        Me.gbSearch.Controls.Add(Me.txtSearchGoodsCD)
        Me.gbSearch.Controls.Add(Me.lblSearchGoodsCD)
        Me.gbSearch.Location = New System.Drawing.Point(29, 29)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.Size = New System.Drawing.Size(837, 105)
        Me.gbSearch.TabIndex = 1
        Me.gbSearch.TabStop = False
        Me.gbSearch.Text = "查询"
        '
        'ddlSearchBarcodeFlg
        '
        Me.ddlSearchBarcodeFlg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlSearchBarcodeFlg.FormattingEnabled = True
        Me.ddlSearchBarcodeFlg.Location = New System.Drawing.Point(87, 57)
        Me.ddlSearchBarcodeFlg.Name = "ddlSearchBarcodeFlg"
        Me.ddlSearchBarcodeFlg.Size = New System.Drawing.Size(160, 20)
        Me.ddlSearchBarcodeFlg.TabIndex = 8
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblID.Location = New System.Drawing.Point(352, 15)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(57, 17)
        Me.lblID.TabIndex = 1
        Me.lblID.Text = "治具ID："
        '
        'lblSearchBarcodeFlg
        '
        Me.lblSearchBarcodeFlg.AutoSize = True
        Me.lblSearchBarcodeFlg.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblSearchBarcodeFlg.Location = New System.Drawing.Point(6, 58)
        Me.lblSearchBarcodeFlg.Name = "lblSearchBarcodeFlg"
        Me.lblSearchBarcodeFlg.Size = New System.Drawing.Size(56, 17)
        Me.lblSearchBarcodeFlg.TabIndex = 1
        Me.lblSearchBarcodeFlg.Text = "基准值："
        '
        'txtSearchID
        '
        Me.txtSearchID.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSearchID.Location = New System.Drawing.Point(430, 11)
        Me.txtSearchID.MaxLength = 100
        Me.txtSearchID.Name = "txtSearchID"
        Me.txtSearchID.Size = New System.Drawing.Size(160, 19)
        Me.txtSearchID.TabIndex = 5
        '
        'gbEdit
        '
        Me.gbEdit.Controls.Add(Me.ddlBarcodeFlg)
        Me.gbEdit.Controls.Add(Me.ddlDepartment)
        Me.gbEdit.Controls.Add(Me.lblDepartment)
        Me.gbEdit.Controls.Add(Me.txtRemarks)
        Me.gbEdit.Controls.Add(Me.lblDistinguish)
        Me.gbEdit.Controls.Add(Me.txtBarcode)
        Me.gbEdit.Controls.Add(Me.lblBarcodeFlg)
        Me.gbEdit.Controls.Add(Me.lblBarcode)
        Me.gbEdit.Controls.Add(Me.txtDistinguish)
        Me.gbEdit.Controls.Add(Me.lblToolsNo)
        Me.gbEdit.Controls.Add(Me.txtToolsNo)
        Me.gbEdit.Controls.Add(Me.lblRemarks)
        Me.gbEdit.Location = New System.Drawing.Point(29, 136)
        Me.gbEdit.Name = "gbEdit"
        Me.gbEdit.Size = New System.Drawing.Size(837, 103)
        Me.gbEdit.TabIndex = 2
        Me.gbEdit.TabStop = False
        Me.gbEdit.Text = "编辑"
        '
        'ddlBarcodeFlg
        '
        Me.ddlBarcodeFlg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlBarcodeFlg.FormattingEnabled = True
        Me.ddlBarcodeFlg.Location = New System.Drawing.Point(87, 57)
        Me.ddlBarcodeFlg.Name = "ddlBarcodeFlg"
        Me.ddlBarcodeFlg.Size = New System.Drawing.Size(160, 20)
        Me.ddlBarcodeFlg.TabIndex = 4
        '
        'ddlDepartment
        '
        Me.ddlDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlDepartment.FormattingEnabled = True
        Me.ddlDepartment.Location = New System.Drawing.Point(87, 11)
        Me.ddlDepartment.Name = "ddlDepartment"
        Me.ddlDepartment.Size = New System.Drawing.Size(160, 20)
        Me.ddlDepartment.TabIndex = 0
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblDepartment.Location = New System.Drawing.Point(6, 15)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(44, 17)
        Me.lblDepartment.TabIndex = 1
        Me.lblDepartment.Text = "部门："
        '
        'txtRemarks
        '
        Me.txtRemarks.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtRemarks.Location = New System.Drawing.Point(87, 80)
        Me.txtRemarks.MaxLength = 200
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(590, 19)
        Me.txtRemarks.TabIndex = 6
        '
        'lblDistinguish
        '
        Me.lblDistinguish.AutoSize = True
        Me.lblDistinguish.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblDistinguish.Location = New System.Drawing.Point(352, 36)
        Me.lblDistinguish.Name = "lblDistinguish"
        Me.lblDistinguish.Size = New System.Drawing.Size(68, 17)
        Me.lblDistinguish.TabIndex = 1
        Me.lblDistinguish.Text = "治具区分："
        '
        'txtBarcode
        '
        Me.txtBarcode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtBarcode.Location = New System.Drawing.Point(430, 57)
        Me.txtBarcode.MaxLength = 30
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(160, 19)
        Me.txtBarcode.TabIndex = 5
        '
        'lblBarcodeFlg
        '
        Me.lblBarcodeFlg.AutoSize = True
        Me.lblBarcodeFlg.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblBarcodeFlg.Location = New System.Drawing.Point(6, 60)
        Me.lblBarcodeFlg.Name = "lblBarcodeFlg"
        Me.lblBarcodeFlg.Size = New System.Drawing.Size(56, 17)
        Me.lblBarcodeFlg.TabIndex = 1
        Me.lblBarcodeFlg.Text = "基准值："
        '
        'lblBarcode
        '
        Me.lblBarcode.AutoSize = True
        Me.lblBarcode.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblBarcode.Location = New System.Drawing.Point(352, 59)
        Me.lblBarcode.Name = "lblBarcode"
        Me.lblBarcode.Size = New System.Drawing.Size(56, 17)
        Me.lblBarcode.TabIndex = 1
        Me.lblBarcode.Text = "条形码："
        '
        'txtDistinguish
        '
        Me.txtDistinguish.Location = New System.Drawing.Point(430, 34)
        Me.txtDistinguish.MaxLength = 100
        Me.txtDistinguish.Name = "txtDistinguish"
        Me.txtDistinguish.Size = New System.Drawing.Size(160, 19)
        Me.txtDistinguish.TabIndex = 3
        '
        'lblToolsNo
        '
        Me.lblToolsNo.AutoSize = True
        Me.lblToolsNo.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblToolsNo.Location = New System.Drawing.Point(6, 37)
        Me.lblToolsNo.Name = "lblToolsNo"
        Me.lblToolsNo.Size = New System.Drawing.Size(68, 17)
        Me.lblToolsNo.TabIndex = 1
        Me.lblToolsNo.Text = "治具编号："
        '
        'txtToolsNo
        '
        Me.txtToolsNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtToolsNo.Location = New System.Drawing.Point(87, 34)
        Me.txtToolsNo.MaxLength = 30
        Me.txtToolsNo.Name = "txtToolsNo"
        Me.txtToolsNo.Size = New System.Drawing.Size(160, 19)
        Me.txtToolsNo.TabIndex = 1
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblRemarks.Location = New System.Drawing.Point(6, 83)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(44, 17)
        Me.lblRemarks.TabIndex = 1
        Me.lblRemarks.Text = "备注："
        '
        'MsMaintenanceToolsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(892, 623)
        Me.Controls.Add(Me.gbEdit)
        Me.Controls.Add(Me.gbSearch)
        Me.Controls.Add(Me.pnlAction)
        Me.Controls.Add(Me.pnlExcel)
        Me.Controls.Add(Me.pnlTools)
        Me.Name = "MsMaintenanceToolsForm"
        Me.Text = "治具MS维护"
        Me.pnlTools.ResumeLayout(False)
        CType(Me.dgvGoods, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTools, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExcel.ResumeLayout(False)
        Me.pnlExcel.PerformLayout()
        Me.pnlAction.ResumeLayout(False)
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        Me.gbEdit.ResumeLayout(False)
        Me.gbEdit.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblSearchGoodsCD As System.Windows.Forms.Label
    Friend WithEvents lblSearchToolsNo As System.Windows.Forms.Label
    Friend WithEvents lblSearchDistinguish As System.Windows.Forms.Label
    Friend WithEvents lblSearchBarcode As System.Windows.Forms.Label
    Friend WithEvents lblSearchRemarks As System.Windows.Forms.Label
    Friend WithEvents pnlTools As System.Windows.Forms.Panel
    Friend WithEvents dgvTools As System.Windows.Forms.DataGridView
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents pnlExcel As System.Windows.Forms.Panel
    Friend WithEvents txtSearchGoodsCD As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchBarcode As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchDistinguish As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchToolsNo As System.Windows.Forms.TextBox
    Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
    Friend WithEvents rdoExport As System.Windows.Forms.RadioButton
    Friend WithEvents rdoImport As System.Windows.Forms.RadioButton
    Friend WithEvents btnFilePath As System.Windows.Forms.Button
    Friend WithEvents lblSearchDepartment As System.Windows.Forms.Label
    Friend WithEvents pnlAction As System.Windows.Forms.Panel
    Friend WithEvents lblTemplateDown As System.Windows.Forms.LinkLabel
    Friend WithEvents lblTemplate As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnReturn As System.Windows.Forms.Button
    Friend WithEvents gbSearch As System.Windows.Forms.GroupBox
    Friend WithEvents gbEdit As System.Windows.Forms.GroupBox
    Friend WithEvents ddlDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents lblDepartment As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblDistinguish As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents lblBarcode As System.Windows.Forms.Label
    Friend WithEvents txtDistinguish As System.Windows.Forms.TextBox
    Friend WithEvents lblToolsNo As System.Windows.Forms.Label
    Friend WithEvents txtToolsNo As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents dgvGoods As System.Windows.Forms.DataGridView
    Friend WithEvents lblSearchBarcodeFlg As System.Windows.Forms.Label
    Friend WithEvents lblBarcodeFlg As System.Windows.Forms.Label
    Friend WithEvents ddlSearchBarcodeFlg As System.Windows.Forms.ComboBox
    Friend WithEvents ddlBarcodeFlg As System.Windows.Forms.ComboBox
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents txtSearchID As System.Windows.Forms.TextBox
    Friend WithEvents lblRowCount As System.Windows.Forms.Label
End Class
