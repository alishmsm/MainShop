using Shope.Common.DTO.Base;
using Shope.Domain.Entities.User;

namespace Shope.Common.DTO.User;

public class UserDto : BaseDto
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? token { get; set; }
    // public virtual ICollection<UserRole> UserRoles { get; set; }
}