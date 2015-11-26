<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IncidentDisplay.aspx.cs" Inherits="IncidentDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" 
        SelectCommand="SELECT Products.Name AS ProductName, Customers.Name AS CustomerName, 
                       Technicians.Name AS TechnicianName, Incidents.DateOpened, Incidents.DateClosed, 
                       Incidents.Title, Incidents.Description FROM Incidents INNER JOIN Products 
                       ON Incidents.ProductCode = Products.ProductCode INNER JOIN Customers 
                       ON Incidents.CustomerID = Customers.CustomerID LEFT OUTER JOIN Technicians 
                       ON Incidents.TechID = Technicians.TechID ORDER BY Incidents.DateOpened"></asp:SqlDataSource>        
    <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <tr style="" class="ListViewItemTemplate">
                <td>
                    <asp:Label ID="ProductNameLabel" runat="server" 
                        Text='<%# Eval("ProductName") %>' />
                    <br />
                </td>
                <td>
                    <asp:Label ID="CustomerNameLabel" runat="server" 
                        Text='<%# Eval("CustomerName") %>' />
                    <br />
                </td>
                <td align="center">
                    <asp:Label ID="TechnicianNameLabel" runat="server" 
                        Text='<%# Eval("TechnicianName") %>' />
                    <br />
                </td>
            </tr>           
            <tr style="" class="ListViewItemTemplate">
                <td></td>
                <td valign="top">
                    Date Opened:
                    <br />
                    DateClosed:
                    <br />
                    Title:
                    <br />
                    Description:
                    <br /><br />
                </td>                
                <td valign="top">
                    <asp:Label ID="DateOpenedLabel" runat="server" 
                        Text='<%# Eval("DateOpened") %>' />
                    <br />
                    <asp:Label ID="DateClosedLabel" runat="server" 
                        Text='<%# Eval("DateClosed") %>' />
                    <br />
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    <br />
                    <asp:Label ID="DescriptionLabel" runat="server" 
                        Text='<%# Eval("Description") %>' />
                    <br /><br />
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr style="" class="ListViewAlternatingItemTemplate">
                <td>
                    <asp:Label ID="ProductNameLabel" runat="server" 
                        Text='<%# Eval("ProductName") %>' />
                    <br />
                </td>
                <td>
                    <asp:Label ID="CustomerNameLabel" runat="server" 
                        Text='<%# Eval("CustomerName") %>' />
                    <br />
                </td>
                <td align="center">
                    <asp:Label ID="TechnicianNameLabel" runat="server" 
                        Text='<%# Eval("TechnicianName") %>' />
                    <br />
                </td>
            </tr>
            <tr style="" class="ListViewAlternatingItemTemplate">
                <td></td>
                <td valign="top">
                    Date Opened:
                    <br />
                    DateClosed:
                    <br />
                    Title:
                    <br />
                    Description:
                    <br /><br />
                </td>                
                <td valign="top">
                    <asp:Label ID="DateOpenedLabel" runat="server" 
                        Text='<%# Eval("DateOpened") %>' />
                    <br />
                    <asp:Label ID="DateClosedLabel" runat="server" 
                        Text='<%# Eval("DateClosed") %>' />
                    <br />
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    <br />
                    <asp:Label ID="DescriptionLabel" runat="server" 
                        Text='<%# Eval("Description") %>' />
                    <br /><br />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>
                        No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                        Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                        Text="Clear" />
                </td>
                <td>
                    <asp:TextBox ID="ProductNameTextBox" runat="server" 
                        Text='<%# Bind("ProductName") %>' />
                </td>
                <td>
                    <asp:TextBox ID="CustomerNameTextBox" runat="server" 
                        Text='<%# Bind("CustomerName") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TechnicianNameTextBox" runat="server" 
                        Text='<%# Bind("TechnicianName") %>' />
                </td>
                <td>
                    <asp:TextBox ID="DateOpenedTextBox" runat="server" 
                        Text='<%# Bind("DateOpened") %>' />
                </td>
                <td>
                    <asp:TextBox ID="DateClosedTextBox" runat="server" 
                        Text='<%# Bind("DateClosed") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                </td>
                <td>
                    <asp:TextBox ID="DescriptionTextBox" runat="server" 
                        Text='<%# Bind("Description") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table ID="itemPlaceholderContainer" runat="server" border="0" style="" cellspacing="0">
                            <tr runat="server" style="" class="ListViewLayoutTemplateHeader">
                                <th runat="server" class="DataListColumnWidthMedium15" align="left">
                                    Product</th>
                                <th runat="server" align="left" class="DataListColumnWidthSmall15">
                                    Customer</th>
                                <th runat="server" align="center" class="DataListColumnWidthXL">
                                    Technician</th>                                
                            </tr>
                            <tr ID="itemPlaceholder" runat="server">                            
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server" class="ListViewLayoutTemplateFooter">
                    <td runat="server" style="" align="center">
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="4">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="True" 
                                    ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <EditItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                        Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                        Text="Cancel" />
                </td>
                <td>
                    <asp:TextBox ID="ProductNameTextBox" runat="server" 
                        Text='<%# Bind("ProductName") %>' />
                </td>
                <td>
                    <asp:TextBox ID="CustomerNameTextBox" runat="server" 
                        Text='<%# Bind("CustomerName") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TechnicianNameTextBox" runat="server" 
                        Text='<%# Bind("TechnicianName") %>' />
                </td>
                <td>
                    <asp:TextBox ID="DateOpenedTextBox" runat="server" 
                        Text='<%# Bind("DateOpened") %>' />
                </td>
                <td>
                    <asp:TextBox ID="DateClosedTextBox" runat="server" 
                        Text='<%# Bind("DateClosed") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                </td>
                <td>
                    <asp:TextBox ID="DescriptionTextBox" runat="server" 
                        Text='<%# Bind("Description") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <SelectedItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="ProductNameLabel" runat="server" 
                        Text='<%# Eval("ProductName") %>' />
                </td>
                <td>
                    <asp:Label ID="CustomerNameLabel" runat="server" 
                        Text='<%# Eval("CustomerName") %>' />
                </td>
                <td>
                    <asp:Label ID="TechnicianNameLabel" runat="server" 
                        Text='<%# Eval("TechnicianName") %>' />
                </td>
                <td>
                    <asp:Label ID="DateOpenedLabel" runat="server" 
                        Text='<%# Eval("DateOpened") %>' />
                </td>
                <td>
                    <asp:Label ID="DateClosedLabel" runat="server" 
                        Text='<%# Eval("DateClosed") %>' />
                </td>
                <td>
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                </td>
                <td>
                    <asp:Label ID="DescriptionLabel" runat="server" 
                        Text='<%# Eval("Description") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
</asp:Content>

