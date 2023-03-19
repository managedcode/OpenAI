using System.Text.Json.Serialization;

namespace ManagedCode.OpenAI.Models;

public class Permission
{
    [JsonPropertyName("id")]
    public string Id;

    [JsonPropertyName("object")]
    public string Object;

    [JsonPropertyName("created")]
    public int Created;

    [JsonPropertyName("allow_create_engine")]
    public bool AllowCreateEngine;

    [JsonPropertyName("allow_sampling")]
    public bool AllowSampling;

    [JsonPropertyName("allow_logprobs")]
    public bool AllowLogprobs;

    [JsonPropertyName("allow_search_indices")]
    public bool AllowSearchIndices;

    [JsonPropertyName("allow_view")]
    public bool AllowView;

    [JsonPropertyName("allow_fine_tuning")]
    public bool AllowFineTuning;

    [JsonPropertyName("organization")]
    public string Organization;

    [JsonPropertyName("group")]
    public object Group;

    [JsonPropertyName("is_blocking")]
    public bool IsBlocking;
}