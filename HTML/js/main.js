$(document).ready(function()
{
    $(".menu-icon").click(function(){
        $(".menu-icon").toggleClass("change");
        $("#menu nav").toggleClass("active");
    })
})