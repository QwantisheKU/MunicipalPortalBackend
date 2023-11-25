using System.Text.Json;

namespace MunicipalPortalBackend.Services.Interfaces
{
    public interface ILocationService
    {
        Task<JsonElement> CleanAddress(string[] address);
    }
}
