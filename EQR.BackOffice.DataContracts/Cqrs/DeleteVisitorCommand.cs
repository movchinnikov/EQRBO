using System;
using EQR.BackOffice.CQRS.Core;

namespace EQR.BackOffice.DataContracts.Cqrs
{
    public sealed class DeleteVisitorCommand : ICommand
    {
        public string Id { get; private set; }

        public DeleteVisitorCommand(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Идентификатор не задан");

            Id = id;
        }
    }
}