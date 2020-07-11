$(document).ready(function () {

    $.ajax({
        url: "ObtenerInfoCentro",
        dataType: "json",
        type: 'POST'
    }).done(function (result) {
        let datos = JSON.parse(result.data);
        $("#nombre").html("Nombre: " + datos.Nombre);
        $("#descripcion").html("Descripcion: " + datos.Descripcion);
        $("#ubicacion").html("Ubicacion: " + datos.Ubicacion);
        $("#logo").append(
            '<img src="' + datos.Logo + '" style="height:40vh"/>'
        )

        for (let i = 0; i < datos.Imagenes.length; i++) {
            
                $("#img").append(
                        '<img class="img-fluid col-sm-6" src="' + datos.Imagenes[i] + '"  width="600" heigth="200" alt="Second slide">'
                    );
        }

    });

    $("#ClasesVirtualesTable").DataTable({
        "destroy": true,
        "responsive": true,
        "ajax": {
            "method": "POST",
            "url": "ObtenerClasesVirtuales",
            "datatype": "json",
        }, "dataSrc": "data",
        columns: [
            { "data": 'id', "visible": false },
            { "data": "nombre", "className": "text-center" },
            { "data": "fecha", "className": "text-center" },
            { "data": "hora", "className": "text-center" },
            { "data": "descripcion", "className": "text-center" },
            {
                "data": "ruta", "className": "text-center",
                "render": function (data) {
                    return '<img src="' + data + '" class="img-fluid rounded mx-auto d-block" width="60" height="20" alt="Responsive image">';
                }
            }
        ]

    });

});