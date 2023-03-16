using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using OpenAI.Api.Client;
using OpenAI.Api.Client.Chats;
using OpenAI.Api.Client.Models;
using OpenAI.Api.Exceptions;
using System;
using System.Net;
using System.Text;
using Assert = Xunit.Assert;
using TheoryAttribute = Xunit.TheoryAttribute;
using AutoFixture;
using System.Linq;
using Xunit;

namespace ClientTest
{
    public class ChatRequestBuilderTests
    {
        private OpenAIClient _client;
        private readonly Fixture _fixture;
        private readonly Mock<IChatClient> _chatClientMock;

        public ChatRequestBuilderTests()
        {
            _client = OpenAIClient.Create("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");
            _fixture = new Fixture();
            _chatClientMock = new Mock<IChatClient>();
        }
        #region AddMessage
        [Fact]
        public void AddMessage_AddsMessageToMessagesList()
        {
            // Arrange
            var client = new OpenAIClient();
            var builder = new ChatRequestBuilder(client, "model_id");
            var message = "Hello";

            // Act
            builder.AddMessage(message);

            // Assert
            Assert.Single(builder._chat.Messages);
            Assert.Equal(RoleType.user.ToString(), builder._chat.Messages[0].Role);
            Assert.Equal(message, builder._chat.Messages[0].Content);
        }
        #endregion

        #region SetMaxTokens
        [Fact]
        public void SetMaxTokens_MaxTokensIsLessThanZero()
        {
            // Arrange
            var client = new OpenAIClient();
            var builder = new ChatRequestBuilder(client, "model_id");
            var maxTokens = -1;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.SetMaxTokens(maxTokens));
        }

