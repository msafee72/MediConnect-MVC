namespace Medi_Connect.Models.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        //public void Add(Doctor doctor);
        public IEnumerable<Doctor> View();
        public void Update(int doctorID, Doctor doctor);

        //public void Delete(int doctorID);

    }
}
