using TaparApi.Data.Entities;

namespace TaparApi.Common.Services
{
    public interface IJwtService
    {
        Task<string> GenerateAsync<T>(T user) where T : class;
    }
}