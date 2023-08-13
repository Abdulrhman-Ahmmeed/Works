using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entity;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.GenericRepository
{
    public class BookRepository : IGenericRepository<Bookstore>
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {

            _context = context;
            
        }
        
        public IList<Bookstore> List()
        {
           // الانكلود عشان لما اجي اعرض كتاب يجبلي اسم المؤلف عن طريق رقمه لان انا معرف الاوشر في البوك بس الاسم ف الاوشر

           return _context.bookstores.Include(a=>a.author).ToList();
        }

        public Bookstore Find(int? Id)
        {
            // asNoTracking عشان لما استخدم الرقم مجرد للبحث مفضلش متتبعه في الاستخدام
           // الانكلود عشان لما اجي اعرض كتاب يجبلي اسم المؤلف عن طريق رقمه لان انا معرف الاوشر في البوك بس الاسم ف الاوشر
           return _context.bookstores.Include(a=>a.author).AsNoTracking().FirstOrDefault(a=>a.Id==Id);
        }

        public void Add(Bookstore entity)
        {
            _context.bookstores.Add(entity);
            _context.SaveChanges();

        }

        public  Bookstore Update(Bookstore entity)
        {
           _context.Update(entity);
           _context.SaveChanges();
            return entity;
        }

        public void Delete(int? Id)
        {
            var exist=Find(Id);
            _context.bookstores.Remove(exist);     
             _context.SaveChanges();

        }

        public IList<Bookstore> Search(string term)
        {
           return _context.bookstores.Include(a=>a.author)
           .Where(a=>a.Title.Contains(term)
           ||a.Description.Contains(term)
           ||a.author.FullName.Contains(term)).ToList();
        }
    }
}
