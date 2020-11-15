﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
namespace SportsStore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly Cart cart;
        public CartSummaryViewComponent(Cart cart)
        {
            this.cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
