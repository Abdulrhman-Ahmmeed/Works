using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Core.Entity
{
    public class Bookstore 
    {  
        
         public int Id { get; set; }

        [Required]
        

        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public string  ImgUrl { get; set; }

        public Author author { get; set; }
         
        

    }

}