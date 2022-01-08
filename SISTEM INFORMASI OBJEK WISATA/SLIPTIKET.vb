Public Class SLIPTIKET

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        CrystalReportViewer1.ReportSource = "TIKET.rpt"
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub SLIPTIKET_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class