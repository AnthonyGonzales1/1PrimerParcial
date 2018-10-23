using PrimerParcial.DAL;
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
using static PrimerParcial.DAL.Repositorios;

namespace PrimerParcial.UI.Registro
{
    public partial class RegistroForm : Form
    {
        public int RowSelected { get; set; }
        public object CuotaTotaltextBox { get; set; }

        List<VendedoresDetalle> Detalle = new List<VendedoresDetalle>();
        Vendedores vendedores =new Vendedores();
        public RegistroForm()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void LlenarComboBox()
        {
            Repositorio<Metas> ticket = new Repositorio<Metas>(new Contexto());
            MetascomboBox.DataSource = ticket.GetList(c => true);
            MetascomboBox.ValueMember = "MetaId";
            MetascomboBox.DisplayMember = "MetaId";

        }

        private Vendedores LlenaClase()
        {
            Vendedores vendedores = new Vendedores();
            if (IdnumericUpDown.Value == 0)
            {
                vendedores.VendedorId = 0;
            }
            else
            {
                vendedores.VendedorId = Convert.ToInt32(IdnumericUpDown.Value);
            }

            vendedores.Nombres = NombretextBox.Text;
            vendedores.Fecha = FechadateTimePicker.Value;
            vendedores.Sueldo = Convert.ToDouble(SueldotextBox.Text);
            vendedores.Retencion = Convert.ToDouble(RetentextBox.CanSelect);

            return vendedores;
        }

        private bool Validar(int error)
        {
            bool paso = false;

            if (error == 1 && IdnumericUpDown.Value == 0)
            {
                errorProvider.SetError(IdnumericUpDown, 
                    "Debe ingresar un Id");
                paso = true;
            }
            if (error == 2 && NombretextBox.Text == string.Empty)
            {
                errorProvider.SetError(NombretextBox,
                   "Ingrese el nombre completo");
                paso = true;
            }
            if (error == 2 && SueldotextBox.Text == string.Empty)
            {
                errorProvider.SetError(SueldotextBox,
                   "Debes ingresar un Sueldo");
                paso = true;
            }

            return paso;
        }

        private void RetentextBox_TextChanged(object sender, EventArgs e)
        {
            double sueldo = Convert.ToDouble(SueldotextBox.Text);
            double porcen = 5.84;
            double cien = 100;
            double resultado = sueldo * porcen / cien;

            try
            {
                if (Convert.ToDouble(SueldotextBox.Text) != 0)
                {
                        RetentextBox.Text = resultado.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Vendedores vendedores = new Vendedores();
            if (Validar(1))
            {
                MessageBox.Show("Favor de llenar la casilla para poder Buscar");
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);
                vendedores = BLL.VendedoresBLL.Buscar(id);

                if (vendedores != null)
                {
                    IdnumericUpDown.Value = vendedores.VendedorId;
                    NombretextBox.Text = vendedores.Nombres.ToString();
                    FechadateTimePicker.Value = vendedores.Fecha;
                    SueldotextBox.Text = vendedores.Sueldo.ToString();
                    RetentextBox.Text = vendedores.Retencion.ToString();
                }
                else
                {
                    MessageBox.Show("No Fue Encontrado!", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                errorProvider.Clear();
            }
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            NombretextBox.Clear();
            FechadateTimePicker.ResetText();
            SueldotextBox.Clear();
            RetentextBox.ResetText();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Vendedores vendedores = new Vendedores();

            if (Validar(2))
            {
                MessageBox.Show("Llenar Campos vacios");
                errorProvider.Clear();
                return;
            }
            else
            {
                vendedores = LlenaClase();
                if (IdnumericUpDown.Value == 0)
                {
                    if (BLL.VendedoresBLL.Guardar(vendedores))
                    {
                        MessageBox.Show("Guardado!", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se Guardo");
                    }
                }
                else
                {
                    var result = MessageBox.Show("Seguro de Modificar?", "+Vendedor",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (BLL.VendedoresBLL.Modificar(LlenaClase()))
                        {
                            MessageBox.Show("Modificado");
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("No se Guardo");
                        }
                    }
                }
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (Validar(1))
            {
                MessageBox.Show("Favor de llenar casilla para poder Eliminar");
            }
            var result = MessageBox.Show("Seguro de  Eliminar?", "+Vendedor",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (BLL.VendedoresBLL.Eliminar(Convert.ToInt32(IdnumericUpDown.Value)))
                {
                    MessageBox.Show("Eliminado");
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar");
                }
            }
        }

        private double toDouble(object valor)
        {
            double retorno = 0;
            double.TryParse(valor.ToString(), out retorno);
            return retorno;

        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            if (Validar(1))
            {
                MessageBox.Show("Llenar campos Vacios");
                return;
            }
            var result = MessageBox.Show("Seguro de  Eliminar?", "+Partidos",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (BLL.VendedoresBLL.Eliminar(Convert.ToInt32(IdnumericUpDown.Value)))
                {
                    MessageBox.Show("Eliminado");
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar");
                }
            }
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            Metas metas = new Metas();
            List<VendedoresDetalle> vendedoresDetalles = new List<VendedoresDetalle>();
            if (Validar(2))
            {
                MessageBox.Show("Llene los Campos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                vendedores.Detalle.Add(new VendedoresDetalle
                        (Convert.ToInt32(MetascomboBox.Text),
                        Convert.ToDouble(CuotastextBox.Text)

                    ));

                //Cargar el detalle al Grid
                VendedoresdataGridView.DataSource = null;
                VendedoresdataGridView.DataSource = vendedores.Detalle;
            }
        }

        private void CuotastextBox_TextChanged(object sender, EventArgs e)
        {
            double cuotatotal = Convert.ToDouble(CuotaTotaltextBox);
            double cuota = Convert.ToDouble(CuotastextBox.Text);
            double resultado = cuota - cuotatotal;

            try
            {
                if (Convert.ToDouble(CuotastextBox) != 0)
                {
                    CuotaTotaltextBox = resultado.GetType();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}


