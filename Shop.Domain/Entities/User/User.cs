using Shope.Domain.Entities.Common;

namespace Shope.Domain.Entities.User;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
}
public enum Role : byte
{
    Admin,
    User
}