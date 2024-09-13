namespace Medi_Connect.Models.Interfaces
{
    public interface ILabResultRepository : IRepository<LabResult>
    {
        public void Upload(LabResult lr);

        public IEnumerable<LabResult> View();

        public List<LabResult> Search(string search);

        public void Update(int labResultID, LabResult lr);

        //public void Delete(int labresultID);
    }
}
