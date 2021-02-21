using BookStoreModelLayer;
using BookStoreModelLayer.BooksModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBusinessLayer.IBusinessLayer
{
    public interface IBookBusiness
    {
        BookModel AddBooks(BookModel book);

        IEnumerable<BookModel> GetAllBook();
    }
}
