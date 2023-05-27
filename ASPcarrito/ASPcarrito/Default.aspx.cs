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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ElementosCatalogo articulos = new ElementosCatalogo();
            dgvArticulos.DataSource = articulos.listarconSP();
            /*Metodo dataBind rendera la tabla, la manda a armar en web*/
            dgvArticulos.DataBind();

        }
    }
}