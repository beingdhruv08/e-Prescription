Imports System.Data
Imports System.Data.OleDb
Partial Class ItemMaster
    Inherits System.Web.UI.Page
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim ds As DataSet = New DataSet()
    Dim dt As DataTable
    Dim str As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        con = New OleDbConnection(Class1.conStr)
        Class1.getCookie1()
        If IsPostBack = False Then
            getData()
        End If
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try
            con.Open()
            da = New OleDbDataAdapter("select * from Item_Master where itemName='" & txt_medicinename.Text & "'", con)
            da.Fill(ds)
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                Response.Write("<script language='javascript'>alert('Same Medicine Name Exist')</script>")
                clear()
                Exit Sub
            End If
            str = "insert into Item_Master(PharmacyID,entryDate,itemName,itemQuantity,itemManufacturer,itemCost,itemThreshold,Status,itemOrderQuantity) values ('" & Session("PharmacyID") & "',getdate(),'" & txt_medicinename.Text & "','" & txt_quantity.Text & "','" & txt_manuname.Text & "','" & txt_cost.Text & "','" & txtThreshold.Text & "','" & 0 & "','" & txtQuantityOrder.Text & "') select SCOPE_IDENTITY()"
            cmd = New OleDbCommand(str, con)
            Session("ItemID") = cmd.ExecuteScalar()
            con.Close()
            getData()
            clear()
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error')</script>")
        Finally
            con.Close()
        End Try
    End Sub
    Protected Sub getData()
        Try
            da = New OleDbDataAdapter("select * from Item_Master", con)
            da.Fill(ds)
            dt = ds.Tables(0)
            gridleave.DataSource = dt
            gridleave.DataBind()
            btn_save.Visible = True
            btn_update.Visible = False
            btnNew.Visible = True
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('error')</script>")
        End Try
    End Sub
    Protected Sub clear()
        txt_manuname.Text = ""
        txt_medicinename.Text = ""
        txt_quantity.Text = ""
        txt_cost.Text = ""
        txtThreshold.Text = ""
        txtQuantityOrder.Text = ""
        btn_save.Visible = True
        btn_update.Visible = False
    End Sub
    Protected Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        Try
            con.Open()
            da = New OleDbDataAdapter("update Item_Master set itemName='" & txt_medicinename.Text & "',itemQuantity='" & txt_quantity.Text & "',itemManufacturer='" & txt_manuname.Text & "',itemCost='" & txt_cost.Text & "' where itemID=" & ViewState("ItemID") & "", con)
            da.Fill(ds)
            con.Close()
            getData()
            clear()
            Response.Write("<script language='javascript'> alert ('Updated')</script>")
        Catch ex As Exception
            Response.Write("<script language='javascript'> alert ('Error')</script>")
        Finally
            con.Close()
        End Try
    End Sub

    Protected Sub gridleave_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gridleave.RowDeleting
        Try

        da = New OleDbDataAdapter("delete from Item_Master where itemID=" & gridleave.DataKeys(e.RowIndex)("itemID") & "", con)
        da.Fill(ds)
            getData()
        Catch ex As Exception
            Response.Write("<script language='javascript'> alert ('Error in Deletion')</script>")
        End Try

    End Sub
    Protected Sub gridleave_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles gridleave.SelectedIndexChanging
        Try
            da = New OleDbDataAdapter("select * from Item_Master where itemID=" & gridleave.DataKeys(e.NewSelectedIndex)("itemID") & "", con)
            da.Fill(ds)
            dt = ds.Tables(0)
            ViewState("ItemID") = gridleave.DataKeys(e.NewSelectedIndex)("itemID")
            txt_manuname.Text = dt.Rows(0)("itemManufacturer")
            txt_medicinename.Text = dt.Rows(0)("itemName")
            txt_quantity.Text = dt.Rows(0)("itemQuantity")
            txt_cost.Text = dt.Rows(0)("itemCost")
            txtThreshold.Text = dt.Rows(0)("itemThreshold")
            txtQuantityOrder.Text = dt.Rows(0)("itemOrderQuantity")
            btn_save.Visible = False
            btn_update.Visible = True
        Catch ex As Exception
            Response.Write("<script language='javascript'> alert ('Error in Selection')</script>")
        End Try
    End Sub
    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        clear()
    End Sub
End Class