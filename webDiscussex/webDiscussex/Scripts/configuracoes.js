$(document).ready(() => {
    
    $("#btnAlteraNome").click(() => {
        var txt = "<div id='fundoPreto'></div> </div > <div id='areaConfiguracoes' class='row container'> <div class='col'>" +
        "<form id='frmConfig' method='post' action='/ Usuario / Excluir'> <div class='campoTexto'> <input type='text' name='nomeUser' id='txtNomeUsuario' class='Input-text' placeholder='Novo nome de usuário'>" +
        "<label for='input' class='Input-label'>Novo nome de usuário</label></div><div class='campoTexto'> <input type='password' name='senha' id='txtSenha' class='Input-text' placeholder='Senha'>" +
        "<label for='input' class='Input-label'>Senha</label ></div><input class='btn' type= 'submit' name= 'btnSubmitAlteraNome' id= 'btnSubmitAlteraNome' value= 'Alterar Nome'></form ></div></div>";
        document.getElementById("pagina").innerHTML += txt;

        //$("#pagina").click(() => {
        //        document.getElementById("pagina").removeChild(document.getElementById("fundoPreto"));
        //        document.getElementById("pagina").removeChild(document.getElementById("areaConfiguracoes"));
        //});
    });

    $("#btnAlteraEmail").click(() => {
        var txt = "<div id='fundoPreto'></div> </div > <div id='areaConfiguracoes' class='row container'> <div class='col'>" +
            "<form id='frmConfig' method='post' action='/ Usuario / Excluir'> <div class='campoTexto'> <input type='text' name='novoEmail' id='txtNovoEmail' class='Input-text' placeholder='Novo email'>" +
            "<label for='input' class='Input-label'>Novo email</label></div><div class='campoTexto'> <input type='password' name='senha' id='txtSenha' class='Input-text' placeholder='Senha'>" +
            "<label for='input' class='Input-label'>Senha </label ></div><input class='btn' type= 'submit' name= 'btnSubmitAlteraEmail' id= 'btnSubmitAlteraEmail' value= 'Altera Email'></form ></div></div>";
        document.getElementById("pagina").innerHTML += txt;
    });


    $("#btnAlteraSenha").click(() => {
        var txt = "<div id='fundoPreto'></div> </div > <div id='areaConfiguracoes' class='row container'> <div class='col'>" +
            "<form id='frmConfig' method='post' action='/ Usuario / Excluir'> <div class='campoTexto'> <input type='text' name='senhaAtual' id='txtSenhaAtual' class='Input-text' placeholder='Senha atual'>" +
            "<label for='input' class='Input-label'>Senha atual</label></div><div class='campoTexto'> <input type='password' name='novaSenha' id='txtNovaSenha' class='Input-text' placeholder='Nova Senha'>" +
            "<label for='input' class='Input-label'>Nova Senha</label ></div><input class='btn' type= 'submit' name= 'btnSubmitAlteraSenha' id= 'btnSubmitAlteraSenha' value= 'Alterar Senha'></form ></div></div>";
        document.getElementById("pagina").innerHTML += txt;
    });

    $("#btnAlteraImagem").click(() => {
        var txt = "<div id='fundoPreto'></div> </div > <div id='areaConfiguracoes' class='row container'> <div class='col'>" +
            "<form id='frmConfig' method='post' action='/ Usuario / Excluir'><div> <label for='txtImg' class='fileContainer'> <input type='file' name='txtImg' id='txtImg' aria-label='asa'> </label> </div>" +
            "<div class='campoTexto'> <input type='password' name='senha' id='txtSenha' class='Input-text' placeholder='Senha'>" +
            "<label for='input' class='Input-label'> Senha </label ></div><input class='btn' type= 'submit' name= 'btnSubmitAlteraImagem' id= 'btnSubmitAlteraImagem' value= 'Alterar Imagem'></form ></div></div>";
        document.getElementById("pagina").innerHTML += txt;
    });

    $("#btnExcluir").click(() => {
        var txt = "<div id='fundoPreto'></div> </div > <div id='areaConfiguracoes' class='row container excluir'> <div class='col col-2'>" +
            "<form id='frmConfig' method='post' action='/ Usuario / Excluir'> <div class='campoTexto'> <input type='text' name='3' id='txtNomeUsuario' class='Input-text' placeholder='Novo nome de usuário'>" +
            "<label for='input' class='Input-label'>Novo nome de usuário</label></div><div class='campoTexto'> <input type='password' name='senha' id='txtSenha' class='Input-text' placeholder='Senha'>" +
            "<label for='input' class='Input-label'> Senha </label ></div><input class='btn' type= 'submit' name= 'btnSubmitExcluir' id= 'btnSubmitExcluir' value= 'Excluir'></form ></div></div>";
        document.getElementById("pagina").innerHTML += txt;
    });
})