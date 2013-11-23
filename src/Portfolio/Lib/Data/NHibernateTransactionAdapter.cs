using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
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
            try
            {
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                if (new Regex("^Cannot insert duplicate key row in object").IsMatch(ex.Message))
                {
                    throw new UniqueRecordViolationException(ex);
                }
                throw;
            }
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