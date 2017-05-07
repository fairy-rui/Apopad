﻿using Apopad.Common.Repositories;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Apopad.Domain.Repositories.EntityFramework
{
    public sealed class EntityFrameworkRepositoryContext : RepositoryContext<DbContext>
    {
        public EntityFrameworkRepositoryContext(DbContext session) : base(session)
        {
        }

        protected override IRepository<TKey, TAggregateRoot> CreateRepository<TKey, TAggregateRoot>()
            => new EntityFrameworkRepository<TKey, TAggregateRoot>(this);

        public override void Commit()
        {
            this.Session.SaveChanges();
        }

        public override async Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Session.SaveChangesAsync(cancellationToken);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Session.Dispose();
            }
        }
    }
}
