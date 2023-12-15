using AutoFixture;
using RecipeAPI.Models;

namespace NoteAPI.Models
{
    public static class Seeder
    {
        public static void Seed(this NoteContext noteContext)
        {
            if (!noteContext.note.Any())
            {
                Fixture fixture = new Fixture();
                fixture.Customize<Note>(note => note.Without(p => p.Id));
                //--- The next two lines add 100 rows to your database
                List<Note> notes = fixture.CreateMany<Note>(10).ToList();
                noteContext.AddRange(notes);
                noteContext.SaveChanges();
            }
        }
    }
}
