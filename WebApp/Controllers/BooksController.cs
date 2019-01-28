using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repository;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository repository;

        public BooksController(IBookRepository _repository)
        {
            repository = _repository;
        }

        //[Authorize(Policy = "Guest")]
        [HttpGet(Name = "GetBooks")]
        public async Task<IActionResult> Get()
        {
            var query = this.HttpContext.Request.Query;
            var filter = new Dictionary<string, string>();
            foreach(var key in query.Keys)
            {
                filter.Add(key, (string)query[key]);
            }
            var result = await repository.GetAll(filter);
            return new ObjectResult(result);
        }

        //[Authorize(Policy = "Librarian")]
        [HttpGet("{id}", Name = "GetBook")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await repository.GetBook(id);
            return new ObjectResult(result) { StatusCode = 200 };
        }

        //[Authorize(Policy = "Librarian")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            var result = await repository.CreateBook(book);
            return new ObjectResult(result) { StatusCode = 200 };
        }

        //[Authorize(Policy = "Librarian")]
        [HttpPut(Name = "UpdateBook")]
        public async Task<IActionResult> Put([FromBody] Book book)
        {
            var result = await repository.UpdateBook(book);
            return new ObjectResult(result) { StatusCode = 200 };
        }

        //[Authorize(Policy = "Librarian")]
        [HttpDelete("{id}", Name = "DeleteBook")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await repository.DeleteBook(id);
            return new ObjectResult(result) { StatusCode = 200 };
        }
    }
}
