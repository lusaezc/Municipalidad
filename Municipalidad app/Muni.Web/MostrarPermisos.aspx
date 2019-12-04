<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MostrarPermisos.aspx.cs" Inherits="Muni.Web.MostrarPermisos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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

    <script>  function verificacionModifi(valido) {
            if (valido) {
                Swal.fire({
                    type: 'success',
                    title: 'Wouh...',
                    text: 'El permiso fue modificada exitosamente',
                })
            } else {
                Swal.fire({
                    type: 'error',
                    title: 'Oops...',
                    text: 'El permiso no pudo ser modificada',
                })
            }
        }
    </script>

    <script>  function verificacionNull() {
            Swal.fire({
                type: 'error',
                title: 'Error!',
                text: 'Debe ingresar un id valido y una observación',
            })
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="shortcut icon" href="#" />

    <link href="DataTable/main/main.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="DataTable/datatables.min.css" />
    <link rel="stylesheet" type="text/css" href="DataTable/DataTables-1.10.18/css/dataTables.bootstrap4.min.css">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css" integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous">

    <script type="text/javascript" src="DataTable/datatables.min.js"></script>
    <script src="DataTable/Buttons-1.5.6/js/dataTables.buttons.min.js"></script>
    <script src="DataTable/JSZip-2.5.0/jszip.min.js"></script>
    <script src="DataTable/pdfmake-0.1.36/pdfmake.min.js"></script>
    <script src="DataTable/pdfmake-0.1.36/vfs_fonts.js"></script>
    <script src="DataTable/Buttons-1.5.6/js/buttons.html5.min.js"></script>
    <script src="Js/Data.js"></script>

    <div style="height: 50px"></div>
    <!--Ejemplo tabla con DataTables-->
    <div class="container">
        <div class="card card-luchito">
            <div class="row">
                <div class="col-lg-12">
                    <a href="#" class="btn btn-primary" data-toggle="modal" data-target="#myModal2">Modificar</a>
                    <div class="modal fade" id="myModal2">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h3 class="modal-title">Ingrese el Id del permiso que desea modificar</h3>
                                </div>
                                <div class="modal-body">
                                    Id del permiso:
                            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                                    <br />
                                    <br />

                                    Nuevas observaciones:
                                    <asp:TextBox ID="txtNombreEdit" runat="server" Height="136px" Width="338px"></asp:TextBox>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnCancelarModificar" runat="server" class="btn btn-default" Text="Cancelar" href="MantenedorUnidades.aspx" />
                                    <asp:Button ID="btnConfirmarModificar" runat="server" class="btn btn-success" Text="Confirmar" OnClick="btnConfirmarModificar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="table-responsive">
                        <table id="DataTable" class="table table-striped table-bordered" cellspacing="0" width="100%">
                            <thead>
                                <tr>
                                    <th>Id del Permiso</th>
                                    <th>Observaciones</th>
                                    <th>Cantidad de Dias</th>
                                    <th>Pendiente</th>
                                    <th>Id Solicitud</th>
                                    <th>Codigo de Verificacion</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <asp:TextBox ID="txtcod" runat="server" placeholder="codigo verificar documento"></asp:TextBox>
        <asp:Button ID="btnVerificar" type="button" class="btn btn-primary btn-rounded" runat="server" Text="Verificar" OnClick="btnVerificar_Click" />
    </div>
    <script>
        $(function () {
            tablep();
        });
    </script>
</asp:Content>
