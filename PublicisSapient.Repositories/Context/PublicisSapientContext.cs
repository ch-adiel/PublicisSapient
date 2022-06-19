using Microsoft.EntityFrameworkCore;
using PublicisSapient.Models;

namespace PublicisSapient.Repositories.Context
{
    public partial class PublicisSapientContext : DbContext
    {
        public PublicisSapientContext(DbContextOptions<PublicisSapientContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CreditCard> CreditCards { get; set; }
    }
}
