<%@ Page Title="" Language="VB" MasterPageFile="~/ChemistMaster.master" AutoEventWireup="false" CodeFile="PharmacyAccount.aspx.vb" Inherits="PharmacyAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
     <table runat="server" align="center" style="height: 449px; width: 678px">
        <tr>
            <td align="right" >Pharmacy Name*</td>
            <td align="left" ><asp:TextBox ID="txtPharmacyName" runat="server" TextMode="SingleLine" MaxLength="50"/></td>
        </tr>
        <tr>
            <td align="right">Login Name/E-mail ID*
            </td>
            <td align="left"><asp:TextBox runat="server" ID="txtLoginname" TextMode="SingleLine"/></td>
        </tr>
        <tr>
            <td align="right">Password*</td>
            <td align="left"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"/></td>
        </tr>
        <tr>
            <td align="right">Confirm Password*</td>
            <td align="left"><asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"/>
            </td>
        </tr>

        <tr>
            <td align="right">Pharmacy Address*</td>
            <td align="left"><asp:TextBox runat="server" ID="txtAddress" TextMode="MultiLine" /></td>
        </tr>
        <tr>
            <td align="right">Head Chemist Name*</td>
            <td align="left"><asp:TextBox runat="server" ID="txtChemistName" TextMode="SingleLine" /></td>
        </tr>
        <tr>
            <td align="right">Pharmacy Contact Number*</td>
            <td align="left"><asp:TextBox runat="server" ID="txtNumber" TextMode="Phone"/></td>
        </tr>
        <tr>
            <td align="right">About</td>
            <td align="left"><asp:TextBox runat="server" ID="txtAbout" TextMode="MultiLine"/></td>
        </tr>
         <tr>
             <td colspan="2" align="center">
                 <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="save" />
            </td>
        </tr>
    </table>
    </div>
</asp:Content>

