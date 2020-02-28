using GeneralAPI.Models;
using System.Collections.Generic;

namespace GeneralAPI.Data
{
    public class FakeDatabase
    {
        public List<Book> Books { get; set; }

        public FakeDatabase()
        {
            Books = new List<Book>
            {
                new Book { ID = "df1f0cd7-f08e-44f4-aa25-a108299861c8", Title = "The Fellowship of the Ring" },
                new Book { ID = "5bf9953d-6184-4338-8324-b612d418db97", Title = "Hunger Games" },
                new Book { ID = "a7579815-8dde-41f8-8844-80ad1b0416eb", Title = "The Two Towers" },
                new Book { ID = "2aead370-7d0d-4477-a1e4-2bc41c6aca24", Title = "The Return of the King" },
                new Book { ID = "5cb03130-fa85-4063-bd21-916f369a7db0", Title = "The Da Vinci Code" }
            };
        }
    }
}
