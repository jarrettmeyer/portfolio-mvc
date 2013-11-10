using System;
using NHibernate;

namespace Portfolio.Lib.Data
{
    public class NHibernateTransactionAdapter : ITransactionAdapter
    {
        private readonly ITransaction transaction;

        public NHibernateTransactionAdapter(ITransaction transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException("transaction");

            this.transaction = transaction;
        }

        public virtual void Commit()
        {
            transaction.Commit();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Rollback()
        {
            transaction.Rollback();
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
                transaction.Dispose();
        }
    }
}