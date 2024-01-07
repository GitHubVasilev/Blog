using Blog.Domain.Base;

namespace Blog.Application.Common.Exceptions
{
    /// <summary>
    /// Исключение указывает что объект уже существует
    /// </summary>
    public class BlogEntityAlreadyExistsException : Exception
    {
        public BlogEntityAlreadyExistsException(string name, object key)
            : base(string.Format(AppData.AlreadyExists, name, key))
        {
            
        }
    }
}
