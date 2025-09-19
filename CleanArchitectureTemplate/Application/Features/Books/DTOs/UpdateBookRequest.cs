using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.DTOs
{
    public class UpdateBookRequest
    {
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public DateTime PublishedAt { get; set; }
        public decimal Price { get; set; }
    }
}
