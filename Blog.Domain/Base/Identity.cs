namespace Blog.Domain.Base
{
    /// <summary>
    /// Абстрактный класс с индентификатором
    /// </summary>
    public abstract class Identity : IHaveId
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
