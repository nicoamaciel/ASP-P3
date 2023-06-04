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

        public string ArtId
        {
            get
            {
                if (Request.QueryString["id"] != null)
                {
                    return Request.QueryString["id"];
                }
                return null;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
                
                if (!IsPostBack)
                {
                ElementosCatalogo catalogo = new ElementosCatalogo();
                CatalogoImagenes img = new CatalogoImagenes();
                    if (Request.QueryString["id"] != null)
                    {
                        listaImagen = img.listar(ArtId);
                        listaArticulos = catalogo.listarSPdeID(ArtId);
                    }
                    else
                    {
                        return;
                    }
                }

                // Mostrar contenido actualizado
                if (listaImagen != null)
                {
                    foreach (Dominio.Imagenes img in listaImagen)
                    {
                        // Mostrar imágenes
                    }
                }

                if (listaArticulos != null)
                {
                    foreach (Dominio.Articulos art in listaArticulos)
                    {
                        // Mostrar artículos
                    }
                }
            }
            protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Session["Carrito"] != null)
            {
                ElementosCatalogo Articulos = new ElementosCatalogo();
                List<Articulos> productos = Articulos.listarSPdeID(Request.QueryString["id"]);
                List<Articulos> carrito = (List<Articulos>)Session["Carrito"];
                carrito.AddRange(productos);
                Session["Carrito"] = carrito;
            }
            Response.Redirect(Request.RawUrl);
        }


    }
}
