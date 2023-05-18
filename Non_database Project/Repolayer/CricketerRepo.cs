using Non_database_Project.Model;
using Non_database_Project.Repolayer;

namespace Non_database_Project.Servicelayer
{
    public class CricketerRepo: ICricketerRepo
    {
        private List<CricketTeam> items = new List<CricketTeam>();
      //  private int _nextId = 1;
        public CricketerRepo()
        {
            Add(new CricketTeam { Jerseynumber = 1, Jerseyname = "virat", Playerage = 20, Average = 3 });

        }
        public IEnumerable<CricketTeam> GetAll()
        {
            return items;
        }
        public CricketTeam? Get(int id)
        {
            return items.Find(p => p.Jerseynumber == id);
        }
        public CricketTeam Add(CricketTeam item)
        {
            items.Add(item);
            return item;
        }
        public void Remove(int id)
        {
            items.RemoveAll(p => p.Jerseynumber == id);
        }
        public bool Update(CricketTeam item)
        {
            int index = items.FindIndex(p => p.Jerseynumber == item.Jerseynumber);
            items.RemoveAt(index);
            items.Add(item);
            return true;
        }
    }
}