<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TechnicianIncidentSummary.aspx.cs" Inherits="TechnicianIncidentSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="TechSupportDataContext" OrderBy="Name" 
        Select="new (TechID, Name)" TableName="Technicians">
    </asp:LinqDataSource>
    <asp:LinqDataSource ID="LinqDataSource2" runat="server" 
        ContextTypeName="TechSupportDataContext" OrderBy="ProductCode" 
        Select="new (key as ProductCode, it as IncidentRecords, Count() as Count)" TableName="IncidentRecords" 
        Where="TechID == @TechID" GroupBy="ProductCode" OrderGroupsBy="key">
        <WhereParameters>
            <asp:ControlParameter ControlID="ddlTechnicians" Name="TechID" 
                PropertyName="SelectedValue" Type="Int32" />
        </WhereParameters>
    </asp:LinqDataSource>
    <asp:Label ID="lblTechnicians" runat="server" Text="Technician: "></asp:Label>
    <asp:DropDownList ID="ddlTechnicians" runat="server" AutoPostBack="True" 
        DataSourceID="LinqDataSource1" DataTextField="Name" DataValueField="TechID">
    </asp:DropDownList>
    <br />
    <br />
    <asp:GridView ID="grdTechnicianIncidents" runat="server" 
        AutoGenerateColumns="False" DataSourceID="LinqDataSource2" CellPadding="4" 
        ForeColor="#333333">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="ProductCode" HeaderText="Product" ReadOnly="True" 
                SortExpression="ProductCode" 
                ItemStyle-CssClass="DataListColumnWidthSmall" >
            <HeaderStyle HorizontalAlign="Left" />
<ItemStyle CssClass="DataListColumnWidthSmall"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Count" HeaderText="No. of Incidents" ReadOnly="True" 
                SortExpression="Count" >
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
</asp:Content>

