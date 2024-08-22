using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();

        Task<CategoryDTO> GetCategoryByID(int id);

        Task AddCategory(CategoryDTO categoryDto);
        Task RemoveCategory(int id);
        Task UpdateCategory(CategoryDTO categoryDto);
    }
}
