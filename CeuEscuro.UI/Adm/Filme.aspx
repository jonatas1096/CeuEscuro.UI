<%@ Page Title="" Language="C#" MasterPageFile="~/Adm/ManagerUser.Master" AutoEventWireup="true" CodeBehind="Filme.aspx.cs" Inherits="CeuEscuro.UI.Adm.Filme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="gv2" AutoGenerateColumns="false" runat="server">

        <Columns>
            <asp:CommandField ShowSelectButton="true" ButtonType="Button"/>
            <asp:BoundField DataField="Id" HeaderText="Id"/>
            <asp:BoundField DataField="Titulo" HeaderText="Title"/>
            <asp:BoundField DataField="Produtora" HeaderText="Email"/>
            <asp:BoundField DataField="Classificacao_Id" HeaderText="Classification"/>
            <asp:BoundField DataField="Genero_Id" HeaderText="Type"/>
            <asp:ImageField DataImageUrlField="UrlImg" HeaderText="Imagem" ControlStyle-Width="100"/>
        </Columns>

    </asp:GridView>

</asp:Content>
