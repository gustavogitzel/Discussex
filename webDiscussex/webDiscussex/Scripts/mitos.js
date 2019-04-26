$(document).ready(() => {
    $('.verdade').click(function () {
        var $elementoPai = $(this).parent();        //div

        var $elementoAvo = $elementoPai.parent();

        var $elemento = $elementoAvo.find('[name = "aparecer"]');
        
        if ($elemento.find("h1").html() == "Mentira")
            $elementoAvo.css("background", "red");
        else
            $elementoAvo.css("background", "green");

        $(this).attr("disabled", "true").addClass("desligado").siblings("button").attr("disabled", "true").addClass("desligado");

        $elemento.slideDown();
    });

    $(".mito").click(function() {
        var $elementoPai = $(this).parent();

        var $elementoAvo = $elementoPai.parent();

        var $elemento = $elementoAvo.find('[name = "aparecer"]');

        if ($elemento.find("h1").html() == "Mentira")
            $elementoAvo.css("background", "red");
        else 
            $elementoAvo.css("background", "green");


        $(this).attr("disabled", "true").addClass("desligado").siblings("button").attr("disabled", "true").addClass("desligado");


        $elemento.slideDown("slow");
    });
});