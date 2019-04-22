$(document).ready(() => {
    $("#txtLoginEmail").on("blur",() => {
        checarEmail();
    });
});

function checarEmail() {
    var url = $("#txtLoginEmail").data('request-url');
    $.post(url, {
        emailDigitado: $("#txtLoginEmail").val()
    },
        function (data) {
            if (data == 0) {
                $("#lbCadastroEmail").addClass("disponivel");
            }
            else
                alert("email indisponivel");
        });
}