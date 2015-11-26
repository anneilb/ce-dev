<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FileNotFound.aspx.cs" Inherits="ErrorPages_FileNotFound" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <p />
    <asp:Label ID="lblErrorTitle" runat="server" Text="HTTP Error 404" ForeColor="Red" 
            Font-Bold="True" Font-Names="Arial"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblError" runat="server"         
        Text="The resource you requested can't be found. The application must be aborted."></asp:Label>
    <br />
    <br />
</asp:Content>

