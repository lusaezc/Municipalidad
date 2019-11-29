<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MantenedorTiposPermiso.aspx.cs" Inherits="Muni.Web.MantenedorTiposPermiso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>  function verificacionNull() {
            Swal.fire({
                type: 'error',
                title: 'Error!',
                text: 'Debe ingresar un nombre',
            })
        }
    </script>

    <script>  function verificacion(valido) {
            if (valido) {
                Swal.fire({
                    type: 'success',
                    title: 'Wouh...',
                    text: 'El tipo permiso fue generado exitosamente',
                })
            } else {
                Swal.fire({
                    type: 'error',
                    title: 'Oops...',
                    text: 'El tipo permiso no pudo ser generado',
                })
            }
        }
    </script>

    <script>  function verificacionModifi(valido) {
            if (valido) {
                Swal.fire({
                    type: 'success',
                    title: 'Wouh...',
                    text: 'El tipo permiso fue modificado exitosamente',
                })
            } else {
                Swal.fire({
                    type: 'error',
                    title: 'Oops...',
                    text: 'El tipo permiso no pudo ser modificado',
                })
            }
        }
    </script>

    <script>  function verificacionDelete(valido) {
            if (valido) {
                Swal.fire({
                    type: 'success',
                    title: 'Wouh...',
                    text: 'El tipo permiso fue eliminado exitosamente',
                })
            } else {
                Swal.fire({
                    type: 'error',
                    title: 'Oops...',
                    text: 'El tipo permiso no pudo ser elimnado',
                })
            }
        }
    </script>

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
                    <a href="#" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Crear</a>
                    <div class="modal fade" id="myModal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h3 class="modal-title">Ingresar un nuevo tipo de permiso</h3>
                                </div>
                                <div class="modal-body">
                                    Nombre del nuevo tipo de permiso
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                    Cantidad de días que tendra
                                    <asp:TextBox ID="txtNroDias" runat="server"></asp:TextBox>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnCancelar" runat="server" class="btn btn-default" Text="Cancelar" href="MantenedorTiposPermiso.aspx" />
                                    <asp:Button ID="btnConfirmar" runat="server" class="btn btn-success" Text="Confirmar" OnClick="btnConfirmar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <a href="#" class="btn btn-primary" data-toggle="modal" data-target="#myModal2">Modificar</a>
                    <div class="modal fade" id="myModal2">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h3 class="modal-title">Elija el tipo de permiso que desea modificar</h3>
                                </div>
                                <div class="modal-body">
                                    <center><asp:DropDownList ID="ddlTipoPermisoEdit" runat="server" Width="215px" CssClass="dropdown" Font-Names="Rockwell" OnSelectedIndexChanged="ddlTipoPermisoEdit_SelectedIndexChanged">
                                        </asp:DropDownList></center>
                                    <br />
                                    <br />

                                    nombre del nuevo tipo de permiso <asp:TextBox ID="txtNombreEdit" runat="server"></asp:TextBox>
                                    
                                    Cantidad de días <asp:TextBox ID="txtCantidadDias" runat="server"></asp:TextBox>
                                    
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnCancelarModificar" runat="server" class="btn btn-default" Text="Cancelar" href="MantenedorTiposPermiso.aspx" />
                                    <asp:Button ID="btnConfirmarModificar" runat="server" class="btn btn-success" Text="Confirmar" OnClick="btnConfirmarModificar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <a href="#" class="btn btn-primary" data-toggle="modal" data-target="#myModal3">Eliminar</a>

                    <div class="modal fade" id="myModal3">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h3 class="modal-title">Seleccione el tipo de permiso que desea eliminar</h3>
                                </div>
                                <div class="modal-body">
                                    <center><asp:DropDownList ID="ddlTipoPermiso" runat="server" Width="215px" CssClass="dropdown" Font-Names="Rockwell" OnSelectedIndexChanged="ddlTipoPermiso_SelectedIndexChanged">
                                        </asp:DropDownList></center>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnCancelarEliminar" runat="server" class="btn btn-default" Text="Cancelar" href="MantenedorTiposPermiso.aspx" />
                                    <asp:Button ID="btnEliminar" runat="server" class="btn btn-success" Text="Confirmar" OnClick="btnEliminar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                </div>
                <div class="table-responsive">
                    <table id="DataTable" class="table table-striped table-bordered" cellspacing="0" width="100%">
                        <thead>
                            <tr>
                                <th>Id del tipo de permiso</th>
                                <th>Nombre</th>
                                <th>Cantidad de días</th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <!-- jQuery, Popper.js, Bootstrap JS -->
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
    <script src="Js/Data.js"></script>
    <script>
        $(function () {
            tipoPermiso();
        });
    </script>

</asp:Content>
