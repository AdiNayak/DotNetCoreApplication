using Microsoft.EntityFrameworkCore;

namespace EBook.Data
{
    public class EBookContext : DbContext
    {
        public EBookContext(DbContextOptions<EBookContext> options) : base(options) { }

        
    }
}
