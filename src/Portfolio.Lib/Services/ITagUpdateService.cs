using Portfolio.Lib.DTOs;
using Portfolio.Lib.Models;

namespace Portfolio.Lib.Services
{
    public interface ITagUpdateService
    {
        Tag UpdateTag(TagDTO tagDTO);
    }
}