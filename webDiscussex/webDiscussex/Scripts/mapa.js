var servico;
var direcao;
var localizacaoUsuario;

var marcadorCasa;


$(document).ready(() => {
    $("#pesquisarCasa").click(() => {
        localUsuario();
    });

    $("#pesquisarPosto").click(() => {
        rota();
    });
})

function iniciarMapa() {
    var mapa = new google.maps.Map(document.getElementById('map'), {
        zoom: 3.5,
        center: { lat: -15.7801, lng: -47.9292 }
    });

    servico = new google.maps.DirectionsService;
    direcao = new google.maps.DirectionsRenderer({
        draggable: true,
        map: map,
        panel: document.getElementById('rota')
    });
}

function localUsuario() {
    localizacaoUsuario = document.getElementById("txtCep").value;
    exibirLocalizacao(localizacaoUsuario);
}

function rota() {
    direcao.addListener('direcoes', function () {
        calcularDistancia(direcao.getDirections());
    });

    exibirRota(localizacaoUsuario, 'Saúde, Campinas', modo, servico, direcao);
}


function exibirLocalizacao(cep) {
    $.ajax({
        type: "GET",
        url: "https://maps.googleapis.com/maps/api/geocode/xml?address=" + cep + "&key=AIzaSyBBh6JK23HFsrPff9iyGpdfzztePcfRhq4",
        dataType: "xml",
        success: function (xml) {
            $(xml).find('result').each(function () {
                var endereco = $(this).find('formatted_address').text();
                var lat = $(this).find('location').find('lat').text();
                var long = $(this).find('location').find('lng').text();

                var minhaLatlng = new google.maps.LatLng(lat, long);

                var mapOptions = {
                    zoom: 16,
                    center: minhaLatlng
                }
                var mapas = new google.maps.Map(document.getElementById("map"), mapOptions);

                //var imagem = "~/imagensGoogle/markerCasa.png"
                marcadorCasa = new google.maps.Marker({
                    position: minhaLatlng,
                    title: 'Casa',
                    animation: google.maps.Animation.DROP,
                    //icone: imagem
                });
                marcadorCasa.addListener('click', toggleBounce);
                marcadorCasa.setMap(mapas);
            });
        },
        error: function () {
            alert("Ocorreu um erro inesperado durante o processamento.");
        }
    });
}

function toggleBounce() {
    if (marcadorCasa.getAnimation() !== null) {
        marcadorCasa.setAnimation(null);
    } else {
        marcadorCasa.setAnimation(google.maps.Animation.BOUNCE);
    }
}

function exibirRota(origem, destino, modo, service, exibicao) {
    service.route({
        origin: origem,
        destination: destino,
        travelMode: modo,
        avoidTolls: true
    }, function (response, status) {
        if (status === 'OK') {
            exibicao.setDirectionss(response);
        } else {
            alert('Não podemos exibir a rota, pois:  ' + status);
        }
    });
}

function calcularDistancia(resultado) {
    var total = 0;
    var minhaRota = v.routes[0];
    for (var i = 0; i < minhaRota.legs.length; i++) {
        total += minhaRota.legs[i].distance.value;
    }
    total = total / 1000;
    document.getElementById('total').innerHTML = total + ' km';
}