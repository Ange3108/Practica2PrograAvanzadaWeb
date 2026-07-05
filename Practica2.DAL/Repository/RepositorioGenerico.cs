using Microsoft.EntityFrameworkCore;
using Practica2.DAL.Data;
using System.Linq.Expressions;


namespace Practica2.DAL.Repository
{

    public class RepositorioGenerico<T> : IRepositorioGenerico<T>
        where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositorioGenerico(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void AgregarAsync(T entity)
        {
            _dbSet.Add(entity);
        }

        public void ActualizarAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public void EliminarAsync(int id)
        {
            var entity = _dbSet.Find(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task<T?> BuscarAsync(
            Expression<Func<T, bool>> predicate,
            bool asNoTracking = false,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(predicate);
        }


        public async Task<T?> ObtenerPorIdAsync(
            int id,
            bool asNoTracking = true,
            params Expression<Func<T, object>>[] includes)
        {
            return await _dbSet.FindAsync(id);
        }


        public async Task<List<T>> ObtenerTodosAsync(
            bool asNoTracking = true,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }

}
