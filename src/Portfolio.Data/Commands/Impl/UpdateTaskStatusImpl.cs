using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Portfolio.Data.Models;

namespace Portfolio.Data.Commands
{
    public class UpdateTaskStatusImpl : UpdateTaskStatus
    {
        private readonly IDbConnection connection;

        public override Task ExecuteCommand(Task task)
        {
            using (var txn = connection.BeginTransaction())
            {
                txn.Commit();
            }
            return null;
        }
    }
}
