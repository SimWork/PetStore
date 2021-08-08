using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace PetStore.Models
{
    public class Pet
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("category")]
        public Category? Category { get; set; }

        [JsonPropertyName("photoUrls")]
        public List<string>? PhotoUrl { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("tags")]
        public List<Tags>? Tags { get; set; }
    }
}
