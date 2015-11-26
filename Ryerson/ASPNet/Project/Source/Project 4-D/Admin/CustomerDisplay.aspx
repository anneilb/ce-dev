<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="CustomerDisplay.aspx.cs" Inherits="_CustomerDisplay" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 79px;
        }
    </style>
</asp:Content>
     
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <asp:Label ID="lblCustomer" runat="server" Text="Select a customer: "></asp:Label>
    <asp:DropDownList ID="ddlCustomers" runat="server" AutoPostBack="True" 
        DataSourceID="AccessDataSource1" DataTextField="Name" 
        DataValueField="CustomerID">
    </asp:DropDownList>
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
        DataFile="~/App_Data/TechSupport.mdb" 
        SelectCommand="SELECT * FROM [Customers] ORDER BY [Name]">
    </asp:AccessDataSource>
    <br />
    <br />
    <table>
        <tr>
            <td class="style1">
                <asp:Label ID="lblAddressLabel" runat="server" Text="Address:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblAddress" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblPhoneLabel" runat="server" Text="Phone:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPhone" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblEmailLabel" runat="server" Text="Email:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Button ID="btnAddToContacts" runat="server" Text="Add to Contact List" 
        onclick="btnAddToContacts_Click" />
&nbsp;&nbsp;
    <asp:Button ID="btnDisplayContacts" runat="server" 
        Text="Display Contact List" PostBackUrl="~/Admin/ContactDisplay.aspx" />

    <br />
    <br />
    <asp:Label ID="lblContactExists" runat="server" ForeColor="Red" 
        Text="Contact already exists!" Visible="False"></asp:Label>    
</asp:Content>
