using BookStoreModelLayer;
using BookStoreModelLayer.BooksModels;
using BookStoreModelLayer.CustomerModels;
using BookStoreModelLayer.UserModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer
{
    public class BookStoreContext :DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        { 
        }
        
        public DbSet<UserModel> UserTabel { get; set; }

        public DbSet<AddressTypeModel> AddressTypeTable { get; set; }

        public DbSet<CustomerModel> CustomerTable { get; set; }

        public DbSet<BookModel> BookTable { get; set; }

        public DbSet<OrderModel> OrderSummaryTable { get; set; }

    }
}
