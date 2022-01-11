<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class m_permission
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
        Me.btnSave = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.AvoidMiss_NewDataSet = New Lixil.AvoidMissSystem.WinUI.AvoidMiss_NewDataSet
        Me.AvoidMissNewDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MpermissionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.M_permissionTableAdapter = New Lixil.AvoidMissSystem.WinUI.AvoidMiss_NewDataSetTableAdapters.m_permissionTableAdapter
        Me.UseridDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccesstypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccesscdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeleteflgDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InsertuserDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InsertdateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateuserDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdatedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AvoidMiss_NewDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AvoidMissNewDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MpermissionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UseridDataGridViewTextBoxColumn, Me.AccesstypeDataGridViewTextBoxColumn, Me.AccesscdDataGridViewTextBoxColumn, Me.DeleteflgDataGridViewTextBoxColumn, Me.InsertuserDataGridViewTextBoxColumn, Me.InsertdateDataGridViewTextBoxColumn, Me.UpdateuserDataGridViewTextBoxColumn, Me.UpdatedateDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.MpermissionBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(21, 86)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(695, 407)
        Me.DataGridView1.TabIndex = 4
        '
        'AvoidMiss_NewDataSet
        '
        Me.AvoidMiss_NewDataSet.DataSetName = "AvoidMiss_NewDataSet"
        Me.AvoidMiss_NewDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AvoidMissNewDataSetBindingSource
        '
        Me.AvoidMissNewDataSetBindingSource.DataSource = Me.AvoidMiss_NewDataSet
        Me.AvoidMissNewDataSetBindingSource.Position = 0
        '
        'MpermissionBindingSource
        '
        Me.MpermissionBindingSource.DataMember = "m_permission"
        Me.MpermissionBindingSource.DataSource = Me.AvoidMissNewDataSetBindingSource
        '
        'M_permissionTableAdapter
        '
        Me.M_permissionTableAdapter.ClearBeforeFill = True
        '
        'UseridDataGridViewTextBoxColumn
        '
        Me.UseridDataGridViewTextBoxColumn.DataPropertyName = "user_id"
        Me.UseridDataGridViewTextBoxColumn.HeaderText = "user_id"
        Me.UseridDataGridViewTextBoxColumn.Name = "UseridDataGridViewTextBoxColumn"
        '
        'AccesstypeDataGridViewTextBoxColumn
        '
        Me.AccesstypeDataGridViewTextBoxColumn.DataPropertyName = "access_type"
        Me.AccesstypeDataGridViewTextBoxColumn.HeaderText = "access_type"
        Me.AccesstypeDataGridViewTextBoxColumn.Name = "AccesstypeDataGridViewTextBoxColumn"
        '
        'AccesscdDataGridViewTextBoxColumn
        '
        Me.AccesscdDataGridViewTextBoxColumn.DataPropertyName = "access_cd"
        Me.AccesscdDataGridViewTextBoxColumn.HeaderText = "access_cd"
        Me.AccesscdDataGridViewTextBoxColumn.Name = "AccesscdDataGridViewTextBoxColumn"
        '
        'DeleteflgDataGridViewTextBoxColumn
        '
        Me.DeleteflgDataGridViewTextBoxColumn.DataPropertyName = "delete_flg"
        Me.DeleteflgDataGridViewTextBoxColumn.HeaderText = "delete_flg"
        Me.DeleteflgDataGridViewTextBoxColumn.Name = "DeleteflgDataGridViewTextBoxColumn"
        '
        'InsertuserDataGridViewTextBoxColumn
        '
        Me.InsertuserDataGridViewTextBoxColumn.DataPropertyName = "insert_user"
        Me.InsertuserDataGridViewTextBoxColumn.HeaderText = "insert_user"
        Me.InsertuserDataGridViewTextBoxColumn.Name = "InsertuserDataGridViewTextBoxColumn"
        '
        'InsertdateDataGridViewTextBoxColumn
        '
        Me.InsertdateDataGridViewTextBoxColumn.DataPropertyName = "insert_date"
        Me.InsertdateDataGridViewTextBoxColumn.HeaderText = "insert_date"
        Me.InsertdateDataGridViewTextBoxColumn.Name = "InsertdateDataGridViewTextBoxColumn"
        '
        'UpdateuserDataGridViewTextBoxColumn
        '
        Me.UpdateuserDataGridViewTextBoxColumn.DataPropertyName = "update_user"
        Me.UpdateuserDataGridViewTextBoxColumn.HeaderText = "update_user"
        Me.UpdateuserDataGridViewTextBoxColumn.Name = "UpdateuserDataGridViewTextBoxColumn"
        '
        'UpdatedateDataGridViewTextBoxColumn
        '
        Me.UpdatedateDataGridViewTextBoxColumn.DataPropertyName = "update_date"
        Me.UpdatedateDataGridViewTextBoxColumn.HeaderText = "update_date"
        Me.UpdatedateDataGridViewTextBoxColumn.Name = "UpdatedateDataGridViewTextBoxColumn"
        '
        'm_permission
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 561)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnSave)
        Me.Name = "m_permission"
        Me.Text = "m_permission"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AvoidMiss_NewDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AvoidMissNewDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MpermissionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents AvoidMissNewDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AvoidMiss_NewDataSet As Lixil.AvoidMissSystem.WinUI.AvoidMiss_NewDataSet
    Friend WithEvents MpermissionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents M_permissionTableAdapter As Lixil.AvoidMissSystem.WinUI.AvoidMiss_NewDataSetTableAdapters.m_permissionTableAdapter
    Friend WithEvents UseridDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccesstypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccesscdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeleteflgDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InsertuserDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InsertdateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateuserDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdatedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
