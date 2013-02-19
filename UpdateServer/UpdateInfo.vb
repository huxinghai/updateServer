Imports UpdateBLL
Public Class UpdateInfo

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If Me.BoxIp.Text.Trim() = "" OrElse Me.BoxUserName.Text.Trim() = "" OrElse Me.BoxPwd.Text.Trim() = "" Then
            MessageBox.Show("请填写完整资料!")
            Exit Sub
        End If
        Try
            SqlServer.InsertUpdateInfo(Me.BoxIp.Text.Trim(), Me.BoxUserName.Text.Trim(), Me.BoxPwd.Text.Trim())
            MessageBox.Show("储存成功!")
        Catch ex As Exception
            MessageBox.Show("储存失败!" & ex.Message)
        End Try
    End Sub
End Class