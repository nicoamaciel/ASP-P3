<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="detalleArticulo.aspx.cs" Inherits="ASPcarrito.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <asp:Panel runat="server">
        <% foreach (Dominio.Articulos art in listaArticulos)
        {
            if (art.ID == ArtId)
            {
        %>




      <div class="row mt-5  d-flex align-items-center justify-content-center" style="height:700px">

          <div class="col-lg-5 mt-5">

<img src="<%= art.URL %>" class="card-img-top" alt="..." style="width:100%;height:600px;">

          </div>

  <div class="col-lg-5 mt-5">


                <h1 class="card-title"><%= art.Nombre %></h1>
              
                <hr />
                <p>Información: <span id="infoSpan" runat="server"></span></p>  <p class="card-text mt-5"><b>Marca:</b> <%= art.Marca %></p>
                <p class="card-text"><b>Descripcion: </b><%= art.Descripcion %></p>
                <p class="card-text"><b>Precio</b>: $<%= art.Precio %></p>
          </div>

          <div class="col-md-2 d-flex align-items-center justify-content-center" >


              <div class="container d-flex align-items-center justify-content-center">
                  <div class="row">
                  <div class="col-md-4"><a href="Default.aspx"><div class="btn btn-danger" style="height:43px"><p>regresar</p>
                                                               </div></a></div>
                  <div class="col-md-4"></div>
                  <div class="col-md-4"><asp:Button ID="btnAgregar" runat="server" Text="Add carrito" OnClick="btnAgregar_Click" CssClass="btn btn-success b1" /></div>

</div>

              </div>

              <br/>



          </div>

      </div>




       


       <div class="mt-5" style="max-width: 520px; margin:auto"><div class="col-md-12 d-flex justify-content-center align-items-center" style="height:250px">
            
        </div>
    <div class="row g-0">
        
        <div class="col-md-12 text-center">
            
        </div>
    </div>
</div>













        <% 
                    break;
                }
            }
        %>
    </asp:Panel>



</asp:Content>
