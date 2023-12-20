namespace CQRS.Execution
{
    using System.Threading;
    using System.Threading.Tasks;
    using CQRS.Command.Abstractions;

    /// <summary>
    /// Executes a command in its own scope.
    /// </summary>
    /// <typeparam name="TCommand">The type of command to be executed in its own <see cref="ICommandHandlerScope"/>.</typeparam>
    public class ScopedCommandHandler<TCommand> : ICommandHandler<ScopedCommand<TCommand>>
    {
        private readonly ICommandHandlerScopeFactory handlerScopeFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScopedCommandHandler{T}"/> class.
        /// </summary>
        /// <param name="handlerScopeFactory">The <see cref="IQueryHandlerScopeFactory"/> that is responsible for creating an new <see cref="ICommandHandlerScope"/>.</param>
        public ScopedCommandHandler(ICommandHandlerScopeFactory handlerScopeFactory)
            => this.handlerScopeFactory = handlerScopeFactory;

        /// <summary>
        /// Handles the specified command in its own scope.
        /// </summary>
        /// <param name="command">The <see cref="ScopedCommand{T}"/>.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive
        /// notice of cancellation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task HandleAsync(ScopedCommand<TCommand> command, CancellationToken cancellationToken = default)
        {
            using (var scope = handlerScopeFactory.CreateScope())
            {
                var commandExecutor = scope.CreateCommandExecutor();
                await commandExecutor.ExecuteAsync(command.Command, cancellationToken);
            }
        }
    }
}