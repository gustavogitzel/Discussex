$(document).ready(function()
{
    var menuClose = true;
    $(".menu-icon").click(function(){
        $(".menu-icon").toggleClass("change");

        if(menuClose)
            $("#menu nav").animate({
                left:"0"
            },300, function(){
                var fundo = $("div");
                fundo.id = "fundoPretoMenu";
                $("body").after(fundo).css({
                    "width": "100%",
                    "height": "100%",
                    "position": "absolute",
                    "top": "0",
                    "margin-top":"2em",
                    "transition":"none",
                    "background": "rgba(26,26,26)"
                });
            });
        else
        $("#menu nav").animate({
            left: "-30em"
        },300, function(){
            $("#fundoPretoMenu").remove();
        });

        menuClose = !menuClose;
    })
    $("#menu").mouseover(function(){
        // $("#logo").attr("src","img/logoDark.png");
    })
    $("#menu").mouseout(function(){
        $("#logo").attr("src","img/logo.png");
    })
})