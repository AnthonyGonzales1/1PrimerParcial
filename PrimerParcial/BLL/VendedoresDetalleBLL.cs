using PrimerParcial.DAL;
using PrimerParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial.BLL
{
    public class VendedoresDetalleBLL
    {
        public static VendedoresDetalle Buscar(int id)
        {
            VendedoresDetalle vendedoresDetalle = new VendedoresDetalle();
            Contexto contexto = new Contexto();
            try
            {

                vendedoresDetalle = contexto.Detalle.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return vendedoresDetalle;
        }

        public static bool Guardar(VendedoresDetalle vendedoresDetalle)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Detalle.Add(vendedoresDetalle) != null)
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

        public static bool Modificar(VendedoresDetalle vendedoresDetalle)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(vendedoresDetalle).State = EntityState.Modified;
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
                var eliminar = contexto.Detalle.Find(Id);
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

        public static List<VendedoresDetalle> GetList(Expression<Func<VendedoresDetalle, bool>> vendeT)
        {
            List<VendedoresDetalle> vendedoresDetalles = new List<VendedoresDetalle>();
            Contexto contexto = new Contexto();
            try
            {
                vendedoresDetalles = contexto.Detalle.Where(vendeT).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return vendedoresDetalles;
        }
    }
}
