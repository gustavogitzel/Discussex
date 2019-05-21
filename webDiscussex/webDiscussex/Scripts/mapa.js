var servico;
var direcao;
var endereco;
var latLngUser;
var latLngRef;
var mapas;
var enderecoRef;

$(document).ready(() => {
    $("#pesquisarCasa").click(() => {
        localUsuario();
    });

    $("#pesquisarPosto").click(() => {
        acharPostos();
    });

    $("#buscarCaminho").click(() => {
        buscarCaminho();
    });
})

function iniciarMapa() {
    var mapa = new google.maps.Map(document.getElementById("map"), {
        zoom: 3.5,
        center: { lat: -15.7801, lng: -47.9292 },
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    infoWindow = new google.maps.InfoWindow();

    google.maps.event.addListener(mapa, 'click', function () {
        infoWindow.close();
    });
}

function localUsuario() {
    localizacaoUsuario = $("#txtCep").val();
    exibirLocalizacao(localizacaoUsuario);
}

function exibirLocalizacao(cep) {
    $.ajax({
        type: "GET",
        url: "https://maps.googleapis.com/maps/api/geocode/xml?address=" + cep + "&key=AIzaSyBBh6JK23HFsrPff9iyGpdfzztePcfRhq4",
        dataType: "xml",
        success: function (xml) {
            servico = new google.maps.DirectionsService;

            $('#rota').html('');

            $("#distancia").css("display", "none");

            direcao = new google.maps.DirectionsRenderer({
                draggable: true,
                map: map,
                panel: document.getElementById('rota'),
                suppressMarkers: true
            });

            $(xml).find('result').each(function () {
                endereco = $(this).find('formatted_address').text();
                var lat = $(this).find('location').find('lat').text();
                var long = $(this).find('location').find('lng').text();

                latLngUser = new google.maps.LatLng(lat, long);

                var mapOptions = {
                    zoom: 16,
                    center: latLngUser
                }

                mapas = new google.maps.Map(document.getElementById("map"), mapOptions);

                direcao.setMap(mapas);

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
        url: "http://localhost:61322/api/maps/" + endereco
    }).done(function (data) {
        var json = JSON.parse(data);
        var result = json['results'];

        enderecoRef = result[0].formatted_address;

        var lat = result[0].geometry.location.lat;
        var lng = result[0].geometry.location.lng;

        latLngRef = new google.maps.LatLng(lat, lng);

        var marcadores = [];

        for (var i = 0; i < 5 && i < result.length; i++) {
            marcadores[i] = {
                lat: result[i].geometry.location.lat,
                lng: result[i].geometry.location.lng,
                nome: result[i].name
            }
        }
        mapas.setZoom(14);

        adicionarMarcador(marcadores);
    }).fail(function (erro) {
        alert(erro);
    });
}

function adicionarMarcador(markers) {
    var image = '../img/markerPosto.png'

    for (var i = 0; i < markers.length; i++) {

        var minhaLatlng = new google.maps.LatLng(markers[i].lat, markers[i].lng);

        var marcadorPosto = new google.maps.Marker({
            position: minhaLatlng,
            title: 'Camisinha aqui',
            icon: image,
            map: mapas
        });


        google.maps.event.addListener(marcadorPosto, 'click', (function (marker, nome) {
            return function () {
                var iwContent = '<div id="iw_container">' +
                    '<div class="iw_title">' + nome + '</div>';

                infoWindow.setContent(iwContent);

                infoWindow.open(mapas, marker);
            }
        })(marcadorPosto, markers[i].nome));
    }
}


function buscarCaminho() {
    direcao.addListener('direcoes', function () {
        calcularDistancia(direcao.getDirections());
    });

    modo = document.getElementById('mode').value;

    $("#distancia").css("display", "block");

    exibirRota(endereco, enderecoRef, modo);
}

function exibirRota(origem, destino, modo) {
    var requisicao = {
        origin: origem,
        destination: destino,
        travelMode: modo,
    };

    servico.route(requisicao, function (response, status) {
        if (status === 'OK') {
            direcao.setDirections(response);
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
    $('#total').html(total + ' km');
}