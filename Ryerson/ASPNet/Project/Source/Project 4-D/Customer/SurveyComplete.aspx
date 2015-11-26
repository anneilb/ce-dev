<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SurveyComplete.aspx.cs" Inherits="SurveyComplete" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <br />
    <asp:Label ID="lblThankYou" runat="server" Text="Thank you for your feedback!"></asp:Label>
    <br />
    <asp:Label ID="lblContactResponse" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnReturnToSurvey" runat="server" 
        PostBackUrl="~/Customer/CustomerSurvey.aspx" Text="Return To Survey" />    
</asp:Content>