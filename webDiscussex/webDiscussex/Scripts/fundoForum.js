$(document).ready(() => {
    var qtd = $("#corpo").attr("data-qtdLinhas");
    if (qtd % 2 != 0)
        $("body").css("background", "#2196f3");
    else
        $("body").css("background", "#64b5f6");
});