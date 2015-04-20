Imports System.Data
Imports System.Data.OleDb
Partial Class PharmacyFirstPage
    Inherits System.Web.UI.Page
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim ds As DataSet = New DataSet()
    Dim dt As DataTable
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        con = New OleDbConnection(Class1.conStr)
        Class1.getCookie1()
        If IsPostBack = False Then
            getData()
        End If
    End Sub
    Protected Sub getData()
        Try
            Dim str As String = "select * from DoctorReview a inner join PatientMaster b on a.PatientID =b.PatientID inner join DoctorMaster c on a.ClinicID =c.ClinicID where PharmacyID =" & Session("PharmacyID") & "  and isnull(status,0)=0"
            da = New OleDbDataAdapter(str, con)
            da.Fill(ds)
            dt = ds.Tables(0)
            If Not dt Is Nothing Then
                gridleave.DataSource = dt
                gridleave.DataBind()
            End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error in GridBind')</script>")
        End Try
    End Sub
    Protected Sub gridleave_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles gridleave.SelectedIndexChanging
        Session("SNo") = gridleave.DataKeys(e.NewSelectedIndex)("SNo")
        Response.Redirect("Pharmacyprint.aspx")
    End Sub
End Class