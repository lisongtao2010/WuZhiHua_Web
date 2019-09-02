<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MsMaintenanceAuthorityForm
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
        Me.CheckedListDepartmentAccess = New Lixil.AvoidMissSystem.WinUI.MsMaintenanceAuthorityForm.ColorCodedCheckedListBox
        Me.CheckedListFunctionAccess = New Lixil.AvoidMissSystem.WinUI.MsMaintenanceAuthorityForm.ColorCodedCheckedListBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.lblTemplate = New System.Windows.Forms.Label
        Me.lblFunctionAccess = New System.Windows.Forms.Label
        Me.lblTemplateDown = New System.Windows.Forms.LinkLabel
        Me.btnExcute = New System.Windows.Forms.Button
        Me.lblDepartmentAccess = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.txtFilePath = New System.Windows.Forms.TextBox
        Me.rdoExport = New System.Windows.Forms.RadioButton
        Me.rdoImport = New System.Windows.Forms.RadioButton
        Me.btnFilePath = New System.Windows.Forms.Button
        Me.pnlAction = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnReturn = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.txtConfimPassword = New System.Windows.Forms.TextBox
        Me.txtNewPassword = New System.Windows.Forms.TextBox
        Me.lblConfimPW = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.lblNewPassword = New System.Windows.Forms.Label
        Me.dgvAuthority = New System.Windows.Forms.DataGridView
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblUser = New System.Windows.Forms.Label
        Me.lblPassword = New System.Windows.Forms.Label
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.gbSearch = New System.Windows.Forms.GroupBox
        Me.cbSearchAdmin = New System.Windows.Forms.CheckBox
        Me.CheckedListSearchDepartmentAccess = New Lixil.AvoidMissSystem.WinUI.MsMaintenanceAuthorityForm.ColorCodedCheckedListBox
        Me.lblSearchDepartmentAccess = New System.Windows.Forms.Label
        Me.CheckedListSearchFunctionAccess = New Lixil.AvoidMissSystem.WinUI.MsMaintenanceAuthorityForm.ColorCodedCheckedListBox
        Me.lblSearchFunctionAccess = New System.Windows.Forms.Label
        Me.txtSearchUser = New System.Windows.Forms.TextBox
        Me.lblSearchUser = New System.Windows.Forms.Label
        Me.gbEdit = New System.Windows.Forms.GroupBox
        Me.cbEditAdmin = New System.Windows.Forms.CheckBox
        Me.txtHidId = New System.Windows.Forms.TextBox
        Me.Panel3.SuspendLayout()
        Me.pnlAction.SuspendLayout()
        CType(Me.dgvAuthority, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.gbSearch.SuspendLayout()
        Me.gbEdit.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckedListDepartmentAccess
        '
        Me.CheckedListDepartmentAccess.FormattingEnabled = True
        Me.CheckedListDepartmentAccess.Items.AddRange(New Object() {"一部", "二部", "三部"})
        Me.CheckedListDepartmentAccess.Location = New System.Drawing.Point(725, 20)
        Me.CheckedListDepartmentAccess.Name = "CheckedListDepartmentAccess"
        Me.CheckedListDepartmentAccess.Size = New System.Drawing.Size(100, 76)
        Me.CheckedListDepartmentAccess.TabIndex = 25
        '
        'CheckedListFunctionAccess
        '
        Me.CheckedListFunctionAccess.FormattingEnabled = True
        Me.CheckedListFunctionAccess.Items.AddRange(New Object() {"图片MS", "治具MS", "基础MS", "检查结果修正"})
        Me.CheckedListFunctionAccess.Location = New System.Drawing.Point(530, 20)
        Me.CheckedListFunctionAccess.Name = "CheckedListFunctionAccess"
        Me.CheckedListFunctionAccess.Size = New System.Drawing.Size(100, 112)
        Me.CheckedListFunctionAccess.TabIndex = 24
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(417, 2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 31)
        Me.btnSearch.TabIndex = 0
        Me.btnSearch.Text = "查询"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblTemplate
        '
        Me.lblTemplate.AutoSize = True
        Me.lblTemplate.Location = New System.Drawing.Point(678, 13)
        Me.lblTemplate.Name = "lblTemplate"
        Me.lblTemplate.Size = New System.Drawing.Size(53, 12)
        Me.lblTemplate.TabIndex = 10
        Me.lblTemplate.Text = "模板下载"
        '
        'lblFunctionAccess
        '
        Me.lblFunctionAccess.AutoSize = True
        Me.lblFunctionAccess.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFunctionAccess.Location = New System.Drawing.Point(460, 20)
        Me.lblFunctionAccess.Name = "lblFunctionAccess"
        Me.lblFunctionAccess.Size = New System.Drawing.Size(68, 17)
        Me.lblFunctionAccess.TabIndex = 6
        Me.lblFunctionAccess.Text = "机能权限："
        '
        'lblTemplateDown
        '
        Me.lblTemplateDown.AutoSize = True
        Me.lblTemplateDown.Location = New System.Drawing.Point(732, 13)
        Me.lblTemplateDown.Name = "lblTemplateDown"
        Me.lblTemplateDown.Size = New System.Drawing.Size(91, 12)
        Me.lblTemplateDown.TabIndex = 33
        Me.lblTemplateDown.TabStop = True
        Me.lblTemplateDown.Text = "权限MS模版.XLS"
        '
        'btnExcute
        '
        Me.btnExcute.Location = New System.Drawing.Point(735, 39)
        Me.btnExcute.Name = "btnExcute"
        Me.btnExcute.Size = New System.Drawing.Size(75, 23)
        Me.btnExcute.TabIndex = 36
        Me.btnExcute.Text = "执行"
        Me.btnExcute.UseVisualStyleBackColor = True
        '
        'lblDepartmentAccess
        '
        Me.lblDepartmentAccess.AutoSize = True
        Me.lblDepartmentAccess.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDepartmentAccess.Location = New System.Drawing.Point(652, 20)
        Me.lblDepartmentAccess.Name = "lblDepartmentAccess"
        Me.lblDepartmentAccess.Size = New System.Drawing.Size(68, 17)
        Me.lblDepartmentAccess.TabIndex = 8
        Me.lblDepartmentAccess.Text = "部门权限："
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblTemplate)
        Me.Panel3.Controls.Add(Me.lblTemplateDown)
        Me.Panel3.Controls.Add(Me.txtFilePath)
        Me.Panel3.Controls.Add(Me.rdoExport)
        Me.Panel3.Controls.Add(Me.rdoImport)
        Me.Panel3.Controls.Add(Me.btnFilePath)
        Me.Panel3.Controls.Add(Me.btnExcute)
        Me.Panel3.Location = New System.Drawing.Point(28, 551)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(837, 62)
        Me.Panel3.TabIndex = 8
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(116, 39)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(617, 19)
        Me.txtFilePath.TabIndex = 35
        '
        'rdoExport
        '
        Me.rdoExport.AutoSize = True
        Me.rdoExport.Location = New System.Drawing.Point(116, 9)
        Me.rdoExport.Name = "rdoExport"
        Me.rdoExport.Size = New System.Drawing.Size(71, 16)
        Me.rdoExport.TabIndex = 32
        Me.rdoExport.TabStop = True
        Me.rdoExport.Text = "批量导出"
        Me.rdoExport.UseVisualStyleBackColor = True
        '
        'rdoImport
        '
        Me.rdoImport.AutoSize = True
        Me.rdoImport.Location = New System.Drawing.Point(25, 9)
        Me.rdoImport.Name = "rdoImport"
        Me.rdoImport.Size = New System.Drawing.Size(71, 16)
        Me.rdoImport.TabIndex = 31
        Me.rdoImport.TabStop = True
        Me.rdoImport.Text = "批量导入"
        Me.rdoImport.UseVisualStyleBackColor = True
        '
        'btnFilePath
        '
        Me.btnFilePath.Location = New System.Drawing.Point(25, 37)
        Me.btnFilePath.Name = "btnFilePath"
        Me.btnFilePath.Size = New System.Drawing.Size(75, 23)
        Me.btnFilePath.TabIndex = 34
        Me.btnFilePath.Text = "选择路径"
        Me.btnFilePath.UseVisualStyleBackColor = True
        '
        'pnlAction
        '
        Me.pnlAction.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlAction.Controls.Add(Me.btnClose)
        Me.pnlAction.Controls.Add(Me.btnReturn)
        Me.pnlAction.Controls.Add(Me.btnSearch)
        Me.pnlAction.Controls.Add(Me.btnClear)
        Me.pnlAction.Controls.Add(Me.btnDelete)
        Me.pnlAction.Controls.Add(Me.btnSave)
        Me.pnlAction.Location = New System.Drawing.Point(-30, 4)
        Me.pnlAction.Name = "pnlAction"
        Me.pnlAction.Size = New System.Drawing.Size(953, 36)
        Me.pnlAction.TabIndex = 9
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnClose.Location = New System.Drawing.Point(817, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 31)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "退出"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnReturn
        '
        Me.btnReturn.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnReturn.Location = New System.Drawing.Point(737, 2)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(75, 31)
        Me.btnReturn.TabIndex = 4
        Me.btnReturn.Text = "返回"
        Me.btnReturn.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnClear.Location = New System.Drawing.Point(657, 2)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 31)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "清空"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(577, 2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 31)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "删除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSave.Location = New System.Drawing.Point(497, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 31)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "保存"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtConfimPassword
        '
        Me.txtConfimPassword.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtConfimPassword.Location = New System.Drawing.Point(87, 110)
        Me.txtConfimPassword.MaxLength = 30
        Me.txtConfimPassword.Name = "txtConfimPassword"
        Me.txtConfimPassword.Size = New System.Drawing.Size(159, 23)
        Me.txtConfimPassword.TabIndex = 22
        '
        'txtNewPassword
        '
        Me.txtNewPassword.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtNewPassword.Location = New System.Drawing.Point(87, 80)
        Me.txtNewPassword.MaxLength = 30
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.Size = New System.Drawing.Size(159, 23)
        Me.txtNewPassword.TabIndex = 21
        '
        'lblConfimPW
        '
        Me.lblConfimPW.AutoSize = True
        Me.lblConfimPW.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblConfimPW.Location = New System.Drawing.Point(6, 114)
        Me.lblConfimPW.Name = "lblConfimPW"
        Me.lblConfimPW.Size = New System.Drawing.Size(80, 17)
        Me.lblConfimPW.TabIndex = 4
        Me.lblConfimPW.Text = "确认新密码："
        '
        'txtPassword
        '
        Me.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPassword.Location = New System.Drawing.Point(87, 50)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(159, 23)
        Me.txtPassword.TabIndex = 5
        '
        'lblNewPassword
        '
        Me.lblNewPassword.AutoSize = True
        Me.lblNewPassword.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblNewPassword.Location = New System.Drawing.Point(6, 84)
        Me.lblNewPassword.Name = "lblNewPassword"
        Me.lblNewPassword.Size = New System.Drawing.Size(56, 17)
        Me.lblNewPassword.TabIndex = 4
        Me.lblNewPassword.Text = "新密码："
        '
        'dgvAuthority
        '
        Me.dgvAuthority.AllowUserToAddRows = False
        Me.dgvAuthority.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAuthority.Location = New System.Drawing.Point(0, 19)
        Me.dgvAuthority.Name = "dgvAuthority"
        Me.dgvAuthority.RowTemplate.Height = 21
        Me.dgvAuthority.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAuthority.Size = New System.Drawing.Size(837, 268)
        Me.dgvAuthority.TabIndex = 30
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvAuthority)
        Me.Panel2.Location = New System.Drawing.Point(28, 271)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(837, 273)
        Me.Panel2.TabIndex = 7
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblUser.Location = New System.Drawing.Point(6, 24)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(56, 17)
        Me.lblUser.TabIndex = 1
        Me.lblUser.Text = "登录名："
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblPassword.Location = New System.Drawing.Point(6, 54)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(56, 17)
        Me.lblPassword.TabIndex = 4
        Me.lblPassword.Text = "旧密码："
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(87, 20)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(160, 23)
        Me.txtUser.TabIndex = 20
        '
        'gbSearch
        '
        Me.gbSearch.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.gbSearch.Controls.Add(Me.cbSearchAdmin)
        Me.gbSearch.Controls.Add(Me.CheckedListSearchDepartmentAccess)
        Me.gbSearch.Controls.Add(Me.lblSearchDepartmentAccess)
        Me.gbSearch.Controls.Add(Me.CheckedListSearchFunctionAccess)
        Me.gbSearch.Controls.Add(Me.lblSearchFunctionAccess)
        Me.gbSearch.Controls.Add(Me.txtSearchUser)
        Me.gbSearch.Controls.Add(Me.lblSearchUser)
        Me.gbSearch.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.gbSearch.Location = New System.Drawing.Point(28, 37)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.Size = New System.Drawing.Size(837, 112)
        Me.gbSearch.TabIndex = 10
        Me.gbSearch.TabStop = False
        Me.gbSearch.Text = "查询"
        '
        'cbSearchAdmin
        '
        Me.cbSearchAdmin.AutoSize = True
        Me.cbSearchAdmin.Font = New System.Drawing.Font("Microsoft YaHei", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSearchAdmin.Location = New System.Drawing.Point(359, 20)
        Me.cbSearchAdmin.Name = "cbSearchAdmin"
        Me.cbSearchAdmin.Size = New System.Drawing.Size(93, 23)
        Me.cbSearchAdmin.TabIndex = 12
        Me.cbSearchAdmin.Text = "管理员权限"
        Me.cbSearchAdmin.UseVisualStyleBackColor = True
        '
        'CheckedListSearchDepartmentAccess
        '
        Me.CheckedListSearchDepartmentAccess.FormattingEnabled = True
        Me.CheckedListSearchDepartmentAccess.Items.AddRange(New Object() {"一部", "二部", "三部"})
        Me.CheckedListSearchDepartmentAccess.Location = New System.Drawing.Point(725, 11)
        Me.CheckedListSearchDepartmentAccess.Name = "CheckedListSearchDepartmentAccess"
        Me.CheckedListSearchDepartmentAccess.Size = New System.Drawing.Size(100, 94)
        Me.CheckedListSearchDepartmentAccess.TabIndex = 14
        '
        'lblSearchDepartmentAccess
        '
        Me.lblSearchDepartmentAccess.AutoSize = True
        Me.lblSearchDepartmentAccess.Font = New System.Drawing.Font("Microsoft YaHei", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchDepartmentAccess.Location = New System.Drawing.Point(653, 20)
        Me.lblSearchDepartmentAccess.Name = "lblSearchDepartmentAccess"
        Me.lblSearchDepartmentAccess.Size = New System.Drawing.Size(74, 19)
        Me.lblSearchDepartmentAccess.TabIndex = 15
        Me.lblSearchDepartmentAccess.Text = "部门权限："
        '
        'CheckedListSearchFunctionAccess
        '
        Me.CheckedListSearchFunctionAccess.FormattingEnabled = True
        Me.CheckedListSearchFunctionAccess.Items.AddRange(New Object() {"图片MS", "治具MS", "基础MS", "检查结果修正"})
        Me.CheckedListSearchFunctionAccess.Location = New System.Drawing.Point(530, 11)
        Me.CheckedListSearchFunctionAccess.Name = "CheckedListSearchFunctionAccess"
        Me.CheckedListSearchFunctionAccess.Size = New System.Drawing.Size(100, 94)
        Me.CheckedListSearchFunctionAccess.TabIndex = 13
        '
        'lblSearchFunctionAccess
        '
        Me.lblSearchFunctionAccess.AutoSize = True
        Me.lblSearchFunctionAccess.Font = New System.Drawing.Font("Microsoft YaHei", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchFunctionAccess.Location = New System.Drawing.Point(461, 20)
        Me.lblSearchFunctionAccess.Name = "lblSearchFunctionAccess"
        Me.lblSearchFunctionAccess.Size = New System.Drawing.Size(74, 19)
        Me.lblSearchFunctionAccess.TabIndex = 13
        Me.lblSearchFunctionAccess.Text = "机能权限："
        '
        'txtSearchUser
        '
        Me.txtSearchUser.Location = New System.Drawing.Point(87, 19)
        Me.txtSearchUser.Name = "txtSearchUser"
        Me.txtSearchUser.Size = New System.Drawing.Size(160, 23)
        Me.txtSearchUser.TabIndex = 11
        '
        'lblSearchUser
        '
        Me.lblSearchUser.AutoSize = True
        Me.lblSearchUser.Font = New System.Drawing.Font("Microsoft YaHei", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchUser.Location = New System.Drawing.Point(6, 20)
        Me.lblSearchUser.Name = "lblSearchUser"
        Me.lblSearchUser.Size = New System.Drawing.Size(61, 19)
        Me.lblSearchUser.TabIndex = 11
        Me.lblSearchUser.Text = "登录名："
        '
        'gbEdit
        '
        Me.gbEdit.Controls.Add(Me.cbEditAdmin)
        Me.gbEdit.Controls.Add(Me.CheckedListDepartmentAccess)
        Me.gbEdit.Controls.Add(Me.lblDepartmentAccess)
        Me.gbEdit.Controls.Add(Me.lblUser)
        Me.gbEdit.Controls.Add(Me.txtHidId)
        Me.gbEdit.Controls.Add(Me.txtUser)
        Me.gbEdit.Controls.Add(Me.CheckedListFunctionAccess)
        Me.gbEdit.Controls.Add(Me.lblPassword)
        Me.gbEdit.Controls.Add(Me.lblFunctionAccess)
        Me.gbEdit.Controls.Add(Me.lblNewPassword)
        Me.gbEdit.Controls.Add(Me.txtConfimPassword)
        Me.gbEdit.Controls.Add(Me.txtPassword)
        Me.gbEdit.Controls.Add(Me.txtNewPassword)
        Me.gbEdit.Controls.Add(Me.lblConfimPW)
        Me.gbEdit.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.gbEdit.Location = New System.Drawing.Point(28, 141)
        Me.gbEdit.Name = "gbEdit"
        Me.gbEdit.Size = New System.Drawing.Size(837, 141)
        Me.gbEdit.TabIndex = 11
        Me.gbEdit.TabStop = False
        Me.gbEdit.Text = "编辑"
        '
        'cbEditAdmin
        '
        Me.cbEditAdmin.AutoSize = True
        Me.cbEditAdmin.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cbEditAdmin.Location = New System.Drawing.Point(358, 20)
        Me.cbEditAdmin.Name = "cbEditAdmin"
        Me.cbEditAdmin.Size = New System.Drawing.Size(87, 21)
        Me.cbEditAdmin.TabIndex = 23
        Me.cbEditAdmin.Text = "管理员权限"
        Me.cbEditAdmin.UseVisualStyleBackColor = True
        '
        'txtHidId
        '
        Me.txtHidId.Location = New System.Drawing.Point(671, 110)
        Me.txtHidId.Name = "txtHidId"
        Me.txtHidId.Size = New System.Drawing.Size(160, 23)
        Me.txtHidId.TabIndex = 3
        Me.txtHidId.Visible = False
        '
        'MsMaintenanceAuthorityForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(902, 631)
        Me.Controls.Add(Me.gbEdit)
        Me.Controls.Add(Me.gbSearch)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlAction)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "MsMaintenanceAuthorityForm"
        Me.Text = "权限维护"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlAction.ResumeLayout(False)
        CType(Me.dgvAuthority, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        Me.gbEdit.ResumeLayout(False)
        Me.gbEdit.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblTemplate As System.Windows.Forms.Label
    Friend WithEvents lblFunctionAccess As System.Windows.Forms.Label
    Friend WithEvents lblTemplateDown As System.Windows.Forms.LinkLabel
    Friend WithEvents btnExcute As System.Windows.Forms.Button
    Friend WithEvents lblDepartmentAccess As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
    Friend WithEvents rdoExport As System.Windows.Forms.RadioButton
    Friend WithEvents rdoImport As System.Windows.Forms.RadioButton
    Friend WithEvents btnFilePath As System.Windows.Forms.Button
    Friend WithEvents pnlAction As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnReturn As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtConfimPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtNewPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblConfimPW As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblNewPassword As System.Windows.Forms.Label
    Friend WithEvents dgvAuthority As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents gbSearch As System.Windows.Forms.GroupBox
    Friend WithEvents txtSearchUser As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchUser As System.Windows.Forms.Label
    Friend WithEvents lblSearchDepartmentAccess As System.Windows.Forms.Label
    Friend WithEvents lblSearchFunctionAccess As System.Windows.Forms.Label
    Friend WithEvents gbEdit As System.Windows.Forms.GroupBox
    Friend WithEvents cbSearchAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents cbEditAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents CheckedListDepartmentAccess As Lixil.AvoidMissSystem.WinUI.MsMaintenanceAuthorityForm.ColorCodedCheckedListBox
    Friend WithEvents CheckedListFunctionAccess As Lixil.AvoidMissSystem.WinUI.MsMaintenanceAuthorityForm.ColorCodedCheckedListBox
    Friend WithEvents CheckedListSearchDepartmentAccess As Lixil.AvoidMissSystem.WinUI.MsMaintenanceAuthorityForm.ColorCodedCheckedListBox
    Friend WithEvents CheckedListSearchFunctionAccess As Lixil.AvoidMissSystem.WinUI.MsMaintenanceAuthorityForm.ColorCodedCheckedListBox
    Friend WithEvents txtHidId As System.Windows.Forms.TextBox

End Class