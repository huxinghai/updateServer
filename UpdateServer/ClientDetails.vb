Imports UpdateBLL
Public Class ClientDetails

    Private sname As String = "" '传递参数值
    Private dt As New DataTable
    Public Sub New(ByVal sn As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        sname = sn

    End Sub
    Private Sub ClientDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataBinds()
    End Sub

    Private Sub DataBinds()
        Me.TvIp.Nodes.Clear()
        dt = SqlServer.QueryClientInfo("", sname)
        For i As Int32 = 0 To dt.Rows.Count - 1
            Me.TvIp.Nodes.Add(dt.Rows(i)("Ip"))
            Me.TvIp.Nodes(i).Tag = dt.Rows(i)("Id")
            Me.TvIp.Nodes(i).ToolTipText = "Version:" & dt.Rows(i)("VerSoin") & "  BeginDate:" & Format(dt.Rows(i)("BeginDate"), "yyyy-MM-dd") & "  EndDate:" & Format(dt.Rows(i)("EndDate"), "yyyy-MM-dd")
        Next
    End Sub

    Private Sub TvIp_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TvIp.AfterSelect
        dt = SqlServer.QueryUpdateClientDetails(IsNothingOrNull(Me.TvIp.SelectedNode.Tag, 0))

        Me.Dgv.Rows.Clear()
        For i As Int32 = 0 To dt.Rows.Count - 1
            Me.Dgv.Rows.Add(dt.Rows(i)("Path"), dt.Rows(i)("State"))
        Next
    End Sub

    Private Sub 刷新ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 刷新ToolStripMenuItem.Click
        DataBinds()
    End Sub

    Private Sub 清除ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 清除ToolStripMenuItem.Click
        If Not Me.TvIp.SelectedNode Is Nothing Then
            SqlServer.DeleteUpdateClient(IsNothingOrNull(Me.TvIp.SelectedNode.Tag, ""))
            DataBinds()
        End If
    End Sub
End Class