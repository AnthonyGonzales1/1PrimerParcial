using PrimerParcial.DAL;
using PrimerParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PrimerParcial.UI.Registro;

namespace PrimerParcial.BLL
{
    public class MetasBLL
    {
        public static Metas Buscar(int id)
        {
            Metas metas = new Metas();
            Contexto contexto = new Contexto();
            try
            {

                metas = contexto.Meta.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return metas;
        }

        public static bool Guardar(Metas metas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Meta.Add(metas) != null)
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
        
        public static List<Metas> GetList(Expression<Func<Metas, bool>> met)
        {
            List<Metas> metas = new List<Metas>();
            Contexto contexto = new Contexto();
            try
            {
                metas = contexto.Meta.Where(met).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return metas;
        }
    }
}
