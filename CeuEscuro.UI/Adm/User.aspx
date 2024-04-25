<%@ Page Title="" Language="C#" MasterPageFile="~/Adm/ManagerUser.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="CeuEscuro.UI.Adm.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblSession" runat="server" Text=""></asp:Label>

    <ul>
        <li> <asp:TextBox ID="txtId" placeholder="Id:" runat="server"></asp:TextBox> </li>

        <li> 
            <asp:TextBox ID="txtNome" placeholder="Name:" runat="server" MaxLength="150"></asp:TextBox>  
            <asp:Label ID="lblNome" runat="server" Text=""></asp:Label>
        </li>

        <li> 
            <asp:TextBox ID="txtEmail" placeholder="Email:" runat="server" MaxLength="150"></asp:TextBox> 
            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
        </li>

        <li> 
            <asp:TextBox ID="txtSenha" placeholder="Password:" runat="server" MaxLength="6"></asp:TextBox> 
             <asp:Label ID="lblSenha" runat="server" Text=""></asp:Label>
        </li>

        <li> 
            <asp:TextBox ID="txtDataNascUsuario" onkeypress="$(this).mask('00/00/0000')" placeholder="Birth Date:" runat="server"></asp:TextBox> 
            <asp:Label ID="lblDataNascUsuario" runat="server" Text=""></asp:Label>
        </li>

        <%--Listinha dos tipos de usuários--%>
        <li> <asp:DropDownList ID="ddl1" width="160px" Height="27px" AutoPostBack="false" DataValueField="Id" DataTextField="Descricao" runat="server"></asp:DropDownList> </li>
        <%------------------%>

        <li> 
            <asp:Button ID="btnRecord" runat="server" Text="Record" OnClick="btnRecord_Click"/> 
            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click"/>
            <asp:Button ID="btnDelete"  runat="server" Text="Delete" OnClick="btnDelete_Click" OnClientClick="if(!confirm('Deseja excluir este usuário?')) return false"/>
        </li>
        
        <%--SearchById--%>
        <li>
            <asp:TextBox ID="txtSearch" runat="server" placeholder="Search by Name"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <asp:Label ID="lblSearch" runat="server" Text=""></asp:Label>
        </li>
        
    </ul>

    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

    <asp:GridView ID="gv1" AutoGenerateColumns="false" runat="server" OnSelectedIndexChanged="gv1_SelectedIndexChanged">

        <Columns>
            <asp:CommandField ShowSelectButton="true" ButtonType="Button"/>
            <asp:BoundField DataField="Id" HeaderText="Id"/>
            <asp:BoundField DataField="Nome" HeaderText="Name"/>
            <asp:BoundField DataField="Email" HeaderText="Email"/>
            <asp:BoundField DataField="Senha" HeaderText="Password"/>
            <asp:BoundField DataField="DataNascUsuario" HeaderText="Birth Date" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField DataField="TipoUsuario_Id" HeaderText="Permission"/>
        </Columns>

    </asp:GridView>

</asp:Content>

