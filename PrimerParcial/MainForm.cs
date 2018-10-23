using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerParcial
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrimerParcial.UI.Registro.RegistroForm registro = new UI.Registro.RegistroForm();
            
            registro.Show();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrimerParcial.UI.Consulta.ConsultaForm consulta = new UI.Consulta.ConsultaForm();

            consulta.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrimerParcial.UI.Registro.MetasForms metas = new UI.Registro.MetasForms();

            metas.Show();
        }
    }
}
