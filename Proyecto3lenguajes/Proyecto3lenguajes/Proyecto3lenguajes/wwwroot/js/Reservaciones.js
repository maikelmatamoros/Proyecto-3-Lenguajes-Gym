let fecha1;
let fecha2;

$(document).ready(function () {
    $("#ReservacionesTable").DataTable();
    $('#date').daterangepicker({
        "startDate": "07/04/2020",
        "endDate": "07/10/2020"
    }, function (start, end, label) {
        fecha1 = start.format('YYYY-MM-DD');
        fecha2 = end.format('YYYY-MM-DD');
        console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') );
    });
});


$(document).on("click", "#Consultar", function () {

    consultarReservaciones();
});

function consultarReservaciones() {

    $("#ReservacionesTable").DataTable({
        "destroy": true,
        "responsive": true,
        "ajax": {
            "method": "Get",
            "url": "ObtenerReservaciones",
            "data": { "fecha1": fecha1, "fecha2": fecha2 },
            "datatype": "json",
        }, "dataSrc": "data",
        columns: [
            { "data": 'centro_nombre', "className": "text-center" },
            { "data": "control_hora_bloque", "className": "text-center" },
            { "data": "control_hora_dia", "className": "text-center" }
        ]

    });

};
