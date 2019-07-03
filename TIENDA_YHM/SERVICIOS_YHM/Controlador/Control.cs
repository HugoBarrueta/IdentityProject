using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;
using SERVICIOS_YHM.Modelo;

namespace SERVICIOS_YHM.Controlador
{
    public class Control
    {
        MySqlConnection bd = Conexion.Conectar.ObtenerConexion();

        public void InsertaUsuario(Usuario usuario)
        {
            bd.Open();
            string insert = "Insert into tblusuarios (strUsuario, strPass,dteFechaRegistro,bitEstatus) values ('" + usuario.strUsuario + "', '" + usuario.strPass + "')";
            MySqlCommand ejecutar = new MySqlCommand(insert, bd);
            ejecutar.ExecuteNonQuery();
            bd.Close();
        }
    }
}