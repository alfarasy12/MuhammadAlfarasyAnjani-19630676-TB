Imports System.Data.Odbc
Public Class WISATA


    Private Sub WISATA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call kondisiawal()
    End Sub
    Sub kondisiawal()
        TextBox2.Text = Today
        TextBox3.Clear()
        TextBox4.Text = "07:00"
        ComboBox1.Text = ""
        TextBox5.Text = "18:00"
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        Call nootomatis()
        Call tampilwisata()
    End Sub
    Sub nootomatis()
        Call Koneksi()
        cmd = New OdbcCommand("select * from wisata order by idwisata desc", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then
            TextBox1.Text = "1" + "001"
        Else
            TextBox1.Text = Val(Microsoft.VisualBasic.Mid(rd.Item("idwisata").ToString, 4, 3)) + 1
            If Len(TextBox1.Text) = 1 Then
                TextBox1.Text = "100" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 2 Then
                TextBox1.Text = "10" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 3 Then
                TextBox1.Text = "1" & TextBox1.Text & ""
            End If
        End If
    End Sub
    Sub tampilwisata()
        Call Koneksi()
        da = New OdbcDataAdapter("select * from wisata", conn)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns(0).HeaderText = "ID wisata"
        DataGridView1.Columns(1).HeaderText = "TANGGAL INPUT"
        DataGridView1.Columns(2).HeaderText = "NAMA"
        DataGridView1.Columns(3).HeaderText = "KETERANGAN"
        DataGridView1.Columns(4).HeaderText = "JAM BUKA"
        DataGridView1.Columns(5).HeaderText = "JAM TUTUP"
        DataGridView1.Columns(6).HeaderText = "HARGA TIKET"
        DataGridView1.Columns(7).HeaderText = "ASURANSI"
        DataGridView1.Columns(8).HeaderText = "MAX PENGUNJUNG"
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightBlue
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        DataGridView1.Columns(1).Width = 150
        DataGridView1.Columns(6).Width = 120
        DataGridView1.Columns(8).Width = 150
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Then
            MessageBox.Show("Data Belum Lengkap", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Call Koneksi()
        cmd = New OdbcCommand("select idwisata from wisata where idwisata='" & TextBox1.Text & "'", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Dim EditData As String = "Update wisata set tglinput='" & Format(Now, "yyyy-MM-dd") & "',nama='" & TextBox3.Text & "',Keterangan='" & ComboBox1.Text & "',jambuka='" & TextBox4.Text & "',jamtutup='" & TextBox5.Text & "',htiket='" & TextBox6.Text & "',asuransi='" & TextBox7.Text & "',maxpengunjung='" & TextBox8.Text & "' where idwisata='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(EditData, conn)
            cmd.ExecuteNonQuery()
            Call kondisiawal()
            Exit Sub
        ElseIf Not rd.HasRows Then
            Call Koneksi()
            Dim InputData As String = "Insert into wisata values('" & TextBox1.Text & "','" & Format(Now, "yyyy-MM-dd") & "','" & TextBox3.Text & "','" & ComboBox1.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "')"
            cmd = New OdbcCommand(InputData, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Input", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call kondisiawal()
        End If
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
        Call Koneksi()
        da = New OdbcDataAdapter("select * from wisata where nama like'%" & TextBox9.Text & "%'", conn)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MessageBox.Show("Data Belum Lengkap", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show("Hapus Data Ini?", "Warning", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Call Koneksi()
            Dim HapusData As String = "delete from wisata where idwisata='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(HapusData, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Hapus", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call kondisiawal()
        End If
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        TextBox7.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value
        TextBox8.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value
    End Sub
End Class