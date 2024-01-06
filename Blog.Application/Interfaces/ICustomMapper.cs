namespace Blog.Application.Interfaces
{
    /// <summary>
    /// Интерфейс для конвертации данных из модели <see cref="T"> в модель представления <see cref="K"> и обратно
    /// </summary>
    /// <typeparam name="T">Модель данных</typeparam>
    /// <typeparam name="K">Модель представления</typeparam>
    public interface ICustomMapper<T,K>
    {
        /// <summary>
        /// Конвертирует модель представления <see cref="K"> в модель <see cref="T">
        /// </summary>
        /// <param name="viewModel">модель представления <see cref="K"></param>
        /// <returns>модель <see cref="T"></returns>
        T ToModel(K viewModel);
        /// <summary>
        /// Конвертирует модель <see cref="T"> в модель представления <see cref="K">
        /// </summary>
        /// <param name="model"></param>
        /// <returns>модель представления <see cref="K"></returns>
        K ToViewModel(T model);
    }
}
