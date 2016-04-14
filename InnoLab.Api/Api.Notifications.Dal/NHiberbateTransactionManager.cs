using System;
using NHibernate;

namespace Api.Notifications.Dal
{
    public class NHiberbateTransactionManager : ITransactionManager
    {
        private readonly ISession _session;

        public NHiberbateTransactionManager(ISession session)
        {
            _session = session;
        }

        public void RunInTransaction(Action actionToExecute)
        {
            using (var tx = _session.BeginTransaction())
            {
                try
                {
                    actionToExecute();
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }
    }
}