Imports System.Data.OleDb
Imports System.Data
Imports Class1
Partial Class PharmacyLogout
    Inherits System.Web.UI.Page
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim Str As String
    Dim ds As DataSet = New DataSet()
    Dim dt As DataTable
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        con = New OleDbConnection(conStr)
        If IsPostBack = False Then
            Session.Abandon()
            Response.Redirect("Login.aspx")
        End If
    End Sub

End Class

Partial Class PharmacyLogout
    Inherits System.Web.UI.Page

End Class
