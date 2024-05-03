<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CeuEscuro.UI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CéuEscuro</title>
     <link rel="stylesheet" type="text/css" href="StyleLogin.css" media="screen" />
</head>
<body>
        <header>
            <asp:Image id="senaclogo" runat="server" src="src/senaclogo.png"/>
        </header>
        <div id="container">
            <div id="areaLogin">
                    <form id="form1" runat="server"> 
                        <div id="areaLoginHeader"><h1>Céu Escuro</h1></div>
                        <div id="areaLoginFields">
                            <ul>
                                <li>
                                    <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" autofocus="" ></asp:TextBox>
                                </li>
                                <li>
                                    <asp:TextBox ID="txtSenha" runat="server" placeholder="Senha" MaxLength="6" TextMode="Password"></asp:TextBox>
                                </li>
                                <li>
                                    <asp:Button ID="btnLogar" runat="server" Text="Logar" OnClick="btnLogar_Click"/>
                                    <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
                                </li>
                                <li>
                                    <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
                                </li>
                            </ul>
                        </div>
                    </form>
            </div>
        </div>
</body>
</html>

