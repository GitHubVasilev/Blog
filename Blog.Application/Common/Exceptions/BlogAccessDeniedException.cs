using Blog.Domain.Base;

namespace Blog.Application.Common.Exceptions
{
    /// <summary>
    /// Исключение указывает на отсутствие прав доступа на выполнение операции
    /// </summary>
    public class BlogAccessDeniedException : Exception
    {
        public BlogAccessDeniedException(string operationName) : base(string.Format(AppData.AccessDenied, operationName))
        {
            
        }
    }
}
