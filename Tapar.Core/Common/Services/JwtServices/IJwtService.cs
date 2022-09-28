using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Tapar.Core.Common.Services.JwtServices
{
    [ScopedService]
    public interface IJwtService
    {
        Task<string> GenerateAsync<T>(T user) where T : class;
    }
}