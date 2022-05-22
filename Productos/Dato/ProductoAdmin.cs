using Productos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Productos.Dato
{
    public class ProductoAdmin
    {
        /// <summary>
        /// consulta todos los productos
        /// </summary>
        /// <returns>lista productos</returns> 

        public IEnumerable<Producto> Consultar()
        {
            using (productosEntities contexto = new productosEntities())
                return contexto.Producto.AsNoTracking().ToList();
        }

        /// <summary>
        /// Guardar producto en base de datos
        /// </summary>
        /// <param name="modelo"> Dato del producto</param>

        public void Guardar(Producto modelo)
        {
            using (productosEntities contexto = new productosEntities())
            {
                contexto.Producto.Add(modelo);
                contexto.SaveChanges();
            }            
                
        }

        /// <summary>
        /// Consultar productos
        /// </summary>
        /// <param name="id">id del producto</param>
        /// <returns></returns>

        public Producto Consultar(int id)
        {
            using (productosEntities contexto = new productosEntities())
                return contexto.Producto.FirstOrDefault(v => v.ID == id);

        }

        /// <summary>
        /// modificar los datos del producto
        /// </summary>
        /// <param name="modelo"> Datos del productos</param>

        public void Modificar( Producto modelo)
        {
            using (productosEntities contexto = new productosEntities())
            {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }

        }

        /// <summary>
        /// elimana un producto
        /// </summary>
        /// <param name="modelo">producto a eliminar</param>

        public void Eliminar(Producto modelo)
        {
            using (productosEntities contexto = new productosEntities())
            {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }

        }

    }
}