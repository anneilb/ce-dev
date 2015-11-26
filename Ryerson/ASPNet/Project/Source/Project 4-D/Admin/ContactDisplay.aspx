<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContactDisplay.aspx.cs" Inherits="ContactDisplay" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 460px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <asp:Label ID="lblContactList" runat="server" Text="Contact List:"></asp:Label>
    <br />
    <table class="style1">
        <tr>
            <td class="style2">
                <asp:ListBox ID="lstContacts" runat="server" Width="454px" Height="120px"></asp:ListBox>
            </td>
            <td>
                <asp:Button ID="btnRemoveContact" runat="server" 
                    onclick="btnRemoveContact_Click" Text="Remove Contact" Width="140px" />
                <br />
                <br />
                <asp:Button ID="btnEmptyList" runat="server" onclick="btnEmptyList_Click" 
                    Text="Empty List" Width="140px" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                <br />
                <asp:Button ID="btnSelectAdditionalCustomers" runat="server" 
                    PostBackUrl="~/Admin/CustomerDisplay.aspx" Text="Select Additional Customers" 
                    Width="190px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
