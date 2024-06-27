namespace Watson.Adapter.OpenAI.Models
{
    public class CreateAudioRequest
    {
        public string Input { get; set; } = "";
        public string Voice { get; set; } = "onyx";
        public string Model { get; set; } = "tts-1";
    }
}
