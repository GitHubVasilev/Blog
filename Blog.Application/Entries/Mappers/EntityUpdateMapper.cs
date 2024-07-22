using Blog.Application.Entries.ViewModels;
using Blog.Application.Interfaces;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Entries.Mappers;

public class EntityUpdateMapper : ICustomMapper<Entity, EntityUpdateViewModel>
{
    /// <summary>
    /// Конвертирует модель представления <see cref="EntityUpdateViewModel"> в модель <see cref="Entity"/> 
    /// </summary>
    /// <param name="viewModel">Модель представления <see cref="EntityUpdateViewModel"></param>
    /// <returns>модель <see cref="Entity"/></returns>
    public Entity ToModel(EntityUpdateViewModel viewModel)
    {
        return new Entity
        {
            Id = viewModel.Id,
            Title = viewModel.Title,
            Content = viewModel.Content
        };
    }

    /// <summary>
    /// Конвертирует модель <see cref="Entity"/> в модель представления <see cref="EntityUpdateViewModel">
    /// </summary>
    /// <param name="model">модель <see cref="Entity"/></param>
    /// <returns>Модель представления <see cref="EntityUpdateViewModel"></returns>
    public EntityUpdateViewModel ToViewModel(Entity model)
    {
        return new EntityUpdateViewModel
        {
            Id = model.Id,
            Title = model.Title,
            Content = model.Content
        };
    }
}
