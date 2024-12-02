<%@ Page Title="" Language="C#" MasterPageFile="~/user/DefaultUser.Master" AutoEventWireup="true" CodeBehind="ConsultaUser.aspx.cs" Inherits="Slayer.UI.user.ConsultaUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="IdUsuario" HeaderText="Código" />
            <asp:BoundField DataField="EmailUsuario" HeaderText="Email" />
            <asp:BoundField DataField="DtNascUsuario" HeaderText="Data Nascimento" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="UsuarioTp" HeaderText="Permissão" />
        </Columns>
    </asp:GridView>

</asp:Content>
