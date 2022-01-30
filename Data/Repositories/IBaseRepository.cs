using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IBaseRepository  <TModel> where TModel :  BaseEntity
    {
        public Task<List<TModel>> GetAll();
        public Task<TModel> Get(Guid id);
        public Task<bool> Create(TModel model);
        public Task<bool> Update(TModel model);
        public Task<bool> Delete(Guid id);
    }
}
