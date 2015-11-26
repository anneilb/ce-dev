<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerSupport.aspx.cs" Inherits="CustomerSupport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server"> 
    <p />
        <asp:HyperLink ID="hlRegisterProduct" runat="server" 
            NavigateUrl="~/Customer/ProductRegistration.aspx">Register Product</asp:HyperLink>
    <p />
        <asp:HyperLink ID="hlCompleteSurvey" runat="server" 
            NavigateUrl="~/Customer/CustomerSurvey.aspx">Complete Survey</asp:HyperLink>
    <p />    
        <asp:HyperLink ID="hlContactUs" runat="server" 
            NavigateUrl="~/Customer/ContactUs.aspx">Contact Us</asp:HyperLink>
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

