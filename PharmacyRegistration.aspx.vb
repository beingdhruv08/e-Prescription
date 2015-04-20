Imports System.Data
Imports System.Data.OleDb
Imports Class1
Partial Class PharmacyRegistration
    Inherits System.Web.UI.Page
    Dim con As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet = New DataSet()
    Dim dt As DataTable
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        con = New OleDbConnection(conStr)
        Class1.getCookie1()
        If IsPostBack = True Then

        End If
    End Sub
    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            con.Open()
            Response.Redirect("PharmacyRegistration.aspx")
        Catch ex As Exception
            con.Close()
        End Try
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If txtPassword.Text <> txtConfirm.Text Then
                Response.Write("<script language='javascript'>alert('Password Mistmatch')</script>")
                Exit Sub
            End If
            da = New OleDbDataAdapter("select * from PharmacyMaster where PharmacyName='" & txtPharmacyName.Text & "' and EmailID='" & txtLoginname.Text & "'", con)
            da.Fill(ds)
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                Response.Write("<script language='javascript'>alert('Same Username Exist or E-Mail ID exist')</script>")
                Exit Sub
            End If
            da = New OleDbDataAdapter("insert into PharmacyMaster(entryDate,PharmacyName,EmailID,ChemistName,Address,ContactNumber,Password1,About) values( getdate() ,'" & txtPharmacyName.Text & "','" & txtLoginname.Text & "','" & txtChemistName.Text & "','" & txtAddress.Text & "','" & txtNumber.Text & "','" & txtPassword.Text & "','" & txtAbout.Text & "')", con)
            da.Fill(ds)
            con.Close()
            Response.Redirect("login.aspx")
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error')</script>")
        End Try
    End Sub
End Class
