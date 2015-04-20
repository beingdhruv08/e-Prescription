<%@ Page Title="" Language="VB" MasterPageFile="~/ChemistMaster.master" AutoEventWireup="false" CodeFile="PharmacyFirstPage.aspx.vb" Inherits="PharmacyFirstPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div>
        <table runat ="server" align="center" style="height: 380px; width: 501px" >
                    <tr>
                        <td align="center" colspan="2">
                            <h1>Pharmacy First Page</h1>
                        </td>     
                   </tr>
                     <tr>
                          <td  colspan="2" >
                        <asp:GridView ID="gridleave" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames ="PharmacyID,SNo" Height="157px" style="margin-right: 15px">
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
                                <asp:BoundField HeaderText="Doctor Name" DataField ="DoctorName" />
                                <asp:BoundField HeaderText="Patient Name" DataField ="PatientName" />
                                <asp:CommandField ShowSelectButton="True" />
                               </Columns>
                        </asp:GridView>
                      </td>
                    </tr>
                   
        </table>
    </div>
</asp:Content>

