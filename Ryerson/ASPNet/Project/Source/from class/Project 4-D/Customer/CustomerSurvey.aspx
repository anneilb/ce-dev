<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerSurvey.aspx.cs" Inherits="CustomerSurvey" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 142px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">    
    <asp:Label ID="lblCustomerID" runat="server" Text="Enter your customer ID: "></asp:Label>
    <asp:TextBox ID="txtCustomerID" runat="server" 
        ValidationGroup="CustomerID"></asp:TextBox>
&nbsp;
    <asp:Button ID="btnGetIncidents" runat="server" Text="Get Incidents" 
        onclick="btnGetIncidents_Click" />
    &nbsp;&nbsp;
    <br />
    <asp:RequiredFieldValidator ID="vldRequiredCustomerID" runat="server" 
        ControlToValidate="txtCustomerID" Display="Dynamic" 
        ErrorMessage="A valid Customer ID is required" 
        ValidationGroup="CustomerID" EnableClientScript="False"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="vldCompareCustomerID" runat="server" 
        ControlToValidate="txtCustomerID" Display="Dynamic" 
        ErrorMessage="Customer ID must be an integer value" Operator="DataTypeCheck" 
        Type="Integer" ValidationGroup="CustomerID" EnableClientScript="False"></asp:CompareValidator>
    <asp:Label ID="lblNoClosedIncidents" runat="server" ForeColor="Red" 
        Text="There are no closed incidents for the ID entered" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:ListBox ID="lstIncidents" runat="server" Height="90px" Width="524px" 
        ValidationGroup="Incidents">
    </asp:ListBox>
            <br />
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
        DataFile="~/App_Data/TechSupport.mdb"             
        
        SelectCommand="SELECT [IncidentID], [CustomerID], [ProductCode], [TechID], [DateOpened], [DateClosed], [Title] FROM [Incidents] ORDER BY [DateClosed]">
    </asp:AccessDataSource>
                <asp:RequiredFieldValidator ID="vldRequiredIncident" runat="server" 
                    ControlToValidate="lstIncidents" EnableClientScript="False" 
                    ErrorMessage="An incident must be selected" InitialValue="None" 
                    ValidationGroup="Incidents" Display="Dynamic"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblSurveyInstructions" runat="server" Font-Bold="True" 
        Text="Please rate this incident by the following categories:"></asp:Label>
    <table>
        <tr>
            <td class="style1">
                <asp:Label ID="lblResponseTime" runat="server" Text="Response time:"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rblResponseTime" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Not Satisfied</asp:ListItem>
                    <asp:ListItem Value="2">Somewhat satisfied</asp:ListItem>
                    <asp:ListItem Value="3">Satisfied</asp:ListItem>
                    <asp:ListItem Value="4">Completely satisfied</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblTechEfficiency" runat="server" Text="Technician efficiency:"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rblTechEfficiency" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Not Satisfied</asp:ListItem>
                    <asp:ListItem Value="2">Somewhat satisfied</asp:ListItem>
                    <asp:ListItem Value="3">Satisfied</asp:ListItem>
                    <asp:ListItem Value="4">Completely satisfied</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblProblemResolution" runat="server" Text="Problem resolution:"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rblProblemResolution" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Not Satisfied</asp:ListItem>
                    <asp:ListItem Value="2">Somewhat satisfied</asp:ListItem>
                    <asp:ListItem Value="3">Satisfied</asp:ListItem>
                    <asp:ListItem Value="4">Completely satisfied</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" valign="top">
                <asp:Label ID="lblComments" runat="server" Text="Additional comments:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtComments" runat="server" Height="69px" TextMode="MultiLine" 
                    Width="464px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <asp:CheckBox ID="chkContact" runat="server" 
        Text="Please contact me to discuss this incident" />
    <br />
&nbsp;&nbsp;&nbsp;
    <asp:RadioButton ID="rbContactByEmail" runat="server" GroupName="ContactBy" 
        Text="Contact by email" />
    <br />
&nbsp;&nbsp;&nbsp;
    <asp:RadioButton ID="rbContactByPhone" runat="server" GroupName="ContactBy" 
        Text="Contact by phone" />
    <br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
        onclick="btnSubmit_Click" />
    <br />    
</asp:Content>
