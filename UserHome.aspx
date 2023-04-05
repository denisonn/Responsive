<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GeneralLayout.master" CodeFile="UserHome.aspx.cs" Inherits="UserHome" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <asp:Label ID="lblSuccess" runat="server" CssClass="text-success"></asp:Label>

        <nav class="navbar navbar-expand-lg navbar-light ">
            <%--                <a class="navbar-brand" href="Default.aspx">
                    <img alt="Logo" src="Images/tc only 512.png" height="30" />
                    TechCybo.com
                </a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>--%>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Empresas - Sucusales
                            </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <%--<a class="dropdown-item" href="Products.aspx">All Products</a>
                                <div class="dropdown-divider"></div>--%>

                            <asp:Repeater ID="rptCategory" runat="server" OnItemDataBound="OnItemDataBound">
                                <ItemTemplate>
                                    <a class="dropdown-item main-cat" ><%# Eval("Co_empresa") %></a>
                                    <asp:HiddenField ID="hfCo_empresa" runat="server" Value='<%# Eval("Co_empresa") %>' />

                                    <asp:Repeater ID="rptSubCategories" runat="server">
                                        <ItemTemplate>
                                            <a class="dropdown-item" href="Products.aspx?subcat=<%# Eval("Co_sucur") %>"><%# Eval("Co_sucur") %>-<%# Eval("Sucur_des") %></a>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <div class="dropdown-divider"></div>
                                        </FooterTemplate>
                                    </asp:Repeater>

                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </li>
                </ul>
            </div>
        </nav>
    </div>
</asp:Content>
