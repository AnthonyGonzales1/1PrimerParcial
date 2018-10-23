using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial.Entidades
{
    public class VendedoresDetalle
    {
        [Key]
        public int MetasId { get; set; }
        public double Cuotas { get; set; }

        public VendedoresDetalle()
        {
            this.MetasId = 0;
        }
        public VendedoresDetalle(int metasId, double cuotas)
        {
            this.MetasId = metasId;
            this.Cuotas = cuotas;
            
        }
    }
}
