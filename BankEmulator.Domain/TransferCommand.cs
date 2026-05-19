namespace BankEmulator.Domain
{
    public class TransferCommand : ICommand
    {
        private readonly Account _fromAccount;
        private readonly Account _toAccount;
        private readonly decimal _amount;
        private bool _isExecuted = false;

        public TransferCommand(Account fromAccount, Account toAccount, decimal amount)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amount = amount;
        }

        public bool Execute()
        {
            try
            {
                _fromAccount.Withdraw(_amount);
                _toAccount.Deposit(_amount);
                _isExecuted = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Undo()
        {
            if (!_isExecuted) return;

            _toAccount.Withdraw(_amount);
            _fromAccount.Deposit(_amount);
            _isExecuted = false;
        }
    }
}