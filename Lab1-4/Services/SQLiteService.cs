using Lab1_4.Entities;
using SQLite;

namespace Lab1_4.Services
{
    public class SQLiteService : IDbService
    {
        private SQLiteConnection? db;
        public IEnumerable<Team>? GetAllTeams()
            => db?.Table<Team>();
        public IEnumerable<Member>? GetMembers(int id)
            => db?.Table<Member>().Where(t => t.TeamId == id);
        public void Init()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "MyDB.db3");
            
            if (File.Exists(dbPath))
            {
                db = new SQLiteConnection(dbPath);
                return;
            }

            db = new SQLiteConnection(dbPath);
            db.CreateTable<Team>();
            db.CreateTable<Member>();
            
            db.Insert(new Team { Name = "Барселона", Emblem = "barcelona.png" });
            db.Insert(new Member() { Name = "Марк-Андре тер Стеген", Number = 1, TeamId = 0, Emblem = "barcelona.png" });
            db.Insert(new Member() { Name = "Жоау Канселу", Number = 2, TeamId = 0, Emblem = "barcelona.png" });
            db.Insert(new Member() { Name = "Алехандро Бальде", Number = 3, TeamId = 0, Emblem = "barcelona.png" });
            db.Insert(new Member() { Name = "Рональд Араухо", Number = 4, TeamId = 0, Emblem = "barcelona.png" });
            db.Insert(new Member() { Name = "Иньиго Мартинес", Number = 5, TeamId = 0, Emblem = "barcelona.png" });
            
            db.Insert(new Team { Name = "Ювентус", Emblem = "juventus.png" });
            db.Insert(new Member() { Name = "Войцех Щенсный", Number = 1, TeamId = 1, Emblem = "juventus.png" });
            db.Insert(new Member() { Name = "Маттия Де Шильо", Number = 2, TeamId = 1, Emblem = "juventus.png" });
            db.Insert(new Member() { Name = "Глейсон Бремер", Number = 3, TeamId = 1, Emblem = "juventus.png" });
            db.Insert(new Member() { Name = "Федерико Гатти", Number = 4, TeamId = 1, Emblem = "juventus.png" });
            
            db.Insert(new Team { Name = "Ливерпуль", Emblem = "liverpool.png" });
            db.Insert(new Member() { Name = "Алиссон Бекер", Number = 1, TeamId = 2, Emblem = "liverpool.png" });
            db.Insert(new Member() { Name = "Джозеф Гомес", Number = 2, TeamId = 2, Emblem = "liverpool.png" });
            db.Insert(new Member() { Name = "Ватару Эндо", Number = 3, TeamId = 2, Emblem = "liverpool.png" });
            db.Insert(new Member() { Name = "Вирджил ван Дейк", Number = 4, TeamId = 2, Emblem = "liverpool.png" });
            db.Insert(new Member() { Name = "Ибраима Конате", Number = 5, TeamId = 2, Emblem = "liverpool.png" });
            db.Insert(new Member() { Name = "Тьяго Алькантара", Number = 6, TeamId = 2, Emblem = "liverpool.png" });

        }
    }
}
