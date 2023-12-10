using Microsoft.EntityFrameworkCore;
using RecipeAPI.Models;

namespace NoteAPI.Models
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions<NoteContext> options)
        : base(options)
        {
        }

        public DbSet<Note> note { get; set; } = null!;
    }
}
