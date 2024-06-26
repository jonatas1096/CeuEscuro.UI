﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CeuEscuro.UI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>CéuEscuro</title>
    <link rel="stylesheet" type="text/css" href="resource/Style.css" media="screen" />
</head>
<body>
    <header>
        <asp:Image ID="senaclogo" runat="server" src="src/senaclogo.png" />
    </header>
    <div id="containerLogin">
        <form id="areaLogin" runat="server">
            <ul>
                <li>
                    <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" autofocus=""></asp:TextBox>
                </li>
                <li>
                    <asp:TextBox ID="txtSenha" runat="server" placeholder="Senha" MaxLength="6" TextMode="Password"></asp:TextBox>
                </li>
                <li>
                    <asp:Button ID="btnLogar" runat="server" Text="Logar" OnClick="btnLogar_Click" />
                    <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
                </li>
                <li>
                    <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
                </li>
            </ul>
        </form>
    </div>
</body>
</html>

