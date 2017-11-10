namespace EQR.BackOffice.DataContracts.Request
{
    public sealed class CreateAdmissionRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string PhoneNumber { get; set; }
    }
}