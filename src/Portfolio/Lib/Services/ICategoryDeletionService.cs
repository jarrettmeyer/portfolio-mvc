using Portfolio.Models;

namespace Portfolio.Lib.Services
{
    public interface ICategoryDeletionService
    {
        Category DeleteCategory(int id);
    }
}