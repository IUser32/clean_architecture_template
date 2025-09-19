using Application.Features.Books.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.UnitOfWork;
using MediatR;

namespace Application.Features.Books.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBooksQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _unitOfWork.Books.GetAllAsync();

            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                PublishedAt = b.PublishedAt,
                Price = b.Price
            }).ToList();
        }
    }
}
