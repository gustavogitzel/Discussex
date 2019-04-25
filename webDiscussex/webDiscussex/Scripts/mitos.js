$(document).ready(() => {
    $(".verdade").click(() => {
        exibirResposta();
    });

    $(".mito").click(() => {
        exibirResposta();
    });
});

function exibirResposta() {
    $(this).parentsUntil("section").siblings().slideDown();
}