using DPL.Data;
using DPL.Models;
using Microsoft.EntityFrameworkCore;

namespace DPL.Services
{
    public class SubCategoryService
    {
        private readonly ApplicationDbContext _context;

        public SubCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SubCategories>> GetsubCategoriessAsync()
        {
            return await _context.SubCategories.ToListAsync();
        }
        public async Task<SubCategories> GetSubCategoryByIdAsync(int subCategoryId)
        {
            return await _context.SubCategories
                .FirstOrDefaultAsync(sc => sc.SubCategoryId == subCategoryId);
        }

        public async Task AddSubcategoryAsync(SubCategories subcat)
        {
            _context.SubCategories.Add(subcat);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSubCategoryAsync(SubCategories subcat)
        {
            var existingSubCategory = await _context.SubCategories.FindAsync(subcat.SubCategoryId);
            if (existingSubCategory != null)
            {
                existingSubCategory.Name = subcat.Name;
                existingSubCategory.CategoryId = subcat.CategoryId;
                existingSubCategory.SubCategoryId = subcat.SubCategoryId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteSubCategoryAsync(int subcateId)
        {
            var subcategory = await _context.SubCategories.FindAsync(subcateId);
            if (subcategory != null)
            {
                _context.SubCategories.Remove(subcategory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
