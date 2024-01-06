using Blog.Domain.Base;

namespace Blog.Application.Interfaces
{
    /// <summary>
    /// Базовый класс модели представления
    /// </summary>
    public class ViewModelBase : IViewModel, IHaveId
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}

