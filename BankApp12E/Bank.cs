using System.Security.Principal;

namespace BankApp12E
{
    public class Bank
    {
        Dictionary<string, Account> accounts = new Dictionary<string, Account>();

        public void CreateAccount(string account, string name)
        {
            accounts.Add(account, new Account(name, 0));
        }

        public int GetBalance(string account)
        {
            if (!accounts.ContainsKey(account))
            {
                throw new ArgumentException("Invalid account");
            }
            return accounts[account].Balance;
        }

        public void Deposit(string account, int amount)
        {
            if (!accounts.ContainsKey(account))
            {
                throw new ArgumentException("Invalid account");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive");
            }
            accounts[account].Balance += amount;
        }

        public bool Withdraw(string account, int amount)
        {
            if (!accounts.ContainsKey(account))
            {
                throw new ArgumentException("Invalid account");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive");
            }
            if (accounts[account].Balance < amount)
            {
                return false;
            }


            accounts[account].Balance -= amount;
            return true;
        }

        public bool Transfer(string fromAccount, string toAccount, int amount)
        {
            if (!accounts.ContainsKey(fromAccount))
            {
                throw new ArgumentException("Invalid fromAccount");
            }
            else if (!accounts.ContainsKey(toAccount))
            {
                throw new ArgumentException("Invalid toAccount");
            }
            else if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive");
            }

            else if (accounts[fromAccount].Balance < amount)
            {
                return false;
            }
            else
            {
                accounts[fromAccount].Balance -= amount;
                accounts[toAccount].Balance += amount;
                return true;
            }
        }


        public void CloseAccount(string account)
        {
            if (!accounts.ContainsKey(account))
            {
                throw new ArgumentException();
            }
            else if (accounts[account].Balance != 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
            accounts.Remove(account);
            }
        }

        public string GetOwner(string account)
        {
            if (!accounts.ContainsKey(account))
            {
                throw new ArgumentException();
            }
            else
            {
                return accounts[account].Name;
            }
        }
    }
}
