namespace EQR.BackOffice.DataContracts.Request
{
    public sealed class UpdateVisitorRequest
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Description { get; set; }
    }
}