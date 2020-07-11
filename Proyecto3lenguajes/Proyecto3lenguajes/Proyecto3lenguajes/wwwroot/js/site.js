// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//$(document).ready(function () {
//);
   

//});
$(document).ready(function () {

    listarDatelles();
});
let idAdm;
$("#LoginA").submit(function (e) {
    alert("hello")
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: 'InsertarGym',
        data: new FormData(this),
        contentType: false,
        cache: false,
        processData: false,

    }).done(function (data) {
        window.location ="loginAdm"
       

    })
        ;

});
$("#LoginAdm").submit(function (e) {
    alert("hello")
    e.preventDefault();
    window.location = "PaginaPricipal"
    //$.ajax({
    //    type: "POST",
    //    url: 'InsertarGym',
    //    data: new FormData(this),
    //    contentType: false,
    //    cache: false,
    //    processData: false,

   // }).done(function (data) {
        //window.location = "loginAdm"


 //   })
       // ;

});
function listarDatelles() {
    let id = 1;
    $.ajax({
        type: "GET",
        url: 'obtenerDetalles',
        dataType: "JSON",
        data: {
            "id": id
        }

    }).done(function (data) {
        alert(JSON.stringify(data.data))
        let datos = JSON.parse(data.data);
        
        $("#descripcion").html(datos.descripcion);
        $("#ubicacion").html(datos.ubicacion);
        $("#telefono").html(datos.telefono);
        $("#correo").html(datos.correo);
        $("#capacidad").html(datos.capacidad);
        $("#porcentaje").html(datos.porcentaje);
        $("#horaI").html(datos.horaI);
        $("#horaC").html(datos.horaC);

       

    })
        ;

}
;
//alert(JSON.stringify(result.data));
//let datos = JSON.parse(result.data);
//alert(JSON.stringify(datos));
//$("#nombre").html("Nombre: " + datos.Nombre);
//$("#descripcion").html("Descripcion: " + datos.Descripcion);
//$("#ubicacion").html("Ubicacion: " + datos.Ubicacion);
//$("#logo").append(
//    '<img src="' + datos.Logo + '" style="height:40vh"/>'
//)
