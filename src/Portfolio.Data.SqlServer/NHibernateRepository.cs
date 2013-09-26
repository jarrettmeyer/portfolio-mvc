﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;

namespace Portfolio.Data
{
    public class NHibernateRepository : IRepository
    {
        private readonly ISession session;

        public NHibernateRepository(ISession session)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            this.session = session;
        }

        public void Add<T>(T entity)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(entity);
                transaction.Commit();
            }
        }

        public IEnumerable<T> All<T>()
        {
            var items = session.Query<T>().ToArray();
            return items;
        }

        public T First<T>(Expression<Func<T, bool>> expression)
        {
            var item = session.Query<T>().Where(expression).FirstOrDefault();
            return item;
        }

        public T Load<T>(object id)
        {
            var item = session.Load<T>(id);
            return item;
        }

        public void SaveChanges()
        {
            using (var transaction = session.BeginTransaction())
            {
                transaction.Commit();
            }
        }

        public IEnumerable<T> Where<T>(Expression<Func<T, bool>> expression)
        {
            var items = session.Query<T>().Where(expression).ToArray();
            return items;
        }
    }
}