<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class msBaobiao
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.rdoJCJGMS = New System.Windows.Forms.RadioButton
        Me.dgvWhere = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.rdoCheckResult = New System.Windows.Forms.RadioButton
        Me.rdoWJCYL = New System.Windows.Forms.RadioButton
        Me.rdoPicture = New System.Windows.Forms.RadioButton
        Me.rdoTools = New System.Windows.Forms.RadioButton
        Me.rdoXM = New System.Windows.Forms.RadioButton
        Me.btnOutExcel2010 = New System.Windows.Forms.Button
        Me.dgvList = New System.Windows.Forms.DataGridView
        Me.btnOutExcel2003 = New System.Windows.Forms.Button
        Me.btnList = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.rdoOr = New System.Windows.Forms.RadioButton
        Me.btnCSV = New System.Windows.Forms.Button
        Me.rdoMissCheckListNewAndOld = New System.Windows.Forms.RadioButton
        Me.rdoNewOldCheckResultMs = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbCheckMS = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.gbBumen = New System.Windows.Forms.GroupBox
        Me.cbBumon4 = New System.Windows.Forms.CheckBox
        Me.cbBumon3 = New System.Windows.Forms.CheckBox
        Me.cbBumon2 = New System.Windows.Forms.CheckBox
        Me.cbBumon1 = New System.Windows.Forms.CheckBox
        CType(Me.dgvWhere, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbBumen.SuspendLayout()
        Me.SuspendLayout()
        '
        'rdoJCJGMS
        '
        Me.rdoJCJGMS.AutoSize = True
        Me.rdoJCJGMS.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoJCJGMS.ForeColor = System.Drawing.Color.Blue
        Me.rdoJCJGMS.Location = New System.Drawing.Point(17, 18)
        Me.rdoJCJGMS.Name = "rdoJCJGMS"
        Me.rdoJCJGMS.Size = New System.Drawing.Size(123, 17)
        Me.rdoJCJGMS.TabIndex = 0
        Me.rdoJCJGMS.TabStop = True
        Me.rdoJCJGMS.Text = "检查结果明细表"
        Me.rdoJCJGMS.UseVisualStyleBackColor = True
        '
        'dgvWhere
        '
        Me.dgvWhere.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWhere.Location = New System.Drawing.Point(11, 131)
        Me.dgvWhere.Name = "dgvWhere"
        Me.dgvWhere.RowTemplate.Height = 21
        Me.dgvWhere.Size = New System.Drawing.Size(1262, 68)
        Me.dgvWhere.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label1.Location = New System.Drawing.Point(12, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(691, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "出力条件 在下边列表中第一行输入值， 如果有值 就被当作检索条件（只有第一行有效）  日期区间检索格式 9999/99/99#9999/99/99"
        '
        'rdoCheckResult
        '
        Me.rdoCheckResult.AutoSize = True
        Me.rdoCheckResult.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoCheckResult.ForeColor = System.Drawing.Color.Blue
        Me.rdoCheckResult.Location = New System.Drawing.Point(148, 18)
        Me.rdoCheckResult.Name = "rdoCheckResult"
        Me.rdoCheckResult.Size = New System.Drawing.Size(123, 17)
        Me.rdoCheckResult.TabIndex = 3
        Me.rdoCheckResult.TabStop = True
        Me.rdoCheckResult.Text = "检查结果汇总表"
        Me.rdoCheckResult.UseVisualStyleBackColor = True
        '
        'rdoWJCYL
        '
        Me.rdoWJCYL.AutoSize = True
        Me.rdoWJCYL.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoWJCYL.ForeColor = System.Drawing.Color.Blue
        Me.rdoWJCYL.Location = New System.Drawing.Point(273, 18)
        Me.rdoWJCYL.Name = "rdoWJCYL"
        Me.rdoWJCYL.Size = New System.Drawing.Size(109, 17)
        Me.rdoWJCYL.TabIndex = 4
        Me.rdoWJCYL.TabStop = True
        Me.rdoWJCYL.Text = "未检查一览表"
        Me.rdoWJCYL.UseVisualStyleBackColor = True
        '
        'rdoPicture
        '
        Me.rdoPicture.AutoSize = True
        Me.rdoPicture.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoPicture.ForeColor = System.Drawing.Color.Blue
        Me.rdoPicture.Location = New System.Drawing.Point(403, 18)
        Me.rdoPicture.Name = "rdoPicture"
        Me.rdoPicture.Size = New System.Drawing.Size(53, 17)
        Me.rdoPicture.TabIndex = 5
        Me.rdoPicture.TabStop = True
        Me.rdoPicture.Text = "图片"
        Me.rdoPicture.UseVisualStyleBackColor = True
        '
        'rdoTools
        '
        Me.rdoTools.AutoSize = True
        Me.rdoTools.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoTools.ForeColor = System.Drawing.Color.Blue
        Me.rdoTools.Location = New System.Drawing.Point(478, 18)
        Me.rdoTools.Name = "rdoTools"
        Me.rdoTools.Size = New System.Drawing.Size(100, 17)
        Me.rdoTools.TabIndex = 6
        Me.rdoTools.TabStop = True
        Me.rdoTools.Text = "治具 一览表"
        Me.rdoTools.UseVisualStyleBackColor = True
        '
        'rdoXM
        '
        Me.rdoXM.AutoSize = True
        Me.rdoXM.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoXM.ForeColor = System.Drawing.Color.Blue
        Me.rdoXM.Location = New System.Drawing.Point(604, 18)
        Me.rdoXM.Name = "rdoXM"
        Me.rdoXM.Size = New System.Drawing.Size(81, 17)
        Me.rdoXM.TabIndex = 7
        Me.rdoXM.TabStop = True
        Me.rdoXM.Text = "检查项目"
        Me.rdoXM.UseVisualStyleBackColor = True
        '
        'btnOutExcel2010
        '
        Me.btnOutExcel2010.Location = New System.Drawing.Point(860, 204)
        Me.btnOutExcel2010.Name = "btnOutExcel2010"
        Me.btnOutExcel2010.Size = New System.Drawing.Size(133, 23)
        Me.btnOutExcel2010.TabIndex = 8
        Me.btnOutExcel2010.Text = "出力Excel2007以上"
        Me.btnOutExcel2010.UseVisualStyleBackColor = True
        '
        'dgvList
        '
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvList.Location = New System.Drawing.Point(11, 230)
        Me.dgvList.Name = "dgvList"
        Me.dgvList.RowTemplate.Height = 21
        Me.dgvList.Size = New System.Drawing.Size(1003, 431)
        Me.dgvList.TabIndex = 9
        '
        'btnOutExcel2003
        '
        Me.btnOutExcel2003.Location = New System.Drawing.Point(747, 204)
        Me.btnOutExcel2003.Name = "btnOutExcel2003"
        Me.btnOutExcel2003.Size = New System.Drawing.Size(107, 23)
        Me.btnOutExcel2003.TabIndex = 10
        Me.btnOutExcel2003.Text = "出力Excel2003"
        Me.btnOutExcel2003.UseVisualStyleBackColor = True
        '
        'btnList
        '
        Me.btnList.Location = New System.Drawing.Point(442, 204)
        Me.btnList.Name = "btnList"
        Me.btnList.Size = New System.Drawing.Size(107, 23)
        Me.btnList.TabIndex = 11
        Me.btnList.Text = "浏览"
        Me.btnList.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 215)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "数据一览"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Controls.Add(Me.rdoOr)
        Me.Panel1.Location = New System.Drawing.Point(747, 99)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(260, 26)
        Me.Panel1.TabIndex = 13
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(129, 7)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(41, 16)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "and"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'rdoOr
        '
        Me.rdoOr.AutoSize = True
        Me.rdoOr.Location = New System.Drawing.Point(63, 7)
        Me.rdoOr.Name = "rdoOr"
        Me.rdoOr.Size = New System.Drawing.Size(33, 16)
        Me.rdoOr.TabIndex = 0
        Me.rdoOr.Text = "or"
        Me.rdoOr.UseVisualStyleBackColor = True
        '
        'btnCSV
        '
        Me.btnCSV.Location = New System.Drawing.Point(558, 204)
        Me.btnCSV.Name = "btnCSV"
        Me.btnCSV.Size = New System.Drawing.Size(183, 23)
        Me.btnCSV.TabIndex = 14
        Me.btnCSV.Text = "CSV(和Excel版本没关系)"
        Me.btnCSV.UseVisualStyleBackColor = True
        '
        'rdoMissCheckListNewAndOld
        '
        Me.rdoMissCheckListNewAndOld.AutoSize = True
        Me.rdoMissCheckListNewAndOld.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoMissCheckListNewAndOld.ForeColor = System.Drawing.Color.Blue
        Me.rdoMissCheckListNewAndOld.Location = New System.Drawing.Point(273, 60)
        Me.rdoMissCheckListNewAndOld.Name = "rdoMissCheckListNewAndOld"
        Me.rdoMissCheckListNewAndOld.Size = New System.Drawing.Size(123, 17)
        Me.rdoMissCheckListNewAndOld.TabIndex = 15
        Me.rdoMissCheckListNewAndOld.TabStop = True
        Me.rdoMissCheckListNewAndOld.Text = "新旧未检查一览"
        Me.rdoMissCheckListNewAndOld.UseVisualStyleBackColor = True
        '
        'rdoNewOldCheckResultMs
        '
        Me.rdoNewOldCheckResultMs.AutoSize = True
        Me.rdoNewOldCheckResultMs.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdoNewOldCheckResultMs.ForeColor = System.Drawing.Color.Blue
        Me.rdoNewOldCheckResultMs.Location = New System.Drawing.Point(17, 60)
        Me.rdoNewOldCheckResultMs.Name = "rdoNewOldCheckResultMs"
        Me.rdoNewOldCheckResultMs.Size = New System.Drawing.Size(137, 17)
        Me.rdoNewOldCheckResultMs.TabIndex = 16
        Me.rdoNewOldCheckResultMs.TabStop = True
        Me.rdoNewOldCheckResultMs.Text = "新旧检查结果明细"
        Me.rdoNewOldCheckResultMs.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GroupBox1.Controls.Add(Me.rbCheckMS)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.rdoNewOldCheckResultMs)
        Me.GroupBox1.Controls.Add(Me.rdoJCJGMS)
        Me.GroupBox1.Controls.Add(Me.rdoMissCheckListNewAndOld)
        Me.GroupBox1.Controls.Add(Me.rdoCheckResult)
        Me.GroupBox1.Controls.Add(Me.rdoWJCYL)
        Me.GroupBox1.Controls.Add(Me.rdoPicture)
        Me.GroupBox1.Controls.Add(Me.rdoTools)
        Me.GroupBox1.Controls.Add(Me.rdoXM)
        Me.GroupBox1.Font = New System.Drawing.Font("NSimSun", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(1, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(792, 93)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "新系统"
        '
        'rbCheckMS
        '
        Me.rbCheckMS.AutoSize = True
        Me.rbCheckMS.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbCheckMS.ForeColor = System.Drawing.Color.Blue
        Me.rbCheckMS.Location = New System.Drawing.Point(700, 18)
        Me.rbCheckMS.Name = "rbCheckMS"
        Me.rbCheckMS.Size = New System.Drawing.Size(81, 17)
        Me.rbCheckMS.TabIndex = 18
        Me.rbCheckMS.TabStop = True
        Me.rbCheckMS.Text = "检查明细"
        Me.rbCheckMS.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(441, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "新旧系统(因为数据太多，请尽量不要使用出力EXCEL，请使用CSV按钮)"
        '
        'gbBumen
        '
        Me.gbBumen.Controls.Add(Me.cbBumon4)
        Me.gbBumen.Controls.Add(Me.cbBumon3)
        Me.gbBumen.Controls.Add(Me.cbBumon2)
        Me.gbBumen.Controls.Add(Me.cbBumon1)
        Me.gbBumen.Location = New System.Drawing.Point(802, 0)
        Me.gbBumen.Name = "gbBumen"
        Me.gbBumen.Size = New System.Drawing.Size(115, 55)
        Me.gbBumen.TabIndex = 18
        Me.gbBumen.TabStop = False
        Me.gbBumen.Text = "部门"
        Me.gbBumen.Visible = False
        '
        'cbBumon4
        '
        Me.cbBumon4.AutoSize = True
        Me.cbBumon4.Location = New System.Drawing.Point(58, 34)
        Me.cbBumon4.Name = "cbBumon4"
        Me.cbBumon4.Size = New System.Drawing.Size(42, 16)
        Me.cbBumon4.TabIndex = 3
        Me.cbBumon4.Text = "4部"
        Me.cbBumon4.UseVisualStyleBackColor = True
        '
        'cbBumon3
        '
        Me.cbBumon3.AutoSize = True
        Me.cbBumon3.Location = New System.Drawing.Point(58, 12)
        Me.cbBumon3.Name = "cbBumon3"
        Me.cbBumon3.Size = New System.Drawing.Size(42, 16)
        Me.cbBumon3.TabIndex = 2
        Me.cbBumon3.Text = "3部"
        Me.cbBumon3.UseVisualStyleBackColor = True
        '
        'cbBumon2
        '
        Me.cbBumon2.AutoSize = True
        Me.cbBumon2.Location = New System.Drawing.Point(10, 34)
        Me.cbBumon2.Name = "cbBumon2"
        Me.cbBumon2.Size = New System.Drawing.Size(42, 16)
        Me.cbBumon2.TabIndex = 1
        Me.cbBumon2.Text = "2部"
        Me.cbBumon2.UseVisualStyleBackColor = True
        '
        'cbBumon1
        '
        Me.cbBumon1.AutoSize = True
        Me.cbBumon1.Location = New System.Drawing.Point(10, 12)
        Me.cbBumon1.Name = "cbBumon1"
        Me.cbBumon1.Size = New System.Drawing.Size(42, 16)
        Me.cbBumon1.TabIndex = 0
        Me.cbBumon1.Text = "1部"
        Me.cbBumon1.UseVisualStyleBackColor = True
        '
        'msBaobiao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(1247, 662)
        Me.Controls.Add(Me.gbBumen)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCSV)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnList)
        Me.Controls.Add(Me.btnOutExcel2003)
        Me.Controls.Add(Me.dgvList)
        Me.Controls.Add(Me.btnOutExcel2010)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvWhere)
        Me.Name = "msBaobiao"
        Me.Text = "报表"
        CType(Me.dgvWhere, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbBumen.ResumeLayout(False)
        Me.gbBumen.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rdoJCJGMS As System.Windows.Forms.RadioButton
    Friend WithEvents dgvWhere As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdoCheckResult As System.Windows.Forms.RadioButton
    Friend WithEvents rdoWJCYL As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPicture As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTools As System.Windows.Forms.RadioButton
    Friend WithEvents rdoXM As System.Windows.Forms.RadioButton
    Friend WithEvents btnOutExcel2010 As System.Windows.Forms.Button
    Friend WithEvents dgvList As System.Windows.Forms.DataGridView
    Friend WithEvents btnOutExcel2003 As System.Windows.Forms.Button
    Friend WithEvents btnList As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoOr As System.Windows.Forms.RadioButton
    Friend WithEvents btnCSV As System.Windows.Forms.Button
    Friend WithEvents rdoMissCheckListNewAndOld As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNewOldCheckResultMs As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbCheckMS As System.Windows.Forms.RadioButton
    Friend WithEvents gbBumen As System.Windows.Forms.GroupBox
    Friend WithEvents cbBumon4 As System.Windows.Forms.CheckBox
    Friend WithEvents cbBumon3 As System.Windows.Forms.CheckBox
    Friend WithEvents cbBumon2 As System.Windows.Forms.CheckBox
    Friend WithEvents cbBumon1 As System.Windows.Forms.CheckBox
End Class
