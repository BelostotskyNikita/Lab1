using SQLite;

namespace Lab1_4.Entities
{
    [Table("Members")]
    public class Member
    {
        [PrimaryKey, AutoIncrement, Indexed]
        [Column("Id")]
        public int MemberId { get; set; }
        public string? Name { get; set; }
        public int Number { get; set; }
        public string? Emblem { get; set; }
        [Indexed]
        public int TeamId { get; set; }
    }
}
