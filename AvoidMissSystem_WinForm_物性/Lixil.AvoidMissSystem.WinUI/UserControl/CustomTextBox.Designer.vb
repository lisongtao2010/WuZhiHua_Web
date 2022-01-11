<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomTextBox
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
        Me.txtBox = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtBox
        '
        Me.txtBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtBox.Location = New System.Drawing.Point(0, 0)
        Me.txtBox.Margin = New System.Windows.Forms.Padding(0)
        Me.txtBox.Name = "txtBox"
        Me.txtBox.Size = New System.Drawing.Size(165, 19)
        Me.txtBox.TabIndex = 0
        '
        'CustomTextBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtBox)
        Me.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.Name = "CustomTextBox"
        Me.Size = New System.Drawing.Size(165, 17)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBox As System.Windows.Forms.TextBox

End Class
