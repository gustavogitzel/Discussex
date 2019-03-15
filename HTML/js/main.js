$(document).ready(function () {
    var menuClose = true;

    $("#corpo").click(() => {
        if (!menuClose)
            $(".menu-icon").click();
    });

    $(".menu-icon").click(function () {
        $(".menu-icon").toggleClass("change");

        alterarMenu(menuClose);
        menuClose = !menuClose;



    })
    $("#menu").mouseover(function () {
        $("#logo").attr("src", "img/logoDark.png");
    })
    $("#menu").mouseout(function () {
        $("#logo").attr("src", "img/logo.png");
    })
})

function alterarMenu(situacao) {
    if (!situacao)
        $("#menu nav").slideUp();
    else
        $("#menu nav").slideDown();
}