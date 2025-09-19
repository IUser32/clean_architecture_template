using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Books.DTOs;
using MediatR;

namespace Application.Features.Books.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<BookDto>>
    {
    }
}
