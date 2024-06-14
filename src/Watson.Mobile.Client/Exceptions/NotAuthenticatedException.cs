namespace Watson.Mobile.Client.Exceptions
{
    public class NotAuthenticatedException : Exception
    {
        public NotAuthenticatedException(string message) : base(message)
        {
        }

        public NotAuthenticatedException() : base("User is not authenticated")
        {
        }
    }
}
