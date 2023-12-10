using Notes.ApiClient;
using Notes.ApiClient.Models.ApiModels;
using NotesApp.Pages;

namespace NotesApp
{
    public partial class MainPage : ContentPage
    {
        private readonly NotesApiClientService _notesApiClientService;
        public MainPage(NotesApiClientService notesApiClientService)
        {
            InitializeComponent();
            _notesApiClientService = notesApiClientService;
            this.Appearing += MainPage_Appearing;
        }

        private async Task LoadNotes()
        {
            var notes = await _notesApiClientService.GetNotes();
            notesListView.ItemsSource = notes;
        }

        // Event handler for MainPage appearing
        private async void MainPage_Appearing(object sender, EventArgs e)
        {
            // Load notes every time the MainPage appears
            await LoadNotes();
        }

        private async void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NotePage(_notesApiClientService, null));
        }

        private async void noteListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var note = (Note)e.Item;
            var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");
            switch (action)
            {
                case "Edit":
                    await Navigation.PushModalAsync(new NotePage(_notesApiClientService, note));
                    break;
                case "Delete":
                    await _notesApiClientService.DeleteNote(note.Id);
                    await LoadNotes();
                    break;
            }
        }
    }
}