using System.Text.Json;

namespace ManagedCode.OpenAI.Chats.Enums;

public class JsonNamingPolicyDecorator : JsonNamingPolicy 
{
    readonly JsonNamingPolicy underlyingNamingPolicy;
    
    public JsonNamingPolicyDecorator(JsonNamingPolicy underlyingNamingPolicy) 
        => this.underlyingNamingPolicy = underlyingNamingPolicy;

    public override string ConvertName (string name) => 
        underlyingNamingPolicy?.ConvertName(name) ?? name;
}