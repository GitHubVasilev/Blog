namespace Blog.Domain.Base
{
    /// <summary>
    /// Общий интерфейс для сущностей с идентификатором
    /// </summary>
    public interface IHaveId
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        Guid Id { get; set; }
    }
}
