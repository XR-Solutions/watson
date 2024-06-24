using Watson.Mobile.Client.Models.Note;
using Watson.Mobile.Client.Services.Endpoints;

namespace Watson.Mobile.Client.Views;

public partial class NotesView
{
	private readonly NoteService _noteService;
	private List<Note> _notes = [];

	public NotesView()
    {
        _noteService = new NoteService();
        InitializeComponent();
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

	private async void OnPositionCompleted(object sender, EventArgs e)
	{
		var entry = sender as Entry;
		var note = entry.BindingContext as Note;

		// Update note with new position values
		if (float.TryParse(entry.Text, out float value))
		{
			var index = ((StackLayout)entry.Parent).Children.IndexOf(entry);
			note.ObjectMetadata.Position[index] = value;
			await UpdateNoteAsync(note);
		}
	}

	private async void OnRotationCompleted(object sender, EventArgs e)
	{
		var entry = sender as Entry;
		var note = entry.BindingContext as Note;

		// Update note with new rotation values
		if (float.TryParse(entry.Text, out float value))
		{
			var index = ((StackLayout)entry.Parent).Children.IndexOf(entry);
			note.ObjectMetadata.Rotation[index] = value;
			await UpdateNoteAsync(note);
		}
	}

	private async void OnScaleCompleted(object sender, EventArgs e)
	{
		var entry = sender as Entry;
		var note = entry.BindingContext as Note;

		// Update note with new scale values
		if (float.TryParse(entry.Text, out float value))
		{
			var index = ((StackLayout)entry.Parent).Children.IndexOf(entry);
			note.ObjectMetadata.Scale[index] = value;
			Console.WriteLine($"Scale updated: {note.ObjectMetadata.Scale[index]} at index {index}");
			await UpdateNoteAsync(note);
		}
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