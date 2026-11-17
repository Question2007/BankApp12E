namespace BankApp12E
{
    public class Bank
    {
        Dictionary<string, int> accounts = new Dictionary<string, int>();

        public void CreateAccount(string account)
        {
            accounts.Add(account, 0);
        }

        public int GetBalance(string account)
        {
            if (!accounts.ContainsKey(account))
            {
                throw new ArgumentException("Invalid account");
            }
            return accounts[account];
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
            accounts[account] += amount;
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
            if (accounts[account] < amount)
            {
                return false;
            }
            

            accounts[account] -= amount;
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

            else if (accounts[fromAccount] < amount)
            {
                return false;
            }
            else
            {
            accounts[fromAccount] -= amount;
            accounts[toAccount] += amount;
                return true;
            }
        }
    }
}
