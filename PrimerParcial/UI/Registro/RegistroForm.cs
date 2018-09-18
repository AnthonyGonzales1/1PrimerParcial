﻿using PrimerParcial.Entidades;
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
    public partial class RegistroForm : Form
    {
        public RegistroForm()
        {
            InitializeComponent();
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
            vendedores.Sueldo = Convert.ToInt32(SueldotextBox.Text);
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
                double sueldo = Convert.ToInt32(SueldotextBox.Text);
                double porcen = 0.584;
                double cien = 100;
                double resultado = sueldo * porcen / cien;

                try
                {
                    if (Convert.ToDouble(RetentextBox.Text) != 0)
                    {
                        RetentextBox.Text += resultado;
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
            RetentextBox.Clear();
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
    }
}
