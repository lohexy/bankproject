using System.Collections.Generic;

namespace BankEmulator.Domain
{
    public class BankHistoryManager
    {
        private readonly Stack<ICommand> _history = new Stack<ICommand>();

        public bool ExecuteTransaction(ICommand command)
        {
            if (command.Execute())
            {
                _history.Push(command);
                return true;
            }
            return false;
        }

        public void UndoLastTransaction()
        {
            if (_history.Count > 0)
            {
                var lastCommand = _history.Pop();
                lastCommand.Undo();
            }
        }
    }
}