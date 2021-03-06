﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
	public class HomeController : Controller
	{

		private readonly IStoreRepository storeRepository;
		public int PageSize { get; set; } = 4;
		public HomeController(IStoreRepository repository)
		{
			storeRepository = repository;
		}
		public IActionResult Index(string category,int productPage=1)
        {
			return View(new ProductsListViewModel { 
				Products = storeRepository.Products.Where(p=> category == null || p.Category==category).OrderBy(p => p.ProductID).Skip((productPage - 1) * PageSize).Take(PageSize) ,
				PagingInfo=new PagingInfo { 
					CurrentPage=productPage,
					ItemsPerPage=PageSize,
					TotalItems= category==null ? storeRepository.Products.Count() : storeRepository.Products.Where(p=>p.Category==category).Count()
				},
				CurrentCategory = category
			});
        }
	}
}
