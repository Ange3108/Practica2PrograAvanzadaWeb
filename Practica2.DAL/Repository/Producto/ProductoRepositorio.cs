using Practica2.DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practica2.DAL.Repository.Producto

{
    public class ProductoRepositorio : RepositorioGenerico<Entities.Producto>,IProductoRepositorio
    {
        public ProductoRepositorio(
            ApplicationDbContext context)
            : base(context)
        {

        }
    }
}

