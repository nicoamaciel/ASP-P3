<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPcarrito.Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="Titulo mt-5">
        <h1>Twenty two store</h1>
        <div class="Sub mt-4">
            <p>Tienda de tecnologia</p>
        </div>
    <hr />
    </div>
    <asp:Label ID="filtrolbl" runat="server" Text="Busqueda:"></asp:Label>
    <asp:TextBox ID="filtro" runat="server" AutoPostBack="true" OnTextChanged="filtro_TextChanged" placeholder="Nombre del Articulo"  ></asp:TextBox>
    
    <div id="cajas" class="row row-cols-1 row-cols-md-3 g-4" >
        <asp:Repeater runat="server" ID="repRepetidor" >
             <ItemTemplate>
                <div class="card mt-5" style="max-width: 320px;  margin:auto">
                    <div class="row g-0">
                        <div class="col-md-12 d-flex justify-content-center align-items-center" style="height:250px">
                            <img src="<%#Eval("URL") %>" class="card-img-top" alt="..." style="width:100%;height:100%;">
                        </div>
                        <div class="col-md-12 text-center">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <p class="card-text">Precio:$<%#Eval("Precio") %></p>
                                <asp:Button ID="Button1" CssClass="btn btn-dark" runat="server" Text="Agragar al carrito" OnClick="Button1_Click" CommandArgument='<%#Eval("ID") %>' />
                                <hr />
                                <asp:Button ID="btnDetalles" runat="server" Text="Ver detalles" CommandArgument='<%#Eval("ID") %>' OnClick="btnDetalles_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
    <script src="JS/JavaScript.js"></script>
</asp:Content>
