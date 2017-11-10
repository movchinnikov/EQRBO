namespace EQR.BackOffice.CQRS.Core
{
    public interface IAfterCommand<TCommand> where TCommand : ICommand
    {
    }
}