<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IncidentUpdate.aspx.cs" Inherits="IncidentUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetCustomersWithIncidents" TypeName="CustomerDB"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        InsertMethod="InsertIncident" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetCustomerIncidents" TypeName="IncidentDB" 
        UpdateMethod="UpdateIncident">
        <UpdateParameters>
            <asp:Parameter Name="DateClosed" Type="DateTime" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="original_IncidentID" Type="Int32" />
            <asp:Parameter Name="original_ProductCode" Type="String" />
            <asp:Parameter Name="original_DateOpened" Type="DateTime"/>
            <asp:Parameter Name="original_DateClosed" Type="Object" />
            <asp:Parameter Name="original_Title" Type="String" />
            <asp:Parameter Name="original_Description" Type="String" />
        </UpdateParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlCustomers" Name="CustomerID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="CustomerID" Type="Int32" />
            <asp:Parameter Name="ProductCode" Type="String" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <asp:Label ID="lblCustomers" runat="server" Text="Select a customer:  "></asp:Label>
    <asp:DropDownList ID="ddlCustomers" runat="server" 
        DataSourceID="ObjectDataSource1" DataTextField="Name" 
        DataValueField="CustomerID" AutoPostBack="True">
    </asp:DropDownList>
    <br /><br />
    <asp:GridView ID="grdIncidents" runat="server" CellPadding="4" 
        DataSourceID="ObjectDataSource2" ForeColor="#333333" 
        AutoGenerateColumns="False" 
        
        DataKeyNames="IncidentID,ProductCode,DateOpened,DateClosed,Title,Description" 
        onrowupdated="grdIncidents_RowUpdated">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="IncidentID" HeaderText="ID" ReadOnly="True" 
                SortExpression="IncidentID" >
            <ItemStyle VerticalAlign="Top" />
            </asp:BoundField>
            <asp:BoundField DataField="ProductCode" HeaderText="Product Code" 
                ReadOnly="True" SortExpression="ProductCode" >
            <ItemStyle VerticalAlign="Top" />
            </asp:BoundField>
            <asp:BoundField DataField="DateOpened" HeaderText="Date Opened" ReadOnly="True" 
                SortExpression="DateOpened" DataFormatString="{0:d}" >
            <ItemStyle VerticalAlign="Top" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Date Closed" SortExpression="DateClosed">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DateClosed") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("DateClosed", "{0:d}") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="True" 
                SortExpression="Title" >
            <ItemStyle VerticalAlign="Top" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Description" SortExpression="Description">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Height="55px" 
                        Text='<%# Bind("Description") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:CommandField ButtonType="Button" ShowEditButton="True" >
            <ItemStyle VerticalAlign="Top" />
            </asp:CommandField>
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <br />
    <asp:Label ID="lblError" runat="server" EnableViewState="False"></asp:Label>
</asp:Content>

