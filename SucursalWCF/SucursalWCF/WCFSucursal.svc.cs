using MySql.Data.MySqlClient;
using SucursalWCF.Conexion;
using SucursalWCF.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SucursalWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "WCFSucursal" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione WCFSucursal.svc o WCFSucursal.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WCFSucursal : IWCFSucursal
    {
        MySqlConnection db = conexion.ObtenerConexion();
        Control con = new Control();

        public DataSet GetCategoria()
        {
            return con.GetCatego();
        }

        public DataSet GetProducto(string prod)
        {
            return con.GetProducto(new Producto { StrProducto = prod});
        }

        public Usuario GetUsuario(string usuario, string pass)
        {
            
            Usuario usu = new Usuario();
            return con.ComprobarUsuario(new Usuario { StrUsuario = usuario, StrPass = pass });
        }
        
        public int InsertarProdcuto(Producto prod)
        {
            return con.InertarProducto(prod);
        }

        public int EditarProducto(Producto prod)
        {
            return con.EditarProducto(prod);
        }

        public int ElimiarProdcuto(Producto prod)
        {
            return con.EliminarProducto(prod);
        }

        public int InsertarCategoria(Categoria cat)
        {
            return con.InertarCategoria(cat);
        }

        public int EditarCategoria(Categoria cat)
        {
            return con.EditarCategoria(cat);
        }

        public int ElimiarCategoria(Categoria cat)
        {
            return con.EliminarCategoria(cat);
        }

        public int RegistrarUsuario(Usuario us)
        {
            return con.RegistroUsuario(us);

          
        }

        public DataSet GetSucursal()
        {
            return con.GetSucursal();
        }

        public DataSet MostrarProducto()
        {
            db.Open();

            string consulta = "select * from tblproducto where bitEstatus = 1;";

            //string consulta = "select * from tblproducto";
            MySqlCommand comm = new MySqlCommand(consulta, db);
            comm.CommandTimeout = 120;
            comm.ExecuteNonQuery();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet dt = new DataSet();
            da.SelectCommand = comm;
            da.Fill(dt);
            return dt;
            
            
        }

        public DataSet MostrarBitacora()
        {
            db.Open();

            string consulta = "select * from BitacoraProducto;";

            //string consulta = "select * from tblproducto";
            MySqlCommand comm = new MySqlCommand(consulta, db);
            comm.CommandTimeout = 120;
            comm.ExecuteNonQuery();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet dt = new DataSet();
            da.SelectCommand = comm;
            da.Fill(dt);
            return dt;
        }
    }
}
