namespace Watson.Mobile.Client.Models.Note;

    public class Note
{
	public string Guid { get; init; }
	public string Name { get; init; }
	public string Description { get; init; }
	public TraceTypes TraceType { get; init; }
	public ObjectMetadata ObjectMetadata { get; init; }
}
