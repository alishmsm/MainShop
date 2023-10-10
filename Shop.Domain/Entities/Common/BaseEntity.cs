using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Shope.Domain.Entities.Common;

public class BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public DateTime CreatDate { get; set; }
    public bool IsDelete { get; set; }
    public DateTime? DeleteDate { get; set; }

}