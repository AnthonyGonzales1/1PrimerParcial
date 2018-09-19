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
        List<Vendedores> vendedore = new List<Vendedores>();
        Vendedores vendedores = new Vendedores();
        Expression<Func<Vendedores, bool>> filtrar = x => true;

        public ConsultaForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {}
        private void textBox1_TextChanged(object sender, EventArgs e)
        {}

        private bool Validar(int error)
        {
            bool paso = false;
            int num = 0;

            if (error == 1 && int.TryParse(CriteriotextBox.Text, out num) == false)
            {
                errorProvider.SetError(CriteriotextBox, "Debe de introducir un numero");
                paso = true;
            }
            if (error == 2 && int.TryParse(CriteriotextBox.Text, out num) == true)
            {
                errorProvider.SetError(CriteriotextBox, "Debe de introducir un caracter");
                paso = true;
            }

            return paso;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Vendedores, bool>> filtro = x => true;

            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://ID 
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.VendedorId == id;
                    break;
                case 1://Nombres
                    filtro = x => x.Nombres.Contains(CriteriotextBox.Text)
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 2://Sueldo 
                    filtro = x => x.Sueldo.Equals(CriteriotextBox.Text)
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 3://Retencion
                    filtro = x => x.Retencion.Equals(CriteriotextBox.Text)
                    && (x.Fecha >= DesdedateTimePicker.Value && x.Fecha <= HastadateTimePicker.Value);
                    break;
                case 4://Todo
                    filtro = x => true;
                    break;
            }
            VendedordataGridView.DataSource = BLL.VendedoresBLL.GetList(filtro);
        }

        private void FiltrocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CriteriotextBox.Clear();
            if (FiltrocomboBox.SelectedIndex == 2)
            {
                CriteriotextBox.Enabled = false;
            }
            else
            {
                CriteriotextBox.Enabled = true;
            }
            
        }

        private void ConsultaForm_Load(object sender, EventArgs e)
        {

        }
    }
}

