var data;
var array;

$(document).ready(() => {
    $("#conferirRespostas").click(() => {
        data = $("#conferirRespostas").data("respostas");
        array = data.split(" ");
        exibirPontuacao();
        conferirRespostas();
    });
});

function exibirPontuacao() {

    var pontos = 0;

    for (var i = 0; i < array.length -1; i++) {
        var certo = $("#sel" + array[i].substring(5, 6) + "_" + i).is(':checked');
        if (certo)
            pontos++;
    }

    var txt =
        "<div id='fundoPreto'></div><div id='areaPontuacao' class='row container pontuacao'><div class='col col-2' id='imgPontos'>" +
        "<img src='/img/guaxinimFeliz.png'></div> <div class='col col-2' ><div id='divPontuacao'> Sua pontuação foi de " + pontos + "</div> <button class='btn concluir' name= 'btnPontuacao' id= 'btnPontuacao' " +
        "value='Pontuação'>OK</button></div>";

    $("#pagina").append(txt);

    $(window).scrollTop(0);

    fundoPreto();

    botao();

}

function conferirRespostas() {
    for (var i = 0; i < array.length; i++)
        $("#" + array[i] + "_" + i).css("color", "green");
}

function fundoPreto() {
    $("#fundoPreto").click(() => {
        $("#fundoPreto").remove();
        $("#areaPontuacao").remove();
    });
}

function botao() {
    $("#btnPontuacao").click(() => {
        $("#fundoPreto").remove();
        $("#areaPontuacao").remove();
    });
 }