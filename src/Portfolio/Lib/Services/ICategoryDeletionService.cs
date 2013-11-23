using Portfolio.Models;

namespace Portfolio.Lib.Services
{
    public interface ICategoryDeletionService
    {
        Tag DeleteCategory(int id);
    }
}