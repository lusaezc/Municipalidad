<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Prueba.aspx.cs" Inherits="Muni.Web.Prueba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>  function verificacion(valido) {
            if (valido) {
                Swal.fire({
                    type: 'success',
                    title: 'Wouh...',
                    text: 'La unidad fue generada exitosamente',
                })
            } else {
                Swal.fire({
                    type: 'error',
                    title: 'Oops...',
                    text: 'La unidad no pudo ser generada',
                })
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="send-pm" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="send-pm" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h3 id="myModalLabel">Send Foobar a PM</h3>
        </div>
        <div class="modal-body">
            <p>One fine body…</p>
        </div>
        <div class="modal-footer">
            <button class="btn" data-dismiss="modal" aria-hidden="true">Cancel</button>
            <button class="btn btn-primary">Send</button>
        </div>
    </div>

    <a href="#" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Eliminar</a>
    <div id="Eliminar" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="send-pm" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title">Elija la unidad que desea eliminar</h3>
                </div>
                <div class="modal-body">
                    <form id="myForm3">
                        <asp:DropDownList ID="ddlUnidades" runat="server" Width="215px" CssClass="dropdown" Font-Names="Rockwell" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </form>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnCancelarEliminar" runat="server" class="btn btn-default" Text="Cancelar" href="#" />
                    <asp:Button ID="btnConfirmarEliminar" runat="server" class="btn btn-success" Text="Confirmar" OnClick="btnConfirmarEliminar_Click" />
                </div>
            </div>
        </div>
    </div>

    <a href="#" class="btn btn-primary" data-toggle="modal" data-target="#myModall">Crear</a>
    <div id="send-pm" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="send-pm" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title">Ingresar una nueva unidad</h3>
                </div>
                <div class="modal-body">
                    <form id="myForm">
                        Nombre de la nueva unidad:
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    </form>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnCancelar" runat="server" class="btn btn-default" Text="Cancelar" href="#" />
                    <asp:Button ID="btnConfirmar" runat="server" class="btn btn-success" Text="Confirmar" OnClick="btnConfirmar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
