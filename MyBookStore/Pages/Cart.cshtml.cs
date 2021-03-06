using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBookStore.Infrastructure;
using MyBookStore.Models;

namespace MyBookStore.Pages
{
    public class CartModel : PageModel
    {
        private IBookRepository bookRepository;

        public CartModel(IBookRepository repository, Cart cartService)
        {
           bookRepository = repository;
           Cart = cartService;
        }

        public Cart Cart { get; set; }
        public string ReturnToPage { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnToPage = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long bookID, string returnUrl)
        {
            Book book = bookRepository.Books
                        .FirstOrDefault(book => book.BookID == bookID);
            // call cart object, and if it is not found then create a new instance of cart
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            // add book to cart
            Cart.AddItem(book, 1);
            // serialize object Cart
            //HttpContext.Session.SetJson("cart", Cart);
            
            return RedirectToPage(new { returnToPage = returnUrl });
        }

        public IActionResult OnPostRemove(long bookID, string returnUrl)
        {
            Cart.RemoveLines(Cart.Lines.First(cl => cl.Book.BookID == bookID).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
