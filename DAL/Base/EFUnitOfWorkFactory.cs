using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Base
{
    public class EFUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private static Func<DbContext> _objectContextDelegate;
        private static readonly Object LockObject = new object();

        public static void SetObjectContext(Func<DbContext> objectContextDelegate)
        {
            _objectContextDelegate = objectContextDelegate;
        }

        public IUnitOfWork Create()
        {
            DbContext context;

            lock (LockObject)
            {
                context = _objectContextDelegate();
            }

            return new EFUnitOfWork(context);

        }
    }
}
