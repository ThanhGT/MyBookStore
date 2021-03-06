using Microsoft.AspNetCore.Mvc;
using MyBookStore.Models;

namespace MyBookStore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartServ)
        {
            cart = cartServ;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
