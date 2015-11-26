<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IncidentCreation.aspx.cs" Inherits="IncidentCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 390px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetCustomerList" 
        TypeName="CustomerDB"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetCustomerProducts" TypeName="ProductDB">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlCustomers" Name="CustomerID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
        InsertMethod="InsertIncident" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetIncidents" TypeName="IncidentDB">
        <InsertParameters>
            <asp:Parameter Name="CustomerID" Type="Int32" />
            <asp:Parameter Name="ProductCode" Type="String" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <table>
        <tr>
            <td class="DataListColumnWidthSmall">
    
    <asp:Label ID="lblCustomer" runat="server" Text="Customer:"></asp:Label>
            </td>
            <td class="style1">
                <asp:DropDownList ID="ddlCustomers" runat="server" 
                    DataSourceID="ObjectDataSource1" DataTextField="Name" 
                    DataValueField="CustomerID" AutoPostBack="True" 
                    AppendDataBoundItems="True" Width="200px">
                    <asp:ListItem Value="-1">--Select a customer--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="vldRequiredCustomerID" runat="server" 
                    ErrorMessage="A customer must be selected." 
                    ControlToValidate="ddlCustomers" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="DataListColumnWidthSmall">
                <asp:Label ID="lblProduct" runat="server" Text="Product:"></asp:Label>
            </td>
            <td class="style1">
                <asp:DropDownList ID="ddlProducts" runat="server" AppendDataBoundItems="True" 
                    DataSourceID="ObjectDataSource2" DataTextField="Name" 
                    DataValueField="ProductCode" Width="200px" EnableViewState="False">
                    <asp:ListItem Value="-1">--Select a product--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="vldRequiredProductCode" runat="server" 
                    ErrorMessage="A product must be selected." ControlToValidate="ddlProducts" 
                    Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="DataListColumnWidthSmall">
                <asp:Label ID="lblTitle" runat="server" Text="Title:"></asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="txtTitle" runat="server" Width="380px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="vldRequiredTitle" runat="server" 
                    ErrorMessage="A title is required." ControlToValidate="txtTitle" 
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="DataListColumnWidthSmall" valign="top">
                <asp:Label ID="lblDescription" runat="server" Text="Description:"></asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="txtDescription" runat="server" Width="380px" Height="55px" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
            <td valign="top">
                <asp:RequiredFieldValidator ID="vldRequiredDescription" runat="server" 
                    ErrorMessage="A description is required." 
                    ControlToValidate="txtDescription" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnAddIncident" runat="server" Text="Add Incident" 
        onclick="btnAddIncident_Click" />
    <br />
    <br />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
</asp:Content>

