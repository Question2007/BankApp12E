using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp12E
{
    [TestFixture]
    public class BankTest
    {
        Bank bank;

        [SetUp]
        public void SetUp()
        {
            bank = new Bank();
            bank.CreateAccount("1234");
        }

        [Test]
        public void StartingBalanceIsZero()
        {
            Assert.That(bank.GetBalance("1234"), Is.Zero);
        }

        [Test]
        public void DepositOnce()
        {
            bank.Deposit("1234", 10000);
            Assert.That(bank.GetBalance("1234"), Is.EqualTo(10000));
        }

        [Test]
        public void DepositMultiple()
        {
            bank.Deposit("1234", 10000);
            bank.Deposit("1234", 15000);
            Assert.That(bank.GetBalance("1234"), Is.EqualTo(25000));
        }

        [Test]
        public void DepositNegativeAmount()
        {
            Assert.That(() => bank.Deposit("1234", -10000), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void DepositMultipleAccounts()
        {
            bank.CreateAccount("5678");
            bank.Deposit("1234", 10000);
            Assert.That(bank.GetBalance("1234"), Is.EqualTo(10000));
            Assert.That(bank.GetBalance("5678"), Is.Zero);
        }

        [Test]
        public void GetBalanceOfInvalidAccount()
        {
            Assert.That(() => bank.GetBalance("5678"), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void DepositToInvalidAccount()
        {
            Assert.That(() => bank.Deposit("5678", 5000), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Withdraw()
        {
            bank.Deposit("1234", 10000);
            bank.Withdraw("1234", 5000);
            Assert.That(bank.GetBalance("1234"), Is.EqualTo(5000));
        }

        [Test]
        public void WithdrawReturn()
        {
            bank.Deposit("1234", 10000);
            Assert.That(bank.Withdraw("1234", 5000), Is.True);
        }

        [Test]
        public void WithdrawInsufficientFunds()
        {
            bank.Deposit("1234", 10000);
            Assert.That(() => bank.Withdraw("1234", 15000), Is.False);
        }

        [Test]
        public void WithdrawInvalidAccount()
        {
            Assert.That(() => bank.Withdraw("1252", 5000), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void WithdrawNegativeAmount()
        {
            Assert.That(() => bank.Withdraw("1234", -10000), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Transfer()
        {
            bank.CreateAccount("1252");
            bank.Deposit("1234", 10000);
            bank.Transfer("1234", "1252", 5000);
            Assert.That(bank.GetBalance("1252"), Is.EqualTo(5000));
        }

        [Test]
        public void TransferReturn()
        {
            bank.CreateAccount("1252");
            bank.Deposit("1234", 10000);
            Assert.That(bank.Transfer("1234", "1252", 5000), Is.True);
        }

        [Test]
        public void TransferInvalidFromAccount()
        {
            bank.CreateAccount("1252");
            bank.Deposit("1234", 10000);
            Assert.That(() => bank.Transfer("8998", "1252", 5000), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TransferInvalidToAccount()
        {
            bank.CreateAccount("1252");
            bank.Deposit("1234", 10000);
            Assert.That(() => bank.Transfer("1234", "8998", 5000), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TransferNegativeAmount()
        {
            bank.CreateAccount("1252");
            bank.Deposit("1234", 10000);
            Assert.That(() => bank.Transfer("1234", "8998", -5000), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TransferInsufficientFunds()
        {
            bank.CreateAccount("1252");
            bank.Deposit("1234", 4999);
            Assert.That(bank.Transfer("1234", "1252", 5000), Is.False);
            Assert.That(bank.GetBalance("1234"), Is.EqualTo(4999));
            Assert.That(bank.GetBalance("1252"), Is.EqualTo(0));
        }
    }
}
