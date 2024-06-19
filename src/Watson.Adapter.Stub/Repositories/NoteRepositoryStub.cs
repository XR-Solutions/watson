using Watson.Core.Entities;
using Watson.Core.Ports;

namespace Watson.Adapter.Stub.Repositories
{
	public class NoteRepositoryStub : INoteRepository
	{
		private static readonly List<Note> notes = [];

		public Task<Core.Entities.Note> AddAsync(Core.Entities.Note entity)
		{
			notes.Add(entity);

			return Task.FromResult(entity);
		}

		public Task DeleteAsync(Core.Entities.Note entity)
		{
			throw new NotImplementedException();
		}

		public Task<IReadOnlyList<Core.Entities.Note>> GetAllAsync()
		{
			IReadOnlyList<Note> readOnlyNotes = notes.AsReadOnly();
			return Task.FromResult(readOnlyNotes);
		}

		public Task<Core.Entities.Note> GetByIdAsync(Guid id)
		{
			var note = notes.Find(note => note.Guid == id.ToString());
			return Task.FromResult(note);
		}

		public Task<int> GetCountAsync()
		{
			throw new NotImplementedException();
		}

		public Task<IReadOnlyList<Core.Entities.Note>> GetPagedResponseAsync(int page, int pageSize)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(Core.Entities.Note entity)
		{
			var existingNote = notes.Find(note => note.Guid == entity.Guid);
			if (existingNote != null)
			{
				int index = notes.IndexOf(existingNote);
				notes[index] = entity;
			}
			return Task.CompletedTask;
		}
	}
}
