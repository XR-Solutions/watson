using System.ComponentModel.DataAnnotations;

namespace Watson.Adapter.OpenAI.Options
{
    public class OpenAISettings
    {
        [Required]
        public string ModelType { get; set; }
        
        [Required]
        public string ApiKey {  get; set; }
        
        [Required]
        public string WhisperApiUrl { get; set; }
    }
}
