<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ErrorDataForm
    Inherits System.Windows.Forms.Form

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
        Me.dgvErrorData = New System.Windows.Forms.DataGridView
        CType(Me.dgvErrorData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvErrorData
        '
        Me.dgvErrorData.AllowUserToAddRows = False
        Me.dgvErrorData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvErrorData.Location = New System.Drawing.Point(21, 25)
        Me.dgvErrorData.Name = "dgvErrorData"
        Me.dgvErrorData.RowHeadersVisible = False
        Me.dgvErrorData.RowTemplate.Height = 21
        Me.dgvErrorData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvErrorData.Size = New System.Drawing.Size(750, 520)
        Me.dgvErrorData.TabIndex = 0
        '
        'ErrorDataForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Controls.Add(Me.dgvErrorData)
        Me.Name = "ErrorDataForm"
        Me.Text = "ErrorDataForm"
        CType(Me.dgvErrorData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvErrorData As System.Windows.Forms.DataGridView
End Class
