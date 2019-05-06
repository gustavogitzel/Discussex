var menuClose;
$(document).ready(() => {
    menuClose = true;
    fecharMenuClick();
    gerenciarMenu();
    alterarLogo();

    $('select').each(function () {
        var $this = $(this), numberOfOptions = $(this).children('option').length;

        $this.addClass('select-hidden');
        $this.wrap('<div class="select"></div>');
        $this.after('<div class="select-styled"></div>');

        var $styledSelect = $this.next('div.select-styled');
        $styledSelect.text($this.children('option').eq(0).text());

        var $list = $('<ul />', {
            'class': 'select-options'
        }).insertAfter($styledSelect);

        for (var i = 0; i < numberOfOptions; i++) {
            $('<li />', {
                text: $this.children('option').eq(i).text(),
                rel: $this.children('option').eq(i).val()
            }).appendTo($list);
            if (i == numberOfOptions - 1)
                $this.children('option').addClass("ultimoDaLista");
        }

        var $listItems = $list.children('li');

        $styledSelect.click(function (e) {
            e.stopPropagation();
            $('div.select-styled.active').not(this).each(function () {
                $(this).removeClass('active').next('ul.select-options').hide();
            });
            $(this).toggleClass('active').next('ul.select-options').toggle();
        });

        $listItems.click(function (e) {
            e.stopPropagation();
            $styledSelect.text($(this).text()).removeClass('active');
            $this.val($(this).attr('rel'));
            $list.hide();
            //console.log($this.val());
        });

        $(document).click(function () {
            $styledSelect.removeClass('active');
            $list.hide();
        });

    });
})

function gerenciarMenu() {
    $(".menu-icon").click(() => {
        $(".menu-icon").toggleClass("change");
        alterarMenu(menuClose);
        menuClose = !menuClose;
    })
}

function fecharMenuClick() {
    $("#corpo").click(() => {
        if (!menuClose)
            $(".menu-icon").click();
    });
}

function alterarMenu(situacao) {
    if (!situacao)
    {
        $("#menu nav").slideUp();
    }
    else
    {
        $("#menu nav").slideDown();
    } 
}

function alterarLogo() {
    $("#menu").mouseover(() => {
        $("#logo").attr("src", "/img/LogoDark.png");
    });
    $("#menu").mouseout(() => {
        $("#logo").attr("src", "/img/Logo.png");
    });
}