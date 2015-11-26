<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <p />
        <asp:HyperLink ID="hlCustomerSupport" runat="server" 
            NavigateUrl="~/Customer/CustomerSupport.aspx">Customer Support</asp:HyperLink>
    <p />
        <asp:HyperLink ID="hlTechnicianSupport" runat="server" 
            NavigateUrl="~/Tech/TechnicianSupport.aspx">Technician Support</asp:HyperLink>
    <p />    
        <asp:HyperLink ID="hlAdministration" runat="server" 
            NavigateUrl="~/Admin/Administration.aspx">Administration</asp:HyperLink>
    <br />       
</asp:Content>

