using Watson.Core.Enums;

namespace Watson.Core.Entities
{
	public class Note
	{
		public string Guid { get; init; }
		public string Name { get; init; }
		public string Description { get; init; }
		public TraceTypes TraceType { get; init; }
		public ObjectMetadata ObjectMetadata { get; init; }
	}
}
