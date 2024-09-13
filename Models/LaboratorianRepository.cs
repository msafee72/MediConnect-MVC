using Generic_Medi_Connect.Models.Repositories;
using Medi_Connect.Models.Interfaces;
using NuGet.Protocol.Core.Types;
using System.Numerics;

namespace Medi_Connect.Models
{
    public class LaboratorianRepository : GenericRepository<Laboratorian>, ILaboratorianRepository
    {

        List<Laboratorian> _laboratorian = new List<Laboratorian>();


        IRepository<Laboratorian> _laboratoriansRepository = new GenericRepository<Laboratorian>("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;");
        
        private readonly object _laboratorianRepository;

        
        
        private readonly string _connString;
        public LaboratorianRepository(string conn) : base(conn)
        {
            _connString = conn;
        }


        public void Add(Laboratorian l)
        {
            _laboratoriansRepository.Add(l);

        }

        public IEnumerable<Laboratorian> View()
        {


            return _laboratoriansRepository.GetAll();
        }

        public void Update(int id, Laboratorian l)
        {


            _laboratoriansRepository.Update(l);
        }

        public void Delete(int id)
        {
            _laboratoriansRepository.Delete(id);
        }

    }
}
