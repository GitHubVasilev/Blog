using Blog.Application.Interfaces;
using Blog.Application.Reviews.ViewModels;
using Blog.Domain;

namespace Blog.Application.Reviews.Mappers;

public class ReviewCreateMapper : ICustomMapper<Review, ReviewCreateViewModel>
{
    public Review ToModel(ReviewCreateViewModel viewModel)
    {
        throw new NotImplementedException();
    }

    public ReviewCreateViewModel ToViewModel(Review model)
    {
        throw new NotImplementedException();
    }
}
