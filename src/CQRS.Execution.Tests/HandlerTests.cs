using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CQRS.Execution.Tests
{
    public class HandlerTests
    {
        [Fact]
        public async Task ShouldExecuteCommandHandler()
        {
            var commandExecutor = new CommandExecutor(new CommandHandlerFactory());

            var command = new SampleCommand();
            await commandExecutor.ExecuteAsync(command);

            command.WasHandled.Should().BeTrue();
        }

        [Fact]
        public async Task ShouldExecuteQueryHandler()
        {
            var queryExecutor = new QueryExecutor(new QueryHandlerFactory());

            var query = new SampleQuery();
            await queryExecutor.ExecuteAsync(query);


            query.WasHandled.Should().BeTrue();
        }


        [Fact]
        public async Task ShouldExecuteCommandHandlerInScope()
        {
            var commandExecutor = new CommandExecutor(new CommandHandlerFactory());

            var command = new SampleCommand();
            await commandExecutor.ExecuteScopedAsync(command);

            command.WasHandled.Should().BeTrue();
        }

        [Fact]
        public async Task ShouldExecuteQueryHandlerInScope()
        {
            var queryExecutor = new QueryExecutor(new QueryHandlerFactory());

            var query = new SampleQuery();
            await queryExecutor.ExecuteScopedAsync(query);

            query.WasHandled.Should().BeTrue();

        }
    }
}