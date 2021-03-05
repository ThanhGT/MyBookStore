using Microsoft.AspNetCore.Mvc;
using MyBookStore.Models;
using System.Linq;

namespace MyBookStore.Components
{
    public class NavMenuViewComp : ViewComponent
    {
        private IBookRepository repository;
        public NavMenuViewComp(IBookRepository bookRepository)
        {
            repository = bookRepository;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Books
                        .Select(x=>x.Category)
                        .Distinct()
                        .OrderBy(x=>x));
            
        }
    }
}
