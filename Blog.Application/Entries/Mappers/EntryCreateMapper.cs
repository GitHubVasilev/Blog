using Blog.Application.Entries.ViewModels;
using Blog.Application.Interfaces;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Entries.Mappers
{
    public class EntryCreateMapper : ICustomMapper<Entry, EntryCreateViewModel>
    {
        /// <summary>
        /// Конвертирует модель представления <see cref="EntryCreateViewModel"> в модель <see cref="Entry"/> 
        /// </summary>
        /// <param name="viewModel">Модель представления <see cref="EntryCreateViewModel"></param>
        /// <returns>модель <see cref="Entry"/></returns>
        public Entry ToModel(EntryCreateViewModel viewModel)
        {
            return new Entry
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Content = viewModel.Content
            };
        }

        /// <summary>
        /// Конвертирует модель <see cref="Entry"/> в модель представления <see cref="EntryCreateViewModel">
        /// </summary>
        /// <param name="model">модель <see cref="Entry"/></param>
        /// <returns>Модель представления <see cref="EntryCreateViewModel"></returns>
        public EntryCreateViewModel ToViewModel(Entry model)
        {
            return new EntryCreateViewModel 
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content
            };
        }
    }
}
