﻿$(document).ready(() => {
    var ctx = $('#pareto');
    window.myBar = new Chart(ctx, {
        type: 'bar',
        data: data,
        options: options
    });
});

var data = {
    animation: {
        onComplete: function () {
            var ctx = this.chart.ctx;
            ctx.textAlign = "center";
            ctx.textBaseline = "middle";

            this.chart.config.data.datasets.forEach(function (dataset) {
                ctx.font = "20px Arial";
                switch (dataset.type) {
                    case "line":
                        ctx.fillStyle = "Black";
                        dataset.metaData.forEach(function (p) {
                            ctx.fillText(p._chart.config.data.datasets[p._datasetIndex].data[p._index], p._model.x, p._model.y - 20);
                        });
                        break;
                    case "bar":
                        ctx.fillStyle = "White";
                        dataset.metaData.forEach(function (p) {
                            ctx.fillText(p._chart.config.data.datasets[p._datasetIndex].data[p._index], p._model.x, p._model.y + 20);
                        });
                        break;
                }
            });
        }
    },
    labels: ["Erro de Servidor no Aplicativo '/'", "SQL Exception", "Rotas inválidas","Validaçaõ de Formulário"],
    datasets: [{
        type: "line",
        label: "ACUMULADO",
        borderColor: "#ea80fc",
        backgroundColor: "#ea80fc",
        pointBorderWidth: 5,
        fill: false,
        data: [44.23, 73.07, 88.45, 100],
        yAxisID: 'y-axis-2'
    }, {
        type: "bar",
        label: "ASSISTENCIA",
        borderColor: "#4a148c",
        backgroundColor: "#4a148c",
        data: [23, 15, 8, 6],
        yAxisID: 'y-axis-1'
    }]
};

var options = {
    scales: {
        xAxes: [{
            stacked: true,
            ticks: {
                fontColor: "white",
                fontSize: 20
            }
        }],

        yAxes: [{
            type: "linear",
            position: "left",
            id: "y-axis-1",
            stacked: true,
            ticks: {
                suggestedMin: 0,
                fontColor: "white",
                fontSize: 20
            },
            scaleLabel: {
                display: true,
                labelString: "FREQUÊNCIA",
                fontColor: "white",
                fontSize: 20
            }
        }, {
            type: "linear",
            position: "right",
            id: "y-axis-2",
            ticks: {
                suggestedMin: 0,
                callback: function (value) {
                    return value + "%";
                },
                fontColor: "white",
                fontSize: 20
            },
            scaleLabel: {
                display: true,
                labelString: "PORCENTAGEM",
                fontColor: "white",
                fontSize: 20
            }
        }]
    },
    legend: {
        labels: {
            // This more specific font property overrides the global property
            fontColor: 'white',
            fontSize: 20
        }
    }
};