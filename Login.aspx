<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Login Page
    </title>
</head>
<body style="background:url(bkg-blu.jpg) no-repeat;background-size:100%; height: 505px; width: 1047px;">
    <form id="form1" runat="server">
    <div>
        <table align="center" style="height: 478px; width: 844px; margin-left: 83px;" border="0" >
            <tr>
                <td colspan="2" align="center">
                    <h1>Login Page</h1>
                </td>
            </tr>
            <tr  align="center">
                <td  colspan ="2">
                    <asp:RadioButton ID="pharmacyBtn" Text="Pharmacy" align="center" runat="server" GroupName ="a"></asp:RadioButton> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="doctorBtn" Text="Doctor" align="center" runat="server" GroupName ="a"></asp:RadioButton>
                </td>
            </tr>
            <tr>
                <td align="right" style="width:380px">User Name:</td>
                <td align="left"><asp:TextBox ID="usernameTxt" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" style="width:380px">Password:</td>
                <td align="Left"><asp:TextBox ID="passwordTxt" runat="server" Text="Password:" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr align="center">
                <td colspan="2">
                    <asp:Button runat="server" ID="loginBtn" Text="Login" OnClick="loginBtn_Click" Height="36px" Width="77px"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" ID="editBtn" Text="Reset" OnClick="editBtn_Click" Height="39px" Width="72px"/>
                </td>
            </tr>
            <tr align="center">
                <td colspan="2">
                    <asp:HyperLink NavigateUrl="~/PharmacyRegistration.aspx" Text="New Pharmacist" runat="server"></asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:HyperLink NavigateUrl="~/DoctorRegistration.aspx" Text="New Doctor" runat="server"></asp:HyperLink>
                </td>
            </tr>
         </table>
    </div>
    </form>
</body>
</html>
