using System;
using DataWellCore.core.Protocol;
using Newtonsoft.Json;
using Xunit;

namespace DataWellUnitTests
{
    public class CommandTests
    {
        [Fact]
        public void CommandFactoryTest()
        {
            var commandList = Enum.GetNames(typeof(Commands));
            foreach (var command in commandList)
            {
                var stringCommandObj = CommandFactory.GetCommand(Enum.Parse<Commands>((string)command));
                var obj = JsonConvert.DeserializeObject<BaseCommand>(stringCommandObj);
                var result = obj.CommandName == Enum.Parse<Commands>((string) command);
                Assert.True(result);
            }
        }
    }
}
