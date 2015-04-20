Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Public Class Class1
    Dim con As OleDbConnection
    Public Shared conStr As String = "Provider=SQLOLEDB.1; Data Source = POORVAK-PC\SQLEXPRESS;Initial Catalog= E-Prescription; Persist Security Info= False; Integrated Security = SSPI"
    Public Shared Function getData(ByVal str As String) As DataTable
        Dim con As OleDbConnection = New OleDbConnection(Class1.conStr)
        Dim da As OleDbDataAdapter
        Dim ds As DataSet = New DataSet()
        Dim dt As DataTable
        da = New OleDbDataAdapter(str, con)
        da.Fill(ds)
        dt = ds.Tables(0)
        Return dt
    End Function
    Public Shared Sub getCookie()
        Dim session As HttpSessionState = HttpContext.Current.Session
        Dim request As HttpRequest = HttpContext.Current.Request
        Dim response As HttpResponse = HttpContext.Current.Response
        If session("ClinicID") Is Nothing Then
            If Not request.Cookies("ck") Is Nothing Then
                Dim a As String = HttpContext.Current.Server.HtmlEncode(request.Cookies("ck").Value)
                ' Dim b As String() = a.Split("#")
                session("ClinicID") = a
                Dim ck As New HttpCookie("ck")
                ck.Value = session("ClinicID")
                response.Cookies.Add(ck)
            End If
        End If
    End Sub
    Public Shared Sub getCookie1()
        Dim session As HttpSessionState = HttpContext.Current.Session
        Dim request As HttpRequest = HttpContext.Current.Request
        Dim response As HttpResponse = HttpContext.Current.Response
        If session("PharmacyID") Is Nothing Then
            If Not request.Cookies("ck") Is Nothing Then
                Dim a As String = HttpContext.Current.Server.HtmlEncode(request.Cookies("ck").Value)
                ' Dim b As String() = a.Split("#")
                session("PharmacyID") = a
                Dim ck As New HttpCookie("ck")
                ck.Value = session("PharmacyID")
                response.Cookies.Add(ck)
            End If
        End If
    End Sub
    Public Shared Function getOrderNo() As Date
        Dim con As OleDbConnection = New OleDbConnection(Class1.conStr)
        Dim da As OleDbDataAdapter
        Dim ds As DataSet = New DataSet()
        Dim dt As DataTable
        da = New OleDbDataAdapter("select day(getDate()) d,month(getDate()) m,year(getDate()) y", con)
        da.Fill(ds)
        dt = ds.Tables(0)
        Dim datee As Date
        datee = dt.Rows(0)("d") + dt.Rows(0)("m") + dt.Rows(0)("y")
        con.Close()
        Return datee
    End Function
    Public Shared Function getDate() As Date
        Dim con As OleDbConnection = New OleDbConnection(Class1.conStr)
        Dim da As OleDbDataAdapter
        Dim ds As DataSet = New DataSet()
        Dim dt As DataTable
        da = New OleDbDataAdapter("select day(getDate()) d,month(getDate()) m,year(getDate()) y", con)
        da.Fill(ds)
        dt = ds.Tables(0)
        Dim datee As Date
        datee = dt.Rows(0)("d").ToString() + "-" + MonthName(dt.Rows(0)("m").ToString()) + "-" + dt.Rows(0)("y").ToString()
        con.Close()
        Return datee
    End Function
    Public Shared Sub getOpen()
        Dim con As OleDbConnection
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub
End Class
