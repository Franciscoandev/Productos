using Productos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Productos.Dato
{
    public class CategoriaAdmin
    {

        /// <summary>
        /// consulta todas las categorias
        /// </summary>
        /// <returns> datos de la categoria</returns>
        public IEnumerable<Categoria> Consulta()
        {
            using (productosEntities contexto = new productosEntities())
                return contexto.Categoria.AsNoTracking().ToList();
        }

      /// <summary>
      /// Consulta base de datos
      /// </summary>
      /// <param name="modelo"></param>
        
        public void Guardar(Categoria modelo)
        {
            using (productosEntities contexto = new productosEntities())
            {
                contexto.Categoria.Add(modelo);
                contexto.SaveChanges();
            }
        }


        /// <summary>
        /// Consulta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public Categoria Consultar(int id)
        {
            using (productosEntities contexto = new productosEntities())
            {
                return contexto.Categoria.FirstOrDefault(v => v.ID == id);
            }
        }

        /// <summary>
        /// Modifica las Categorias
        /// </summary>
        /// <param name="modelo"> Datos de la categoria</param>

        public void Modificar(Categoria modelo)
        {
            using (productosEntities contexto = new productosEntities())
            {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// elimina una categoria
        /// </summary>
        /// <param name="modelo"> CSategoria a eliminar</param>

        public void Eliminar (Categoria modelo)
        {
            using (productosEntities contexto = new productosEntities())
            {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }

        }

    }
}