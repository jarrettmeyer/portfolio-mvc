using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Services
{
    public interface ICategoryCreationService
    {
        Tag CreateCategory(CategoryInputModel categoryInputModel);
    }
}