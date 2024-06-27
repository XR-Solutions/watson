using Watson.Application.Interfaces.Repositories;
using Watson.Core.Entities;

namespace Watson.Adapter.Stub.Repositories
{
	public class NoteImageRepositoryStub : INoteImageRepository
	{
		private static readonly List<NoteImage> noteImages = new();

		public Task<NoteImage> AddAsync(NoteImage entity)
		{
			noteImages.Add(entity);
			return Task.FromResult(entity);
		}

		public Task DeleteAsync(NoteImage entity)
		{
			throw new NotImplementedException();
		}

		public Task<IReadOnlyList<NoteImage>> GetAllAsync()
		{
			IReadOnlyList<NoteImage> readOnlyNoteImages = noteImages.AsReadOnly();
			return Task.FromResult(readOnlyNoteImages);
		}

		public Task<NoteImage> GetByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<IReadOnlyList<NoteImage>> GetByNoteIdAsync(string noteId)
		{
			IReadOnlyList<NoteImage> noteImage = noteImages.FindAll(image => image.NoteId == noteId).AsReadOnly();
			return Task.FromResult(noteImage);
		}

		public Task<int> GetCountAsync()
		{
			throw new NotImplementedException();
		}

		public Task<IReadOnlyList<NoteImage>> GetPagedResponseAsync(int page, int pageSize)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(NoteImage entity)
		{
			var existingNoteImage = noteImages.Find(image => image.NoteId == entity.NoteId);
			if (existingNoteImage != null)
			{
				int index = noteImages.IndexOf(existingNoteImage);
				noteImages[index] = entity;
			}
			return Task.CompletedTask;
		}
	}
}
