<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PharmacyRegistration.aspx.vb" Inherits="PharmacyRegistration" %>
<!DOCTYPE html>
<script runat="server">
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pharmacy Login</title>
    <div>
        <h1 align="center">Pharmacy Registration</h1>
    </div>
</head>
<body style="background:url(bkg-blu.jpg) no-repeat;background-size:100%;">
    <form id="form1" runat="server">
    <div>
     <table runat="server" align="center" style="height: 449px; width: 678px">
        <tr>
            <td align="right" >Pharmacy Name*</td>
            <td align="left" ><asp:TextBox ID="txtPharmacyName" runat="server" TextMode="SingleLine" MaxLength="50"/></td>
        </tr>
        <tr>
            <td align="right" class="auto-style2">Login Name/E-mail ID*
            <%--<asp:RegularExpressionValidator ID="emailExpressionValidater" runat="server" Display="Dynamic" ErrorMessage="Inavlid Format of E-mail ID"
            ValidationExpression="^$"
            SetFocusOnError="True" />
                sir se poochna hai ki email validation expression kaise likhte hain--%>
            </td>
            <td align="left" ><asp:TextBox runat="server" ID="txtLoginname" TextMode="SingleLine"/></td>
        </tr>
        <tr>
            <td align="right" class="auto-style2">Password*</td>
            <td align="left" ><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"/></td>
        </tr>
        <tr>
            <td align="right" class="auto-style2">Confirm Password*</td>
            <td align="left" ><asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"/>
            </td>
        </tr>

        <tr>
            <td align="right" class="auto-style2">Pharmacy Address*</td>
            <td align="left" ><asp:TextBox runat="server" ID="txtAddress" TextMode="MultiLine" /></td>
        </tr>
        <tr>
            <td align="right" class="auto-style2">Head Chemist Name*</td>
            <td align="left" ><asp:TextBox runat="server" ID="txtChemistName" TextMode="SingleLine" /></td>
        </tr>
        <tr>
            <td align="right" class="auto-style2">Pharmacy Contact Number*</td>
            <td align="left" ><asp:TextBox runat="server" ID="txtNumber" TextMode="Phone"/></td>
        </tr>
        <tr>
            <td align="right" class="auto-style2">About</td>
            <td align="left" ><asp:TextBox runat="server" ID="txtAbout" TextMode="MultiLine"/></td>
        </tr>
         <tr>
             <td colspan="2" align="center">
                 <asp:Button runat="server" ID="btnReset" Text="Reset"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="save" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
