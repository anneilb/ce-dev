<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductRegistration.aspx.cs" Inherits="ProductRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" 
        
        SelectCommand="SELECT [Name], [CustomerID], [Email] FROM [Customers] WHERE ([CustomerID] = @CustomerID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtCustomerID" Name="CustomerID" 
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" 
        SelectCommand="SELECT [Name], [ProductCode] FROM [Products] ORDER BY [Name]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" 
        DeleteCommand="DELETE FROM [Registrations] WHERE [CustomerID] = @CustomerID AND [ProductCode] = @ProductCode" 
        InsertCommand="INSERT INTO [Registrations] ([CustomerID], [ProductCode], [RegistrationDate]) VALUES (@CustomerID, @ProductCode, @RegistrationDate)" 
        SelectCommand="SELECT [CustomerID], [ProductCode], [RegistrationDate] FROM [Registrations]" 
        UpdateCommand="UPDATE [Registrations] SET [RegistrationDate] = @RegistrationDate WHERE [CustomerID] = @CustomerID AND [ProductCode] = @ProductCode">
        <DeleteParameters>
            <asp:Parameter Name="CustomerID" Type="Int32" />
            <asp:Parameter Name="ProductCode" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="RegistrationDate" Type="DateTime" />
            <asp:Parameter Name="CustomerID" Type="Int32" />
            <asp:Parameter Name="ProductCode" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="CustomerID" Type="Int32" />
            <asp:Parameter Name="ProductCode" Type="String" />
            <asp:Parameter Name="RegistrationDate" Type="DateTime" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:Label ID="lblCustomerID" runat="server" Text="Enter your customer ID:"></asp:Label>
    &nbsp
    <asp:TextBox ID="txtCustomerID" runat="server" CausesValidation="True" 
        ValidationGroup="CustomerID"></asp:TextBox>
    &nbsp
    <asp:Button ID="btnGetCustomer" runat="server" Text="Get Customer" 
        onclick="btnGetCustomer_Click" ValidationGroup="CustomerID"/>
    <br />
    <asp:RequiredFieldValidator ID="vldRequiredCustomerID" runat="server" 
        ErrorMessage="A customer ID must be entered." ControlToValidate="txtCustomerID" 
        Display="Dynamic" EnableClientScript="False" EnableViewState="False" 
        ValidationGroup="CustomerID"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="vldCompareCustomerID" runat="server" 
        ControlToValidate="txtCustomerID" Display="Dynamic" EnableClientScript="False" 
        EnableViewState="False" ErrorMessage="A numeric customer ID must be entered." 
        Operator="DataTypeCheck" Type="Integer" ValidationGroup="CustomerID"></asp:CompareValidator>
    <asp:CustomValidator ID="vldCustomCustomerID" runat="server" 
        ErrorMessage="A customer record does not exist for that ID." 
        ControlToValidate="txtCustomerID" Display="Dynamic" EnableClientScript="False" 
        EnableViewState="False" onservervalidate="vldCustomCustomerID_ServerValidate" 
        ValidationGroup="CustomerID"></asp:CustomValidator>
    <br />    
    <table>
        <tr>
            <td class="DataListColumnWidthSmall">
                <asp:Label ID="lblCustomerNameLabel" runat="server" Text="Customer: "></asp:Label>
                <br />
                <br />
            </td>
            <td>
                <asp:Label ID="lblCustomerName" runat="server" Text=""></asp:Label>
                <br />
                <br />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="DataListColumnWidthSmall">
                <asp:Label ID="lblSelectProduct" runat="server" Text="Product: "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSelectProduct" runat="server" 
                    AppendDataBoundItems="True" EnableViewState="False" Width="230px" 
                    DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="ProductCode">
                    <asp:ListItem Value="-1">--Select a product--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="vldRequiredProduct" runat="server" 
                    ControlToValidate="ddlSelectProduct" Display="Dynamic" 
                    EnableClientScript="False" EnableViewState="False" 
                    ErrorMessage="A product must be selected." InitialValue="-1"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnRegisterProduct" runat="server" Text="Register Product" 
        onclick="btnRegisterProduct_Click" />
    <br />
    <br />
    <asp:Label ID="lblError" runat="server" EnableViewState="False"></asp:Label>
</asp:Content>

