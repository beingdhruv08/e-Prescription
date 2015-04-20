Imports System.Data
Imports System.Data.OleDb
Partial Class PharmacyPurchaseOrder
    Inherits System.Web.UI.Page
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim ds As DataSet = New DataSet()
    Dim dt As DataTable
    Dim str As String
    Dim str1 As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        con = New OleDbConnection(Class1.conStr)
        Class1.getCookie1()
        If IsPostBack = False Then
            getData()
        End If
    End Sub
    Protected Sub getOrderNo()
        ds = New DataSet()
        da = New OleDbDataAdapter("select year(getDate()) y,month(getDate()) m,day(getDate()) d ", con)
        da.Fill(ds)
        dt = ds.Tables(0)
        Dim y As String = dt.Rows(0)("y")
        Dim m As String = dt.Rows(0)("m")
        Dim d As String = dt.Rows(0)("d")
        ds = New DataSet()
        da = New OleDbDataAdapter("select count(*)+1 c from Order_Master where entryDate =convert(date, getDate(),103)  and PharmacyID=" & Session("PharmacyID") & "", con)
        da.Fill(ds)
        dt = ds.Tables(0)
        Dim n As String = dt.Rows(0)("c")
        labelordernumber.Text = y + m + d + n
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            con.Open()
            Dim str As String = "insert into Order_Master(entryDate,OrderNo,PharmacyID,Supplier) values (getdate(),'" & labelordernumber.Text & "' ,'" & Session("PharmacyID") & "','" & txt_manuname.Text & "') select SCOPE_IDENTITY()"
            cmd = New OleDbCommand(str, con)
            Session("OrderId") = cmd.ExecuteScalar()
            ds = New DataSet()
            da = New OleDbDataAdapter("select itemName,isnull(itemOrderQuantity,0) itemOrderQuantity from Item_Master where isnull(Status,0)=0 and itemQuantity < itemThreshold", con)
            da.Fill(ds)
            dt = ds.Tables(0)
            Dim str1 As String
            For i = 0 To dt.Rows.Count - 1
                str1 = " insert into OrderMaster_detail(OrderNo,MedicineName,Quantity) values ('" & Session("OrderId") & "','" & dt.Rows(i)("itemName") & "','" & dt.Rows(i)("itemOrderQuantity") & "') "
                cmd = New OleDbCommand(str1, con)
                cmd.ExecuteScalar()
            Next
            Dim str2 As String = " update Item_Master set Status=1 where PharmacyID=" & Session("PharmacyID") & ""
            cmd = New OleDbCommand(str2, con)
            cmd.ExecuteScalar()
            con.Close()
            Response.Write("<script language='javascript'>alert('Order Placed')</script>")
            Response.Redirect("PharmacyFirstPage.aspx")
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error')</script>")
        End Try
    End Sub
    Protected Sub getData()
        Try
            getOrderNo()
            labelDate.Text = Class1.getDate()
            ds = New DataSet()
            da = New OleDbDataAdapter("select itemName,isnull(itemOrderQuantity,0) itemOrderQuantity from Item_Master where isnull(Status,0)=0 and itemQuantity < itemThreshold", con)
            da.Fill(ds)
            dt = ds.Tables(0)
            gridleave.DataSource = dt
            gridleave.DataBind()
            
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error')</script>")
        End Try
    End Sub
    Protected Sub btnNewMedicine_Click(sender As Object, e As EventArgs) Handles btnNewMedicine.Click
        Response.Redirect("ItemMaster.aspx")
    End Sub
End Class