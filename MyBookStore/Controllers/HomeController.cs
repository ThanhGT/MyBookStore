using Microsoft.AspNetCore.Mvc;
using MyBookStore.Models;
using MyBookStore.Models.ViewModels;
using System.Linq;

namespace MyBookStore.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository repository;
        public int PageSize = 3;
        public HomeController(IBookRepository bookRepository)
        {
            repository = bookRepository;
        }
        public IActionResult Index(string category, int bookPage=1) => View(new BookListView
        {
                                                         Books = repository.Books
                                                        .Where(c=> category == null || c.Category == category)
                                                        .OrderBy(b => b.BookID)
                                                        .Skip((bookPage - 1) * PageSize)
                                                        .Take(PageSize),
                                                    PageInfo = new PageInfo
                                                    {
                                                        CurrentPage = bookPage,
                                                        ItemPerPage = PageSize,
                                                        TotalItems = category == null ?
                                                            repository.Books.Count() :
                                                            repository.Books.Where( c => c.Category == category).Count()
                                                    },
                                                    CurrentCategory = category
        });
    }
}
