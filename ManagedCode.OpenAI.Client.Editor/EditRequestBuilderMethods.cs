using ManagedCode.Methods;
using ManagedCode.OpenAI.Client.Models;

namespace ManagedCode.OpenAI.Client.Editor;

public static class EditRequestBuilderMethods
{
    public static EditRequestBuilder AsEdit(this OpenAIClient client, string modelId, string instruction)
    {
        return new EditRequestBuilder(client).Clear(modelId, instruction);
    }
    
    public static EditRequestBuilder AsEdit(this OpenAIClient client, Model model, string instruction)
    {
        return AsEdit(client, model.Id, instruction);
    }
    
    public static EditRequestBuilder AsEdit(this OpenAIClient client, EditModel model, string instruction)
    {
        return AsEdit(client, model.GetDescription(), instruction);
    }

    
}