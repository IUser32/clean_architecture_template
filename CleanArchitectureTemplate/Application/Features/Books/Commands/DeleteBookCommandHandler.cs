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
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(request.Id);

            if (book == null)
                throw new KeyNotFoundException("El libro no fue encontrado.");

            await _unitOfWork.Books.DeleteAsync(book);

            await _unitOfWork.SaveChangesAsync();

            return "Libro eliminado correctamente.";
        }
    }
}
