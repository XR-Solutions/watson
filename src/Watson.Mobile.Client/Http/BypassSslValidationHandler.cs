namespace Watson.Mobile.Client.Http
{
	public class BypassSslValidationHandler : HttpClientHandler
	{
		protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			// Bypass SSL certificate validation
			ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
			return base.Send(request, cancellationToken);
		}
	}
}
