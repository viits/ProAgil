using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProAgil.API.Model;

namespace ProAgil.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        
        public DbSet<Evento> Evento { get; set; }      

    }
}