using SucursalWCF.Conexion;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SucursalWCF.Controlador
{
    public class Control
    {
        MySqlConnection db = conexion.ObtenerConexion();
        #region login
        //listo
        public Usuario ComprobarUsuario(Usuario usu)
        {
            db.Open();
            string consulta = "SELECT * FROM tblUsuarios WHERE StrUsuario = '" + usu.StrUsuario + "' AND StrPass = '" + usu.StrPass + "';";
            MySqlCommand comm = new MySqlCommand(consulta, db);
            Usuario usuario = new Usuario();
            try
            {
                MySqlDataReader leer = comm.ExecuteReader();
                leer.Read();
                usuario.Id = int.Parse(leer[0].ToString());
                usuario.StrUsuario = leer[1].ToString();
                usuario.StrPass = leer[2].ToString();
                usuario.BanErrores = true;
            }
            catch (Exception)
            {
                usuario.BanErrores = false;
            }
            db.Close();
            return usuario;

        }
        #endregion
        //listo
        public int RegistroUsuario(Usuario us)
        {
            int res = 0;
            byte est = 0;
            try
            {
                if (us.BitEstatus == true)
                {
                    est = 1;
                }

                db.Open();
                string consulta = "insert into tblusuarios (strUsuario,strpass,dteFechaRegistro,bitestatus,idsucursal)"
                    + "values('" + us.StrUsuario + "', '" + us.StrPass + "', NOW(), '" + est + "', '" + us.IdSucursal + "');";
                MySqlCommand comm = new MySqlCommand(consulta, db);

                res = comm.ExecuteNonQuery();


                us.BanErrores = true;
                us.Mensajes = "usuario registrado correctamente";
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
                us.Mensajes = "Error al registrar usuario";

            }
            db.Close();
            return res;
        }

        #region Producto
        public int InertarProducto(Producto prod)
        {
            int res = 0;
            try
            {

                db.Open();
                string consulta = "INSERT INTO tblProducto(strProducto,idSucursal,intCantidad,bitEstatus,idCategoria) "
                    + "Values(@_strProducto,@_idSucursal,@_intCantidad,@_bitEstatus,@_idCategoria)";
                MySqlCommand comm = new MySqlCommand(consulta, db);
                comm.CommandTimeout = 120;
                comm.CommandType = CommandType.Text;

                comm.Parameters.AddWithValue("@_strProducto", prod.StrProducto);
                comm.Parameters.AddWithValue("@_idSucursal", prod.IdSucursal);
                comm.Parameters.AddWithValue("@_intCantidad", prod.IntCantidad);
                comm.Parameters.AddWithValue("@_bitEstatus", prod.BitEstatus);
                comm.Parameters.AddWithValue("@_idCategoria", prod.IdCategoria);

                res = comm.ExecuteNonQuery();

                db.Close();

                prod.BanErrores = true;
                prod.Mensajes = "Producto registrado correctamente";
            }
            catch (Exception)
            {
                prod.BanErrores = false;
                prod.Mensajes = "Error al registrar producto";

            }
            db.Close();
            return res;
        }

        public int EditarProducto(Producto prod)
        {
            int res = 0;
            try
            {

                db.Open();
                string consulta = "UPDATE tblProducto SET strProducto = @_strProducto, idSucursal = @_idSucursal, intCantidad = @_intCantidad, " +
                                "bitEstatus = @_bitEstatus, idCategoria = @_idCategoria WHERE id = @_id; ";
                MySqlCommand comm = new MySqlCommand(consulta, db);

                comm.CommandType = CommandType.Text;

                comm.Parameters.AddWithValue("@_id", prod.Id);
                comm.Parameters.AddWithValue("@_strProducto", prod.StrProducto);
                comm.Parameters.AddWithValue("@_idSucursal", prod.IdSucursal);
                comm.Parameters.AddWithValue("@_intCantidad", prod.IntCantidad);
                comm.Parameters.AddWithValue("@_bitEstatus", prod.BitEstatus);
                comm.Parameters.AddWithValue("@_idCategoria", prod.IdCategoria);

                res = comm.ExecuteNonQuery();

                prod.BanErrores = true;
                prod.Mensajes = "Producto modificado correctamente";
            }
            catch (Exception)
            {
                prod.BanErrores = false;
                prod.Mensajes = "Error al modificar producto";

            }
            db.Close();
            return res;
        }

        public int EliminarProducto(Producto prod)
        {
            int res = 0;
            try
            {

                db.Open();
                string consulta = "update tblProducto set bitEstatus = 0 where id = @_id;";
                MySqlCommand comm = new MySqlCommand(consulta, db);

                comm.CommandType = CommandType.Text;

                comm.Parameters.AddWithValue("@_id", prod.Id);

                res = comm.ExecuteNonQuery();

                db.Close();

                prod.BanErrores = true;
                prod.Mensajes = "Producto eliminado correctamente";
            }
            catch (Exception)
            {
                prod.BanErrores = false;
                prod.Mensajes = "Error al eliminar producto";

            }
            db.Close();
            return res;
        }
        //listo
        public DataSet GetProducto(Producto prod)
        {
        #endregion
        
            

            db.Open();
            string consulta = "select p.id, strProducto, idSucursal," +
            "intCantidad, p.bitEstatus, idCategoria from tblproducto p inner "
            + " join tblSucursal s on s.id = p.idsucursal inner join catCategoria c on c.id = p.idCategoria "
            + "where strProducto = '" + prod.StrProducto + "';";
            MySqlCommand comm = new MySqlCommand(consulta, db);
            comm.CommandTimeout = 120;
            //comm.CommandType = CommandType.StoredProcedure;
            comm.ExecuteNonQuery();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet dt = new DataSet();
            da.SelectCommand = comm;
            da.Fill(dt);
            
            return dt;

        }
    
        #region Categoria
        public int InertarCategoria(Categoria cat)
        {
            int res = 0;
            try
            {

                db.Open();
                string consulta = "sp_InsertarCategoria";
                MySqlCommand comm = new MySqlCommand(consulta, db);

                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.AddWithValue("@_strCategoria", cat.StrCategoria);
                comm.Parameters.AddWithValue("@_bitEstatus", cat.BitEstatus);

                res = comm.ExecuteNonQuery();

                db.Close();

                cat.BanErrores = true;
                cat.Mensajes = "Categoria registrada correctamente";
            }
            catch (Exception)
            {
                cat.BanErrores = false;
                cat.Mensajes = "Error al registrar categoria";

            }
            db.Close();
            return res;
        }

        public int EditarCategoria(Categoria cat)
        {
            int res = 0;
            try
            {

                db.Open();
                string consulta = "sp_EditarCategoria";
                MySqlCommand comm = new MySqlCommand(consulta, db);

                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.AddWithValue("@_id", cat.Id);
                comm.Parameters.AddWithValue("@_strProducto", cat.StrCategoria);
                comm.Parameters.AddWithValue("@_bitEstatus", cat.BitEstatus);

                res = comm.ExecuteNonQuery();

                db.Close();

                cat.BanErrores = true;
                cat.Mensajes = "Categoria editada correctamente";
            }
            catch (Exception)
            {
                cat.BanErrores = false;
                cat.Mensajes = "Error al editar categoria";

            }
            db.Close();
            return res;
        }

        public int EliminarCategoria(Categoria cat)
        {
            int res = 0;
            try
            {

                db.Open();
                string consulta = "sp_EliminarProducto";
                MySqlCommand comm = new MySqlCommand(consulta, db);

                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.AddWithValue("@_id", cat.Id);

                res = comm.ExecuteNonQuery();

                db.Close();

                cat.BanErrores = true;
                cat.Mensajes = "Categoria eliminada correctamente";
            }
            catch (Exception)
            {
                cat.BanErrores = false;
                cat.Mensajes = "Error al eliminar categoria";

            }
            db.Close();
            return res;
        }

        public List<Categoria> GetCategoria()
        {
            List<Categoria> list = new List<Categoria>();
            try
            {

                db.Open();
                string consulta = "sp_EliminarProducto";
                MySqlCommand comm = new MySqlCommand(consulta, db);

                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.AddWithValue("@_id", "");

                MySqlDataReader rd = comm.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        list.Add(new Categoria
                        {
                            Id = rd.GetInt32(0),
                            StrCategoria = rd.GetString(1),
                            BitEstatus = rd.GetBoolean(4)
                        });
                    }
                }
                else
                {
                    throw new Exception("No hay registros");
                }

                db.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);

            }
            db.Close();
            return list;
        }
        #endregion

        //listo
        public DataSet GetSucursal()
        {
            db.Open();
            string consulta = "SELECT * FROM tblSucursal;";
            MySqlCommand comm = new MySqlCommand(consulta, db);
            //comm.CommandType = CommandType.StoredProcedure;
            comm.ExecuteNonQuery();
            MySqlDataAdapter da = new MySqlDataAdapter(comm);
            DataSet dt = new DataSet();
            da.Fill(dt);
            db.Close();
            return dt;
        }
        //listo
        public DataSet GetCatego()
        {
            db.Open();
            string consulta = "SELECT * FROM catCategoria;";
            MySqlCommand comm = new MySqlCommand(consulta, db);
            //comm.CommandType = CommandType.StoredProcedure;
            comm.ExecuteNonQuery();
            MySqlDataAdapter da = new MySqlDataAdapter(comm);
            DataSet dt = new DataSet();
            da.Fill(dt);
            db.Close();
            return dt;
        }
        
    }
}