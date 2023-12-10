using Notes.ApiClient.Models;
using Notes.ApiClient.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Notes.ApiClient
{
    public class NotesApiClientService
    {
        private readonly HttpClient _httpClient;

        public NotesApiClientService(ApiClientOptions apiClientOptions)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(apiClientOptions.ApiBaseAddress);
        }
        public async Task<List<Note>?> GetNotes()
        {
            return await _httpClient.GetFromJsonAsync<List<Note>?>("/api/Notes");
        }

        public async Task<Note?> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Note?>($"/api/Notes/{id}");
        }

        public async Task SaveNote(Note note)
        {
            await _httpClient.PostAsJsonAsync("/api/Notes", note);
        }

        public async Task UpdateNote(Note note)
        {
            await _httpClient.PutAsJsonAsync("/api/Notes", note);
        }

        public async Task DeleteNote(int id)
        {
            await _httpClient.DeleteAsync($"/api/Notes/{id}");
        }
    }
}
