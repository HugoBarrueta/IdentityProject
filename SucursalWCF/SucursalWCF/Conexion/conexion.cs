using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SucursalWCF.Conexion
{
    public class conexion
    {
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection("datasource=127.0.0.1;port=3306;" +
                "username=Sucursales;password=1234;database=db_Sucursales;");
            return conexion;
        }
    }
}