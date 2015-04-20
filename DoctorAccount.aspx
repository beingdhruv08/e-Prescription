<%@ Page Title="" Language="VB" MasterPageFile="~/DoctorMaster.master" AutoEventWireup="false" CodeFile="DoctorAccount.aspx.vb" Inherits="DoctorAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div>
            <table runat ="server" align="center" style="height: 338px; width: 422px">
                <tr>
                    <td colspan ="2">
                        <h1 align="center">Doctor Account</h1>
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
                        <asp:Button ID="btnSave" Text="Save" runat="server" style="height: 27px; width: 93px"/>
                    </td>    
                </tr>
            </table>
        </div>
</asp:Content>

