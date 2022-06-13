$(document).ready(function () {
     $("#hazardous-asteroids-datatable").DataTable({
        serverSide: true,
        paging: true,
        searching: false,
        ordering: false,
        processing: true,
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
        ]
    });
});

