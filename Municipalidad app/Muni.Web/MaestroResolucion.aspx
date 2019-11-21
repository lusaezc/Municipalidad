<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MaestroResolucion.aspx.cs" Inherits="Muni.Web.MaestroResolucion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>
        <script> function alertarme() {
            Swal.fire(
                'Pagina denegada para este tipo de usuario',
                'Pulse para OK continuar',
                'warning'
            )
        }
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

</asp:Content>
