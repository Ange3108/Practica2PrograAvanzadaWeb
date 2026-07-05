using System;
using System.Collections.Generic;
using System.Text;

namespace Practica2.DAL.Entities
{
    public partial class Producto
    {

        public int IdProducto { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public int IdCategoria { get; set; }

        public virtual Categoria? Categoria { get; set; }
    }

}
