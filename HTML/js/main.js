$(document).ready(function()
{
    var menuClose = true;
    $(".menu-icon").click(function(){
        $(".menu-icon").toggleClass("change");

        
        if(menuClose)
        {
            $("#menu nav").animate({
                left:"0"
            },300, function(){});
            var fundoPreto = "<div id='fundoMenuPreto'></div>";
            document.getElementById("pagina").innerHTML += fundoPreto;
        }
        else
        $("#menu nav").animate({
            left: "-30em"
        },300, function(){
            $("#fundoPretoMenu").remove();
        });

        menuClose = !menuClose;
    })
    $("#menu").mouseover(function(){
        $("#logo").attr("src","img/logoDark.png");
    })
    $("#menu").mouseout(function(){
        $("#logo").attr("src","img/logo.png");
    })
})