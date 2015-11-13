/* 
 * Copyright (C) 2014 Mehdi El Gueddari
 * http://mehdi.me
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace Mehdime.Entity
{
    /// <summary>
    ///     Convenience methods to retrieve ambient DbContext instances.
    /// </summary>
    public interface IAmbientDbContextLocator
    {
        /// <summary>
        ///     If called within the scope of a DbContextScope, gets or creates
        ///     the ambient DbContext instance for the provided DbContext type.
        ///     Otherwise returns null.
        /// </summary>
        TDbContext Get<TDbContext>() where TDbContext : class, IDbContext;
    }

    public interface IDbContext : IDisposable
    {
        DbContextConfiguration Configuration { get; }
        Database Database { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancelToken);
    }
}