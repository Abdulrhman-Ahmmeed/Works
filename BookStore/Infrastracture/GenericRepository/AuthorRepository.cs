using Core.Entity;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.GenericRepository
{
    public class AuthorRepository : IGenericRepository<Author>
    {
        private readonly BookContext _context;

        public AuthorRepository(BookContext Context)
        {
            _context = Context;
        }
        

        public IList<Author> List()
        {
            return _context.authors.ToList(); 
        }

        public Author Find(int? Id)
        {
            return _context.authors.FirstOrDefault(a=>a.Id==Id);

        }

        public void Add(Author entity)
        {
            _context.authors.Add(entity);
           _context.SaveChanges();

        }

        public Author Update(Author entity)
        {
            var exist=_context.authors.Attach(entity);
            exist.State= Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return entity;

        }

        public void Delete(int? Id)
        {
            var exist=Find(Id);
             _context.authors.Remove(exist);  
             _context.SaveChanges();
         
       }

        public IList<Author> Search(string term)
        {
           return _context.authors
           .Where(a=>a.FullName.Contains(term)).ToList();
        }
    }
}