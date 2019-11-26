<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GenerarSolicitud.aspx.cs" Inherits="Muni.Web.GenerarSolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
                        <br />
                        <h2>
                            <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                        </h2>
                        <br />
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Tipo Permiso:"></asp:Label>
                        <asp:DropDownList ID="ddlCategoria" runat="server" Width="215px" CssClass="dropdown" Font-Names="Rockwell" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        <p>
                            &nbsp;
                        </p>
                        <p>
                            &nbsp;
                        </p>
                        <asp:Calendar ID="Calendar1" runat="server" OnDayRender="RenderDays1" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False" Width="350px">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                        </asp:Calendar>
                        <br />
                        <asp:Label ID="lblCalendar" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:Calendar ID="Calendar2" runat="server" OnDayRender="RenderDays2" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" OnSelectionChanged="Calendar2_SelectionChanged" Visible="False" Width="350px">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                        </asp:Calendar>
                        <br />
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Confirmar" Visible="False" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
