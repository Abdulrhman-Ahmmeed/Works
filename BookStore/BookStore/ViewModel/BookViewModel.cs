using System;
using System.Collections.Generic;
using Core.Entity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace BookStore.ViewModel
{
    public class BookViewModel
    {

        public int BookId { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        [StringLength(120,MinimumLength =5)]
        public string Description { get; set; }

        public int AuthorId { get; set; }

        public IList<Author> Authors { get; set; }
        
        public IFormFile File { get; set; }

        public string imagUrl { get; set; }
        
    }
}