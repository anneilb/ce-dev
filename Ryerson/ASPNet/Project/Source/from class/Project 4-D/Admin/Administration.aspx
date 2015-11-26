<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Administration.aspx.cs" Inherits="Administration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <p />
        <asp:HyperLink ID="hlProductMaintenance" runat="server" 
            NavigateUrl="~/Admin/ProductMaintenance.aspx">Maintain Products</asp:HyperLink>
    <p />
        <asp:HyperLink ID="hlCustomerMaintenance" runat="server" 
            NavigateUrl="~/Admin/CustomerMaintenance.aspx">Maintain Customers</asp:HyperLink>
    <p />    
        <asp:HyperLink ID="hlTechnicianMaintenance" runat="server" 
            NavigateUrl="~/Admin/TechnicianMaintenance.aspx">Maintain Technicians</asp:HyperLink>            
    <p />    
        <asp:HyperLink ID="hlIncidentCreation" runat="server" 
            NavigateUrl="~/Admin/IncidentCreation.aspx">Create Incidents</asp:HyperLink>
    <p />    
        <asp:HyperLink ID="hlTechnicianIncidentSummary" runat="server" 
            NavigateUrl="~/Admin/TechnicianIncidentSummary.aspx">Display Technician Incidents</asp:HyperLink>
    <p />    
        <asp:HyperLink ID="hlIncidentAssignment" runat="server" 
            NavigateUrl="~/Admin/IncidentAssignment.aspx">Assign Incidents</asp:HyperLink>
    <p />    
        <asp:HyperLink ID="hlIncidentDisplay" runat="server" 
            NavigateUrl="~/Admin/IncidentDisplay.aspx">Display Incidents</asp:HyperLink>
    <p />    
        <asp:HyperLink ID="hlCustomerDisplay" runat="server" 
            NavigateUrl="~/Admin/CustomerDisplay.aspx">Display Customers</asp:HyperLink>    
    <p />
        <table>
            <tr>
                <td>    
                    Current User: <asp:LoginName ID="LoginName1" runat="server" />    
                </td>
                <td>
                    &nbsp&nbsp
                    <asp:LoginStatus ID="LoginStatus1" runat="server" />    
                </td>
            </tr>
        </table>    
</asp:Content>

