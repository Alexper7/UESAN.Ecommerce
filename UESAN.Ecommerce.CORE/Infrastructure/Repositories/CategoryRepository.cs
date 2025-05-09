using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UESAN.Ecommerce.CORE.Core.Interfaces;
using UESAN.Ecommerce.CORE.Infrastructure.Data;

namespace UESAN.Ecommerce.CORE.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _context;

        public CategoryRepository(StoreDbContext context)
        {
            _context = context;
        }
        // Get all categories
        public IEnumerable<Category> GetAllCategories()
        {
            //var context = new StoreDbContext();
            var categories = _context.Category.Where(c => c.IsActive == true).ToList();
            return categories;
            //(parametro) => expresión
            //Elemento de la tabla categoria es c(lambda(=>))
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Category.Where(c => c.IsActive == true).ToListAsync();
        }
        //Get category by id anync este anys es para que se utilicen muchos Hilos de ejecucion SE LLAMA ASINCRONIA
        // para que sea asincrono se pone el async y await
        //await es que espera a una tarea asincrona termine, asincrono puede ejecutarse en segundo plano

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Category.FindAsync(id);//busca por clave primaria el registro
            return category;
        }

        // Create category

        public async Task<int> CreateCategoryAsync(Category category)
        {
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        //delete category
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return false;
            }
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
        // Delete category (soft delete) este es un Update
        public async Task<bool> SoftDeleteCategoryAsync(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return false;





            }
            category.IsActive = false;
            _context.Category.Update(category);
            await _context.SaveChangesAsync();
            return true;
        }





    }
}
