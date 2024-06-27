namespace Watson.Mobile.Client.Models.Note
{
    public static class TraceTypesEnumValues
    {
        public static IList<TraceTypes> Values =>
            Enum.GetValues(typeof(TraceTypes)).Cast<TraceTypes>().ToList();
    }
}