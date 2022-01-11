<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShouInputCheckResult
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbxZuofan = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbxJianchayuan = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.gv1 = New System.Windows.Forms.DataGridView
        Me.btnIns = New System.Windows.Forms.Button
        Me.rbOk = New System.Windows.Forms.RadioButton
        Me.rbNG = New System.Windows.Forms.RadioButton
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnTUika = New System.Windows.Forms.Button
        Me.tbxGoodcd = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnSel = New System.Windows.Forms.Button
        CType(Me.gv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "座番"
        '
        'tbxZuofan
        '
        Me.tbxZuofan.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tbxZuofan.Location = New System.Drawing.Point(111, 36)
        Me.tbxZuofan.Name = "tbxZuofan"
        Me.tbxZuofan.Size = New System.Drawing.Size(153, 23)
        Me.tbxZuofan.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(281, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 26)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "检查员"
        '
        'tbxJianchayuan
        '
        Me.tbxJianchayuan.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tbxJianchayuan.Location = New System.Drawing.Point(362, 81)
        Me.tbxJianchayuan.Name = "tbxJianchayuan"
        Me.tbxJianchayuan.Size = New System.Drawing.Size(153, 23)
        Me.tbxJianchayuan.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 26)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "检查结果"
        '
        'gv1
        '
        Me.gv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv1.Location = New System.Drawing.Point(15, 180)
        Me.gv1.Name = "gv1"
        Me.gv1.RowTemplate.Height = 21
        Me.gv1.Size = New System.Drawing.Size(866, 92)
        Me.gv1.TabIndex = 4
        '
        'btnIns
        '
        Me.btnIns.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnIns.Enabled = False
        Me.btnIns.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnIns.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnIns.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnIns.Location = New System.Drawing.Point(536, 45)
        Me.btnIns.Name = "btnIns"
        Me.btnIns.Size = New System.Drawing.Size(141, 33)
        Me.btnIns.TabIndex = 6
        Me.btnIns.Text = "追加"
        Me.btnIns.UseVisualStyleBackColor = False
        '
        'rbOk
        '
        Me.rbOk.AutoSize = True
        Me.rbOk.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbOk.Location = New System.Drawing.Point(122, 118)
        Me.rbOk.Name = "rbOk"
        Me.rbOk.Size = New System.Drawing.Size(51, 23)
        Me.rbOk.TabIndex = 7
        Me.rbOk.TabStop = True
        Me.rbOk.Text = "OK"
        Me.rbOk.UseVisualStyleBackColor = True
        '
        'rbNG
        '
        Me.rbNG.AutoSize = True
        Me.rbNG.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rbNG.Location = New System.Drawing.Point(193, 118)
        Me.rbNG.Name = "rbNG"
        Me.rbNG.Size = New System.Drawing.Size(52, 23)
        Me.rbNG.TabIndex = 8
        Me.rbNG.TabStop = True
        Me.rbNG.Text = "NG"
        Me.rbNG.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(15, 296)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(866, 200)
        Me.DataGridView1.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnTUika)
        Me.GroupBox1.Controls.Add(Me.tbxGoodcd)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbxZuofan)
        Me.GroupBox1.Controls.Add(Me.rbNG)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.rbOk)
        Me.GroupBox1.Controls.Add(Me.tbxJianchayuan)
        Me.GroupBox1.Controls.Add(Me.btnIns)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnSel)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(866, 162)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "手入力"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Meiryo UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(531, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(201, 26)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "新生未产入力的场合"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Meiryo UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(531, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(180, 26)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "新生产入力的场合"
        '
        'btnTUika
        '
        Me.btnTUika.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnTUika.Enabled = False
        Me.btnTUika.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnTUika.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnTUika.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnTUika.Location = New System.Drawing.Point(536, 118)
        Me.btnTUika.Name = "btnTUika"
        Me.btnTUika.Size = New System.Drawing.Size(322, 33)
        Me.btnTUika.TabIndex = 11
        Me.btnTUika.Text = "直接追加(不检查)"
        Me.btnTUika.UseVisualStyleBackColor = False
        '
        'tbxGoodcd
        '
        Me.tbxGoodcd.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tbxGoodcd.Location = New System.Drawing.Point(111, 78)
        Me.tbxGoodcd.Name = "tbxGoodcd"
        Me.tbxGoodcd.Size = New System.Drawing.Size(153, 23)
        Me.tbxGoodcd.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Meiryo UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 26)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "商品CD"
        '
        'btnSel
        '
        Me.btnSel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnSel.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSel.Location = New System.Drawing.Point(286, 33)
        Me.btnSel.Name = "btnSel"
        Me.btnSel.Size = New System.Drawing.Size(196, 33)
        Me.btnSel.TabIndex = 5
        Me.btnSel.Text = "检索(检查数据存在用)"
        Me.btnSel.UseVisualStyleBackColor = False
        '
        'ShouInputCheckResult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(890, 522)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.gv1)
        Me.Name = "ShouInputCheckResult"
        Me.Text = "ShouInputCheckResult"
        CType(Me.gv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbxZuofan As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbxJianchayuan As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gv1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnIns As System.Windows.Forms.Button
    Friend WithEvents rbOk As System.Windows.Forms.RadioButton
    Friend WithEvents rbNG As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbxGoodcd As System.Windows.Forms.TextBox
    Friend WithEvents btnTUika As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnSel As System.Windows.Forms.Button
End Class
