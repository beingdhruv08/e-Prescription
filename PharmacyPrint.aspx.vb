Imports System.Data
Imports System.Data.OleDb
Partial Class Pharmacyprint
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
    Protected Sub getBillID()
        ds = New DataSet()
        da = New OleDbDataAdapter("select year(getDate()) y,month(getDate()) m,day(getDate()) d ", con)
        da.Fill(ds)
        dt = ds.Tables(0)
        Dim y As String = dt.Rows(0)("y")
        Dim m As String = dt.Rows(0)("m")
        Dim d As String = dt.Rows(0)("d")
        ds = New DataSet()
        da = New OleDbDataAdapter(" select ChemistName p from PharmacyMaster where PharmacyID=" & Session("PharmacyID") & " ", con)
        da.Fill(ds)
        dt = ds.Tables(0)
        Dim str As String = dt.Rows(0)("p")
        ds = New DataSet()
        da = New OleDbDataAdapter("select count(*)+1 c from PharmacyPrint where EntryDate =convert(date, getDate(),103)  and PharmacyID=" & Session("PharmacyID") & "", con)
        da.Fill(ds)
        dt = ds.Tables(0)
        Dim n As String = dt.Rows(0)("c")
        labelBillID.Text = str + y + m + d + n
    End Sub
    Protected Sub getData()
        Try
            con.Open()
            ds = New DataSet()
            Dim str As String = "select * from DoctorReview a inner join DoctorPharmacyInventory b on a.SNo =b.itemNo inner join Item_Master c on b.itemName =c.itemName inner join PharmacyMaster d on c.PharmacyID =d.PharmacyID inner join DoctorMaster e on a.ClinicID=e.ClinicID where a.SNo=" & Session("SNo") & ""
            da = New OleDbDataAdapter(str, con)
            da.Fill(ds)
            dt = ds.Tables(0)
            gridleave.DataSource = dt
            gridleave.DataBind()
            labelDate.Text = dt.Rows(0)("entryDate")
            labelPatientID.Text = dt.Rows(0)("PatientID")
            labelPharmacyName.Text = dt.Rows(0)("PharmacyName")
            labelContact.Text = dt.Rows(0)("ContactNumber")
            labelDoctorName.Text = dt.Rows(0)("DoctorName")
            labelDoctorID.Text = dt.Rows(0)("ClinicID")
            getBillID()
            ds = New DataSet()
            Dim str2 As String = "select sum(T) tt from (select itemCost , b.itemQuantity , ( itemCost * b.itemQuantity ) T  from DoctorReview a inner join DoctorPharmacyInventory b on a.SNo =b.itemNo inner join Item_Master c on b.itemName =c.itemName inner join PharmacyMaster d on c.PharmacyID =d.PharmacyID inner join DoctorMaster e on a.ClinicID=e.ClinicID where a.SNo=" & Session("SNo") & ") q "
            da = New OleDbDataAdapter(str2, con)
            da.Fill(ds)
            dt = ds.Tables(0)
            labelTotalAmount.Text = dt.Rows(0)("tt")
            con.Close()
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error in GridBind')</script>")
        End Try
    End Sub
    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            con.Open()
            str = "insert into PharmacyPrint(EntryDate,PatientID,BillID,BillAmount,SNo,PharmacyID) values ('" & labelDate.Text & "','" & labelPatientID.Text & "','" & labelBillID.Text & "','" & labelTotalAmount.Text & "','" & Session("SNo") & "','" & Session("PharmacyID") & "') "
            cmd = New OleDbCommand(str, con)
            cmd.ExecuteScalar()
            str1 = "update DoctorReview set Status=1  where PharmacyID=" & Session("PharmacyID") & " and PatientID=" & labelPatientID.Text & " and SNo=" & Session("SNo") & ""
            cmd = New OleDbCommand(str1, con)
            cmd.ExecuteScalar()
            con.Close()
            Response.Redirect("PharmacyFirstPage.aspx")
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error in Printing')</script>")
        End Try
    End Sub
    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("PharmacyFirstPage.aspx")
    End Sub
End Class