using System;
using BTG.Models.CategoryModels;

namespace BTG.Services.CategoryServices
{
    public interface ICategoryService
    {  
        Task<bool> CreateCategoryAsync(CategoryCreate model);

        Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync();
    }
}

