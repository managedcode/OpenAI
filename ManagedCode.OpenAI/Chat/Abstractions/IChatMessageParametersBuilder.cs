using ManagedCode.OpenAI.Client;

namespace ManagedCode.OpenAI.Chat
{
    public interface IChatMessageParametersBuilder
    {
        public IChatMessageParametersBuilder SetModel(string modelId);
        public IChatMessageParametersBuilder SetModel(GptModel model);
        public IChatMessageParametersBuilder SetRole(string role);
        public IChatMessageParametersBuilder SetRole(RoleType role);
        public IChatMessageParametersBuilder SetMaxTokens(int maxTokens);
        public IChatMessageParametersBuilder SetTemperature(float temperature);
        public IChatMessageParametersBuilder SetNucleus(float value);
        public IChatMessageParametersBuilder SetStream();
        public IChatMessageParametersBuilder SetPresencePenalty(float number);
        public IChatMessageParametersBuilder SetFrequencyPenalty(float number);
        public IChatMessageParametersBuilder SetLogitBias(Dictionary<string, int> dictionary);
        public IChatMessageParametersBuilder SetLogitBias(string key, int value);
        public IChatMessageParametersBuilder SetUser(string user);

        public IChatMessageParameters Build();
    }
}
