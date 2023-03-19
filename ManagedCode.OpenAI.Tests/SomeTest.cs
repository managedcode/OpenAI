using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ManagedCode.OpenAI.Tests;


public class SomeTest 
{
    private readonly ITestOutputHelper _outputHelper;

    public SomeTest(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }
    
    [Fact]
    public async Task OneRequest()
    {
        _outputHelper.WriteLine("OK");
    }

   
}