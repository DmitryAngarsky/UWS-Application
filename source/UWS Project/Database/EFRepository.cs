using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UWS_Project.Database
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSetEntity;

        public EFRepository(DbContext context)
        {
            _context = context;
            _dbSetEntity = context.Set<TEntity>();
        }

        public Task<List<TEntity>> Get()
        {
            return _dbSetEntity.AsNoTracking().ToListAsync();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSetEntity.AsNoTracking().AsEnumerable().Where(predicate).ToList();
        }

        public ValueTask<TEntity> FindById(int id)
        {
            return _dbSetEntity.FindAsync(id);
        }

        public async void Create(TEntity item)
        {
            await _dbSetEntity.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async void Remove(TEntity item)
        {
            _dbSetEntity.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}