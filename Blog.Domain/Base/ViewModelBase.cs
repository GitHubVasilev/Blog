namespace Blog.Domain.Base
{
    /// <summary>
    /// Базовый класс модели представления
    /// </summary>
    internal class ViewModelBase : IViewModel, IHaveId
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
