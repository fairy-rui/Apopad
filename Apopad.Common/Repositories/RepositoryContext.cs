using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Apopad.Common.Repositories
{
    /// <summary>
    /// Represents the base class for the repository contexts.
    /// </summary>
    /// <remarks>
    /// A repository context is the concept that handles external storage connection sessions and
    /// database transactions. Usually the encapsulated session object will be a database connection,
    /// a database session that holds the database connection and handles the object states, or even
    /// a centralized location where the object data stores. For example, a DbContext object in Entity Framework,
    /// a Session object in NHibernate or an IDbConnection object in ADO.NET.
    /// </remarks>
    /// <typeparam name="TSession">The type of the encapsulated session object.</typeparam>
    public abstract class RepositoryContext<TSession> : DisposableObject, IRepositoryContext<TSession>
        where TSession : class
    {
        #region Private Fields
        private readonly TSession session;
        private readonly Guid id = Guid.NewGuid();
        private readonly ConcurrentDictionary<Type, object> cachedRepositories = new ConcurrentDictionary<Type, object>();
        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryContext{TSession}"/> class.
        /// </summary>
        /// <param name="session">The encapsulated session object.</param>
        protected RepositoryContext(TSession session)
        {
            this.session = session;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the unique identifier of the current repository context.
        /// </summary>
        public Guid Id => this.id;

        /// <summary>
        /// Gets the instance of a session object.
        /// </summary>
        /// <remarks>
        /// A session object usually maintains the connection between the repository and
        /// its backend infrastructure. For example, it can be the DbContext in Entity Framework
        /// repository implementation, or an ISession instance in NHibernate implementation.
        /// </remarks>
        public TSession Session => this.session;

        /// <summary>
        /// Gets the instance of a session object.
        /// </summary>
        /// <remarks>
        /// A session object usually maintains the connection between the repository and
        /// its backend infrastructure. For example, it can be the DbContext in Entity Framework
        /// repository implementation, or an ISession instance in NHibernate implementation.
        /// </remarks>
        object IRepositoryContext.Session => this.session;
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets an instance of <see cref="T:Apopad.Common.Repositories.IRepository`2" /> from current context.
        /// </summary>
        /// <typeparam name="TKey">The type of the key of the aggregate root.</typeparam>
        /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
        /// <returns>
        /// An instance of <see cref="T:Apopad.Common.Repositories.IRepository`2" />.
        /// </returns>
        public IRepository<TKey, TAggregateRoot> GetRepository<TKey, TAggregateRoot>()
            where TKey : IEquatable<TKey>
            where TAggregateRoot : class, IAggregateRoot<TKey> =>
            (IRepository<TKey, TAggregateRoot>)cachedRepositories.GetOrAdd(typeof(TAggregateRoot), CreateRepository<TKey, TAggregateRoot>());

        /// <summary>
        /// Commits the changes to the repository as a single transaction.
        /// </summary>
        public virtual void Commit() { }

        /// <summary>
        /// Commits the changes to the repository asynchronously as a single transaction.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> that propagates the notification that the operation should be cancelled.</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> which performs the commit operation.
        /// </returns>
        public virtual Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Factory.StartNew(Commit, cancellationToken);
        }

        public abstract IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);
        #endregion

        #region Protected Methods
        /// <summary>
        /// Creates the repository.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
        /// <returns></returns>
        protected abstract IRepository<TKey, TAggregateRoot> CreateRepository<TKey, TAggregateRoot>()
            where TKey : IEquatable<TKey>
            where TAggregateRoot : class, IAggregateRoot<TKey>;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing) { }
        #endregion

    }
}
