<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResultDetail
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
        Me.pnlAction = New System.Windows.Forms.Panel
        Me.btnExport = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.dgvChkResultDetail = New System.Windows.Forms.DataGridView
        Me.pnlAction.SuspendLayout()
        CType(Me.dgvChkResultDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlAction
        '
        Me.pnlAction.Controls.Add(Me.btnExport)
        Me.pnlAction.Controls.Add(Me.btnClose)
        Me.pnlAction.Location = New System.Drawing.Point(43, 11)
        Me.pnlAction.Name = "pnlAction"
        Me.pnlAction.Size = New System.Drawing.Size(837, 32)
        Me.pnlAction.TabIndex = 2
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(670, 4)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 21)
        Me.btnExport.TabIndex = 8
        Me.btnExport.Text = "导出"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(751, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "退出"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dgvChkResultDetail
        '
        Me.dgvChkResultDetail.AllowUserToAddRows = False
        Me.dgvChkResultDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvChkResultDetail.Location = New System.Drawing.Point(43, 49)
        Me.dgvChkResultDetail.Name = "dgvChkResultDetail"
        Me.dgvChkResultDetail.ReadOnly = True
        Me.dgvChkResultDetail.RowTemplate.Height = 21
        Me.dgvChkResultDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvChkResultDetail.Size = New System.Drawing.Size(837, 556)
        Me.dgvChkResultDetail.TabIndex = 8
        '
        'ResultDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(892, 623)
        Me.Controls.Add(Me.dgvChkResultDetail)
        Me.Controls.Add(Me.pnlAction)
        Me.Name = "ResultDetail"
        Me.Text = "检查结果详细页"
        Me.pnlAction.ResumeLayout(False)
        CType(Me.dgvChkResultDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlAction As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents dgvChkResultDetail As System.Windows.Forms.DataGridView

End Class
