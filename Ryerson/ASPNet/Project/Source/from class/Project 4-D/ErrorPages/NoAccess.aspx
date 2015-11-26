<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NoAccess.aspx.cs" Inherits="ErrorPages_NoAccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <p />
    <asp:Label ID="lblErrorTitle" runat="server" Text="HTTP Error 403" ForeColor="Red" 
            Font-Bold="True" Font-Names="Arial"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblError" runat="server"         
        Text="Forbidden. The client is not allowed to access the requested resource."></asp:Label>
    <br />
    <br />
</asp:Content>

