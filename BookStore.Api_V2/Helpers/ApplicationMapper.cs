using AutoMapper;
using BookStore.Api_V2.Data;
using BookStore.Api_V2.Models;

namespace BookStore.Api_V2.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();
        }
    }
}
