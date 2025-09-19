using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Books.DTOs;
using MediatR;

namespace Application.Features.Books.Commands
{
    public class UpdateBookCommand : IRequest<UpdateBookResponse>
    {
        public int Id { get; }
        public UpdateBookRequest Request { get; }

        public UpdateBookCommand(int id, UpdateBookRequest request)
        {
            Id = id;
            Request = request;
        }
    }
}
