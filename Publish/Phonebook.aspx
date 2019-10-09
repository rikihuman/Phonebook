<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Phonebook.aspx.cs" Inherits="pb" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="card-body">
            <p class="lead" align="center">Welcome to Communication Concordance.</p>
            <div class="row">
                <div class="col-md">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div align="right">
                                <asp:TextBox CssClass="textbox" ID="txtFind" runat="server" MaxLength="150"></asp:TextBox>
                                <asp:LinkButton ID="lbFind" runat="server" class="btn btn-default" OnClick="lbFind_Click">Find</asp:LinkButton>
                                <asp:LinkButton ID="lbNew" runat="server" class="btn btn-default" OnClick="lbNew_Click">New</asp:LinkButton>

                            </div>
                            <br />
                            <div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="pnlContacts" runat="server">
                                            <div class="header" align="center">
                                                <h4 class="title" style="color: #1F77D0; text-transform: uppercase; font-weight: bold; position: relative; line-height: normal; vertical-align: middle; text-align: center">
                                                    <asp:Label ID="lblContact" runat="server" Text="New Contact"></asp:Label></h4>
                                                <div class="form-group">
                                                    <table>
                                                        <tr>
                                                            <th>
                                                                <p>Name</p>
                                                            </th>
                                                            <th>
                                                                <asp:TextBox CssClass="textbox" ID="txtName" runat="server" MaxLength="150"></asp:TextBox></th>
                                                        </tr>
                                                        <tr>
                                                            <th>
                                                                <p>Surname</p>
                                                            </th>
                                                            <th>
                                                                <asp:TextBox CssClass="textbox" ID="txtContactSurname" runat="server" MaxLength="150"></asp:TextBox></th>
                                                        </tr>
                                                        <tr>
                                                            <th>
                                                                <p>Relationship</p>
                                                            </th>
                                                            <th>
                                                                <asp:DropDownList CssClass="textbox" ID="ddlRelationship" runat="server"></asp:DropDownList>
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <th>
                                                                <p>Number Type</p>
                                                            </th>
                                                            <th>
                                                                <asp:DropDownList CssClass="textbox" ID="ddlNumberType" runat="server" OnSelectedIndexChanged="ddlNumberType_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></th>
                                                        </tr>
                                                        <tr>
                                                            <th>
                                                                <p>
                                                                    <asp:Label ID="lblNumType" runat="server">Home</asp:Label>
                                                                </p>
                                                            </th>
                                                            <th>
                                                                <asp:TextBox CssClass="textbox" ID="txtNumber" runat="server" MaxLength="100"></asp:TextBox>
                                                            </th>
                                                        </tr>
                                                        <%--<tr>
                                <th><p>Name</p></th>
                                <th>
                                    <asp:TextBox CssClass="textbox" ID="txtNumber" runat="server" MaxLength="100"></asp:TextBox></th>
                            </tr>--%>
                                                        <tr>
                                                            <th>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-default" OnClick="LinkButton1_Click">Save</asp:LinkButton></th>
                                                            <th>
                                                                <asp:LinkButton ID="lbCancel" runat="server" class="btn btn-default" OnClick="lbCancel_Click">Cancel</asp:LinkButton></th>
                                                        </tr>
                                                        <tr>
                                                            <th></th>
                                                        </tr>

                                                    </table>
                                                </div>
                                            </div>


                                        </asp:Panel>

                                        <div class="card-body">
                                            <div class="table-responsive">
                                                <asp:GridView ID="gvContacts" runat="server" AutoGenerateColumns="false"
                                                    DataKeyNames="ContactID, ContactNumberID" OnRowDataBound="gvContacts_RowDataBound"
                                                    OnRowEditing="gvContacts_RowEditing" OnRowUpdating="gvContacts_RowUpdating"
                                                    HeaderStyle-BorderColor="Silver" RowStyle-BorderColor="Silver"
                                                    BorderColor="Silver" OnRowDeleted="gvContacts_RowDeleted"
                                                    OnRowDeleting="gvContacts_RowDeleting"
                                                    OnSelectedIndexChanged="gvContacts_SelectedIndexChanged"
                                                    OnSelectedIndexChanging="gvContacts_SelectedIndexChanging"
                                                    HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle" CellPadding="5" AllowSorting="True" CssClass="table table-bordered">
                                                    <Columns>

                                                        <%--         <asp:TemplateField>
                            <ItemTemplate>
                    <%#Eval("ContactName")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox CssClass="textbox" runat="server" ID="txtName" Text='<%#Eval("ContactName")%>' EnableViewState="true"></asp:TextBox>
                    
                </EditItemTemplate>
                        </asp:TemplateField>--%>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>Name</HeaderTemplate>
                                                            <%--<InsertItemTemplate>
                                <asp:TextBox CssClass="textbox" ID="txtName" runat="server"></asp:TextBox></th>
                            </InsertItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox CssClass="textbox" ID="txtName" runat="server"></asp:TextBox></th>
                            </EditItemTemplate>--%>
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblContactName" Text='<%#Bind("ContactName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>Surname</HeaderTemplate>
                                                            <%--<InsertItemTemplate>
                                <asp:TextBox CssClass="textbox" ID="txtSurname" runat="server"></asp:TextBox></th>
                            </InsertItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox CssClass="textbox" ID="txtSurname" runat="server"></asp:TextBox></th>
                            </EditItemTemplate>--%>
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblContactSurname" Text='<%#Bind("ContactSurname") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>Number Type</HeaderTemplate>
                                                            <%--<InsertItemTemplate>
                                <asp:TextBox CssClass="textbox" ID="txtRelationship" runat="server"></asp:TextBox></th>
                            </InsertItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox CssClass="textbox" ID="txtRelationship" runat="server"></asp:TextBox></th>
                            </EditItemTemplate>--%>
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblNumberType" Text='<%#Bind("NumberName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate></HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblNumber" Text='<%#Bind("Number") %> '></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>Relationship</HeaderTemplate>
                                                            <%--<InsertItemTemplate>
                                <asp:TextBox CssClass="textbox" ID="txtRelationship" runat="server"></asp:TextBox></th>
                            </InsertItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox CssClass="textbox" ID="txtRelationship" runat="server"></asp:TextBox></th>
                            </EditItemTemplate>--%>
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblRelationship" Text='<%#Bind("RelationshipName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>

                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lbUpdate" runat="server" class="btn btn-default" CommandArgument='<%#Bind("ContactID") %>' OnClick="lbUpdate_Click">Edit</asp:LinkButton>
                                                                <asp:LinkButton ID="lbDelete" runat="server" class="btn btn-default" CommandName="Delete" CommandArgument='<%#Bind("ContactID") %>' OnClientClick="return confirm('Are you sure you want to delete?');">Delete</asp:LinkButton>

                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle BorderColor="Silver" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <RowStyle BorderColor="Silver" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <%-- <asp:AsyncPostBackTrigger ControlID="lbUpdate" EventName="" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <%-- <asp:AsyncPostBackTrigger ControlID="lbUpdate" EventName="" />--%>
                        </Triggers>
                    </asp:UpdatePanel>
                </div>

            </div>

        </div>
    </div>
</asp:Content>
