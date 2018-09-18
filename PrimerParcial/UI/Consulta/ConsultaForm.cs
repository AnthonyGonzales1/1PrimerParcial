using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrimerParcial.Entidades;
using PrimerParcial.BLL;
using System.Linq.Expressions;
using PrimerParcial.UI.Registro;

namespace PrimerParcial.UI.Consulta
{
    public partial class ConsultaForm : Form
    {
        public ConsultaForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Vendedores, bool>> filtro = x => true;

            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://ID articulo
                    id = Convert.ToInt32(CriteriocomboBox.Text);
                    filtro = x => x.VendedorId == id;
                    break;
                case 1://Descripcion articulo
                    filtro = x => x.Nombres.Contains(CriteriocomboBox.Text)
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 2://Precio articulo
                    filtro = x => x.Sueldo.Equals(CriteriocomboBox.Text)
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 3://Cantidad cotizada
                    filtro = x => x.Retencion.Equals(CriteriocomboBox.Text)
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
            }


            VendedordataGridView.DataSource = BLL.VendedoresBLL.GetList(filtro);
        }
    }
}

