using System.ComponentModel.DataAnnotations;

namespace Watson.Mobile.Client.Options
{
    public class Auth0Settings
    {
        [Required]
        public string Domain { get; set; }

        [Required]
        public string ClientId { get; set; }

        [Required]
        public string Scope { get; set; }
    }
}
