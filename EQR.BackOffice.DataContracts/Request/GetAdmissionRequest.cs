namespace EQR.BackOffice.DataContracts.Request
{
    public sealed class GetAdmissionRequest
    {
        public string VisitorId { get; set; }

        public string AdmissionId { get; set; }
    }
}