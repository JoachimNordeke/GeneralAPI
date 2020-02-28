using GeneralAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralAPI.Data
{
    public interface IBooksService
    {
        Task<Book> GetBook(string id);
        Task<List<Book>> GetBooks();
        Task<Book> CreateBook(Book book);
        Task<bool> DeleteBook(string id);
        Task<Book> UpdateBook(string id, Book newBook);
    }

    public class BooksService : IBooksService
    {
        private FakeDatabase _db;

        public BooksService()
        {
            _db = new FakeDatabase();
        }

        public async Task<Book> GetBook(string id) =>
            _db.Books.Find(x => x.ID == id);

        public async Task<List<Book>> GetBooks() =>
            _db.Books.FindAll(x => true);

        public async Task<Book> CreateBook(Book book)
        {
            _db.Books.Add(book);
            return book;
        }

        public async Task<bool> DeleteBook(string id)
        {
            var deleted = _db.Books.RemoveAll(x => x.ID == id);
            return deleted > 0 ? true : false;
        }

        public async Task<Book> UpdateBook(string id, Book newBook)
        {
            var book = _db.Books.Find(x => x.ID == id);
            book.Title = newBook.Title;
            return book;
        }
    }
}
