Imports System.Data.Odbc
Public Class LoginForm1
    Sub buka()
        UTAMA.MasterToolStripMenuItem.Enabled = True
        UTAMA.WindowsToolStripMenuItem.Enabled = True
        UTAMA.ToolStripMenuItem2.Enabled = True
        UTAMA.GroupBox1.Visible = True
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Call Koneksi()
        Dim cari As String
        cari = "select * from ADMIN where NAMA='" & UsernameTextBox.Text & "' and PASSWORD='" & PasswordTextBox.Text & "'"
        cmd = New OdbcCommand(cari, conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Call buka()
            UTAMA.Label5.Text = rd!NAMA
            UTAMA.Label6.Text = rd!STATUS
            UsernameTextBox.Text = ""
            PasswordTextBox.Text = ""
            Me.Close()
        ElseIf Not rd.HasRows Then
            MessageBox.Show("Id Atau Password Salah", "Warnig", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UsernameTextBox.Text = ""
            PasswordTextBox.Text = ""
            UsernameTextBox.Focus()
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
