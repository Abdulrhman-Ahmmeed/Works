using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entity;
using Infrastructure;
using Core.Interfaces;
using BookStore.ViewModel;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;

namespace BookStore.Controllers
{
    public class BookstoresController : Controller
    {
         private readonly BookContext _context;
        private readonly IGenericRepository<Bookstore> _BookRepo;
        private readonly IGenericRepository<Author> _authorRepo;
        [Obsolete]
        private readonly IHostingEnvironment _host;

        [Obsolete]
        public BookstoresController(BookContext context,IGenericRepository<Bookstore> BookRepo,
                                IGenericRepository<Author> authorRepo,IHostingEnvironment host)
        {
            _context = context;
            _BookRepo = BookRepo;
            _authorRepo=authorRepo;
            _host = host;
        }
        // GET: Bookstores
        public  IActionResult Index()
        {
            return View( _BookRepo.List());
        }

        // GET: Authors/Details/5
        public  IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookstore =  _BookRepo.Find(id);
            if (bookstore == null)
            {
                return NotFound();
            }

            return View(bookstore);
        }

        // GET: Bookstores/Create
        public IActionResult Create()
        {
            var Book= new BookViewModel
            {   
                Authors=FillSelectList()
            };
            return View(Book);
        }

        // POST: Bookstores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [Obsolete]
        // public IActionResult Create(BookViewModel BVM)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         if (BVM.File==null)
        //         {
        //             string images =Path.Combine(_host.ContentRootPath,"images");
        //             string fullpath = Path.Combine(images, BVM.File.FileName);
        //             BVM.File.CopyTo(new FileStream(fullpath, FileMode.Create));
        //         }
                    
        //          var authoR = _authorRepo.Find(BVM.AuthorId);

        //             Bookstore book = new Bookstore
        //             {
        //                 Id=BVM.BookId,
        //                 Title=BVM.Title,
        //                 Description=BVM.Description,
        //                 author=authoR,
        //                 ImgUrl=BVM.File.FileName
        //             };

        //             _BookRepo.Add(book);
        //           _context.SaveChanges();

        //             return RedirectToAction(nameof(Index));

        //     }
        //     ModelState.AddModelError("", "You have to fill all the required fields!");
        //     return View(GetAllAuthors());
        //     }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Obsolete]
        public IActionResult Create(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string fileName = UploadFile(model.File) ?? string.Empty;
                    if (model.AuthorId == 0)
                    {
                        ViewBag.Message = "Please select an author from the list!";
                        return View(GetAllAuthors());
                    }
                    var authoR = _authorRepo.Find(model.AuthorId);
                 
                    Bookstore book = new Bookstore
                    {
                        Id = model.BookId,
                        Title = model.Title,
                        Description = model.Description,
                        author = authoR,
                        ImgUrl = fileName
                    };
                    _BookRepo.Add(book);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            ModelState.AddModelError("", "You have to fill all the required fields!");
            return View(GetAllAuthors());
        }


        // GET: Bookstores/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookstore = _BookRepo.Find(id);
            if (bookstore == null)
            {
                return NotFound();
            }

             var viewModel = new BookViewModel
            {
                BookId = bookstore.Id,
                Title = bookstore.Title,
                Description = bookstore.Description,
                Authors = _authorRepo.List().ToList(),
                imagUrl=bookstore.ImgUrl
            };

            return View(viewModel);
        }

        // POST: Bookstores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Obsolete]
        public ActionResult Edit(BookViewModel viewModel)
        {
            // في مشكله دلوقتي لما بعدل ع الصوره بنده بfind 
            // فالايدي بيبقي مستخدم لجلب اسم الصوره في الميثود المخصصه 
            // ولما بنعمل نيوبوك بنستخد الايدي فبيبقيكدا متتبع مرتين ف استخدمت في الfind 
            // روح شوف ف الفايند 
            // ==========other way use hidden filename in viewmodel to get name Pic with out find by id
            try
            {
              string fileName = UploadFile(viewModel.File,viewModel.BookId) ?? string.Empty;

                  var authoR = _authorRepo.Find(viewModel.AuthorId);

                    Bookstore book = new Bookstore
                    {
                        Id=viewModel.BookId,
                        Title=viewModel.Title,
                        Description=viewModel.Description,
                        author=authoR,
                        ImgUrl=fileName
                    };

                    _BookRepo.Update(book);
                  _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
            }
            catch (Exception )
            {
                return View();
            }
        }

        // GET: Bookstores/Delete/5
        public  IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookstore =  _BookRepo.Find(id);
            if (bookstore == null)
            {
                return NotFound();
            }

            return View(bookstore);
        }

        // POST: Bookstores/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            var bookstore =  _BookRepo.Find(id);
                _context.Remove(bookstore);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool BookstoreExists(int? id)
        {
            return _context.bookstores.Any(e => e.Id == id);
        } 
        // List<Author> FillSelectList()
        // {
        //     var authors = _authorRepo.List().ToList();
        //     authors.Insert(0, new Author { Id = 0, FullName = "--- Please select an author ---" });

        //     return authors;
        // }
        List<Author> FillSelectList()
        {
            var authors = _authorRepo.List().ToList();
            authors.Insert(0, new Author { Id = 0, FullName = "--- Please select an author ---" });

            return authors;
        }
          BookViewModel GetAllAuthors()
        {
            var vmodel = new BookViewModel
            {
                Authors = FillSelectList()
            };

            return vmodel;
        }
                
                
        [Obsolete]

        string UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string uploads = Path.Combine(_host.ContentRootPath+"/wwwroot/"+"images");
                string fullPath = Path.Combine(uploads, file.FileName);
                file.CopyTo(new FileStream(fullPath, FileMode.Create));

                return file.FileName;
            }

            return null;
        }

        [Obsolete]
        string UploadFile(IFormFile file,int id)
        {
            if (file != null)
            {
                // New Path
                string uploads = Path.Combine(_host.ContentRootPath+"/wwwroot/"+"images");
                string newFullPath = Path.Combine(uploads, file.FileName);
                // Delete old Path
                string oldFileName=_BookRepo.Find(id).ImgUrl;
                string oldFullPath=Path.Combine(uploads,oldFileName);
                if (oldFullPath != newFullPath)
                {
                    System.IO.File.Delete(oldFullPath);
                    // save New File  
                    file.CopyTo(new FileStream(newFullPath, FileMode.Create));

                }
                return file.FileName;
            }

            return null;
        }
         public IActionResult Search(string term)
         {
            var result=_BookRepo.Search(term);
            return View("Index",result); 
         }

    }
}
