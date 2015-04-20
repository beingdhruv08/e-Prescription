<%@ Page Title="" Language="VB" MasterPageFile="~/DoctorMaster.master" AutoEventWireup="false" CodeFile="PatientDetails.aspx.vb" Inherits="PatientDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 359px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table runat="server" style="height:268px;width:936px" align="center">
            <tr>
                <td colspan ="2">
                    <h1 align="center">Patient Details</h1>
                </td>
            </tr> 
            <tr>
                <td align="right" class="auto-style1">Date:</td>
                <td align="left"><asp:TextBox id="txtDate"  runat="server" ReadOnly="true" />
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">Patient ID:</td>
                <td align="left"><asp:TextBox ID="txtPatientID" AutoGenerate="true" TextMode="Number" runat="server"/>
                </td>
            </tr> 
            <tr>
                <td align="right" class="auto-style1">Patient Name:</td>
                <td align="left"><asp:TextBox ID="txtPatientName" TextMode="SingleLine" runat="server"/>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">Age:</td>
                <td align="left"><asp:TextBox ID="txtAge" TextMode="Number" runat="server"/>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">Patient Address:</td>
                <td align="left"><asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">Contact Number:</td>
                <td align="left"><asp:TextBox ID="txtContactNumber" TextMode="Phone" runat="server"/>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="margin-left: 40px">
                    <asp:Button ID="btnUpdate" Text="Update" runat="server"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnNext" Text="Next" runat ="server" ValidationGroup ="save"/>
                </td>
            </tr>
            <tr>
                <td colspan ="2">
                    <asp:GridView ID="grdData" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames ="PatientID">
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
                                <asp:BoundField HeaderText="Date" DataField ="EntryDate" />
                                <asp:BoundField HeaderText="Patient ID" DataField ="PatientID"/>
                                <asp:BoundField HeaderText="Patient Name"  DataField ="PatientName"/>
                                <asp:BoundField HeaderText="Age"  DataField ="Age"/>
                                <asp:BoundField HeaderText="Patient Address" DataField ="PatientAddress" />
                                <asp:BoundField HeaderText="Contact Number"  DataField ="ContactNumber"/>
                                <asp:CommandField AccessibleHeaderText="Select" ShowSelectButton="True" />
                                <asp:CommandField ShowDeleteButton="True" />
                               </Columns>
                        </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

