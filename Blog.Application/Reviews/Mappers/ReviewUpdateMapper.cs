using Blog.Application.Interfaces;
using Blog.Application.Reviews.ViewModels;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Reviews.Mappers;

/// <summary>
/// Класс для преобразования данных моделей <see cref="Review"/> и моделей представления <see cref="ReviewUpdateViewModel">
/// </summary>
public class ReviewUpdateMapper : ICustomMapper<Review, ReviewUpdateViewModel>
{
    /// <summary>
    /// Конвертирует модель представления <see cref="ReviewCreateViewModel"> в модель <see cref="Review"/> 
    /// </summary>
    /// <param name="viewModel">Модель представления <see cref="ReviewCreateViewModel"></param>
    /// <returns>модель <see cref="Review"/></returns>
    public Review ToModel(ReviewUpdateViewModel viewModel)
    {
        return new Review
        {
            Id = viewModel.Id,
            IsVisible = viewModel.IsVisible,
            Content = viewModel.Content,
            Rating = viewModel.Rating
        };
    }


    /// <summary>
    /// Конвертирует модель <see cref="Review"/> в модель представления <see cref="ReviewGetViewModel">
    /// </summary>
    /// <param name="category">модель <see cref="Review"/></param>
    /// <returns>Модель представления <see cref="ReviewGetViewModel"></returns>
    public ReviewUpdateViewModel ToViewModel(Review model)
    {
        return new ReviewUpdateViewModel
        {
            Id = model.Id,
            IsVisible = model.IsVisible,
            Content = model.Content,
            Rating = model.Rating
        };
    }
}
