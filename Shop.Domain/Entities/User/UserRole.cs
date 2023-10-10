using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shope.Domain.Entities.Common;

namespace Shope.Domain.Entities.User;

public class UserRole
{
    [Key]
    public int Id { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public Role _Role { get; set; }
}