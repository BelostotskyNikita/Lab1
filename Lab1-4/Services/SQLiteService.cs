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
            if (db is not null) return;
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "MyDB.db3");
            if (File.Exists(dbPath)) File.Delete(dbPath);
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Team>();
            db.CreateTable<Member>();
            
            db.Insert(new Team { Name = "team1" });
            db.Insert(new Member() { Name = "Иванов Иван", Number = 1, TeamId = 1 });
            db.Insert(new Member() { Name = "Иванов Иван", Number = 2, TeamId = 1 });
            db.Insert(new Member() { Name = "Иванов Иван", Number = 3, TeamId = 1 });
            db.Insert(new Member() { Name = "Иванов Иван", Number = 4, TeamId = 1 });
            db.Insert(new Member() { Name = "Иванов Иван", Number = 5, TeamId = 1 });
            
            db.Insert(new Team { Name = "team2" });
            db.Insert(new Member() { Name = "Иванов Иван", Number = 11, TeamId = 2 });
            db.Insert(new Member() { Name = "Иванов Иван", Number = 12, TeamId = 2 });
            db.Insert(new Member() { Name = "Иванов Иван", Number = 13, TeamId = 2 });
            db.Insert(new Member() { Name = "Иванов Иван", Number = 14, TeamId = 2 });
            db.Insert(new Member() { Name = "Иванов Иван", Number = 15, TeamId = 2 });
            
            db.Insert(new Team { Name = "team3" });
            db.Insert(new Member() { Name = "Иванов Иван", Number = 21, TeamId = 3 });
            db.Insert(new Member() { Name = "Иванов Иван", Number = 22, TeamId = 3 });
            db.Insert(new Member() { Name = "Иванов Иван", Number = 23, TeamId = 3 });
            db.Insert(new Member() { Name = "Иванов Иван", Number = 24, TeamId = 3 });
            db.Insert(new Member() { Name = "Иванов Иван", Number = 25, TeamId = 3 });
            
        }
    }
}
