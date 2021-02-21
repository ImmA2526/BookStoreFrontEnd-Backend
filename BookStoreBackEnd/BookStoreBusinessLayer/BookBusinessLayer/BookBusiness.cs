using BookStoreBusinessLayer.IBusinessLayer;
using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBusinessLayer.BusinessLayer
{
    public class BookBusiness : IBookBusiness
    {
        IBookRepository bookRepo;
        public BookBusiness(IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;
        }


    }
}
