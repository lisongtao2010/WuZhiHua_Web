<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MsgConfirmForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dtgv = New System.Windows.Forms.DataGridView
        Me.btnReChk = New System.Windows.Forms.Button
        Me.btnDefaultResult = New System.Windows.Forms.Button
        Me.btnNoChk = New System.Windows.Forms.Button
        Me.btnContinueChk = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblSyohinCd = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        CType(Me.dtgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtgv
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgv.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgv.Location = New System.Drawing.Point(5, 5)
        Me.dtgv.MultiSelect = False
        Me.dtgv.Name = "dtgv"
        Me.dtgv.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgv.RowTemplate.Height = 21
        Me.dtgv.Size = New System.Drawing.Size(1155, 313)
        Me.dtgv.TabIndex = 0
        '
        'btnReChk
        '
        Me.btnReChk.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnReChk.Font = New System.Drawing.Font("SimHei", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReChk.Location = New System.Drawing.Point(404, 356)
        Me.btnReChk.Name = "btnReChk"
        Me.btnReChk.Size = New System.Drawing.Size(140, 40)
        Me.btnReChk.TabIndex = 100006
        Me.btnReChk.Text = "重新检查"
        Me.btnReChk.UseVisualStyleBackColor = False
        Me.btnReChk.Visible = False
        '
        'btnDefaultResult
        '
        Me.btnDefaultResult.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnDefaultResult.Font = New System.Drawing.Font("SimHei", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDefaultResult.Location = New System.Drawing.Point(164, 356)
        Me.btnDefaultResult.Name = "btnDefaultResult"
        Me.btnDefaultResult.Size = New System.Drawing.Size(140, 40)
        Me.btnDefaultResult.TabIndex = 100006
        Me.btnDefaultResult.Text = "默认结果"
        Me.btnDefaultResult.UseVisualStyleBackColor = False
        Me.btnDefaultResult.Visible = False
        '
        'btnNoChk
        '
        Me.btnNoChk.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnNoChk.Font = New System.Drawing.Font("SimHei", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNoChk.Location = New System.Drawing.Point(669, 356)
        Me.btnNoChk.Name = "btnNoChk"
        Me.btnNoChk.Size = New System.Drawing.Size(140, 40)
        Me.btnNoChk.TabIndex = 100006
        Me.btnNoChk.Text = "不检查"
        Me.btnNoChk.UseVisualStyleBackColor = False
        '
        'btnContinueChk
        '
        Me.btnContinueChk.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnContinueChk.Font = New System.Drawing.Font("SimHei", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContinueChk.Location = New System.Drawing.Point(164, 356)
        Me.btnContinueChk.Name = "btnContinueChk"
        Me.btnContinueChk.Size = New System.Drawing.Size(140, 40)
        Me.btnContinueChk.TabIndex = 100006
        Me.btnContinueChk.Text = "继续检查"
        Me.btnContinueChk.UseVisualStyleBackColor = False
        Me.btnContinueChk.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 15)
        Me.Label1.TabIndex = 100007
        Me.Label1.Text = "商品CD:"
        '
        'lblSyohinCd
        '
        Me.lblSyohinCd.AutoSize = True
        Me.lblSyohinCd.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSyohinCd.Location = New System.Drawing.Point(75, 13)
        Me.lblSyohinCd.Name = "lblSyohinCd"
        Me.lblSyohinCd.Size = New System.Drawing.Size(0, 15)
        Me.lblSyohinCd.TabIndex = 100008
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.dtgv)
        Me.Panel1.Location = New System.Drawing.Point(1, 31)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1185, 319)
        Me.Panel1.TabIndex = 0
        '
        'MsgConfirmForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(1184, 398)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblSyohinCd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnNoChk)
        Me.Controls.Add(Me.btnContinueChk)
        Me.Controls.Add(Me.btnDefaultResult)
        Me.Controls.Add(Me.btnReChk)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "MsgConfirmForm"
        Me.Text = "MsgConfirmForm"
        CType(Me.dtgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnReChk As System.Windows.Forms.Button
    Friend WithEvents btnDefaultResult As System.Windows.Forms.Button
    Friend WithEvents btnNoChk As System.Windows.Forms.Button
    Friend WithEvents btnContinueChk As System.Windows.Forms.Button
    Friend WithEvents dtgv As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSyohinCd As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
