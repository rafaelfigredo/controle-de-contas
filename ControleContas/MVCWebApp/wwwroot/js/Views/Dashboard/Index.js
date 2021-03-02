$(document).ready(function () {
    getDataChartCategorias(urlChartCategorias);
    getDataChartContas(urlChartContas);
});

function getDataChartContas(url) {
    $.ajax({
        type: "GET",
        url: url
    }).done(function (obj) {
        renderDoughnutChart('#chartContas', obj.contas, obj.cores, obj.valores);
        $('#tituloChartContas').text('Contas - ' + obj.descricao);
    }).fail(function (jqXHR, textStatus, msg) {
        alert('Ocorreu um erro!');
    });
}

function getDataChartCategorias(url) {
    $.ajax({
        type: "GET",
        url: url
    }).done(function (obj) {
        renderDoughnutChart('#chartCategorias', obj.categorias, obj.cores, obj.valores);
        $('#tituloChartCategorias').text('Categorias - ' + obj.descricao);
    }).fail(function (jqXHR, textStatus, msg) {
        alert('Ocorreu um erro!');
    });
}

function getArrayColors(cores) {
    var backgroundColor = [];
    var borderColor = [];

    $(cores).each(function (index) {
        var hex = cores[index];
        var rgbColor = hexToRgb(hex);

        var color = returnRGBColor(rgbColor.r, rgbColor.g, rgbColor.b, 0.75);
        backgroundColor.push(color);

        var border = returnRGBColor(rgbColor.r, rgbColor.g, rgbColor.b, 1);
        borderColor.push(border);
    });

    return { backgroundColor: backgroundColor, borderColor: borderColor }
}

function renderDoughnutChart(chartId, labels, cores, data) {
    colors = getArrayColors(cores);
    var ctx = $(chartId);
    var chart = new Chart(ctx, {
        type: 'doughnut',
        data: {
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: colors.backgroundColor,
                borderColor: colors.borderColor,
                borderWidth: 1
            }]
        }
    });
}