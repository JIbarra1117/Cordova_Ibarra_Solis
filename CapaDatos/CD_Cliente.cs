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
    public class CD_Cliente
    {
        public static CD_Cliente _instancia = null;

        private CD_Cliente()
        {

        }

        public static CD_Cliente Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Cliente();
                }
                return _instancia;
            }
        }


        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> rptListaCliente = new List<Cliente>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerCliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaCliente.Add(new Cliente()
                        {
                            IdCliente = Convert.ToInt32(dr["IdCliente"].ToString()),
                            TipoDocumento = dr["TipoDocumento"].ToString(),
                            NumeroDocumento = dr["NumeroDocumento"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"])

                        });
                    }
                    dr.Close();

                    return rptListaCliente;

                }
                catch (Exception ex)
                {
                    rptListaCliente = null;
                    return rptListaCliente;
                }
            }
        }



    }
}
