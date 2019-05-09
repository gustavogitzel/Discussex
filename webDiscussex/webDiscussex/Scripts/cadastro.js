var inputs = { "Email": false, "Nome de Usuário": false, "Senha": false };

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
        if (checarTodos() == false) {
            alert("não vou dar submit");
            e.preventDefault();
        }
    });
});

function checarTodos()
{
    for (var input in inputs)
        if (inputs[input] == false)
            return false;

    return true;
}

function checar($obj) {
    if ($obj.val() == "") {
        $obj.removeClass("disponivel");
        $obj.removeClass("indisponivel");
        $obj.text($obj.attr("defaultValue"));
        inputs[$obj.attr("defaultValue")] = false;
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
                    inputs[$obj.attr("defaultValue")] = true;
                }
                else {
                    if ($obj.attr("defaultValue") == "Senha")
                        $obj.siblings().text($obj.attr("defaultValue") + " inválida - 8 dígitos no mínimo");
                    else
                        $obj.siblings().text($obj.attr("defaultValue") + " inválido");
                    $obj.removeClass("disponivel");
                    $obj.addClass("indisponivel");

                    inputs[$obj.attr("defaultValue")] = false;
                }
            });

    }
}
