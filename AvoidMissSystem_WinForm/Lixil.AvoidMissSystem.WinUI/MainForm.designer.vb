<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTest
    Inherits Lixil.AvoidMissSystem.WinUI.BaseForm

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
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnCheck = New System.Windows.Forms.Button
        Me.btnMsMaintenance = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnExit.Font = New System.Drawing.Font("SimHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(668, 605)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(131, 32)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "退出"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnCheck
        '
        Me.btnCheck.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnCheck.Font = New System.Drawing.Font("SimHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheck.Location = New System.Drawing.Point(374, 241)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(131, 32)
        Me.btnCheck.TabIndex = 3
        Me.btnCheck.Text = "寸法检查"
        Me.btnCheck.UseVisualStyleBackColor = False
        '
        'btnMsMaintenance
        '
        Me.btnMsMaintenance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnMsMaintenance.Font = New System.Drawing.Font("SimHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMsMaintenance.Location = New System.Drawing.Point(374, 279)
        Me.btnMsMaintenance.Name = "btnMsMaintenance"
        Me.btnMsMaintenance.Size = New System.Drawing.Size(131, 32)
        Me.btnMsMaintenance.TabIndex = 4
        Me.btnMsMaintenance.Text = "后台维护"
        Me.btnMsMaintenance.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(35, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(810, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "用于测试的起始页，本番之前要删除这个页面。然后分别以下面两个按钮的对应页面为起始页，做成两个程序"
        '
        'frmTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(892, 675)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.btnMsMaintenance)
        Me.Name = "frmTest"
        Me.Text = "Test"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnCheck As System.Windows.Forms.Button
    Friend WithEvents btnMsMaintenance As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    'Friend WithEvents MitsumoriService As SEPJSamples.Sekisan.UI.Mitsumori.MitsumoriService

End Class
