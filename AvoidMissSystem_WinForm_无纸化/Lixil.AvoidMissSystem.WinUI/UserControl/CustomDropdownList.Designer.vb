<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomDropdownList
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
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
        Me.drpList = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'drpList
        '
        Me.drpList.BackColor = System.Drawing.SystemColors.Window
        Me.drpList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpList.FormattingEnabled = True
        Me.drpList.Location = New System.Drawing.Point(3, 1)
        Me.drpList.Margin = New System.Windows.Forms.Padding(2)
        Me.drpList.Name = "drpList"
        Me.drpList.Size = New System.Drawing.Size(80, 20)
        Me.drpList.TabIndex = 0
        '
        'CustomDropdownList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.drpList)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "CustomDropdownList"
        Me.Size = New System.Drawing.Size(92, 22)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents drpList As System.Windows.Forms.ComboBox

End Class
