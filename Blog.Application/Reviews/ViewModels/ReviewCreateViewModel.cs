using Blog.Application.Interfaces;

namespace Blog.Application.Reviews.ViewModels;

/// <summary>
/// Модель представления для создания отзыва
/// </summary>
public class ReviewCreateViewModel : ViewModelBase
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string UserName { get; set; } = null!;

    /// <summary>
    /// Содержание
    /// </summary>
    public string Content { get; set; } = null!;

    /// <summary>
    /// Оценка
    /// </summary>
    public int Rating { get; set; }

    /// <summary>
    /// Пост к которому прикреплен комментарий
    /// </summary>
    public Guid EntityId { get; set; }

    /// <summary>
    /// Идентификатор родительского комментария
    /// </summary>
    public Guid ParentId { get; set; }
}
