using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Books.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.UnitOfWork;
using MediatR;

namespace Application.Features.Books.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBookByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(request.Id);

            if (book == null)
            {
                throw new KeyNotFoundException("El libro no fue encontrado.");
            }

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                PublishedAt = book.PublishedAt,
                Price = book.Price
            };
        }
    }
}
