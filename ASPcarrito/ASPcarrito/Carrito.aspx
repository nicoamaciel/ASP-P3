<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="ASPcarrito.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="cajas" class="row row-cols-1 row-cols-md-3 g-4">
    <%  
    Dictionary<int, int> cantidadArticulos = new Dictionary<int, int>();

    foreach (Dominio.Articulos art in listaArticulos)
    {
        if (cantidadArticulos.ContainsKey(art.ID))
        {
            cantidadArticulos[art.ID]++;
        }
        else
        {
            cantidadArticulos.Add(art.ID, 1);
        }
    }

    HashSet<int> articulosMostrados = new HashSet<int>();

    foreach (Dominio.Articulos art in listaArticulos)
    {
        if (articulosMostrados.Contains(art.ID))
        {
            continue; // Saltar al siguiente artículo si ya ha sido mostrado
        }
        
        articulosMostrados.Add(art.ID);
        %>
        <table class="table">
            <thead>
                <tr>
                    <th scope="col"></th>
                    <th scope="col">Nombre</th>
                    <th scope="col">Descripcion</th>
                    <th scope="col">Marca</th>
                    <th scope="col">Categoria</th>
                    <th scope="col">Precio</th>
                    <th scope="col">Eliminar Articulo</th>
                    <th scope="col">Agregar Otro</th>
                    <% if (cantidadArticulos.ContainsKey(art.ID)) { %>
                        <th scope="col">Cantidad</th>
                    <% } %>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope="row"></th>
                    <td><img src="<%= art.URL %>" class="mh-100" alt="..." style="width: 100px; height: 200px;" /></td>
                    <td><%= art.Nombre %></td>      
                    <td><%= art.Descripcion %></td>      
                    <td><%= art.Marca %></td>
                    <td><%= art.Categoria %></td>
                    <td><%= art.Precio %></td>
                    <td><asp:Button ID="btnEliminar" class="bi bi-bag-x-fill" runat="server" /></td>
                    <td><asp:Button ID="btnAregar" class="bi bi-arrow-bar-up" runat="server" /></td>
                    <% if (cantidadArticulos.ContainsKey(art.ID)) { %>
                        <td><%= cantidadArticulos[art.ID] %></td>
                    <% } %>
                </tr>
            </tbody>
        </table>
    <%  
    }
    %>
</div>
</asp:Content>
