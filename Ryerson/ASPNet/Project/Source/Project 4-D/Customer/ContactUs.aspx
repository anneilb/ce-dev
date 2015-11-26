<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 83px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="Large" 
        Text="How to contact us"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblInstructions" runat="server" 
        Text="If you ever have any questions of comments about our products, please be sure to contact us in whatever way is most convenient for you."></asp:Label>
    <br />
    <br />
    <table cellpadding="5px">
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="lblPhoneLabel" runat="server" Font-Bold="False" Text="Phone:"></asp:Label>
            </td>
            <td valign="top">
                1-800-555-0400<br />
                Weekdays, 8 to 5 Pacific Time</td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="lblEmailLabel" runat="server" Font-Bold="False" Text="Email:"></asp:Label>
            </td>
            <td>
                <a href="mailto:sportspro@sportsprosoftware.com">sportspro@sportsprosoftware.com</a>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="lblFaxLabel" runat="server" Font-Bold="False" Text="Fax:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblFax" runat="server" Text="1-559-555-2732"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="lblAddressLabel" runat="server" Font-Bold="False" 
                    Text="Address:"></asp:Label>
            </td>
            <td>
                SportsPro Software, Inc.<br />
                1500 N. Main Street<br />
                Fresno, California 93710</td>
        </tr>
    </table>
</asp:Content>

