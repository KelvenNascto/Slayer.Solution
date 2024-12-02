<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefaultAdm.Master" AutoEventWireup="true" CodeBehind="ManageAdmFilme.aspx.cs" Inherits="Slayer.UI.adm.ManageAdmFilme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--formulario--%>
    <ul>
        <li>
            <asp:TextBox ID="txtId" runat="server" placeholder="Id:"></asp:TextBox>
        </li>
        <li>
            <asp:TextBox ID="txtTitulo" runat="server" placeholder="Titulo:" MaxLength="150"></asp:TextBox>
            <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:TextBox ID="txtProdutora" runat="server" placeholder="Produtora:" MaxLength="150"></asp:TextBox>
            <asp:Label ID="lblProdutora" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <span>Selecione a classificação:</span>
        </li>
        <li>
            <asp:DropDownList
                ID="ddlClassif"
                Width="260px"
                Height="40px"
                CssClass="large-text"
                AutoPostBack="false"
                DataValueField="IdClassificacao"
                DataTextField="DescricaoClassificacao"
                runat="server">
            </asp:DropDownList>
        </li>
        <li>
            <span>Selecione o gênero:</span>
        </li>
        <li>
            <asp:DropDownList
                ID="ddlGenero"
                Width="260px"
                Height="40px"
                CssClass="large-text"
                AutoPostBack="false"
                DataValueField="IdGenero"
                DataTextField="DescricaoGenero"
                runat="server">
            </asp:DropDownList>
        </li>
        <li>
            <asp:FileUpload ID="Fup" runat="server" OnChange="previewImage(this)" />
            <asp:Label ID="lblFup" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:Image ID="img1" runat="server" Width="200" ClientIDMode="Static" />
            <asp:Label ID="lblImg" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:Button ID="btnRecord" runat="server" Text="Record" OnClick="btnRecord_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClientClick="if(!confirm('Deseja realmente eliminar esse registro ?'))return false" OnClick="btnDelete_Click" />
        </li>
        <li>
            <asp:TextBox ID="txtSearch" runat="server" placeholder="Search by Title:" MaxLength="150"></asp:TextBox>

            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />

            <asp:Label ID="lblSearch" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <%--filter--%>
            <asp:TextBox ID="txtFiltro" runat="server" placeholder="Filter by genre:" MaxLength="150"></asp:TextBox>
        </li>
        <li>
            <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" />
            <asp:Button ID="btnClearFilter" runat="server" Text="Clear Filter" OnClick="btnClearFilter_Click" />
            <asp:Label ID="lblFilter" runat="server" Text=""></asp:Label>
        </li>
    </ul>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

    <%--gridView--%>
    <asp:GridView ID="gv2" AutoGenerateColumns="false" runat="server" OnSelectedIndexChanged="gv2_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="true" ButtonType="Button" HeaderText="Options" />
            <asp:BoundField DataField="IdFilme" HeaderText="Código" />
            <asp:BoundField DataField="TituloFilme" HeaderText="Título" />
            <asp:BoundField DataField="ProdutoraFilme" HeaderText="Produtora" />
            <asp:BoundField DataField="ClassificacaoId" HeaderText="Classificação" />
            <asp:BoundField DataField="GeneroId" HeaderText="Gênero" />
            <asp:ImageField DataImageUrlField="UrlFilme" HeaderText="Imagem" ControlStyle-Width="100%" ControlStyle-Height="150"/>
        </Columns>
        <SelectedRowStyle BackColor="white"
            ForeColor="black"
            Font-Bold="true" />
    </asp:GridView>
</asp:Content>
