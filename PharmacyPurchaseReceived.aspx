<%@ Page Title="" Language="VB" MasterPageFile="~/ChemistMaster.master"  AutoEventWireup="true" CodeFile="PharmacyPurchaseReceived.aspx.vb" Inherits="PharmacyPurchaseReceived" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
      <table id="purchase_received_table"  >
        <tr>
            <td align="right">Date of Received:</td>
            <td align="left"><asp:Label runat="server" ID="labelDateOfReceived"/></td>
        </tr>
       <tr>
            <td align="right">Against Order Number:</td>
            <td align="left"><asp:TextBox ID="txtOrderNumber" runat="server" TextMode="Number"/><asp:Button runat ="server" id="BtnFetch" Text="Fetch"/></td>
        </tr>
        <tr>
              <td align="right">Supplier Name:</td>
              <td align="left"><asp:Label ID="labelSupplierName" runat ="server" /></td>
        </tr>
        <tr>
            <td colspan ="2">
                <asp:GridView ID="gridleave" Width="100%" runat="server" AutoGenerateColumns="False" BackColor="White" 
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="182px" DataKeyNames ="Quantity,MedicineName">
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
                        <asp:BoundField HeaderText="Medicine Name" DataField="MedicineName"/>
                        <asp:BoundField HeaderText="Quantity Ordered" DataField="Quantity"/>
                        <asp:BoundField HeaderText="Manufacturer Name" DataField="itemManufacturer"/>
                        <asp:BoundField headertext="Total Medicine Cost" DataField="aa"/>
                        <asp:CommandField ShowSelectButton="True" HeaderText ="Select if Medicine Present" />
                    </Columns>
                </asp:GridView>
            </td> 
        </tr>
        <tr>
            <td align="right" colspan ="2">Total Amount:<asp:Label ID="labelTotalAmount" runat="server" Text="Total Amount"/></td>
        </tr>
        <tr>
            <td align="center" colspan ="2">
                <asp:Button ID="btnSave" runat ="server" Text="Save"/>
            </td> 
        </tr>
      </table>
   </div>
</asp:Content>
