using BookStoreModelLayer;
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

    }
}
