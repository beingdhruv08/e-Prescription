Imports System.Data
Imports System.Data.OleDb
Imports Class1
Partial Class DoctorPharmacyInventory
    Inherits System.Web.UI.Page
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim Str As String
    Dim str1 As String
    Dim var As Integer
    Dim name As String
    Dim ds As DataSet = New DataSet()
    Dim dt As DataTable
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        con = New OleDbConnection(conStr)
        Class1.getCookie()
        If IsPostBack = False Then
            getData()
        End If
    End Sub
    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            con.Open()
            con.Close()
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error')</script>")
        Finally
            Response.Redirect("DoctorPrint.aspx")
        End Try
    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            con.Open()
            Str = "insert into DoctorPharmacyInventory(itemNo,itemName,itemQuantity) values ('" & Session("SNo") & "', '" & ddlMedicine.SelectedValue & "', '" & txtPillsRequired.Text & "' )"
            cmd = New OleDbCommand(Str, con)
            con.Close()
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error')</script>")
        End Try
    End Sub
    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("DoctorReview.aspx")
    End Sub
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            con.Open()
            ds = New DataSet()
            da = New OleDbDataAdapter("select * from Item_Master where itemID='" & ddlMedicine.SelectedValue & "' and PharmacyID=" & Session("PharmacyID") & "", con)
            da.Fill(ds)
            dt = ds.Tables(0)
            name = dt.Rows(0)("itemName")
            var = dt.Rows(0)("itemQuantity")
            If Val(txtPillsRequired.Text) > Val(var) Then
                con.Close()
                Response.Write("<script language='javascript'>alert('Sorry left with only " + var.ToString() + " number of pills!')</script>")
                Exit Sub
            End If
            Str = "insert into DoctorPharmacyInventory(itemNo,itemName,itemQuantity) values ('" & Session("SNo") & "', '" & name & "', '" & txtPillsRequired.Text & "' )"
            cmd = New OleDbCommand(Str, con)
            cmd.ExecuteScalar()
            var = var - txtPillsRequired.Text
            str1 = "update Item_Master set itemQuantity='" & var & "' where itemID=" & ddlMedicine.SelectedValue & " and PharmacyID='" & Session("PharmacyID") & "'"
            cmd = New OleDbCommand(str1, con)
            cmd.ExecuteScalar()
            da = New OleDbDataAdapter("select * from DoctorPharmacyInventory where itemNo='" & Session("SNo") & "'", con)
            ds = New DataSet()
            da.Fill(ds)
            dt = ds.Tables(0)
            gridleave.DataSource = dt
            gridleave.DataBind()
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error')</script>")
        End Try
    End Sub
    Protected Sub getData()
        Try
            ddlMedicine.DataSource = getData1("select itemName,Itemid from Item_Master where PharmacyID=" & Session("PharmacyID") & "")
            ddlMedicine.DataTextField = "itemName"
            ddlMedicine.DataValueField = "itemID"
            ddlMedicine.DataBind()
            btnPrint.Visible = True
            btnBack.Visible = True
            btnUpdate.Visible = False
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error')</script>")
        End Try
    End Sub
    Protected Sub gridleave_Click(sender As Object, e As GridViewDeleteEventArgs) Handles gridleave.RowDeleting
        Try
            Str = "delete from PatientMaster where PatientID=" & gridleave.DataKeys(e.RowIndex)("PatientID") & ""
            cmd = New OleDbCommand(Str, con)
            cmd.ExecuteScalar()
            getData()
            Response.Write("<script language='javascript'> alert ('Deleted')</script>")
        Catch ex As Exception
            Response.Write("<script language='javascript'> alert ('Error')</script>")
        End Try

    End Sub
    Protected Sub gridleave_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles gridleave.SelectedIndexChanging
        Try
            da = New OleDbDataAdapter("select * from DoctorPharmacyInventory where itemNo=" & gridleave.DataKeys(e.NewSelectedIndex)("itemNo") & " and itemName ='" & gridleave.DataKeys(e.NewSelectedIndex)("itemName") & "'", con)
            da.Fill(ds)
            dt = ds.Tables(0)
            ViewState("itemNo") = gridleave.DataKeys(e.NewSelectedIndex)("itemNo")
            ddlMedicine.SelectedItem.Text = dt.Rows(0)("itemName")
            txtPillsRequired.Text = dt.Rows(0)("itemQuantity")
            btnUpdate.Visible = True
        Catch ex As Exception
            Response.Write("<script language='javascript'> alert ('Error')</script>")
        End Try
    End Sub
    Protected Function getData1(ByVal str As String) As DataTable
        da = New OleDbDataAdapter(str, con)
        da.Fill(ds)
        dt = ds.Tables(0)
        Return dt
    End Function
End Class
