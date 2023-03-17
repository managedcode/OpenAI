using Newtonsoft.Json;

namespace ManagedCode.OpenAI.Client.Models;

public class Permission
{
    [JsonProperty("id")]
    public string Id;

    [JsonProperty("object")]
    public string Object;

    [JsonProperty("created")]
    public int Created;

    [JsonProperty("allow_create_engine")]
    public bool AllowCreateEngine;

    [JsonProperty("allow_sampling")]
    public bool AllowSampling;

    [JsonProperty("allow_logprobs")]
    public bool AllowLogprobs;

    [JsonProperty("allow_search_indices")]
    public bool AllowSearchIndices;

    [JsonProperty("allow_view")]
    public bool AllowView;

    [JsonProperty("allow_fine_tuning")]
    public bool AllowFineTuning;

    [JsonProperty("organization")]
    public string Organization;

    [JsonProperty("group")]
    public object Group;

    [JsonProperty("is_blocking")]
    public bool IsBlocking;
}