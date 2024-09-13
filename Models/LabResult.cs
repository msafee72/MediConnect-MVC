namespace Medi_Connect.Models
{
    public class LabResult
    {
        public int Id { get; set; }
        public int PatientId { get; set; }

        public string TestName { get; set; }

        public IFormFile File { get; set; }
        public string ResultFilePath { get; set; }

    }

}
