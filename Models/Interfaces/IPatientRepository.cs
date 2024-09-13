namespace Medi_Connect.Models.Interfaces
{
    public interface IPatientRepository :IRepository<Patient>
    {
        //public void Add(Patient patient);

        public IEnumerable<Patient> View();

        public void Update(int patientId, Patient patient);

        //public void Delete(int patientId);
    }
}
