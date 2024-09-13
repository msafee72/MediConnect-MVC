using Generic_Medi_Connect.Models.Repositories;
using Medi_Connect.Models.Interfaces;
using System.Globalization;

namespace Medi_Connect.Models
{
    public class PrescriptionRepository : GenericRepository<Prescription>, IPrescriptionRepository
    {
        List<Prescription> _prescriptions = new List<Prescription>();

        IRepository<Prescription> _prescriptionsRepository = new GenericRepository<Prescription>("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;");
        //private readonly object _doctorRepository;

        private readonly string _connString;

        public PrescriptionRepository(string conn) : base(conn)
        {
            _connString = conn;
        }

        public void Add(Prescription prescription)
        {
            _prescriptionsRepository.Add(prescription);
        }


        public IEnumerable<Prescription> View()
        {
            return (List<Prescription>)_prescriptionsRepository.GetAll();

        }


        public void Update(int Id, Prescription prescription)
        {

            _prescriptionsRepository.Update(prescription);
        }

        public void Delete(int prescriptionId)
        {
            _prescriptionsRepository.Delete(prescriptionId);

        }
    }
}

