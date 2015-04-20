<%@ Page Title="Item Master" Language="VB" MasterPageFile="~/ChemistMaster.master" AutoEventWireup="false" CodeFile="ItemMaster.aspx.vb" Inherits="ItemMaster" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <style type="text/css">
            
        </style>
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
        <div  align="center" >    
            <table runat ="server"  >
                <tr >
                    <td align="center" colspan="2">
                        <h1>Item Master</h1>
                    </td>     
                </tr>
                <tr>
                    <td align="right" class="auto-style1"  >Medicine Name:</td>
                    <td align="left" class="auto-style2"  ><asp:TextBox ID="txt_medicinename" runat="server" Height="28px" Width="178px"/></td>    
                </tr>
                <tr>
                    <td align="right" class="auto-style1"  >Quantity:</td>
                    <td align="left" class="auto-style2" ><asp:TextBox ID="txt_quantity" TextMode="Number" runat="server" Height="29px" Width="177px"/></td>    
                </tr>
                <tr>
                    <td align="right" class="auto-style1"  >Quantity to be Order:</td>
                    <td align="left" class="auto-style2" ><asp:TextBox ID="txtQuantityOrder" TextMode="Number"  runat="server" Height="29px" Width="177px"/></td>    
                </tr>
                <tr>
                    <td align="right" class="auto-style1"  >Manufacturer Name:</td>
                    <td align="left" class="auto-style2" ><asp:TextBox ID="txt_manuname" runat="server" Height="29px" Width="177px"/></td>    
                </tr>
                <tr>
                    <td align = "right" class="auto-style1"  >Cost per pill:</td>
                    <td align = "left" class="auto-style2"  ><asp:TextBox ID="txt_cost" TextMode="Number" runat="server" Height="29px" Width="177px"/></td>    
                </tr>
                <tr>
                    <td align = "right" class="auto-style1" >Threshold Value:</td>
                    <td align = "left" class="auto-style2"  ><asp:TextBox ID="txtThreshold" TextMode="Number" runat="server" Height="29px" Width="177px"/></td>    
                </tr>
                <tr>
                    <td align="center" colspan ="2">
                        <asp:Button ID="btn_update" Text="Update" align="center" runat="server" style="height: 27px; width: 93px"/>&nbsp;&nbsp;
                        <asp:Button ID="btn_save" Text="Save" align="center" runat="server" style="height: 27px; width: 93px"/>&nbsp;&nbsp;
                        <asp:Button ID="btnNew" Text="New" align="center" runat="server" style="height: 27px; width: 93px"/>
                    </td>    
                </tr>
                <tr>
                     <td align = " center " class="auto-style1" colspan="2">
                        <asp:GridView ID="gridleave" Width="100px" runat="server" AutoGenerateColumns="False" DataKeyNames ="itemID">
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
                                <asp:BoundField HeaderText="Medicine Name" DataField ="ItemName" />
                                <asp:BoundField HeaderText="Quantity" DataField ="itemQuantity" />
                                <asp:BoundField HeaderText="Manufacturer Name" DataField ="itemManufacturer" />
                                <asp:BoundField HeaderText="Cost" DataField ="itemCost" />
                                <asp:BoundField HeaderText="Threshold" DataField ="itemThreshold" />
                                <asp:CommandField AccessibleHeaderText="Select" ShowSelectButton="True" />
                                <asp:CommandField ShowDeleteButton="True" />
                               </Columns>
                        </asp:GridView>
                      </td>
                    </tr>
        </table>
    </div>
</asp:Content>