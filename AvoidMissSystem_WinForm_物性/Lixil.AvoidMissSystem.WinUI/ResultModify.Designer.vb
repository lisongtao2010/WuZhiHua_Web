<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResultModify
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
        Me.pnlAction = New System.Windows.Forms.Panel()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnReturn = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.gbSearch = New System.Windows.Forms.GroupBox()
        Me.cbLine_name = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CToDate = New System.Windows.Forms.DateTimePicker()
        Me.lblCFrom = New System.Windows.Forms.Label()
        Me.CFromDate = New System.Windows.Forms.DateTimePicker()
        Me.lblCDate = New System.Windows.Forms.Label()
        Me.PToDate = New System.Windows.Forms.DateTimePicker()
        Me.lblPFrom = New System.Windows.Forms.Label()
        Me.chkLDepartment = New Lixil.AvoidMissSystem.WinUI.Common.ColorCodedCheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtChkUser = New System.Windows.Forms.TextBox()
        Me.drpResult = New System.Windows.Forms.ComboBox()
        Me.PFromDate = New System.Windows.Forms.DateTimePicker()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.lblPDate = New System.Windows.Forms.Label()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.lblMakeNo = New System.Windows.Forms.Label()
        Me.txtMakeNo = New System.Windows.Forms.TextBox()
        Me.txtSearchGoodsCD = New System.Windows.Forms.TextBox()
        Me.lblGoodsCD = New System.Windows.Forms.Label()
        Me.gbEdit = New System.Windows.Forms.GroupBox()
        Me.btnSakujyo = New System.Windows.Forms.Button()
        Me.txtPDate = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFDate = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtSharId = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtUpStart = New System.Windows.Forms.TextBox()
        Me.txtUpEnd = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtEDirection = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtENumber = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtELine = New System.Windows.Forms.TextBox()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.drpState = New System.Windows.Forms.ComboBox()
        Me.lblState = New System.Windows.Forms.Label()
        Me.btnOpenDetail = New System.Windows.Forms.Button()
        Me.drpEResult = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEChkUser = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtReultID = New System.Windows.Forms.TextBox()
        Me.txtEndTime = New System.Windows.Forms.TextBox()
        Me.txtEGoodsCd = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtEDptMent = New System.Windows.Forms.TextBox()
        Me.lbl = New System.Windows.Forms.Label()
        Me.lblDepMent = New System.Windows.Forms.Label()
        Me.txtEStartTime = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEMakeNo = New System.Windows.Forms.TextBox()
        Me.dgvChkResult = New System.Windows.Forms.DataGridView()
        Me.pnlAction.SuspendLayout()
        Me.gbSearch.SuspendLayout()
        Me.gbEdit.SuspendLayout()
        CType(Me.dgvChkResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlAction
        '
        Me.pnlAction.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlAction.Controls.Add(Me.btnExport)
        Me.pnlAction.Controls.Add(Me.btnClose)
        Me.pnlAction.Controls.Add(Me.btnReturn)
        Me.pnlAction.Controls.Add(Me.btnClear)
        Me.pnlAction.Controls.Add(Me.btnSearch)
        Me.pnlAction.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAction.Location = New System.Drawing.Point(0, 0)
        Me.pnlAction.Name = "pnlAction"
        Me.pnlAction.Size = New System.Drawing.Size(1008, 41)
        Me.pnlAction.TabIndex = 1
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Microsoft YaHei", 10.0!)
        Me.btnExport.Location = New System.Drawing.Point(377, 0)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 38)
        Me.btnExport.TabIndex = 8
        Me.btnExport.Text = "导出"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft YaHei", 10.0!)
        Me.btnClose.Location = New System.Drawing.Point(611, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 38)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "退出"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnReturn
        '
        Me.btnReturn.Font = New System.Drawing.Font("Microsoft YaHei", 10.0!)
        Me.btnReturn.Location = New System.Drawing.Point(533, 0)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(75, 38)
        Me.btnReturn.TabIndex = 6
        Me.btnReturn.Text = "返回"
        Me.btnReturn.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Microsoft YaHei", 10.0!)
        Me.btnClear.Location = New System.Drawing.Point(454, 0)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 38)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "清空"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft YaHei", 10.0!)
        Me.btnSearch.Location = New System.Drawing.Point(295, 0)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 38)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "查询"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(593, 20)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 24)
        Me.btnUpdate.TabIndex = 12
        Me.btnUpdate.Text = "保存"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'gbSearch
        '
        Me.gbSearch.Controls.Add(Me.cbLine_name)
        Me.gbSearch.Controls.Add(Me.Label12)
        Me.gbSearch.Controls.Add(Me.Label11)
        Me.gbSearch.Controls.Add(Me.CToDate)
        Me.gbSearch.Controls.Add(Me.lblCFrom)
        Me.gbSearch.Controls.Add(Me.CFromDate)
        Me.gbSearch.Controls.Add(Me.lblCDate)
        Me.gbSearch.Controls.Add(Me.PToDate)
        Me.gbSearch.Controls.Add(Me.lblPFrom)
        Me.gbSearch.Controls.Add(Me.chkLDepartment)
        Me.gbSearch.Controls.Add(Me.Label1)
        Me.gbSearch.Controls.Add(Me.txtChkUser)
        Me.gbSearch.Controls.Add(Me.drpResult)
        Me.gbSearch.Controls.Add(Me.PFromDate)
        Me.gbSearch.Controls.Add(Me.lblDepartment)
        Me.gbSearch.Controls.Add(Me.lblPDate)
        Me.gbSearch.Controls.Add(Me.lblResult)
        Me.gbSearch.Controls.Add(Me.lblMakeNo)
        Me.gbSearch.Controls.Add(Me.txtMakeNo)
        Me.gbSearch.Controls.Add(Me.txtSearchGoodsCD)
        Me.gbSearch.Controls.Add(Me.lblGoodsCD)
        Me.gbSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbSearch.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.gbSearch.Location = New System.Drawing.Point(0, 41)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.Size = New System.Drawing.Size(1008, 136)
        Me.gbSearch.TabIndex = 5
        Me.gbSearch.TabStop = False
        Me.gbSearch.Text = "查询"
        '
        'cbLine_name
        '
        Me.cbLine_name.FormattingEnabled = True
        Me.cbLine_name.Location = New System.Drawing.Point(507, 46)
        Me.cbLine_name.Name = "cbLine_name"
        Me.cbLine_name.Size = New System.Drawing.Size(128, 25)
        Me.cbLine_name.TabIndex = 28
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(283, 88)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(17, 17)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "~"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(283, 114)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(17, 17)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "~"
        '
        'CToDate
        '
        Me.CToDate.Location = New System.Drawing.Point(307, 108)
        Me.CToDate.Name = "CToDate"
        Me.CToDate.ShowCheckBox = True
        Me.CToDate.Size = New System.Drawing.Size(151, 23)
        Me.CToDate.TabIndex = 25
        '
        'lblCFrom
        '
        Me.lblCFrom.AutoSize = True
        Me.lblCFrom.Location = New System.Drawing.Point(133, 111)
        Me.lblCFrom.Name = "lblCFrom"
        Me.lblCFrom.Size = New System.Drawing.Size(0, 17)
        Me.lblCFrom.TabIndex = 23
        '
        'CFromDate
        '
        Me.CFromDate.Location = New System.Drawing.Point(110, 107)
        Me.CFromDate.Name = "CFromDate"
        Me.CFromDate.ShowCheckBox = True
        Me.CFromDate.Size = New System.Drawing.Size(152, 23)
        Me.CFromDate.TabIndex = 22
        '
        'lblCDate
        '
        Me.lblCDate.AutoSize = True
        Me.lblCDate.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblCDate.Location = New System.Drawing.Point(12, 111)
        Me.lblCDate.Name = "lblCDate"
        Me.lblCDate.Size = New System.Drawing.Size(92, 17)
        Me.lblCDate.TabIndex = 21
        Me.lblCDate.Text = "检查实际日期："
        '
        'PToDate
        '
        Me.PToDate.Location = New System.Drawing.Point(307, 82)
        Me.PToDate.Name = "PToDate"
        Me.PToDate.ShowCheckBox = True
        Me.PToDate.Size = New System.Drawing.Size(151, 23)
        Me.PToDate.TabIndex = 20
        '
        'lblPFrom
        '
        Me.lblPFrom.AutoSize = True
        Me.lblPFrom.Location = New System.Drawing.Point(133, 85)
        Me.lblPFrom.Name = "lblPFrom"
        Me.lblPFrom.Size = New System.Drawing.Size(0, 17)
        Me.lblPFrom.TabIndex = 18
        '
        'chkLDepartment
        '
        Me.chkLDepartment.BackColor = System.Drawing.SystemColors.Control
        Me.chkLDepartment.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chkLDepartment.ColumnWidth = 75
        Me.chkLDepartment.FormattingEnabled = True
        Me.chkLDepartment.Location = New System.Drawing.Point(645, 20)
        Me.chkLDepartment.Name = "chkLDepartment"
        Me.chkLDepartment.Size = New System.Drawing.Size(185, 108)
        Me.chkLDepartment.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(266, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "检查员："
        '
        'txtChkUser
        '
        Me.txtChkUser.Location = New System.Drawing.Point(331, 46)
        Me.txtChkUser.MaxLength = 100
        Me.txtChkUser.Name = "txtChkUser"
        Me.txtChkUser.Size = New System.Drawing.Size(127, 23)
        Me.txtChkUser.TabIndex = 8
        '
        'drpResult
        '
        Me.drpResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpResult.FormattingEnabled = True
        Me.drpResult.Location = New System.Drawing.Point(87, 46)
        Me.drpResult.Name = "drpResult"
        Me.drpResult.Size = New System.Drawing.Size(150, 25)
        Me.drpResult.TabIndex = 7
        '
        'PFromDate
        '
        Me.PFromDate.Location = New System.Drawing.Point(110, 81)
        Me.PFromDate.Name = "PFromDate"
        Me.PFromDate.ShowCheckBox = True
        Me.PFromDate.Size = New System.Drawing.Size(152, 23)
        Me.PFromDate.TabIndex = 6
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblDepartment.Location = New System.Drawing.Point(595, 20)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(44, 17)
        Me.lblDepartment.TabIndex = 1
        Me.lblDepartment.Text = "部门："
        '
        'lblPDate
        '
        Me.lblPDate.AutoSize = True
        Me.lblPDate.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblPDate.Location = New System.Drawing.Point(12, 85)
        Me.lblPDate.Name = "lblPDate"
        Me.lblPDate.Size = New System.Drawing.Size(92, 17)
        Me.lblPDate.TabIndex = 1
        Me.lblPDate.Text = "生产实际日期："
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblResult.Location = New System.Drawing.Point(12, 48)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(68, 17)
        Me.lblResult.TabIndex = 1
        Me.lblResult.Text = "检查结果："
        '
        'lblMakeNo
        '
        Me.lblMakeNo.AutoSize = True
        Me.lblMakeNo.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblMakeNo.Location = New System.Drawing.Point(12, 20)
        Me.lblMakeNo.Name = "lblMakeNo"
        Me.lblMakeNo.Size = New System.Drawing.Size(68, 17)
        Me.lblMakeNo.TabIndex = 1
        Me.lblMakeNo.Text = "商品作番："
        '
        'txtMakeNo
        '
        Me.txtMakeNo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtMakeNo.Location = New System.Drawing.Point(86, 16)
        Me.txtMakeNo.MaxLength = 30
        Me.txtMakeNo.Name = "txtMakeNo"
        Me.txtMakeNo.Size = New System.Drawing.Size(150, 23)
        Me.txtMakeNo.TabIndex = 2
        '
        'txtSearchGoodsCD
        '
        Me.txtSearchGoodsCD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtSearchGoodsCD.Location = New System.Drawing.Point(331, 16)
        Me.txtSearchGoodsCD.MaxLength = 30
        Me.txtSearchGoodsCD.Name = "txtSearchGoodsCD"
        Me.txtSearchGoodsCD.Size = New System.Drawing.Size(237, 23)
        Me.txtSearchGoodsCD.TabIndex = 1
        '
        'lblGoodsCD
        '
        Me.lblGoodsCD.AutoSize = True
        Me.lblGoodsCD.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblGoodsCD.Location = New System.Drawing.Point(266, 20)
        Me.lblGoodsCD.Name = "lblGoodsCD"
        Me.lblGoodsCD.Size = New System.Drawing.Size(61, 17)
        Me.lblGoodsCD.TabIndex = 1
        Me.lblGoodsCD.Text = "商品CD："
        '
        'gbEdit
        '
        Me.gbEdit.Controls.Add(Me.btnSakujyo)
        Me.gbEdit.Controls.Add(Me.txtPDate)
        Me.gbEdit.Controls.Add(Me.Label9)
        Me.gbEdit.Controls.Add(Me.txtFDate)
        Me.gbEdit.Controls.Add(Me.Label17)
        Me.gbEdit.Controls.Add(Me.txtSharId)
        Me.gbEdit.Controls.Add(Me.Label14)
        Me.gbEdit.Controls.Add(Me.Label15)
        Me.gbEdit.Controls.Add(Me.txtUpStart)
        Me.gbEdit.Controls.Add(Me.txtUpEnd)
        Me.gbEdit.Controls.Add(Me.Label16)
        Me.gbEdit.Controls.Add(Me.txtEDirection)
        Me.gbEdit.Controls.Add(Me.Label13)
        Me.gbEdit.Controls.Add(Me.txtENumber)
        Me.gbEdit.Controls.Add(Me.Label10)
        Me.gbEdit.Controls.Add(Me.txtELine)
        Me.gbEdit.Controls.Add(Me.lblLine)
        Me.gbEdit.Controls.Add(Me.drpState)
        Me.gbEdit.Controls.Add(Me.lblState)
        Me.gbEdit.Controls.Add(Me.btnOpenDetail)
        Me.gbEdit.Controls.Add(Me.btnUpdate)
        Me.gbEdit.Controls.Add(Me.drpEResult)
        Me.gbEdit.Controls.Add(Me.Label8)
        Me.gbEdit.Controls.Add(Me.txtEChkUser)
        Me.gbEdit.Controls.Add(Me.Label2)
        Me.gbEdit.Controls.Add(Me.txtRemark)
        Me.gbEdit.Controls.Add(Me.Label7)
        Me.gbEdit.Controls.Add(Me.txtReultID)
        Me.gbEdit.Controls.Add(Me.txtEndTime)
        Me.gbEdit.Controls.Add(Me.txtEGoodsCd)
        Me.gbEdit.Controls.Add(Me.Label6)
        Me.gbEdit.Controls.Add(Me.Label5)
        Me.gbEdit.Controls.Add(Me.txtEDptMent)
        Me.gbEdit.Controls.Add(Me.lbl)
        Me.gbEdit.Controls.Add(Me.lblDepMent)
        Me.gbEdit.Controls.Add(Me.txtEStartTime)
        Me.gbEdit.Controls.Add(Me.Label3)
        Me.gbEdit.Controls.Add(Me.Label4)
        Me.gbEdit.Controls.Add(Me.txtEMakeNo)
        Me.gbEdit.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbEdit.Font = New System.Drawing.Font("NSimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEdit.Location = New System.Drawing.Point(0, 177)
        Me.gbEdit.Name = "gbEdit"
        Me.gbEdit.Size = New System.Drawing.Size(1008, 184)
        Me.gbEdit.TabIndex = 6
        Me.gbEdit.TabStop = False
        Me.gbEdit.Text = "编辑"
        '
        'btnSakujyo
        '
        Me.btnSakujyo.Location = New System.Drawing.Point(755, 18)
        Me.btnSakujyo.Name = "btnSakujyo"
        Me.btnSakujyo.Size = New System.Drawing.Size(75, 24)
        Me.btnSakujyo.TabIndex = 33
        Me.btnSakujyo.Text = "消除"
        Me.btnSakujyo.UseVisualStyleBackColor = True
        '
        'txtPDate
        '
        Me.txtPDate.Font = New System.Drawing.Font("NSimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPDate.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPDate.Location = New System.Drawing.Point(323, 85)
        Me.txtPDate.MaxLength = 30
        Me.txtPDate.Name = "txtPDate"
        Me.txtPDate.ReadOnly = True
        Me.txtPDate.Size = New System.Drawing.Size(178, 21)
        Me.txtPDate.TabIndex = 32
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(256, 89)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 17)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "纳品时间："
        '
        'txtFDate
        '
        Me.txtFDate.Font = New System.Drawing.Font("NSimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFDate.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtFDate.Location = New System.Drawing.Point(99, 86)
        Me.txtFDate.MaxLength = 30
        Me.txtFDate.Name = "txtFDate"
        Me.txtFDate.ReadOnly = True
        Me.txtFDate.Size = New System.Drawing.Size(150, 21)
        Me.txtFDate.TabIndex = 30
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.Label17.Location = New System.Drawing.Point(12, 87)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 17)
        Me.Label17.TabIndex = 29
        Me.Label17.Text = "生产时间："
        '
        'txtSharId
        '
        Me.txtSharId.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtSharId.Location = New System.Drawing.Point(593, 113)
        Me.txtSharId.MaxLength = 30
        Me.txtSharId.Name = "txtSharId"
        Me.txtSharId.ReadOnly = True
        Me.txtSharId.Size = New System.Drawing.Size(200, 21)
        Me.txtSharId.TabIndex = 28
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.Label14.Location = New System.Drawing.Point(511, 109)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 17)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "继承结果ID："
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.Label15.Location = New System.Drawing.Point(12, 130)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 17)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "再检开始："
        '
        'txtUpStart
        '
        Me.txtUpStart.Font = New System.Drawing.Font("NSimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpStart.Location = New System.Drawing.Point(99, 133)
        Me.txtUpStart.MaxLength = 100
        Me.txtUpStart.Name = "txtUpStart"
        Me.txtUpStart.ReadOnly = True
        Me.txtUpStart.Size = New System.Drawing.Size(150, 21)
        Me.txtUpStart.TabIndex = 25
        '
        'txtUpEnd
        '
        Me.txtUpEnd.Font = New System.Drawing.Font("NSimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpEnd.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtUpEnd.Location = New System.Drawing.Point(323, 132)
        Me.txtUpEnd.MaxLength = 30
        Me.txtUpEnd.Name = "txtUpEnd"
        Me.txtUpEnd.ReadOnly = True
        Me.txtUpEnd.Size = New System.Drawing.Size(178, 21)
        Me.txtUpEnd.TabIndex = 24
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.Label16.Location = New System.Drawing.Point(256, 134)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 17)
        Me.Label16.TabIndex = 23
        Me.Label16.Text = "再检结束："
        '
        'txtEDirection
        '
        Me.txtEDirection.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtEDirection.Location = New System.Drawing.Point(593, 57)
        Me.txtEDirection.MaxLength = 30
        Me.txtEDirection.Name = "txtEDirection"
        Me.txtEDirection.ReadOnly = True
        Me.txtEDirection.Size = New System.Drawing.Size(200, 21)
        Me.txtEDirection.TabIndex = 22
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.Label13.Location = New System.Drawing.Point(511, 60)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 17)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "方向："
        '
        'txtENumber
        '
        Me.txtENumber.Font = New System.Drawing.Font("NSimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtENumber.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtENumber.Location = New System.Drawing.Point(323, 61)
        Me.txtENumber.MaxLength = 30
        Me.txtENumber.Name = "txtENumber"
        Me.txtENumber.ReadOnly = True
        Me.txtENumber.Size = New System.Drawing.Size(178, 21)
        Me.txtENumber.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(256, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 17)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "生产数量："
        '
        'txtELine
        '
        Me.txtELine.Font = New System.Drawing.Font("NSimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtELine.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtELine.Location = New System.Drawing.Point(99, 62)
        Me.txtELine.MaxLength = 30
        Me.txtELine.Name = "txtELine"
        Me.txtELine.ReadOnly = True
        Me.txtELine.Size = New System.Drawing.Size(150, 21)
        Me.txtELine.TabIndex = 18
        '
        'lblLine
        '
        Me.lblLine.AutoSize = True
        Me.lblLine.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblLine.Location = New System.Drawing.Point(12, 65)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(56, 17)
        Me.lblLine.TabIndex = 17
        Me.lblLine.Text = "生产线："
        '
        'drpState
        '
        Me.drpState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpState.FormattingEnabled = True
        Me.drpState.Location = New System.Drawing.Point(593, 152)
        Me.drpState.Name = "drpState"
        Me.drpState.Size = New System.Drawing.Size(150, 20)
        Me.drpState.TabIndex = 16
        Me.drpState.Visible = False
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblState.Location = New System.Drawing.Point(511, 155)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(44, 17)
        Me.lblState.TabIndex = 15
        Me.lblState.Text = "状态："
        Me.lblState.Visible = False
        '
        'btnOpenDetail
        '
        Me.btnOpenDetail.Location = New System.Drawing.Point(674, 18)
        Me.btnOpenDetail.Name = "btnOpenDetail"
        Me.btnOpenDetail.Size = New System.Drawing.Size(75, 24)
        Me.btnOpenDetail.TabIndex = 8
        Me.btnOpenDetail.Text = "查看详细"
        Me.btnOpenDetail.UseVisualStyleBackColor = True
        '
        'drpEResult
        '
        Me.drpEResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpEResult.Font = New System.Drawing.Font("NSimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpEResult.FormattingEnabled = True
        Me.drpEResult.Location = New System.Drawing.Point(99, 158)
        Me.drpEResult.Name = "drpEResult"
        Me.drpEResult.Size = New System.Drawing.Size(150, 20)
        Me.drpEResult.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(256, 157)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 17)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "备注："
        '
        'txtEChkUser
        '
        Me.txtEChkUser.Location = New System.Drawing.Point(593, 86)
        Me.txtEChkUser.MaxLength = 100
        Me.txtEChkUser.Name = "txtEChkUser"
        Me.txtEChkUser.ReadOnly = True
        Me.txtEChkUser.Size = New System.Drawing.Size(200, 21)
        Me.txtEChkUser.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(511, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "检查员："
        '
        'txtRemark
        '
        Me.txtRemark.Font = New System.Drawing.Font("NSimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemark.Location = New System.Drawing.Point(323, 156)
        Me.txtRemark.MaxLength = 100
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(178, 21)
        Me.txtRemark.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(12, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 17)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "检查结果ID："
        '
        'txtReultID
        '
        Me.txtReultID.Font = New System.Drawing.Font("NSimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReultID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtReultID.Location = New System.Drawing.Point(99, 14)
        Me.txtReultID.MaxLength = 30
        Me.txtReultID.Name = "txtReultID"
        Me.txtReultID.ReadOnly = True
        Me.txtReultID.Size = New System.Drawing.Size(150, 21)
        Me.txtReultID.TabIndex = 8
        '
        'txtEndTime
        '
        Me.txtEndTime.Font = New System.Drawing.Font("NSimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndTime.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtEndTime.Location = New System.Drawing.Point(323, 108)
        Me.txtEndTime.MaxLength = 30
        Me.txtEndTime.Name = "txtEndTime"
        Me.txtEndTime.ReadOnly = True
        Me.txtEndTime.Size = New System.Drawing.Size(178, 21)
        Me.txtEndTime.TabIndex = 8
        '
        'txtEGoodsCd
        '
        Me.txtEGoodsCd.Font = New System.Drawing.Font("NSimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEGoodsCd.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtEGoodsCd.Location = New System.Drawing.Point(323, 37)
        Me.txtEGoodsCd.MaxLength = 30
        Me.txtEGoodsCd.Name = "txtEGoodsCd"
        Me.txtEGoodsCd.ReadOnly = True
        Me.txtEGoodsCd.Size = New System.Drawing.Size(178, 21)
        Me.txtEGoodsCd.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(12, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 17)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "检查结果："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(256, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 17)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "结束时间："
        '
        'txtEDptMent
        '
        Me.txtEDptMent.Font = New System.Drawing.Font("NSimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEDptMent.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtEDptMent.Location = New System.Drawing.Point(323, 13)
        Me.txtEDptMent.MaxLength = 30
        Me.txtEDptMent.Name = "txtEDptMent"
        Me.txtEDptMent.ReadOnly = True
        Me.txtEDptMent.Size = New System.Drawing.Size(178, 21)
        Me.txtEDptMent.TabIndex = 7
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lbl.Location = New System.Drawing.Point(256, 43)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(61, 17)
        Me.lbl.TabIndex = 7
        Me.lbl.Text = "商品CD："
        '
        'lblDepMent
        '
        Me.lblDepMent.AutoSize = True
        Me.lblDepMent.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.lblDepMent.Location = New System.Drawing.Point(256, 21)
        Me.lblDepMent.Name = "lblDepMent"
        Me.lblDepMent.Size = New System.Drawing.Size(44, 17)
        Me.lblDepMent.TabIndex = 1
        Me.lblDepMent.Text = "部门："
        '
        'txtEStartTime
        '
        Me.txtEStartTime.Font = New System.Drawing.Font("NSimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEStartTime.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtEStartTime.Location = New System.Drawing.Point(99, 109)
        Me.txtEStartTime.MaxLength = 30
        Me.txtEStartTime.Name = "txtEStartTime"
        Me.txtEStartTime.ReadOnly = True
        Me.txtEStartTime.Size = New System.Drawing.Size(150, 21)
        Me.txtEStartTime.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(12, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "开始时间："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(12, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 17)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "商品作番："
        '
        'txtEMakeNo
        '
        Me.txtEMakeNo.Font = New System.Drawing.Font("NSimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEMakeNo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtEMakeNo.Location = New System.Drawing.Point(99, 38)
        Me.txtEMakeNo.MaxLength = 30
        Me.txtEMakeNo.Name = "txtEMakeNo"
        Me.txtEMakeNo.ReadOnly = True
        Me.txtEMakeNo.Size = New System.Drawing.Size(150, 21)
        Me.txtEMakeNo.TabIndex = 2
        '
        'dgvChkResult
        '
        Me.dgvChkResult.AllowUserToAddRows = False
        Me.dgvChkResult.AllowUserToOrderColumns = True
        Me.dgvChkResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvChkResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvChkResult.Location = New System.Drawing.Point(0, 361)
        Me.dgvChkResult.Name = "dgvChkResult"
        Me.dgvChkResult.ReadOnly = True
        Me.dgvChkResult.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvChkResult.RowTemplate.Height = 21
        Me.dgvChkResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvChkResult.Size = New System.Drawing.Size(1008, 301)
        Me.dgvChkResult.TabIndex = 7
        '
        'ResultModify
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(1008, 662)
        Me.Controls.Add(Me.dgvChkResult)
        Me.Controls.Add(Me.gbEdit)
        Me.Controls.Add(Me.gbSearch)
        Me.Controls.Add(Me.pnlAction)
        Me.Name = "ResultModify"
        Me.Text = "检查结果修正"
        Me.pnlAction.ResumeLayout(False)
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        Me.gbEdit.ResumeLayout(False)
        Me.gbEdit.PerformLayout()
        CType(Me.dgvChkResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlAction As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnReturn As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents gbSearch As System.Windows.Forms.GroupBox
    Friend WithEvents lblDepartment As System.Windows.Forms.Label
    Friend WithEvents lblPDate As System.Windows.Forms.Label
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents lblMakeNo As System.Windows.Forms.Label
    Friend WithEvents txtMakeNo As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchGoodsCD As System.Windows.Forms.TextBox
    Friend WithEvents lblGoodsCD As System.Windows.Forms.Label
    Friend WithEvents PFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents drpResult As System.Windows.Forms.ComboBox
    Friend WithEvents gbEdit As System.Windows.Forms.GroupBox
    Friend WithEvents lblDepMent As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEStartTime As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEChkUser As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEMakeNo As System.Windows.Forms.TextBox
    Friend WithEvents txtEDptMent As System.Windows.Forms.TextBox
    Friend WithEvents txtEGoodsCd As System.Windows.Forms.TextBox
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtChkUser As System.Windows.Forms.TextBox
    Friend WithEvents txtEndTime As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtReultID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgvChkResult As System.Windows.Forms.DataGridView
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents drpEResult As System.Windows.Forms.ComboBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnOpenDetail As System.Windows.Forms.Button
    Friend WithEvents chkLDepartment As Lixil.AvoidMissSystem.WinUI.Common.ColorCodedCheckedListBox
    Friend WithEvents PToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPFrom As System.Windows.Forms.Label
    Friend WithEvents CToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCFrom As System.Windows.Forms.Label
    Friend WithEvents CFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCDate As System.Windows.Forms.Label
    Friend WithEvents drpState As System.Windows.Forms.ComboBox
    Friend WithEvents lblState As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtELine As System.Windows.Forms.TextBox
    Friend WithEvents lblLine As System.Windows.Forms.Label
    Friend WithEvents txtSharId As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtUpStart As System.Windows.Forms.TextBox
    Friend WithEvents txtUpEnd As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtEDirection As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtENumber As System.Windows.Forms.TextBox
    Friend WithEvents txtPDate As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFDate As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnSakujyo As System.Windows.Forms.Button
    Friend WithEvents cbLine_name As ComboBox
End Class
