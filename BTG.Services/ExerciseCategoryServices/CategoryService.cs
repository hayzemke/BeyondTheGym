using System;
using BeyondTheGym_WebApp.Data.Data;
using BTG.Data;
using BTG.Models.CategoryModels;
using Microsoft.EntityFrameworkCore;

namespace BTG.Services.CategoryServices
{
    public class CategoryService :ICategoryService
    {
        private readonly ApplicationDbContext _context;
  
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCategoryAsync(CategoryCreate model)
        {
            if (model is null) return false;

            var entity = new Category
            {
                Name = model.Name,
            };

            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync()
        {
            var categories = await _context
                .Categories
                .Select(e=> new CategoryListItem
                {
                    Id=e.Id,
                    Name=e.Name,
                })
                .ToListAsync();

            return categories;
        }
    }
}

