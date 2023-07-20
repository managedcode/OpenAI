﻿using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Edit;

public interface IEditBuilder
{
    public IEditBuilder SetModel(string modelId);

    public IEditBuilder SetModel(GptModel model);

    public IEditBuilder SetTemperature(float temperature);

    public IEditBuilder SetTopP(float topP);


    public Task<IAnswer<IEditMessage>> ExecuteAsync();

    public Task<IAnswer<IEditMessage[]>> ExecuteMultipleAsync(int count);
}