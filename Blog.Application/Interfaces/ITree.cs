namespace Blog.Application.Interfaces
{
    /// <summary>
    /// Интерфейс древовидной структуры
    /// </summary>
    /// <typeparam name="T">Тип модели данных</typeparam>
    public interface ITree<T>
    {
        /// <summary>
        /// Поле ссылка на родительский класс
        /// </summary>
        T? Parent { get; set; }

        /// <summary>
        /// Список дочерних классов
        /// </summary>
        List<T> Child { get; set; }
    }
}
