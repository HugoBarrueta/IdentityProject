using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIENDA_YHM.Vistas
{
    public partial class Principal : Form
    {
        private int ID;
        public Principal()
        {
            InitializeComponent();
        }

        public Principal(int id)
        {
            InitializeComponent();
            this.ID = id;
        }

        private void MenuUsuarios_Click(object sender, EventArgs e)
        {
            MenuUsuarios usuario = new MenuUsuarios();
            usuario.Show();
        }

        private void MenuProductos_Click(object sender, EventArgs e)
        {
            MenuProductos producto = new MenuProductos();
            producto.Show();
        }

        private void MenuCategorias_Click(object sender, EventArgs e)
        {
            MenuCategorias categoria = new MenuCategorias();
            categoria.Show();
        }

        private void consultarSucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sucursales sucursales = new Sucursales(this.ID);
            sucursales.Show();
        }
    }
}
