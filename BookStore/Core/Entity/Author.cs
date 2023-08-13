using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Core.Entity
{
    public class Author 
    {
        public int Id { get; set; }

        public string FullName { get; set; }
    }

}