using System;
using System.Collections.Generic;
using System.Text;

namespace ErickEspinosa.SQLite.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
