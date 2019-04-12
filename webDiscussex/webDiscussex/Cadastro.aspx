<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="webDiscussex.Cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/cadastro.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col col-2" id="imgLogin">
                <img src="img/LoginImg.png">
            </div>
            <div class="col col-2">
                <form id="frmCadastro" action="/Usuario/Adiciona" method="post">
                    <h1 id="tituloLogin">CADASTRO</h1>
                    <button class="btn google" type="button" name="btnLoginGoogle" id="btnLoginGoogle" value="Entrar">
                        <i class="fab fa-google"></i>
                        <span>Cadastrar com o Google</span>
                    </button>
                    <div class="campoTexto">
                        <input type="email" name="user.Email" id="txtLoginEmail" class="Input-text" placeholder="Email">
                        <label for="input" class="Input-label">Email</label>
                    </div>
                    <div class="campoTexto">
                        <input type="text" name="user.NomeUsuario" id="txtNomeUsuario" class="Input-text" placeholder="Nome de usuário">
                        <label for="input" class="Input-label">Nome de usuário</label>
                    </div>
                    <div class="campoTexto">
                        <input type="password" name="user.Senha" id="txtSenhaCadastro" class="Input-text" placeholder="Senha">
                        <label for="input" class="Input-label">Senha</label>
                    </div>
                    <div>
                            <label for="txtImg" class="fileContainer ">
                        <input type="file" name="txtImg" id="txtImg" aria-label="asa">
                       </label>
                    </div>
                    <input class="btn" type="submit" name="btnSubmitCadastro" id="btnSubmitCadastro" value="Cadastrar">
                   
                </form>
            </div>
</asp:Content>
