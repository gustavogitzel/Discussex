$(document).ready(() => {
    $('.verdade').click(function () {
        var $elementoPai = $(this).parent();

        var $elementoAvo = $elementoPai.parent();

        var $elemento = $elementoAvo.find('[name = "aparecer"]');

        $elemento.slideDown();
    });

    $(".mito").click(function() {
        var $elementoPai = $(this).parent();

        var $elementoAvo = $elementoPai.parent();

        var $elemento = $elementoAvo.find('[name = "aparecer"]');

        $elemento.slideDown();
    });
});