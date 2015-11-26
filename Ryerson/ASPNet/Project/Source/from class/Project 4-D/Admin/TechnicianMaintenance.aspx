<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TechnicianMaintenance.aspx.cs" Inherits="TechnicianMaintenance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 75px;
        }
        .style2
        {
            width: 201px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" 
        SelectCommand="SELECT [TechID], [Name] FROM [Technicians] ORDER BY [Name]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConflictDetection="CompareAllValues" 
        ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" 
        DeleteCommand="DELETE FROM [Technicians] WHERE [TechID] = @original_TechID AND [Name] = @original_Name AND [Email] = @original_Email AND [Phone] = @original_Phone" 
        InsertCommand="INSERT INTO [Technicians] ([Name], [Email], [Phone]) VALUES (@Name, @Email, @Phone)" 
        OldValuesParameterFormatString="original_{0}" 
        SelectCommand="SELECT * FROM [Technicians] WHERE ([TechID] = @TechID)" 
        UpdateCommand="UPDATE [Technicians] SET [Name] = @Name, [Email] = @Email, [Phone] = @Phone WHERE [TechID] = @original_TechID AND [Name] = @original_Name AND [Email] = @original_Email AND [Phone] = @original_Phone">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlTechnician" Name="TechID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="original_TechID" Type="Int32" />
            <asp:Parameter Name="original_Name" Type="String" />
            <asp:Parameter Name="original_Email" Type="String" />
            <asp:Parameter Name="original_Phone" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Phone" Type="String" />
            <asp:Parameter Name="original_TechID" Type="Int32" />
            <asp:Parameter Name="original_Name" Type="String" />
            <asp:Parameter Name="original_Email" Type="String" />
            <asp:Parameter Name="original_Phone" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Phone" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:Label ID="lblTechnician" runat="server" Text="Select a Technician:"></asp:Label>
    <asp:DropDownList ID="ddlTechnician" runat="server" AutoPostBack="True" 
        DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="TechID">
    </asp:DropDownList>
    <br />
    <br />
    <table>
        <tr>
            <td class="DataListColumnWidthLarge15">   
        
        <asp:FormView ID="FormView1" runat="server" CellPadding="4" 
            DataKeyNames="TechID" DataSourceID="SqlDataSource2" ForeColor="#333333" 
            GridLines="Both" onitemdeleted="FormView1_ItemDeleted" 
                    oniteminserted="FormView1_ItemInserted" onitemupdated="FormView1_ItemUpdated" 
                    onmodechanging="FormView1_ModeChanging">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <EditItemTemplate>
                <table>
                    <tr>
                        <td class="style1">
                            TechID:
                        </td>
                        <td class="style2">
                            <asp:Label ID="TechIDLabel1" runat="server" Text='<%# Eval("TechID") %>' />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Name:
                        </td>
                        <td class="style2">
                            <asp:TextBox ID="txtEditTechName" runat="server" Text='<%# Bind("Name") %>' 
                                CausesValidation="True" ValidationGroup="EditTech" Width="200px" />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="vldRequiredEditTechName" runat="server" 
                                ControlToValidate="txtEditTechName" Display="Static" EnableViewState="False"
                                ErrorMessage="A name is required." ValidationGroup="EditTech" 
                                EnableClientScript="False">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Email:
                        </td>
                        <td class="style2">
                            <asp:TextBox ID="txtEditTechEmail" runat="server" Text='<%# Bind("Email") %>' 
                                CausesValidation="True" ValidationGroup="EditTech" Width="200px" />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="vldRequiredEditTechEmail" runat="server" 
                                ControlToValidate="txtEditTechEmail" Display="Static" EnableViewState="False"
                                ErrorMessage="An email address is required." ValidationGroup="EditTech" 
                                EnableClientScript="False">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Phone:
                        </td>
                        <td class="style2">
                            <asp:TextBox ID="txtEditTechPhone" runat="server" Text='<%# Bind("Phone") %>' 
                                CausesValidation="True" ValidationGroup="EditTech" />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="vldRequiredEditTechPhone" runat="server" 
                                ControlToValidate="txtEditTechPhone" Display="Static" EnableViewState="False"
                                ErrorMessage="A phone number is required." ValidationGroup="EditTech" 
                                EnableClientScript="False">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="btnUpdate" runat="server" CausesValidation="True" 
                    CommandName="Update" Text="Update" ValidationGroup="EditTech"/>
                &nbsp;<asp:Button ID="btnUpdateCancel" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                <table>
                    <tr>
                        <td class="style1">
                            Name:
                        </td>
                        <td class="style2">
                            <asp:TextBox ID="txtInsertTechName" runat="server" Text='<%# Bind("Name") %>' 
                                CausesValidation="True" ValidationGroup="InsertTech" Width="200px"/>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="vldRequiredInsertTechName" runat="server" 
                                ControlToValidate="txtInsertTechName" Display="Static" EnableViewState="False"
                                ErrorMessage="A name is required." ValidationGroup="InsertTech" 
                                EnableClientScript="False">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Email:
                        </td>
                        <td class="style2">
                            <asp:TextBox ID="txtInsertTechEmail" runat="server" Text='<%# Bind("Email") %>'
                                CausesValidation="True" ValidationGroup="InsertTech" Width="200px"/>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="vldRequiredInsertTechEmail" runat="server" 
                                ControlToValidate="txtInsertTechEmail" Display="Static" EnableViewState="False"
                                ErrorMessage="An email address is required." ValidationGroup="InsertTech" 
                                EnableClientScript="False">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Phone:
                        </td>
                        <td class="style2">
                            <asp:TextBox ID="txtInsertTechPhone" runat="server" Text='<%# Bind("Phone") %>' 
                                CausesValidation="True" ValidationGroup="InsertTech" />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="vldRequiredInsertTechPhone" runat="server" 
                                ControlToValidate="txtInsertTechPhone" Display="Static" EnableViewState="False"
                                ErrorMessage="A phone number is required." ValidationGroup="InsertTech" 
                                EnableClientScript="False">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="btnInsert" runat="server" CausesValidation="True" 
                    CommandName="Insert" Text="Insert" ValidationGroup="InsertTech" />
                &nbsp;<asp:Button ID="btnInsertCancel" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                <table>
                    <tr>
                        <td class="style1">
                            TechID:
                        </td>
                        <td>
                            <asp:Label ID="TechIDLabel" runat="server" Text='<%# Eval("TechID") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Name:
                        </td>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Email:
                        </td>
                        <td>
                            <asp:Label ID="EmailLabel" runat="server" Text='<%# Bind("Email") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Phone:
                        </td>
                        <td>
                            <asp:Label ID="PhoneLabel" runat="server" Text='<%# Bind("Phone") %>' />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="btnEdit" runat="server" CausesValidation="False" 
                    CommandName="Edit" Text="Edit" />
                &nbsp;<asp:Button ID="btnDelete" runat="server" CausesValidation="False" 
                    CommandName="Delete" Text="Delete" />
                &nbsp;<asp:Button ID="btnNew" runat="server" CausesValidation="False" 
                    CommandName="New" Text="New" />
            </ItemTemplate>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
        </asp:FormView>    
            </td>
            <td valign="top">
                <asp:ValidationSummary ID="vldSummaryTech" runat="server" 
                    HeaderText="Please correct the following errors:" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Label ID="lblError" runat="server" />    
    </asp:Content>

