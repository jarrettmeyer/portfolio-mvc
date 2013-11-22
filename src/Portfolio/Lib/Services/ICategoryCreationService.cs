using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Services
{
    public interface ICategoryCreationService
    {
        Category CreateCategory(CategoryInputModel categoryInputModel);
    }
}