using Blog.Domain.Base;

namespace Blog.Application.Interfaces;

public class ViewModelAuditableBase : IViewModel, IAuditable, IHaveId
{
    public Guid Id { get; set; }
    public DateTime CreatedAt {  get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime? UpdatedAt {  get; set; }
    public string? UpdatedBy { get; set; }
}
