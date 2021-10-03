using System;

namespace RegisterAndLogin_LTQL.Controllers
{
    internal class LTQLDBEntities
    {
        public object Accounts { get; internal set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}