<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TechnicianSupport.aspx.cs" Inherits="TechnicianSupport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <p />    
        <asp:HyperLink ID="hlCustomerIncidentDisplay" runat="server" 
            NavigateUrl="~/Tech/CustomerIncidentDisplay.aspx">Display Customer Incidents</asp:HyperLink>
    <p />    
        <asp:HyperLink ID="hlUpdateIncidents" runat="server" 
            NavigateUrl="~/Tech/IncidentUpdate.aspx">Update Incidents</asp:HyperLink>    
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

