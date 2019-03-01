$(document).ready(function () {
    $(".menu-toggle").click(function () {
        $(".menu-toggle").toggleClass("change");
        $("nav").toggleClass("active");
    });
});