

//function test() {
//    var xx;
//    var arrSolicitud = $.ajax({
//        method: "POST",
//        async: false,
//        url: "MostrarSolicitud.aspx/CargarDataTable",
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (d) {
//            console.log(d);
//            arr = d.d.data;
//            xx = d;
//            return arr;
//        }
//    });

//    console.log(arr);

//    var table = $("#example").DataTable({
//        destroy: true,
//        responsive: true,

//        var arr = Array.from(xx.d.data);

//        arr.forEach(function (item, idx) {
//            var date = fnc(item.FechaInicio);
//            var jsDate = new Date(date);
//            console.log(jsDate);
//        });

//        function fnc (date) {
//            const re = /-?\d+/;
//            const m = re.exec(date);
//            return m[0];
//        }

//        var response = arrSolicitud.done(function (info) {
//            console.log(info);
//            return info;
//        });
//        var x = response.responseText;

//        console.log(x);
//    }
//}



function dtUsers() {

    var table = $("#example").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            async: false,
            url: "MostrarSolicitud.aspx/CargarDataTable",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                console.log(d);
                var arr = JSON.stringify(d);
                console.log(arr);
                return arr;
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "IdSolicitud" },
            { "data": "FechaInicioStr" },
            { "data": "FechaFinStr" },
            { "data": "Rut" },
            { "data": "TipoUsuarioStr" }
        ]
    });
}


function tablep() {

    var table = $("#table").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            async: false,
            url: "MostrarPermisos.aspx/CargarDataTable",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                console.log(d);
                var arr = JSON.stringify(d);
                console.log(arr);
                return arr;
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "IdPermiso" },
            { "data": "EstadoStr" },
            { "data": "Observaciones" },
            { "data": "CantidadDias" },
            { "data": "PendienteDesplegar" },
            { "data": "CodVerificacion" }

        ]
    });
}


