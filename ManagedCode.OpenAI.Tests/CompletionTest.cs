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
using OpenAI.Api.Client.Completions;

namespace ClientTest
{
    public class CompletionTest
    {
        private OpenAIClient _client;
        private readonly Fixture _fixture;
        private readonly Mock<IChatClient> _chatClientMock;
        private const string ModelId = "test_model";

        public CompletionTest()
        {
            _client = OpenAIClient.Create("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");
            _fixture = new Fixture();
            _chatClientMock = new Mock<IChatClient>();
        }

        #region SetPropmt

        [Fact]
        public void SetPrompt_ShouldSetPromptPropertyToStringArray_GivenValidStringArrayInput()
        {
            // Arrange
            var builder = new CompletionsBuilder(new OpenAIClient(), ModelId);
            var prompt = new string[] { "Hello", "world", "!" };

            // Act
            var result = builder.SetPrompt(prompt);

            // Assert
            Assert.Equal(prompt, result._completion.Prompt);
        }

        [Fact]
        public void SetPrompt_ShouldSetPromptPropertyToStringArrayWithSingleElement_GivenValidStringInput()
        {
            // Arrange
            var builder = new CompletionsBuilder(new OpenAIClient(), ModelId);
            var prompt = "Hello world!";

            // Act
            var result = builder.SetPrompt(prompt);

            // Assert
            Assert.Single(result._completion.Prompt);
            Assert.Equal(prompt, result._completion.Prompt[0]);
        }

        [Fact]
        public void SetPrompt_ShouldThrowArgumentException_GivenInvalidStringInput()
        {
            // Arrange
            var builder = new CompletionsBuilder(new OpenAIClient(), ModelId);
            var prompt = new string('a', 1025);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => builder.SetPrompt(prompt));
        }

        #endregion

        #region SetSuffix

        [Fact]
        public void SetSuffix_Should_SetSuffix_On_CompletionRequest()
        {
            // Arrange
            var apiKey = "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";
            var client = OpenAIClient.Create(apiKey);
            var builder = new CompletionsBuilder(client, "model-id");

            var expectedSuffix = "Expected suffix";

            // Act
            var result = builder.SetSuffix(expectedSuffix);

            // Assert

        }
        #endregion

