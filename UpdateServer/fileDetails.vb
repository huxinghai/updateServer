Imports UpdateBLL
Public Class fileDetails

    Private sname As String = ""
    Private uid As Int32
    Public Sub New(ByVal name As String, ByVal ud As Int32)
        sname = name
        uid = ud
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。


    End Sub
    Private Sub fileDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataBindinfo(sname)
    End Sub
    Private Sub DataBindinfo(ByVal sn As String)
        Dim str() As String
        Dim t As String
        Dim type As String = ""
        t = GetFilesDetailList(sn)
        If Not t Is Nothing Then
            str = t.ToString.Split("$")
            Me.DataGridView1.Rows.Clear()
            For i As Int32 = 0 To str.Length - 1
                If IsNothingOrNull(str(i), "") <> "" AndAlso Trim(IsNothingOrNull(str(i), "").ToString.Substring(54)).Substring(0, 1) <> "." Then
                    If str(i).Substring(0, 1).Trim.ToUpper = "D" Then
                        type = "文件夹"
                    Else
                        type = "文件"
                    End If

                    Me.DataGridView1.Rows.Add(str(i).Substring(54), type, False)
                End If
            Next
        End If
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        ReturnPath()
        DataBindinfo(sname)
    End Sub

    Private Sub ReturnPath()
        Dim str() As String = sname.Split("/")
        Dim t As String = ""

        For i As Int32 = 0 To str.Length - 2
            If IsNothingOrNull(str(i), "") <> "" Then
                t &= IIf(t = "", str(i), "/" & str(i))
            End If
        Next

        If t <> "" Then
            sname = t
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim sql As String = ""
        Try
            For i As Int32 = 0 To Me.DataGridView1.Rows.Count - 1
                With Me.DataGridView1.Rows(i)
                    If .Cells("确定选取").Value = True AndAlso .Cells("文件类型").Value <> "文件夹" Then
                        If SqlServer.IsDetails(uid, Replace(Trim(sname & "/" & Trim(.Cells("名称").Value)), " ", "")) = False Then
                            Dim Model As New UpdateBLL.UpdateServerDetails
                            Model.UId = uid
                            Model.ServerName = .Cells("名称").Value
                            Model.Paths = Replace(Trim(sname & "/" & Trim(.Cells("名称").Value)), " ", "")
                            sql &= SqlServer.AddULf(Model)
                        End If
                    End If
                End With
            Next

            If sql = "" Then
                MessageBox.Show("没有选取更新的文件或者选取的文件已经存在更新了,请选择文件", "提示")
                Exit Sub
            End If
            If SqlServer.ExecuteTran(sql) Then
                MessageBox.Show("文件选取成功！")
            Else
                MessageBox.Show("文件选取失败！")
            End If
        Catch ex As Exception
            MessageBox.Show("文件选取失败！" & ex.Message)
        End Try
    End Sub

    Private Sub 删除ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 删除ToolStripMenuItem.Click
        If Me.DataGridView1.SelectedRows.Count <= 0 Then
            MessageBox.Show("请选择要删除的文件！")
        End If
        Try
            If MessageBox.Show("是否确定删除，删除将无法还原！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            Dim lk As String = ""
            With Me.DataGridView1.SelectedRows(0)
                DirectoryDelete(Replace(sname & "/" & .Cells("名称").Value, " ", ""), .Cells("文件类型").Value)

                If .Cells("文件类型").Value = "文件夹" Then
                    lk = .Cells("名称").Value & "%"
                Else
                    lk = .Cells("名称").Value
                End If
                SqlServer.DeleteUpdateServerDetails("", uid, Replace(sname & "/" & lk, " ", ""))
                Me.DataGridView1.Rows.Remove(Me.DataGridView1.SelectedRows(0))
            End With

            MessageBox.Show("删除成功！", "提示")
        Catch ex As Exception
            MessageBox.Show("删除失败！" & ex.Message)
        End Try

    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso Me.DataGridView1.Columns(e.ColumnIndex).Name = "名称" AndAlso Me.DataGridView1.Rows(e.RowIndex).Cells("文件类型").Value = "文件夹" Then
            sname = Trim(sname & "/" & Me.DataGridView1.Rows(e.RowIndex).Cells("名称").Value)
            DataBindinfo(sname)
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso Me.DataGridView1.Columns(e.ColumnIndex).Name = "确定选取" Then
            If Me.DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False Then
                Me.DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
            Else
                Me.DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
            End If
        End If
    End Sub
End Class