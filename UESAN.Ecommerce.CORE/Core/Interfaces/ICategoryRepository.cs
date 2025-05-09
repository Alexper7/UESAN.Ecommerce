using UESAN.Ecommerce.CORE.Infrastructure.Data;

namespace UESAN.Ecommerce.CORE.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<int> CreateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);
        IEnumerable<Category> GetAllCategories();
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<bool> SoftDeleteCategoryAsync(int id);
    }
}