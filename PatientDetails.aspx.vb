Imports System.Data
Imports System.Data.OleDb
Imports Class1
Partial Class PatientDetails
    Inherits System.Web.UI.Page
    Dim con As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet = New DataSet()
    Dim dt As DataTable
    Dim cmd As OleDbCommand
    Dim str As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        con = New OleDbConnection(conStr)
        Class1.getCookie()
        If IsPostBack = False Then
            getDate()
            getPatientID()
            btnUpdate.Visible = False
            getData()
        End If
    End Sub
    Protected Sub getDate()
        txtDate.Text = Class1.getDate()
        con.Close()
    End Sub
    Protected Sub getPatientID()
        ds = New DataSet()
        da = New OleDbDataAdapter("select year(getDate()) y,month(getDate()) m,day(getDate()) d ", con)
        da.Fill(ds)
        dt = ds.Tables(0)
        Dim y As String = dt.Rows(0)("y")
        Dim m As String = dt.Rows(0)("m")
        Dim d As String = dt.Rows(0)("d")
        ds = New DataSet()
        da = New OleDbDataAdapter("select count(*)+1 c from PatientMaster where EntryDate =convert(date, getDate(),103)  and ClinicID=" & Session("ClinicID") & "", con)
        da.Fill(ds)
        dt = ds.Tables(0)
        Dim n As String = dt.Rows(0)("c")
        txtPatientID.Text = y + m + d + n
    End Sub
    Protected Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            con.Open()
            If ViewState("PatientID") = "" Then
                str = "insert into PatientMaster(ClinicID,PatientID,EntryDate,PatientName,Age,PatientAddress,ContactNumber) values ('" & Session("ClinicID") & "','" & txtPatientID.Text & "',getdate() ,'" & txtPatientName.Text & "','" & txtAge.Text & "','" & txtAddress.Text & "','" & txtContactNumber.Text & "') "
                cmd = New OleDbCommand(str, con)
                cmd.ExecuteScalar()
                Session("PatientID") = txtPatientID.Text
                getData()
                clear()
                con.Close()
            Else
                Session("PatientID") = ViewState("PatientID")
            End If

        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error')</script>")
        End Try
        Response.Redirect("DoctorReview.aspx")

    End Sub
    Protected Sub getData()
        Try
            btnUpdate.Visible = False
            da = New OleDbDataAdapter("select * from PatientMaster where ClinicID=" & Session("ClinicID") & "", con)
            da.Fill(ds)
            dt = ds.Tables(0)
            grdData.DataSource = dt
            grdData.DataBind()
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Error')</script>")
        End Try
    End Sub
    Protected Sub clear()
        txtPatientID.Text = ""
        txtPatientName.Text = ""
        txtAddress.Text = ""
        txtAge.Text = ""
        txtContactNumber.Text = ""
        txtDate.Text = ""
        btnUpdate.Visible = False
    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            con.Open()
            da = New OleDbDataAdapter("update PatientMaster set PatientName='" & txtPatientName.Text & "',ContactNumber='" & txtContactNumber.Text & "',PatientAddress='" & txtAddress.Text & "',Age='" & txtAge.Text & "' where PatientID=" & ViewState("PatientID") & "", con)
            da.Fill(ds)
            getData()
            clear()
            Response.Write("<script language='javascript'> alert ('Updated')</script>")
            con.Close()
        Catch ex As Exception
            Response.Write("<script language='javascript'> alert ('Error')</script>")
        Finally
        End Try
    End Sub
    Protected Sub grdData_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdData.RowDeleting
        Try
            da = New OleDbDataAdapter("delete from PatientMaster where PatientID=" & grdData.DataKeys(e.RowIndex)("PatientID") & "", con)
            da.Fill(ds)
            Response.Write("<script language='javascript'> alert ('Deleted')</script>")
            getData()
        Catch ex As Exception
            Response.Write("<script language='javascript'> alert ('Error')</script>")
        End Try
    End Sub
    Protected Sub grdData_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles grdData.SelectedIndexChanging
        Try
            da = New OleDbDataAdapter("select * from PatientMaster where PatientID=" & grdData.DataKeys(e.NewSelectedIndex)("PatientID") & "", con)
            da.Fill(ds)
            dt = ds.Tables(0)
            ViewState("PatientID") = grdData.DataKeys(e.NewSelectedIndex)("PatientID")
            txtPatientID.Text = ViewState("PatientID")
            txtPatientName.Text = dt.Rows(0)("PatientName")
            txtAddress.Text = dt.Rows(0)("PatientAddress")
            txtAge.Text = dt.Rows(0)("Age")
            txtContactNumber.Text = dt.Rows(0)("ContactNumber")
            txtDate.Text = dt.Rows(0)("EntryDate")
            btnUpdate.Visible = True
        Catch ex As Exception
            Response.Write("<script language='javascript'> alert ('Error')</script>")
        End Try
    End Sub
End Class
