using System;

namespace Api.Notifications.Dal
{
    public interface ITransactionManager
    {
        void RunInTransaction(Action actionToExecute);
    }
}