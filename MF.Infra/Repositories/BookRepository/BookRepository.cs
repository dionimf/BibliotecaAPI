using MF.Domain.Entities.Book;
using MF.Domain.Interfaces;
using MF.Infra.Context;
using MF.Infra.Repositories.GenericRepository;
namespace MF.Infra.Repositories.BookRepository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}