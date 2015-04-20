<%@ Page Title="" Language="VB" MasterPageFile="~/DoctorMaster.master" AutoEventWireup="false" CodeFile="DoctorPrint.aspx.vb" Inherits="DoctorPrint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <table align="center" style="height: 380px; width: 521px" >
        <tr>
            <td colspan="2" align ="center"><h1>Doctor Print</h1></td>
        </tr>
        <tr>
            <td>Date:<asp:Label ID="lab_date" Text="Date" Font-Bold="true" runat="server" Height="29px" Width="177px"></asp:Label></td>
            <td>Patient ID:<asp:Label ID="lab_patientid" Text="Patient ID" Font-Bold="true" runat="server" Height="29px" Width="177px"></asp:Label></td>    
        </tr>
        <tr>
            <td>Doctor Name:<asp:Label ID="lab_DoctorName" Text="Doctor Name" Font-Bold="true" runat="server" Height="29px" Width="177px"></asp:Label></td>
           <td>Contact Number<asp:Label ID="lab_contact" Text="Contact Number" Font-Bold="true"  runat="server" Height="29px" Width="177px"></asp:Label></td>
                 
        </tr>
        <tr>
            <td colspan="2">
             <asp:GridView ID="gridleave" Width="100%" runat="server" AutoGenerateColumns="False"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="116px">
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
                    <asp:BoundField HeaderText="Medicine Name" ReadOnly="True" DataField ="ItemName" />
                    <asp:BoundField DataField="ItemQuantity" HeaderText="Quantity" ReadOnly="True" />
                </Columns>
             </asp:GridView>
            </td>
          </tr>
          <tr><td colspan="2"></td></tr>   
          <tr><td colspan="2"></td></tr>
          <tr><td colspan="2"></td></tr>
          <tr><td colspan="2" align="right">Signature</td></tr>
          <tr>
              <td colspan="2" align="center">
                  <asp:Button ID="btnBack" runat="server" Text="Back"/>
              </td>
          </tr>
        </table>
    </div>
</asp:Content>

