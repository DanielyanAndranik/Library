using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repository
{
    public class BookRepository : BaseRopository, IBookRepository
    {
        public BookRepository(LibraryContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Book>> GetAll(Dictionary<string, string> filter)
        {
            var books = (IQueryable<Book>)context.Books;

            if(filter.Count != 0)
            {
                if(filter.TryGetValue("title", out string title))
                {
                    books = books.Where(book => book.Title == title);
                }

                if (filter.TryGetValue("author", out string author))
                {
                    books = books.Where(book => book.Author == author);
                }

                if (filter.TryGetValue("publisher", out string publisher))
                {
                    books = books.Where(book => book.Publisher == publisher);
                }

                if (filter.TryGetValue("lang", out string lang))
                {
                    books = books.Where(book => book.Language == lang);
                }

                if (filter.TryGetValue("published", out string yearString))
                {
                    if(int.TryParse(yearString, out int year))
                    {
                        books = books.Where(book => book.Published == new DateTime(year, 0, 0));
                    }
                }
            }

            return await Task.Run(() => books);
        }

        public async Task<Book> GetBook(int id)
        {
            return await Task.Run(() => context.Books.First(b => b.Id == id));
        }

        public async Task<Book> CreateBook(Book book)
        {
            var result = await context.Books.AddAsync(book);

            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Book> UpdateBook(Book book)
        {
            var result = context.Books.Update(book);

            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Book> DeleteBook(int id)
        {
            var book = context.Books.First(b => b.Id == id);

            if (book == null)
            {
                return null;
            }

            var result = context.Books.Remove(book);

            await context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
