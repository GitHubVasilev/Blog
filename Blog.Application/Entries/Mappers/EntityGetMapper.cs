using Blog.Application.Categories.ViewModels;
using Blog.Application.Entries.ViewModels;
using Blog.Application.Interfaces;
using Blog.Domain;

namespace Blog.Application.Entries.Mappers
{
    /// <summary>
    /// Класс для преобразования данных моделей <see cref="Entity"/> и моделей представления <see cref="EntityGetViewModel">
    /// </summary>
    public class EntityGetMapper : ICustomMapper<Entity, EntityGetViewModel>
    {
        private readonly ICustomMapper<Category, CategoryGetViewModel> _categoryMapper;

        public EntityGetMapper(ICustomMapper<Category, CategoryGetViewModel> categoryMapper)
        {
            _categoryMapper = categoryMapper;
        }
        /// <summary>
        /// Конвертирует модель представления <see cref="EntityGetViewModel"> в модель <see cref="Entity"/> 
        /// </summary>
        /// <param name="viewModel">Модель представления <see cref="EntityGetViewModel"></param>
        /// <returns>модель <see cref="Entity"/></returns>
        public Entity ToModel(EntityGetViewModel viewModel)
        {
            return new Entity
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Content = viewModel.Content,
                Category = _categoryMapper.ToModel(viewModel.Category)
            };
        }

        /// <summary>
        /// Конвертирует модель <see cref="Entity"/> в модель представления <see cref="EntityGetViewModel">
        /// </summary>
        /// <param name="model">модель <see cref="Entity"/></param>
        /// <returns>Модель представления <see cref="EntityGetViewModel"></returns>
        public EntityGetViewModel ToViewModel(Entity model)
        {
            return new EntityGetViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content,
                CreatedAt = model.CreatedAt,
                CreatedBy = model.CreatedBy,
                UpdatedAt = model.UpdatedAt,
                UpdatedBy = model.UpdatedBy,
                Category = _categoryMapper.ToViewModel(model.Category)
            };
        }
    }
}
