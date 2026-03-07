using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TalentGrid.Domain.Repositories;
using TelentGrid.Persistence.Context;

namespace TelentGrid.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly TalentGridDbContext _context;

        public BaseRepository(TalentGridDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            var entry = _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(Guid id)
            => await _context.Set<T>().FindAsync(id);

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
