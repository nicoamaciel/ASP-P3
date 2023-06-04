using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Catalogo;
using System.Data;
using System.Collections;
using System.Drawing.Imaging;

namespace ASPcarrito
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {

        public List<Articulos> listaArticulos { get; set; }
        public List<Imagenes> listaImagen { get; set; }

        public string ArtId;

        protected void Page_Load(object sender, EventArgs e)
        {
            ElementosCatalogo catalogo = new ElementosCatalogo();
            CatalogoImagenes img = new CatalogoImagenes();
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    ArtId = Request.QueryString["id"];
                    listaImagen = img.listar(ArtId);
                    listaArticulos = catalogo.listarSPdeID(ArtId);
                }
                else
                {
                    return;
                }
                
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Session["Carrito"] != null)
            {
                ElementosCatalogo Articulos = new ElementosCatalogo();
                List<Articulos> productos = Articulos.listarSPdeID(ArtId);
                List<Articulos> carrito = (List<Articulos>)Session["Carrito"];
                carrito.AddRange(productos);
                Session["Carrito"] = carrito;
            }
        }
    }
}
