using BookStoreBusinessLayer.IBusinessLayer;
using BookStoreModelLayer;
using BookStoreModelLayer.BooksModels;
using BookStoreRepositoryLayer.IRepository;
using Microsoft.AspNetCore.Http;
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

        public string Image(IFormFile file, int id)
        {
            var uploadImage = bookRepo.Image(file, id);
            return uploadImage;

        }

        public BookModel UpdateBooksByAdding(int bookCount, int bookId)
        {
            var udateBook = bookRepo.UpdateBooksByAdding(bookCount, bookId);
            return udateBook;
        }

        public BookModel UpdateBooksByDeleting(int bookCount, int bookId)
        {
            var udateBook = bookRepo.UpdateBooksByDeleting(bookCount, bookId);
            return udateBook;
        }
    }
}
