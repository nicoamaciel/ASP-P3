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
        public List<Articulos> listaArticulos { get; set; }
             List<int> listaId=new List<int>();



        protected void Page_Load(object sender, EventArgs e)
        {


   ElementosCatalogo articulos = new ElementosCatalogo();
                //dgvArticulos.DataSource = articulos.listarconSP();
                //dgvArticulos.DataBind();
                /*Metodo dataBind rendera la tabla, la manda a armar en web*/
           listaArticulos = articulos.listarconSP();
            Session.Add("listaArticulos", listaArticulos);
                


             
                repRepetidor.DataSource = Session["listaArticulos"];
                repRepetidor.DataBind();
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button btn=(Button)sender;
          string  idAux = btn.CommandArgument;


            int id;
            if (int.TryParse(idAux, out id))
            {
             
                listaId.Add(id);


            }
            else
            {
                
            }


        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Articulos> lista = (List<Articulos>)Session["listaArticulos"];
            List<Articulos> listaFiltrada= lista.FindAll(x=> x.Nombre.ToUpper().Contains(filtro.Text.ToUpper()));
            repRepetidor.DataSource= listaFiltrada;
            repRepetidor.DataBind();

        }
    }
}