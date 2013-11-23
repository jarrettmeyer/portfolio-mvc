using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Services
{
    public interface ICategoryUpdateService
    {
        Tag UpdateCategory(CategoryInputModel categoryInputModel);
    }
}