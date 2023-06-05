using AutoMapper;
using BookStore.Api_V2.Data;
using BookStore.Api_V2.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Api_V2.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BookModel>> GetAllbooksAsync()
        {
            var records = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);

        }
        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            return _mapper.Map<BookModel>(book);
        }

        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Titie = bookModel.Titie,
                Description = bookModel.Description,
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task UpdateBookAsync(int bookId, BookModel bookModel)
        {

            var book = new Books()
            {
                Id = bookId,
                Titie = bookModel.Titie,
                Description = bookModel.Description,
            };
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);

            if (book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task  DeleteBookAsync(int bookId )
        {
            var book = new Books() { Id = bookId };

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
