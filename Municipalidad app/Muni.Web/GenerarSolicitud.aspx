<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GenerarSolicitud.aspx.cs" Inherits="Muni.Web.GenerarSolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"/>

    <script> function alertarme() {
            let timerInterval
            Swal.fire({
                type: 'warning',
                title: 'Pagina denegada, Usted es un usuario moroso! Comuniquese con su unidad!',
                html: 'Seras redirigido en <b></b> Milisegundos.',
                timer: 5000,
                timerProgressBar: true,
                onBeforeOpen: () => {
                    Swal.showLoading()
                    timerInterval = setInterval(() => {
                        Swal.getContent().querySelector('b')
                            .textContent = Swal.getTimerLeft()
                    }, 100)
                },
                onClose: () => {
                    window.location.replace("http://localhost:57203/Inicio.aspx");
                }
            })
        }
    </script>

    <script>  function verificacion(valido) {
            if (valido) {
                Swal.fire({
                    type: 'success',
                    title: 'Wouh...',
                    text: 'La solicitud fue generada exitosamente',
                })
            } else {
                Swal.fire({
                    type: 'error',
                    title: 'Oops...',
                    text: 'La solicitud no pudo ser generada',
                })
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <div class="card card-luchito">
            <div class="row">
                <div class="col-lg-12">
                    <div class="table-responsive">
                        <center><br />
                        <h2>
                            <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                        </h2>
                        <br />
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Tipo Permiso:"></asp:Label>
                        <asp:DropDownList ID="ddlCategoria" runat="server" Width="215px" CssClass="form-control" Font-Names="Rockwell" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        <p>
                            &nbsp;
                        </p>
                        <p>
                            &nbsp;
                        </p>
                        <div class="date-picker" >
                            <asp:Calendar ID="Calendar1" runat="server" OnDayRender="RenderDays1" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False" Width="220px" DayNameFormat="Shortest" FirstDayOfWeek="Monday" ShowGridLines="True">
                                <DayHeaderStyle Font-Bold="True" BackColor="#FFCC66" Height="1px" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                            </asp:Calendar>
                        </div>

                        <br />
                        <asp:Label ID="lblCalendar" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:Calendar ID="Calendar2" runat="server" OnDayRender="RenderDays2" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" OnSelectionChanged="Calendar2_SelectionChanged" Visible="False" Width="220px" DayNameFormat="Shortest" ShowGridLines="True">
                            <DayHeaderStyle Font-Bold="True" BackColor="#FFCC66" Height="1px" />
                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                            <OtherMonthDayStyle ForeColor="#CC9966" />
                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                            <SelectorStyle BackColor="#FFCC66" />
                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                        </asp:Calendar>
                        <br />
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Confirmar" Visible="False" />
                        </center>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
