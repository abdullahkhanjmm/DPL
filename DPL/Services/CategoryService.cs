using System.Collections.Generic;
using System.Threading.Tasks;
using DPL.Components.Pages;
using DPL.Data;
using DPL.Models;
using Microsoft.EntityFrameworkCore;

public class CategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Categories>> GetCategoriesAsync()
    {
        return  await _context.Categories.ToListAsync();
    }

    public async Task AddcategoryAsync(Categories category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCategoryAsync(Categories category)
    {
        var existingCategory = await _context.Categories.FindAsync(category.CategoryId);
        if (existingCategory != null)
        {
            existingCategory.CategoryName = category.CategoryName;
            existingCategory.Description = category.Description;
            existingCategory.Image = category.Image;
            existingCategory.ImageName = category.ImageName;
            existingCategory.ImageFormat = category.ImageFormat;
            existingCategory.ImageUrl = category.ImageUrl;

            _context.Categories.Update(existingCategory);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteCategoryAsync(int cateId)
    {
        var category = await _context.Categories.FindAsync(cateId);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}