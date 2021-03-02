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

function hexToRgb(hex) {
    // Expand shorthand form (e.g. "03F") to full form (e.g. "0033FF")
    var shorthandRegex = /^#?([a-f\d])([a-f\d])([a-f\d])$/i;
    hex = hex.replace(shorthandRegex, function (m, r, g, b) {
        return r + r + g + g + b + b;
    });

    var result = /^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(hex);
    return result ? {
        r: parseInt(result[1], 16),
        g: parseInt(result[2], 16),
        b: parseInt(result[3], 16)
    } : null;
}