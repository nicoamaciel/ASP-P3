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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                DataTable dt = (DataTable)Session["ID"];
                DataRow dr = dt.NewRow();
                dr["ID"] = Request.QueryString["id"];
                dt.Rows.Add(dr);
            }
        }
    }
}
