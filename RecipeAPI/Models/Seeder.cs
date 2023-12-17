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
            }
        }
    }
}
