<%@ Page Title="" Language="VB"  AutoEventWireup="false" CodeFile="DoctorRegistration.aspx.vb" Inherits="DoctorRegistration" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Doctor Registration</title>
</head>
<body style="background:url(bkg-blu.jpg) no-repeat;background-size:100%;">
    <form id="form1" runat="server"> 
        <div>
            <table runat ="server" align="center" style="height: 338px; width: 422px">
                <tr>
                    <td colspan ="2">
                        <h1 align="center">Doctor Registration</h1>
                    </td>
                </tr> 
                <tr>
                    <td align="right">Doctor Name:</td>
                    <td align="left"><asp:TextBox ID="txtDoctorName" runat="server" Height="29px" Width="199px"/></td>
                </tr>
                <tr>
                    <td align="right">Degree Obtained:</td>
                    <td align="left"><asp:TextBox ID="txtDegree" runat="server" Height="29px" Width="199px"/></td>
                </tr>
                <tr>
                    <td align="right">UserName/E-Mail ID:</td>
                    <td align="left"><asp:TextBox ID="txtUserName" runat="server" Height="29px" Width="199px"/></td>
                </tr>
                <tr>
                    <td align="right">Password:</td>
                    <td align="left"><asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Height="29px" Width="199px"/></td>
                </tr>
                <tr>
                    <td align="right">Confirm Password:</td>
                    <td align="left"><asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" Height="29px" Width="199px"/></td>
                </tr>
                <tr>
                    <td align="right">Contact Number:</td>
                    <td align="left"><asp:TextBox ID="txtContactNumber" TextMode="Number" runat="server" Height="29px" Width="199px"/></td>
                </tr>
                <tr>
                    <td align="right">Clinic Address:</td>
                    <td align="left"><asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" Height="56px" Width="199px"/></td>
                </tr>
                <tr>
                    <td align="right">Pincode:</td>
                    <td align="left"><asp:TextBox ID="txtPincode" TextMode="Number" runat="server" Height="29px" Width="199px"/></td>
                </tr>
                <tr>
                    <td colspan=2 align="center">
                        <asp:Button ID="btnReset" Text="Reset" runat="server" style="height: 27px; width: 93px"/>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnsave" Text="Save" runat="server" style="height: 27px; width: 93px"/>
                    </td>    
                </tr>
            </table>
        </div>
    </form>
    </body>
</html>

