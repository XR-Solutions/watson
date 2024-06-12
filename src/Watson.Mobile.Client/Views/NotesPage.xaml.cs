using Watson.Mobile.Client.Models;
using Watson.Mobile.Client.Services;

namespace Watson.Mobile.Client.Views;

public partial class NotesPage : ContentPage
{
	private readonly NoteService _noteService;
	private List<Note> _notes;

	public NotesPage()
	{
		InitializeComponent();
		_noteService = new NoteService();
	}

	private async void OnLoadNotesClicked(object sender, EventArgs e)
	{
		await LoadNotesAsync();
	}

	private async Task LoadNotesAsync()
	{
		try
		{
			_notes = await _noteService.GetAllNotesAsync();
			NotesCollectionView.ItemsSource = _notes;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error loading notes: {ex.Message}");
		}
	}

	private async void OnNameCompleted(object sender, EventArgs e)
	{
		var entry = sender as Entry;
		var note = entry.BindingContext as Note;

		await UpdateNoteAsync(note);
	}

	private async void OnDescriptionCompleted(object sender, EventArgs e)
	{
		var entry = sender as Entry;
		var note = entry.BindingContext as Note;

		await UpdateNoteAsync(note);
	}

	private async Task UpdateNoteAsync(Note updatedNote)
	{
		try
		{
			await _noteService.UpdateNoteAsync(updatedNote);
			// Optionally provide feedback to the user
			await DisplayAlert("Success", "Note updated successfully", "OK");
		}
		catch (Exception ex)
		{
			await DisplayAlert("Error", $"Failed to update note: {ex.Message}", "OK");
		}
	}
}