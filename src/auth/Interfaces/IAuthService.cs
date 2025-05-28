using System.Threading.Tasks;
using Auth.DTOs;

namespace Auth.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto?> LoginAsync(LoginRequestDto request);
        // Outros métodos como Register, RefreshToken, etc, podem ser adicionados aqui
    }
}
