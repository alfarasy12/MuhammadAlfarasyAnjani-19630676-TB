Public Class LAPORAN

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CrystalReportViewer1.ReportSource = "DATAWISATA.rpt"
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CrystalReportViewer1.ReportSource = "DATATIKET.rpt"
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class