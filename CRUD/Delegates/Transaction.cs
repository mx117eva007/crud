using System;
using System.Transactions;

namespace CRUD.Delegates
{
    public class Transaction
    {
        public delegate void Func(Database1Entities context, dynamic model);

        /// <param name="func">帶入方法</param>
        /// <param name="model">帶入模型</param>
        /// <param name="level">交易等級</param>
        public static void Run(Func func, dynamic model, IsolationLevel level = IsolationLevel.ReadCommitted)
        {
            var scope = new TransactionScope(
                TransactionScopeOption.RequiresNew,
                new TransactionOptions
                {
                    IsolationLevel = level,
                    Timeout = new TimeSpan(0, 0, 1, 0)
                },
                TransactionScopeAsyncFlowOption.Enabled
                );

            Database1Entities context = null;
            try
            {
                using (scope)
                {
                    using (context = new Database1Entities())
                    {
                        func(context, model);
                        context.SaveChanges();
                    }
                    scope.Complete();
                }
            }
            catch (Exception)
            {
                context?.Dispose();
                scope.Dispose();
                throw;
            }
            finally
            {
                context?.Dispose();
                scope.Dispose();
            }
        }
    }
}