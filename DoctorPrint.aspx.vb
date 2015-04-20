Imports System.Data
Imports System.Data.OleDb
Imports Class1
Partial Class DoctorPrint
    Inherits System.Web.UI.Page
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim ds As DataSet = New DataSet()
    Dim dt As DataTable
    Dim str As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        con = New OleDbConnection(Class1.conStr)
        Class1.getCookie()
        If IsPostBack = False Then
            getDetail()
        End If
    End Sub
    Protected Sub getDetail()
        ds = New DataSet()
        da = New OleDbDataAdapter(" select PatientID,ContactNumber from PatientMaster where ClinicID=" & Session("ClinicID") & " and PatientID=" & Session("PatientID") & "", con)
        da.Fill(ds)
        dt = ds.Tables(0)
        lab_date.Text = Class1.getDate()
        lab_patientid.Text = dt.Rows(0)("PatientID")
        lab_contact.Text = dt.Rows(0)("ContactNumber")
        ds = New DataSet()
        da = New OleDbDataAdapter("select DoctorName from DoctorMaster where ClinicID= " & Session("ClinicID") & " ", con)
        da.Fill(ds)
        dt = ds.Tables(0)
        lab_DoctorName.Text = dt.Rows(0)("DoctorName")
        gridleave.DataSource = dt
        ds = New DataSet()
        da = New OleDbDataAdapter("select * from DoctorPharmacyInventory where itemNo= " & Session("SNo") & " ", con)
        da.Fill(ds)
        dt = ds.Tables(0)
        gridleave.DataSource = dt
        gridleave.DataBind()
        con.Close()
    End Sub
    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
            Response.Redirect("DoctorPharmacyInventory.aspx")
    End Sub
End Class