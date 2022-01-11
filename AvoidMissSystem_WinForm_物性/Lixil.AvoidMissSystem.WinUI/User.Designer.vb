<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class User
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
        Me.components = New System.ComponentModel.Container
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LoginNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LoginPasswordDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TBUserBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AvoidMiss_NewDataSet = New Lixil.AvoidMissSystem.WinUI.AvoidMiss_NewDataSet
        Me.TB_UserTableAdapter = New Lixil.AvoidMissSystem.WinUI.AvoidMiss_NewDataSetTableAdapters.TB_UserTableAdapter
        Me.btnSave = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBUserBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AvoidMiss_NewDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.LoginNameDataGridViewTextBoxColumn, Me.LoginPasswordDataGridViewTextBoxColumn, Me.UserNameDataGridViewTextBoxColumn, Me.UserCodeDataGridViewTextBoxColumn, Me.UserTypeDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.TBUserBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(12, 68)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(732, 439)
        Me.DataGridView1.TabIndex = 0
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        '
        'LoginNameDataGridViewTextBoxColumn
        '
        Me.LoginNameDataGridViewTextBoxColumn.DataPropertyName = "LoginName"
        Me.LoginNameDataGridViewTextBoxColumn.HeaderText = "LoginName"
        Me.LoginNameDataGridViewTextBoxColumn.Name = "LoginNameDataGridViewTextBoxColumn"
        '
        'LoginPasswordDataGridViewTextBoxColumn
        '
        Me.LoginPasswordDataGridViewTextBoxColumn.DataPropertyName = "LoginPassword"
        Me.LoginPasswordDataGridViewTextBoxColumn.HeaderText = "LoginPassword"
        Me.LoginPasswordDataGridViewTextBoxColumn.Name = "LoginPasswordDataGridViewTextBoxColumn"
        '
        'UserNameDataGridViewTextBoxColumn
        '
        Me.UserNameDataGridViewTextBoxColumn.DataPropertyName = "UserName"
        Me.UserNameDataGridViewTextBoxColumn.HeaderText = "UserName"
        Me.UserNameDataGridViewTextBoxColumn.Name = "UserNameDataGridViewTextBoxColumn"
        '
        'UserCodeDataGridViewTextBoxColumn
        '
        Me.UserCodeDataGridViewTextBoxColumn.DataPropertyName = "UserCode"
        Me.UserCodeDataGridViewTextBoxColumn.HeaderText = "UserCode"
        Me.UserCodeDataGridViewTextBoxColumn.Name = "UserCodeDataGridViewTextBoxColumn"
        '
        'UserTypeDataGridViewTextBoxColumn
        '
        Me.UserTypeDataGridViewTextBoxColumn.DataPropertyName = "UserType"
        Me.UserTypeDataGridViewTextBoxColumn.HeaderText = "UserType"
        Me.UserTypeDataGridViewTextBoxColumn.Name = "UserTypeDataGridViewTextBoxColumn"
        '
        'TBUserBindingSource
        '
        Me.TBUserBindingSource.DataMember = "TB_User"
        Me.TBUserBindingSource.DataSource = Me.AvoidMiss_NewDataSet
        '
        'AvoidMiss_NewDataSet
        '
        Me.AvoidMiss_NewDataSet.DataSetName = "AvoidMiss_NewDataSet"
        Me.AvoidMiss_NewDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TB_UserTableAdapter
        '
        Me.TB_UserTableAdapter.ClearBeforeFill = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(584, 25)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "保存"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(466, 25)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "刷新"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(573, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "原来没有这个机能，为了方便才追加的，所以如果不是特别需要请不要使用这个机能（保持原来的逻辑比较好）"
        '
        'User
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 561)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "User"
        Me.Text = "User"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBUserBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AvoidMiss_NewDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents AvoidMiss_NewDataSet As Lixil.AvoidMissSystem.WinUI.AvoidMiss_NewDataSet
    Friend WithEvents TBUserBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TB_UserTableAdapter As Lixil.AvoidMissSystem.WinUI.AvoidMiss_NewDataSetTableAdapters.TB_UserTableAdapter
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoginNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoginPasswordDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
