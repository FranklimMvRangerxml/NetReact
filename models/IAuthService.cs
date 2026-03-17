using carritonet.Models;

namespace carritonet.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDto?> LoginAsync(LoginDto loginDto);
    }
}