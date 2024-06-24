namespace Watson.Mobile.Client.Models
{
	public static class TraceTypesEnumValues
	{
		public static IList<TraceTypes> Values =>
			Enum.GetValues(typeof(TraceTypes)).Cast<TraceTypes>().ToList();
	}
}