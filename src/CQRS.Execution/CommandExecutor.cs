namespace CQRS.Execution.Abstractions
{
    using System.Threading;
    using System.Threading.Tasks;
    using CQRS.Command.Abstractions;

    /// <summary>
    /// Executes command handlers.
    /// </summary>
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ICommandHandlerFactory commandHandlerFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandExecutor"/> class.
        /// </summary>
        /// <param name="commandHandlerFactory">The <see cref="ICommandHandlerFactory"/> that
        /// is responsible for creating command handlers.</param>
        public CommandExecutor(ICommandHandlerFactory commandHandlerFactory)
        {
            this.commandHandlerFactory = commandHandlerFactory;
        }

        /// <inheritdoc/>
        public async Task ExecuteAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        {
            var commandHandler = this.commandHandlerFactory.CreateCommandHandler<TCommand>();
            await commandHandler.HandleAsync(command, cancellationToken).ConfigureAwait(false);
        }
    }
}
