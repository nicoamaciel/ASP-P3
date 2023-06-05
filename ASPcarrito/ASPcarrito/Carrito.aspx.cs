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
                {
                    listaArticulos = (List<Articulos>)Session["Carrito"];
                    rptArticulos.DataSource = listaArticulos;
                    rptArticulos.DataBind();
                }
                else
                {
                Response.Redirect("Default.aspx");
                }

            }


            

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ElementosCatalogo Articulos = new ElementosCatalogo();
            List<Articulos> productos = Articulos.listarSPImg(((Button)sender).CommandArgument);
            List<Articulos> carrito = (List<Articulos>)Session["Carrito"];
            foreach (Articulos producto in productos)
            {
                Articulos articuloExistente = carrito.FirstOrDefault(p => p.ID == producto.ID);

                if (articuloExistente != null)
                {
                    articuloExistente.cantidad--;
                    if (articuloExistente.cantidad == 0)
                    {
                        carrito.Remove(articuloExistente);
                    }
                }
            }
            Session["Carrito"] = carrito;
            Response.Redirect(Request.Url.ToString());
        }

        protected void btnAumentar_Click(object sender, EventArgs e)
        {
            ElementosCatalogo Articulos = new ElementosCatalogo();
            List<Articulos> productos = Articulos.listarSPImg(((Button)sender).CommandArgument);
            List<Articulos> carrito = (List<Articulos>)Session["Carrito"];
            foreach (Articulos producto in productos)
            {
                Articulos articuloExistente = carrito.FirstOrDefault(p => p.ID == producto.ID);

                if (articuloExistente != null)
                {
                    articuloExistente.cantidad++;
                    
                }
            }
            Session["Carrito"] = carrito;
            Response.Redirect(Request.Url.ToString());
        }
    }
    
}