$(document).ready(function () {
    $("#hazardous-asteroids-datatable").DataTable({
        serverSide: true,
        paging: true,
        searching: false,
        ordering: false,
        processing: true,
        language: {
            lengthMenu: "Mostrar _MENU_ registros por página",
            zeroRecords: "No se encontraron registros",
            info: "Mostrando página _PAGE_ of _PAGES_",
            infoEmpty: "No hay información",
            infoFiltered: "(filtrado de _MAX_ registros)",
            paginate: {
                first: "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            },
        },
        ajax: {
            url: "HazardousAsteroids/Datatable",
            type: "POST",
            dataType: 'json',
            data: function (data) {
                return $.extend({}, data, {
                    planet: $("#planet").val(),
                    fromDate: $("#from-date").val(),
                    toDate: $("#to-date").val(),
                });
            }
        },
        columns: [
            { data: 'name' },
            { data: 'diameter' },
            { data: 'speed' },
            { data: 'date' },
        ],
        columnDefs: [
            {
                render: function (data) {
                    return `${Number(data).toFixed(2)} Km`;
                },
                targets: 1,
            },
            {
                render: function (data) {
                    return `${Number(data).toFixed(2)} km/h`;
                },
                targets: 2,
            },
            {
                render: function (data) {
                    return moment(data, 'YYYY-MM-DD').format("DD/MM/YYYY");
                },
                targets: 3,
            }
        ]
    });
});