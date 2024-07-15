using Blog.Application.Interfaces;
using Blog.Application.Reviews.ViewModels;
using Blog.Domain;

namespace Blog.Application.Reviews.Mappers;

/// <summary>
/// Класс для преобразования данных моделей <see cref="Review"/> и моделей представления <see cref="ReviewGetViewModel">
/// </summary>
public class ReviewGetMapper : ICustomMapper<Review, ReviewGetViewModel>
{
    /// <summary>
    /// Конвертирует модель представления <see cref="ReviewGetViewModel"> в модель <see cref="Review"/> 
    /// </summary>
    /// <param name="viewModel">Модель представления <see cref="ReviewGetViewModel"></param>
    /// <returns>модель <see cref="Review"/></returns>
    public Review ToModel(ReviewGetViewModel viewModel)
    {
        return new Review()
        {
            Id = viewModel.Id,
            Content = viewModel.Content,
            ParentId = viewModel.Parent?.Id ?? null,
            IsVisible = viewModel.IsVisible,
            CreatedAt = viewModel.CreatedAt,
            CreatedBy = viewModel.CreatedBy,
            UpdatedAt = viewModel.UpdatedAt,
            UpdatedBy = viewModel.UpdatedBy,
        };
    }

    /// <summary>
    /// Конвертирует модель <see cref="Review"/> в модель представления <see cref="ReviewGetViewModel">
    /// </summary>
    /// <param name="category">модель <see cref="Review"/></param>
    /// <returns>Модель представления <see cref="ReviewGetViewModel"></returns>
    public ReviewGetViewModel ToViewModel(Review model)
    {
        return new ReviewGetViewModel() 
        {
            Id = model.Id,
            Content = model.Content,
            IsVisible = model.IsVisible,
            CreatedAt = model.CreatedAt,
            CreatedBy = model.CreatedBy,
            UpdatedAt = model.UpdatedAt,
            UpdatedBy = model.UpdatedBy,
            Child = new List<ReviewGetViewModel>()
        };
    }
}
