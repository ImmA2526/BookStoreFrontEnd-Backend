using BookStoreModelLayer;
using BookStoreModelLayer.BooksModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface IBookRepository
    {
        BookModel AddBooks(BookModel book);
        IEnumerable<BookModel> GetAllBook();
        string Image(IFormFile file, int id);

        BookModel UpdateBooksByAdding(int bookCount, int bookId);

        BookModel UpdateBooksByDeleting(int bookCount, int bookId);
    }
}
