<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWinForm
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbComName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.comboBox_comPl = New System.Windows.Forms.ComboBox()
        Me.pBtns = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cbComName)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnConnect)
        Me.Panel1.Controls.Add(Me.btnStop)
        Me.Panel1.Controls.Add(Me.comboBox_comPl)
        Me.Panel1.Location = New System.Drawing.Point(15, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(489, 37)
        Me.Panel1.TabIndex = 23
        '
        'cbComName
        '
        Me.cbComName.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbComName.FormattingEnabled = True
        Me.cbComName.Location = New System.Drawing.Point(60, 3)
        Me.cbComName.Name = "cbComName"
        Me.cbComName.Size = New System.Drawing.Size(76, 30)
        Me.cbComName.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(-1, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 26)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "串口:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(142, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 26)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "波特率:"
        '
        'btnConnect
        '
        Me.btnConnect.Font = New System.Drawing.Font("Microsoft YaHei", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConnect.Location = New System.Drawing.Point(331, 1)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(74, 32)
        Me.btnConnect.TabIndex = 12
        Me.btnConnect.Text = "连接"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Font = New System.Drawing.Font("Microsoft YaHei", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStop.Location = New System.Drawing.Point(411, 1)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 32)
        Me.btnStop.TabIndex = 13
        Me.btnStop.Text = "停止"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'comboBox_comPl
        '
        Me.comboBox_comPl.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboBox_comPl.FormattingEnabled = True
        Me.comboBox_comPl.Items.AddRange(New Object() {"19200"})
        Me.comboBox_comPl.Location = New System.Drawing.Point(222, 3)
        Me.comboBox_comPl.Name = "comboBox_comPl"
        Me.comboBox_comPl.Size = New System.Drawing.Size(103, 30)
        Me.comboBox_comPl.TabIndex = 14
        Me.comboBox_comPl.Text = "9600"
        '
        'pBtns
        '
        Me.pBtns.Location = New System.Drawing.Point(15, 55)
        Me.pBtns.Name = "pBtns"
        Me.pBtns.Size = New System.Drawing.Size(489, 273)
        Me.pBtns.TabIndex = 24
        '
        'MainWinForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 344)
        Me.Controls.Add(Me.pBtns)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "MainWinForm"
        Me.Text = "投影仪连接"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Private WithEvents cbComName As ComboBox
    Private WithEvents Label2 As Label
    Private WithEvents Label3 As Label
    Private WithEvents btnConnect As Button
    Private WithEvents btnStop As Button
    Private WithEvents comboBox_comPl As ComboBox
    Friend WithEvents pBtns As Panel
End Class
