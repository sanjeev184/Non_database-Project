using Non_database_Project.Model;

namespace Non_database_Project.Repolayer
{
    public interface ICricketerRepo
    {
        public List<CricketTeam> GetAll();
        public CricketTeam? Get(int id);
        public CricketTeam Add(CricketTeam item);
        public void Remove(int id);
        public bool Update(CricketTeam item);
    }
}
