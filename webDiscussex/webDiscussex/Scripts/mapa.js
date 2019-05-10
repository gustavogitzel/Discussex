var servico;
var direcao;

function iniciarMapa() {
    var map = new google.maps.Map(document.getElementById('map'), {
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


function Rota() {
    direcao.addListener('direcoes', function () {
        calcularDistancia(direcao.getDirections());
    });

    var localizacaoUsuario = document.getElementById("txtCep").value;
    var modo = document.getElementById("mode").value;

    exibirLocalizao(localizacaoUsuario);

    exibirRota(localizacaoUsuario, 'Saúde, Campinas', modo, servico, direcao);
}

function exibirRota(origem, destino, modo, service, exibicao) {
    service.route({
        origin: origem,
        destination: destino,
        travelMode: modo,
        avoidTolls: true
    }, function (response, status) {
        if (status === 'OK') {
            exibicao.setDirections(response);
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