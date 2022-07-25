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
    public class CD_Categoria
    {
        public static CD_Categoria _instancia = null;

        private CD_Categoria()
        {

        }

        public static CD_Categoria Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Categoria();
                }
                return _instancia;
            }
        }

        public List<Categoria> ObtenerCategoria()
        {
            List<Categoria> rptListaCategoria = new List<Categoria>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerCategorias", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaCategoria.Add(new Categoria()
                        {
                            IdCategoria = Convert.ToInt32(dr["IdCategoria"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaCategoria;

                }
                catch (Exception ex)
                {
                    rptListaCategoria = null;
                    return rptListaCategoria;
                }
            }
        }

    }
}
