using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Data.Commands
{
    public class UpdateTaskStatusImpl : UpdateTaskStatus
    {
        private readonly IDbConnection connection;

        public override void ExecuteCommand()
        {
            using (var txn = connection.BeginTransaction())
            {
                txn.Commit();
            }            
        }
    }
}
