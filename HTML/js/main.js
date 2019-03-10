$(document).ready(function()
{
    $(".menu-icon").click(function(){
        $(".menu-icon").toggleClass("change");
        $("#menu nav").toggleClass("active");
    })
    $("#menu").mouseover(function(){
        $("#logo").attr("src","img/logoDark.png");
    })
    $("#menu").mouseout(function(){
        $("#logo").attr("src","img/logo.png");
    })
})