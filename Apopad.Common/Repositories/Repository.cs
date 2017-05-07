using Apopad.Common.Querying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Apopad.Common.Repositories
{
    /// <summary>
    /// Represents the base class for repositories.
    /// </summary>
    /// <typeparam name="TKey">The type of the key of the aggregate root.</typeparam>
    /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
    /// <seealso cref="Apopad.Common.Repositories.IRepository{TKey, TAggregateRoot}" />
    public abstract class Repository<TKey, TAggregateRoot> : IRepository<TKey, TAggregateRoot>
        where TKey : IEquatable<TKey>
        where TAggregateRoot : class, IAggregateRoot<TKey>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TKey, TAggregateRoot}"/> class.
        /// </summary>
        /// <param name="context">The repository context.</param>
        protected Repository(IRepositoryContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Gets the context in which the current repository exists.
        /// </summary>
        public IRepositoryContext Context { get; }

        /// <summary>
        /// Adds the specified <see cref="T:Apopad.Common.IAggregateRoot`1" /> instance to the current repository.
        /// </summary>
        /// <param name="aggregateRoot">The <see cref="T:Apopad.Common.IAggregateRoot`1" /> instance to be added.</param>
        public abstract void Add(TAggregateRoot aggregateRoot);

        /// <summary>
        /// Adds the specified <see cref="T:Apopad.Common.IAggregateRoot`1" /> instance to the current repository asynchronously.
        /// </summary>
        /// <param name="aggregateRoot">The <see cref="T:Apopad.Common.IAggregateRoot`1" /> instance to be added.</param>
        /// <param name="cancellationToken">The object that propagates notification that operations should be canceled.</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> instance which performs the add operation.
        /// </returns>
        public virtual Task AddAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Factory.StartNew(() => this.Add(aggregateRoot), cancellationToken);
        }

        /// <summary>
        /// Removes the specified aggregate root from the current repository.
        /// </summary>
        /// <param name="aggregateRoot">The aggregate root.</param>
        public virtual void Remove(TAggregateRoot aggregateRoot)
        {
            this.RemoveByKey(aggregateRoot.Id);
        }

        /// <summary>
        /// Removes the specified aggregate root from the current repository asynchronously.
        /// </summary>
        /// <param name="aggregateRoot">The aggregate root.</param>
        /// <param name="cancellationToken">The object that propagates notification that operations should be canceled.</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> instance which performs the remove operation.
        /// </returns>
        public virtual async Task RemoveAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.RemoveByKeyAsync(aggregateRoot.Id, cancellationToken);
        }

        /// <summary>
        /// Removes the specified aggregate root from the current repository by using its key.
        /// </summary>
        /// <param name="key">The key of the aggregate root to be removed.</param>
        public abstract void RemoveByKey(TKey key);

        /// <summary>
        /// Removes the specified aggregate root from the current repository by using its key asynchronously.
        /// </summary>
        /// <param name="key">The key of the aggregate root to be removed.</param>
        /// <param name="cancellationToken">The object that propagates notification that operations should be canceled.</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> instance that performs the remove operation.
        /// </returns>
        public virtual Task RemoveByKeyAsync(TKey key, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Factory.StartNew(() => this.RemoveByKey(key), cancellationToken);
        }

        /// <summary>
        /// Updates the specified aggregate root.
        /// </summary>
        /// <param name="aggregateRoot">The aggregate root to be updated.</param>
        public virtual void Update(TAggregateRoot aggregateRoot)
        {
            this.UpdateByKey(aggregateRoot.Id, aggregateRoot);
        }

        /// <summary>
        /// Updates the specified aggregate root asynchronously.
        /// </summary>
        /// <param name="aggregateRoot">The aggregate root to be updated.</param>
        /// <param name="cancellationToken">The object that propagates notification that operations should be canceled.</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> instance that performs the update operation.
        /// </returns>
        public virtual async Task UpdateAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.UpdateByKeyAsync(aggregateRoot.Id, aggregateRoot, cancellationToken);
        }

        /// <summary>
        /// Updates the aggregate root by using its key.
        /// </summary>
        /// <param name="key">The key of the aggregate root that is going to be updated.</param>
        /// <param name="aggregateRoot">The aggregate root that is going to be updated.</param>
        public abstract void UpdateByKey(TKey key, TAggregateRoot aggregateRoot);

        /// <summary>
        /// Updates the aggregate root by using its key asynchronously.
        /// </summary>
        /// <param name="key">The key of the aggregate root that is going to be updated.</param>
        /// <param name="aggregateRoot">The aggregate root that is going to be updated.</param>
        /// <param name="cancellationToken">The object that propagates notification that operations should be canceled.</param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" /> instance that performs the update operation.
        /// </returns>
        public virtual Task UpdateByKeyAsync(TKey key, TAggregateRoot aggregateRoot, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Factory.StartNew(() => this.UpdateByKey(key, aggregateRoot), cancellationToken);
        }

        /// <summary>
        /// Checks if the aggregate roots that meet the specified specification exist in the current repository.
        /// </summary>
        /// <param name="specification">The specification that filters the aggregate roots.</param>
        /// <returns>
        ///   <c>True</c> if the aggregate roots that meet the specified specification exist, otherwise, <c>False</c>.
        /// </returns>
        public virtual bool Exists(Expression<Func<TAggregateRoot, bool>> specification)
        {
            return this.FindAll(specification).Count() > 0;
        }

        /// <summary>
        /// Checks if the aggregate roots that meet the specified specification exist in the current repository asynchronously.
        /// </summary>
        /// <param name="specification">The specification that filters the aggregate roots.</param>
        /// <param name="cancellationToken">The object that propagates notification that operations should be canceled.</param>
        /// <returns>
        /// The task that performs the checking operation and returns the existance of the aggregate roots.
        /// </returns>
        public virtual async Task<bool> ExistsAsync(Expression<Func<TAggregateRoot, bool>> specification, CancellationToken cancellationToken = default(CancellationToken))
        {
            return (await this.FindAllAsync(specification, cancellationToken)).Count() > 0;
        }

        /// <summary>
        /// Gets the <see cref="T:Apopad.Common.IAggregateRoot`1" /> instance from current repository by using a specified key.
        /// </summary>
        /// <param name="key">The aggregate root key.</param>
        /// <returns>
        /// An instance of <see cref="T:Apopad.Common.IAggregateRoot`1" /> that has the specified key.
        /// </returns>
        public abstract TAggregateRoot FindByKey(TKey key);

        /// <summary>
        /// Gets the <see cref="T:Apopad.Common.IAggregateRoot`1" /> instance from current repository by using a specified key asynchronously.
        /// </summary>
        /// <param name="key">The aggregate root key.</param>
        /// <param name="cancellationToken">The object that propagates notification that operations should be canceled.</param>
        /// <returns>
        /// An instance of <see cref="T:Apopad.Common.IAggregateRoot`1" /> that has the specified key.
        /// </returns>
        public virtual Task<TAggregateRoot> FindByKeyAsync(TKey key, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Factory.StartNew(() => this.FindByKey(key), cancellationToken);
        }

        /// <summary>
        /// Gets all the <see cref="T:Apopad.Common.IAggregateRoot`1" /> instances from current repository.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerable`1" /> instance which queries over the collection of the <see cref="T:Apopad.Common.IAggregateRoot`1" /> objects.
        /// </returns>
        public virtual IEnumerable<TAggregateRoot> FindAll()
        {
            return this.FindAll(_ => true, null);
        }

        /// <summary>
        /// Gets all the <see cref="T:Apopad.Common.IAggregateRoot`1" /> instances from current repository asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> that propagates the notification that the operation should be cancelled.</param>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerable`1" /> instance which queries over the collection of the <see cref="T:Apopad.Common.IAggregateRoot`1" /> objects.
        /// </returns>
        public virtual Task<IEnumerable<TAggregateRoot>> FindAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(this.FindAll());
        }

        /// <summary>
        /// Gets all the <see cref="T:Apopad.Common.IAggregateRoot`1" /> instances from current repository according to a given query specification.
        /// </summary>
        /// <param name="specification">The specification which specifies the query criteria.</param>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerable`1" /> instance which queries over the collection of the <see cref="T:Apopad.Common.IAggregateRoot`1" /> objects.
        /// </returns>
        public virtual IEnumerable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> specification)
        {
            return this.FindAll(specification, null);
        }

        /// <summary>
        /// Gets all the <see cref="T:Apopad.Common.IAggregateRoot`1" /> instances from current repository according to a given query specification asynchronously.
        /// </summary>
        /// <param name="specification">The specification which specifies the query criteria.</param>
        /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> that propagates the notification that the operation should be cancelled.</param>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerable`1" /> instance which queries over the collection of the <see cref="T:Apopad.Common.IAggregateRoot`1" /> objects.
        /// </returns>
        public virtual Task<IEnumerable<TAggregateRoot>> FindAllAsync(Expression<Func<TAggregateRoot, bool>> specification, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(this.FindAll(specification));
        }

        /// <summary>
        /// Gets all the <see cref="T:Apopad.Common.IAggregateRoot`1" /> instances from current repository according to a given query specification with the sorting enabled.
        /// </summary>
        /// <param name="specification">The specification which specifies the query criteria.</param>
        /// <param name="sortSpecification">The specifications which implies the sorting.</param>
        /// <returns>
        /// A <see cref="T:System.Linq.IEnumerable`1" /> instance which queries over the collection of the <see cref="T:Apopad.Common.IAggregateRoot`1" /> objects.
        /// </returns>
        public abstract IEnumerable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> specification, SortSpecification<TKey, TAggregateRoot> sortSpecification);

        /// <summary>
        /// Gets all the <see cref="T:Apopad.Common.IAggregateRoot`1" /> instances from current repository according to a given query specification with the sorting enabled.
        /// </summary>
        /// <param name="specification">The specification which specifies the query criteria.</param>
        /// <param name="sortSpecification">The specifications which implies the sorting.</param>
        /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> that propagates the notification that the operation should be cancelled.</param>
        /// <returns>
        /// A <see cref="T:System.Linq.IEnumerable`1" /> instance which queries over the collection of the <see cref="T:Apopad.Common.IAggregateRoot`1" /> objects.
        /// </returns>
        public virtual Task<IEnumerable<TAggregateRoot>> FindAllAsync(Expression<Func<TAggregateRoot, bool>> specification, SortSpecification<TKey, TAggregateRoot> sortSpecification, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(this.FindAll(specification, sortSpecification));
        }

        /// <summary>
        /// Gets all the <see cref="T:Apopad.Common.IAggregateRoot`1" /> instances from current repository according to a given query specification for
        /// the specified page size and page number that matches the given sorting specification.
        /// </summary>
        /// <param name="specification">The specification which specifies the query criteria.</param>
        /// <param name="sortSpecification">The specifications which implies the sorting.</param>
        /// <param name="pageNumber">The number of the page to be returned from the query.</param>
        /// <param name="pageSize">The number of records per page.</param>
        /// <returns>
        /// A <see cref="T:Apopad.Common.Querying.PagedResult`2" /> instance which contains the returned objects and the pagination information.
        /// </returns>
        public abstract PagedResult<TKey, TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> specification, SortSpecification<TKey, TAggregateRoot> sortSpecification, int pageNumber, int pageSize);

        /// <summary>
        /// Gets all the <see cref="T:Apopad.Common.IAggregateRoot`1" /> instances from current repository according to a given query specification for
        /// the specified page size and page number that matches the given sorting specification.
        /// </summary>
        /// <param name="specification">The specification which specifies the query criteria.</param>
        /// <param name="sortSpecification">The specifications which implies the sorting.</param>
        /// <param name="pageNumber">The number of the page to be returned from the query.</param>
        /// <param name="pageSize">The number of records per page.</param>
        /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> that propagates the notification that the operation should be cancelled.</param>
        /// <returns>
        /// The task that performs the querying and returns the <see cref="T:Apopad.Common.Querying.PagedResult`2" /> instance which contains both
        /// query result and the pagination information.
        /// </returns>
        public virtual Task<PagedResult<TKey, TAggregateRoot>> FindAllAsync(Expression<Func<TAggregateRoot, bool>> specification, SortSpecification<TKey, TAggregateRoot> sortSpecification, int pageNumber, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(this.FindAll(specification, sortSpecification, pageNumber, pageSize));
        }

        /// <summary>
        /// Gets all the <see cref="T:Apopad.Common.IAggregateRoot`1" /> instances from current repository for the specified page size and page number that matches the given sorting specification.
        /// </summary>
        /// <param name="sortSpecification">The sort specification.</param>
        /// <param name="pageNumber">The number of the page to be returned from the query.</param>
        /// <param name="pageSize">The number of records per page.</param>
        /// <returns>
        /// A <see cref="T:Apopad.Common.Querying.PagedResult`2" /> instance which contains the returned objects and the pagination information.
        /// </returns>
        public virtual PagedResult<TKey, TAggregateRoot> FindAll(SortSpecification<TKey, TAggregateRoot> sortSpecification, int pageNumber, int pageSize)
        {
            return this.FindAll(_ => true, sortSpecification, pageNumber, pageSize);
        }

        /// <summary>
        /// Gets all the <see cref="T:Apopad.Common.IAggregateRoot`1" /> instances from current repository for the specified page size and page number that matches the given sorting specification asynchronously.
        /// </summary>
        /// <param name="sortSpecification">The sort specification.</param>
        /// <param name="pageNumber">The number of the page to be returned from the query.</param>
        /// <param name="pageSize">The number of records per page.</param>
        /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> that propagates the notification that the operation should be cancelled.</param>
        /// <returns>
        /// The task that performs the querying and returns the <see cref="T:Apopad.Common.Querying.PagedResult`2" /> instance which contains both
        /// query result and the pagination information.
        /// </returns>
        public virtual Task<PagedResult<TKey, TAggregateRoot>> FindAllAsync(SortSpecification<TKey, TAggregateRoot> sortSpecification, int pageNumber, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.FindAllAsync(_ => true, sortSpecification, pageNumber, pageSize, cancellationToken);
        }
    }
}
