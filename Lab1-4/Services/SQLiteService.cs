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
            
            db.Insert(new Team { Name = "Барселона" });
            db.Insert(new Member() { Name = "Марк-Андре тер Стеген", Number = 1, TeamId = 0 });
            db.Insert(new Member() { Name = "Жоау Канселу", Number = 2, TeamId = 0 });
            db.Insert(new Member() { Name = "Алехандро Бальде", Number = 3, TeamId = 0 });
            db.Insert(new Member() { Name = "Рональд Араухо", Number = 4, TeamId = 0 });
            db.Insert(new Member() { Name = "Иньиго Мартинес", Number = 5, TeamId = 0 });
            
            db.Insert(new Team { Name = "Ювентус" });
            db.Insert(new Member() { Name = "Войцех Щенсный", Number = 1, TeamId = 1 });
            db.Insert(new Member() { Name = "Маттия Де Шильо", Number = 2, TeamId = 1 });
            db.Insert(new Member() { Name = "Глейсон Бремер", Number = 3, TeamId = 1 });
            db.Insert(new Member() { Name = "Федерико Гатти", Number = 4, TeamId = 1 });
            
            db.Insert(new Team { Name = "Ливерпуль" });
            db.Insert(new Member() { Name = "Алиссон Бекер", Number = 1, TeamId = 2 });
            db.Insert(new Member() { Name = "Джозеф Гомес", Number = 2, TeamId = 2 });
            db.Insert(new Member() { Name = "Ватару Эндо", Number = 3, TeamId = 2 });
            db.Insert(new Member() { Name = "Вирджил ван Дейк", Number = 4, TeamId = 2 });
            db.Insert(new Member() { Name = "Ибраима Конате", Number = 5, TeamId = 2 });
            db.Insert(new Member() { Name = "Тьяго Алькантара", Number = 6, TeamId = 2 });

        }
    }
}
