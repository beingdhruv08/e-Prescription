Imports System.Data
Imports System.Data.OleDb
Imports Class1
Partial Class PharmacyAccount
    Inherits System.Web.UI.Page
    Dim con As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim cmd As OleDbCommand
    Dim ds As DataSet = New DataSet()
    Dim dt As DataTable
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        con = New OleDbConnection(conStr)
        Class1.getCookie1()
        If IsPostBack = False Then
            getData()
        End If
    End Sub
    Protected Sub getData()
        Try
            da = New OleDbDataAdapter("select * from PharmacyMaster where PharmacyID=" & Session("PharmacyID") & "", con)
            da.Fill(ds)
            dt = ds.Tables(0)
            txtAddress.Text = dt.Rows(0)("Address")
            txtPharmacyName.Text = dt.Rows(0)("PharmacyName")
            txtPassword.Text = dt.Rows(0)("Password1")
            txtNumber.Text = dt.Rows(0)("ContactNumber")
            txtLoginname.Text = dt.Rows(0)("EmailID")
            txtChemistName.Text = dt.Rows(0)("ChemistName")
            txtAbout.Text = dt.Rows(0)("About")
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error')</script>")
        End Try
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            con.Open()
            If txtPassword.Text <> txtConfirm.Text Then
                Response.Write("<script language='javascript'>alert('Password Mistmatch')</script>")
                Exit Sub
            End If
            da = New OleDbDataAdapter("select * from PharmacyMaster where PharmacyName='" & txtPharmacyName.Text & "' and EmailID='" & txtLoginname.Text & "' and PharmacyID <> '" & Session("PharmacyID") & "'", con)
            da.Fill(ds)
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                Response.Write("<script language='javascript'>alert('Same Username Exist or E-Mail ID exist')</script>")
                Exit Sub
            End If
            Dim str As String = "insert into PharmacyMaster(EntryDate,PharmacyName,EmailID,ChemistName,Address,ContactNumber,Password1,About) values ( getdate(), '" & txtPharmacyName.Text & "','" & txtLoginname.Text & "','" & txtChemistName.Text & "','" & txtAddress.Text & "','" & txtNumber.Text & "','" & txtPassword.Text & "','" & txtAbout.Text & "') "
            cmd = New OleDbCommand(str, con)
            cmd.ExecuteScalar()
            con.Close()
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error')</script>")
        End Try
    End Sub
End Class
