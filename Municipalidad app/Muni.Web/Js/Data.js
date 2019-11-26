﻿function unidades() {
    var table = $("#example").DataTable({
        select: true,
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            async: false,
            url: "MantenedorUnidades.aspx/CargarDataTable",
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
            { "data": "IdUnidad" },
            { "data": "Nombre" },
        ]
    })

}

function verifPermiso() {

    var table = $("#example").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            async: false,
            url: "AutorizarPermiso.aspx/CargarDataTable",
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
            { "data": "TipoUsuarioStr" },
            { "data": "EstadoStr" }
        ]
    });
}

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
            { "data": "TipoUsuarioStr" },
            { "data": "EstadoStr" }
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
            { "data": "Observaciones" },
            { "data": "CantidadDias" },
            { "data": "PendienteStr" },
            { "data": "IdSolicitud" },
            { "data": "CodVerificacion" }
        ]
    });
}