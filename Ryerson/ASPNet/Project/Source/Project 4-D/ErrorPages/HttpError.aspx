<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HttpError.aspx.cs" Inherits="ErrorPages_HttpError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <p />
    <asp:Label ID="lblErrorTitle" runat="server" Text="HTTP Error" ForeColor="Red" 
            Font-Bold="True" Font-Names="Arial"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblError" runat="server"         
        Text="An error has occurred. Sorry for the inconvenience."></asp:Label>
    <br />
    <br />
</asp:Content>

