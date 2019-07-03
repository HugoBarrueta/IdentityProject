using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIENDA_YHM.SucursalServiceRef;

namespace TIENDA_YHM.Vistas
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            GetSucursal();
        }

        public void GetSucursal()
        {
            WCFSucursalClient client = new WCFSucursalClient();
            DataSet ds = new DataSet();
            ds = client.GetSucursal();

            cmbSucursal.ValueMember = "id";
            cmbSucursal.DisplayMember = "strNombre";
            cmbSucursal.DataSource = ds.Tables[0];
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            
            var usu = txtUsuario.Text.Trim();
            var psw = txtContrasena.Text.Trim();
            var estatus = false;
            if (chbActivo.Checked)
            {
                estatus = true;
            }

                WCFSucursalClient client = new WCFSucursalClient();
            Usuario usuario = new Usuario();

           
                usuario.StrUsuario = txtUsuario.Text.Trim();
                usuario.StrPass = txtContrasena.Text.Trim();
                usuario.IdSucursal = cmbSucursal.SelectedIndex;
                usuario.BitEstatus = estatus;
                //usuario.DteFechaRegistro = DateTime.Now;
            
          
            if (txtContrasena.Text == txtconfpass.Text)
            {
               var us = client.RegistrarUsuario(usuario);
                if (us > 0)
                {
                    MessageBox.Show("Usuario registrado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al intentar n\registrar al usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                lblError.Text = "Las contraseñas no coinciden";
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Close();
        }
    }
}
