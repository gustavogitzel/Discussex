$(document).ready(function()
{
    var menuClose = true;
    
        $("#corpo").click(()=>{
            if(!menuClose)
                $(".menu-icon").click();
        });
    
    $(".menu-icon").click(function(){
        $(".menu-icon").toggleClass("change");
        alterarMenu(menuClose);
        menuClose = !menuClose;
        var div; 
        
        if(menuClose)
        {
            $("#pagina").css("overflow-y", "initial");
            document.getElementById("corpo").removeChild(div);
        }
        if(menuClose == false)
        {
            div = document.createElement("div");
            div.id = "fundoMenuPreto";
            $("#pagina").css("overflow-y", "hidden");
            
            document.getElementById("corpo").appendChild(div);
        }
            
    })
    $("#menu").mouseover(function(){
        $("#logo").attr("src","img/logoDark.png");
    })
    $("#menu").mouseout(function(){
        $("#logo").attr("src","img/logo.png");
    })
})

function alterarMenu(estaFechado)
{
    if(estaFechado)   
        $("#menu nav").animate({left:"0"},300);
    else
        $("#menu nav").animate({left: "-30em"},300);
}