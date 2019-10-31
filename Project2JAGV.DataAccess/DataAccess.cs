using System;
using System.Collections.Generic;
using System.Text;
using Project2JAGV.DataAccess.Entities;
using Project2JAGV.ObjectLogic.Interfaces;

namespace Project2JAGV.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly Project2JAGVContext _context;

        /// <summary>
        /// constructor for the project0 database access
        /// </summary>
        /// <param name="context">Dbcontext for accessing the database</param>
        public DataAccess(Project2JAGVContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
