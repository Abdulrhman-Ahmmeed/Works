using System;
using System.Collections.Generic;


namespace Core.Interfaces
{
    public interface IGenericRepository<T>
    {
        IList<T> List();
        
        T Find(int? Id);

        void Add(T entity);

        T Update( T entity);

        void Delete(int? Id);
        IList<T> Search(string term);

         
    }
}