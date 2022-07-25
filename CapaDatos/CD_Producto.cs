using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Producto
    {
        public static CD_Producto _instancia = null;

        private CD_Producto()
        {

        }

        public static CD_Producto Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Producto();
                }
                return _instancia;
            }
        }

        public List<Producto> ObtenerProducto()
        {
            List<Producto> rptListaProducto = new List<Producto>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerProductos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaProducto.Add(new Producto()
                        {
                            IdProducto = Convert.ToInt32(dr["IdProducto"].ToString()),
                            Codigo = dr["Codigo"].ToString(),
                            ValorCodigo = Convert.ToInt32(dr["ValorCodigo"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["DescripcionProducto"].ToString(),
                            IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString()),
                            oCategoria = new Categoria() { Descripcion = dr["DescripcionCategoria"].ToString() },
                            Activo = Convert.ToBoolean(dr["Activo"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaProducto;

                }
                catch (Exception ex)
                {
                    rptListaProducto = null;
                    return rptListaProducto;
                }
            }
        }

    }
}
