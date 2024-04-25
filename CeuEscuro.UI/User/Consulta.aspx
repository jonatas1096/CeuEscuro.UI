<%@ Page Title="" Language="C#" MasterPageFile="~/User/ConsultaUser.Master" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="CeuEscuro.UI.User.Consulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="gv2" AutoGenerateColumns="false" runat="server">
        <Columns>
     
            <asp:BoundField DataField="Id" HeaderText="Id"/>
            <asp:BoundField DataField="Nome" HeaderText="Name"/>
            <asp:BoundField DataField="Email" HeaderText="Email"/>
            <asp:BoundField DataField="DataNascUsuario" HeaderText="Birth Date" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField DataField="TipoUsuario_Id" HeaderText="Permission"/>
        </Columns>
    </asp:GridView>

</asp:Content>
