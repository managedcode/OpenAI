using AutoFixture;
using Moq;
using OpenAI.Api.Client.Chats;
using OpenAI.Api.Client.Completions;
using OpenAI.Api.Client.Models;
using OpenAI.Api.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenAI.Api.Client.Editor;

namespace ClientTest
{
    namespace ClientTest
    {
        public class EditorTest
        {
            private OpenAIClient _client;
            private readonly Fixture _fixture;
            private readonly Mock<IChatClient> _chatClientMock;
            private const string ModelId = "test_model";

            public EditorTest()
            {
                _client = OpenAIClient.Create("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");
                _fixture = new Fixture();
                _chatClientMock = new Mock<IChatClient>();
            }

            #region SetRequestResult
            [Fact]
            public void SetRequestResult_SetsNValue()
            {
                // Arrange
                var builder = new EditRequestBuilder(_client);
                int nValue = 3;

                // Act
                var result = builder.SetRequestResult(nValue);

                // Assert
                Assert.Equal(nValue, result._request.N);
            }
            #endregion

            #region SetTemperature
            [Fact]
            public void SetTemperature_ThrowsExceptionTemperatureIsLessThanZero()
            {
                // Arrange
                var client = new OpenAIClient();
                var builder = new EditRequestBuilder(client);
                var temperature = -1f;

                // Act & Assert
                Assert.Throws<ArgumentOutOfRangeException>(() => builder.SetTemperature(temperature));
            }

            [Fact]
            public void SetTemperature_ThrowsExceptionTemperatureIsGreaterThanTwo()
            {
                // Arrange
                var client = new OpenAIClient();
                var builder = new EditRequestBuilder(client);
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
                var builder = new EditRequestBuilder(client);
                var topP = 5;

                // Act
                builder.SetTopP(topP);

                // Assert
                Assert.Equal(topP, builder._request.TopP);
            }

            #endregion

            #region Send

            [Fact]
            public async Task Send_ValidRequest_ReturnsChatCompletion()
            {
                // Arrange
                var apiKey = "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";
                var client = OpenAIClient.Create(apiKey);
                var builder = new EditRequestBuilder(client);

                // Act
                var result = await builder.Send();

                // Assert
                Assert.NotNull(result);
            }

            #endregion

            #region Clear
            [Fact]
            public void Clear_ShouldReturnSameInstance()
            {
                // Arrange
                var chatRequestBuilder = new EditRequestBuilder(_client);

                // Act
                var result = chatRequestBuilder.Clear();

                // Assert
                Assert.Equal(chatRequestBuilder, result);
            }

            [Fact]
            public void Clear_Should_Return_Same_Instance()
            {
                // Arrange
                var apiKey = "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";
                var client = OpenAIClient.Create(apiKey);
                var builder = new EditRequestBuilder(client);

                // Act
                var result = builder.Clear();

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
                var builder = new EditRequestBuilder(client);

                // Act
                var result = builder.Clear();

                // Assert
                Assert.Equal(builder, result);
            }

            [Fact]
            public void Clear_ModelIdAndInstruction_ReturnsBuilderInstance()
            {
                // Arrange
                var modelId = "model-id";
                var instruction = "instruction";
                var builder = new EditRequestBuilder(Mock.Of<OpenAIClient>());

                // Act
                var result = builder.Clear(modelId, instruction);

                // Assert
                Assert.IsType<EditRequestBuilder>(result);
                Assert.Equal(modelId, builder._request.Model);
                Assert.Equal(instruction, builder._request.Instruction);
            }

            [Fact]
            public void Clear_ModelAndInstruction_ReturnsBuilderInstance()
            {
                // Arrange
                var model = new Model { Id = "model-id" };
                var instruction = "instruction";
                var builder = new EditRequestBuilder(Mock.Of<OpenAIClient>());

                // Act
                var result = builder.Clear(model, instruction);

                // Assert
                Assert.IsType<EditRequestBuilder>(result);
                Assert.Equal(model.Id, builder._request.Model);
                Assert.Equal(instruction, builder._request.Instruction);
            }

            #endregion

        }
    }
}
