using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Application.Interfaces.UnitOfWork;
using Persistence.Context;

namespace Persistence.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBookRepository Books { get; }

        public UnitOfWork(ApplicationDbContext context, IBookRepository bookRepository)
        {
            _context = context;
            Books = bookRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }

}
