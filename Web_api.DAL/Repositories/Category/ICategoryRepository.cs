using Web_api.DAL.Entities;

namespace Web_api.DAL.Repositories.Category
{
    public interface ICategoryRepository
        : IGenericRepository<CategoryEntity, string>
    {
        Task<CategoryEntity?> GetByNameAsync(string name);
        bool IsUniqueName(string name);
    }
}
