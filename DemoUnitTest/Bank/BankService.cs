using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DemoUnitTest.Bank
{
    public class BankService : IBankService
    {
        private DbConnection _connection;

        private Dictionary<string, decimal> AccountInfo;

        public BankService()
        {
            AccountInfo = new Dictionary<string, decimal>();
            AccountInfo.Add("steve", 1000);
            AccountInfo.Add("thierry", 2000);

        }

        public BankService(DbConnection cnx)
        {
            _connection = cnx;
        }

        public decimal GetBalance(string customerName)
        {
            using (DbCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT Balance FROM Account WHERE cname = @cname";
                DbParameter param = command.CreateParameter();

                param.ParameterName = "cname";
                param.Value = 1000;

                command.Parameters.Add(param);

                return (decimal)command.ExecuteScalar();
            }
        }
    }

}
