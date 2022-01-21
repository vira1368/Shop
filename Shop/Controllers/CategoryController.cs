﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();

            var viewModel = categories
                .Select(category => new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name
                })
                .ToList();
            return View(viewModel);
        }
    }
}
