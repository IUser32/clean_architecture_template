using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Books.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.UnitOfWork;
using Domain.Entities;
using MediatR;

namespace Application.Features.Books.Commands
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreateBookResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateBookResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Request.Title,
                Author = request.Request.Author,
                PublishedAt = request.Request.PublishedAt,
                Price = request.Request.Price,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Books.AddAsync(book);
            await _unitOfWork.SaveChangesAsync();

            return new CreateBookResponse
            {
                Id = book.Id,
                Message = "Libro creado correctamente."
            };
        }
    }
}
