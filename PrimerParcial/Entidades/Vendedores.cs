using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial.Entidades
{
    public class Vendedores
    {
        [Key]
        public int VendedorId { get; set; }
        public string Nombres { get; set; }
        public DateTime Fecha { get; set; }
        public double Sueldo { get; set; }
        public double Retencion { get; set; }

        public Vendedores()
        {
            this.VendedorId = 0;
            this.Nombres = string.Empty;
            this.Fecha = DateTime.Now;
            this.Sueldo = 0;
            this.Retencion = 0;
            
        }

        public Vendedores(int vendedorId)
        {
            this.VendedorId = vendedorId;
        }
    }
}
