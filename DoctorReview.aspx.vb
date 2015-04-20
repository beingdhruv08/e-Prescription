Imports System.Data.OleDb
Imports System.Data
Imports Class1
Partial Class DoctorReview
    Inherits System.Web.UI.Page
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim Str As String
    Dim ds As DataSet = New DataSet()
    Dim dt As DataTable
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        con = New OleDbConnection(conStr)
        Class1.getCookie()
        If IsPostBack = False Then
            getData()
        End If
    End Sub
    Protected Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            con.Open()
            Str = "insert into DoctorReview(PatientID,ClinicID,EntryDate,PharmacyID,Disease,Status) values ('" & Session("PatientID") & "','" & Session("ClinicID") & "',getdate() ,'" & ddl1.SelectedValue() & "','" & txtDisease.Text & "','" & 0 & "') select SCOPE_IDENTITY() "
            cmd = New OleDbCommand(Str, con)
            Session("SNo") = cmd.ExecuteScalar()
            Session("PharmacyID") = ddl1.SelectedValue()
            getData()
            clear()
            con.Close()
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error')</script>")
        End Try
        Response.Redirect("DoctorPharmacyInventory.aspx")
    End Sub
    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Try
            con.Open()
        Catch ex As Exception
            Response.Redirect("<script language='javascript'>alert('Error')</script>")
        End Try
        Response.Redirect("PatientDetails.aspx")
        con.Close()
    End Sub
    Protected Sub getData()
        Try
            ddl1.DataSource = getData1("select * from PharmacyMaster")
            ddl1.DataTextField = "PharmacyName"
            ddl1.DataValueField = "Pharmacyid"
            ddl1.DataBind()
            btnNext.Visible = True
            btnBack.Visible = True
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error')</script>")
        End Try
    End Sub
    Protected Function getData1(ByVal str As String) As DataTable
        da = New OleDbDataAdapter(str, con)
        da.Fill(ds)
        dt = ds.Tables(0)
        Return dt
    End Function
    Protected Sub clear()
        txtDisease.Text = ""
    End Sub
End Class
