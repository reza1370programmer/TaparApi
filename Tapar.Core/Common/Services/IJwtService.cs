

namespace Tapar.Core.Common.Services
{
    public interface IJwtService
    {
        Task<string> GenerateAsync<T>(T user) where T : class;
    }
}