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
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, UpdateBookResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UpdateBookResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(request.Id);

            if (book == null)
                throw new KeyNotFoundException("El libro no fue encontrado.");

            book.Title = request.Request.Title;
            book.Author = request.Request.Author;
            book.PublishedAt = request.Request.PublishedAt;
            book.Price = request.Request.Price;

            await _unitOfWork.Books.UpdateAsync(book);

            await _unitOfWork.SaveChangesAsync();

            return new UpdateBookResponse
            {
                Book = new BookDto { },
                Message = "Libro actualizado correctamente."
            };
        }
    }
}
