using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIENDA_YHM.Sucursales;
using TIENDA_YHM.Vistas;
using TIENDA_YHM.SucursalServiceRef;
using TIENDA_YHM.FerreteriaServiceRef;
using TIENDA_YHM.ServSucJNJ;
using TIENDA_YHM.ServiceTiendaDEJ;
using TIENDA_YHM.Carlos;

namespace TIENDA_YHM.Vistas
{
    public partial class Login : Form
    {
        sucursal suc = new sucursal();
        MenuProductos mp = new MenuProductos();
        Productos pds = new Productos();
        int intentos = 1;
        int cmb = 0;
        int contador = 0;
        public Login()
        {
            InitializeComponent();
            GetSucursal();
        }

        public void GetSucursal()
        {
            WCFSucursalClient client = new WCFSucursalClient();
            DataSet ds = new DataSet();
            ds = client.GetSucursal();
            cmbSucursal.SelectedItem = null;
            cmbSucursal.ValueMember = "id";
            cmbSucursal.DisplayMember = "strNombre";
            cmbSucursal.DataSource = ds.Tables[0];
        }



        //validacion de login con 3 intentos
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            #region VALIDACION 3 INTENTOS
            //var usuario = txtUsuario.Text.Trim();
            //var pass = txtContrasena.Text.Trim();


            //string[,] arreglo = { { usuario }, { pass } };
            ////Usuario usu = new Usuario();
            //WCFSucursalClient client = new WCFSucursalClient();
            //var us = client.GetUsuario(usuario, pass);

            //#region servCarlos
            ////Carlos.Service1Client carlos = new Carlos.Service1Client();
            ////var us = carlos.consultarUsuario();
            //#endregion

            //#region Ferreteria 

            ////Ferreteria
            ////Service1Client ferr = new Service1Client();
            ////var us = ferr.Login(usuario, pass);
            //#endregion

            //#region ip .2
            ////ServConsulClienteClient client = new ServConsulClienteClient();
            ////var us = client.verifRegLogin(usuario, pass);
            //#endregion

            //#region ip.3
            ////ServiceTiendaDEJClient client = new ServiceTiendaDEJClient();
            ////var us = client.GetUsuario(usuario, 6);
            //#endregion



            //if (us.StrUsuario == arreglo[0, 0] && us.StrPass == arreglo[1, 0])
            //{
            //    MessageBox.Show("Bienvenido " + usuario + " ", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    mp.Show();
            //    //pds.Show();
            //    this.Hide();

            //}

            //else if (intentos == 3)
            //{
            //    MessageBox.Show("Ha alcanzado el nivel maximo de intentos, Porfavor vuelva a intentarlo", "Mensaje del sistema",
            //                     MessageBoxButtons.OK, MessageBoxIcon.Error);


            //    Application.Exit();
            //}
            //else
            //{
            //    intentos += 1;

            //    MessageBox.Show("Ususario y/o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    txtUsuario.Text = "";
            //    txtContrasena.Text = "";
            //}

            #endregion
       
            if (this.cmb == (int)sucursal.WCFTiendaDEJ)
            {
                using (ServiceTiendaDEJ.ServiceTiendaDEJClient servicioDEJ = new
                    ServiceTiendaDEJ.ServiceTiendaDEJClient())
                {
                    var objlogin =
                        servicioDEJ.GetUsuario(this.txtUsuario.Text.Trim(),
                        cmb);
                    if (objlogin != null)
                    {
                        MessageBox.Show("Bienvenido " + objlogin.Nombre, "Verificar", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                        var frm = new Principal(this.cmb);
                        this.Hide();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("No es posible conectar ", "Verificar", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                        contador += 1;
                    }
                    if (contador == 3)
                    {

                        Application.Exit();
                    }
                }
            }

            if (this.cmb == (int)sucursal.WCFTiendaYHM)
            {
                using (SucursalServiceRef.WCFSucursalClient servicioYHM = new
                    SucursalServiceRef.WCFSucursalClient())
                {
                    var objlogin =
                        servicioYHM.GetUsuario(this.txtUsuario.Text.Trim(),
                        this.txtContrasena.Text.Trim());
                    if (objlogin != null)
                    {
                        MessageBox.Show("Bienvenido " + objlogin.StrUsuario, "Sistema", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                        var frm = new Principal();
                        this.Hide();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("No se puede conectar con la sucursal ", "Sistema", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                        contador += 1;
                    }
                    if (contador == 3)
                    {
                        MessageBox.Show("Error al iniciar sesión, intente más tarde", "Sistema", MessageBoxButtons.OK,
        MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
            }

        }


        private void linkRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Usuarios us = new Usuarios();
            us.Show();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbSucursal.SelectedItem != null)
                {
                    this.cmb = int.Parse(this.cmbSucursal.SelectedValue.ToString());
                }

            }
            catch (Exception e_)
            {
                MessageBox.Show(e_.Message);
            }
        }
    }
}

