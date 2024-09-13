namespace Medi_Connect.Models.Interfaces
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        //public void Add(Prescription prescription);

        public IEnumerable<Prescription> View();

        public void Update(int Id, Prescription prescription);

        //public void Delete(int prescriptionId);


    }
}
