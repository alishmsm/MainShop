using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shope.Application.Interfaces;
using Shope.Common.DTO.Base;
using Shope.Common.DTO.User;
using Store.Coomon;

namespace Shope.Application.Services.User;

public class UserService : IUserService
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    public UserService(IAppDbContext context,IMapper mapper,IConfiguration coconfiguration)
    {
        _configuration = coconfiguration;
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<UserDto>>> GetAllUser()
    {
        var Userlist = await _context.Users
            .AsNoTracking()
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        // var _userlist=_mapper.Map<List<UserDto>>(Userlist);
        // return   _context.Users.ToList();
        return new Response<IEnumerable<UserDto>>(Userlist);

    }
    public async Task<Response<UserDto>> GetUser(int id)
    {
        var user = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            return new Response<UserDto>(null,false,"this user isn't exist");
        }
        var userDto = _mapper.Map<UserDto>(user);
        return new Response<UserDto>(userDto);
    
    }
    
    // public async Task<Response<UserDto>> GetUser()
    // {
    //     var user = await _context.Users
    //         .AsNoTracking()
    //         .FirstOrDefaultAsync(u => u.Id ==  );
    //     if (user == null)
    //     {
    //         return new Response<UserDto>(null,false,"this user isn't exist");
    //     }
    //     var userDto = _mapper.Map<UserDto>(user);
    //     return new Response<UserDto>(userDto);
    //
    // }
    public async Task<Response<bool>> Logup(LogupDto logupDto)
    {
        bool existUser = await _context.Users.AsNoTracking()
            .AnyAsync(u => u.UserName == logupDto.UserName);

        PasswordHasher passwordHasher = new();
        string newpass = passwordHasher.HashPassword(logupDto.Password);
        logupDto.Password = newpass;
        if (!existUser)
        {
            var user = _mapper.Map<Domain.Entities.User.User>(logupDto);
            _context.Users.Add(user);

            await _context.SaveChangesAsync();
            return new Response<bool>(true,true, "Logup successfully");
        }

        return new Response<bool>(false,false, "Logup failed");
    }

    public async Task<Response<UserDto?>> Login(LoginDto loginDto)
    {
        
        
        
        var user = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.UserName == loginDto.UserName);
        
        UserDto _userDto = _mapper.Map<UserDto>(user);
        if (user == null)
        {
            return new Response<UserDto?>(null,false,"This User isn't Exist");
        }
        PasswordHasher passwordHasher = new();
        bool resultVerifyPassword = passwordHasher.VerifyPassword(user.Password, loginDto.Password);
        if (resultVerifyPassword == false)
        {
            return new Response<UserDto?>(null,false,"wrong password!!");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // You can add more claims here
            new Claim(ClaimTypes.Name, user.UserName), // You can add more claims here
            // Add any additional claims you want to include in the token
        };

        var token = GetToken(claims);
        _userDto.token = token;
        return new Response<UserDto>(_userDto);
    }
    
    
    private string GetToken(List<Claim> claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Issuer"], claims,
            expires: DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:Expire"])), signingCredentials: credentials);
        var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
        
        return accessToken;
    }
}