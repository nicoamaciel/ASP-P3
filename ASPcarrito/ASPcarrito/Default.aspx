<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPcarrito.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h2>Listado de articulos</h2>
    <hr />

    <%--el uso de la grilla es para pruebas de lectura de datos NO LA BORREN--%>
    <%--<asp:GridView runat="server" CssClass="table" ID="dgvArticulos" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
            <asp:BoundField HeaderText="URL" DataField="URL" />

        </Columns>
    </asp:GridView>--%>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%--class para orden horizontal cortesia de maxi--%>
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>

                <div class="card mb-3" style="max-width: 540px;">
                    <div class="row g-0">
                        <div class="col-md-4">
                            <img src="<%#Eval("URL") %>" class="card-img-top" alt="...">
                        </div>
                        <div class="col-md-8">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <p class="card-text"><%#Eval("Descripcion") %></p>
                                <p class="card-text">$<%#Eval("Precio") %></p>
                                <p class="card-text"><%#Eval("Marca") %></p>
                                <button type="button" class="btn btn-outline-primary">Agregar al carrito</button>
                                <hr />
                                <a href="#">Ver detalles</a>


                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
