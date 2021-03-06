using Microsoft.AspNetCore.Mvc;
using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository orderRepository;
        private Cart cart;
        
        public OrderController(IOrderRepository repositoryService, Cart cartService)
        {
            orderRepository = repositoryService;
            cart = cartService;
        }

        public IActionResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty");
            }
            if (ModelState.IsValid)
            {
                order.CartLines = cart.Lines.ToArray();
                orderRepository.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/Complete", new { orderId = order.OrderID });

            } else
            {
                return View();
            }
        }
    }
}
