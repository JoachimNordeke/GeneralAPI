using System;
using GeneralAPI.Models;

namespace GeneralAPI.Factories
{
    public static class BookFactory
    {
        public static Book CreateBookFromCreateBook(CreateBook book)
        {
            return new Book
            {
                ID = Guid.NewGuid().ToString(),
                Title = book.Title
            };
        }
    }
}
