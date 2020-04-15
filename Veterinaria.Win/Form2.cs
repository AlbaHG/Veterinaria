using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.BL;

namespace Veterinaria.Win
{
    public partial class Form2 : Form
    {
        ReportedeVentasPorProductoBL _reporteVentasPorProductoBL;

        public Form2()
        {
            InitializeComponent();
            _reporteVentasPorProductoBL = new ReportedeVentasPorProductoBL();

            RefrescarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefrescarDatos();
        }

        private void RefrescarDatos()
        {
            var listadeVentasPorProducto = _reporteVentasPorProductoBL.ObtenerVentasPorProducto();
            listadeVentasPorProductoBindingSource.DataSource = listadeVentasPorProducto;
            listadeVentasPorProductoBindingSource.ResetBindings(false);
        }
    }
}
