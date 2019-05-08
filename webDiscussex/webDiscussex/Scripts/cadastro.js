$(document).ready(() => {
    $("#txtCadastroEmail").on("blur",() => {
        checar($("#txtCadastroEmail"));
    });
    $("#txtCadastroNome").on("blur", () => {
        checar($("#txtCadastroNome"));
    });
    $("#txtCadastroSenha").on("blur", () => {
        checar($("#txtCadastroSenha"));
    });

    $("#frmCadastro").submit((e) => {
        checarTodos();
        e.preventDefault();
    });
});

function checarTodos()
{
    var a = checar($("#txtCadastroEmail"));
    if (a == true)
        alert("true");
}

function checar($obj) {
    var result;
    if ($obj.val() == "") {
        $obj.removeClass("disponivel");
        $obj.removeClass("indisponivel");
        $obj.text($obj.attr("defaultValue"));
        result = false;
    }
    else {
        var url = $obj.data('request-url');
        $.post(url, {
            digitado: $obj.val()
        },
            function (data) {
                if (data) {
                    $obj.addClass("disponivel");
                    $obj.removeClass("indisponivel");
                    result= true;
                }
                else {
                    if ($obj.attr("defaultValue") == "Senha")
                        $obj.siblings().text($obj.attr("defaultValue") + " inválida - 8 dígitos no mínimo");
                    else
                        $obj.siblings().text($obj.attr("defaultValue") + " inválido");
                    $obj.removeClass("disponivel");
                    $obj.addClass("indisponivel");

                    result =  false;
                }
            });


    }

    return result;
}