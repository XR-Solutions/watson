using Watson.Mobile.Client.Services;

namespace Watson.Mobile.Client.Views;

public partial class NotesPage : ContentPage
{
	private readonly NoteService _noteService;

	public NotesPage()
	{
		InitializeComponent();
		_noteService = new NoteService(new HttpClient());
	}

	private async void OnLoadNotesClicked(object sender, EventArgs e)
	{
		await LoadNotesAsync();
	}

	private async Task LoadNotesAsync()
	{
		var notes = await _noteService.GetAllNotesAsync();
		NotesCollectionView.ItemsSource = notes;
	}
}