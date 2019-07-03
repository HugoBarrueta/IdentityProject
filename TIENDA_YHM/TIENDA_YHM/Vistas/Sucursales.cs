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

namespace TIENDA_YHM.Vistas
{
    public partial class Sucursales : Form
    {
        private int ID;
        public Sucursales(int id)
        {
            InitializeComponent();
            this.ID = id;
            this.grid();
        }

        public void grid()
        {
            if (this.ID == (int)sucursal.WCFTiendaDEJ)
            {
                using (ServiceTiendaDEJ.ServiceTiendaDEJClient servicioDEJ = new
                    ServiceTiendaDEJ.ServiceTiendaDEJClient())
                {
                    this.dgvSucursales.DataSource = servicioDEJ.GetProductos(ID);

                }
            }
        }
    }
}
