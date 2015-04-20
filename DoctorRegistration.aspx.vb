Imports System.Data
Imports System.Data.OleDb
Imports Class1
Partial Class DoctorRegistration
    Inherits System.Web.UI.Page
    Dim con As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet = New DataSet()
    Dim dt As DataTable
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        con = New OleDbConnection(conStr)
        Class1.getCookie()
        If IsPostBack = True Then
        End If
    End Sub
    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            con.Open()
            Response.Redirect("DoctorRegistration.aspx")
        Catch ex As Exception
            con.Close()
        End Try
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If txtPassword.Text <> txtConfirmPassword.Text Then
                Response.Write("<script language='javascript'>alert('Password Mistmatch')</script>")
                Exit Sub
            End If
            da = New OleDbDataAdapter("select * from DoctorMaster where DoctorName='" & txtDoctorName.Text & "' and EmailID='" & txtUserName.Text & "'", con)
            da.Fill(ds)
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                Response.Write("<script language='javascript'>alert('Same Username Exist or E-Mail ID exist')</script>")
                Exit Sub
            End If
            da = New OleDbDataAdapter("insert into DoctorMaster(entryDate,Degree,DoctorName,Contactnumber,EmailID,Password1,Address,Pincode) values( getdate() ,'" & txtDegree.Text & "','" & txtDoctorName.Text & "','" & txtContactNumber.Text & "','" & txtUserName.Text & "','" & txtPassword.Text & "','" & txtAddress.Text & "','" & txtPincode.Text & "')", con)
            da.Fill(ds)
            con.Close()
            Response.Write("<script language='javascript'>alert('Please Login Again')</script>")
            Response.Redirect("login.aspx")
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error')</script>")
        End Try
    End Sub
End Class
