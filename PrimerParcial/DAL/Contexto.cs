using PrimerParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial.DAL
{
    // Aqui agregamos public tambien, para que la clase pueda ser encontrada en cualquier parte del proyecto, 
    //y heredamos de  DbContext para que EntityFramework pueda hacer su magia
    public class Contexto: DbContext
    {
        public DbSet<Vendedores> Vendedore { get; set; }
        public DbSet<VendedoresDetalle> Detalle { get; set; }
        public DbSet<Metas> Meta { get; set; }

        // base("ConStr") para pasar la conexion a la clase base de EntityFramework 
        public Contexto() : base("ConStr") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
