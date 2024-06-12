using CommunityToolkit.Mvvm.ComponentModel;

namespace Watson.Mobile.Client.ViewModel
{
	public class NotesViewModel : ObservableObject
	{
		//private readonly NoteService _noteService;

		//public ObservableCollection<Note> Notes { get; } = new ObservableCollection<Note>();

		//public ICommand LoadNotesCommand { get; }

		//public NotesViewModel(NoteService noteService)
		//{
		//	_noteService = noteService;
		//	LoadNotesCommand = new AsyncRelayCommand(LoadNotesAsync);
		//}

		//private async Task LoadNotesAsync()
		//{
		//	var notes = await _noteService.GetAllNotesAsync();
		//	Notes.Clear();

		//	foreach (var note in notes)
		//	{
		//		Notes.Add(note);
		//	}
		//}
	}
}
