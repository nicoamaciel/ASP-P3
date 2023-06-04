using Catalogo;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace ASPcarrito
{
    public partial class Carrito : System.Web.UI.Page
    {
        
        public List<Imagenes> imagens ;
        public List<Articulos> listaArticulos
        {
            get
            {
                var obj = this.Session["Carrito"];
                if (obj == null) { 
                    obj = this.Session["Carrito"] = new List<Articulos>(); }
                return (List<Articulos>)obj;
            }

            set
            {
                this.Session["Carrito"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogoImagenes img = new CatalogoImagenes();
            if (!IsPostBack)
            {
                imagens = img.listartop();
            }
            
        }


    }
}