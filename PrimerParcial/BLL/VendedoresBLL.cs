using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PrimerParcial.DAL;
using PrimerParcial.Entidades;

namespace PrimerParcial.BLL
{
    public class VendedoresBLL
    {
        public static Vendedores Buscar(int id)
        {
            Vendedores vendedores = new Vendedores();
            Contexto contexto = new Contexto();
            try
            {

                vendedores = contexto.Vendedore.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return vendedores;
        }

        public static bool Guardar(Vendedores vendedores)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Vendedore.Add(vendedores) != null)
                {
                    contexto.SaveChanges();
                    contexto.Dispose();
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Vendedores vendedores)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(vendedores).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    contexto.Dispose();
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var eliminar = contexto.Vendedore.Find(Id);
                if (eliminar != null)
                {
                    contexto.Entry(eliminar).State = EntityState.Deleted;
                    if (contexto.SaveChanges() > 0)
                    {
                        contexto.Dispose();
                        paso = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        
        public static List<Vendedores> GetList(Expression<Func<Vendedores, bool>> vende)
        {
            List<Vendedores> vendedores = new List<Vendedores>();
            Contexto contexto = new Contexto();
            try
            {
                vendedores = contexto.Vendedore.Where(vende).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return vendedores;
        }
    }
}
