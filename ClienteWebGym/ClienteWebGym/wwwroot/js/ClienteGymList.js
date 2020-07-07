
let nombre;
let logo;



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


$(document).on('click', '.btnAcceder', function () {
    let index;
    for (let i = 0; i < array.length; i++) {
        if (array[i].centro_id == $(this).attr('id')) {
            index = i;
            break;
        }
        
    }
    //alert(array[index].centro_nombre + " " + array[index].centro_logo_ruta);
    $.ajax({
        url: "LoginToCenter", // Url
        data: {
            "Center": $(this).attr('id'),
            "Logo": array[index].centro_logo_ruta,
            "Nombre": array[index].centro_nombre
        },
        type: "post"
    }).done(function (result) {
        alert(result);
        if (result != null) {
             window.location = "LoginView";
        }
    })

});

let array;
function cargarPagina(resultados) {

    array = JSON.parse(resultados.data);
    for (let i = 0; i < array.length; i++) {
        let ruta =array[i].centro_logo_ruta;
        $("#contenedor").append(
            '<div class="col-sm-6 col-md-4 col-lg-4 py-2" >' +

            '<div class="card card-body h-30" style="background-color: green !important;opacity:0.3">' +
            
            '<img src="' + ruta + '" style="height:40vh"/>' +

            '<h4 class="card-title">' + array[i].centro_nombre + '</h4>' +

            '<h6 class="card-subtitle mb-2 text-muted">' + array[i].centro_ubicacion+'</h6 > ' +

            '<button class="btn btn-danger mt-1 btnAcceder" id="'+array[i].centro_id+'"> Acceder </button>' +

            '</div>' +

            '</div>'
        );
    }

}