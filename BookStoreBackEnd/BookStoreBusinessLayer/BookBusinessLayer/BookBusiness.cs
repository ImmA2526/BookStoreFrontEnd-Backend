using BookStoreBusinessLayer.IBusinessLayer;
using BookStoreModelLayer;
using BookStoreModelLayer.BooksModels;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBusinessLayer.BusinessLayer
{
    public class BookBusiness:IBookBusiness
    {
        IBookRepository bookRepo;
        public BookBusiness(IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        public BookModel AddBooks(BookModel book)
        {
            var result = bookRepo.AddBooks(book);
            return result;
        }

        public IEnumerable<BookModel> GetAllBook()
        {
            var getResult = bookRepo.GetAllBook();
            return getResult;
        }
    }
}
