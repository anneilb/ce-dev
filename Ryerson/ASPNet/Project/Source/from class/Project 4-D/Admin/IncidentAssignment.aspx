<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IncidentAssignment.aspx.cs" Inherits="IncidentAssignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" 
        
        SelectCommand="SELECT Customers.Name AS CustomerName, Incidents.ProductCode, Incidents.DateOpened, Incidents.Title, Incidents.Description, Incidents.IncidentID FROM Incidents INNER JOIN Customers ON Incidents.CustomerID = Customers.CustomerID WHERE (Incidents.TechID IS NULL) ORDER BY Incidents.DateOpened"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" 
        SelectCommand="SELECT Technicians.TechID, Technicians.Name, COUNT(Incidents.IncidentID) AS OpenIncidents FROM Incidents RIGHT OUTER JOIN Technicians ON Incidents.TechID = Technicians.TechID WHERE (Incidents.DateClosed IS NULL) GROUP BY Technicians.TechID, Technicians.Name ORDER BY Technicians.Name"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" 
        DeleteCommand="DELETE FROM [Incidents] WHERE [IncidentID] = @IncidentID" 
        InsertCommand="INSERT INTO [Incidents] ([TechID]) VALUES (@TechID)" 
        SelectCommand="SELECT [IncidentID], [TechID] FROM [Incidents]" 
        UpdateCommand="UPDATE [Incidents] SET [TechID] = @TechID WHERE [IncidentID] = @IncidentID">
        <DeleteParameters>
            <asp:Parameter Name="IncidentID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="TechID" Type="Int32" />
            <asp:Parameter Name="IncidentID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="TechID" Type="Int32" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:MultiView ID="mvwAssignIncident" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwSelectIncident" runat="server">
            <asp:Label ID="lblSelectIncident" runat="server" Text="Select an incident:"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="grdSelectIncident" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IncidentID" 
                DataSourceID="SqlDataSource1" ForeColor="#333333" 
                PageSize="5">
                <PagerSettings Mode="NextPreviousFirstLast" />
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:BoundField DataField="CustomerName" HeaderText="Customer" 
                        SortExpression="CustomerName" />
                    <asp:BoundField DataField="ProductCode" HeaderText="Product" 
                        SortExpression="ProductCode" />
                    <asp:BoundField DataField="DateOpened" DataFormatString="{0:d}" 
                        HeaderText="Date Opened" SortExpression="DateOpened" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="Description" HeaderText="Description" 
                        SortExpression="Description" />
                    <asp:BoundField DataField="IncidentID" HeaderText="IncidentID" 
                        InsertVisible="False" ReadOnly="True" SortExpression="IncidentID" 
                        Visible="False" />
                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            <br />
            <asp:Button ID="btnSelectIncidentNext" runat="server" Text="Next" Width="71px" 
                onclick="btnSelectIncidentNext_Click" />
            <br />
            <br />
            <asp:Label ID="lblSelectIncidentError" runat="server" EnableViewState="False" 
                ForeColor="Red"></asp:Label>
        </asp:View>
        <asp:View ID="vwSelectTech" runat="server">
            <asp:Label ID="lblSelectTech" runat="server" Text="Select a Technician:"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="grdSelectTech" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataKeyNames="TechID" DataSourceID="SqlDataSource2" 
                ForeColor="#333333">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:BoundField DataField="TechID" HeaderText="TechID" InsertVisible="False" 
                        ReadOnly="True" SortExpression="TechID" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="OpenIncidents" HeaderText="Open Incidents" 
                        ReadOnly="True" SortExpression="OpenIncidents">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            <br />
            <asp:Button ID="btnSelectTechPrev" runat="server" Text="Previous" 
                CommandName="PrevView" Width="71px" />
            &nbsp
            <asp:Button ID="btnSelectTechNext" runat="server" Text="Next" Width="71px" 
                onclick="btnSelectTechNext_Click" />
            <br />
            <br />
            <asp:Label ID="lblSelectTechError" runat="server" EnableViewState="False" 
                ForeColor="Red"></asp:Label>
        </asp:View> 
        <asp:View ID="vwSummary" runat="server">
            <asp:Label ID="lblSummary" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnSummaryPrev" runat="server" Text="Previous" 
                CommandName="PrevView" Width="71px" />
            &nbsp
            <asp:Button ID="btnAssignIncident" runat="server" Text="Assign Incident" 
                onclick="btnAssignIncident_Click" />
            <br />
            <br />
            <asp:Label ID="lblSummaryError" runat="server" EnableViewState="False" 
                ForeColor="Red"></asp:Label>        
            </asp:View>    
    </asp:MultiView>
</asp:Content>

