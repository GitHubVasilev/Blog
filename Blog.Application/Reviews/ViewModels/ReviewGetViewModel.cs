using Blog.Application.Interfaces;
namespace Blog.Application.Reviews.ViewModels;

public class ReviewGetViewModel : ViewModelAuditableBase, ITree<ReviewGetViewModel>
{
    public string UserName { get; set; } = null!;
    public string Content { get; set; } = null!;
    public int Rating { get; set; }
    public ReviewGetViewModel? Parent {  get; set; }
    public List<ReviewGetViewModel> Child { get; set; } = null!;
    public bool IsVisible { get; set; }
}
