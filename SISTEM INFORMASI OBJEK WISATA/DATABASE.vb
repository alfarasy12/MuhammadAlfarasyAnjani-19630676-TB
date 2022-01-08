Imports System.Data.Odbc
Module DATABASE
    Public conn As OdbcConnection
    Public da As OdbcDataAdapter
    Public ds As DataSet
    Public cmd As OdbcCommand
    Public rd As OdbcDataReader = Nothing
    Sub Koneksi()
        Try
            conn = New OdbcConnection("DSN=WISATA;MultipleActiveResultSets=true")
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MsgBox("Koneksi Ke Database Gagal")
        End Try
    End Sub
End Module
