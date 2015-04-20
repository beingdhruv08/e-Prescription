Imports System.Data
Imports System.Data.OleDb
Imports Class1
Partial Class DoctorAccount
    Inherits System.Web.UI.Page
    Dim con As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim cmd As OleDbCommand
    Dim ds As DataSet = New DataSet()
    Dim dt As DataTable
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        con = New OleDbConnection(conStr)
        Class1.getCookie()
        If IsPostBack = False Then
            getData()
        End If
    End Sub
    Protected Sub getData()
        Try
            da = New OleDbDataAdapter("select * from DoctorMaster where ClinicID=" & Session("ClinicID"), con)
            da.Fill(ds)
            dt = ds.Tables(0)
            txtAddress.Text = dt.Rows(0)("Address")
            txtContactNumber.Text = dt.Rows(0)("Contactnumber")
            txtDegree.Text = dt.Rows(0)("Degree")
            txtDoctorName.Text = dt.Rows(0)("DoctorName")
            txtPincode.Text = dt.Rows(0)("Pincode")
            txtUserName.Text = dt.Rows(0)("EmailID")
            txtPassword.Text = dt.Rows(0)("Password1")
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error')</script>")
        End Try
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            con.Open()
            If txtPassword.Text <> txtConfirmPassword.Text Then
                Response.Write("<script language='javascript'>alert('Password Mistmatch')</script>")
                Exit Sub
            End If
            da = New OleDbDataAdapter("select * from DoctorMaster where EmailID='" & txtUserName.Text & "' and ClinicID <> '" & Session("ClinicID") & "' ", con)
            da.Fill(ds)
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                Response.Write("<script language='javascript'>alert('Same E-Mail ID Exist')</script>")
                Exit Sub
            End If
            Dim str As String = "update DoctorMaster set Degree='" & txtDegree.Text & "',DoctorName='" & txtDoctorName.Text & "',Contactnumber='" & txtContactNumber.Text & "',EmailID='" & txtUserName.Text & "',Password1='" & txtPassword.Text & "',Address='" & txtAddress.Text & "',Pincode='" & txtPincode.Text & "' where ClinicID='" & Session("ClinicID") & "'"
            cmd = New OleDbCommand(str, con)
            cmd.ExecuteScalar()
            con.Close()
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error')</script>")
        Finally
            con.Close()
        End Try
    End Sub
End Class
