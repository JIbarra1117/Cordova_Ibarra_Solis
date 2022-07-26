﻿using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Proveedor
    {
        public static CD_Proveedor _instancia = null;

        private CD_Proveedor()
        {

        }

        public static CD_Proveedor Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Proveedor();
                }
                return _instancia;
            }
        }

        public List<Proveedor> ObtenerProveedor()
        {
            List<Proveedor> rptListaProveedor = new List<Proveedor>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerProveedores", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaProveedor.Add(new Proveedor()
                        {
                            IdProveedor = Convert.ToInt32(dr["IdProveedor"].ToString()),
                            Ruc = dr["Ruc"].ToString(),
                            RazonSocial = dr["RazonSocial"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"].ToString())

                        });
                    }
                    dr.Close();

                    return rptListaProveedor;

                }
                catch (Exception ex)
                {
                    rptListaProveedor = null;
                    return rptListaProveedor;
                }
            }
        }


    }
}
