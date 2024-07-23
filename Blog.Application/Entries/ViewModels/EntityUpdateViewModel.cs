using Blog.Application.Categories.ViewModels;
using Blog.Application.Interfaces;

namespace Blog.Application.Entries.ViewModels;

/// <summary>
/// Модель представления для обновления сущности Пост
/// </summary>
public class EntityUpdateViewModel : ViewModelAuditableBase
{
    /// <summary>
    /// Заголовок
    /// </summary>
    public string Title { get; set; } = null!;
    /// <summary>
    /// Контент
    /// </summary>
    public string Content { get; set; } = null!;
    /// <summary>
    /// Флаг видимости
    /// </summary>
    public bool IsVisible { get; set; }
    /// <summary>
    /// Категория 
    /// </summary>
    public CategoryGetViewModel Category { get; set; }
}
