using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.DTOs
{
    public class CreateBookResponse
    {
        public int Id { get; set; }
        public string Message { get; set; } = default!;
    }
}
