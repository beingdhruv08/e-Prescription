<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PharmacyMenu.aspx.vb" Inherits="PharmacyMenu" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pharmacy Menu</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Menu ID="navMenu" runat="server" BackColor="#007FFF" BorderColor="#0066CC" 
                    StaticMenuItemStyle-ForeColor="#FFFFFF" StaticMenuItemStyle-VerticalPadding="10px"
                    StaticMenuItemStyle-HorizontalPadding="10px"
                    RenderingMode="Table" Orientation="Horizontal" Height="99px" Width="839px">
                    <Items>
                     <asp:MenuItem Text ="Item Master" NavigateUrl="item_master.aspx">
                     </asp:MenuItem>
                     <asp:MenuItem Text="Purchased Received" NavigateUrl="Purchase Received.aspx">
                     </asp:MenuItem>
                    <asp:MenuItem Text="Purchase Return" NavigateUrl="PurchaseReturn.aspx">
                     </asp:MenuItem>
                     <asp:MenuItem Text ="Sale Master" NavigateUrl="PharmacySaleMaster.aspx">
                     </asp:MenuItem>
                     <asp:MenuItem Text ="Sale Return" NavigateUrl="PharmacySaleReturn.aspx">
                     </asp:MenuItem>
                     <asp:MenuItem Text ="Report" NavigateUrl="PharmcayReport.aspx">
                     </asp:MenuItem>
                    </Items>
                    </asp:Menu>
                </td>
             </tr>
        </table>
    </div>
    </form>
</body>
</html>
