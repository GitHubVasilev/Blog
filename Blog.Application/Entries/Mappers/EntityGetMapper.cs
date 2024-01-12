using Blog.Application.Entries.ViewModels;
using Blog.Application.Interfaces;
using Blog.Domain;

namespace Blog.Application.Entries.Mappers
{
    /// <summary>
    /// Класс для преобразования данных моделей <see cref="Entry"/> и моделей представления <see cref="EntryViewModel">
    /// </summary>
    public class EntityGetMapper : ICustomMapper<Entry, EntryViewModel>
    {
        /// <summary>
        /// Конвертирует модель представления <see cref="EntryViewModel"> в модель <see cref="Entry"/> 
        /// </summary>
        /// <param name="viewModel">Модель представления <see cref="EntryViewModel"></param>
        /// <returns>модель <see cref="Entry"/></returns>
        public Entry ToModel(EntryViewModel viewModel)
        {
            return new Entry
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Content = viewModel.Content
            };
        }

        /// <summary>
        /// Конвертирует модель <see cref="Entry"/> в модель представления <see cref="EntryViewModel">
        /// </summary>
        /// <param name="model">модель <see cref="Entry"/></param>
        /// <returns>Модель представления <see cref="EntryViewModel"></returns>
        public EntryViewModel ToViewModel(Entry model)
        {
            return new EntryViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content
            };
        }
    }
}
