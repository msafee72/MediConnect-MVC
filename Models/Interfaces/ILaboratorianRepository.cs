namespace Medi_Connect.Models.Interfaces
{
    public interface ILaboratorianRepository: IRepository<Laboratorian>
    {
        //public void Add(Laboratorian l);

        public IEnumerable<Laboratorian> View();

        public void Update(int id, Laboratorian l);

        //public void Delete(int id);
    }
}
