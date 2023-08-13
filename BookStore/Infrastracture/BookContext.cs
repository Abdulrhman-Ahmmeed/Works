using System;
using Core.Entity;
using Microsoft.EntityFrameworkCore;
    
     namespace Infrastructure 
     {
        public class BookContext : DbContext 
        {
            public BookContext (DbContextOptions<BookContext> options) : base (options) 
            { 
                
            }
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
           
           
                
        // }

            public DbSet<Bookstore> bookstores { get; set; }
            public DbSet<Author> authors { get; set; }
            
        }
    }
    
