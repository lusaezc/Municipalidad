﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MostrarSolicitud.aspx.cs" Inherits="Muni.Web.MostrarSolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>
    <script>  function verificacion(valido) {
            if (valido) {
                Swal.fire({
                    type: 'success',
                    title: 'Wouh...',
                    text: 'El documento es autentico',
                })
            } else {
                Swal.fire({
                    type: 'error',
                    title: 'Oops...',
                    text: 'El documento no es autentico',
                })
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="shortcut icon" href="#" />

    <!-- Bootstrap CSS -->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- CSS personalizado -->
    <link href="DataTable/main/main.css" rel="stylesheet" />
    <!--datables CSS básico-->
    <link rel="stylesheet" type="text/css" href="DataTable/datatables.min.css" />
    <!--datables estilo bootstrap 4 CSS-->
    <link rel="stylesheet" type="text/css" href="DataTable/DataTables-1.10.18/css/dataTables.bootstrap4.min.css">

    <!--font awesome con CDN-->
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css" integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous">


    <div style="height: 50px"></div>
    <!--Ejemplo tabla con DataTables-->
    <div class="container">
        <div class="card card-luchito">
            <div class="row">
                <div class="col-lg-12">
                    <div class="table-responsive">
                        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
                            <thead>
                                <tr>
                                    <th>Id de Solicitud</th>
                                    <th>Fecha de Inicio</th>
                                    <th>Fecha de Fin</th>
                                    <th>Rut del Funcionario</th>
                                    <th>Id Tipo Permiso</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- jQuery, Popper.js, Bootstrap JS -->
    <script src ="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>
    <script src="DataTable/popper/popper.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <!-- puede estar malo******** -->

    <!-- datatables JS -->
    <script type="text/javascript" src="DataTable/datatables.min.js"></script>

    <!-- para usar botones en datatables JS -->
    <script src="DataTable/Buttons-1.5.6/js/dataTables.buttons.min.js"></script>
    <script src="DataTable/JSZip-2.5.0/jszip.min.js"></script>
    <script src="DataTable/pdfmake-0.1.36/pdfmake.min.js"></script>
    <script src="DataTable/pdfmake-0.1.36/vfs_fonts.js"></script>
    <script src="DataTable/Buttons-1.5.6/js/buttons.html5.min.js"></script>

    <!-- código JS propìo-->
    <script src="DataTable/main/main.js"></script>
    <script src="Js/Data.js"></script>
    <script>
        $(function () {
            dtUsers();
        });
    </script>

</asp:Content>
