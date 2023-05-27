using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;
using System.Net;
using System.Xml.Linq;

namespace Catalogo
{
    public class listarArticulos
    {
        private object lector;

        public List<Articulos> listar()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesDatos datos = new AccesDatos();
            try
            {
                datos.setearConsulta("select A.Id,Codigo,Nombre,A.Descripcion,Precio," +
                    "C.Id,C.Descripcion,M.Id,M.Descripcion from ARTICULOS as A, CATEGORIAS as C, MARCAS as M WHERE A.IdCategoria=C.Id and A.IdMarca=M.Id");
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.ID = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Categoria = new Categorias();
                    aux.Categoria.ID = (int)datos.Lector["Id"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marcas();
                    aux.Marca.ID = (int)datos.Lector["Id"];
                    aux.Marca.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }


                return lista;
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

        public void agregar(Articulos nuevo)
        {
            AccesDatos datos = new AccesDatos();

            try
            {
                datos.setearConsulta("insert into ARTICULOS (ID,Codigo,Nombre,Descripcion,IdMarca,IdCategoria,Precio )values("
                                    + nuevo.ID + ", '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "'," + nuevo.Codigo + "',@IdMarca,  @IdCategoria)");
                datos.setearParametro("@ID", nuevo.ID);
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@dDescripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca.ID);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.ID);
                datos.setearParametro("@Precio", nuevo.Precio);
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

        public void modificar(Articulos arti)
        {
            AccesDatos datos = new AccesDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @nombre, Descripcion = @dDescripcion, " +
                                        "IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio Where Id = @id");
                datos.setearParametro("@Codigo", arti.Codigo);
                datos.setearParametro("@nombre", arti.Nombre);
                datos.setearParametro("@dDescripcion", arti.Descripcion);
                datos.setearParametro("@IdMarca", arti.Marca.ID);
                datos.setearParametro("@IdCategoria", arti.Categoria.ID);
                datos.setearParametro("@idDebilidad", arti.Precio);
                datos.setearParametro("@id", arti.ID);

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



        public List<Articulos> filtroBuscar()
        {
            List<Articulos> filtro = new List<Articulos>();
            AccesDatos datos = new AccesDatos();

            try
            {
                datos.setearConsulta("select A.Id, A.Nombre, A.Descripcion, A.IdMarca, A.IdMarca, A.Precio from ARTICULOS as A");
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.ID = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Categoria = new Categorias();
                    aux.Categoria.ID = (int)datos.Lector["Id"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marcas();
                    aux.Marca.ID = (int)datos.Lector["Id"];
                    aux.Marca.Descripcion = (string)datos.Lector["Descripcion"];


                    filtro.Add(aux);
                }


                return filtro;
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
    }
}
