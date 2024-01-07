using Blog.Application.Categories.ViewModels;
using Blog.Application.Interfaces;
using Blog.Domain;

namespace Blog.Application.Categories.Mappers
{
    /// <summary>
    /// Класс для преобразования данных моделей <see cref="Category"/> и моделей представления <see cref="CategoryDetailViewModel">
    /// </summary>
    public class CategoryDetailMapper : ICustomMapper<Category, CategoryDetailViewModel>
    {
        /// <summary>
        /// Конвертирует модель представления <see cref="CategoryDetailViewModel"> в модель <see cref="Category"/> 
        /// </summary>
        /// <param name="viewModel">Модель представления <see cref="CategoryDetailViewModel"></param>
        /// <returns>модель <see cref="Category"/></returns>
        public Category ToModel(CategoryDetailViewModel viewModel)
        {
            return new Category
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                IsVisible = viewModel.IsVisible,
                ParentId = viewModel.Parent?.Id
            };
        }
        /// <summary>
        /// Конвертирует модель <see cref="Category"/> в модель представления <see cref="CategoryDetailViewModel">
        /// </summary>
        /// <param name="category">модель <see cref="Category"/></param>
        /// <returns>Модель представления <see cref="CategoryDetailViewModel"></returns>
        public CategoryDetailViewModel ToViewModel(Category model)
        {
            return new CategoryDetailViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                IsVisible = model.IsVisible
            };
        }
    }
}
