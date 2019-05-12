var servico;
var direcao;
var endereco;
var latLngUser;

$(document).ready(() => {
    $("#pesquisarCasa").click(() => {
        localUsuario();
    });

    $("#pesquisarPosto").click(() => {
        acharPostos();
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

function exibirLocalizacao(cep) {
    $.ajax({
        type: "GET",
        url: "https://maps.googleapis.com/maps/api/geocode/xml?address=" + cep + "&key=AIzaSyBBh6JK23HFsrPff9iyGpdfzztePcfRhq4",
        dataType: "xml",
        success: function (xml) {
            $(xml).find('result').each(function () {
                endereco = $(this).find('formatted_address').text();
                var lat = $(this).find('location').find('lat').text();
                var long = $(this).find('location').find('lng').text();

                latLngUser = new google.maps.LatLng(lat, long);

                var mapOptions = {
                    zoom: 16,
                    center: latLngUser
                }
                var mapas = new google.maps.Map(document.getElementById("map"), mapOptions);

                var image = '../img/markerCasa.png'

                var marcadorCasa = new google.maps.Marker({
                    position: latLngUser,
                    title: 'Casa',
                    icon: image
                });
                marcadorCasa.setMap(mapas);
            });
        },
        error: function () {
            alert("Ocorreu um erro inesperado durante o processamento.");
        }
    });
}

function acharPostos() {
    $.ajax({
        type: "GET",
        url: "https://maps.googleapis.com/maps/api/place/textsearch/xml?query==posto+de+saude+near+" + endereco + "&rankyby=distance&radius=10000&key=AIzaSyBBh6JK23HFsrPff9iyGpdfzztePcfRhq4",
        dataType: "xml",
        success: function (xml) {
            $(xml).find('result').each(function () {
                var nomes = $(this).find('name').text();
            });
        },
        error: function () {
            alert("Ocorreu um erro inesperado durante o processamento.");
        }
    });
}

function adicionarMarcador(latitude, longitude) {
    var minhaLatlng = new google.maps.LatLng(latitude, longitude);

    var mapOptions = {
        zoom: 8,
        center: latLngUser
    }

    var mapas = new google.maps.Map(document.getElementById("map"), mapOptions);

    var image = '../img/markerPosto.png'

    var marcadorPosto = new google.maps.Marker({
        position: minhaLatlng,
        title: 'Camisinha aqui',
        icon: image
    });
    marcadorPosto.setMap(mapas);
}


function rota() {
    direcao.addListener('direcoes', function () {
        calcularDistancia(direcao.getDirections());
    });

    exibirRota(endereco, 'Saúde, Campinas', modo, servico, direcao);
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