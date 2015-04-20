<%@ Page Title="" Language="VB" MasterPageFile="~/ChemistMaster.master" AutoEventWireup="false" CodeFile="PharmacyPurchaseOrder.aspx.vb" Inherits="PharmacyPurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <table align="center" style="height: 380px; width: 521px" >
        <tr>
            <td colspan ="2" align="center">
                <h1>Purchase Order</h1>
            </td>
        </tr> 
        <tr>
            <td align="right" >Order Number</td>
            <td align="left" ><asp:Label ID="labelordernumber" TextMode="Number" runat="server" Height="29px" Width="177px"></asp:Label></td>    
        </tr>
        <tr>
            <td align="right" >Supplier Name</td>
            <td align="left" ><asp:TextBox ID="txt_manuname" runat="server" Height="29px" Width="177px"></asp:TextBox></td>    
        </tr>
        <tr>
            <td align="right" >Order Date</td>
            <td align="left" ><asp:Label ID="labelDate" TextMode="Month" runat="server" Height="29px" Width="177px"></asp:Label></td>    
        </tr>
        <tr>
            <td align="center" colspan ="2">
                <asp:Button ID="btnNewMedicine" runat ="server" Text="New Medicine" />
            </td> 
        </tr>
            <td colspan ="2">
                <asp:GridView ID="gridleave" width="100%" runat="server" AutoGenerateColumns="False"  
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="116px">
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
                            <asp:BoundField HeaderText="Medicine Name" DataField ="itemName"/>
                            <asp:BoundField HeaderText="Quantity" DataField ="itemOrderQuantity"/>    
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" colspan ="2">
                <asp:Button ID="btnSave" Text="Save" runat ="server" />
            </td>    
        </tr>
    </table>
    </div>
</asp:Content>