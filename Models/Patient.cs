namespace Medi_Connect.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string Contact { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public decimal Weight { get; set; }
        public int Age { get; set; }
        public string HealthConditions { get; set; }
        public string Diseases { get; set; }
    }
}
