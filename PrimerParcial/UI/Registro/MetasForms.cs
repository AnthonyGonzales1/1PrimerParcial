using PrimerParcial.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerParcial.UI.Registro
{
    public partial class MetasForms : Form
    {
        public object CuotastextBox { get; private set; }

        public MetasForms()
        {
            InitializeComponent();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Metas metas = new Metas();
            if (IdnumericUpDown.Value == 0)
            {
                if (BLL.MetasBLL.Guardar(metas))
                {
                    MessageBox.Show("Guardado!", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se Guardo");
                }
            }
        }

        private void CuotaTotaltextBox_TextChanged(object sender, EventArgs e)
        {}

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Metas metas = new Metas();
            
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            metas = BLL.MetasBLL.Buscar(id);

            if (metas != null)
            {
                IdnumericUpDown.Value = metas.MetaId;
                DescripciontextBox.Text = metas.Descripcion;
                CuotaTotaltextBox.Text = metas.Cuota.ToString();
                    
            }
            else
            {
                MessageBox.Show("No Fue Encontrado!", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

