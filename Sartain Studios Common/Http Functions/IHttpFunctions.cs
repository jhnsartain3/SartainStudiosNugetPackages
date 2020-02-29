using System.Threading.Tasks;

namespace Sartain_Studios_Common.Http_Functions
{
    public interface IHttpFunctions
    {
        Task<T> Get<T>(string baseUri, string port, string url);
        Task Put<T>(string baseUri, string url, T stringValue);
        Task<dynamic> Post<T>(string baseUri, string url, T contentValue);
        Task Delete(string baseUri, string url);
    }
}