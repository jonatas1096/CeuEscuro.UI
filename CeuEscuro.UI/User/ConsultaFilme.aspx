<%@ Page Title="" Language="C#" MasterPageFile="~/User/ConsultaUser.Master" AutoEventWireup="true" CodeBehind="ConsultaFilme.aspx.cs" Inherits="CeuEscuro.UI.User.ConsultaFilme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="gv1" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Nome" HeaderText="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Senha" HeaderText="Password" />
            <asp:BoundField DataField="DataNascUsuario" HeaderText="Birth Date" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="TipoUsuario_Id" HeaderText="Permission" />
        </Columns>

    </asp:GridView>
</asp:Content>
