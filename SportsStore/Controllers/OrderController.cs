using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private Cart cart;
        public OrderController(IOrderRepository repository,Cart cartService)
        {
            orderRepository = repository;
            cart = cartService;
        }
        public IActionResult Checkout()
        {
            return View(new Order());
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        {
            if (cart.Lines.Count == 0)
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            if(ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                await orderRepository.SaveOrderAsync(order);
                cart.Clear();
                return RedirectToPage("/Completed", new { orderId = order.OrderID });
            }
            return View(order);
        }
    }
}
