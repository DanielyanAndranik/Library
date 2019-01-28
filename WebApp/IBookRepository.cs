using WebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll(Dictionary<string, string> filter);
        Task<Book> GetBook(int id);
        Task<Book> CreateBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<Book> DeleteBook(int id);
    }
}
