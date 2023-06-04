using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Catalogo;
using System.Data;

namespace ASPcarrito
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulos> listaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ElementosCatalogo articulos = new ElementosCatalogo();
                //dgvArticulos.DataSource = articulos.listarconSP();
                //dgvArticulos.DataBind();
                /*Metodo dataBind rendera la tabla, la manda a armar en web*/
            listaArticulos = articulos.listarconSP();
            Session.Add("listaArticulos", listaArticulos);
            if (!IsPostBack) {

                if (Session["Carrito"] == null)
                {
                    List<Articulos> myList = new List<Articulos>();
                    Session["Carrito"] = myList;
                }
                repRepetidor.DataSource = Session["listaArticulos"];
                repRepetidor.DataBind();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
             
            if (Session["Carrito"] != null)
            {
                ElementosCatalogo Articulos = new ElementosCatalogo();
                List<Articulos> productos = Articulos.listarSPImg(((Button)sender).CommandArgument);
                List<Articulos> carrito = (List<Articulos>)Session["Carrito"];

                carrito.AddRange(productos);
                Session["Carrito"] = carrito;
            }


        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Articulos> lista = (List<Articulos>)Session["listaArticulos"];
            List<Articulos> listaFiltrada= lista.FindAll(x=> x.Nombre.ToUpper().Contains(filtro.Text.ToUpper()));
            repRepetidor.DataSource= listaFiltrada;
            repRepetidor.DataBind();

        }

        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            Response.Redirect("detalleArticulo.aspx?ID="+((Button)sender).CommandArgument);
        }
    }
}