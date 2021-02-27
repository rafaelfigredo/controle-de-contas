$(document).ready(function () {
    getDataChartCategorias(urlChartCategorias);
});

function getDataChartCategorias(url) {
    $.ajax({
        type: "GET",
        url: url
    }).done(function (obj) {
        renderChart(obj.categorias, obj.valores, obj.descricao);
    }).fail(function (jqXHR, textStatus, msg) {
        alert('Ocorreu um erro!');
    });
}

function getRandomInt(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function getRandomColor(transparencia) {
    var r = getRandomInt(0, 255);
    var g = getRandomInt(0, 255);
    var b = getRandomInt(0, 255);

    var arrayColor = { r: r, g: g, b: b, color: 'rgba(' + r + ',' + g + ',' + b + ',' + transparencia + ')' };
    return arrayColor;
}

function returnRGBColor(r, g, b, transparencia) {
    return 'rgba(' + r + ',' + g + ',' + b + ',' + transparencia + ')';
}

function getArrayColors(data) {
    var backgroundColor = [];
    var borderColor = [];

    $(data).each(function (index) {
        var arrayColor = getRandomColor(0.6);

        var color = arrayColor.color;
        backgroundColor.push(color);
        var border = returnRGBColor(arrayColor.r, arrayColor.g, arrayColor.b, 1);
        borderColor.push(border);
    });

    return { backgroundColor: backgroundColor, borderColor: borderColor }
}

function renderChart(labels, data, titulo) {
    $('#tituloChartCategorias').text('Categorias - ' + titulo);
    colors = getArrayColors(data);
    var ctx = $('#chartCategorias');
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