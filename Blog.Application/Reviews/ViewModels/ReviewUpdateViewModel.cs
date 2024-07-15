using Blog.Application.Interfaces;


namespace Blog.Application.Reviews.ViewModels;

/// <summary>
/// Модель представления для обновления отзыва <see cref="Review"/>
/// </summary>
public class ReviewUpdateViewModel : ViewModelBase
{
    /// <summary>
    /// Флаг отображения
    /// </summary>
    public bool IsVisible { get; set; }

    /// <summary>
    /// Содержание
    /// </summary>
    public string Content { get; set; } = null!;

    /// <summary>
    /// Оценка
    /// </summary>
    public int Rating { get; set; }
}
