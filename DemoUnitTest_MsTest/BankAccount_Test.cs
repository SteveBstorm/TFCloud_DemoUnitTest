using Apps72.Dev.Data.DbMocker;
using DemoUnitTest.Bank;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUnitTest_MsTest
{
    [TestClass]
    public class BankAccount_Test
    {
        [TestMethod]
        public void DebitAvecValidMontant()
        {
            BankAccount b = new BankAccount("steve", 1000);
            b.Debit(200);
            Assert.AreEqual(800, b.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreditAvecMontantInvalid()
        {
            BankAccount b = new BankAccount("steve", 1000);
            b.Credit(-200);
            Assert.AreEqual(800, b.Balance);
        }

        [TestMethod]
        public void Debit_AvecDbMocker()
        {
            MockDbConnection cnx = new MockDbConnection();
            cnx.Mocks.When(c => c.HasValidSqlServerCommandText())
                .ReturnsTable(MockTable.WithColumns("Balance", "cname")
                .AddRow(1000m, "steve"));

            BankService service = new BankService(cnx);
            BankAccount b = new BankAccount(service, "steve");

            b.Debit(200);
            Assert.IsInstanceOfType(service.GetBalance(""), typeof(decimal));
            Assert.AreEqual(800m, b.Balance);
        }

        [TestMethod]
        public void Debit_AvecMoc()
        {
            var service = new Mock<IBankService>();
            service.Setup(srv => srv.GetBalance("arthur")).Returns(200);

            BankAccount b = new BankAccount(service.Object, "arthur");

            b.Debit(200);
            Assert.AreEqual(0, b.Balance);
        }
    }
}
