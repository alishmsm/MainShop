using Shope.Domain.Entities.Common;

namespace Shope.Domain.Entities.Image;

public class Image : BaseEntity
{
    public string FileName { get; set; }
    public string FileSize { get; set; }
    public string FileExtention { get; set; }
    public Guid Identifire { get; set; }
}