        [Fact]
        public void SetMaxTokens_ThrowsExceptionMaxTokensIsGreaterThan2048()
        {
            // Arrange
            var client = new OpenAIClient();
            var builder = new ChatRequestBuilder(client, "model_id");
            var maxTokens = 2049;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.SetMaxTokens(maxTokens));
        }

        [Fact]
        public void SetMaxTokens_SetsMaxTokensInChatRequest()
        {
            // Arrange
            var client = new OpenAIClient();
            var builder = new ChatRequestBuilder(client, "model_id");
            var maxTokens = 100;

            // Act
            builder.SetMaxTokens(maxTokens);

            // Assert
            Assert.Equal(maxTokens, builder._chat.MaxTokens);
        }
        #endregion

        #region SetTemperature
        [Fact]
        public void SetTemperature_ThrowsExceptionTemperatureIsLessThanZero()
        {
            // Arrange
            var client = new OpenAIClient();
            var builder = new ChatRequestBuilder(client, "model_id");
            var temperature = -1f;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.SetTemperature(temperature));
        }

        [Fact]
        public void SetTemperature_ThrowsExceptionTemperatureIsGreaterThanTwo()
        {
            // Arrange
            var client = new OpenAIClient();
            var builder = new ChatRequestBuilder(client, "model_id");
            var temperature = 2.1f;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.SetTemperature(temperature));
        }
        #endregion

        #region SetTopP
        [Fact]
        public void SetTopP_Should_SetTopPValue()
        {
            // Arrange
            var client = new OpenAIClient();
            var builder = new ChatRequestBuilder(client, "modelId");
            var topP = 5;

            // Act
            builder.SetTopP(topP);

            // Assert
            Assert.Equal(topP, builder._chat.TopP);
        }

        #endregion

        #region SetRequestResult
        [Fact]
        public void SetRequestResult_SetsNValue()
        {
            // Arrange
            var builder = new ChatRequestBuilder(_client, "model-id");
            int nValue = 3;

            // Act
            var result = builder.SetRequestResult(nValue);

            // Assert
            Assert.Equal(nValue, result._chat.N);
        }
        #endregion

        #region UseStream
        [Fact]
        public void UseStream_SetsStreamValueToTrue()
        {
            // Arrange
            var builder = new ChatRequestBuilder(_client, "model-id");

            // Act
            var result = builder.UseStream();

            // Assert
            Assert.True(result._chat.Stream);
        }
        #endregion

        #region SetPresencePenalty
        [Fact]
        public void SetPresencePenalty_SetsPenalty_NumberInRange()
        {
            // Arrange
            var builder = new ChatRequestBuilder(null, null);
            var penalty = -1.0f;

            // Act
            builder.SetPresencePenalty(penalty);

            // Assert
            Assert.Equal(penalty, builder._chat.PresencePenalty);
        }

        [Theory]
        [InlineData(-2.1f)]
        [InlineData(2.1f)]
        public void SetPresencePenalty_ThrowsArgumentOutOfRangeException_NumberOutOfRange(float penalty)
        {
            // Arrange
            var builder = new ChatRequestBuilder(null, null);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.SetPresencePenalty(penalty));
        }
        #endregion

        #region SetFrequencyPenalty

        [Fact]
        public void SetFrequencyPenalty_SetsPenalty_NumberInRange()
        {
            // Arrange
            var builder = new ChatRequestBuilder(null, null);
            var penalty = -1.0f;

            // Act
            builder.SetFrequencyPenalty(penalty);

            // Assert
            Assert.Equal(penalty, builder._chat.FrequencyPenalty);
        }

        [Theory]
        [InlineData(-2.1f)]
        [InlineData(2.1f)]
        public void SetFrequencyPenalty_ThrowsArgumentOutOfRangeException_NumberOutOfRange(float penalty)
        {
            // Arrange
            var builder = new ChatRequestBuilder(null, null);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.SetFrequencyPenalty(penalty));
        }
        #endregion

        #region SetLogitBias

        [Fact]
        public void SetLogitBias_SetsLogitBias_DictionaryNotNull()
        {
            // Arrange
            var builder = new ChatRequestBuilder(null, null);
            var logitBias = new Dictionary<string, int>()
        {
            { "key1", 1 },
            { "key2", 2 }
        };

            // Act
            builder.SetLogitBias(logitBias);

            // Assert
            Assert.Equal(logitBias, builder._chat.LogitBias);
        }

        [Fact]
        public void SetLogitBias_ReplacesLogitBias_DictionaryNotNull()
        {
            // Arrange
            var builder = new ChatRequestBuilder(null, null);
            builder.SetLogitBias(new Dictionary<string, int>()
        {
            { "key1", 1 },
            { "key2", 2 }
        });
            var newLogitBias = new Dictionary<string, int>()
        {
            { "key3", 3 }
        };

            // Act
            builder.SetLogitBias(newLogitBias);

            // Assert
            Assert.Equal(newLogitBias, builder._chat.LogitBias);
        }
        #endregion

        #region SetUser

        [Fact]
        public void SetUser_SetsUserValue()
        {
            // Arrange
            var builder = new ChatRequestBuilder(new OpenAIClient(), "model-id");
            var expectedUser = "test-user";

            // Act
            builder.SetUser(expectedUser);
            var result = builder._chat.User;

            // Assert
            Assert.Equal(expectedUser, result);
        }
        #endregion

        #region Send

        [Fact]
        public async Task Send_ValidRequest_ReturnsChatCompletion()
        {
            // Arrange
            var apiKey = "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";//should be valid api key(currently this one is not valid)
            var client = OpenAIClient.Create(apiKey);
            var builder = new ChatRequestBuilder(client, "test-model-id")
                .SetUser("user")
                .AddMessage("test-message");

            // Act
            var result = await builder.Send();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(builder._chat.Messages);
        }

        #endregion

        #region Clear
        [Fact]
        public void Clear_WithModel_ShouldSetModel()
        {
            var model = new Model { Id = "model-id" };
            var chatRequestBuilder = new ChatRequestBuilder(_client, "default-model-id");

            // Act
            chatRequestBuilder.Clear(model);

            // Assert
            Assert.Equal(model.Id, chatRequestBuilder._chat.Model);
        }

        [Fact]
        public void Clear_WithChatModel_ShouldSetModel()
        {
            // Arrange
            var chatModel = ChatModel.Turbo0301;
            var chatRequestBuilder = new ChatRequestBuilder(_client, "default-model-id");

            // Act
            chatRequestBuilder.Clear(chatModel);

            // Assert
            Assert.Equal(chatModel.GetDescription(), chatRequestBuilder._chat.Model);
        }

        [Fact]
        public void Clear_ShouldClearAllFieldsExceptModel()
        {
            // Arrange
            var chatRequestBuilder = new ChatRequestBuilder(_client, "default-model-id");
            chatRequestBuilder
                .AddMessage("hello")
                .SetMaxTokens(100)
                .SetTemperature(0.5f)
                .SetTopP(10)
                .SetRequestResult(5)
                .UseStream()
                .SetPresencePenalty(0.2f)
                .SetFrequencyPenalty(0.3f)
                .SetLogitBias(new Dictionary<string, int> { { "key1", 1 }, { "key2", 2 } })
                .SetUser("user");

            // Act
            chatRequestBuilder.Clear();

            // Assert
            Assert.Equal("default-model-id", chatRequestBuilder._chat.Model);
            Assert.Empty(chatRequestBuilder._chat.Messages);
            Assert.Null(chatRequestBuilder._chat.MaxTokens);
            Assert.Null(chatRequestBuilder._chat.Temperature);
            Assert.Null(chatRequestBuilder._chat.TopP);
            Assert.Null(chatRequestBuilder._chat.N);
            Assert.Null(chatRequestBuilder._chat.Stream);
            Assert.Null(chatRequestBuilder._chat.PresencePenalty);
            Assert.Null(chatRequestBuilder._chat.FrequencyPenalty);
            Assert.Null(chatRequestBuilder._chat.LogitBias);
            Assert.Null(chatRequestBuilder._chat.User);
        }

        [Fact]
        public void Clear_ShouldReturnSameInstance()
        {
            // Arrange
            var chatRequestBuilder = new ChatRequestBuilder(_client, "default-model-id");

            // Act
            var result = chatRequestBuilder.Clear("new-model-id");

            // Assert
            Assert.Equal(chatRequestBuilder, result);
        }

        #endregion

    }
}