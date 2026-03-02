namespace CQRS.Execution;

using System.Threading.Tasks;

/// <summary>
/// Represents a factory for creating an <see cref="IQueryHandlerScope"/>.
/// </summary>
public interface IQueryHandlerScopeFactory
{
    /// <summary>
    /// Creates a new <see cref="IQueryHandlerScope"/>.
    /// </summary>
    /// <returns><see cref="IQueryHandlerScope"/> instance.</returns>
    ValueTask<IQueryHandlerScope> CreateScopeAsync();
}
