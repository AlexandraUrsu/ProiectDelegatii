using System.IO;
using System.Threading.Tasks;

namespace ProiectDelegatii
{
    interface ISave
    {
        Task SaveAndView(string filename, string contentType, MemoryStream stream);
    }
}
