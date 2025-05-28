using System.Threading.Tasks;
using Auth.DTOs;

namespace Auth.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto?> LoginAsync(LoginRequestDto request);
        // Outros m�todos como Register, RefreshToken, etc, podem ser adicionados aqui
    }
}
