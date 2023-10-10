using System.ComponentModel.DataAnnotations;

namespace Shope.Common.DTO.User;

public class LogupDto
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    
    
    [Compare("Password", ErrorMessage = "Password is notEqual RePassword")]
    public string RePassword { get; set; }
}