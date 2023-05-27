using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo
{
    public class CatalogoImagenes
    {
        public List<Imagenes> listar(Articulos articulos)
        {
            List<Imagenes> lista = new List<Imagenes>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select ID,IdArticulo, ImagenURL from IMAGENES ");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagenes aux = new Imagenes();
                    if (articulos.ID == (int)datos.Lector["IdArticulo"])
                    {
                        aux.ID = (int)datos.Lector["Id"];
                        aux.ImagenURL = (string)datos.Lector["ImagenURL"];
                        lista.Add(aux);
                    }

                }
                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //
        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from IMAGENES where IdArticulo = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificarImagen(Imagenes modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update IMAGENES set ImagenUrl= @imag, IdArticulo = @idart Where Id = @id");
                datos.setearParametro("@imag", modificar.ImagenURL);
                datos.setearParametro("@idart", modificar.IDArticulo);
                datos.setearParametro("@id", modificar.ID);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void cargarImagenes(Imagenes nuevos)
        {
            // Crear instancia de AccesoDatos
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Setear consulta SQL para insertar nuevo artículo
                datos.setearConsulta("INSERT INTO IMAGENES (ImagenUrl, IdArticulo) " +
                      "VALUES ('" + nuevos.ImagenURL + "', " + nuevos.IDArticulo+")");
                // Ejecutar consulta SQL
                datos.ejecutarLectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Cerrar conexión
                datos.cerrarConexion();
            }
        }
        //
    }
}
