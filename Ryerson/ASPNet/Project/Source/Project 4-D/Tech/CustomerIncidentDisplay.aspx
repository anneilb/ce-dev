<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerIncidentDisplay.aspx.cs" Inherits="CustomerIncidentDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" 
        SelectCommand="SELECT [CustomerID], [Name] FROM [Customers] ORDER BY [Name]">
    </asp:SqlDataSource>
    <asp:Label ID="lblSelectACustomer" runat="server" Text="Select a customer:  "></asp:Label>
    <asp:DropDownList ID="ddlCustomers" runat="server" AutoPostBack="True" 
        DataSourceID="SqlDataSource1" DataTextField="Name" 
        DataValueField="CustomerID" 
        onselectedindexchanged="ddlCustomers_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <br />
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>"         
        SelectCommand="SELECT Products.Name AS ProductName, Incidents.Title, Technicians.Name AS TechnicianName, Incidents.Description, Incidents.DateOpened, Incidents.DateClosed FROM Incidents INNER JOIN Products ON Incidents.ProductCode = Products.ProductCode LEFT OUTER JOIN Technicians ON Incidents.TechID = Technicians.TechID WHERE (Incidents.CustomerID = @CustomerID) ORDER BY Incidents.DateOpened">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlCustomers" Name="CustomerID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:DataList ID="DataList1" runat="server" CellPadding="4" 
        DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="Both" 
        ShowFooter="False">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingItemStyle BackColor="White" />
        <ItemStyle BackColor="#EFF3FB" />
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderTemplate>
            <table>
                <tr>
                    <td class="DataListColumnWidthMedium">
                        Product/<br />
                        Incident</td>
                    <td class="DataListColumnWidthLarge">
                        Tech Name/<br />
                        Description</td>
                    <td class="DataListColumnWidthSmall" valign="top">
                        Date Opened</td>
                    <td class="DataListColumnWidthSmall" valign="top">
                        Date Closed</td>
                </tr>
            </table>
        </HeaderTemplate>
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <ItemTemplate>
            <table>
                <tr>
                    <td class="DataListColumnWidthMedium" valign="top">
                        <asp:Label ID="ProductNameLabel" runat="server" 
                            Text='<%# Eval("ProductName") %>' />
                        <br />
                        <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    </td>
                    <td class="DataListColumnWidthLarge" valign="top">
                        <asp:Label ID="TechnicianNameLabel" runat="server" 
                            Text='<%# Eval("TechnicianName") %>' />
                        <br />
                        <asp:Label ID="DescriptionLabel" runat="server" 
                            Text='<%# Eval("Description") %>' />
                    </td>
                    <td class="DataListColumnWidthSmall" valign="top">
                        <asp:Label ID="DateOpenedLabel" runat="server" 
                            Text='<%# Eval("DateOpened", "{0:d}") %>' />
                    </td>
                    <td class="DataListColumnWidthSmall" valign="top">
                        <asp:Label ID="DateClosedLabel" runat="server" 
                            Text='<%# Eval("DateClosed", "{0:d}") %>' />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>    
</asp:Content>

