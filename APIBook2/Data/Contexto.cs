using APIBook2.Model;
using Microsoft.EntityFrameworkCore;

namespace APIBook2.Data
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        public DbSet<Livro> Livros { get; set; }
    }
}
