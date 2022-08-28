using AspNetCore.ServiceRegistration.Dynamic;

namespace TaparApi.Common.Services
{
    public interface IJwtService:IScopedService
    {
        Task<string> GenerateAsync<T>(T user) where T : class;
    }
}