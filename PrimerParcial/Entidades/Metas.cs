using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial.Entidades
{
    public class Metas
    {
        [Key]
        public int MetaId { get; set; }
        public string Descripcion { get; set; }
        public double Cuota { get; set; }

        public Metas()
        {
            this.MetaId = 0;
            this.Descripcion = string.Empty;
            this.Cuota = 0;
        }
    }
}
