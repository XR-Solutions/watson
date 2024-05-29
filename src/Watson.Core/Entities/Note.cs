using Watson.Core.Enums;

namespace Watson.Core.Entities
{
	public class Note
	{
		public string Name { get; init; }
		public string Description { get; init; }
		public TraceTypes TraceType { get; init; }
	}
}
