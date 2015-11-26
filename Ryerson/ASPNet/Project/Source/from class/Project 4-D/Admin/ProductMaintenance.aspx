<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductMaintenance.aspx.cs" Inherits="ProductMaintenance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 108px;
        }
        .style2
        {
            width: 246px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConflictDetection="CompareAllValues" 
            ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" 
            DeleteCommand="DELETE FROM [Products] WHERE [ProductCode] = @original_ProductCode AND [Name] = @original_Name AND [Version] = @original_Version AND [ReleaseDate] = @original_ReleaseDate" 
            InsertCommand="INSERT INTO [Products] ([ProductCode], [Name], [Version], [ReleaseDate]) VALUES (@ProductCode, @Name, @Version, @ReleaseDate)" 
            OldValuesParameterFormatString="original_{0}" 
            SelectCommand="SELECT [ProductCode], [Name], [Version], [ReleaseDate] FROM [Products] ORDER BY [ProductCode]" 
            UpdateCommand="UPDATE [Products] SET [Name] = @Name, [Version] = @Version, [ReleaseDate] = @ReleaseDate WHERE [ProductCode] = @original_ProductCode AND [Name] = @original_Name AND [Version] = @original_Version AND [ReleaseDate] = @original_ReleaseDate">
            <DeleteParameters>
                <asp:Parameter Name="original_ProductCode" Type="String" />
                <asp:Parameter Name="original_Name" Type="String" />
                <asp:Parameter Name="original_Version" Type="Decimal" />
                <asp:Parameter Name="original_ReleaseDate" Type="DateTime" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Version" Type="Decimal" />
                <asp:Parameter Name="ReleaseDate" Type="DateTime" />
                <asp:Parameter Name="original_ProductCode" Type="String" />
                <asp:Parameter Name="original_Name" Type="String" />
                <asp:Parameter Name="original_Version" Type="Decimal" />
                <asp:Parameter Name="original_ReleaseDate" Type="DateTime" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ProductCode" Type="String" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Version" Type="Decimal" />
                <asp:Parameter Name="ReleaseDate" Type="DateTime" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="grdProducts" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="ProductCode" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" onrowdeleted="grdProducts_RowDeleted" 
            onrowupdated="grdProducts_RowUpdated">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:BoundField DataField="ProductCode" HeaderText="Product Code" 
                    ReadOnly="True" SortExpression="ProductCode" />
                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditProductName" runat="server" CausesValidation="True" 
                            MaxLength="50" Text='<%# Bind("Name") %>' ValidationGroup="EditProduct" 
                            Width="215px"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="vldRequiredEditProductName" runat="server" 
                            ControlToValidate="txtEditProductName" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="A product name is required." 
                            ValidationGroup="EditProduct" EnableClientScript="False">*</asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Version" SortExpression="Version">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditProductVersion" runat="server" CausesValidation="True" 
                            Text='<%# Bind("Version") %>' ValidationGroup="EditProduct"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="vldRequiredEditProductVersion" runat="server" 
                            ControlToValidate="txtEditProductVersion" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="A product version is required." 
                            ValidationGroup="EditProduct" EnableClientScript="False">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="vldCompareEditProductVersion" runat="server" 
                            ControlToValidate="txtEditProductVersion" Display="Dynamic" 
                            EnableViewState="False" 
                            ErrorMessage="A valid product version must be supplied." 
                            Operator="DataTypeCheck" Type="Double" ValidationGroup="EditProduct" 
                            EnableClientScript="False">*</asp:CompareValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Version") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Release Date" SortExpression="ReleaseDate">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditProductReleaseDate" runat="server" CausesValidation="True" 
                            Text='<%# Bind("ReleaseDate") %>' ValidationGroup="EditProduct"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="vldRequiredEditProductDate" runat="server" 
                            ControlToValidate="txtEditProductReleaseDate" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="A product release date is required." 
                            ValidationGroup="EditProduct" EnableClientScript="False">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="vldCompareEditProductDate" runat="server" 
                            ControlToValidate="txtEditProductReleaseDate" Display="Dynamic" 
                            EnableViewState="False" 
                            ErrorMessage="A valid date must be supplied for product release date." 
                            Operator="DataTypeCheck" Type="Date" ValidationGroup="EditProduct" 
                            EnableClientScript="False">*</asp:CompareValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" 
                            Text='<%# Bind("ReleaseDate", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" 
                    ShowEditButton="True" ValidationGroup="EditProduct" />
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </p>
    <br />
    <asp:ValidationSummary ID="vldSummaryEditProduct" runat="server" 
        EnableViewState="False" ValidationGroup="EditProduct" 
        HeaderText="Please correct the following errors:" />
    <br />    
    <asp:Label ID="lblAddProduct" runat="server" Text="To add a new product, enter the product information and click Add Product."/>    
    <br />
    <br />
    

    <table style="width: 760px">
        <tr>
            <td class="style1">
                <asp:Label ID="lblAddPoductCode" runat="server" Text="Product code:"></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txtAddProductCode" runat="server" CausesValidation="True" 
                    MaxLength="10" ValidationGroup="AddProduct"/>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="vldRequiredAddProductCode" runat="server" 
                            ControlToValidate="txtAddProductCode" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="A product code is required." 
                            ValidationGroup="AddProduct">* A product code is required.</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="vldCompareAddProductCode" runat="server" 
                            ControlToValidate="txtAddProductCode" Display="Dynamic" 
                            EnableViewState="False" 
                            ErrorMessage="A valid product code must be supplied." 
                            Operator="DataTypeCheck" ValidationGroup="AddProduct">* A valid product code must be supplied.</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblAddProductName" runat="server" Text="Name:"></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txtAddProductName" runat="server" Width="238px" 
                    CausesValidation="True" MaxLength="50" ValidationGroup="AddProduct"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="vldRequiredAddProductName" runat="server" 
                            ControlToValidate="txtAddProductName" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="A product name is required." 
                            ValidationGroup="AddProduct">* A product name is required.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblVersion" runat="server" Text="Version:"></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txtAddProductVersion" runat="server" CausesValidation="True" 
                    ValidationGroup="AddProduct"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="vldRequiredAddProductVersion" runat="server" 
                            ControlToValidate="txtAddProductVersion" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="A product version is required." 
                            ValidationGroup="AddProduct">* A product version is required.</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="vldCompareAddProductVersion" runat="server" 
                            ControlToValidate="txtAddProductVersion" Display="Dynamic" 
                            EnableViewState="False" 
                            ErrorMessage="A valid product version must be supplied." 
                            Operator="DataTypeCheck" Type="Double" 
                    ValidationGroup="AddProduct">* A valid product version must be supplied.</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblReleaseDate" runat="server" Text="Release date:"></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txtAddProductReleaseDate" runat="server" 
                    CausesValidation="True" ValidationGroup="AddProduct"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="vldRequiredAddProductDate" runat="server" 
                            ControlToValidate="txtAddProductReleaseDate" Display="Dynamic" 
                            EnableViewState="False" ErrorMessage="A product release date is required." 
                            ValidationGroup="AddProduct">* A product release date is required.</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="vldCompareAddProductDate" runat="server" 
                            ControlToValidate="txtAddProductReleaseDate" Display="Dynamic" 
                            EnableViewState="False" 
                            ErrorMessage="A valid date must be supplied for product release date." 
                            Operator="DataTypeCheck" Type="Date" ValidationGroup="AddProduct">* A valid date must be supplied for product release date.</asp:CompareValidator>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" 
        onclick="btnAddProduct_Click" ValidationGroup="AddProduct" />
    <br />
    <br />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
</asp:Content>

