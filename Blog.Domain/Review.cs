using Blog.Domain.Base;

namespace Blog.Domain;

/// <summary>
/// Модель сущности комментарий
/// </summary>
public class Review : Auditable, IModelTree
{
    /// <summary>
    /// Оценка
    /// </summary>
    public int Rating { get; set; }
    /// <summary>
    /// Текст комментария
    /// </summary>
    public string Content { get; set; } = null!;
    /// <summary>
    /// Статья к которой комментарий принадлежит
    /// </summary>
    public Guid EntityId { get; set; } 
    /// <summary>
    /// Идентификатор родительского комментария
    /// </summary>
    public Guid? ParentId { get; set; }
    /// <summary>
    /// Флаг видимости
    /// </summary>
    public bool IsVisible { get; set; }
}
