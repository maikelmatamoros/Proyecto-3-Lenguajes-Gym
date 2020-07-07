$(document).ready(function () {
    $.ajax({
        url: "ObtenerOcupacion", // Url
        data: {
            "fecha": "2020-7-6"
        },
        type: "get"
    }).done(function (result) {
        if (result != null) {
            console.log(result);
        }
    })
});