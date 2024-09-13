namespace Medi_Connect.Models.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        
        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity entity);

        void Delete(int id);
        

    }

}





//namespace Medi_Connect.Models.Interfaces
//{
//    public interface IRepository<TEntity>
//    {
//        public void Add(TEntity entity);
//        public void Update(TEntity entity);

//        public void Delete(int id);
//        public TEntity Get(int id);

//        public List<TEntity> Get();
//    }
//}
