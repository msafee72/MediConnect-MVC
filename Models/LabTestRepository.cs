using Generic_Medi_Connect.Models.Repositories;
using Medi_Connect.Models.Interfaces;
using NuGet.Protocol.Core.Types;
using System.Numerics;

namespace Medi_Connect.Models
{
    public class LabTestRepository : GenericRepository<LabTest>, ILabTestRepository
    {
        List<LabTest> _labtestrepo = new List<LabTest>();

        IRepository<LabTest> _labTestRepository = new GenericRepository<LabTest>("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;");

        private readonly string _connString;

        public LabTestRepository(string conn):base(conn) 
        {
            _connString = conn;
        }


        public void Add(LabTest l)
        {
            _labTestRepository.Add(l);
        }

        public IEnumerable<LabTest> View()
        {


            return _labTestRepository.GetAll();
        }

        public void Update(int id, LabTest l)
        {


            _labTestRepository.Update(l);
        }

        public void Delete(int id)
        {

            _labTestRepository.Delete(id);
        
        }


    }
}
