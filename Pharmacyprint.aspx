<%@ Page Title="" Language="VB" MasterPageFile="~/ChemistMaster.master" AutoEventWireup="false" CodeFile="PharmacyPrint.aspx.vb" Inherits="Pharmacyprint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div>
        <table align="center" style="height:100%; width:100%" >
        <tr>
            <td colspan="2" align ="center"><h1>Pharmacy Print</h1></td>
        </tr>
        <tr>
            <td>Date<asp:Label ID="labelDate" Text="Date" Font-Bold="true" runat="server" Height="29px" Width="177px"></asp:Label></td>
            <td>Patient ID<asp:Label ID="labelPatientID" Text="Patient ID" Font-Bold="true" runat="server" Height="29px" Width="177px"></asp:Label></td>    
        </tr>
        <tr>
            <td>Pharmacy Name<asp:Label ID="labelPharmacyName" Text="Pharmacy Name" Font-Bold="true" runat="server" Height="29px" Width="177px"></asp:Label></td>
            <td>Contact Details<asp:Label ID="labelContact" Text="Contact Details" Font-Bold="true"  runat="server" Height="29px" Width="177px"></asp:Label></td>         
        </tr>
        <tr>
            <td>Doctor Name<asp:Label ID="labelDoctorName" Text="Doctor Name" Font-Bold="true" runat="server" Height="29px" Width="177px"></asp:Label></td>
            <td>Doctor ID<asp:Label ID="labelDoctorID" Text="Doctor ID" Font-Bold="true"  runat="server" Height="29px" Width="177px"></asp:Label></td>         
        </tr>
        <tr>
            <td colspan="2" align="left">
                Bill ID<asp:Label ID="labelBillID" runat="server" Height="29px" Width="177px"/>
            </td>
        </tr> 
        <tr>
            <td colspan="2">
                <asp:GridView ID="gridleave" Width="100%" runat="server" AutoGenerateColumns="False"  
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" DataKeyNames="SNo"
                    CellPadding="3" Height="116px">
                <AlternatingRowStyle CssClass="AltItem" />
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle CssClass="Header" BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle CssClass="Item" ForeColor="#000066" />
                <SelectedRowStyle CssClass="SelectedItem" BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                <Columns>
                    <asp:BoundField HeaderText="Medicine Name" DataField ="itemName" ReadOnly="True" />
                    <asp:BoundField HeaderText="Quantity" DataField ="itemQuantity" ReadOnly="True" />
                    <asp:BoundField HeaderText="Cost" DataField ="itemCost" ReadOnly ="True" />                     
                </Columns>
                </asp:GridView>
             </td>
        </tr>
        <tr><td colspan="2"></td></tr>
        <tr><td colspan="2" align="right">Total Amount<asp:Label ID="labelTotalAmount" Text="Total Amount" Font-Bold="true"  runat="server"/></td></tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnPrint" runat ="server" Text ="Print" Width="76px"/>&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBack" runat="server" Text="Back" Width ="76px"/>
            </td> 
        </tr> 
        </table>
    </div>
    
</asp:Content>

