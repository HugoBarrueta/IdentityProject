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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
            mostrarBitacora();
        }

        private void mostrarBitacora()
        {
            using (var carga = new WCFSucursalClient())
            //using (var ferr = new Service1Client())
            {
                dgvBitacora.DataSource = carga.MostrarBitacora().Tables[0];
                //dgvProductos.DataSource = ferr.CargarDatosTabla().Tables[0];
            }
        }

        private void dgvBitacora_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Productos_Load(object sender, EventArgs e)
        {
            mostrarBitacora();
        }
    }
}
