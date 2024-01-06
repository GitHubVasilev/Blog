using Blog.Application.Categories.ViewModels;
using Blog.Application.Interfaces;
using Blog.Domain;

namespace Blog.Application.Categories.Mappers
{
    /// <summary>
    /// Класс для преобразования данных моделей <see cref="Category"/> и моделей представления <see cref="CategoryViewModel">
    /// </summary>
    public class CategoryGetMapper : ICustomMapper<Category, CategoryViewModel>
    {
        /// <summary>
        /// Конвертирует модель представления <see cref="CategoryViewModel"> в модель <see cref="Category"/> 
        /// </summary>
        /// <param name="viewModel">Модель представления <see cref="CategoryViewModel"></param>
        /// <returns>модель <see cref="Category"/></returns>
        public Category ToModel(CategoryViewModel viewModel) 
        {
            return new Category
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                ParentId = viewModel.Parent?.Id,
                IsVisible = viewModel.IsVisible,
            };
        }
        /// <summary>
        /// Конвертирует модель <see cref="Category"/> в модель представления <see cref="CategoryViewModel">
        /// </summary>
        /// <param name="category">модель <see cref="Category"/></param>
        /// <returns>Модель представления <see cref="CategoryViewModel"></returns>
        public CategoryViewModel ToViewModel(Category model) 
        {
            return new CategoryViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                IsVisible = model.IsVisible,
                Child = new List<CategoryViewModel>()
            };
        }
    }
}
