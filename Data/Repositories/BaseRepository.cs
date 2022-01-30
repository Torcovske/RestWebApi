using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : BaseEntity
    {
        private readonly DataContext _context;
        public BaseRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(TModel model)
        {
            if(model != null)
            {
                await _context.Set<TModel>().AddAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            return false; 
        }

        public async Task<bool> Delete(Guid id)
        {
            var toDelete = await _context.Set<TModel>().FirstOrDefaultAsync(m => m.Id == id);
            if(toDelete != null)
            {
                _context.Set<TModel>().Remove(toDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<TModel> Get(Guid id)
        {
            return await _context.Set<TModel>().FirstOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<List<TModel>> GetAll()
        {
            return await _context.Set<TModel>().ToListAsync();
        }

        public async Task<bool> Update(TModel model)
        {
            var toUpdate =await  _context.Set<TModel>().FirstOrDefaultAsync(m => m.Id == model.Id);
            if (toUpdate != null)
            {
               _context.Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
