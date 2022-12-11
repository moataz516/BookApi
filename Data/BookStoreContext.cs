using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Book.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext>options):base(options)
        {

        }

        public DbSet<Books> Books { set; get; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 94.56.229.181)(PORT = 3488))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = traindb)));User Id=TAH10_USER36;Password=Test321;Persist Security Info=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}

    }
}
