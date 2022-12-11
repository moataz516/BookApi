using AutoMapper;
using Book.Data;
using Book.Models;

namespace Book.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>();
        }
    }
}
