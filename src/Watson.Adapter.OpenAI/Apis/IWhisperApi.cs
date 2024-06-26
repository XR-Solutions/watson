﻿using Refit;
using Watson.Adapter.OpenAI.Models;

namespace Watson.Adapter.OpenAI.Apis
{
    public interface IWhisperApi
    {
        [Multipart]
        [Post("/v1/audio/transcriptions")]
        Task<WhisperTranscribeResponse> TranscribeAudio
            (
                [AliasAs("file")] StreamPart audioStream,
                [AliasAs("model")] string model = "whisper-1"
            );

    }
}
