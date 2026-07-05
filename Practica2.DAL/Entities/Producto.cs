using Microsoft.EntityFrameworkCore;
namespace Practica2.DAL.Entities
{
    public partial class Producto
    {

        public int IdProducto { get; set; }

        public required string Nombre { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public int IdCategoria { get; set; }

        public virtual Categoria? Categoria { get; set; }
    }

}
