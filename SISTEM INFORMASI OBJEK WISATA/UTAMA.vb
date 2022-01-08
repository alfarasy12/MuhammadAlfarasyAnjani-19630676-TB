Public Class UTAMA


    Private Sub UTAMA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call bgmdi()
        Call kunci()
    End Sub

    Sub kunci()
        MasterToolStripMenuItem.Enabled = False
        WindowsToolStripMenuItem.Enabled = False
        ToolStripMenuItem2.Enabled = False
        GroupBox1.Visible = False
    End Sub
    Sub bgmdi()
        Dim c As Control
        For Each c In Me.Controls
            If TypeOf c Is MdiClient Then c.BackColor = Me.BackColor
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ADMIN.Show()
        ADMIN.MdiParent = Me
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        PENGELOLA.Show()
        PENGELOLA.MdiParent = Me
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        WISATA.Show()
        WISATA.MdiParent = Me
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TIKET.Show()
        TIKET.MdiParent = Me
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        LAPORAN.ShowDialog()
    End Sub

    Private Sub DataWisataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataWisataToolStripMenuItem.Click
        WISATA.Show()
        WISATA.MdiParent = Me
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        End
    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click
        LoginForm1.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim PANGGIL As String
        PANGGIL = "PERSYARATAN.docx"
        Process.Start(PANGGIL)
    End Sub
End Class
