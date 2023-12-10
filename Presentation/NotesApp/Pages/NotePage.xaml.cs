using Notes.ApiClient;
using Notes.ApiClient.Models.ApiModels;

namespace NotesApp.Pages;

public partial class NotePage : ContentPage
{
	private readonly NotesApiClientService _notesApiClientService;
	private Note _note;
	public NotePage(NotesApiClientService apiClient, Note note)
	{
		InitializeComponent();

		_notesApiClientService = apiClient;
		_note = note;
		LoadNoteDetails();

    }

	private void LoadNoteDetails()
	{
		if (_note is not null)
		{
			TextEditor.Text = _note.Text;
		}
	}

    private async void ButtonSave_Clicked(object sender, EventArgs e)
    {
        if (_note is null)
        {
            await _notesApiClientService.SaveNote(new Note 
			{
                Text = TextEditor.Text,
                Date = DateTime.Now
            });
        }
		else
		{
			await _notesApiClientService.UpdateNote(new Note
			{
				Id = _note.Id,
				Text = TextEditor.Text,
				Date = DateTime.Now
			});
		}
		await Navigation.PopModalAsync();
    }

    private async void ButtonCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}