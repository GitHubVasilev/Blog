using AutoMapper;

namespace Blog.Domain.Mappings
{
    /// <summary>
    /// Интерфейс для маппинга моделей
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMapWith<T>
    {
        /// <summary>
        /// Метод с конфигурацией исходного типа
        /// </summary>
        /// <param name="profile"></param>
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
