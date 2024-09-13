namespace Medi_Connect.Models.Interfaces
{
    public interface ILabTestRepository : IRepository<LabTest>
    {
        //public void Add(LabTest l);

        public IEnumerable<LabTest> View();

        public void Update(int id, LabTest l);

        //public void Delete(int id);
    }
}
