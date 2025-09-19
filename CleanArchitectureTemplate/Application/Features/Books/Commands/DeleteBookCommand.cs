using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Books.DTOs;
using MediatR;

namespace Application.Features.Books.Commands
{
    public class DeleteBookCommand : IRequest<string>
    {
        public int Id { get; }

        public DeleteBookCommand(int id)
        {
            Id = id;
        }
    }
}
