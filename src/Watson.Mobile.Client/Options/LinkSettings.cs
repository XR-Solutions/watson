using System.ComponentModel.DataAnnotations;

namespace Watson.Mobile.Client.Options
{
    public class LinkSettings
    {
        [Required]
        public string HelpSiteUrl { get; set; }

        [Required]
        public string GitHubRepoUrl { get; set; }
    }
}
