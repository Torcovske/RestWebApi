using Data;
using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace REstWebApi.Controllers
{
    [ApiController]
    [Route("AuthorsRestApi")]
    public class AuthorsRestApi : ControllerBase
    {
        private readonly IBaseRepository<Authors> _repository;
        private readonly DataContext _context;
        public AuthorsRestApi(IBaseRepository<Authors> authorRepository, DataContext context)
        {
            _repository = authorRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<JsonResult> Get()
        {
            return new JsonResult(await _repository.GetAll());
        }
        [HttpGet]
        public async Task<JsonResult> Get(Guid id)
        {
            return new JsonResult(await _repository.Get(id));
        }
        [HttpGet]
        public async Task<JsonResult> GetBooksCount(Guid id)
        {       
            var result = await _context.Books.Include(x => x.AuthorsBooks).Where(x => x.AuthorsBooks.Select(x => x.AuthorsId).Contains(id)).CountAsync();
            return new JsonResult(result);
        }
        [HttpPost]
        public async Task<JsonResult> Post(Authors author)
        {
            return await _repository.Create(author) ? new JsonResult("Create successful") : new JsonResult("Create was not successful");
        }
        [HttpPut]
        public async Task<JsonResult> Put(Authors author)
        {
            return await _repository.Update(author) ? new JsonResult("Update successful") : new JsonResult("Update was not successful");
        }
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid id)
        {
            return await _repository.Delete(id) ? new JsonResult("Delete successful") : new JsonResult("Delete was not successful");
        }
    }
}
