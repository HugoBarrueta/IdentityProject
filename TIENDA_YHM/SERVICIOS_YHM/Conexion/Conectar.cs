using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SERVICIOS_YHM.Conexion
{
    public class Conectar
    {
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=1234;database=bd_sucursales;");
            return conexion;
        }
    }
}