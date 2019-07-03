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
using TIENDA_YHM.FerreteriaServiceRef;

namespace TIENDA_YHM.Vistas
{
    public partial class MenuProductos : Form
    {
        public MenuProductos()
        {
            InitializeComponent();
            GetSucursal();
            GetCategoria();
            mostrarProductos();
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

        public void GetCategoria()
        {
            WCFSucursalClient client = new WCFSucursalClient();
            DataSet ds = new DataSet();
            ds = client.GetCategoria();
            cmbCategoria.SelectedItem = null;
            cmbCategoria.ValueMember = "id";
            cmbCategoria.DisplayMember = "strCategoria";
            cmbCategoria.DataSource = ds.Tables[0];
        }

        public void llenarData(int id)
        {
            //switch (id)
            //{
            //    case 4:
            //        using (Carlos.Service1Client carlos = new Carlos.Service1Client())
            //        {
            //            this.dgvProductos.DataSource = carlos.consultarProductoEstatusInner();
            //        }
            //        break;
            //    case 6:
            //        using (Hugo.WCFSucursalClient hugo = new Hugo.WCFSucursalClient())
            //        {
            //            this.dgvProductos.DataSource = hugo.MostrarProducto().Tables[0];
            //        }
            //        break;
            //    case 7:
            //        using (Moy.SucursalAKMClient moy = new Moy.SucursalAKMClient())
            //        {
            //            this.dgvProductos.DataSource = moy.CargarDatosTabla().Tables[0];
            //        }
            //        break;
            //    case 8:
            //        using (Maylley.Service1Client maylley = new Maylley.Service1Client())
            //        {
            //            this.dgvProductos.DataSource = maylley.CargarDatosTabla().Tables[0];
            //        }
            //        break;
            //    case 10:
            //        using (Karen.WSSucursalClient karen = new Karen.WSSucursalClient())
            //        {
            //            this.dgvProductos.DataSource = karen.Query();
            //        }
            //        break;
            //    default:
            //        break;
            //}
        }

        private void mostrarProductos()
        {
            using (var carga = new WCFSucursalClient())
            //using (var ferr = new Service1Client())
            {
                dgvProductos.DataSource = carga.MostrarProducto().Tables[0];
                //dgvProductos.DataSource = ferr.CargarDatosTabla().Tables[0];
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            WCFSucursalClient client = new WCFSucursalClient();
            dgvProductos.DataSource = client.GetProducto(txtProducto.Text.Trim());

        }

        private void MenuProductos_Load(object sender, EventArgs e)
        {
            mostrarProductos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {            
                var estatus = false;
                if (chbActivo.Checked)
                {
                    estatus = true;
                }
                WCFSucursalClient client = new WCFSucursalClient();
                Producto producto = new Producto();

                producto.StrProducto = txtNombre.Text.Trim();
                producto.IdSucursal = cmbSucursal.SelectedIndex;
                producto.BitEstatus = estatus;
                producto.IntCantidad = int.Parse(txtCantidad.Text.Trim());
                producto.IdCategoria = cmbCategoria.SelectedIndex;

                var prod = client.InsertarProdcuto(producto);
                if (prod > 0)
                {
                    MessageBox.Show("Producto registrado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mostrarProductos();
                }
                else
                {
                    MessageBox.Show("Error al registrar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var estatus = false;
            if (chbActivo.Checked)
            {
                estatus = true;
            }
            WCFSucursalClient client = new WCFSucursalClient();
            Producto producto = new Producto();

            producto.Id = int.Parse(lblID.Text);
            producto.StrProducto = txtNombre.Text.Trim();
            producto.IdSucursal = cmbSucursal.SelectedIndex;
            producto.BitEstatus = estatus;
            producto.IntCantidad = int.Parse(txtCantidad.Text.Trim());
            producto.IdCategoria = cmbCategoria.SelectedIndex;

            var prod = client.EditarProducto(producto);
            if (prod > 0)
            {
                MessageBox.Show("Producto Editado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mostrarProductos();
            }
            else
            {
                MessageBox.Show("Error al editar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.Rows.Count > 0)
            {

                foreach (DataGridViewRow row in dgvProductos.SelectedRows)
                {

                    lblID.Text = row.Cells[0].Value.ToString();
                    txtNombre.Text = row.Cells[1].Value.ToString();
                    txtCantidad.Text = row.Cells[3].Value.ToString();
                    cmbSucursal.SelectedValue = row.Cells[2].Value.ToString();
                    cmbCategoria.SelectedValue = row.Cells[5].Value.ToString();
                    //chbActivo.AutoCheck = bool.Parse(row.Cells[5].Value.ToString());
                    chbActivo.Checked = true;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            WCFSucursalClient client = new WCFSucursalClient();
            Producto producto = new Producto();

            producto.Id = int.Parse(lblID.Text);

            var prod = client.ElimiarProdcuto(producto);
            if (prod > 0)
            {
                MessageBox.Show("Producto Eliminado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mostrarProductos();


            }
            else
            {
                MessageBox.Show("Error al Eliminar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            Productos p = new Productos();
            p.Show();
        }
    }
}
