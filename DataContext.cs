using Microsoft.EntityFrameworkCore;
using MvcTaskManager.Models;

namespace MvcTaskManager.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
             
        }
        
       
        public DbSet<Products> Products { get;set; }

    }
}
