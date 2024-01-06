namespace Blog.Domain.Base
{
    /// <summary>
    /// Интерфейс модели с данными дерева
    /// </summary>
    public interface IModelTree : IHaveId
    {
        /// <summary>
        /// Идентификатор родительского элемента
        /// </summary>
        Guid? ParentId { get; set; }
    }
}
