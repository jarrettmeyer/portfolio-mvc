using System;

namespace Portfolio.Lib.Data
{
    public interface ITransactionAdapter : IDisposable
    {
        /// <summary>
        /// Commit the transaction.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollback the transaction.
        /// </summary>
        void Rollback();
    }
}