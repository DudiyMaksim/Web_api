﻿using Microsoft.EntityFrameworkCore;
using Web_api.DAL.Entities;

namespace Web_api.DAL.Repositories.Category
{
    public class CategoryRepository
    : GenericRepository<CategoryEntity, string>, ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<CategoryEntity?> GetByNameAsync(string name)
        {
            var entity = await _context.Category
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.NormalizedName == name.ToUpper());
            return entity;
        }

        public bool IsUniqueName(string name)
        {
            return !_context.Category
                .Any(c => c.NormalizedName == name.ToUpper());
        }
    }
}
