Imports System.Data
Imports System.Data.OleDb
Partial Class PharmacyPurchaseReceived
    Inherits System.Web.UI.Page
    Dim con As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim cmd As OleDbCommand
    Dim str As String
    Dim ds As DataSet = New DataSet()
    Dim dt As DataTable
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        con = New OleDbConnection(Class1.conStr)
        Class1.getCookie1()
        If IsPostBack = True Then
            getData()
        End If
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            con.Open()
            ds = New DataSet()
            da = New OleDbDataAdapter("select c.MedicineName,c.Quantity,a.itemManufacturer,((a.itemCost-.5)*c.Quantity) aa,b.Supplier from Order_Master b inner join OrderMaster_detail c on b.OrderID =c.OrderNo inner join Item_Master a on a.itemName =c.MedicineName where b.OrderNo=" & txtOrderNumber.Text & " and ISNULL(status,0)=1 and a.PharmacyID=" & Session("PharmacyID") & "", con)
            da.Fill(ds)
            dt = ds.Tables(0)
            For i = 0 To dt.Rows.Count - 1
                str = "update Item_Master set Status=0 where PharmacyID=" & Session("PharmacyID") & " and itemName='" & dt.Rows(i)("MedicineName") & "' and ISNULL(Status,0)=1"
                cmd = New OleDbCommand(str, con)
                cmd.ExecuteScalar()
            Next
            Response.Write("<script language='javascript'>alert('Value Updated!')</script>")
            con.Close()
            Response.Redirect("PharmacyFirstPage.aspx")
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error in Saving Data!')</script>")
        End Try
    End Sub
    Protected Sub getData()
        labelDateOfReceived.Text = Class1.getDate()
    End Sub
    Protected Sub gridleave_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles gridleave.SelectedIndexChanging
        Try
            con.Open()
            ds = New DataSet()
            Dim orderdQuantity As Integer = gridleave.DataKeys(e.NewSelectedIndex)("Quantity")
            Dim itemName As String = gridleave.DataKeys(e.NewSelectedIndex)("MedicineName")
            Dim str As String = "update Item_Master set Status=0,itemQuantity=itemQuantity+" & orderdQuantity & "  where PharmacyID=" & Session("PharmacyID") & " and itemName='" & itemName & "'"
            cmd = New OleDbCommand(str, con)
            cmd.ExecuteScalar()
            ds = New DataSet()
            Dim str2 As String = "select sum(aa) tt from (select c.MedicineName,c.Quantity,a.itemManufacturer,((a.itemCost-.5)*c.Quantity) aa,b.Supplier from Order_Master b inner join OrderMaster_detail c on b.OrderID =c.OrderNo inner join Item_Master a on a.itemName =c.MedicineName  where b.OrderNo=" & txtOrderNumber.Text & " and a.PharmacyID=" & Session("PharmacyID") & " and ISNULL(status,0)=0) q "
            da = New OleDbDataAdapter(str2, con)
            da.Fill(ds)
            dt = ds.Tables(0)
            labelTotalAmount.Text = Val(labelTotalAmount.Text) + Val(dt.Rows(0)("tt"))
            getData1()
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error in Selection!')script>")
        End Try
    End Sub
    Protected Sub BtnFetch_Click(sender As Object, e As EventArgs) Handles BtnFetch.Click
        Try
            getData1()
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error in Fetching Data!')</script>")
        End Try
    End Sub
    Sub getData1()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            ds = New DataSet()
            da = New OleDbDataAdapter("select c.MedicineName,c.Quantity,a.itemManufacturer,((a.itemCost-.5)*c.Quantity) aa,b.Supplier from Order_Master b inner join OrderMaster_detail c on b.OrderID =c.OrderNo inner join Item_Master a on a.itemName =c.MedicineName where b.OrderNo=" & txtOrderNumber.Text & " and a.PharmacyID=" & Session("PharmacyID") & " and isNULL(status,0)=1", con)
            da.Fill(ds)
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                labelSupplierName.Text = dt.Rows(0)("Supplier")
                gridleave.DataSource = dt
                gridleave.DataBind()
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            Else
                gridleave.DataSource = Nothing
                gridleave.DataBind()
            End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error in Fetching Data!')</script>")
        End Try
    End Sub
End Class