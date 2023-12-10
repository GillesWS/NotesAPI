using System;

namespace Notes.ApiClient.Models.ApiModels
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
