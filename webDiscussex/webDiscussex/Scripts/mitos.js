$(document).ready(() => {
    $('.verdade').click(function () {
        var $elementoPai = $(this).parent();        //div

        var $elementoAvo = $elementoPai.parent();

        var $elemento = $elementoAvo.find('[name = "aparecer"]');
        var str = $elemento.find("p").text();
        if ($elemento.find("h1").html() == "Mito") {
            $elemento.find("p").text(str.replace("MITO:", ""));
            $elementoAvo.css("background", "#e53935");
        }
        else {
            $elemento.find("p").text(str.replace("VERDADE:", ""));
            $elementoAvo.css("background", "#43a047");
        }

        $(this).attr("disabled", "true").addClass("desligado").siblings("button").attr("disabled", "true").addClass("desligado");

        $elemento.slideDown();
    });

    $(".mito").click(function() {
        var $elementoPai = $(this).parent();

        var $elementoAvo = $elementoPai.parent();

        var $elemento = $elementoAvo.find('[name = "aparecer"]');

        var str = $elemento.find("p").text();
        if ($elemento.find("h1").html() == "Mito") {
            $elemento.find("p").text(str.replace("MITO:", ""));
            $elementoAvo.css("background", "#e53935");
        }
        else {
            $elemento.find("p").text(str.replace("VERDADE:", ""));
            $elementoAvo.css("background", "#43a047");
        }


        $(this).attr("disabled", "true").addClass("desligado").siblings("button").attr("disabled", "true").addClass("desligado");


        $elemento.slideDown("slow");
    });
});