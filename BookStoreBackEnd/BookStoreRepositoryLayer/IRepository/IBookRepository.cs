using BookStoreModelLayer;
using BookStoreModelLayer.BooksModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface IBookRepository
    {
        BookModel AddBooks(BookModel book);

        IEnumerable<BookModel> GetAllBook();
    }
}
