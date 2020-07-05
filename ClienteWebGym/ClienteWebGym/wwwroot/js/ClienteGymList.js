
$(document).ready(function () {
    $.ajax({
        url: "ObtenerUsuarios", // Url
        type: "get"
    }).done(function (result) {
        if (result != null) {
            cargarPagina(result);
        }
    })
});


$(document).on('click','.btnAcceder', function () {
    alert($(this).attr('id'));

});


function cargarPagina(resultados) {
    console.log(JSON.stringify(resultados.data));

    let array = JSON.parse(resultados.data);
    for (let i = 0; i < array.length; i++) {
        let ruta =array[i].centro_logo_ruta;
        $("#contenedor").append(
            '<div class="col-sm-6 col-md-4 col-lg-4 py-2">' +

            '<div class="card card-body h-100">' +

            '<img src="' + ruta + '" />' +

            '<h4 class="card-title">' + array[i].centro_nombre + '</h4>' +

            '<h6 class="card-subtitle mb-2 text-muted">' + array[i].centro_ubicacion+'</h6 > ' +

            '<button class="btn btn-danger mt-1 btnAcceder" id="'+array[i].centro_id+'"> Acceder </button>' +

            '</div>' +

            '</div>'
        );
    }

}