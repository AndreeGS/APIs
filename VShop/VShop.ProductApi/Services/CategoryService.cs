using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEnity = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEnity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
        {
            var categoriesEnity = await _categoryRepository.GetCategoriesProducts();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEnity);
        }

        public async Task<CategoryDTO> GetCategoryByID(int id)
        {
            var categoriesEnity = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDTO>(categoriesEnity);
        }

        public async Task AddCategory(CategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Create(categoryEntity);
            categoryDto.CategoryId = categoryEntity.CategoryId;
        }

        public async Task UpdateCategory(CategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Update(categoryEntity);
        }

        public async Task RemoveCategory(int id)
        {
            var categoryEntity = _categoryRepository.GetById(id).Result;
            await _categoryRepository.Delete(categoryEntity.CategoryId);
        }

        
    }
}
