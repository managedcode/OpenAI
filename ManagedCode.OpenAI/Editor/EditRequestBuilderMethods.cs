using ManagedCode.OpenAI.Editor.Enums;
using ManagedCode.OpenAI.Models;

namespace ManagedCode.OpenAI.Editor;

public static class EditRequestBuilderMethods
{
    public static EditRequestBuilder AsEdit(this OpenAIClient.OpenAIClient client, string modelId, string instruction)
    {
        return new EditRequestBuilder(client).Clear(modelId, instruction);
    }
    
    public static EditRequestBuilder AsEdit(this OpenAIClient.OpenAIClient client, Model model, string instruction)
    {
        return AsEdit(client, model.Id, instruction);
    }
    
    public static EditRequestBuilder AsEdit(this OpenAIClient.OpenAIClient client, EditModel model, string instruction)
    {
        return AsEdit(client, model, instruction);
    }

    
}