$(document).ready(function () {
    const dataTable = $("#hazardous-asteroids-datatable").DataTable({
        serverSide: true,
        paging: true,
        searching: false,
        ordering: false,
        processing: true,
        deferLoading: 0,
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

    $("#search-button").on("click", function () {
        $("#planet-error-message").text("");
        $("#days-error-message").text("");

        if (!$("#planet").val()) {
            $("#planet-error-message").text("Indica un planeta para realizar la búsqueda");
            return;
        }

        let startDate = $("#from-date").val();
        let endDate = $("#to-date").val();

        if (startDate && endDate) {
            let momentStartDate = moment(startDate);
            let momentEndDate = moment(endDate);
            let daysOfDifference = momentEndDate.diff(momentStartDate, 'days');

            if (daysOfDifference > 7) {
                $("#days-error-message").text("Elige menos de 7 días")
                return;
            }

            if (daysOfDifference < 0) {
                $("#days-error-message").text("La fecha de finalización no puede ser menor que la de inicio")
                return;
            }
        }

        dataTable.ajax.reload();
        dataTable.draw();
    });
});