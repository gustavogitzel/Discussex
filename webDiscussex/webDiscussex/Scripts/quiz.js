$(document).ready(() => {
    $("#conferirRespostas").click(() => {
        conferirRespostas();
    });
});

function conferirRespostas() {
    var data = $("#conferirRespostas").data("respostas");
    for (var i = 0; i < data.Count; i++) {
        $("#" + data[i] + "_" + i).css("color", "green");
    }
}