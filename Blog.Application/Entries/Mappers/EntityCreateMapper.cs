using Blog.Application.Categories.ViewModels;
using Blog.Application.Entries.ViewModels;
using Blog.Application.Interfaces;
using Blog.Domain;

namespace Blog.Application.Entries.Mappers;

public class EntityCreateMapper : ICustomMapper<Entity, EntityCreateViewModel>
{
    private readonly ICustomMapper<Category, CategoryGetViewModel> _categoryMapper;

    public EntityCreateMapper(ICustomMapper<Category, CategoryGetViewModel> categoryMapper)
    {
        _categoryMapper = categoryMapper;
    }
    /// <summary>
    /// Конвертирует модель представления <see cref="EntityCreateViewModel"> в модель <see cref="Entity"/> 
    /// </summary>
    /// <param name="viewModel">Модель представления <see cref="EntityCreateViewModel"></param>
    /// <returns>модель <see cref="Entity"/></returns>
    public Entity ToModel(EntityCreateViewModel viewModel)
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
    /// Конвертирует модель <see cref="Entity"/> в модель представления <see cref="EntityCreateViewModel">
    /// </summary>
    /// <param name="model">модель <see cref="Entity"/></param>
    /// <returns>Модель представления <see cref="EntityCreateViewModel"></returns>
    public EntityCreateViewModel ToViewModel(Entity model)
    {
        return new EntityCreateViewModel 
        {
            Id = model.Id,
            Title = model.Title,
            Content = model.Content,
            Category = _categoryMapper.ToViewModel(model.Category)
        };
    }
}
