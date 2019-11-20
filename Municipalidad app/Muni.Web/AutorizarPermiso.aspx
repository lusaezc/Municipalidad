<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AutorizarPermiso.aspx.cs" Inherits="Muni.Web.AutorizarPermiso" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script> function alertarme() {
            Swal.fire(
                'Pagina denegada para este tipo de usuario',
                'Pulse para OK continuar',
                'warning'
            )
        }
    </script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>
    <script> function autorizar() {
            Swal.fire({
                title: 'Esta seguro?',
                text: "Usted no podra revertirlo",
                type: 'warning',
                showCancelButton: true,
                closeOnConfirm: false,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                cancelButtonText: 'No, cancelar!',
                confirmButtonText: 'Si, Autorizar!',
                allowEscapeKey: false,
                allowOutsideClick: false

            }).then((result) => {
                if (result.value) {
                    $.ajax({
                        type: "POST",
                        url: "AutorizarPermiso.aspx/Busqueda",
                        data: JSON.stringify(data),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function verificado(verif) {
                            if (verif) {
                                Swal.fire(
                                    'Autorizado!',
                                    'La solicitud fue autorizada de forma exitosa.',
                                    'success');
                            } else {
                                Swal.fire(
                                    'No ha sido autorizado!',
                                    'Hubo un error al momento de autorizar, lo sentimos',
                                    'error');

                            }
                        }
                    })
                }
            })
        }



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Panel ID="Panel1" runat="server" Height="331px">
        <h1>&nbsp;</h1>
        <center style="height: 655px; width: 1500px;">
                    <center><h1>
             <asp:Label ID="lblTitulo0" runat="server" Text="Panel para generar prestamos"></asp:Label>
             </h1>
             <p>
                 &nbsp;</p>
             <h2>
                 <asp:Label ID="lblTitulo" runat="server" Text="Label"></asp:Label>
             </h2>
           </center>
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:GridView ID="gvSCurso" runat="server" AllowPaging="True" CellPadding="3" OnPageIndexChanging="gvCola_PageIndexChanging" AutoGenerateColumns="False" OnSelectedIndexChanged="gvCola_SelectedIndexChanged" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2" Width="673px">
            <Columns>
                <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio     " DataFormatString = "{0:d}" />
                <asp:BoundField DataField="FechaFin" HeaderText="Fecha Fin     " DataFormatString = "{0:d}" />
                <asp:BoundField DataField="IdSolicitud" HeaderText="Id Solicitud     " />
                <asp:BoundField DataField="Rut" HeaderText="Rut     " />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre     " />
                <asp:BoundField DataField="TipoPermiso" HeaderText="Tipo Permiso     " />
            </Columns>
            <EmptyDataTemplate>
             <h3>No Hay Solicitudes En Curso.</h3>
            </EmptyDataTemplate>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>

           <br />
           <br />
           <h3>Ingresa el ID de la Solicitud que desea autorizar y la observación:</h3>
           <p>
               <asp:TextBox ID="txtObservacion" runat="server" Height="117px" Width="445px"></asp:TextBox>
                    </p>
           <asp:TextBox ID="txtBuscar" runat="server" onkeypress="return numbersonly(event);" Width="43px"></asp:TextBox>

           &nbsp;&nbsp;&nbsp;
           <asp:Button ID="btnAutorizar" runat="server" Text="Autorizar" OnClick="btnAutorizar_Click" />
           <br />
           <br />
    </asp:Panel>
    </center>

</asp:Content>
