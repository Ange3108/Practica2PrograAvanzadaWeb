using Microsoft.EntityFrameworkCore;
namespace Practica2.DAL.Entities
{
    public partial class Categoria
    {
        public int IdCategoria { get; set; }

        public required string Nombre { get; set; } // Se agregó el required para indicar que no puede ser nulo y eliminar el warning de non-nullable

        public required string Descripcion { get; set; }  // Se agregó el required para indicar que no puede ser nulo y eliminar el warning de non-nullable
    }
}
