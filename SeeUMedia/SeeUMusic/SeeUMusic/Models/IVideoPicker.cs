using System.Threading.Tasks;

namespace SeeUMedia.Models
{
    public interface IVideoPicker
    {
        Task<string> GetVideoFileAsync();
    }
}
