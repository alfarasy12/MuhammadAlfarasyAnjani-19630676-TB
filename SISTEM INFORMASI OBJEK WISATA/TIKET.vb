Imports System.Data.Odbc
Public Class TIKET

    Private Sub TIKET_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call kondisiawal()
        Call munculwisata()
    End Sub

    Sub kondisiawal()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        ComboBox1.Text = ""
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        Call nootomatis()
        Call tampiltiket()
    End Sub
    Sub munculwisata()
        Call Koneksi()
        Dim cari As String
        cari = "select nama from wisata GROUP BY nama"
        cmd = New OdbcCommand(cari, conn)
        rd = cmd.ExecuteReader
        If rd.HasRows Then
            Do While rd.Read
                ComboBox1.Items.Add(rd("nama"))
            Loop
        Else

        End If
    End Sub
    Sub nootomatis()
        Call Koneksi()
        cmd = New OdbcCommand("select * from tiket order by idtiket desc", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then
            TextBox1.Text = "TK" + "001"
        Else
            TextBox1.Text = Val(Microsoft.VisualBasic.Mid(rd.Item("idtiket").ToString, 4, 3)) + 1
            If Len(TextBox1.Text) = 1 Then
                TextBox1.Text = "TK00" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 2 Then
                TextBox1.Text = "TK0" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 3 Then
                TextBox1.Text = "TK" & TextBox1.Text & ""
            End If
        End If
    End Sub
    Sub tampiltiket()
        Call Koneksi()
        da = New OdbcDataAdapter("select * from tiket", conn)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightBlue
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Then
            MessageBox.Show("Data Belum Lengkap", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Call Koneksi()
        cmd = New OdbcCommand("select idtiket from tiket where idtiket='" & TextBox1.Text & "'", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Dim EditData As String = "Update tiket set npelanggan='" & TextBox2.Text & "',jpelanggan='" & TextBox3.Text & "',nik='" & TextBox4.Text & "',alamat='" & TextBox4.Text & "',wisata='" & ComboBox1.Text & "',htiket='" & TextBox6.Text & "',jumlah='" & TextBox7.Text & "',bayar='" & TextBox8.Text & "',dibayar='" & TextBox9.Text & "',kembali='" & TextBox10.Text & "' where idtiket='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(EditData, conn)
            cmd.ExecuteNonQuery()
            Call kondisiawal()
            Exit Sub
        ElseIf Not rd.HasRows Then
            Call Koneksi()
            Dim InputData As String = "Insert into tiket values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "')"
            cmd = New OdbcCommand(InputData, conn)
            cmd.ExecuteNonQuery()
            If MessageBox.Show("Cetak Tiket Wisata", "Information", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                SLIPTIKET.ShowDialog()
            End If
            Call kondisiawal()
        End If
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        On Error Resume Next
        TextBox7.Text = Val(Microsoft.VisualBasic.Str(TextBox6.Text)) * Val(Microsoft.VisualBasic.Str(TextBox3.Text))
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        On Error Resume Next
        TextBox7.Text = Val(Microsoft.VisualBasic.Str(TextBox6.Text)) * Val(Microsoft.VisualBasic.Str(TextBox3.Text))
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        TextBox8.Text = TextBox7.Text
    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        If e.KeyChar = Chr(13) Then
            If Val(TextBox9.Text) < Val(TextBox8.Text) Then
                MessageBox.Show("Pembayaran Kurang", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox9.Clear()
                TextBox8.Focus()
            ElseIf Val(TextBox9.Text) = Val(TextBox8.Text) Then
                TextBox10.Text = 0
                Button1.Focus()
            ElseIf Val(TextBox9.Text) > Val(TextBox8.Text) Then
                TextBox10.Text = Val(TextBox9.Text) - Val(TextBox8.Text)
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        TextBox7.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value
        TextBox8.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value
        TextBox9.Text = DataGridView1.Rows(e.RowIndex).Cells(9).Value
        TextBox10.Text = DataGridView1.Rows(e.RowIndex).Cells(10).Value
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Then
            MessageBox.Show("Data Belum Lengkap", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show("Hapus Data Ini?", "Warning", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Call Koneksi()
            Dim HapusData As String = "delete from TIKET where idTIKET='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(HapusData, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Hapus", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call kondisiawal()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call Koneksi()
        Dim cariData As String = "SELECT * FROM wisata WHERE nama='" & ComboBox1.Text & "' and keterangan='TUTUP'"
        cmd = New OdbcCommand(cariData, conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            MessageBox.Show("Wisata Sedang Tutup", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Call Koneksi()
        Dim cari As String = "SELECT * FROM wisata WHERE nama='" & ComboBox1.Text & "'"
        cmd = New OdbcCommand(cari, conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            TextBox6.Text = rd.Item("htiket")
        End If
    End Sub
End Class