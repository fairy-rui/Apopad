using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Apopad.Common.Repositories
{
    /// <summary>
    /// Represents that the implemented classes are repository contexts in which
    /// the repositories resides.
    /// </summary>
    public interface IRepositoryContext : IDisposable
    {
        /// <summary>
        /// Gets the unique identifier of the current context.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets the instance of a session object.
        /// </summary>
        /// <remarks>
        /// A session object usually maintains the connection between the repository and 
        /// its backend infrastructure. For example, it can be the DbContext in Entity Framework
        /// repository implementation, or an ISession instance in NHibernate implementation.
        /// </remarks>
        object Session { get; }

        /// <summary>
        /// Gets an instance of <see cref="IRepository{TKey, TAggregateRoot}"/> from current context.
        /// </summary>
        /// <typeparam name="TKey">The type of the key of the aggregate root.</typeparam>
        /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
        /// <returns>An instance of <see cref="IRepository{TKey, TAggregateRoot}"/>.</returns>
        IRepository<TKey, TAggregateRoot> GetRepository<TKey, TAggregateRoot>()
            where TKey : IEquatable<TKey>
            where TAggregateRoot : class, IAggregateRoot<TKey>;

        /// <summary>
        /// Commits the changes to the repository as a single transaction.
        /// </summary>
        void Commit();

        /// <summary>
        /// Commits the changes to the repository asynchronously as a single transaction.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that propagates the notification that the operation should be cancelled.</param>
        /// <returns>The <see cref="Task"/> which performs the commit operation.</returns>
        Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken));

        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);
    }

    /// <summary>
    /// Represents that the implemented classes are repository contexts in which
    /// the repositories resides. This is the strongly-typed version of <see cref="IRepositoryContext"/> interface.
    /// </summary>
    /// <typeparam name="TSession">The type of the session object.</typeparam>
    public interface IRepositoryContext<out TSession> : IRepositoryContext
        where TSession : class
    {
        /// <summary>
        /// Gets the instance of a session object.
        /// </summary>
        /// <remarks>
        /// A session object usually maintains the connection between the repository and 
        /// its backend infrastructure. For example, it can be the DbContext in Entity Framework
        /// repository implementation, or an ISession instance in NHibernate implementation.
        /// </remarks>
        new TSession Session { get; }
    }
}
