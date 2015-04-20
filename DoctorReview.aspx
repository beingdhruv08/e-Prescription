<%@ Page Title="" Language="VB" MasterPageFile="~/DoctorMaster.master" AutoEventWireup="false" CodeFile="DoctorReview.aspx.vb" Inherits="DoctorReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
            <table align="center">
                <tr>
                    <td colspan="2" align="center">
                        <h1>Doctor Review</h1>
                    </td> 
                </tr> 
                <tr>
                    <td align="right">Pharmacy ID:</td>
                    <td align="left"><asp:DropDownList ID="ddl1" runat ="server" DataValueField ="PharmacyID" DataTextField = "PharmacyName" /></td>
                </tr>
                <tr>
                    <td align="right">Disease:</td>
                    <td align="left"><asp:TextBox runat ="server" ID="txtDisease" TextMode ="MultiLine" MaxLength="5000" /></td>
                </tr> 
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button runat="server" Text="Next" ID="btnNext"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button runat="server" Text="Back" ID="btnBack"/>
                    </td>
                </tr>
             </table>
        </div>
</asp:Content>

