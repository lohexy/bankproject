namespace BankEmulator.Domain
{
    public interface ICommand
    {
        bool Execute();
        void Undo();
    }
}