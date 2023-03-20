using ManagedCode.OpenAI.Client;
using ManagedCode.OpenAI.Editor.Enums;
using ManagedCode.OpenAI.Models;

namespace ManagedCode.OpenAI.Editor;

public static class EditRequestBuilderMethods
{
    public static EditRequestBuilder CreateEditBuilder(this OpenAIClient client, EditModel model, string instruction)
    {
        return new EditRequestBuilder(client, model, instruction);
    }
    
    
}