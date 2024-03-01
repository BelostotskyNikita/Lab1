using Lab1_4.Entities;
using SQLite;

namespace Lab1_4.Services
{
    public class SQLiteService : IDbService
    {
        private SQLiteConnection db;
        public SQLiteService() { }
        public IEnumerable<Team> GetAllTeams()
        {
            var members = db.Table<Team>();
            return members;
        }
        public IEnumerable<Member> GetMembers(int id)
        {
            var members = db.Table<Member>()
                .Where(t => t.TeamId == id)
                .ToList();
            return members;
        }
        public void Init()
        {
            if (db != null) return;
            var dbPath = Path.Combine(/*FileSystem.AppDataDirectory*/Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyDB.db3");
            if(!File.Exists(dbPath)) File.Create(dbPath);
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Team>();
            db.CreateTable<Member>();
            db.Insert(new Team { Id = 1, Name = "team1" });
            db.Insert(new Team { Id = 2, Name = "team2" });
            db.Insert(new Team { Id = 3, Name = "team3" });
            
        }
    }
}
