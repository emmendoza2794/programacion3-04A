using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graficas.views
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHelix_Click(object sender, EventArgs e)
        {
            var helixTool = new HelixToolTikForm();
            helixTool.ShowDialog();
        }

        private void btnScottPlot_Click(object sender, EventArgs e)
        {
            var scottPlotForm = new ScottPlotForm();
            scottPlotForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var graficasForm = new GraficasForm();
            graficasForm.ShowDialog();
        }
    }
}
