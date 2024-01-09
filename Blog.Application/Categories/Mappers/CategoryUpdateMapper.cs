using Blog.Application.Categories.ViewModels;
using Blog.Application.Interfaces;
using Blog.Domain;

namespace Blog.Application.Categories.Mappers
{
    /// <summary>
    /// Класс для преобразования данных моделей <see cref="Category"/> и моделей представления <see cref="CategoryUpdateViewModel">
    /// </summary>
    public class CategoryUpdateMapper : ICustomMapper<Category, CategoryUpdateViewModel>
    {
        /// <summary>
        /// Конвертирует модель представления <see cref="CategoryUpdateViewModel"> в модель <see cref="Category"/> 
        /// </summary>
        /// <param name="viewModel">Модель представления <see cref="CategoryGetViewModel"></param>
        /// <returns>модель <see cref="Category"/></returns>
        public Category ToModel(CategoryUpdateViewModel viewModel)
        {
            return new Category
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                IsVisible = viewModel.IsVisible,
                ParentId = viewModel.ParentId
            };
        }
        /// <summary>
        /// Конвертирует модель <see cref="Category"/> в модель представления <see cref="CategoryUpdateViewModel">
        /// </summary>
        /// <param name="category">модель <see cref="Category"/></param>
        /// <returns>Модель представления <see cref="CategoryUpdateViewModel"></returns>
        public CategoryUpdateViewModel ToViewModel(Category model)
        {
            return new CategoryUpdateViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                IsVisible = model.IsVisible,
                ParentId = model.ParentId
            };
        }
    }
}
