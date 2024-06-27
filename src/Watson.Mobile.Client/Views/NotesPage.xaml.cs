using Microsoft.Extensions.Options;
using Watson.Mobile.Client.Models.Note;
using Watson.Mobile.Client.Options;
using Watson.Mobile.Client.Services;

namespace Watson.Mobile.Client.Views;

public partial class NotesPage : ContentPage
{
	private readonly NoteService _noteService;
	private List<Note> _notes;
	private readonly SignalRService _signalRService;
	private bool _isUpdating;  // Add a flag to manage the state

	public NotesPage(IOptions<ApiSettings> apiSettings)
	{
		InitializeComponent();
		_noteService = new NoteService(apiSettings);
		_signalRService = new SignalRService(apiSettings);
		_signalRService.NoteUpdated += OnNoteUpdated;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await _signalRService.StartAsync();
		await LoadNotesAsync();
	}

	protected override async void OnDisappearing()
	{
		base.OnDisappearing();
		await _signalRService.StopAsync();
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

	private async void OnNoteUpdated(string noteId)
	{
		var updatedNote = await _noteService.GetNoteByIdAsync(noteId);

		var noteIndex = _notes.FindIndex(n => n.Guid == noteId);
		if (noteIndex >= 0)
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				_notes[noteIndex] = updatedNote;
				NotesCollectionView.ItemsSource = null;
				NotesCollectionView.ItemsSource = _notes;
			});
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
	private async void OnTraceTypeChanged(object sender, EventArgs e)
	{
		if (_isUpdating)
			return;

		try
		{
			_isUpdating = true;

			var picker = sender as Picker;
			var note = picker.BindingContext as Note;

			if (picker.SelectedItem is TraceTypes selectedTraceType)
			{
				note.TraceType = selectedTraceType;
				await UpdateNoteAsync(note);
			}
		}
		finally
		{
			_isUpdating = false;
		}
	}

	private async Task UpdateNoteAsync(Note updatedNote)
	{
		try
		{
			await _noteService.UpdateNoteAsync(updatedNote);
			await DisplayAlert("Success", "Note updated successfully", "OK");
		}
		catch (Exception ex)
		{
			await DisplayAlert("Error", $"Failed to update note: {ex.Message}", "OK");
		}
	}

	private async void OnAddImageClicked(object sender, EventArgs e)
	{
		NoteImage image = new NoteImage();
		var note = (sender as Button).BindingContext as Note;
		var result = await FilePicker.PickAsync(new PickOptions
		{
			FileTypes = FilePickerFileType.Images,
			PickerTitle = "Pick an image"
		});

		if (result != null)
		{
			using (var stream = await result.OpenReadAsync())
			{
				using (var memoryStream = new MemoryStream())
				{
					await stream.CopyToAsync(memoryStream);
					image.NoteId = note.Guid;
					image.ImageBase64 = Convert.ToBase64String(memoryStream.ToArray());
				}
			}

			await _noteService.UploadImageAsync(image);
		}
	}
}