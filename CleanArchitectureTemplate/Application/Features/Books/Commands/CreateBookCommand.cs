using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Books.DTOs;
using MediatR;

namespace Application.Features.Books.Commands
{
    public class CreateBookCommand : IRequest<CreateBookResponse>
    {
        public CreateBookRequest Request { get; set; }

        public CreateBookCommand(CreateBookRequest request)
        {
            Request = request;
        }
    }
}
