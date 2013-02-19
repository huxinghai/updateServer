Imports UpdateBLL
Public Class fileDetails

    Private sname As String = ""
    Private uid As Int32
    Public Sub New(ByVal name As String, ByVal ud As Int32)
        sname = name
        uid = ud
        ' �˵����� Windows ���������������ġ�
        InitializeComponent()

        ' �� InitializeComponent() ����֮������κγ�ʼ����


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
                        type = "�ļ���"
                    Else
                        type = "�ļ�"
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
                    If .Cells("ȷ��ѡȡ").Value = True AndAlso .Cells("�ļ�����").Value <> "�ļ���" Then
                        If SqlServer.IsDetails(uid, Replace(Trim(sname & "/" & Trim(.Cells("����").Value)), " ", "")) = False Then
                            Dim Model As New UpdateBLL.UpdateServerDetails
                            Model.UId = uid
                            Model.ServerName = .Cells("����").Value
                            Model.Paths = Replace(Trim(sname & "/" & Trim(.Cells("����").Value)), " ", "")
                            sql &= SqlServer.AddULf(Model)
                        End If
                    End If
                End With
            Next

            If sql = "" Then
                MessageBox.Show("û��ѡȡ���µ��ļ�����ѡȡ���ļ��Ѿ����ڸ�����,��ѡ���ļ�", "��ʾ")
                Exit Sub
            End If
            If SqlServer.ExecuteTran(sql) Then
                MessageBox.Show("�ļ�ѡȡ�ɹ���")
            Else
                MessageBox.Show("�ļ�ѡȡʧ�ܣ�")
            End If
        Catch ex As Exception
            MessageBox.Show("�ļ�ѡȡʧ�ܣ�" & ex.Message)
        End Try
    End Sub

    Private Sub ɾ��ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ɾ��ToolStripMenuItem.Click
        If Me.DataGridView1.SelectedRows.Count <= 0 Then
            MessageBox.Show("��ѡ��Ҫɾ�����ļ���")
        End If
        Try
            If MessageBox.Show("�Ƿ�ȷ��ɾ����ɾ�����޷���ԭ��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            Dim lk As String = ""
            With Me.DataGridView1.SelectedRows(0)
                DirectoryDelete(Replace(sname & "/" & .Cells("����").Value, " ", ""), .Cells("�ļ�����").Value)

                If .Cells("�ļ�����").Value = "�ļ���" Then
                    lk = .Cells("����").Value & "%"
                Else
                    lk = .Cells("����").Value
                End If
                SqlServer.DeleteUpdateServerDetails("", uid, Replace(sname & "/" & lk, " ", ""))
                Me.DataGridView1.Rows.Remove(Me.DataGridView1.SelectedRows(0))
            End With

            MessageBox.Show("ɾ���ɹ���", "��ʾ")
        Catch ex As Exception
            MessageBox.Show("ɾ��ʧ�ܣ�" & ex.Message)
        End Try

    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso Me.DataGridView1.Columns(e.ColumnIndex).Name = "����" AndAlso Me.DataGridView1.Rows(e.RowIndex).Cells("�ļ�����").Value = "�ļ���" Then
            sname = Trim(sname & "/" & Me.DataGridView1.Rows(e.RowIndex).Cells("����").Value)
            DataBindinfo(sname)
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso Me.DataGridView1.Columns(e.ColumnIndex).Name = "ȷ��ѡȡ" Then
            If Me.DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False Then
                Me.DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
            Else
                Me.DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
            End If
        End If
    End Sub
End Class