<%@ Page Title="Carrito de Compras" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="ASPcarrito.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="product-list">
        <asp:Repeater ID="rptArticulos" runat="server">
    <ItemTemplate>
        <div class="product">
            <img src="<%# Eval("URL") %>" alt="Miniatura">
            <div class="product-info">
                <span><strong>Nombre:</strong> <%# Eval("Nombre") %></span>
                <span><strong>Código:</strong> <%# Eval("Codigo") %></span>
                <span><strong>Marca:</strong> <%# Eval("Marca") %></span>
                <span><strong>Categoría:</strong> <%# Eval("Categoria") %></span>
                <span><strong>Precio:</strong> <%# Eval("Precio") %></span>
                <span><strong>Cantidad:</strong> <%# Eval("cantidad") %></span>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("ID") %>' />
                <asp:Button ID="btnAumentar" runat="server" Text="+" OnClick="btnAumentar_Click" CommandArgument='<%# Eval("ID") %>' />

            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
            <div class="total">
    <% decimal totalPagar = listaArticulos.Sum(p => p.Precio * p.cantidad); %>
    <% foreach (var producto in listaArticulos) { %>
        <span><strong><%= producto.Nombre %>:</strong> <%= producto.Precio %> x <%= producto.cantidad %></span>
    <% } %>
    <br>
    Total a pagar: $<%= totalPagar.ToString("0.00") %>
</div>
</div>
        
        

</asp:Content>
