namespace Domain.Common;

public class BaseAuditableEntity : BaseEntity
{
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}
