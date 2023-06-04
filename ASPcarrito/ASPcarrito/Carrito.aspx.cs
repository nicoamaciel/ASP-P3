using Catalogo;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace ASPcarrito
{
    public partial class Carrito : System.Web.UI.Page
    {

        public List<Articulos> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogoImagenes img = new CatalogoImagenes();
            if (!IsPostBack)
            {
                if (Session["Carrito"] != null)
                    listaArticulos = (List<Articulos>)Session["Carrito"];
            }

        }

        private void BindArticulos(List<Articulos> listaArticulos)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='table'>");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<th></th>");
            sb.Append("<th></th>");
            sb.Append("<th>Nombre</th>");
            sb.Append("<th>Descripcion</th>");
            sb.Append("<th>Marca</th>");
            sb.Append("<th>Categoria</th>");
            sb.Append("<th>Precio</th>");
            sb.Append("<th>Eliminar Articulo</th>");
            sb.Append("<th>Agregar Otro</th>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody>");

            foreach (Articulos articulo in listaArticulos)
            {
                sb.Append("<tr>");
                sb.Append("<td></td>");
                sb.Append("<td><img src='" + articulo.URL + "' class='mh-100' alt='...' style='width: 100px; height: 200px;' /></td>");
                sb.Append("<td>" + articulo.Nombre + "</td>");
                sb.Append("<td>" + articulo.Descripcion + "</td>");
                sb.Append("<td>" + articulo.Marca + "</td>");
                sb.Append("<td>" + articulo.Categoria + "</td>");


            }
        }

        protected void btnAregar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}