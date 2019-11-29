function unidades() {
    var table = $("#DataTable").DataTable({
        language: {
            "lengthMenu": "Mostrar _MENU_ registros",
            "zeroRecords": "No se encontraron resultados",
            "info": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "infoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sSearch": "Buscar",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "sProcessing": "Procesando...",
        },
        //para usar los botones   
        responsive: "true",
        dom: 'Bfrtilp',
        buttons: [
            {
                extend: 'excelHtml5',
                text: '<i class="fas fa-file-excel"></i> ',
                titleAttr: 'Exportar a Excel',
                className: 'btn btn-success'
            },
            {
                extend: 'pdfHtml5',
                text: '<i class="fas fa-file-pdf"></i> ',
                titleAttr: 'Exportar a PDF',
                className: 'btn btn-danger'
            },
            {
                extend: 'print',
                text: '<i class="fa fa-print"></i> ',
                titleAttr: 'Imprimir',
                className: 'btn btn-info'
            },
        ],
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            async: false,
            url: "MantenedorUnidades.aspx/CargarDataTable",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                var arr = JSON.stringify(d);
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

function tipoPermiso() {
    var table = $("#DataTable").DataTable({
        language: {
            "lengthMenu": "Mostrar _MENU_ registros",
            "zeroRecords": "No se encontraron resultados",
            "info": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "infoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sSearch": "Buscar",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "sProcessing": "Procesando...",
        },
        //para usar los botones   
        responsive: "true",
        dom: 'Bfrtilp',
        buttons: [
            {
                extend: 'excelHtml5',
                text: '<i class="fas fa-file-excel"></i> ',
                titleAttr: 'Exportar a Excel',
                className: 'btn btn-success'
            },
            {
                extend: 'pdfHtml5',
                text: '<i class="fas fa-file-pdf"></i> ',
                titleAttr: 'Exportar a PDF',
                className: 'btn btn-danger'
            },
            {
                extend: 'print',
                text: '<i class="fa fa-print"></i> ',
                titleAttr: 'Imprimir',
                className: 'btn btn-info'
            },
        ],
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            async: false,
            url: "MantenedorTiposPermiso.aspx/CargarDataTable",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                var arr = JSON.stringify(d);
                return arr;
            },
            dataSrc: "d.data"
        },
        columns: [
            { "data": "IdTipoPermiso" },
            { "data": "Nombre" },
            { "data": "NumeroDias" },
        ]
    })
}


function verifPermiso() {
    var table = $("#DataTable").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            async: false,
            url: "AutorizarPermiso.aspx/CargarDataTable",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                var arr = JSON.stringify(d);
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
    var table = $("#Table").DataTable({
        language: {
            "lengthMenu": "Mostrar _MENU_ registros",
            "zeroRecords": "No se encontraron resultados",
            "info": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "infoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sSearch": "Buscar",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "sProcessing": "Procesando...",
        },
        //para usar los botones   
        responsive: "true",
        dom: 'Bfrtilp',
        buttons: [
            {
                extend: 'excelHtml5',
                text: '<i class="fas fa-file-excel"></i> ',
                titleAttr: 'Exportar a Excel',
                className: 'btn btn-success'
            },
            {
                extend: 'pdfHtml5',
                text: '<i class="fas fa-file-pdf"></i> ',
                titleAttr: 'Exportar a PDF',
                className: 'btn btn-danger'
            },
            {
                extend: 'print',
                text: '<i class="fa fa-print"></i> ',
                titleAttr: 'Imprimir',
                className: 'btn btn-info'
            },
        ],
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            async: false,
            url: "MostrarSolicitud.aspx/CargarDataTable",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                var arr = JSON.stringify(d);
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
    var table = $("#DataTable").DataTable({
        language: {
            "lengthMenu": "Mostrar _MENU_ registros",
            "zeroRecords": "No se encontraron resultados",
            "info": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "infoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sSearch": "Buscar",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "sProcessing": "Procesando...",
        },
        //para usar los botones   
        responsive: "true",
        dom: 'Bfrtilp',
        buttons: [
            {
                extend: 'excelHtml5',
                text: '<i class="fas fa-file-excel"></i> ',
                titleAttr: 'Exportar a Excel',
                className: 'btn btn-success'
            },
            {
                extend: 'pdfHtml5',
                text: '<i class="fas fa-file-pdf"></i> ',
                titleAttr: 'Exportar a PDF',
                className: 'btn btn-danger'
            },
            {
                extend: 'print',
                text: '<i class="fa fa-print"></i> ',
                titleAttr: 'Imprimir',
                className: 'btn btn-info'
            },
        ],
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            async: false,
            url: "MostrarPermisos.aspx/CargarDataTable",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: function (d) {
                var arr = JSON.stringify(d);
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