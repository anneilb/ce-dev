<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ErrorMessage.aspx.cs" Inherits="ErrorMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <p />
    <asp:Label ID="lblErrorPreamble" runat="server" 
        Text="An unrecoverable error has occurred:" Font-Bold="True" Font-Names="Arial" 
        ForeColor="Red"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnReturn" runat="server" Text="Return" 
        onclick="btnReturn_Click" />
    <br />
    <br />
</asp:Content>

