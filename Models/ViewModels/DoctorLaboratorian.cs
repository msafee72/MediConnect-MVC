namespace Medi_Connect.Models.ViewModels
{
    public class DoctorLaboratorian
    {
        //public string WelcomeMessage { get; set; }

        public IEnumerable<Patient> Patients { get; set; }

        public IEnumerable<LabTest> LabTests { get; set; }


    }
}
