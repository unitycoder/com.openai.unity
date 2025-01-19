// Licensed under the MIT License. See LICENSE in the project root for license information.

using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine.Scripting;

namespace OpenAI.Chat
{
    [Preserve]
    public sealed class Delta
    {
        [Preserve]
        internal Delta() { }

        [Preserve]
        public Delta(
            [JsonProperty("role")] Role role,
            [JsonProperty("content")] string content,
            [JsonProperty("refusal")] string refusal,
            [JsonProperty("name")] string name,
            [JsonProperty("function_call")] IReadOnlyList<ToolCall> toolCalls)
        {
            Role = role;
            Content = content;
            Refusal = refusal;
            Name = name;
            ToolCalls = toolCalls;
        }

        /// <summary>
        /// The <see cref="OpenAI.Role"/> of the author of this message.
        /// </summary>
        [Preserve]
        [JsonProperty("role")]
        public Role Role { get; private set; }

        /// <summary>
        /// The contents of the message.
        /// </summary>
        [Preserve]
        [JsonProperty("content", DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Include)]
        public string Content { get; private set; }

        /// <summary>
        /// The refusal message generated by the model.
        /// </summary>
        [Preserve]
        [JsonProperty("refusal")]
        public string Refusal { get; private set; }

        /// <summary>
        /// The tool calls generated by the model, such as function calls.
        /// </summary>
        [Preserve]
        [JsonProperty("tool_calls")]
        public IReadOnlyList<ToolCall> ToolCalls { get; private set; }

        /// <summary>
        /// If the audio output modality is requested, this object contains data about the audio response from the model. 
        /// </summary>
        [Preserve]
        [JsonProperty("audio")]
        public AudioOutput AudioOutput { get; private set; }

        /// <summary>
        /// Optional, The name of the author of this message.<br/>
        /// May contain a-z, A-Z, 0-9, and underscores, with a maximum length of 64 characters.
        /// </summary>
        [Preserve]
        [JsonProperty("name")]
        public string Name { get; private set; }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Content))
            {
                return AudioOutput?.ToString() ?? string.Empty;
            }

            return Content ?? string.Empty;
        }

        public static implicit operator string(Delta delta) => delta?.ToString();
    }
}