        #region SetMaxTokens
        [Fact]
        public void SetMaxTokens_ThrowsExceptionWhenMaxTokensIsLessThanZero()
        {
        // Arrange
            var client = new OpenAIClient();
        var builder = new CompletionsBuilder(client, "model_id");
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
            var builder = new CompletionsBuilder(client, "model_id");
            var temperature = -1f;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.SetTemperature(temperature));
        }

        [Fact]
        public void SetTemperature_ThrowsExceptionTemperatureIsGreaterThanTwo()
        {
            // Arrange
            var client = new OpenAIClient();
            var builder = new CompletionsBuilder(client, "model_id");
            var temperature = 2.1f;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.SetTemperature(temperature));
        }
        #endregion       

        #region SetRequestResult
        [Fact]
        public void SetRequestResult_SetsNValue()
        {
            // Arrange
            var builder = new CompletionsBuilder(_client, "model-id");
            int nValue = 3;

            // Act
            var result = builder.SetRequestResult(nValue);

            // Assert
            Assert.Equal(nValue, result._completion.N);
        }
        #endregion

        #region UseStream
        [Fact]
        public void UseStream_SetsStreamValueToTrue()
        {
            // Arrange
            var builder = new CompletionsBuilder(_client, "model-id");

            // Act
            var result = builder.UseStream();

            // Assert
            Assert.True(result._completion.Stream);
        }
        #endregion

        #region SetLogProbs

        [Fact]
        public void SetLogProbs_Should_SetLogprobs_On_CompletionRequest()
        {
            // Arrange
            var apiKey = "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";
            var client = OpenAIClient.Create(apiKey);
            var builder = new CompletionsBuilder(client, "model-id");

            var expectedLogprobs = 10;

            // Act
            var result = builder.SetLogProbs(expectedLogprobs);

            // Assert
            Assert.Equal(expectedLogprobs, result._completion.Logprobs);
        }

        [Fact]
        public void SetLogProbs_Should_Throw_ArgumentOutOfRangeException_If_Count_Is_Negative()
        {
            // Arrange
            var apiKey = "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";
            var client = OpenAIClient.Create(apiKey);
            var builder = new CompletionsBuilder(client, "model-id");

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.SetLogProbs(-1));
        }

        #endregion

        #region UseEcho    

        [Fact]
        public void UseEcho_Should_SetEcho_To_True_On_CompletionRequest()
        {
            // Arrange
            var apiKey = "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";
            var client = OpenAIClient.Create(apiKey);
            var builder = new CompletionsBuilder(client, "model-id");

            // Act
            var result = builder.UseEcho();

            // Assert
            Assert.True(result._completion.Echo);
        }

        #endregion

        #region SetStop      

        [Fact]
        public void SetStop_Should_SetStop_To_Single_Element_Array_On_CompletionRequest()
        {
            // Arrange
            var apiKey = "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";
            var client = OpenAIClient.Create(apiKey);
            var builder = new CompletionsBuilder(client, "model-id");
            var stop = "stop";

            // Act
            var result = builder.SetStop(stop);

            // Assert
            Assert.Equal(new string[] { stop }, result._completion.Stop);
        }

        #endregion

        #region SetPresencePenalty
        [Fact]
        public void SetPresencePenalty_SetsPenalty_WhenNumberInRange()
        {
            // Arrange
            var builder = new CompletionsBuilder(null, null);
            var penalty = -1.0f;

            // Act
            builder.SetPresencePenalty(penalty);

            // Assert
            Assert.Equal(penalty, builder._completion.PresencePenalty);
        }

        [Theory]
        [InlineData(-2.1f)]
        [InlineData(2.1f)]
        public void SetPresencePenalty_ThrowsArgumentOutOfRangeException_NumberOutOfRange(float penalty)
        {
            // Arrange
            var builder = new CompletionsBuilder(null, null);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.SetPresencePenalty(penalty));
        }
        #endregion

        #region SetFrequencyPenalty

        [Fact]
        public void SetFrequencyPenalty_SetsPenalty_NumberInRange()
        {
            // Arrange
            var builder = new CompletionsBuilder(null, null);
            var penalty = -1.0f;

            // Act
            builder.SetFrequencyPenalty(penalty);

            // Assert
            Assert.Equal(penalty, builder._completion.FrequencyPenalty);
        }

        [Theory]
        [InlineData(-2.1f)]
        [InlineData(2.1f)]
        public void SetFrequencyPenalty_ThrowsArgumentOutOfRangeException_NumberOutOfRange(float penalty)
        {
            // Arrange
            var builder = new CompletionsBuilder(null, null);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.SetFrequencyPenalty(penalty));
        }
        #endregion

        #region SetBestOf

        [Fact]
        public void SetBestOf_Should_SetBestOf_To_Given_Integer_On_CompletionRequest()
        {
            // Arrange
            var apiKey = "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";
            var client = OpenAIClient.Create(apiKey);
            var builder = new CompletionsBuilder(client, "model-id");
            var integer = 3;

            // Act
            var result = builder.SetBestOf(integer);

            // Assert
            Assert.Equal(integer, result._completion.BestOf);
        }

        [Fact]
        public void SetBestOf_Should_Throw_Exception_Integer_Less_Than_Or_Equal_To_Zero()
        {
            // Arrange
            var apiKey = "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";
            var client = OpenAIClient.Create(apiKey);
            var builder = new CompletionsBuilder(client, "model-id");
            var integer = 0;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.SetBestOf(integer));
        }

        [Fact]
        public void SetBestOf_Should_Throw_Exception_Stream_Is_True()
        {
            // Arrange
            var apiKey = "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";
            var client = OpenAIClient.Create(apiKey);
            var builder = new CompletionsBuilder(client, "model-id");
            builder.UseStream();
            var integer = 3;

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => builder.SetBestOf(integer));
        }

        #endregion

        #region SetLogitBias

        [Fact]
        public void SetLogitBias_SetsLogitBias_DictionaryNotNull()
        {
            // Arrange
            var builder = new CompletionsBuilder(null, null);
            var logitBias = new Dictionary<string, int>()
        {
            { "key1", 1 },
            { "key2", 2 }
        };

            // Act
            builder.SetLogitBias(logitBias);

            // Assert
            Assert.Equal(logitBias, builder._completion.LogitBias);
        }

        [Fact]
        public void SetLogitBias_ReplacesLogitBias_DictionaryNotNull()
        {
            // Arrange
            var builder = new CompletionsBuilder(null, null);
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
            Assert.Equal(newLogitBias, builder._completion.LogitBias);
        }
        #endregion

        #region AddLogitBias

        #endregion

        #region SetUser

        [Fact]
        public void SetUser_SetsUserValue()
        {
            // Arrange
            var builder = new CompletionsBuilder(new OpenAIClient(), "model-id");
            var expectedUser = "test-user";

            // Act
            builder.SetUser(expectedUser);
            var result = builder._completion.User;

            // Assert
            Assert.Equal(expectedUser, result);
        }
        #endregion

        #region Send

        [Fact]
        public async Task Send_ValidRequest_ReturnsChatCompletion()
        {
            // Arrange
            var apiKey = "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";
            var client = OpenAIClient.Create(apiKey);
            var builder = new CompletionsBuilder(client, "test-model-id")
                .SetUser("user");

            // Act
            var result = await builder.Send();

            // Assert
            Assert.NotNull(result);
        }

        #endregion

        #region Clear
        [Fact]
        public void Clear_WithModel_ShouldSetModel()
        {
            var model = new Model { Id = "model-id" };
            var chatRequestBuilder = new CompletionsBuilder(_client, "default-model-id");

            // Act
            chatRequestBuilder.Clear(model);

            // Assert
            Assert.Equal(model.Id, chatRequestBuilder._completion.Model);
        }       

        [Fact]
        public void Clear_ShouldReturnSameInstance()
        {
            // Arrange
            var chatRequestBuilder = new CompletionsBuilder(_client, "default-model-id");

            // Act
            var result = chatRequestBuilder.Clear("new-model-id");

            // Assert
            Assert.Equal(chatRequestBuilder, result);
        }

        [Fact]
        public void Clear_Should_Return_Same_Instance()
        {
            // Arrange
            var apiKey = "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";
            var client = OpenAIClient.Create(apiKey);
            var builder = new CompletionsBuilder(client, "model-id");

            // Act
            var result = builder.Clear("new-model-id");

            // Assert
            Assert.Equal(builder, result);
        }

        [Fact]
        public void Clear_With_Model_Should_Return_Same_Instance()
        {
            // Arrange
            var apiKey = "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";
            var client = OpenAIClient.Create(apiKey);
            var model = new Model { Id = "model-id" };
            var builder = new CompletionsBuilder(client, model.ToString());

            // Act
            var result = builder.Clear(model);

            // Assert
            Assert.Equal(builder, result);
        }

        [Fact]
        public void Clear_Should_Set_Model_Id()
        {
            // Arrange
            var apiKey = "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";
            var client = OpenAIClient.Create(apiKey);
            var builder = new CompletionsBuilder(client, "model-id");

            // Act
            var result = builder.Clear("new-model-id");

            // Assert
            Assert.Equal("new-model-id", result._completion.Model);
        }

        [Fact]
        public void Clear_With_Model_Should_Set_Model_Id()
        {
            // Arrange
            var apiKey = "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";
            var client = OpenAIClient.Create(apiKey);
            var model = new Model { Id = "model-id" };
            var builder = new CompletionsBuilder(client, model.ToString());

            // Act
            var result = builder.Clear(model);

            // Assert
            Assert.Equal(model.Id, result._completion.Model);
        }


        [Fact]
        public void Clear_Should_Reset_Prompt()
        {
            // Arrange
            var apiKey = "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";
            var client = OpenAIClient.Create(apiKey);
            var builder = new CompletionsBuilder(client, "model-id")
                .SetPrompt("Hello, world!");

            // Act
            var result = builder.Clear("new-model-id");

            // Assert
            Assert.Null(result._completion.Prompt);
        }

        [Fact]
        public void Clear_With_Model_Should_Reset_Prompt()
        {
            // Arrange
            var apiKey = "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";
            var client = OpenAIClient.Create(apiKey);
            var model = new Model{ Id = "model-id" };
            var builder = new CompletionsBuilder(client, model.ToString())
                .SetPrompt("Hello, world!");

            // Act
            var result = builder.Clear(model);

            // Assert
            Assert.Null(result._completion.Prompt);
        }

        [Fact]
        public void Clear_Should_Reset_Suffix()
        {
            // Arrange
            var apiKey = "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";
            var client = OpenAIClient.Create(apiKey);
            var builder = new CompletionsBuilder(client, "model-id")
                .SetSuffix("...");

            // Act
            var result = builder.Clear("new-model-id");

            // Assert
            Assert.Null(result._completion.Suffix);
        }

        [Fact]
        public void Clear_With_Model_Should_Reset_Suffix()
        {
            // Arrange
            var apiKey = "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";
            var client = OpenAIClient.Create(apiKey);
            var model = new Model{ Id = "model-id" };
            var builder = new CompletionsBuilder(client, model.ToString())
                .SetSuffix("...");

            // Act
            var result = builder.Clear(model);

            // Assert
            Assert.Null(result._completion.Suffix);
        }

        #endregion

    }
}
