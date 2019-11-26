<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="MuniWeb.Inicio" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <script> function alertarme() {
                let timerInterval
                Swal.fire({
                    type: 'success',
                    title: 'Permiso concluido exitosamente!',
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

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Required resources-->
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" />

    <div class="h-100 mx-auto" id="demopurpose">
        <div class="container he-100">
            <div class="row justify-content-center align-items-center h-100">
                <div class="col-12">
                    <div class="card text-center card-luchito">
                        <div class="card-body py-4">
                            <img class="profile-picture rounded-circle" src="https://s3-us-west-1.amazonaws.com/co-directory-images/patricio-ogaz-8a635a30.jpg" />
                            <h2 class="text-dark h5 font-weight-bold mt-4 mb-1">
                                <asp:Label ID="lblinfo0" runat="server"></asp:Label>
                            </h2>
                            <p class="text-muted font-weight-bold small">
                                <i class="fa fa-map-marker"></i>
                                <asp:Label ID="lblinfo1" runat="server"></asp:Label>
                            </p>
                            <p class="px-1 mt-4 mb-4 text-muted quote-text">
                                <asp:Label ID="lblinfo2" runat="server"></asp:Label>
                            </p>
                            <div class="d-flex px-1 w-100 align-items-center text-left">
                                <div class="w-100">
                                    <asp:Label class="mb-1 font-weight-light text-muted small text-uppercase" ID="lblinfo3" runat="server"></asp:Label>
                                    <strong class="d-block text-warning">
                                        <i class="fa fa-star"></i>
                                        <asp:Label ID="lblinfo4" runat="server"></asp:Label>
                                    </strong>
                                </div>
                            </div>
                        </div>
                        <asp:Label ID="lblAdvertencia" runat="server"></asp:Label>
                        <br />
                        <asp:Button ID="btnVerif" runat="server" Text="Verificar" OnClick="btnVerif_Click" Visible="False" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

