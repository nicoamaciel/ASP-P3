<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="detalleArticulo.aspx.cs" Inherits="ASPcarrito.Formulario_web1" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <asp:Panel runat="server">
      <% if (listaImagen != null && listaImagen.Count > 0)
          { %>
        <div class="row mt-5 d-flex align-items-center justify-content-center">
            <div class="col-lg-5 mt-5">
                <div id="carouselExampleIndicators" class="carousel slide carousel-fade">
                    <div class="carousel-inner">
                        <% for (int i = 0; i < listaImagen.Count; i++)
                            { %>
                            <div class="carousel-item<%= i == 0 ? " active" : "" %>">
                                <img src="<%= listaImagen[i].ImagenURL %>" class="d-block w-100" alt="...">
                            </div>
                        <% } %>
                    </div>
                    <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Anterior</span>
                    </a>
                    <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Siguiente</span>
                    </a>
                    <ol class="carousel-indicators">
                        <% for (int i = 0; i < listaImagen.Count; i++)
                            { %>
                            <li data-bs-target="#carouselExampleIndicators" data-bs-slide-to="<%= i %>"<%= i == 0 ? " class='active'" : "" %>></li>
                        <% } %>
                    </ol>
                </div>
            </div>

        
      

      <% if (listaArticulos != null && listaArticulos.Count > 0) { %>
    <div class="col-lg-5 mt-5">
        <h1 class="card-title"><%= listaArticulos[0].Nombre %></h1>
        <hr />
        <p>Información: <span id="infoSpan" runat="server"></span></p>
        <p class="card-text mt-5"><b>Marca:</b> <%= listaArticulos[0].Marca %></p>
        <p class="card-text"><b>Descripcion: </b><%= listaArticulos[0].Descripcion %></p>
        <p class="card-text"><b>Precio</b>: $<%= listaArticulos[0].Precio %></p>
    </div>
<% } %>
        </div>
    <% } %>

       <div class="row mt-5">
        <div class="col-md-2 d-flex align-items-center justify-content-center">
            <div class="container d-flex align-items-center justify-content-center">
                <div class="row">
                    <div class="col-md-4">
                        <a href="Default.aspx">
                            <div class="btn btn-danger" style="height:43px">
                                <p>Regresar</p>
                            </div>
                        </a>
                    </div>
                    <div class="col-md-4"></div>
                    <div class="col-md-4">
                        <asp:Button ID="btnAgregar" runat="server" Text="Add carrito" OnClick="btnAgregar_Click"  />

                    </div>

                </div>

            </div>

        </div>

       </div>
    </asp:Panel>



</asp:Content>
