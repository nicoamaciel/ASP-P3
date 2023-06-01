using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Catalogo;

namespace ASPcarrito
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {

        public List<Articulos> listaArticulos { get; set; }
        public int ArtId { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                ArtId = Convert.ToInt32(Request.QueryString["id"]);
            }

            ElementosCatalogo catalogo = new ElementosCatalogo();
            listaArticulos = catalogo.listarconSP();
          




        }

      
    }
}
