using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Services
{
    public interface ICategoryUpdateService
    {
        Category UpdateCategory(CategoryInputModel categoryInputModel);
    }
}