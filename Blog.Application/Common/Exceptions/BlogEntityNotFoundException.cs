using Blog.Domain.Base;

namespace Blog.Application.Common.Exceptions
{
    /// <summary>
    /// Исключение указывающее на то, что объект не найден в базе данных
    /// </summary>
    internal class BlogEntityNotFoundException : Exception
    {
        public BlogEntityNotFoundException(string name, object key) 
            : base(string.Format(AppData.NotFoundException, name, key))
        {
            
        }
    }
}
