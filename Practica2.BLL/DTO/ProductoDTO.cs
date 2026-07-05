namespace Practica2.BLL.DTO
{
    public class ProductoDTO
    {
        public int? IdProducto { get; set; }

        public string Nombre { get; set; } = null!;

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public int IdCategoria { get; set; }

        public CategoriaDTO? Categoria { get; set; }
    }
}
