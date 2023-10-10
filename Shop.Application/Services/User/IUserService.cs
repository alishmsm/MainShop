using Shope.Common.DTO.Base;
using Shope.Common.DTO.User;

namespace Shope.Application.Services.User;

public interface IUserService
{
    Task<Response<IEnumerable<UserDto>>> GetAllUser();
    Task<Response<bool>> Logup(LogupDto logupDto);
    Task<Response<UserDto?>> Login(LoginDto loginDto);
    Task<Response<UserDto>> GetUser(int id);
}