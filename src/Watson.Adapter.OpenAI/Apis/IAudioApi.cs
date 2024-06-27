using Refit;
using Watson.Adapter.OpenAI.Models;

namespace Watson.Adapter.OpenAI.Apis
{
    public interface IAudioApi
    {
        [Multipart]
        [Post("/v1/audio/transcriptions")]
        Task<WhisperTranscribeResponse> TranscribeAudio
            (
                [AliasAs("file")] StreamPart audioStream,
                [AliasAs("model")] string model = "whisper-1"
            );

        [Post("/v1/audio/speech")]
        Task<HttpResponseMessage> CreateAudio(CreateAudioRequest request, [Header("Content-Type")] string contentType = "application/json");

    }
}
