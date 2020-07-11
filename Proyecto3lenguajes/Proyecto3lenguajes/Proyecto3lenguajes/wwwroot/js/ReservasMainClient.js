
let fecha = "NP";

$(document).ready(function () {
    $("#HorariosTable").DataTable({
        "paging": false,
        "ordering": false,
        "info": false,
        "searching": false
    });
    
    $("#date").val(moment());
    $("#date").daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        startDate: moment().format('MM-DD-YYYY') ,
        minYear: 1901,
        maxYear: parseInt(moment().format('YYYY'), 10)
    }, function (start, end, label) {
            fecha = start.format('YYYY-MM-DD');;
    });
});


$(document).on('click', '#Reservar', function () {

    $.ajax({
        data: { "idH": JSON.stringify(idS) },
        url: "Reservar",
        type: 'POST'
    }).done(function (result) {
        alert(result);
        window.location = "ReservacionesView";
    });
});

$(document).on("click", "button.close", function () {

    let elementos = $(this).siblings('Strong');
    let contador = 1;

    $(this).siblings().each(function (idx, el) {
        if (contador == 1) {
            idS.splice(idS.indexOf(el.id), 1);
            contador++;
        }
    });

});

let idS = [];

$(document).on('click', 'button.reservar', function () {
    var table = $("#HorariosTable").DataTable();
    var data = table.row($(this).parents('tr')).data();
    var tr = table.row($(this).parents('tr'));
    alert(data.control_id);
    if (!idS.includes(data.control_id)) {
        idS.push(data.control_id);
        $("#HorariosDiv").append(
            '<div class="alert alert-info alert-dismissible">' +
            '<button type="button" class="close" data-dismiss="alert">&times;</button>' +
            '<strong id="' + data.control_id + '">Fecha: </strong>' + fecha + '<strong"> Horario: </strong>' + data.control_hora_bloque +
            '</div>'
        );
    }
});



function consultarCampos() {

    $("#HorariosTable").DataTable({
        "destroy": true,
        "responsive": true,
        "ajax": {
            "method": "Get",
            "url": "ObtenerOcupacion",
            "data": { "fecha": fecha },
            "datatype": "json",
        }, "dataSrc": "data",
        columns: [
            { "data": 'control_id', "visible": false },
            { "data": "control_hora_bloque", "className": "text-center" },
            { "data": "control_capacidad", "className": "text-center" },
            { "defaultContent": "<button type='button' class='reservar btn btn-info'><i class='fas fa-plus'></i></button>" }
        ]

    });

};


$(document).on("click", "#Consultar", function () {
    consultarCampos();
});
