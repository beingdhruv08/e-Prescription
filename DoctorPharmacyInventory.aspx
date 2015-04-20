<%@ Page Title="" Language="VB" MasterPageFile="~/DoctorMaster.master" AutoEventWireup="false" CodeFile="DoctorPharmacyInventory.aspx.vb" Inherits="DoctorPharmacyInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table runat ="server" align="center" style="height: 380px; width: 501px" >
                    <tr>
                        <td align="center" colspan="2">
                            <h1>Doctor Pharmacy Inventory</h1>
                        </td>     
                   </tr>
                   <tr>
                       <td>
                        Medicine Name:<asp:DropDownList ID="ddlMedicine" runat ="server" AutoPostBack="True" Height="16px" Width="116px" /></td>
                        <td >Pills Required<asp:TextBox ID="txtPillsRequired" TextMode = "Number"  runat="server" ></asp:TextBox></td>    
                        <td><asp:Button ID="btnAdd" Text="Add" align="left" runat="server" style="height: 27px; width: 60px" ></asp:Button> </td>
                    </tr>
                    <tr>
                        <td  colspan="2" >
                        <asp:GridView ID="gridleave" Width="116%" runat="server" AutoGenerateColumns="False"  Height="171px" style="margin-right: 15px"
                            DataKeyNames ="itemName,itemNo">
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
                                <asp:BoundField HeaderText="Medicine Name" DataField ="itemName" />
                                <asp:BoundField HeaderText="Pills Required" DataField ="itemQuantity" />
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:CommandField ShowDeleteButton="True" />
                               </Columns>
                        </asp:GridView>
                      </td>
                    </tr>
                    <tr>
                        <td colspan ="2" align="center">
                            <asp:Button ID="btnPrint" Text="Print Preview" align="center" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnBack" Text="Back" align="center" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnUpdate" Text="Update" align="center" runat="server"/>
                        </td>    
                    </tr>
         </table>
    </div> 
</asp:Content>

