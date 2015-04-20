Imports System.Data
Imports System.Data.OleDb
Partial Class Login
    Inherits System.Web.UI.Page
    Dim con As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet = New DataSet()
    Dim dt As DataTable
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        con = New OleDbConnection(Class1.conStr)
        If IsPostBack = True Then
        End If
    End Sub
    Protected Sub loginBtn_Click(sender As Object, e As EventArgs) Handles loginBtn.Click
        Try
            If doctorBtn.Checked = True Then
                da = New OleDbDataAdapter("select * from DoctorMaster where EmailID='" & usernameTxt.Text & "' and Password1= '" & passwordTxt.Text & "'", con)
                da.Fill(ds)
                dt = ds.Tables(0)
                If dt.Rows.Count > 0 Then
                    Session("ClinicID") = dt.Rows(0)("ClinicID")
                    Dim ck As New HttpCookie("ck")
                    ck.Value = Session("ClinicID")
                    Response.Cookies.Add(ck)
                    Response.Redirect("PatientDetails.aspx")
                End If
            End If
            If pharmacyBtn.Checked = True Then
                da = New OleDbDataAdapter("select * from PharmacyMaster where emailid='" & usernameTxt.Text & "' and password1= '" & passwordTxt.Text & "'", con)
                da.Fill(ds)
                dt = ds.Tables(0)
                If dt.Rows.Count > 0 Then
                    Session("PharmacyID") = dt.Rows(0)("PharmacyID")
                    Dim ck As New HttpCookie("ck")
                    ck.Value = Session("PharmacyID")
                    Response.Cookies.Add(ck)
                    Response.Redirect("PharmacyFirstPage.aspx")
                End If
            End If
            
        Catch ex As Exception
        Finally
            con.Close()
        End Try

    End Sub
    Protected Sub editBtn_Click(sender As Object, e As EventArgs) Handles editBtn.Click
        Try
            Response.Redirect("login.aspx")
        Catch ex As Exception
        Finally
            con.Close()
        End Try
    End Sub
End Class
