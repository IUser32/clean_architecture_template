using Application.Features.Books.Commands;
using Application.Features.Books.DTOs;
using Application.Features.Books.Queries.GetAllBooks;
using Application.Features.Books.Queries.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var query = new GetAllBooksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var query = new GetBookByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest request)
        {
            var command = new CreateBookCommand(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookRequest request)
        {
            var command = new UpdateBookCommand(id, request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var command = new DeleteBookCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
